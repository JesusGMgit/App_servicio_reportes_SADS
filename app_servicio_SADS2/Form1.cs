using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Globalization;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;


namespace app_servicio_SADS2
{
    public partial class frmPrincipal : Form
    {
        private static readonly HttpClient cliente = new HttpClient();
        string pathP = @"C:\Users\Public\Documents\SMARTDAC+ Data Logging Software\Data\";
        string path_temporal = "", P_maquina_reporte;
        string path_reportes_excel = @"C:\xampp\htdocs\Reportes\";
        int P_contador_tmr = 0, P_numero_minutos = 1;
        DateTime P_hora_anterior = new DateTime(2008, 08, 08, 08, 08, 08);
        DateTime P_hora_now, P_hora_registro_anterior, P_temporal_datetime, P_fecha_ayer;
        DataTable P_Tuberia_datatable = new DataTable();
        DataTable P_tuberia_datatable_ayer = new DataTable();
        DataTable P_proyecto_datatable = new DataTable();
        DataTable P_Tabla_excel = new DataTable();
        DataTable P_operador_datatable = new DataTable();
        DataView P_tuberia_dataview;
        bool P_manual, P_registro_nuevo_archivo, P_auto_un_registro, P_no_hay_archivos_ayer=true;
        string P_fecha_busqueda, P_url_get, P_url_update, P_url_insert, P_ID_tubo;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        //subrutinas o funciones usadas por lo elementos del formulario
        
        //subrutinas para iniciar varaibles u obejtos del proyecto
        
        void Iniciar_formulario_principal()
        {
            this.Height = 350;
            this.Width = 400;
            Iniciar_datagrid();
            ltbArchivosExcel.Items.Clear();
            ltbTemporal.Items.Clear();
            ltbTemporal2.Items.Clear();
            txbManualFecha.Text = "";
            txbManualHoraFinal.Text = "";
            txbManualHoraInicial.Text = "";
            cmbManualMaquina.Items.Clear();
            cmbManualSoldadura.Items.Clear();
            btnIniciarAuto.Enabled = true;
            btnPararAuto.Enabled = true;
            txbManualHoraFinal.Enabled = false;
            txbManualHoraInicial.Enabled = false;
            btnGuardarExcel.Enabled = false;
            btnCrearExcel.Enabled = false;
            ptbIndicador2.Image = iglImagenes.Images[5];
            btnModoManual.Text = "ABRIR";
        }
        void Iniciar_datagrid()
        {
            //borra todo el datagrid
            dgvDatosTabla.DataSource=null;

        }

        void Iniciar_tabla_tuberia()
        {
            P_Tuberia_datatable.Columns.Add("T_id_tubo");
            P_Tuberia_datatable.Columns.Add("T_no_tubo");
            P_Tuberia_datatable.Columns.Add("T_no_placa");
            P_Tuberia_datatable.Columns.Add("T_ID_proyecto");
            P_Tuberia_datatable.Columns.Add("T_lote_alambre");
            P_Tuberia_datatable.Columns.Add("T_lote_fundente");
            P_Tuberia_datatable.Columns.Add("T_foliooperador");
            P_Tuberia_datatable.Columns.Add("T_fecha");
            P_Tuberia_datatable.Columns.Add("T_hora");
            P_Tuberia_datatable.Columns.Add("T_hora_db");
            P_Tuberia_datatable.Columns.Add("archivo_excel");
            P_Tuberia_datatable.Columns.Add("Observaciones");

            P_tuberia_datatable_ayer.Columns.Add("T_id_tubo");
            P_tuberia_datatable_ayer.Columns.Add("T_no_tubo");
            P_tuberia_datatable_ayer.Columns.Add("T_no_placa");
            P_tuberia_datatable_ayer.Columns.Add("T_ID_proyecto");
            P_tuberia_datatable_ayer.Columns.Add("T_lote_alambre");
            P_tuberia_datatable_ayer.Columns.Add("T_lote_fundente");
            P_tuberia_datatable_ayer.Columns.Add("T_foliooperador");
            P_tuberia_datatable_ayer.Columns.Add("T_fecha");
            P_tuberia_datatable_ayer.Columns.Add("T_hora");
            P_tuberia_datatable_ayer.Columns.Add("T_hora_db");
            P_tuberia_datatable_ayer.Columns.Add("archivo_excel");
            P_tuberia_datatable_ayer.Columns.Add("Observaciones");

        }
        void iniciar_tabla_excel()
        {
            P_Tabla_excel.Columns.Add("DIA");
            P_Tabla_excel.Columns.Add("HORA");
            P_Tabla_excel.Columns.Add("SEC");
            P_Tabla_excel.Columns.Add("V_AC1");
            P_Tabla_excel.Columns.Add("I_AC1");
            P_Tabla_excel.Columns.Add("V_AC2");
            P_Tabla_excel.Columns.Add("I_AC2");
            P_Tabla_excel.Columns.Add("V_DC");
            P_Tabla_excel.Columns.Add("I_DC");
            P_Tabla_excel.Columns.Add("P_AC1");
            P_Tabla_excel.Columns.Add("P_AC2");
            P_Tabla_excel.Columns.Add("P_DC");
        }

        void Iniciar_tabla_proyecto()
        {
            P_proyecto_datatable.Columns.Add("ID");
            P_proyecto_datatable.Columns.Add("Nombre");
            P_proyecto_datatable.Columns.Add("Diametro");
            P_proyecto_datatable.Columns.Add("Espesor");
            P_proyecto_datatable.Columns.Add("Alambre");
            P_proyecto_datatable.Columns.Add("Fundente");
            P_proyecto_datatable.Columns.Add("OrdenTrabajo");
            P_proyecto_datatable.Columns.Add("Especificacion");

        }

        void Iniciar_tabla_operador()
        {
            P_operador_datatable.Columns.Add("Folio");
            P_operador_datatable.Columns.Add("Nombre");
            P_operador_datatable.Columns.Add("Clave_soldador");
            P_operador_datatable.Columns.Add("Puesto");
        }
       
        void Desabilitar_botones_ce(bool opc)
        {
            if (opc==true)
            {
                gpbModo.Enabled = false;
                gpbModoManual.Enabled = false;
            }
            else
            {
                gpbModo.Enabled = true;
                gpbModoManual.Enabled = true;
            }
            
        }

        DataTable Reacomodar_12(DataTable tabla_reacomodar)
        {
            
            DataView temporal_dataview_12 = tabla_reacomodar.DefaultView;
            temporal_dataview_12.RowFilter = "T_hora LIKE '12:*'";
            int num_filas = tabla_reacomodar.Rows.Count;
            int num_12 = temporal_dataview_12.Count;
            if (num_12 > 0)
            {
                for (int j = 1; j <= num_12; j++)
                {
                    object[] row_12 = tabla_reacomodar.Rows[num_filas - 1].ItemArray;
                    for (int i = num_filas - 2; i > 0; i--)
                    {
                        object[] row_inter1 = tabla_reacomodar.Rows[i].ItemArray;
                        object[] row_inter2 = tabla_reacomodar.Rows[i - 1].ItemArray;
                        tabla_reacomodar.Rows[i + 1].ItemArray = row_inter1;
                        tabla_reacomodar.Rows[i].ItemArray = row_inter2;
                    }
                    tabla_reacomodar.Rows[0].ItemArray = row_12;
                }
                
            }
            temporal_dataview_12.RowFilter = "T_hora LIKE '%:%'";
            return tabla_reacomodar;
        }
        //funciones para envio o peticion de datos por medio de las apis
        public string GetApiData(string url)
        {
            //obtiene los registros de la base de datos segun sea la dirrecion o a la API que hace referencia
            string responseString = "";
            try
            {
                var response = cliente.GetStringAsync(url);
                responseString = response.Result;

            }
            catch (Exception err)
            {
                MessageBox.Show("getapi_error: " + err.Message);

            }
            return responseString;
        }

