using Newtonsoft.Json;
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

        
        protected void ButtonNota_Click(object sender, EventArgs e)
        {
            Archivo archivo = new Archivo();
            //Crear una lista de universidades
            List<Universidad> universidades = new List<Universidad>();
            //Leer el archivo, y este devuelve una lista de universidades
            universidades = archivo.Leer();

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
            else //si la universidad ya existe
            {
                //Busar si el alumno ya existe dentro de esa universidad
                Alumno alumnoExiste = universidadExiste.Alumnos.Find(a => a.Nombre == TextBoxAlumno.Text);

                //Si el alumno no existe crear un nuevo alumno
                if (alumnoExiste == null)
                {
                    Alumno alumnoNuevo = new Alumno();
                    alumnoNuevo.Nombre = TextBoxAlumno.Text;

                    //como es un alumno nuevo se crea el curso, sin buscar si ya existe
                    Curso cursoNuevo = new Curso();
                    //el nombre del curso y la nota se traen desde los textbox
                    cursoNuevo.Nombre = TextBoxCurso.Text;
                    cursoNuevo.Nota = Convert.ToInt16(TextBoxNota.Text);

                    alumnoNuevo.Cursos.Add(cursoNuevo);

                    //agregamos al alumno con sus cursos a la universidad existente

                    universidadExiste.Alumnos.Add(alumnoNuevo);

                }
                else //si el alumno ya existe, ver si el curso ya existe
                {
                    Curso cursoExiste = alumnoExiste.Cursos.Find(c => c.Nombre == TextBoxCurso.Text);

                    //si el curso no existe se crea un nuevo curso
                    if (cursoExiste == null)
                    {
                        //Se crea un nuevo curso
                        Curso cursoNuevo = new Curso();
                        //el nombre del curso y la nota se traen desde los textbox
                        cursoNuevo.Nombre = TextBoxCurso.Text;
                        cursoNuevo.Nota = Convert.ToInt16(TextBoxNota.Text);

                        //se agrega el curso al alumno 
                        alumnoExiste.Cursos.Add(cursoNuevo);
                    }
                }
            }

            //Se manda a grabar la lista de universidades
            archivo.Grabar(universidades);

        }
        protected void ButtonIngresar_Click(object sender, EventArgs e)
        {
            
        }
    }
}