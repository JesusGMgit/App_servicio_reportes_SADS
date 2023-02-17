using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace app_servicio_SADS2
{
    class Consultas
    {
        private static readonly HttpClient cliente_consulta = new HttpClient();

        public static string Get_API(string url)
        {
            string responseString = "";
            try
            {
                var response = cliente_consulta.GetStringAsync(url);
                responseString = response.Result;

            }
            catch (Exception err)
            {
                responseString = "error_conexion: " + err.Message;


            }
            return responseString;
        }

        public static string Post_API(string url, StringContent contenido)
        {
            string respuesta_post;

            return respuesta_post = cliente_consulta.PostAsync(url, contenido).Result.ToString();
        }

        public static string Update_API(string url_update, StringContent contenidp_update)
        {
            string respuesta_update;

            respuesta_update = cliente_consulta.PutAsync(url_update, contenidp_update).ToString();
            return respuesta_update;
        }
    }
}
