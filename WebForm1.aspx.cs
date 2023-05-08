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
    public partial class WebForm1 : System.Web.UI.Page
    {       

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            Archivo archivo = new Archivo();
            //Cargar todas las universidades
            List<Universidad> universidades = archivo.Leer();
            //Buscar la universidad que es igual a la ingresada en el textbos
            Universidad universidad = universidades.Find(u => u.NombreUniversidad == TextBoxUniversidad.Text);
            
            //Si no es null, es porque la encontró
            if (universidad != null)
            {
                //mostrar el mensaje en la pantalla
                Response.Write("<script>alert('Universidad Encontrada.')</script>");
                //Mostrar el nombre en la etiqueta
                LabelUniversidad.Text = universidad.NombreUniversidad;
                //Habilitar el botón de borrar
                ButtonEliminar.Enabled = true;
            }
            else //si es null es porque no la encontró
            {
                Response.Write("<script>alert('Universidad no existe!')</script>");
            }
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            //Declarar un objeto de la clase archivo
            Archivo archivo = new Archivo();
            //Cargar de nuevo la lista
            List<Universidad> universidades = archivo.Leer();
            //Buscar la universidad
            Universidad universidad = universidades.Find(u => u.NombreUniversidad == LabelUniversidad.Text);
           //Eliminar esa universidad
            universidades.Remove(universidad);
            Response.Write("<script>alert('Universidad eliminada!')</script>");
            archivo.Grabar(universidades);
        }
    }
}