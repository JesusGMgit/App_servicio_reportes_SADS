using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_servicio_SADS2
{
    public partial class Busqueda_tubo : Form
    {
        string P_url_apis = "http://10.10.20.15/backend/api/";
        DataTable P_Tuberia_datatable = new DataTable();

        public Busqueda_tubo()
        {
            InitializeComponent();
        }
        
        private void Busqueda_maquinas(string No_tubo)
        {
          
            string url_api;

            string data_tubo;
            
            for (int i = 1; i < 4; i++)
            {
                url_api =P_url_apis + $"ar_tTuberiaInterna_{i}.php?T_No_tubo={No_tubo}";
                data_tubo = Consultas.Get_API(url_api);
                if (data_tubo != "null")
                {
                    List<Tuberia_interna_tabla> temporal_results = JsonConvert.DeserializeObject<List<Tuberia_interna_tabla>>(data_tubo);
                    foreach (var r in temporal_results)
                    {
                        P_Tuberia_datatable.Rows.Add("INTERNA" + i, r.T_No_tubo, r.T_No_placa, r.T_ID_proyecto, r.T_Lote_alambre,
                           r.T_Lote_fundente, r.T_Foliooperador, r.T_Fecha, r.T_Hora, r.T_Hora_db, r.T_Archivos_excel, 
                           r.T_Observaciones, r.T_Reporte_excel);
                    }

                }
            }

            for (int i = 1; i < 4; i++)
            {
                url_api = P_url_apis + $"ar_tTuberiaExterna_{i}.php?T_No_tubo={No_tubo}";
                data_tubo = Consultas.Get_API(url_api);
                if (data_tubo != "null")
                {
                    List<Tuberia_interna_tabla> temporal_results = JsonConvert.DeserializeObject<List<Tuberia_interna_tabla>>(data_tubo);
                    foreach (var r in temporal_results)
                    {
                        P_Tuberia_datatable.Rows.Add("EXTERNA"+i,r.T_No_tubo, r.T_No_placa, r.T_ID_proyecto, r.T_Lote_alambre,
                           r.T_Lote_fundente, r.T_Foliooperador, r.T_Fecha, r.T_Hora, r.T_Hora_db, r.T_Archivos_excel,
                           r.T_Observaciones, r.T_Reporte_excel);
                    }

                }
            }


        }

        void Iniciar_tabla_tuberia()
        {
            //P_Tuberia_datatable.Columns.Add("T_id_Rtubo");
            //P_Tuberia_datatable.Columns.Add("T_id_tubo");
            P_Tuberia_datatable.Columns.Add("T_Maquina");
            P_Tuberia_datatable.Columns.Add("T_no_tubo");
            P_Tuberia_datatable.Columns.Add("T_no_placa");
            P_Tuberia_datatable.Columns.Add("T_ID_proyecto");
            P_Tuberia_datatable.Columns.Add("T_lote_alambre");
            P_Tuberia_datatable.Columns.Add("T_lote_fundente");
            P_Tuberia_datatable.Columns.Add("T_foliooperador");
            P_Tuberia_datatable.Columns.Add("T_fecha");
            P_Tuberia_datatable.Columns.Add("T_hora");
            P_Tuberia_datatable.Columns.Add("T_hora_db");
            P_Tuberia_datatable.Columns.Add("T_Archivo_excel");
            P_Tuberia_datatable.Columns.Add("T_Observaciones");
            P_Tuberia_datatable.Columns.Add("T_Reporte_excel");
        }
            private void btnBusqueda_Click(object sender, EventArgs e)
        {
            dgvTuboBuscado.DataSource = null;
            P_Tuberia_datatable.DefaultView.RowFilter = "T_no_tubo NOT IN (.)";
            P_Tuberia_datatable.Rows.Clear();
            dgvTuboBuscado.DataSource = P_Tuberia_datatable;

            Busqueda_maquinas(txbNoTubo.Text);
            dgvTuboBuscado.DataSource = P_Tuberia_datatable;
        }

        private void Busqueda_tubo_Load(object sender, EventArgs e)
        {
            Iniciar_tabla_tuberia();
        }
    }
}
