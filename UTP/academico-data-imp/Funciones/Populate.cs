using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using academico_common;
using academico_model;
using System.Linq;

namespace academico_data_imp.Funciones
{
    public class Populate
    {

        public Usuario  SetUsuario(SqlDataReader reader)
        {
            return new Usuario()
            {
                idUsuario = (Int32)reader["IdUsuario"] ,
                idTipo = (Int32)reader["IdTipo"],

            };
        }

        public Alumno SetAlumno(SqlDataReader reader)
        {
            return new Alumno()
            {
                idAlumno = (Int32)reader["IdAlumno"],
                codigo = reader["Codigo"] as string,
                numeroDocumento = reader["NumeroDocumento"] as string,
                nombres = reader["Nombres"] as string,
                apellidoPaterno = reader["ApellidoPaterno"] as string,
                apellidoMaterno = reader["ApellidoMaterno"] as string,
                nombreEscuela = reader["nombreEscuela"] as string,
                idEscuela = (Int32)reader["IdEscuela"],
            };
        }

        public Escuela SetEscuela(SqlDataReader reader)
        {
            return new Escuela()
            {
                idEscuela = (Int32)reader["IdEscuela"],
                descripcion = reader["Descripcion"] as string,

            };
        }

        public Ciclo SetCliclo(SqlDataReader reader)
        {
            return new Ciclo()
            {
                idCiclo = (Int32)reader["IdCiclo"],
                descripcion = reader["Descripcion"] as string,

            };
        }

        public Semestre SetSemestre(SqlDataReader reader)
        {
            return new Semestre()
            {
                idSemestre = (Int32)reader["idSemestre"],
                descripcion = reader["descripcion"] as string,

            };
        }

        public Curso SetCurso(SqlDataReader reader)
        {
            return new Curso()
            {
                idCurso = reader.Entero("IdCurso"),
                codigoCurso = reader.Cadena("CodigoCurso"),                
                ciclo = reader.Cadena("Descripcion"),
                creditos = reader.Entero("Creditos"),
                nombreCurso = reader.Cadena("NombreCurso"),
                idEscuela = reader.Entero("idEscuela"),
                idCliclo = reader.Entero("IdCliclo"),
                evaluado = reader.Entero("evaluado"),
                nota = reader.Entero("Calificacion"),
            };
        }

        public Nota SetNota(SqlDataReader reader)
        {
            return new Nota()
            {
                idNota = reader.Entero("idNota"),
                idAlumno = reader.Entero("IdAlumno"),
                idSemestre = reader.Entero("idSemestre"),
            };
        }

    }
}
