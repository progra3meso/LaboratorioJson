using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratorioJson
{
    public class Curso
    {
        string nombre;
        int nota;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Nota { get => nota; set => nota = value; }
    }
}