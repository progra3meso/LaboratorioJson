using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratorioJson
{
    public class Alumno
    {
        string numeroCarne;
        string nombre;
        string fechaNacimiento;
        string direccion;

        List<Curso> cursos;

        public string NumeroCarne { get => numeroCarne; set => numeroCarne = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public List<Curso> Cursos { get => cursos; set => cursos = value; }
        //CONSTRUCTOR
        public Alumno()
        {
            Cursos = new List<Curso>();
        }
    }
}