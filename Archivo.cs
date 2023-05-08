using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;


namespace LaboratorioJson
{
    public class Archivo
    {
        public void Grabar(List<Universidad> universidades)
        {
            string json = JsonConvert.SerializeObject(universidades);
            string archivo = System.Web.HttpContext.Current.Server.MapPath("Datos.json");
            System.IO.File.WriteAllText(archivo, json);
        }


        public List<Universidad> Leer()
        {
            List<Universidad> lista = new List<Universidad>();
            string archivo = System.Web.HttpContext.Current.Server.MapPath("Datos.json");
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            lista = JsonConvert.DeserializeObject<List<Universidad>>(json);

            return lista;
        }



    }
}