        public void InsertApiData(string url, string archivos_excel)
        {
            string id_tubo = txbManualHoraInicial.Text;
            string[] charsToRemove = new string[] { " ", ":", "a", "m", "p" };
            foreach (var c in charsToRemove)
            {
                id_tubo = id_tubo.Replace(c, string.Empty);
            }
            try
            {
                var values = new Dictionary<string, string>
                {
                    { "T_id_tubo", id_tubo },
                    { "T_no_tubo", "" },
                    { "T_no_placa", "" },
                    { "T_nom_proyecto", "sn proyecto" },
                    { "T_lote_alambre", "" },
                    { "T_lote_fundente", "" },
                    { "T_maquina", cmbManualMaquina.Text },
                    { "T_fecha", txbManualFecha.Text },
                    { "T_hora", txbManualHoraFinal.Text },
                    {"Archivos_excel", archivos_excel},


                };

                var content = new FormUrlEncodedContent(values);

                var response = cliente.PostAsync(url, content);


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }

        public void UpdateApiData(string url, string archivos_excel)
        {

            try
            {

                Dictionary<string, string> diccionario = new Dictionary<string, string>
                {
                    {"A_ID_tubo", P_ID_tubo },
                    {"Archivos_excel", archivos_excel},
                };
                //var values = diccionario;

                var content = new FormUrlEncodedContent(diccionario);

                var response = cliente.PostAsync(url, content);
                
                //lblTemporal2.Text = response.Result.ToString();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }
       
        //funciones para limpiar y llenar las tablas y datagrid del proyecto
        public void Rellenar_tabla_datos(string soldadura)
        {
            //llena la tabla de datos para tuberia de los registros solicitados por fecha dada
            
            P_Tuberia_datatable.Rows.Clear();
            DataTable tuberia_filtro_am = new DataTable();
            DataTable tuberia_filtro_pm = new DataTable();
            DataTable tabla_temporal = new DataTable();
            Thread.Sleep(500);
            
            try
            {

                var output = GetApiData(P_url_get);

                if (soldadura == "INTERNA" || soldadura =="in")
                {
                    List<Tuberia_interna_tabla> temporal_results = JsonConvert.DeserializeObject<List<Tuberia_interna_tabla>>(output);
                    foreach (var r in temporal_results)
                    {
                        
                        P_Tuberia_datatable.Rows.Add(r.Ta_id_tubo, r.Ta_no_tubo, r.Ta_no_placa, r.Ta_ID_proyecto, r.Ta_lote_alambre,
                            r.Ta_lote_fundente,r.Ta_foliooperador, r.Ta_fecha, r.Ta_hora, r.Ta_hora_db, r.Ta_Archivos_excel,r.Ta_Observaciones);

                    }
                }
                else if (soldadura == "EXTERNA" || soldadura== "ex")
                {
                    List<Tuberia_externa_tabla> temporal_results = JsonConvert.DeserializeObject<List<Tuberia_externa_tabla>>(output);
                    foreach (var r in temporal_results)
                    {
                        
                        P_Tuberia_datatable.Rows.Add(r.Ta_id_tubo, r.Ta_no_tubo, r.Ta_no_placa, r.Ta_ID_proyecto, r.Ta_lote_alambre,
                            r.Ta_lote_fundente,r.Ta_foliooperador, r.Ta_fecha, r.Ta_hora, r.Ta_hora_db, r.Ta_Archivos_excel,r.Ta_Observaciones);

                    }
                }
                //Checar si hay datos en la tabla
                if (P_Tuberia_datatable.Rows.Count>0)
                {
                    bool hay_archivos_am = false;
                    P_tuberia_dataview = P_Tuberia_datatable.DefaultView;
                    P_tuberia_dataview.Sort = "T_hora_db ASC";
                    P_Tuberia_datatable = P_tuberia_dataview.ToTable();
                    tuberia_filtro_am = P_Tuberia_datatable;
                    tuberia_filtro_pm = P_Tuberia_datatable;

                    P_tuberia_dataview = tuberia_filtro_am.DefaultView;
                    P_tuberia_dataview.RowFilter = "T_hora LIKE '%am%'";
                    //si hay un 12 am, mover al principio
                    if (P_tuberia_dataview.Count > 0)
                    {
                        tuberia_filtro_am = Reacomodar_12(P_tuberia_dataview.ToTable());
                        tabla_temporal = tuberia_filtro_am;
                        hay_archivos_am = true;
                    }


                    P_tuberia_dataview = tuberia_filtro_pm.DefaultView;
                    P_tuberia_dataview.RowFilter = "T_hora LIKE '%pm%'";
                    //si hay un 12 pm, mover al principio
                    if (P_tuberia_dataview.Count > 0)
                    {
                        tuberia_filtro_pm = Reacomodar_12(P_tuberia_dataview.ToTable());
                        if (hay_archivos_am == true)
                        {
                            foreach (DataRow fila_temp in tuberia_filtro_pm.Rows)
                            {
                                tabla_temporal.Rows.Add(fila_temp.ItemArray);
                            }
                        }
                        else
                        {
                            tabla_temporal = tuberia_filtro_pm;
                        }
                    }
                }
                else
                {
                    tabla_temporal = P_Tuberia_datatable;
                }
                
 
                P_Tuberia_datatable = tabla_temporal;
                
            }
            catch (Exception err)
            {
                MessageBox.Show("Rellenar tabla:"+err.Message);
                
            }

        }

        void Rellenar_tabla_proyectos(string nom_proyecto)
        {
            string url_proyecto = "http://10.10.20.15/api/rq_tProyectos.php?nombre=" + nom_proyecto;
            var resultado_proyecto=GetApiData(url_proyecto);
            List<Proyecto_tabla> temporal_results = JsonConvert.DeserializeObject<List<Proyecto_tabla>>(resultado_proyecto);
            foreach (var r in temporal_results)
            {
                P_proyecto_datatable.Rows.Add(r.pro_id, r.pro_nombre,r.pro_diametro,r.pro_espesor,r.pro_alambre,
                                             r.pro_fundente,r.pro_ordentrabajo,r.pro_especificacion);

            }
        }

        void Rellenar_tabla_operador(string folio_operador)
        {
            string url_operador = "http://10.10.20.15/api/rq_tOperadores.php?id=" + folio_operador;
            var resultado_operador = GetApiData(url_operador);
            
            List<Operadores_tabla> temporal_resultado = JsonConvert.DeserializeObject<List<Operadores_tabla>>(resultado_operador);
            foreach (var r in temporal_resultado)
            {
                P_operador_datatable.Rows.Add(r.op_folio, r.op_nombre, r.op_clave_soldador, r.op_puesto);

            }
        }
        
        
       

        
        
        //subrutina principal de integracion
        public void Integracion_datos_tuberia()
        {
            //Rutina para buscar archivos excel y registros tuberia por cada maquina

            //maquinas de soldadura interna
            //P_url_update = "http://10.10.20.15/api/rq_tTuberia_soldadura_interna.php?opc=1";
            ptbIndicadorA.Image = iglImagenes.Images[16];
            Busqueda_archivos_maquina("MONITOREO_INTERNA1", "INTERNA1", "in");
            Busqueda_archivos_maquina("MONITOREO_INTERNA2", "INTERNA2", "in");
            Busqueda_archivos_maquina("MONITOREO_INTERNA3", "INTERNA3", "in");

            //maquinas de soldadura externa
            //P_url_update = "http://10.10.20.15/api/rq_tTuberia_soldadura_externa.php?opc=1";
            
            Busqueda_archivos_maquina("MONITOREO_EXTERNA1", "EXTERNA1", "ex");
            Busqueda_archivos_maquina("MONITOREO_EXTERNA2", "EXTERNA2", "ex");
            Busqueda_archivos_maquina("MONITOREO_EXTERNA3", "EXTERNA3", "ex");
            ptbIndicadorA.Image = iglImagenes.Images[17];
        }

        public void Busqueda_archivos_maquina(string carpeta_maquina, string nom_maquina, string m_exin)
        {
            //busqueda de archivos y registros por maquina y ruta de acceso a archivos
            //fecha que se haran los reportes.
            string fecha_nom_archivo;
            DateTime fecha_formato_temporal = DateTime.Now;
            if (P_manual==true)
            {
                
                fecha_formato_temporal = Convert.ToDateTime(txbManualFecha.Text);
                fecha_nom_archivo = fecha_formato_temporal.ToString("yyyyMMdd");
                P_fecha_busqueda = txbManualFecha.Text;
            }
            else
            {
                fecha_nom_archivo = P_hora_now.ToString("yyyyMMdd");
            }
            
            tssLCarpeta.Text = carpeta_maquina;
            
            lblTemporal2.Text = nom_maquina;
            Limpiar_tabla_fecha(m_exin,nom_maquina);
            path_temporal = pathP + carpeta_maquina+"\\";
            //lblTemporal2.Text = path_temporal;
            //dgvDatosTabla.Rows.Clear();
            dgvDatosTabla.DataSource = P_Tuberia_datatable;
            
            if (dgvDatosTabla.Rows.Count != 0)
            {
                tssLNumeroArchivos.Text = dgvDatosTabla.Rows.Count.ToString();
                Llenar_tabla_datos_ayer(m_exin,nom_maquina);
                ltbTemporal2.Items.Clear();
                if (P_no_hay_archivos_ayer==false)
                {
                    
                    string fecha_ayer_string;
                    if (P_manual==true)
                    {
                        fecha_formato_temporal = fecha_formato_temporal.AddDays(-1);
                        fecha_ayer_string = fecha_formato_temporal.ToString("yyyyMMdd");
                    }
                    else
                    {
                        fecha_ayer_string = P_fecha_ayer.ToString("yyyyMMdd");
                    }
                    Buscar_archivos_excel_ayer(path_temporal, fecha_ayer_string);
                }
                else
                {
                    //Se deja el else por si en un futurio cambio se necesita hacer algo si hay archivos de ayer aqui
                }
                
                //limpiar la lista de no,bres de archivos excel
                ltbArchivosExcel.Items.Clear();
                //buscar archivos excel en la fecha dada
                Buscar_archivos_excel(path_temporal, fecha_nom_archivo);
                Leer_archivos_excel(carpeta_maquina, m_exin,nom_maquina);
            }
            else
            {
                tssLNumeroArchivos.Text = "0 archivos";
                tssLEstado.Text = "No hay archivos";
            }
            

        }

        void Limpiar_tabla_fecha(string m_exin, string maquina_fecha)
        {
            //limpia tabla de datos y la vuelve a llenar con los registros solicitados por maquina,
            //son mostrados en un datagrid

            Iniciar_datagrid();
            P_Tuberia_datatable.DefaultView.RowFilter = "T_id_tubo NOT IN (.)";
            P_Tuberia_datatable.Rows.Clear();
            dgvDatosTabla.DataSource = P_Tuberia_datatable;
            //fecha en formato de busqueda en tabla de soldaduras
            DateTime fecha_formato_temporal = Convert.ToDateTime(P_fecha_busqueda);
            string fecha_temporal = fecha_formato_temporal.ToString("dd/MM/yyyy");
            //designar a que tabla de soldadura sera guardado el dato del archivo excel
            if (m_exin == "in" || m_exin == "INTERNA")
            {
                if (maquina_fecha == "INTERNA1")
                {
                    P_url_get = "http://10.10.20.15/api/internas/rq_tTuberiaInterna_1.php?fecha=" + fecha_temporal;
                    
                }
                else if (maquina_fecha=="INTERNA2")
                {
                    P_url_get = "http://10.10.20.15/api/internas/rq_tTuberiaInterna_2.php?fecha=" + fecha_temporal;
                }
                else
                {
                    P_url_get = "http://10.10.20.15/api/internas/rq_tTuberiaInterna_3.php?fecha=" + fecha_temporal;
                }

            }
            else
            {
                if (maquina_fecha == "EXTERNA1")
                {
                    P_url_get = "http://10.10.20.15/api/externas/rq_tTuberiaExterna_1.php?fecha=" + fecha_temporal;
                }
                else if (maquina_fecha == "EXTERNA2")
                {
                    P_url_get = "http://10.10.20.15/api/externas/rq_tTuberiaExterna_2.php?fecha=" + fecha_temporal;
                }
                else
                {
                    P_url_get = "http://10.10.20.15/api/externas/rq_tTuberiaExterna_3.php?fecha=" + fecha_temporal;
                }
                
            }
            //rellenar data grid con datos
            Rellenar_tabla_datos(m_exin);
            P_maquina_reporte = maquina_fecha;
        }

        void Llenar_tabla_datos_ayer(string soldadura, string maquina_poleo)
        {
            //limpiar tabla de datos de registros de dia anterior en el que se esta trabajando
            P_tuberia_datatable_ayer.Clear();

            //fecha en formato de busqueda en tabla de soldaduras
            string fecha_temporal;
            DateTime fecha_temporal_ayer = Convert.ToDateTime(P_fecha_busqueda);
            if (P_manual == true)
            {
                fecha_temporal_ayer = fecha_temporal_ayer.AddDays(-1);
                fecha_temporal = fecha_temporal_ayer.ToString("dd/MM/yyyy");
            }
            else
            {
                fecha_temporal = P_fecha_ayer.ToString("dd/MM/yyyy");
            }

            string url_get;
            //url para obtener registros de la tuberia del dia anterior(ayer).
            if (soldadura == "in")
            {
                if (maquina_poleo == "INTERNA1")
                {
                    url_get = "http://10.10.20.15/api/internas/rq_tTuberiaInterna_1.php?fecha=" + fecha_temporal;

                }
                else if (maquina_poleo == "INTERNA2")
                {
                    url_get = "http://10.10.20.15/api/internas/rq_tTuberiaInterna_2.php?fecha=" + fecha_temporal;
                }
                else
                {
                    url_get = "http://10.10.20.15/api/internas/rq_tTuberiaInterna_3.php?fecha=" + fecha_temporal;
                }

            }
            else
            {
                if (maquina_poleo == "EXTERNA1")
                {
                    url_get = "http://10.10.20.15/api/externas/rq_tTuberiaExterna_1.php?fecha=" + fecha_temporal;
                }
                else if (maquina_poleo == "EXTERNA2")
                {
                    url_get = "http://10.10.20.15/api/externas/rq_tTuberiaExterna_2.php?fecha=" + fecha_temporal;
                }
                else
                {
                    url_get = "http://10.10.20.15/api/externas/rq_tTuberiaExterna_3.php?fecha=" + fecha_temporal;
                }

            }
            
            try
            {

                string output = GetApiData(url_get);

                if (output != "[] ")
                {
                    if (soldadura == "in")
                    {
                        P_no_hay_archivos_ayer = false;
                        List<Tuberia_interna_tabla> temporal_results = JsonConvert.DeserializeObject<List<Tuberia_interna_tabla>>(output);
                        foreach (var r in temporal_results)
                        {
                            P_tuberia_datatable_ayer.Rows.Add(r.Ta_id_tubo, r.Ta_no_tubo, r.Ta_no_placa, r.Ta_ID_proyecto, r.Ta_lote_alambre,
                                r.Ta_lote_fundente, r.Ta_foliooperador, r.Ta_fecha, r.Ta_hora,r.Ta_hora_db, r.Ta_Archivos_excel,r.Ta_Observaciones);

                        }
                    }
                    else if (soldadura == "ex")
                    {
                        List<Tuberia_externa_tabla> temporal_results = JsonConvert.DeserializeObject<List<Tuberia_externa_tabla>>(output);
                        foreach (var r in temporal_results)
                        {
                            P_tuberia_datatable_ayer.Rows.Add(r.Ta_id_tubo, r.Ta_no_tubo, r.Ta_no_placa, r.Ta_ID_proyecto, r.Ta_lote_alambre,
                                r.Ta_lote_fundente, r.Ta_foliooperador, r.Ta_fecha, r.Ta_hora,r.Ta_hora_db, r.Ta_Archivos_excel,r.Ta_Observaciones);

                        }
                    }
                }
                else
                {
                    P_no_hay_archivos_ayer = true;
                }

                dgvTablaExcel.DataSource = P_tuberia_datatable_ayer;
            }
            catch (Exception err)
            {
                MessageBox.Show("llenar tabla datos ayer: " + err.Message);

            }


        }

        void Buscar_archivos_excel_ayer(string path_archivos, string fecha_archivos)
        {
            //ltbArchivosExcel.Items.Clear();
            try
            {

                DirectoryInfo di = new DirectoryInfo(path_archivos);
                string fechabuscada;
                if (ckbExcel.Checked)
                {
                    fechabuscada = "*" + fecha_archivos + "*?.xlsx";
                }
                else
                {
                    fechabuscada = "*" + fecha_archivos + "*?.txt";
                }

                foreach (var fi in di.GetFiles(fechabuscada))
                {

                    if (fi.Length > 6000)
                    {
                        ltbTemporal2.Items.Add(fi.Name);
                    }

                }
            }
            catch (Exception e)
            {
                Iniciar_datagrid();
                //MessageBox.Show("error:" + e.ToString());
            }

        }

        void Buscar_archivos_excel(string path_archivos, string fecha_archivos)
        {
            //ltbArchivosExcel.Items.Clear();
            try
            {

                DirectoryInfo di = new DirectoryInfo(path_archivos);
                string fechabuscada;
                if (ckbExcel.Checked)
                {
                    fechabuscada = "*" + fecha_archivos + "*?.xlsx";
                }
                else
                {
                    fechabuscada = "*" + fecha_archivos + "*?.txt";
                }
                
                foreach (var fi in di.GetFiles(fechabuscada))
                {

                    if (fi.Length > 95000)
                    {
                        ltbArchivosExcel.Items.Add(fi.Name);
                        ltbTemporal.Items.Add(fi.LastWriteTime.ToString());
                        //ltbTemporal2.Items.Add(fi.Length.ToString());
                    }

                }
            }
            catch (Exception e)
            {
                Iniciar_datagrid();
                MessageBox.Show("error excel:" + e.ToString());
            }

        }

        void Convertir_archivos_txt2csv()
        {

        }
        void Leer_archivos_excel(string carpeta, string soldadura, string maquina)
        {
            string temporal_string, hora_inicial, hora_final, tubo_hora;
            if (soldadura == "in" || soldadura == "INTERNA")
            {
                if (maquina == "INTERNA1")
                {
                    P_url_update = "http://10.10.20.15/api/internas/rq_tTuberiaInterna_1.php";
                }
                else if (maquina == "INTERNA2")
                {
                    P_url_update = "http://10.10.20.15/api/internas/rq_tTuberiaInterna_2.php";
                }
                else
                {
                    P_url_update = "http://10.10.20.15/api/internas/rq_tTuberiaInterna_3.php";
                }

            }
            else
            {
                if (maquina == "EXTERNA1")
                {
                    P_url_update = "http://10.10.20.15/api/externas/rq_tTuberiaExterna_1.php";
                }
                else if (maquina == "EXTERNA2")
                {
                    P_url_update = "http://10.10.20.15/api/externas/rq_tTuberiaExterna_2.php";
                }
                else
                {
                    P_url_update = "http://10.10.20.15/api/externas/rq_tTuberiaExterna_3.php";
                }

            }

            for (int i = 0; i < dgvDatosTabla.Rows.Count; i++)
            {
                temporal_string = dgvDatosTabla.Rows[i].Cells[10].Value.ToString();
                if (temporal_string == "")
                {
                    //buscar archivos excel dentro del rango de hora
                    if (i == 0)
                    {
                        string hora_filtro;

                        if (P_no_hay_archivos_ayer == false)
                        {

                            hora_inicial = P_fecha_ayer.ToString("yyyy/MM/dd") + " " + dgvTablaExcel.Rows[dgvTablaExcel.Rows.Count - 1].Cells[8].Value.ToString();
                        }
                        else
                        {
                            hora_inicial = P_fecha_busqueda + " 12:01:00 am";

                        }
                        hora_final = P_fecha_busqueda + " " + dgvDatosTabla.Rows[i].Cells[8].Value.ToString();
                        hora_filtro = dgvDatosTabla.Rows[i].Cells[8].Value.ToString();
                        tubo_hora = "T_hora=" + "'" + hora_filtro + "'";
                        //lblTemporal.Text = tubo_hora;
                        P_tuberia_dataview = P_Tuberia_datatable.DefaultView;
                        P_tuberia_dataview.RowFilter = tubo_hora;
                        dgvDatosTabla.DataSource = P_tuberia_dataview.ToTable();
                        P_ID_tubo = dgvDatosTabla.Rows[0].Cells[0].Value.ToString();
                        //lblTemporal.Text = P_ID_tubo;
                      
                        P_auto_un_registro = true;
                        guardar_archivos_excel_tubo(hora_inicial, hora_final, carpeta, soldadura, maquina);
                    }
                    else
                    {
                        hora_inicial = P_fecha_busqueda + " " + dgvDatosTabla.Rows[i - 1].Cells[8].Value.ToString();
                        hora_final = P_fecha_busqueda + " " + dgvDatosTabla.Rows[i].Cells[8].Value.ToString();
                        tubo_hora = "T_hora=" + "'" + dgvDatosTabla.Rows[i].Cells[8].Value.ToString() + "'";
                        //lblTemporal.Text = tubo_hora;
                        P_tuberia_dataview = P_Tuberia_datatable.DefaultView;
                        P_tuberia_dataview.RowFilter = tubo_hora;
                        dgvDatosTabla.DataSource = P_tuberia_dataview.ToTable();
                        P_ID_tubo = dgvDatosTabla.Rows[0].Cells[0].Value.ToString();
                        //lblTemporal.Text = P_ID_tubo;
                        
                        guardar_archivos_excel_tubo(hora_inicial, hora_final, carpeta, soldadura, maquina);
                    }

                    
                    Crear_excel_rutina();
                    Limpiar_tabla_fecha(soldadura, maquina);
                    dgvDatosTabla.DataSource = P_Tuberia_datatable;
                }
            }
        }

        //funciones para guaradar nombres de los archivos excel
        void Actualizar_Reporte_excel(string nombre_reporte, string maquina_reporte)
        {
            string url_reporte, url;
            string id_tubo = dgvDatosTabla.Rows[0].Cells[0].Value.ToString();

            Dictionary<string, string> diccionario = new Dictionary<string, string>
                {
                    {"A_id_tubo", id_tubo },
                    {"A_nombre_reporte", nombre_reporte+".xlsx"},
                };

            var content = new FormUrlEncodedContent(diccionario);

            switch (maquina_reporte)
            {
                case "INTERNA1":
                    url_reporte = "http://10.10.20.15/api/internas/rq_tTuberiaInterna_1.php";
                    cliente.PostAsync(url_reporte, content);
                    break;
                case "INTERNA2":
                    url_reporte = "http://10.10.20.15/api/internas/rq_tTuberiaInterna_2.php";
                    cliente.PostAsync(url_reporte, content);
                    break;
                case "INTERNA3":
                    url_reporte = "http://10.10.20.15/api/internas/rq_tTuberiaInterna_3.php";
                    cliente.PostAsync(url_reporte, content);
                    break;
                case "EXTERNA1":
                    url_reporte = "http://10.10.20.15/api/externas/rq_tTuberiaExterna_1.php";
                    cliente.PostAsync(url_reporte, content);
                    break;
                case "EXTERNA2":
                    url_reporte = "http://10.10.20.15/api/externas/rq_tTuberiaExterna_2.php";
                    cliente.PostAsync(url_reporte, content);
                    break;
                case "EXTERNA3":
                    url_reporte = "http://10.10.20.15/api/externas/rq_tTuberiaExterna_3.php";
                    cliente.PostAsync(url_reporte, content);
                    break;
                default:

                    break;
            }

            
            //var values = diccionario;

            

            
        }

        public void guardar_archivos_excel_tubo(string hi, string hf, string cm, string exin, string mq)
        {
            DateTime horainicial_datetime = Convert.ToDateTime(hi);
            DateTime horafinal_datetime = Convert.ToDateTime(hf);
            //string hora_filtro = horafinal_datetime.ToString("hh:mm:ss tt");
            string nombre_archivo, s_temporal_string = "";
            int j = 0;
            if (P_auto_un_registro == true)
            {
                for (int i = 0; i < ltbTemporal2.Items.Count; i++)
                {
                    nombre_archivo = ltbTemporal2.Items[i].ToString();
                    var archivo_encontrado = new FileInfo(pathP + cm + "/" + nombre_archivo);
                    DateTime hora_archivo_encontrado = archivo_encontrado.LastWriteTime;

                    //DateTime temporal_time = File.GetCreationTime(pathP + cm + "/" + nombre_archivo);
                    if (horainicial_datetime <= hora_archivo_encontrado && hora_archivo_encontrado <= horafinal_datetime)
                    {

                        s_temporal_string = s_temporal_string + nombre_archivo + ",";
                        j += 1;

                    }
                }
                P_auto_un_registro = false;
            }

            for (int i = 0; i < ltbArchivosExcel.Items.Count; i++)
            {
                nombre_archivo = ltbArchivosExcel.Items[i].ToString();
                var archivo_encontrado = new FileInfo(pathP + cm + "/" + nombre_archivo);
                DateTime hora_archivo_encontrado = archivo_encontrado.LastWriteTime;

                //DateTime temporal_time = File.GetCreationTime(pathP + cm + "/" + nombre_archivo);
                if (horainicial_datetime <= hora_archivo_encontrado && hora_archivo_encontrado <= horafinal_datetime)
                {

                    s_temporal_string = s_temporal_string + nombre_archivo + ",";
                    j += 1;

                }
            }
            s_temporal_string = j.ToString() + "," + s_temporal_string;
            lblTemporal.Text = s_temporal_string;
            if (P_manual == true)
            {
                if (P_registro_nuevo_archivo == true)
                {
                    InsertApiData(P_url_insert, s_temporal_string);
                }
                else
                {
                    UpdateApiData(P_url_update, s_temporal_string);
                }

            }
            else
            {
                UpdateApiData(P_url_update, s_temporal_string);
            }
            string tubo_ID = "T_id_tubo=" + "'" + dgvDatosTabla.Rows[0].Cells[0].Value.ToString() + "'";
            Limpiar_tabla_fecha(exin, mq);
            P_tuberia_dataview = P_Tuberia_datatable.DefaultView;
            P_tuberia_dataview.RowFilter = tubo_ID;
            dgvDatosTabla.DataSource = P_tuberia_dataview.ToTable();


            //return horafinal_datetime;
        }

        //subrutinas de elementos del formulario
        private void cmbManualMaquina_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvDatosTabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rdbHorainicial.Checked)
            {
                txbManualHoraInicial.Text = dgvDatosTabla.CurrentCell.Value.ToString();
            }
            else
            {
                txbManualHoraFinal.Text = dgvDatosTabla.CurrentCell.Value.ToString();
            }
        }

        private void btnCrearExcel_Click(object sender, EventArgs e)
        {
            Crear_excel_rutina();
                   
        }

        private void ptbIndicador2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pruebas_archivos frm = new pruebas_archivos();
            frm.ShowDialog();
        }

