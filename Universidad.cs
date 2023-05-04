using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratorioJson
{
    public class Universidad
    {
        string nombreUniversidad;
        List<Alumno> alumnos;

        public string NombreUniversidad { get => nombreUniversidad; set => nombreUniversidad = value; }
        public List<Alumno> Alumnos { get => alumnos; set => alumnos = value; }
        
        //Constructor
        public Universidad()
        {
            Alumnos = new List<Alumno>();
        }
    }
}