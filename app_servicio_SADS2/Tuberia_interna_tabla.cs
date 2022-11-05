using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace app_servicio_SADS2
{
    class Tuberia_interna_tabla
    {
        [JsonProperty("Tin_ID_tubo")]
        public ulong Ta_id_tubo { get; set; }
        [JsonProperty("Tin_No_tubo")]
        public string Ta_no_tubo { get; set; }
        [JsonProperty("Tin_No_placa")]
        public string Ta_no_placa { get; set; }
        [JsonProperty("Tin_ID_proyecto")]
        public string Ta_ID_proyecto { get; set; }
        [JsonProperty("Tin_Lote_alambre")]
        public string Ta_lote_alambre { get; set; }
        [JsonProperty("Tin_Lote_fundente")]
        public string Ta_lote_fundente { get; set; }
        [JsonProperty("Tin_FolioOperador")]
        public string Ta_foliooperador { get; set; }
        [JsonProperty("Tin_Fecha")]
        public string Ta_fecha { get; set; }
        [JsonProperty("Tin_Hora")]
        public string Ta_hora { get; set; }
        [JsonProperty("Tin_Hora_db")]
        public DateTime Ta_hora_db { get; set; }
        [JsonProperty("Tin_Archivos_excel")]
        public string Ta_Archivos_excel { get; set; }
        [JsonProperty("Tin_Reporte_excel")]
        public string Ta_Reporte_excel { get; set; }
        [JsonProperty("Tin_Observaciones")]
        public string Ta_Observaciones { get; set; }
    }
}