        private void btnReportesDia_Click(object sender, EventArgs e)
        {
            String carpeta_maquina="", ex_in=cmbManualSoldadura.Text;
            switch (cmbManualMaquina.Text)
            {
                case "INTERNA1":
                    carpeta_maquina = "MONITOREO_INTERNA1";
                    break;
                case "INTERNA2":
                    carpeta_maquina = "MONITOREO_INTERNA2";
                    break;
                case "INTERNA3":
                    carpeta_maquina = "MONITOREO_INTERNA3";
                    break;
                case "EXTERNA1":
                    carpeta_maquina = "MONITOREO_EXTERNA1";
                    break;
                case "EXTERNA2":
                    carpeta_maquina = "MONITOREO_EXTERNA2";
                    break;
                case "EXTERNA3":
                    carpeta_maquina = "MONITOREO_EXTERNA3";
                    break;
                default:
                    break;
            }

            Busqueda_archivos_maquina(carpeta_maquina, cmbManualMaquina.Text, ex_in);
        }

        private void btnPararAuto_Click(object sender, EventArgs e)
        {
            btnIniciarAuto.Enabled = true;
            btnAjustes.Enabled = true;
            tmrMonitoreo.Enabled = false;
            btnPararAuto.Enabled = false;
            btnModoManual.Enabled = true;
            tssLEstado.Text = "en espera...";
        }

