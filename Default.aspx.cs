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

        //static List<Curso> cursosTemporal = new List<Curso>();
        //static List<Registro> registros = new List<Registro>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Grabar(List<Registro> registros)
        {
            string json = JsonConvert.SerializeObject(registros);            
            string archivo = Server.MapPath("Datos.json");
            System.IO.File.WriteAllText(archivo, json);
        }

        private List<Registro> Leer()
        {
            List<Registro> lista = new List<Registro>();            
            string archivo = Server.MapPath("Datos.json");            
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();            
            lista = JsonConvert.DeserializeObject<List<Registro>>(json);

            return lista;
        }



        protected void ButtonNota_Click(object sender, EventArgs e)
        {
            //Curso curso = new Curso();
            //curso.Nombre = TextBoxCurso.Text;
            //curso.Nota = Convert.ToInt32(TextBoxNota.Text);
            //Registro registro = new Registro();
            //registro.Nombre = TextBoxAlumno.Text;
            //curso.
            //cursosTemporal.Add(curso);            

            //Crear una lista de registros
            List<Registro> registros = new List<Registro>();
            //Leer el archivo, y este devuelve una lista de Registros
            registros = Leer();

            //Buscar si el alumno ya existe
            Registro alumnoExiste = registros.Find(a => a.Nombre == TextBoxAlumno.Text);

            //crear un nuevo curso para guardar el curso y la nota
            Curso cursoNuevo = new Curso();
            cursoNuevo.Nombre = TextBoxCurso.Text;
            cursoNuevo.Nota = Convert.ToInt16(TextBoxNota.Text);

            //SI el alumno ya existe solo se le agrega la nota
            if (alumnoExiste != null)
            {
                //al alumno existente se le agrega el nuevo curso
                alumnoExiste.Cursos.Add(cursoNuevo);
                //se manda a grabar de nuevo
                Grabar(registros);
            } 
            // si el alumno no existe se agrega un nuevo registro
            //con una sola nota, para las demás notas se usara el codigo dentro del if
            //cuando ya hay al menos una nota
            else
            {
                //se crea un nuevo registro
                Registro registroNuevo = new Registro();
                //se agrega el nombre del alumno
                registroNuevo.Nombre = TextBoxAlumno.Text;
                //y como es nuevo se le agrega el nuevo curso
                registroNuevo.Cursos.Add(cursoNuevo);
                //se agrega el registro nuevo a la lista de registros
                registros.Add(registroNuevo);
                //se manda a grabar
                Grabar(registros);
            }






        }
        protected void ButtonIngresar_Click(object sender, EventArgs e)
        {
            List<Registro> registros = new List<Registro>();            
            registros = Leer();
            GridView1.DataSource = registros;
            GridView1.DataBind();

        }
    }
}