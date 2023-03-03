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
        public UInt32 T_ID_Rtubo { get; set; }
        public string T_ID_tubo { get; set; }
       
        public string T_No_tubo { get; set; }
       
        public string T_No_placa { get; set; }
        
        public int T_ID_proyecto { get; set; }
        
        public string T_Lote_alambre { get; set; }
        
        public string T_Lote_fundente { get; set; }
        
        public int T_Foliooperador { get; set; }
       
        public string T_Fecha { get; set; }
        
        public string T_Hora { get; set; }
        
        public DateTime T_Hora_db { get; set; }
        
        public string T_Archivos_excel { get; set; }
        
        public string T_Reporte_excel { get; set; }
        
        public string T_Observaciones { get; set; }
    }
}
