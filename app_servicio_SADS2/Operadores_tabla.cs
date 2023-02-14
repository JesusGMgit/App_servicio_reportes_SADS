using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace app_servicio_SADS2
{
    class Operadores_tabla
    {
        [JsonProperty("Op_Folio")]
        public int op_folio { get; set; }
        [JsonProperty("Op_Nombre")]
        public string op_nombre { get; set; }
        [JsonProperty("Op_Clave_soldador")]
        public string op_clave_soldador { get; set; }
        [JsonProperty("Op_Puesto")]
        public string op_puesto { get; set; }
    }
}
