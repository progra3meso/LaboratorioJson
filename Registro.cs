using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratorioJson
{
    public class Registro
    {
        string nombre;
        List<Curso> cursos;

        public string Nombre { get => nombre; set => nombre = value; }
        public List<Curso> Cursos { get => cursos; set => cursos = value; }

        //Constructor de la clase:
        //ejecuta código al crearse un objeto de esta clase
        public Registro()
        {            
            //crear la lista de cursos
            cursos = new List<Curso>();
        }

    }
}