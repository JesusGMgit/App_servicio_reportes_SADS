using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace app_servicio_SADS2
{
    class Proyecto_tabla
    {
        [JsonProperty("Pro_ID")]
        public int pro_id { get; set; }
        [JsonProperty("Pro_Nombre")]
        public string pro_nombre { get; set; }
        [JsonProperty("Pro_Diametro")]
        public String pro_diametro { get; set; }
        [JsonProperty("Pro_Espesor")]
        public String pro_espesor { get; set; }
        [JsonProperty("Pro_Alambre")]
        public string pro_alambre { get; set; }
        [JsonProperty("Pro_Fundente")]
        public string pro_fundente { get; set; }
        [JsonProperty("Pro_OrdenTrabajo")]
        public string pro_ordentrabajo { get; set; }
        [JsonProperty("Pro_Especificacion")]
        public string pro_especificacion { get; set; }
    }
}
