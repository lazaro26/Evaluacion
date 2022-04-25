using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using academico_common;
using academico_data_imp;
using academico_data_intf;
using Serilog;
using static acadecimico_backend.Common.Constantes;
using academico_service_intf;
using academico_service_imp;
using academico_data_imp.Funciones;

namespace acadecimico_backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-XSRF-TOKEN";
                options.SuppressXFrameOptionsHeader = false;
            });

            //Autenticacion
            services.AddAuthentication(options =>
            {
                //AuthenticationScheme = "Bearer"
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = context =>
                    {
                        List<Claim> cl = new List<Claim>(((ClaimsIdentity)context.Principal.Identity).Claims);
                        string strUsuario = cl.Where(c => c.Type == JWT_CLAIM_USUARIO).First().Value;

                        if (string.IsNullOrWhiteSpace(strUsuario))
                        {
                            context.Fail("Unauthorized");
                        }

                        return Task.CompletedTask;
                    }
                };

                //https://tools.ietf.org/html/rfc7519#page-9
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    SaveSigninToken = true,
                    ValidateActor = true,
                    ValidateIssuer = true, //Issuer: Emisor
                    ValidateAudience = true, //Audience: Son los destinatarios del token
                    ValidateLifetime = true, //Lifetime: Tiempo de vida del token
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["ApiAuth:Issuer"],
                    ValidAudience = Configuration["ApiAuth:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["ApiAuth:SecretKey"]))
                };
            });

            //CORS
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(new[]
                    {
                        "http://localhost:4200",
                        "https://webutp.azurewebsites.net"
                    })
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            //LOGs - Serilog RollingLog
            //Log.Logger = new LoggerConfiguration()
            //   .ReadFrom.Configuration(Configuration)
            //   .CreateLogger();


            services.AddScoped(typeof(IUsuarioService), typeof(UsuarioService));
            services.AddScoped(typeof(IUsuarioData), typeof(UsuarioData));
            services.AddScoped(typeof(IAlumnoService), typeof(AlumnoService));
            services.AddScoped(typeof(IAlumnoData), typeof(AlumnoData));
            services.AddScoped(typeof(ICursoService), typeof(CursoService));
            services.AddScoped(typeof(ICursoData), typeof(CursoData));
            services.AddScoped(typeof(IEscuelaService), typeof(EscuelaService));
            services.AddScoped(typeof(IEscuelaData), typeof(EscuelaData));
            services.AddScoped(typeof(ICicloService), typeof(CicloService));
            services.AddScoped(typeof(ICicloData), typeof(CicloData));
            services.AddScoped(typeof(ISemestreService), typeof(SemestreService));
            services.AddScoped(typeof(ISemestreData), typeof(SemestreData));
            services.AddScoped(typeof(INotaService), typeof(NotaService));
            services.AddScoped(typeof(INotaData), typeof(NotaData));

            services.AddScoped<Populate>();

            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Academico API", Version = "v1" });
            });






        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //https://docs.microsoft.com/en-us/aspnet/core/migration/22-to-30?view=aspnetcore-3.0&tabs=visual-studio
            /*For most apps, calls to UseAuthentication, UseAuthorization, and UseCors must appear between 
             * the calls to UseRouting and UseEndpoints to be effective.*/
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");

            loggerFactory.AddSerilog();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Academico API");
            });
        }
    }
}
