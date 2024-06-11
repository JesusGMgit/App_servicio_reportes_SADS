using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_servicio_SADS2.clases
{
    internal class ArchivosPH
    {
        private static readonly HttpClient cliente_consulta = new HttpClient();
        private System.Data.DataTable datatable_datos_archivos_PH = new System.Data.DataTable();
        private string path_smartdac_PH = @"C:\Users\Public\Documents\SMARTDAC+ Data Logging Software\Data\PH PRUEBAS\";
        private string path_reportes_PH = @"C:\xampp\htdocs\Reportes\PH\";
        
        public ArchivosPH() 
        {
            
        }
        
        private void IniciarTablaARchivosPH()
        {
            datatable_datos_archivos_PH.Columns.Clear();
            datatable_datos_archivos_PH.Columns.Add("Nombre_Archivo");
            datatable_datos_archivos_PH.Columns.Add("Hora");
            datatable_datos_archivos_PH.Columns.Add("Fecha");
        }

        public bool AgregarArchivosdld_PH(string fecha_busqueda)
        {
            bool status;

            IniciarTablaARchivosPH();

            status = BuscarArchivos_PH(fecha_busqueda);

            if (status == true)
            {
                CopiarArchivosSmartdac_PH();
                BorrarArchivosSamrtdacPH();
                CrearRegistrosArchivosPh();
            }

            return status;
        }


        private bool BuscarArchivos_PH(string fecha)
        {
            datatable_datos_archivos_PH.Rows.Clear();
            System.Data.DataTable tablatemporal = datatable_datos_archivos_PH;
            bool status = false;
            try
            {
                DirectoryInfo di = new DirectoryInfo(path_smartdac_PH);
                string fechabuscada = $"*{fecha}*.dld";
                foreach (var fi in di.GetFiles(fechabuscada))
                {
                    tablatemporal.Rows.Add(fi.Name, fi.LastWriteTime.ToShortTimeString(), fi.LastWriteTime.ToShortDateString());
                    status = true;
                }
                
            }
            catch (Exception err)
            {
                status = false;
                MessageBox.Show("Rellenar tabla:" + err.Message);
            }

            return status;

        }

        
        private void CopiarArchivosSmartdac_PH()
        {
            string path_arch = path_smartdac_PH;
            string sourcepath, destpath;
            for (int i = 0; i < datatable_datos_archivos_PH.Rows.Count; i++)
            {
                sourcepath = path_arch + datatable_datos_archivos_PH.Rows[i]["Nombre_Archivo"];
                destpath = path_reportes_PH + datatable_datos_archivos_PH.Rows[i]["Nombre_Archivo"];
                File.Copy(sourcepath, destpath);
            }

        }

        private void BorrarArchivosSamrtdacPH()
        {
            string path_arch = path_smartdac_PH;
            string sourcepath;
            for (int i = 0; i < datatable_datos_archivos_PH.Rows.Count; i++)
            {
                sourcepath = path_arch + datatable_datos_archivos_PH.Rows[i]["Nombre_Archivo"];
                File.Delete(sourcepath);
            }

        }

        public string CrearRegistrosArchivosPh()
        {
            string url = "http://10.10.20.15/backend/api/ar_tPhArchivos.php";
            string nombreArchivo, fecha, hora, respuesta_consulta = "No";

            if (datatable_datos_archivos_PH.Rows.Count != 0)
            {
                for (int i = 0; i < datatable_datos_archivos_PH.Rows.Count; i++)
                {
                    nombreArchivo = datatable_datos_archivos_PH.Rows[i]["Nombre_Archivo"].ToString();
                    hora = datatable_datos_archivos_PH.Rows[i]["Hora"].ToString();
                    fecha = datatable_datos_archivos_PH.Rows[i]["Fecha"].ToString();
                    respuesta_consulta = Crear_registro(url, nombreArchivo, fecha, hora);
                    
                }
                
            }
            return respuesta_consulta;

        }

        private string Crear_registro(string url, string nombre, string fecha, string hora)
        {
            string fecha_db = Convert.ToDateTime(fecha + " " + hora).ToString("yyyy-MM-dd HH:mm:ss");
            string respuesta_post;
            HttpClient cliente_archivo = new HttpClient();
            Dictionary<string, string> diccionario_crear_registro = new Dictionary<string, string>
                {
                    {"Ph_Nombre", nombre },
                    {"Ph_Hora", hora},
                    {"Ph_Fecha",fecha},
                    {"Ph_Fecha_db",fecha_db}
                };

            //var content = new FormUrlEncodedContent(diccionario);
            var json = JObject.FromObject(diccionario_crear_registro);
            var contenido = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            return respuesta_post = cliente_archivo.PostAsync(url, contenido).Result.ToString().Substring(0, 15);
            
            
        }

    }
}
