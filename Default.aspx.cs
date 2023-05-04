﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaboratorioJson
{
    public partial class _Default : Page
    {
         
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Grabar(List<Universidad> universidades)
        {
            string json = JsonConvert.SerializeObject(universidades);            
            string archivo = Server.MapPath("Datos.json");
            System.IO.File.WriteAllText(archivo, json);
        }

        
        private List<Universidad> Leer()
        {
            List<Universidad> lista = new List<Universidad>();            
            string archivo = Server.MapPath("Datos.json");            
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();            
            lista = JsonConvert.DeserializeObject<List<Universidad>>(json);

            return lista;
        }



        protected void ButtonNota_Click(object sender, EventArgs e)
        {              
            //Crear una lista de universidades
            List<Universidad> universidades = new List<Universidad>();
            //Leer el archivo, y este devuelve una lista de universidades
            universidades = Leer();

            //si es la primera vez que se corre hay que crear la lista de universidad
            //pues el archivo estará en blanco
            if (universidades == null)
                universidades = new List<Universidad>();

            //ver si la universidad que se está ingresando ya existe
            Universidad universidadExiste = universidades.Find(u => u.NombreUniversidad == DropDownListUniversidad.SelectedValue);

            //si no existe la universidad crear una nueva
            if (universidadExiste == null) 
            {
                //Crear una nueva universidad
                Universidad universidadNueva = new Universidad();

                //El nombre de la universidad se trae desde el dropdownlist
                universidadNueva.NombreUniversidad = DropDownListUniversidad.SelectedValue;

                //crear un nuevo alumno
                Alumno alumnoNuevo = new Alumno();
                //el nombre del alumno se trae desde el textbox
                alumnoNuevo.Nombre = TextBoxAlumno.Text;

                //crear el nuevo curso
                Curso cursoNuevo = new Curso();
                //el nombre del curso y la nota se traen desde los textbox
                cursoNuevo.Nombre = TextBoxCurso.Text;
                cursoNuevo.Nota = Convert.ToInt16(TextBoxNota.Text);

                //Al alumno se le agrega el curso nuevo
                alumnoNuevo.Cursos.Add(cursoNuevo);

                //A la universidad se le agregar el alumno nuevo
                universidadNueva.Alumnos.Add(alumnoNuevo);

                //A la lista de universidades se le agrega la nueva universidad
                universidades.Add(universidadNueva);
            }

            //Se manda a grabar la lista de universidades
            Grabar(universidades);

        }
        protected void ButtonIngresar_Click(object sender, EventArgs e)
        {
            
        }
    }
}