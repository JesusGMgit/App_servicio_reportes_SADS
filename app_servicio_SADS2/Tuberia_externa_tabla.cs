using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace app_servicio_SADS2
{
    class Tuberia_externa_tabla
    {
        [JsonProperty("Tex_ID_tubo")]
        public string Ta_id_tubo { get; set; }
        [JsonProperty("Tex_No_tubo")]
        public string Ta_no_tubo { get; set; }
        [JsonProperty("Tex_No_placa")]
        public string Ta_no_placa { get; set; }
        [JsonProperty("Tex_ID_proyecto")]
        public string Ta_ID_proyecto { get; set; }
        [JsonProperty("Tex_Lote_alambre")]
        public string Ta_lote_alambre { get; set; }
        [JsonProperty("Tex_Lote_fundente")]
        public string Ta_lote_fundente { get; set; }
        [JsonProperty("Tex_FolioOperador")]
        public string Ta_foliooperador { get; set; }
        [JsonProperty("Tex_Fecha")]
        public string Ta_fecha { get; set; }
        [JsonProperty("Tex_Hora")]
        public string Ta_hora { get; set; }
        [JsonProperty("Tex_Hora_db")]
        public DateTime Ta_hora_db { get; set; }
        [JsonProperty("Tex_Archivos_excel")]
        public string Ta_Archivos_excel { get; set; }
        [JsonProperty("Tex_Reporte_excel")]
        public string Ta_Reporte_excel { get; set; }
        [JsonProperty("Tex_Observaciones")]
        public string Ta_Observaciones { get; set; }

    }
}