        private void tmrRetraso_Tick(object sender, EventArgs e)
        {
         
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            string valor = "00";
            string minutos = inputboxvb.InputBox("Tiempo de poleo", "Ingresa los minutos", ref valor);
            P_numero_minutos = Int32.Parse(minutos);
            tssLMinutosMon.Text = minutos + " min.";
        }

        private void txbManualHoraInicial_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Gnumero_minutos = P_numero_minutos;
        }

        private void tmrMonitoreo_Tick(object sender, EventArgs e)
        {
            //rutina periodica para empezar poleo de nuevos archivos excel y registros de tuberia
            tmrMonitoreo.Enabled = false;
            P_hora_now = DateTime.Now;
            tssLEstado.Text = P_hora_now.ToLongTimeString();
            P_fecha_busqueda = P_hora_now.ToString("yyyy/MM/dd");
            P_fecha_ayer = DateTime.Now.AddDays(-1);
            if (P_hora_now > P_hora_anterior)
            {

                P_hora_anterior = P_hora_now;
                P_contador_tmr += 1;
                if (P_contador_tmr == (P_numero_minutos*60))
                {
                    //codigo para revisar si hay nuevos datos de tubos
                    P_contador_tmr = 0;
                    Integracion_datos_tuberia();
                }
            }

            tmrMonitoreo.Enabled = true;
        }

        private void btnIniciarAuto_Click(object sender, EventArgs e)
        {
            //DateTime fecha_hoy = DateTime.Now;
            if (tmrMonitoreo.Enabled == false)
            {
                tmrMonitoreo.Enabled = true;
                tssLMinutosMon.Text = P_numero_minutos + " minutos";
                P_hora_now = DateTime.Now;
                P_fecha_busqueda = P_hora_now.ToString("yyyy/MM/dd");
                tssLEstado.Text = "Modo Automatico";
                P_temporal_datetime = P_hora_registro_anterior;
                P_manual = false;
                btnIniciarAuto.Enabled = false;
                btnPararAuto.Enabled = true;
                btnAjustes.Enabled = false;
                btnModoManual.Enabled = false;
            }
            
        }
        
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ptbIndicador1.Image = iglImagenes.Images[17];
            ptbIndicador2.Image = iglImagenes.Images[5];
            btnPararAuto.Enabled = false;
            Iniciar_tabla_tuberia();
            Iniciar_tabla_operador();
            Iniciar_tabla_proyecto();
            Iniciar_formulario_principal();
            P_numero_minutos = Properties.Settings.Default.Gnumero_minutos;
           
