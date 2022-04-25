USE [master]
GO
/****** Object:  Database [Academico]    Script Date: 25/04/2022 08:20:47 ******/
CREATE DATABASE [Academico]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Academico', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Academico.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Academico_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Academico_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Academico].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Academico] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Academico] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Academico] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Academico] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Academico] SET ARITHABORT OFF 
GO
ALTER DATABASE [Academico] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Academico] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Academico] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Academico] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Academico] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Academico] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Academico] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Academico] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Academico] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Academico] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Academico] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Academico] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Academico] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Academico] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Academico] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Academico] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Academico] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Academico] SET RECOVERY FULL 
GO
ALTER DATABASE [Academico] SET  MULTI_USER 
GO
ALTER DATABASE [Academico] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Academico] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Academico] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Academico] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Academico', N'ON'
GO
USE [Academico]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[IdAlumno] [int] IDENTITY(1,1) NOT NULL,
	[idEscuela] [int] NULL,
	[Codigo] [varchar](10) NULL,
	[NumeroDocumento] [varchar](12) NULL,
	[Nombres] [varchar](50) NULL,
	[ApellidoPaterno] [varchar](50) NULL,
	[ApellidoMaterno] [varchar](50) NULL,
	[eliminado] [bit] NULL,
	[IdUsuario] [int] NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[IdAlumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciclo]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciclo](
	[IdCiclo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](5) NULL,
	[Eliminado] [bit] NULL,
 CONSTRAINT [PK_Ciclo] PRIMARY KEY CLUSTERED 
(
	[IdCiclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[IdCurso] [int] IDENTITY(1,1) NOT NULL,
	[IdCliclo] [int] NULL,
	[idEscuela] [int] NULL,
	[CodigoCurso] [varchar](10) NULL,
	[Creditos] [int] NULL,
	[NombreCurso] [varchar](50) NULL,
	[eliminado] [bit] NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[IdCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Docente]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Docente](
	[IdDocente] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NULL,
	[ApellidoPaterno] [varchar](50) NULL,
	[ApellidoMaterno] [varchar](50) NULL,
	[Eliminado] [bit] NULL,
	[IdUsuario] [int] NULL,
 CONSTRAINT [PK_Docente] PRIMARY KEY CLUSTERED 
(
	[IdDocente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Escuela]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Escuela](
	[IdEscuela] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](150) NULL,
	[Eliminado] [bit] NULL,
 CONSTRAINT [PK_Escuela] PRIMARY KEY CLUSTERED 
(
	[IdEscuela] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nota]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nota](
	[idNota] [int] IDENTITY(1,1) NOT NULL,
	[IdAlumno] [int] NULL,
	[idSemestre] [int] NULL,
	[eliminado] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
	[UsurioRegistro] [varchar](50) NULL,
 CONSTRAINT [PK_Nota] PRIMARY KEY CLUSTERED 
(
	[idNota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotaDetalle]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotaDetalle](
	[idNotaDetalle] [int] IDENTITY(1,1) NOT NULL,
	[idNota] [int] NULL,
	[IdCurso] [int] NULL,
	[Calificacion] [decimal](18, 2) NULL,
	[eliminado] [bit] NULL,
 CONSTRAINT [PK_NotaDetalle] PRIMARY KEY CLUSTERED 
(
	[idNotaDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semestre]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semestre](
	[idSemestre] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](7) NULL,
	[eliminado] [bit] NULL,
 CONSTRAINT [PK_Semestre] PRIMARY KEY CLUSTERED 
(
	[idSemestre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdTipo] [int] NULL,
	[Usuario] [varchar](50) NULL,
	[Clave] [varchar](50) NULL,
	[eliminado] [bit] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alumno] ON 

INSERT [dbo].[Alumno] ([IdAlumno], [idEscuela], [Codigo], [NumeroDocumento], [Nombres], [ApellidoPaterno], [ApellidoMaterno], [eliminado], [IdUsuario]) VALUES (1, 1, N'000001', N'45022559', N'Jorge', N'Lazaro', N'Morales', 0, 1)
INSERT [dbo].[Alumno] ([IdAlumno], [idEscuela], [Codigo], [NumeroDocumento], [Nombres], [ApellidoPaterno], [ApellidoMaterno], [eliminado], [IdUsuario]) VALUES (3, 1, N'000002', N'41526398', N'Marco', N'Castro', N'Lazaro', 0, 5)
INSERT [dbo].[Alumno] ([IdAlumno], [idEscuela], [Codigo], [NumeroDocumento], [Nombres], [ApellidoPaterno], [ApellidoMaterno], [eliminado], [IdUsuario]) VALUES (4, 1, N'000003', N'74859632', N'LEONEL', N'MESI', N'PALACIOS', 0, NULL)
INSERT [dbo].[Alumno] ([IdAlumno], [idEscuela], [Codigo], [NumeroDocumento], [Nombres], [ApellidoPaterno], [ApellidoMaterno], [eliminado], [IdUsuario]) VALUES (5, 1, N'000005', N'41526385', N'JUAN', N'MARIAN', N'POLAR', 0, NULL)
INSERT [dbo].[Alumno] ([IdAlumno], [idEscuela], [Codigo], [NumeroDocumento], [Nombres], [ApellidoPaterno], [ApellidoMaterno], [eliminado], [IdUsuario]) VALUES (6, 1, N'000006', N'74185296', N'PAOLO', N'GUERRERO', N'GUADALUPE', 0, NULL)
INSERT [dbo].[Alumno] ([IdAlumno], [idEscuela], [Codigo], [NumeroDocumento], [Nombres], [ApellidoPaterno], [ApellidoMaterno], [eliminado], [IdUsuario]) VALUES (7, 1, N'000007', N'85961232', N'MARIA', N'MORALES', N'PEREZ', 0, NULL)
INSERT [dbo].[Alumno] ([IdAlumno], [idEscuela], [Codigo], [NumeroDocumento], [Nombres], [ApellidoPaterno], [ApellidoMaterno], [eliminado], [IdUsuario]) VALUES (8, 1, N'000008', N'44454152', N'MATEO', N'PASTOR', N'PEREZ', 0, NULL)
SET IDENTITY_INSERT [dbo].[Alumno] OFF
GO
SET IDENTITY_INSERT [dbo].[Ciclo] ON 

INSERT [dbo].[Ciclo] ([IdCiclo], [Descripcion], [Eliminado]) VALUES (1, N'I', 0)
INSERT [dbo].[Ciclo] ([IdCiclo], [Descripcion], [Eliminado]) VALUES (2, N'II', 0)
INSERT [dbo].[Ciclo] ([IdCiclo], [Descripcion], [Eliminado]) VALUES (3, N'III', 0)
INSERT [dbo].[Ciclo] ([IdCiclo], [Descripcion], [Eliminado]) VALUES (4, N'IV', 0)
INSERT [dbo].[Ciclo] ([IdCiclo], [Descripcion], [Eliminado]) VALUES (5, N'V', 0)
INSERT [dbo].[Ciclo] ([IdCiclo], [Descripcion], [Eliminado]) VALUES (6, N'VI', 0)
INSERT [dbo].[Ciclo] ([IdCiclo], [Descripcion], [Eliminado]) VALUES (7, N'VII', 0)
INSERT [dbo].[Ciclo] ([IdCiclo], [Descripcion], [Eliminado]) VALUES (8, N'VIII', 0)
INSERT [dbo].[Ciclo] ([IdCiclo], [Descripcion], [Eliminado]) VALUES (9, N'IX', 0)
INSERT [dbo].[Ciclo] ([IdCiclo], [Descripcion], [Eliminado]) VALUES (10, N'X', 0)
SET IDENTITY_INSERT [dbo].[Ciclo] OFF
GO
SET IDENTITY_INSERT [dbo].[Curso] ON 

INSERT [dbo].[Curso] ([IdCurso], [IdCliclo], [idEscuela], [CodigoCurso], [Creditos], [NombreCurso], [eliminado]) VALUES (1, 1, 1, N'L0001', 3, N'LENGUAJE', 0)
INSERT [dbo].[Curso] ([IdCurso], [IdCliclo], [idEscuela], [CodigoCurso], [Creditos], [NombreCurso], [eliminado]) VALUES (2, 1, 1, N'M001', 3, N'MATEMATICA 1', 0)
INSERT [dbo].[Curso] ([IdCurso], [IdCliclo], [idEscuela], [CodigoCurso], [Creditos], [NombreCurso], [eliminado]) VALUES (3, 1, 1, N'CI001', 2, N'CIENCIA SOCIALES', 0)
INSERT [dbo].[Curso] ([IdCurso], [IdCliclo], [idEscuela], [CodigoCurso], [Creditos], [NombreCurso], [eliminado]) VALUES (4, 1, 1, N'IF001', 2, N'INFORMATICA', 0)
INSERT [dbo].[Curso] ([IdCurso], [IdCliclo], [idEscuela], [CodigoCurso], [Creditos], [NombreCurso], [eliminado]) VALUES (5, 1, 1, N'ET001', 2, N'EDUCACION PARA EL TRABAJO', 0)
SET IDENTITY_INSERT [dbo].[Curso] OFF
GO
SET IDENTITY_INSERT [dbo].[Docente] ON 

INSERT [dbo].[Docente] ([IdDocente], [Nombres], [ApellidoPaterno], [ApellidoMaterno], [Eliminado], [IdUsuario]) VALUES (1, N'PEDRO', N'LAURA', N'MARCA', 0, 6)
SET IDENTITY_INSERT [dbo].[Docente] OFF
GO
SET IDENTITY_INSERT [dbo].[Escuela] ON 

INSERT [dbo].[Escuela] ([IdEscuela], [Descripcion], [Eliminado]) VALUES (1, N'INGENIERIA DE SISTEMAS', 0)
SET IDENTITY_INSERT [dbo].[Escuela] OFF
GO
SET IDENTITY_INSERT [dbo].[Nota] ON 

INSERT [dbo].[Nota] ([idNota], [IdAlumno], [idSemestre], [eliminado], [FechaRegistro], [UsurioRegistro]) VALUES (1, 1, 1, 0, NULL, NULL)
INSERT [dbo].[Nota] ([idNota], [IdAlumno], [idSemestre], [eliminado], [FechaRegistro], [UsurioRegistro]) VALUES (2, 3, 1, 0, CAST(N'2022-04-24T13:27:03.743' AS DateTime), N'JORGE')
SET IDENTITY_INSERT [dbo].[Nota] OFF
GO
SET IDENTITY_INSERT [dbo].[NotaDetalle] ON 

INSERT [dbo].[NotaDetalle] ([idNotaDetalle], [idNota], [IdCurso], [Calificacion], [eliminado]) VALUES (1, 1, 1, CAST(15.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[NotaDetalle] ([idNotaDetalle], [idNota], [IdCurso], [Calificacion], [eliminado]) VALUES (2, 2, 1, CAST(15.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[NotaDetalle] ([idNotaDetalle], [idNota], [IdCurso], [Calificacion], [eliminado]) VALUES (3, 2, 2, CAST(14.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[NotaDetalle] ([idNotaDetalle], [idNota], [IdCurso], [Calificacion], [eliminado]) VALUES (4, 2, 3, CAST(13.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[NotaDetalle] ([idNotaDetalle], [idNota], [IdCurso], [Calificacion], [eliminado]) VALUES (5, 2, 4, CAST(12.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[NotaDetalle] ([idNotaDetalle], [idNota], [IdCurso], [Calificacion], [eliminado]) VALUES (6, 2, 5, CAST(11.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[NotaDetalle] ([idNotaDetalle], [idNota], [IdCurso], [Calificacion], [eliminado]) VALUES (7, 1, 2, CAST(15.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[NotaDetalle] ([idNotaDetalle], [idNota], [IdCurso], [Calificacion], [eliminado]) VALUES (8, 1, 3, CAST(15.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[NotaDetalle] ([idNotaDetalle], [idNota], [IdCurso], [Calificacion], [eliminado]) VALUES (9, 1, 4, CAST(15.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[NotaDetalle] ([idNotaDetalle], [idNota], [IdCurso], [Calificacion], [eliminado]) VALUES (10, 1, 5, CAST(15.00 AS Decimal(18, 2)), 0)
SET IDENTITY_INSERT [dbo].[NotaDetalle] OFF
GO
SET IDENTITY_INSERT [dbo].[Semestre] ON 

INSERT [dbo].[Semestre] ([idSemestre], [descripcion], [eliminado]) VALUES (1, N'2022-1', 0)
SET IDENTITY_INSERT [dbo].[Semestre] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([IdUsuario], [IdTipo], [Usuario], [Clave], [eliminado]) VALUES (1, 1, N'jorge', N'123', 0)
INSERT [dbo].[Usuario] ([IdUsuario], [IdTipo], [Usuario], [Clave], [eliminado]) VALUES (5, 1, N'castro', N'123', 0)
INSERT [dbo].[Usuario] ([IdUsuario], [IdTipo], [Usuario], [Clave], [eliminado]) VALUES (6, 2, N'laura', N'123', 0)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_Escuela] FOREIGN KEY([idEscuela])
REFERENCES [dbo].[Escuela] ([IdEscuela])
GO
ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_Escuela]
GO
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_Usuario]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Ciclo] FOREIGN KEY([IdCliclo])
REFERENCES [dbo].[Ciclo] ([IdCiclo])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_Ciclo]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Escuela] FOREIGN KEY([idEscuela])
REFERENCES [dbo].[Escuela] ([IdEscuela])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_Escuela]
GO
ALTER TABLE [dbo].[Docente]  WITH CHECK ADD  CONSTRAINT [FK_Docente_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Docente] CHECK CONSTRAINT [FK_Docente_Usuario]
GO
ALTER TABLE [dbo].[Nota]  WITH CHECK ADD  CONSTRAINT [FK_Nota_Alumno] FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumno] ([IdAlumno])
GO
ALTER TABLE [dbo].[Nota] CHECK CONSTRAINT [FK_Nota_Alumno]
GO
ALTER TABLE [dbo].[Nota]  WITH CHECK ADD  CONSTRAINT [FK_Nota_Semestre] FOREIGN KEY([idSemestre])
REFERENCES [dbo].[Semestre] ([idSemestre])
GO
ALTER TABLE [dbo].[Nota] CHECK CONSTRAINT [FK_Nota_Semestre]
GO
ALTER TABLE [dbo].[NotaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_NotaDetalle_Curso] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Curso] ([IdCurso])
GO
ALTER TABLE [dbo].[NotaDetalle] CHECK CONSTRAINT [FK_NotaDetalle_Curso]
GO
ALTER TABLE [dbo].[NotaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_NotaDetalle_Nota] FOREIGN KEY([idNota])
REFERENCES [dbo].[Nota] ([idNota])
GO
ALTER TABLE [dbo].[NotaDetalle] CHECK CONSTRAINT [FK_NotaDetalle_Nota]
GO
/****** Object:  StoredProcedure [dbo].[usp_consultar_nota_alumno]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_consultar_nota_alumno]
 @IdAlumno  int ,
 @idSemestre  int

as
begin

select idNota,
       IdAlumno,	
	   idSemestre
  from Nota where IdAlumno = @IdAlumno	and idSemestre = @idSemestre and  eliminado = 0


end


GO
/****** Object:  StoredProcedure [dbo].[usp_ConsultarUsuario]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_ConsultarUsuario] (
 @usuario as varchar(50),
 @clave as varchar(50)
)
as
begin


  select IdUsuario ,IdTipo from [dbo].[Usuario]  where Usuario = @usuario  and Clave =@clave;

end

GO
/****** Object:  StoredProcedure [dbo].[usp_lista_curso_escuela]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_lista_curso_escuela] 
 @idEscuela  int,
 @IdCliclo   int,
 @IdAlumno   int,
 @idSemestre int
as
begin

with Calificacacion as (
select B.IdCurso,
       B.Calificacion,
	   1 evaluado
from [dbo].[Nota] A
inner join [dbo].[NotaDetalle] B on B.idNota = A.idNota
where A.IdAlumno   = @IdAlumno
  and A.idSemestre = @idSemestre
  and A.eliminado =0
  and B.eliminado =0

)


select A.IdCurso,
       A.CodigoCurso,
       B.Descripcion,
	   A.Creditos,
       A.NombreCurso,
	   A.idEscuela,
	   A.IdCliclo,
	   isnull(evaluado ,0) evaluado,
	   C.Calificacion
from [dbo].[Curso] A
inner join [dbo].[Ciclo]  B on A.IdCliclo = B.IdCiclo
left  join Calificacacion C on C.IdCurso  = A.IdCurso
 where A.idEscuela = @idEscuela
   and A.IdCliclo = @IdCliclo
 end






GO
/****** Object:  StoredProcedure [dbo].[usp_lista_curso_escuela_alumno]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_lista_curso_escuela_alumno] 
 @idEscuela  int,
 @IdAlumno   int,
 @idSemestre int
as
begin



 select 
       C.IdCurso,
       C.CodigoCurso,
       J.Descripcion,
	   C.Creditos,
       C.NombreCurso,
	   C.idEscuela,
	   C.IdCliclo,
	   1 evaluado,
	   B.Calificacion
from [dbo].[Nota] A
inner join [dbo].[NotaDetalle] B on B.idNota = A.idNota
inner join [dbo].[Curso]       C on C.IdCurso = B.IdCurso
inner join [dbo].[Ciclo]       J on J.IdCiclo = C.IdCliclo
where A.IdAlumno   = @IdAlumno
  and A.idSemestre = @idSemestre
  and A.eliminado =0
  and B.eliminado =0
  and C.idEscuela = @idEscuela

end
GO
/****** Object:  StoredProcedure [dbo].[usp_lista_semestre_alumno]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[usp_lista_semestre_alumno]
 @IdAlumno int
as
begin


select A.idSemestre,
       A.descripcion
 from [dbo].[Semestre] A
inner join [dbo].[Nota] B on B.idSemestre = A.idSemestre
where IdAlumno = @IdAlumno

end
GO
/****** Object:  StoredProcedure [dbo].[usp_listaAlumnos]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_listaAlumnos] (
  @Nombres varchar(50)
)

as
begin


select
A.IdAlumno,
A.Codigo,
A.NumeroDocumento,
upper(A.Nombres) Nombres,
upper(A.ApellidoPaterno) ApellidoPaterno,
upper(A.ApellidoMaterno) ApellidoMaterno,
A.IdEscuela,
B.Descripcion nombreEscuela
from  Alumno A
inner join Escuela B on  B.IdEscuela = A.IdEscuela

where A.eliminado = 0
 and  A.Nombres + A.ApellidoMaterno + A.ApellidoMaterno like '%'+ @Nombres+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[usp_listar_ciclo]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_listar_ciclo]

as
begin

select IdCiclo,	Descripcion	  from   [dbo].[Ciclo]  where Eliminado = 0


end


GO
/****** Object:  StoredProcedure [dbo].[usp_listar_escuela]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_listar_escuela]

as
begin

select 	IdEscuela,	Descripcion	  from [dbo].[Escuela] where Eliminado = 0

end



GO
/****** Object:  StoredProcedure [dbo].[usp_listar_semestre]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_listar_semestre]

as
begin

select idSemestre ,	descripcion  from [dbo].[Semestre]  where eliminado = 0


end
GO
/****** Object:  StoredProcedure [dbo].[usp_obtener_dato_alumno]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_obtener_dato_alumno] 
 @IdUsuario int
as
begin

select
A.IdAlumno,
A.Codigo,
A.NumeroDocumento,
upper(A.Nombres) Nombres,
upper(A.ApellidoPaterno) ApellidoPaterno,
upper(A.ApellidoMaterno) ApellidoMaterno,
A.IdEscuela,
B.Descripcion nombreEscuela
from  Alumno A
inner join Escuela B on  B.IdEscuela = A.IdEscuela

where A.eliminado = 0
  and A.IdUsuario = @IdUsuario  
end
GO
/****** Object:  StoredProcedure [dbo].[usp_obtener_dato_usuario]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_obtener_dato_usuario]
 @Usuario  varchar(50),
 @Clave varchar(50)
as
begin

select IdUsuario, IdTipo  from [dbo].[Usuario]
 where Usuario = @Usuario
    and Clave = @Clave

end
GO
/****** Object:  StoredProcedure [dbo].[usp_registrar_alumno]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_registrar_alumno](
@NumeroDocumento varchar(12),
@Nombres varchar(50),
@ApellidoPaterno varchar(50),
@ApellidoMaterno varchar(50),
@idEscuela int
)
as
begin
declare @ultimo int

INSERT INTO [dbo].[Alumno]
           (
            [NumeroDocumento]
           ,[Nombres]
           ,[ApellidoPaterno]
           ,[ApellidoMaterno]
           ,[eliminado]
		   ,[idEscuela])
     VALUES
           (
            @NumeroDocumento
           ,upper(@Nombres)
           ,upper(@ApellidoPaterno)
           ,upper(@ApellidoMaterno)
           ,0
		   ,@idEscuela)

set  @ultimo  = SCOPE_IDENTITY();

update [dbo].[Alumno]
  set Codigo = RIGHT('000000' + Ltrim(Rtrim(@ultimo)),6)
where  IdAlumno = @ultimo

end


GO
/****** Object:  StoredProcedure [dbo].[usp_registrar_alumno_usuario]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_registrar_alumno_usuario](
 @IdAlumno int,
 @IdUsuario int)
 as
 begin

 update [dbo].[Alumno]
   set IdUsuario = @IdUsuario
 where IdAlumno = @IdAlumno

 end
GO
/****** Object:  StoredProcedure [dbo].[usp_registrar_nota]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[usp_registrar_nota]
  @IdAlumno int,
  @idSemestre  int,
  @UsurioRegistro varchar(50),
  @IdNota int OUTPUT 
as
begin
insert into [dbo].[Nota]
 (IdAlumno,
  idSemestre,
  eliminado,
  FechaRegistro,
  UsurioRegistro
 ) values
 (@IdAlumno,
  @idSemestre,
  0,
  getdate(),
  @UsurioRegistro
 );

  set @IdNota = SCOPE_IDENTITY();
end
GO
/****** Object:  StoredProcedure [dbo].[usp_registrar_nota_detalle]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_registrar_nota_detalle]
 @idNota int,
 @IdCurso int,
 @Calificacion decimal(18,2)
as
begin

INSERT INTO [dbo].[NotaDetalle]
           (idNota
           ,IdCurso
           ,Calificacion
           ,eliminado)
     VALUES
           (@idNota,
		    @IdCurso,
			@Calificacion,
			0)



end
GO
/****** Object:  StoredProcedure [dbo].[usp_registrar_usuario]    Script Date: 25/04/2022 08:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[usp_registrar_usuario](
 @IdTipo int,
 @usuario  varchar(50),
 @clave  varchar(50),
 @IdUsuario int OUTPUT 
 )
 as
 begin

  insert into [dbo].[Usuario]
      (IdTipo,
	   Usuario,
	   Clave,
       eliminado
	  )
	  values(
	   @IdTipo,
	   @Usuario,
	   @Clave,
       0
	  );

 set @IdUsuario = SCOPE_IDENTITY();

 end
GO
USE [master]
GO
ALTER DATABASE [Academico] SET  READ_WRITE 
GO