            /*txbManualHoraFinal.Enabled = false;
            txbManualHoraInicial.Enabled = false;
            btnGuardarExcel.Enabled = false; */ 
           
        }

        private void cmbManualSoldadura_SelectedIndexChanged(object sender, EventArgs e)
        {
            Iniciar_datagrid();
            ltbArchivosExcel.Items.Clear();
            ltbTemporal.Items.Clear();
            ltbTemporal2.Items.Clear();
            txbManualFecha.Text = "";
            txbManualHoraFinal.Text = "";
            txbManualHoraInicial.Text = "";
            cmbManualMaquina.Items.Clear();
            

            for (int i = 1; i < 4; i++)
            {
                cmbManualMaquina.Items.Add(cmbManualSoldadura.Text + i.ToString());
            }
        }

        private void btnBusquedaFecha_Click(object sender, EventArgs e)
        {
            //iniciar almacenando variables para busqueda de archivos
            P_fecha_busqueda = txbManualFecha.Text;

            Limpiar_tabla_fecha(cmbManualSoldadura.Text, cmbManualMaquina.Text);
                
            dgvDatosTabla.DataSource = P_Tuberia_datatable;
            lblTemporal.Text = dgvDatosTabla.Rows.Count.ToString();
            lblTemporal.Text = P_Tuberia_datatable.Rows.Count.ToString();
            string fecha_nom_archivo = P_fecha_busqueda.Replace("/", "");
            string manual_carpeta = "MONITOREO_" + cmbManualMaquina.Text;
            
            path_temporal = pathP + "MONITOREO_" + cmbManualMaquina.Text + "\\";
      
            if (dgvDatosTabla.Rows.Count == 0)
            {
                P_registro_nuevo_archivo = true;
            }
            else
            {
                P_registro_nuevo_archivo = false;
            }
            //limpiar la lista de no,bres de archivos excel
            ltbArchivosExcel.Items.Clear();
            //buscar archivos excel en la fecha dada
            Buscar_archivos_excel(pathP + manual_carpeta, fecha_nom_archivo);
            
            //limpiar la lista temporal de datos
            lblTemporal.Text = "";
            tssLEstado.Text = "esperando hora";
            txbManualHoraInicial.Enabled = true;
            txbManualHoraFinal.Enabled = true;
            btnGuardarExcel.Enabled = true;
            btnCrearExcel.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarExcel_Click(object sender, EventArgs e)
        {
            string hora_inicial, hora_final;
            DataView tablaview_temporal;
            //asignar a variables la hora inicial y final de busqueda de archivos excel
            string manual_carpeta = "MONITOREO_" + cmbManualMaquina.Text;
            if ((txbManualHoraInicial.Text != "") && (txbManualHoraFinal.Text != ""))
            {
                hora_inicial = P_fecha_busqueda + " " + txbManualHoraInicial.Text;
                hora_final = P_fecha_busqueda + " " + txbManualHoraFinal.Text;
                string tubo_hora = "T_hora=" + "'" + txbManualHoraFinal.Text + "'";
                lblTemporal.Text = tubo_hora;
                tablaview_temporal = P_Tuberia_datatable.DefaultView;
                tablaview_temporal.RowFilter = tubo_hora;
                //P_Tuberia_datatable.DefaultView.RowFilter = tubo_hora;
                dgvDatosTabla.DataSource = tablaview_temporal.ToTable();
                P_ID_tubo = dgvDatosTabla.Rows[0].Cells[0].Value.ToString();
                lblTemporal.Text = P_ID_tubo;
                if (cmbManualSoldadura.Text == "INTERNA")
                {
                    if (cmbManualMaquina.Text == "INTERNA1")
                    {
                        P_url_update = "http://10.10.20.15/api/internas/rq_tTuberiaInterna_1.php";
                    }
                    else if (cmbManualMaquina.Text == "INTERNA2")
                    {
                        P_url_update = "http://10.10.20.15/api/internas/rq_tTuberiaInterna_2.php";
                    }
                    else
                    {
                        P_url_update = "http://10.10.20.15/api/internas/rq_tTuberiaInterna_3.php";
                    }
                    
                }
                else
                {
                    if (cmbManualMaquina.Text == "EXTERNA1")
                    {
                        P_url_update = "http://10.10.20.15/api/externas/rq_tTuberiaExterna_1.php";
                    }
                    else if (cmbManualMaquina.Text == "EXTERNA2")
                    {
                        P_url_update = "http://10.10.20.15/api/externas/rq_tTuberiaExterna_2.php";
                    }
                    else
                    {
                        P_url_update = "http://10.10.20.15/api/externas/rq_tTuberiaExterna_3.php";
                    }
                    
                }
                guardar_archivos_excel_tubo(hora_inicial, hora_final, manual_carpeta, cmbManualSoldadura.Text, cmbManualMaquina.Text);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Height != 545)
            {
                string valor = "CONTRASEÑA";
                string contraseña = inputboxvb.InputBox("CONTRASEÑA", "ESCRIBE", ref valor);
                ptbIndicador2.Image = iglImagenes.Images[6];
                if (contraseña == "JGM")
                {
                    cmbManualSoldadura.Items.Add("INTERNA");
                    cmbManualSoldadura.Items.Add("EXTERNA");
                    this.Height = 545;
                    this.Width = 875;
                    P_manual = true;
                    btnModoManual.Text = "CERRAR";
                    btnIniciarAuto.Enabled = false;
                    btnPararAuto.Enabled = false;
                    tssLEstado.Text = "Modo Manual";
                }
            }
            else
            {
                Iniciar_formulario_principal();
            }

           
        }

        void Crear_excel_rutina()
        {
            //string exin_excel=dgvDatosTabla.Rows[0].Cells[6].Value.ToString().Substring(0,2);
            string maquina_reporte = P_maquina_reporte;
            ltbTemporal.Items.Clear();
            string S01 = dgvDatosTabla.Rows[0].Cells[10].Value.ToString();
            lblTemporal.Text = S01;
            char[] delimit = new char[] { ',' };
            int i01 = S01.IndexOf(","), j = 0;
            string S02 = S01.Remove(i01, (S01.Length - i01));
            ltbTemporal.Items.Add(S02);
            int numero_archivos = Int32.Parse(S02);
            string[] array_string = new string[numero_archivos + 1];
            //separar los nombres de los archivos excel
            foreach (string substr in S01.Split(delimit))
            {
                ltbTemporal.Items.Add(substr);

                if (j < (numero_archivos + 1))
                {
                    array_string[j] = substr;
                    j += 1;
                }

            }

            //abrir archivos excel
            //crear archivo excel para reporte

            Excel.Application reporte_tuberia = new Excel.Application();
            Excel.Workbook rt_book = reporte_tuberia.Workbooks.Add();
            Excel.Worksheet rt_sheet = (Excel.Worksheet)rt_book.Worksheets[1];

            Excel.Worksheet rt_s_tablas = (Excel.Worksheet)rt_book.Worksheets.Add();

            //Excel.Shapes imagen_logo = (Excel.Shapes)rt_s_tablas.Shapes;
            Excel.Range rangoceldas;
            rt_sheet.Name = "DATOS TUBERIA";
            //rt_s_tablas.Name = "tabla";

            //arcvhivo excel para abrir los archivos con datos de soldadura
            Excel.Application archivo_excel = new Excel.Application();
            Excel.Workbook ae_book = null;
            object oMissiong = System.Reflection.Missing.Value;
            int r = 0;
            int rango;
            int rango_anterior = 0;
            string temporal_celda;
            //abrir archivos excel 
            string path_archivos_excel;

            //-------------------------------------------------------------------------
            //PAGINA 1 DEL LIBRO EXCEL DATOS DE TUBERIA Y PORMEDIOS DE SOLDADURA

            //desabilita funciones para crear reporte
            Desabilitar_botones_ce(true);
            ptbIndicador1.Image = iglImagenes.Images[16];

            //empieza creacion de reporte 
            //solicitar datos del proyecto
            P_proyecto_datatable.Clear();
            Rellenar_tabla_proyectos(dgvDatosTabla.Rows[0].Cells[3].Value.ToString());
            P_operador_datatable.Clear();
            Rellenar_tabla_operador(dgvDatosTabla.Rows[0].Cells[6].Value.ToString());
            //dar formato a tabla
            //encabezado
            /*string directorio_resource = Directory.GetCurrentDirectory();
            imagen_logo.AddPicture(directorio_resource, Microsoft.Office.Core.MsoTriState.msoFalse,
                Microsoft.Office.Core.MsoTriState.msoCTrue, rt_sheet.Range["A1"].Left, rt_sheet.Range["A1"].Top,
                200, 100);*/
            rangoceldas = rt_sheet.Range["F2:L2"];
            rangoceldas.Merge();
            rangoceldas.FormulaR1C1 = "TUBACERO S. DE R.L. DE C.V.";
            rangoceldas.HorizontalAlignment = 3;
            rangoceldas.VerticalAlignment = 3;
            rangoceldas.Font.Size = 27;
            rangoceldas.Font.Bold = true;
            rangoceldas = rt_sheet.Range["E3:K3"];
            rangoceldas.Merge();
            rangoceldas.FormulaR1C1 = "REPORTE DE PARAMEROS DE SOLDADURA POR TUBO";
            rangoceldas.HorizontalAlignment = 3;
            rangoceldas.VerticalAlignment = 3;
            rangoceldas.Font.Size = 16;
            rangoceldas.Font.Bold = true;
            //datos del reporte

            rangoceldas = rt_sheet.Range["A5:P24"];
            rangoceldas.Font.Size = 16;
            rt_sheet.Range["O5"].Value = "FECHA:";
            rt_sheet.Range["P5"].Value = dgvDatosTabla.Rows[0].Cells[7].Value.ToString();
            rt_sheet.Range["P5"].Font.Bold = true;
            rt_sheet.Range["O6"].Value = "HORA:";
            rt_sheet.Range["P6"].Value = dgvDatosTabla.Rows[0].Cells[8].Value.ToString();
            rt_sheet.Range["P6"].Font.Bold = true;
            //datos del proyecto
            rt_sheet.Range["A5"].Value = "DATOS DEL PROYECTO";
            rt_sheet.Range["A6"].Value = "NOMBRE";
            rt_sheet.Range["C6"].Value = P_proyecto_datatable.Rows[0]["Nombre"].ToString();
            rt_sheet.Range["C6"].Font.Bold = true;
            rt_sheet.Range["A7"].Value = "ESPECIFICACION";
            rt_sheet.Range["C7"].Value = P_proyecto_datatable.Rows[0]["Especificacion"].ToString();
            rt_sheet.Range["C7"].Font.Bold = true;
            rt_sheet.Range["A8"].Value = "ORDEN DE TRABAJO";
            rt_sheet.Range["C8"].Value = P_proyecto_datatable.Rows[0]["OrdenTrabajo"].ToString();
            rt_sheet.Range["C8"].Font.Bold = true;
            //datos del tubo
            rt_sheet.Range["G5"].Value = "DATOS DEL TUBO";
            rt_sheet.Range["G6"].Value = "No. TUBO:";
            rt_sheet.Range["I6"].Value = dgvDatosTabla.Rows[0].Cells[1].Value.ToString();
            rt_sheet.Range["I6"].Font.Bold = true;
            rt_sheet.Range["G7"].Value = "No. PLACA:";
            rt_sheet.Range["I7"].Value = dgvDatosTabla.Rows[0].Cells[2].Value.ToString();
            rt_sheet.Range["I7"].Font.Bold = true;
            rt_sheet.Range["J6"].Value = "DIAMETRO:";
            rt_sheet.Range["L6"].Value = P_proyecto_datatable.Rows[0]["Diametro"].ToString();
            rt_sheet.Range["L6"].Font.Bold = true;
            rt_sheet.Range["J7"].Value = "ESPESOR:";
            rt_sheet.Range["L7"].Value = P_proyecto_datatable.Rows[0]["Espesor"].ToString();
            rt_sheet.Range["L7"].Font.Bold = true;
            //datos de alambre y fundente
            rt_sheet.Range["A9"].Value = "DATOS DE ALAMBRE Y FUNDENTE";
            rt_sheet.Range["A10"].Value = "ALAMBRE:";
            rt_sheet.Range["C10"].Value = P_proyecto_datatable.Rows[0]["Alambre"].ToString();
            rt_sheet.Range["C10"].Font.Bold = true;
            rt_sheet.Range["E10"].Value = "LOTE:";
            rt_sheet.Range["F10"].Value = dgvDatosTabla.Rows[0].Cells[4].Value.ToString();
            rt_sheet.Range["F10"].Font.Bold = true;
            rt_sheet.Range["I10"].Value = "FUNDENTE:";
            rt_sheet.Range["K10"].Value = P_proyecto_datatable.Rows[0]["Fundente"].ToString();
            rt_sheet.Range["K10"].Font.Bold = true;
            rt_sheet.Range["M10"].Value = "LOTE:";
            rt_sheet.Range["N10"].Value = dgvDatosTabla.Rows[0].Cells[5].Value.ToString();
            rt_sheet.Range["N10"].Font.Bold = true;

            //datos del operador
            rt_sheet.Range["A12"].Value = "DATOS DE OPERADOR";
            rt_sheet.Range["A13"].Value = "MAQUINA";
            rt_sheet.Range["C13"].Value = maquina_reporte;
            rt_sheet.Range["C13"].Font.Bold = true;
            rt_sheet.Range["E13"].Value = "TURNO";
            rt_sheet.Range["G13"].Value = "no aplica";
            rt_sheet.Range["G13"].Font.Bold = true;
            rt_sheet.Range["A14"].Value = "OPERADOR";
            rt_sheet.Range["C14"].Value = P_operador_datatable.Rows[0]["Nombre"].ToString();
            rt_sheet.Range["C14"].Font.Bold = true;
            rt_sheet.Range["H14"].Value = "FOLIO";
            rt_sheet.Range["I14"].Value = P_operador_datatable.Rows[0]["Folio"].ToString();
            rt_sheet.Range["I14"].Font.Bold = true;
            rt_sheet.Range["K14"].Value = "CS-";
            rt_sheet.Range["L14"].Value = P_operador_datatable.Rows[0]["Clave_soldador"].ToString();
            rt_sheet.Range["L14"].Font.Bold = true;
            rt_sheet.Range["A15"].Value = "SUPERVISOR";
            rt_sheet.Range["C15"].Value = "sin datos";
            rt_sheet.Range["C15"].Font.Bold = true;
            rt_sheet.Range["H15"].Value = "FOLIO";
            rt_sheet.Range["I15"].Value = "sin datos";
            rt_sheet.Range["I15"].Font.Bold = true;
            rt_sheet.Range["A16"].Value = "OBSERVACIONES";
            rt_sheet.Range["C16"].Value = dgvDatosTabla.Rows[0].Cells[11].Value.ToString();
            rt_sheet.Range["C16"].Font.Bold = true;
            //PROMEDIO DE PARAMETROS
            rt_sheet.Range["A18"].Value = "PROMEDIOS PARAMETROS MEDIDOS";
            rt_sheet.Range["A19"].Value = "CORRIENTE CD";
            rt_sheet.Range["C19"].Value = "VOLTAJE CD";
            rt_sheet.Range["E19"].Value = "CORRIENTE AC-1";
            rt_sheet.Range["G19"].Value = "VOLTAJE AC-1";
            rt_sheet.Range["I19"].Value = "CORRIENTE AC-2";
            rt_sheet.Range["K19"].Value = "VOLTAJE AC-2";
            if (maquina_reporte.Contains("EXTERNA"))
            {
                rt_sheet.Range["M19"].Value = "CORRIENTE AC-3";
                rt_sheet.Range["O19"].Value = "VOLTAJE AC-3";
                rt_sheet.Range["M22"].Value = "POTENCIA CA-3";
            }

            rt_sheet.Range["A22"].Value = "POTENCIA CD";
            rt_sheet.Range["E22"].Value = "POTENCIA CA-1";
            rt_sheet.Range["I22"].Value = "POTENCIA CA-2";

            rangoceldas = rt_sheet.Range["A20:O20"];
            rangoceldas.Font.Bold = true;
            rangoceldas = rt_sheet.Range["A23:O23"];
            rangoceldas.Font.Bold = true;
            rangoceldas = rt_sheet.Range["A1:P24"];
            rangoceldas.Borders.Color = Color.White;

            //-------------------------------------------------------------------------
            //PAGINA 2 DEL LIBRO EXCEL- TABLA DE VALORES DE PARAMETROS DE SOLDADURA

            rangoceldas = rt_s_tablas.Range["C2:H2"];
            rangoceldas.HorizontalAlignment = 3;
            rangoceldas.VerticalAlignment = 3;
            rangoceldas.Font.Size = 16;
            rangoceldas.Font.Bold = true;
            rangoceldas.Merge();
            rangoceldas.Value = "VALORES REGISTRADOS DE PARAMETROS";
            rt_s_tablas.Range["J2"].Value = "FECHA:";
            rt_s_tablas.Range["K2"].Value = dgvDatosTabla.Rows[0].Cells[7].Value.ToString();
            rangoceldas = rt_s_tablas.Range["J2:K2"];
            rangoceldas.HorizontalAlignment = 3;
            rangoceldas.VerticalAlignment = 3;
            rangoceldas.Font.Size = 16;
            rangoceldas.Font.Bold = true;
            rt_s_tablas.Range["A5"].Value = "HORA";
            rt_s_tablas.Range["C5"].Value = "VOLTAJE CD";
            rt_s_tablas.Range["E5"].Value = "AMPERAJE CD";
            rt_s_tablas.Range["G5"].Value = "VOLTAJE CA-1";
            rt_s_tablas.Range["I5"].Value = "AMPERAJE CA-1";
            rt_s_tablas.Range["K5"].Value = "VOLTAJE CA-2";
            rt_s_tablas.Range["M5"].Value = "AMPERAJE CA-2";

            if (maquina_reporte.Contains("EXTERNA"))
            {
                rt_s_tablas.Range["O5"].Value = "VOLTAJE CA-3";
                rt_s_tablas.Range["Q5"].Value = "AMPERAJE CA-3";
                rt_s_tablas.Range["Y5"].Value = "POTENCIA CA-3";

            }
            rt_s_tablas.Range["S5"].Value = "POTENCIA CD";
            rt_s_tablas.Range["U5"].Value = "POTENCIA CA-1";
            rt_s_tablas.Range["W5"].Value = "POTENCIA CA-2";

            rango_anterior = 6;

            if (ckbExcel.Checked == false)
            {
                string[] array_temporal = array_string;
                string path_temporal_txt;
                string path_temporal_nuevo = @"C:\Users\Public\Documents\SMARTDAC+ Data Logging Software\Data\";
                for (int i = 1; i < array_temporal.Length; i++)
                {
                    path_temporal_txt = path_temporal + array_temporal[i];
                    path_temporal_nuevo = path_temporal_nuevo + array_temporal[i];
                    File.Copy(path_temporal_txt, path_temporal_nuevo);

                    File.Move(path_temporal_nuevo, Path.ChangeExtension(path_temporal_txt, ".csv"));
                    array_string[i] = array_string[i].Replace(".txt", ".csv");
                    File.Delete(path_temporal_nuevo);
                }
            }
            for (int i = 1; i < array_string.Length; i++)
            {
                try
                {
                    path_archivos_excel = path_temporal + array_string[i];
                    //Abrir archivo de datos de soldadura
                    ae_book = archivo_excel.Workbooks.Open(path_archivos_excel);
                    Excel.Worksheet ae_sheet = (Excel.Worksheet)ae_book.Worksheets.Item[1];
                    r = ae_sheet.UsedRange.Rows.Count;
                    lblTemporal.Text = r.ToString();
                    rango = r - 39;
                    rt_s_tablas.Range["A5:Y" + (rango + rango_anterior)].Font.Size = 14;

                    //valores de hora
                    temporal_celda = "A" + (rango_anterior).ToString() + ":A" + (rango + rango_anterior - 1).ToString();
                    rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("B40:B" + r.ToString())].Value2;
                    if (maquina_reporte.Contains("EXTERNA"))
                    {
                        //celdas pra reportes de externas incluye CA3
                        //valores de voltaje de CA3
                        temporal_celda = "O" + (rango_anterior).ToString() + ":O" + (rango + rango_anterior - 1).ToString();
                        rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("H40:H" + r.ToString())].Value2; ;
                        //valores de corriente de CA3
                        temporal_celda = "Q" + (rango_anterior).ToString() + ":Q" + (rango + rango_anterior - 1).ToString();
                        rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("I40:I" + r.ToString())].Value2;
                        //valores de voltaje de CD
                        temporal_celda = "C" + (rango_anterior).ToString() + ":C" + (rango + rango_anterior - 1).ToString();
                        rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("J40:J" + r.ToString())].Value2;
                        //valores de corriente de CD
                        temporal_celda = "E" + (rango_anterior).ToString() + ":E" + (rango + rango_anterior - 1).ToString();
                        rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("K40:K" + r.ToString())].Value2;

                        //valores de potencia CD
                        temporal_celda = "S" + (rango_anterior).ToString() + ":S" + (rango + rango_anterior - 1).ToString();
                        rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("O40:O" + r.ToString())].Value2;
                        //valores de potencia CA-1
                        temporal_celda = "U" + (rango_anterior).ToString() + ":U" + (rango + rango_anterior - 1).ToString();
                        rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("L40:L" + r.ToString())].Value2;
                        //valores de potencia CA-2
                        temporal_celda = "W" + (rango_anterior).ToString() + ":W" + (rango + rango_anterior - 1).ToString();
                        rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("M40:M" + r.ToString())].Value2;
                        //valores de potencia CA-3
                        temporal_celda = "Y" + (rango_anterior).ToString() + ":Y" + (rango + rango_anterior - 1).ToString();
                        rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("N40:N" + r.ToString())].Value2;

                    }
                    else
                    {
                        //CELDAS PARA REPORTE DE INTERNAS
                        //valores de voltaje de CD
                        temporal_celda = "C" + (rango_anterior).ToString() + ":C" + (rango + rango_anterior - 1).ToString();
                        rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("H40:H" + r.ToString())].Value2;
                        //valores de corriente de CD
                        temporal_celda = "E" + (rango_anterior).ToString() + ":E" + (rango + rango_anterior - 1).ToString();
                        rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("I40:I" + r.ToString())].Value2;

                        //valores de potencia CD
                        temporal_celda = "O" + (rango_anterior).ToString() + ":O" + (rango + rango_anterior - 1).ToString();
                        rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("L40:L" + r.ToString())].Value2;
                        //valores de potencia CA-1
                        temporal_celda = "Q" + (rango_anterior).ToString() + ":Q" + (rango + rango_anterior - 1).ToString();
                        rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("J40:J" + r.ToString())].Value2;
                        //valores de potencia CA-2
                        temporal_celda = "S" + (rango_anterior).ToString() + ":S" + (rango + rango_anterior - 1).ToString();
                        rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("K40:K" + r.ToString())].Value2;

                    }

                    //valores de voltaje de CA1
                    temporal_celda = "G" + (rango_anterior).ToString() + ":G" + (rango + rango_anterior - 1).ToString();
                    rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("D40:D" + r.ToString())].Value2;
                    //valores de corriente de CA1
                    temporal_celda = "I" + (rango_anterior).ToString() + ":I" + (rango + rango_anterior - 1).ToString();
                    rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("E40:E" + r.ToString())].Value2;
                    //valores de voltaje de CA2
                    temporal_celda = "K" + (rango_anterior).ToString() + ":K" + (rango + rango_anterior - 1).ToString();
                    rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("F40:F" + r.ToString())].Value2;
                    //valores de corriente de CA2
                    temporal_celda = "M" + (rango_anterior).ToString() + ":M" + (rango + rango_anterior - 1).ToString();
                    rt_s_tablas.Range[temporal_celda].Value = ae_sheet.Range[("G40:G" + r.ToString())].Value2;


                    _ = rt_s_tablas.UsedRange.Rows.Count;
                    rango_anterior = rt_s_tablas.UsedRange.Rows.Count + 1;

                    //cerrar excel usado para copiar datos
                    ae_book.Close(false, oMissiong, oMissiong);
                    archivo_excel.Workbooks.Close();

                }
                catch (Exception e)
                {

                    MessageBox.Show("AE: " + e.ToString());
                }
            }

            archivo_excel.Quit();



            try
            {

                //pasar datos de soldadura de un excel al excel del reporte
                //VALORES PROMEDIOS DE VOLTAJE Y CORRIENTES
                string celda_pca1, celda_pca2, celda_pcd;
                rango = rt_s_tablas.UsedRange.Rows.Count;
                //valores de voltaje de CD
                temporal_celda = "C" + rango.ToString();
                rt_s_tablas.Range[("C" + (1 + rango).ToString())].FormulaLocal = "=PROMEDIO(C6:" + temporal_celda + ")";
                temporal_celda = "C" + (1 + rango).ToString();
                rt_sheet.Range["C20"].Value = "=Hoja2!" + temporal_celda;
                rt_sheet.Range["D20"].Value = "V";
               //valores de corriente de CD
               temporal_celda = "E" + rango.ToString();
                rt_s_tablas.Range[("E" + (1 + rango).ToString())].FormulaLocal = "=PROMEDIO(E6:" + temporal_celda + ")";
                temporal_celda = "E" + (1 + rango).ToString();
                rt_sheet.Range["A20"].Value = "=Hoja2!" + temporal_celda;
                rt_sheet.Range["B20"].Value = "A";
                //valores de voltaje de CA1
                temporal_celda = "G" + rango.ToString();
                rt_s_tablas.Range[("G" + (1 + rango).ToString())].FormulaLocal = "=PROMEDIO(G6:" + temporal_celda + ")";
                temporal_celda = "G" + (1 + rango).ToString();
                rt_sheet.Range["G20"].Value = "=Hoja2!" + temporal_celda;
                rt_sheet.Range["H20"].Value = "V";
                //valores de corriente de CA1
                temporal_celda = "I" + rango.ToString();
                rt_s_tablas.Range[("I" + (1 + rango).ToString())].FormulaLocal = "=PROMEDIO(I6:" + temporal_celda + ")";
                temporal_celda = "I" + (1 + rango).ToString();
                rt_sheet.Range["E20"].Value = "=Hoja2!" + temporal_celda;
                rt_sheet.Range["D20"].Value = "A";
                //valores de voltaje de CA2
                temporal_celda = "K" + rango.ToString();
                rt_s_tablas.Range[("K" + (1 + rango).ToString())].FormulaLocal = "=PROMEDIO(K6:" + temporal_celda + ")";
                temporal_celda = "K" + (1 + rango).ToString();
                rt_sheet.Range["K20"].Value = "=Hoja2!" + temporal_celda;
                rt_sheet.Range["L20"].Value = "V";
                //valores de corriente de CA2
                temporal_celda = "M" + rango.ToString();
                rt_s_tablas.Range[("M" + (1 + rango).ToString())].FormulaLocal = "=PROMEDIO(M6:" + temporal_celda + ")";
                temporal_celda = "M" + (1 + rango).ToString();
                rt_sheet.Range["I20"].Value = "=Hoja2!" + temporal_celda;
                rt_sheet.Range["J20"].Value = "V";




                if (maquina_reporte.Contains("EXTERNA"))
                {
                    //CELDAS PARA REPORTE DE EXTERNAS
                    //valores de voltaje de CA3
                    temporal_celda = "O" + rango.ToString();
                    rt_s_tablas.Range[("O" + (1 + rango).ToString())].FormulaLocal = "=PROMEDIO(O6:" + temporal_celda + ")";
                    temporal_celda = "O" + (1 + rango).ToString();
                    rt_sheet.Range["O20"].Value = "=Hoja2!" + temporal_celda;
                    rt_sheet.Range["P20"].Value = "V";
                    //valores de corriente de CA3
                    temporal_celda = "Q" + rango.ToString();
                    rt_s_tablas.Range[("Q" + (1 + rango).ToString())].FormulaLocal = "=PROMEDIO(Q6:" + temporal_celda + ")";
                    temporal_celda = "Q" + (1 + rango).ToString();
                    rt_sheet.Range["M20"].Value = "=Hoja2!" + temporal_celda;
                    rt_sheet.Range["N20"].Value = "A";
                    //valores de potencia CA-3
                    temporal_celda = "Y" + rango.ToString();
                    rt_s_tablas.Range[("Y" + (1 + rango).ToString())].FormulaLocal = "=PROMEDIO(Y6:" + temporal_celda + ")";
                    temporal_celda = "Y" + (1 + rango).ToString();
                    rt_sheet.Range["M23"].Value = "=Hoja2!" + temporal_celda;
                    rt_sheet.Range["N23"].Value = "kW";

                    //valores de potencia CD
                    temporal_celda = "S" + rango.ToString();
                    rt_s_tablas.Range[("S" + (1 + rango).ToString())].FormulaLocal = "=PROMEDIO(S6:" + temporal_celda + ")";
                    temporal_celda = "S" + (1 + rango).ToString();
                    rt_sheet.Range["A23"].Value = "=Hoja2!" + temporal_celda;
                    rt_sheet.Range["B23"].Value = "kW";
                    //valores de potencia CA-1
                    temporal_celda = "U" + rango.ToString();
                    rt_s_tablas.Range[("U" + (1 + rango).ToString())].FormulaLocal = "=PROMEDIO(U6:" + temporal_celda + ")";
                    temporal_celda = "U" + (1 + rango).ToString();
                    rt_sheet.Range["E23"].Value = "=Hoja2!" + temporal_celda;
                    rt_sheet.Range["F23"].Value = "kW";
                    //valores de potencia CA-2
                    temporal_celda = "W" + rango.ToString();
                    rt_s_tablas.Range[("W" + (1 + rango).ToString())].FormulaLocal = "=PROMEDIO(W6:" + temporal_celda + ")";
                    temporal_celda = "W" + (1 + rango).ToString();
                    rt_sheet.Range["I23"].Value = "=Hoja2!" + temporal_celda;
                    rt_sheet.Range["J23"].Value = "kW";

                    celda_pcd = "S";
                    celda_pca1 = "U";
                    celda_pca2 = "W";
                }
                else
                {
                    //valores de potencia CD
                    temporal_celda = "O" + rango.ToString();
                    rt_s_tablas.Range[("O" + (1 + rango).ToString())].FormulaLocal = "=PROMEDIO(O6:" + temporal_celda + ")";
                    temporal_celda = "O" + (1 + rango).ToString();
                    rt_sheet.Range["A23"].Value = "=Hoja2!" + temporal_celda;
                    rt_sheet.Range["B23"].Value = "kW";
                    //valores de potencia CA-1
                    temporal_celda = "Q" + rango.ToString();
                    rt_s_tablas.Range[("Q" + (1 + rango).ToString())].FormulaLocal = "=PROMEDIO(Q6:" + temporal_celda + ")";
                    temporal_celda = "Q" + (1 + rango).ToString();
                    rt_sheet.Range["E23"].Value = "=Hoja2!" + temporal_celda;
                    rt_sheet.Range["F23"].Value = "kW";
                    //valores de potencia CA-2
                    temporal_celda = "S" + rango.ToString();
                    rt_s_tablas.Range[("S" + (1 + rango).ToString())].FormulaLocal = "=PROMEDIO(S6:" + temporal_celda + ")";
                    temporal_celda = "S" + (1 + rango).ToString();
                    rt_sheet.Range["I23"].Value = "=Hoja2!" + temporal_celda;
                    rt_sheet.Range["J23"].Value = "kW";

                    celda_pcd = "O";
                    celda_pca1 = "Q";
                    celda_pca2 = "S";
                }


                rango = rt_s_tablas.UsedRange.Rows.Count;

                //----------------CREAR GRAFICAS--------------
                Excel.Chart chartpage = new Excel.Chart();
                Excel.ChartObjects objcharts;
                Excel.ChartObject mychart;
                Excel.Range chartrango;
                string temporal_celdas_origen, temporal_celdas_destino;

                //GRAFICAS DE DE ARCO CD
                //GRAFICA DE VOLTAJE DE CD
                Excel.Worksheet grafica_dc = (Excel.Worksheet)rt_book.Worksheets.Add();
                grafica_dc.Name = "GRAF_DC";

                grafica_dc.Range["F2"].Value = "GRAFICAS DE ARCO CD";
                grafica_dc.Range["F2"].Font.Size = 20;
                grafica_dc.Range["F2"].Font.Bold = true;

                grafica_dc.Range["B5"].Value = "TABLA DE VALORES DE PARAMETROS";
                grafica_dc.Range["B5"].Font.Size = 14;
                grafica_dc.Range["B5"].Font.Bold = true;

                //HORA
                temporal_celdas_origen = "A5:" + "A" + rango.ToString();
                temporal_celdas_destino = "B7" + ":B" + (rango + 2).ToString();
                grafica_dc.Range[temporal_celdas_destino].Value = rt_s_tablas.Range[temporal_celdas_origen].Value2;
                grafica_dc.Range[temporal_celdas_destino].NumberFormat = "hh:mm:ss AM/PM";
                //VALORES DE VOLTAJE CD
                temporal_celdas_origen = "C5:" + "C" + rango.ToString();
                temporal_celdas_destino = "C7" + ":C" + (rango + 2).ToString();
                grafica_dc.Range[temporal_celdas_destino].Value = rt_s_tablas.Range[temporal_celdas_origen].Value2;
                //VALORES DE CORRIENTE CD
                temporal_celdas_origen = "E5:" + "E" + rango.ToString();
                temporal_celdas_destino = "D7" + ":D" + (rango + 2).ToString();
                grafica_dc.Range[temporal_celdas_destino].Value = rt_s_tablas.Range[temporal_celdas_origen].Value2;
                //VALORES DE POTENCIA CD
                temporal_celdas_origen = celda_pcd + "5:" + celda_pcd + rango.ToString();
                temporal_celdas_destino = "E7" + ":E" + (rango + 2).ToString();
                grafica_dc.Range[temporal_celdas_destino].Value = rt_s_tablas.Range[temporal_celdas_origen].Value2;

                grafica_dc.Range["A5:E" + (rango + 2).ToString()].Font.Size = 14;
                grafica_dc.Range["A5:E" + (rango + 2).ToString()].Font.Bold = true;

                //GRAFICA DE VOLTAJE DE CD
                grafica_dc.Range["G5"].Value = "GRAFICA DE VOLTAJE CD";
                grafica_dc.Range["G5"].Font.Size = 14;
                grafica_dc.Range["G5"].Font.Bold = true;

                objcharts = grafica_dc.ChartObjects();
                mychart = objcharts.Add(rt_sheet.Range["H6"].Left, rt_sheet.Range["H6"].Top, 945, 430);
                chartpage = mychart.Chart;
                chartrango = grafica_dc.Range["B8:" + "B" + (rango + 2).ToString() + ",C8:" + "C" + (rango + 2).ToString()];
                chartpage.SetSourceData(chartrango);
                chartpage.ChartType = Excel.XlChartType.xlLine;
                chartpage.ChartStyle = 3;

                //GRAFICA DE CORRIENTE DE CD
                grafica_dc.Range["G32"].Value = "GRAFICA DE CORRIENTE CD";
                grafica_dc.Range["G32"].Font.Size = 14;
                grafica_dc.Range["G32"].Font.Bold = true;

                objcharts = grafica_dc.ChartObjects();
                mychart = objcharts.Add(rt_sheet.Range["H33"].Left, rt_sheet.Range["H33"].Top, 945, 430);
                chartpage = mychart.Chart;
                chartrango = grafica_dc.Range["B8:" + "B" + (rango + 2).ToString() + ",D8:" + "D" + (rango + 2).ToString()];
                chartpage.SetSourceData(chartrango);
                chartpage.ChartType = Excel.XlChartType.xlLine;
                chartpage.ChartStyle = 4;

                //GRAFICA DE POTENCIA DE CD
                grafica_dc.Range["G60"].Value = "GRAFICA DE POTENCIA CD";
                grafica_dc.Range["G60"].Font.Size = 14;
                grafica_dc.Range["G60"].Font.Bold = true;

                objcharts = grafica_dc.ChartObjects();
                mychart = objcharts.Add(rt_sheet.Range["H67"].Left, rt_sheet.Range["H67"].Top, 945, 430);
                chartpage = mychart.Chart;
                chartrango = grafica_dc.Range["B8:" + "B" + (rango + 2).ToString() + ",E8:" + "E" + (rango + 2).ToString()];
                chartpage.SetSourceData(chartrango);
                chartpage.ChartType = Excel.XlChartType.xlLine;
                chartpage.ChartStyle = 4;

                //GRAFICAS DE DE ARCO CA1*********************
                //GRAFICA DE VOLTAJE DE CA1
                Excel.Worksheet grafica_ac1 = (Excel.Worksheet)rt_book.Worksheets.Add();
                grafica_ac1.Name = "GRAF_CA1";

                grafica_ac1.Range["F2"].Value = "GRAFICAS DE ARCO CA1";
                grafica_ac1.Range["F2"].Font.Size = 20;
                grafica_ac1.Range["F2"].Font.Bold = true;

                grafica_ac1.Range["B5"].Value = "TABLA DE VALORES DE PARAMETROS";
                grafica_ac1.Range["B5"].Font.Size = 14;
                grafica_ac1.Range["B5"].Font.Bold = true;

                //HORA
                temporal_celdas_origen = "A5:" + "A" + rango.ToString();
                temporal_celdas_destino = "B7" + ":B" + (rango + 2).ToString();
                grafica_ac1.Range[temporal_celdas_destino].Value = rt_s_tablas.Range[temporal_celdas_origen].Value2;
                grafica_ac1.Range[temporal_celdas_destino].NumberFormat = "hh:mm:ss AM/PM";
                //VALORES DE VOLTAJE CA1
                temporal_celdas_origen = "G5:" + "G" + rango.ToString();
                temporal_celdas_destino = "C7" + ":C" + (rango + 2).ToString();
                grafica_ac1.Range[temporal_celdas_destino].Value = rt_s_tablas.Range[temporal_celdas_origen].Value2;
                //VALORES DE CORRIENTE CA1
                temporal_celdas_origen = "I5:" + "I" + rango.ToString();
                temporal_celdas_destino = "D7" + ":D" + (rango + 2).ToString();
                grafica_ac1.Range[temporal_celdas_destino].Value = rt_s_tablas.Range[temporal_celdas_origen].Value2;
                //VALORES DE POTENCIA CA1
                temporal_celdas_origen = celda_pca1 + "5:" + celda_pca1 + rango.ToString();
                temporal_celdas_destino = "E7" + ":E" + (rango + 2).ToString();
                grafica_ac1.Range[temporal_celdas_destino].Value = rt_s_tablas.Range[temporal_celdas_origen].Value2;

                grafica_ac1.Range["A5:E" + (rango + 2).ToString()].Font.Size = 14;
                grafica_ac1.Range["A5:E" + (rango + 2).ToString()].Font.Bold = true;

                //GRAFICA DE VOLTAJE DE CA1
                grafica_ac1.Range["G5"].Value = "GRAFICA DE VOLTAJE CD";
                grafica_ac1.Range["G5"].Font.Size = 14;
                grafica_ac1.Range["G5"].Font.Bold = true;

                objcharts = grafica_ac1.ChartObjects();
                mychart = objcharts.Add(rt_sheet.Range["H6"].Left, rt_sheet.Range["H7"].Top, 945, 430);
                chartpage = mychart.Chart;
                chartrango = grafica_ac1.Range["B8:" + "B" + (rango + 2).ToString() + ",C8:" + "C" + (rango + 2).ToString()];
                chartpage.SetSourceData(chartrango);
                chartpage.ChartType = Excel.XlChartType.xlLine;
                chartpage.ChartStyle = 3;

                //GRAFICA DE CORRIENTE DE CA1
                grafica_ac1.Range["G32"].Value = "GRAFICA DE CORRIENTE CA1";
                grafica_ac1.Range["G32"].Font.Size = 14;
                grafica_ac1.Range["G32"].Font.Bold = true;

                objcharts = grafica_ac1.ChartObjects();
                mychart = objcharts.Add(rt_sheet.Range["H33"].Left, rt_sheet.Range["H33"].Top, 945, 430);
                chartpage = mychart.Chart;
                chartrango = grafica_ac1.Range["B8:" + "B" + (rango + 2).ToString() + ",D8:" + "D" + (rango + 2).ToString()];
                chartpage.SetSourceData(chartrango);
                chartpage.ChartType = Excel.XlChartType.xlLine;
                chartpage.ChartStyle = 4;

                //GRAFICA DE POTENCIA DE CA1
                grafica_ac1.Range["G60"].Value = "GRAFICA DE POTENCIA CA1";
                grafica_ac1.Range["G60"].Font.Size = 14;
                grafica_ac1.Range["G60"].Font.Bold = true;

                objcharts = grafica_ac1.ChartObjects();
                mychart = objcharts.Add(rt_sheet.Range["H67"].Left, rt_sheet.Range["H67"].Top, 945, 430);
                chartpage = mychart.Chart;
                chartrango = grafica_ac1.Range["B8:" + "B" + (rango + 2).ToString() + ",E8:" + "E" + (rango + 2).ToString()];
                chartpage.SetSourceData(chartrango);
                chartpage.ChartType = Excel.XlChartType.xlLine;
                chartpage.ChartStyle = 4;

                //GRAFICAS DE DE ARCO CA2
                //GRAFICA DE VOLTAJE DE CA2
                Excel.Worksheet grafica_ac2 = (Excel.Worksheet)rt_book.Worksheets.Add();
                grafica_ac2.Name = "GRAF_CA2";

                grafica_ac2.Range["F2"].Value = "GRAFICAS DE ARCO CA2";
                grafica_ac2.Range["F2"].Font.Size = 20;
                grafica_ac2.Range["F2"].Font.Bold = true;

                grafica_ac2.Range["B5"].Value = "TABLA DE VALORES DE PARAMETROS";
                grafica_ac2.Range["B5"].Font.Size = 14;
                grafica_ac2.Range["B5"].Font.Bold = true;

                //HORA
                temporal_celdas_origen = "A5:" + "A" + rango.ToString();
                temporal_celdas_destino = "B7" + ":B" + (rango + 2).ToString();
                grafica_ac2.Range[temporal_celdas_destino].Value = rt_s_tablas.Range[temporal_celdas_origen].Value2;
                grafica_ac2.Range[temporal_celdas_destino].NumberFormat = "hh:mm:ss AM/PM";
                //VALORES DE VOLTAJE CA2
                temporal_celdas_origen = "K5:" + "K" + rango.ToString();
                temporal_celdas_destino = "C7" + ":C" + (rango + 2).ToString();
                grafica_ac2.Range[temporal_celdas_destino].Value = rt_s_tablas.Range[temporal_celdas_origen].Value2;
                //VALORES DE CORRIENTE CA2
                temporal_celdas_origen = "M5:" + "M" + rango.ToString();
                temporal_celdas_destino = "D7" + ":D" + (rango + 2).ToString();
                grafica_ac2.Range[temporal_celdas_destino].Value = rt_s_tablas.Range[temporal_celdas_origen].Value2;
                //VALORES DE POTENCIA CA2
                temporal_celdas_origen = celda_pca2 + "5:" + celda_pca2 + rango.ToString();
                temporal_celdas_destino = "E7" + ":E" + (rango + 2).ToString();
                grafica_ac2.Range[temporal_celdas_destino].Value = rt_s_tablas.Range[temporal_celdas_origen].Value2;

                grafica_ac2.Range["A5:E" + (rango + 2).ToString()].Font.Size = 14;
                grafica_ac2.Range["A5:E" + (rango + 2).ToString()].Font.Bold = true;

                //GRAFICA DE VOLTAJE DE CA2
                grafica_ac2.Range["G5"].Value = "GRAFICA DE VOLTAJE CA2";
                grafica_ac2.Range["G5"].Font.Size = 14;
                grafica_ac2.Range["G5"].Font.Bold = true;

                objcharts = grafica_ac2.ChartObjects();
                mychart = objcharts.Add(rt_sheet.Range["H7"].Left, rt_sheet.Range["H7"].Top, 945, 430);
                chartpage = mychart.Chart;
                chartrango = grafica_ac2.Range["B8:" + "B" + (rango + 2).ToString() + ",C8:" + "C" + (rango + 2).ToString()];
                chartpage.SetSourceData(chartrango);
                chartpage.ChartType = Excel.XlChartType.xlLine;
                chartpage.ChartStyle = 3;

                //GRAFICA DE CORRIENTE DE CA2
                grafica_ac2.Range["G32"].Value = "GRAFICA DE CORRIENTE CA2";
                grafica_ac2.Range["G32"].Font.Size = 14;
                grafica_ac2.Range["G32"].Font.Bold = true;

                objcharts = grafica_ac2.ChartObjects();
                mychart = objcharts.Add(rt_sheet.Range["H33"].Left, rt_sheet.Range["H34"].Top, 945, 430);
                chartpage = mychart.Chart;
                chartrango = grafica_ac2.Range["B8:" + "B" + (rango + 2).ToString() + ",D8:" + "D" + (rango + 2).ToString()];
                chartpage.SetSourceData(chartrango);
                chartpage.ChartType = Excel.XlChartType.xlLine;
                chartpage.ChartStyle = 4;

                //GRAFICA DE POTENCIA DE CA2
                grafica_ac2.Range["G60"].Value = "GRAFICA DE POTENCIA CA2";
                grafica_ac2.Range["G60"].Font.Size = 14;
                grafica_ac2.Range["G60"].Font.Bold = true;

                objcharts = grafica_ac2.ChartObjects();
                mychart = objcharts.Add(rt_sheet.Range["H67"].Left, rt_sheet.Range["H67"].Top, 945, 430);
                chartpage = mychart.Chart;
                chartrango = grafica_ac2.Range["B8:" + "B" + (rango + 2).ToString() + ",E8:" + "E" + (rango + 2).ToString()];
                chartpage.SetSourceData(chartrango);
                chartpage.ChartType = Excel.XlChartType.xlLine;
                chartpage.ChartStyle = 4;

                if (maquina_reporte.Contains("EXTERNA"))
                {
                    //GRAFICAS DE DE ARCO CA3
                    //GRAFICA DE VOLTAJE DE CA3
                    Excel.Worksheet grafica_ac3 = (Excel.Worksheet)rt_book.Worksheets.Add();
                    grafica_ac3.Name = "GRAF_CA3";

                    grafica_ac3.Range["F2"].Value = "GRAFICAS DE ARCO CA3";
                    grafica_ac3.Range["F2"].Font.Size = 20;
                    grafica_ac3.Range["F2"].Font.Bold = true;

                    grafica_ac3.Range["B5"].Value = "TABLA DE VALORES DE PARAMETROS";
                    grafica_ac3.Range["B5"].Font.Size = 14;
                    grafica_ac3.Range["B5"].Font.Bold = true;

                    //HORA
                    temporal_celdas_origen = "A5:" + "A" + rango.ToString();
                    temporal_celdas_destino = "B7" + ":B" + (rango + 2).ToString();
                    grafica_ac3.Range[temporal_celdas_destino].Value = rt_s_tablas.Range[temporal_celdas_origen].Value2;
                    grafica_ac3.Range[temporal_celdas_destino].NumberFormat = "hh:mm:ss AM/PM";
                    //VALORES DE VOLTAJE CA3
                    temporal_celdas_origen = "O5:" + "O" + rango.ToString();
                    temporal_celdas_destino = "C7" + ":C" + (rango + 2).ToString();
                    grafica_ac3.Range[temporal_celdas_destino].Value = rt_s_tablas.Range[temporal_celdas_origen].Value2;
                    //VALORES DE CORRIENTE CA3
                    temporal_celdas_origen = "Q5:" + "Q" + rango.ToString();
                    temporal_celdas_destino = "D7" + ":D" + (rango + 2).ToString();
                    grafica_ac3.Range[temporal_celdas_destino].Value = rt_s_tablas.Range[temporal_celdas_origen].Value2;
                    //VALORES DE POTENCIA CA3
                    temporal_celdas_origen = "W5:" + "W" + rango.ToString();
                    temporal_celdas_destino = "E7" + ":E" + (rango + 2).ToString();
                    grafica_ac3.Range[temporal_celdas_destino].Value = rt_s_tablas.Range[temporal_celdas_origen].Value2;

                    grafica_ac3.Range["A5:E" + (rango + 2).ToString()].Font.Size = 14;
                    grafica_ac3.Range["A5:E" + (rango + 2).ToString()].Font.Bold = true;

                    //GRAFICA DE VOLTAJE DE CA3
                    grafica_ac3.Range["G5"].Value = "GRAFICA DE VOLTAJE CA3";
                    grafica_ac3.Range["G5"].Font.Size = 14;
                    grafica_ac3.Range["G5"].Font.Bold = true;

                    objcharts = grafica_ac3.ChartObjects();
                    mychart = objcharts.Add(rt_sheet.Range["H7"].Left, rt_sheet.Range["H7"].Top, 945, 430);
                    chartpage = mychart.Chart;
                    chartrango = grafica_ac3.Range["B8:" + "B" + (rango + 2).ToString() + ",C8:" + "C" + (rango + 2).ToString()];
                    chartpage.SetSourceData(chartrango);
                    chartpage.ChartType = Excel.XlChartType.xlLine;
                    chartpage.ChartStyle = 3;

                    //GRAFICA DE CORRIENTE DE CA3
                    grafica_ac3.Range["G32"].Value = "GRAFICA DE CORRIENTE CA3";
                    grafica_ac3.Range["G32"].Font.Size = 14;
                    grafica_ac3.Range["G32"].Font.Bold = true;

                    objcharts = grafica_ac3.ChartObjects();
                    mychart = objcharts.Add(rt_sheet.Range["H33"].Left, rt_sheet.Range["H34"].Top, 945, 430);
                    chartpage = mychart.Chart;
                    chartrango = grafica_ac3.Range["B8:" + "B" + (rango + 2).ToString() + ",D8:" + "D" + (rango + 2).ToString()];
                    chartpage.SetSourceData(chartrango);
                    chartpage.ChartType = Excel.XlChartType.xlLine;
                    chartpage.ChartStyle = 4;

                    //GRAFICA DE POTENCIA DE CA3
                    grafica_ac3.Range["G60"].Value = "GRAFICA DE POTENCIA CA3";
                    grafica_ac3.Range["G60"].Font.Size = 14;
                    grafica_ac3.Range["G60"].Font.Bold = true;

                    objcharts = grafica_ac3.ChartObjects();
                    mychart = objcharts.Add(rt_sheet.Range["H67"].Left, rt_sheet.Range["H67"].Top, 945, 430);
                    chartpage = mychart.Chart;
                    chartrango = grafica_ac3.Range["B8:" + "B" + (rango + 2).ToString() + ",E8:" + "E" + (rango + 2).ToString()];
                    chartpage.SetSourceData(chartrango);
                    chartpage.ChartType = Excel.XlChartType.xlLine;
                    chartpage.ChartStyle = 4;
                }


                //guardar excel del reporte 
                string[] charsToRemove = new string[] { "/" };
                string fecha = dgvDatosTabla.Rows[0].Cells[7].Value.ToString();
                string id_tubo_r = dgvDatosTabla.Rows[0].Cells[0].Value.ToString();
                foreach (var c in charsToRemove)
                {
                    fecha = fecha.Replace(c, string.Empty);
                }
                //NOMBRE PARA EL ARCHIVO DEL REPORTE
                //R_IDP-(ID_PROYECTO)_IDT-(ID_TUBO)_f-(FECHA)
                string nombre_reporte = "R_IDP-" + dgvDatosTabla.Rows[0].Cells[3].Value.ToString() + "_IDT-" + id_tubo_r + "_f-" + fecha;
                string pat = path_reportes_excel + maquina_reporte + "\\" + nombre_reporte + ".xlsx";
                rt_book.SaveAs(pat, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, Excel.XlSaveAsAccessMode.xlNoChange,
                                oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                rt_book.Close(true, oMissiong, oMissiong);
                reporte_tuberia.Workbooks.Close();
                reporte_tuberia.Quit();


                Actualizar_Reporte_excel(nombre_reporte, maquina_reporte);

                //GC.Collect();
                //GC.WaitForPendingFinalizers();
                //habilitar botones
                Desabilitar_botones_ce(false);
                ptbIndicador1.Image = iglImagenes.Images[17];
                
            }
            catch (Exception e)
            {
                //habilitar botones
                Desabilitar_botones_ce(false);
                ptbIndicador1.Image = iglImagenes.Images[17];
                MessageBox.Show("TABLA EXCEL ERROR: " + e.ToString());
            }
        }
    }
}
