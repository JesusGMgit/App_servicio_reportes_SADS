using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using app_servicio_SADS2.clases;

namespace app_servicio_SADS2
{
    public partial class Busqueda_tubo : Form
    {
        string P_url_apis = "http://10.10.20.15/backend/api/";
        string pathP = @"C:\Users\Public\Documents\SMARTDAC+ Data Logging Software\Data\";
        string path_reportes_excel = @"C:\xampp\htdocs\Reportes\";
        string P_path_smartdac_PH = @"C:\Users\Public\Documents\SMARTDAC+ Data Logging Software\Data\PH PRUEBAS\";
        string P_path_reportes_PH = @"C:\xampp\htdocs\Reportes\PH\";
        System.Data.DataTable P_Tuberia_datatable = new System.Data.DataTable();
        System.Data.DataTable P_ATuberia_datatable = new System.Data.DataTable();
        System.Data.DataTable P_proyecto_datatable = new System.Data.DataTable();
        System.Data.DataTable P_operador_datatable = new System.Data.DataTable();
        System.Data.DataTable P_datatable_datos_archivos_PH = new System.Data.DataTable();
        ArchivosPH ArchivosPH_ = new ArchivosPH();

        public Busqueda_tubo()
        {
            InitializeComponent();
        }

        private void Busqueda_tubo_Load(object sender, EventArgs e)
        {
            Iniciar_tabla_tuberia();
            Iniciar_tabla_registro_anterior();
            Iniciar_tabla_proyecto();
            Iniciar_tabla_operador();
            Limpiar_objetos();
            //ArchivosPH_.IniciarTablaDatosArchivoPH();
            //IniciarTablaDatosArchivoPH();


        }
        void IniciarTablaDatosArchivoPH()
        {
            P_datatable_datos_archivos_PH.Columns.Clear();
            P_datatable_datos_archivos_PH.Columns.Add("Nombre_Archivo");
            P_datatable_datos_archivos_PH.Columns.Add("Hora");
            P_datatable_datos_archivos_PH.Columns.Add("Fecha");
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

        void Rellenar_tabla_proyectos()
        {
            string url_proyecto = "http://10.10.20.15/backend/api/ar_tProyectos.php?";
            var resultado_proyecto = Consultas.Get_API(url_proyecto);
            List<Proyecto_tabla> temporal_results = JsonConvert.DeserializeObject<List<Proyecto_tabla>>(resultado_proyecto);
            foreach (var r in temporal_results)
            {
                P_proyecto_datatable.Rows.Add(r.pro_id, r.pro_nombre, r.pro_diametro, r.pro_espesor, r.pro_alambre,
                                             r.pro_fundente, r.pro_ordentrabajo, r.pro_especificacion);
                CmbProyecto.Items.Add(r.pro_id.ToString() + "-" + r.pro_ordentrabajo.ToString());

            }
        }

        private void Busqueda_maquinas(string No_tubo, string ID_proyecto)
        {
          
            string url_api;

            string data_tubo;
            
            for (int i = 1; i < 4; i++)
            {
                url_api =P_url_apis + $"ar_tTuberiaInterna_{i}.php?T_No_tubo={No_tubo}&T_ID_proyecto={ID_proyecto}";
                data_tubo = Consultas.Get_API(url_api);
                if (data_tubo != "null")
                {
                    List<Tuberia_interna_tabla> temporal_results = JsonConvert.DeserializeObject<List<Tuberia_interna_tabla>>(data_tubo);
                    foreach (var r in temporal_results)
                    {
                        P_Tuberia_datatable.Rows.Add("INTERNA" + i, r.T_No_tubo, r.T_No_placa, r.T_ID_proyecto, r.T_Fecha, r.T_Hora,
                           r.T_Archivos_excel, r.T_Reporte_excel, r.T_Lote_alambre, r.T_Lote_fundente, r.T_Foliooperador, r.T_Hora_db,
                           r.T_Observaciones, r.T_ID_Rtubo);
                    }

                }
            }

            for (int i = 1; i < 4; i++)
            {
                url_api = P_url_apis + $"ar_tTuberiaExterna_{i}.php?T_No_tubo={No_tubo}&T_ID_proyecto={ID_proyecto}";
                data_tubo = Consultas.Get_API(url_api);
                if (data_tubo != "null")
                {
                    List<Tuberia_interna_tabla> temporal_results = JsonConvert.DeserializeObject<List<Tuberia_interna_tabla>>(data_tubo);
                    foreach (var r in temporal_results)
                    {
                        P_Tuberia_datatable.Rows.Add("EXTERNA" + i,r.T_No_tubo, r.T_No_placa, r.T_ID_proyecto, r.T_Fecha, r.T_Hora,
                           r.T_Archivos_excel, r.T_Reporte_excel, r.T_Lote_alambre, r.T_Lote_fundente, r.T_Foliooperador, r.T_Hora_db, 
                           r.T_Observaciones, r.T_ID_Rtubo);
                    }

                }
            }


        }

        private void Busqueda_registros(string maquina, string ID_registro)
        {
            string url_api, url_api_ra;
            int po = maquina.IndexOf("T");
            string soldadura = maquina.Substring(0,po);
            po = maquina.IndexOf("A");
            string no_maquina = maquina.Substring(po + 1);
            string ID_registro_ra = (Convert.ToInt32(ID_registro)-1).ToString();
            P_Tuberia_datatable.Clear();
            P_ATuberia_datatable.Clear();

            if (soldadura == "IN")
            {
                url_api = P_url_apis + $"ar_tTuberiaInterna_{no_maquina}.php?T_ID_Rtubo={ID_registro}";
                url_api_ra = P_url_apis + $"ar_tTuberiaInterna_{no_maquina}.php?T_ID_Rtubo={ID_registro_ra}";
            }
            else
            {
                url_api = P_url_apis + $"ar_tTuberiaExterna_{no_maquina}.php?T_ID_Rtubo={ID_registro}";
                url_api_ra = P_url_apis + $"ar_tTuberiaExterna_{no_maquina}.php?T_ID_Rtubo={ID_registro_ra}";
            }
            
            string  data_registro = Consultas.Get_API(url_api);
            if (data_registro != "null")
            {
                List<Tabla_exin> temporal_results = JsonConvert.DeserializeObject<List<Tabla_exin>>(data_registro);
                foreach (var r in temporal_results)
                {
                    LblRBIDregistro.Text = r.T_ID_Rtubo;
                    LblRBNotubo.Text = r.T_No_tubo;
                    LblRBFecha.Text = r.T_Fecha;
                    LblRBHora.Text = r.T_Hora;
                    LblRBMaquina.Text = maquina;
                    P_Tuberia_datatable.Rows.Add(maquina, r.T_No_tubo, r.T_No_placa, r.T_ID_proyecto, r.T_Fecha, r.T_Hora,
                           r.T_Archivos_excel, r.T_Reporte_excel, r.T_Lote_alambre, r.T_Lote_fundente, r.T_Foliooperador, r.T_Hora_db,
                           r.T_Observaciones, r.T_ID_Rtubo);
                }

            }

            data_registro = "";

            data_registro = Consultas.Get_API(url_api_ra);
            if (data_registro != "null")
            {
                List<Tabla_exin> temporal_results = JsonConvert.DeserializeObject<List<Tabla_exin>>(data_registro);
                foreach (var r in temporal_results)
                {
                    LblRAIDregistro.Text = r.T_ID_Rtubo;
                    LblRANotubo.Text = r.T_No_tubo;
                    LblRAFecha.Text = r.T_Fecha;
                    LblRAHora.Text = r.T_Hora;
                    LblRAMaquina.Text = maquina;
                    P_ATuberia_datatable.Rows.Add(maquina, r.T_No_tubo, r.T_No_placa, r.T_ID_proyecto, r.T_Fecha, r.T_Hora,
                           r.T_Archivos_excel, r.T_Reporte_excel, r.T_Lote_alambre, r.T_Lote_fundente, r.T_Foliooperador, r.T_Hora_db,
                           r.T_Observaciones, r.T_ID_Rtubo);
                }

            }
        }
        void Iniciar_tabla_tuberia()
        {
            
            //P_Tuberia_datatable.Columns.Add("T_id_tubo");
            P_Tuberia_datatable.Columns.Add("T_Maquina");
            P_Tuberia_datatable.Columns.Add("T_no_tubo");
            P_Tuberia_datatable.Columns.Add("T_no_placa");
            P_Tuberia_datatable.Columns.Add("T_ID_proyecto");
            P_Tuberia_datatable.Columns.Add("T_fecha");
            P_Tuberia_datatable.Columns.Add("T_hora");
            P_Tuberia_datatable.Columns.Add("T_Archivos_excel");
            P_Tuberia_datatable.Columns.Add("T_Reporte_excel");
            P_Tuberia_datatable.Columns.Add("T_lote_alambre");
            P_Tuberia_datatable.Columns.Add("T_lote_fundente");
            P_Tuberia_datatable.Columns.Add("T_foliooperador");
            P_Tuberia_datatable.Columns.Add("T_hora_db");
            P_Tuberia_datatable.Columns.Add("T_Observaciones");
            P_Tuberia_datatable.Columns.Add("T_id_Rtubo");
            
        }

        void Iniciar_tabla_registro_anterior()
        {

            //P_Tuberia_datatable.Columns.Add("T_id_tubo");
            P_ATuberia_datatable.Columns.Add("T_Maquina");
            P_ATuberia_datatable.Columns.Add("T_no_tubo");
            P_ATuberia_datatable.Columns.Add("T_no_placa");
            P_ATuberia_datatable.Columns.Add("T_ID_proyecto");
            P_ATuberia_datatable.Columns.Add("T_fecha");
            P_ATuberia_datatable.Columns.Add("T_hora");
            P_ATuberia_datatable.Columns.Add("T_Archivos_excel");
            P_ATuberia_datatable.Columns.Add("T_Reporte_excel");
            P_ATuberia_datatable.Columns.Add("T_lote_alambre");
            P_ATuberia_datatable.Columns.Add("T_lote_fundente");
            P_ATuberia_datatable.Columns.Add("T_foliooperador");
            P_ATuberia_datatable.Columns.Add("T_hora_db");
            P_ATuberia_datatable.Columns.Add("T_Observaciones");
            P_ATuberia_datatable.Columns.Add("T_id_Rtubo");

        }
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            Limpiar_objetos();
            btnCrearReporte.Enabled = false;
            if (txbNoTubo.Text != "" && CmbProyecto.Text != "")
            {
                dgvTuboBuscado.DataSource = null;
                //P_Tuberia_datatable.DefaultView.RowFilter = "T_no_tubo NOT IN (.)";
                //P_Tuberia_datatable.Rows.Clear();
                dgvTuboBuscado.DataSource = P_Tuberia_datatable;

                int po =CmbProyecto.Text.IndexOf("-");
                string ID_proyecto = CmbProyecto.Text.Substring(0, po);

                Busqueda_maquinas(txbNoTubo.Text,ID_proyecto);
                dgvTuboBuscado.DataSource = P_Tuberia_datatable;
            }
           
        }

        void Buscar_archivos_excel(string path_archivos, string fecha_b,string fecha_a)
        {
            LtbArchivosExcel.Items.Clear();

            try
            {

                DirectoryInfo di = new DirectoryInfo(path_archivos);
                string fechabuscada;

                if (fecha_a != fecha_b)
                {
                    fechabuscada = "*" + fecha_a + "*?.xlsx";

                    foreach (var fi in di.GetFiles(fechabuscada))
                    {

                        if (fi.Length > 65000)
                        {
                            LtbArchivosExcel.Items.Add(fi.Name);

                        }

                    }

                }

                fechabuscada = "*" + fecha_b + "*?.xlsx";

                foreach (var fi in di.GetFiles(fechabuscada))
                {

                    if (fi.Length > 65000)
                    {
                        LtbArchivosExcel.Items.Add(fi.Name);
                        
                    }

                }

                
            }
            catch (Exception e)
            {
                MessageBox.Show("error busqueda de archivos excel:" + e.ToString());
            }

        }
       
        public void guardar_archivos_excel_tubo(string hi, string hf, string carpeta, string mq)
        {
            
            DateTime horainicial_datetime = Convert.ToDateTime(hi);
            DateTime horafinal_datetime = Convert.ToDateTime(hf);
            //string hora_filtro = horafinal_datetime.ToString("hh:mm:ss tt");
            string nombre_archivo, s_temporal_string = "";
            int j = 0;
            

            for (int i = 0; i < LtbArchivosExcel.Items.Count; i++)
            {
                nombre_archivo = LtbArchivosExcel.Items[i].ToString();
                var archivo_encontrado = new FileInfo(pathP + carpeta + "/" + nombre_archivo);
                DateTime hora_archivo_encontrado = archivo_encontrado.LastWriteTime;

                //DateTime temporal_time = File.GetCreationTime(pathP + cm + "/" + nombre_archivo);
                if (horainicial_datetime <= hora_archivo_encontrado && hora_archivo_encontrado <= horafinal_datetime)
                {

                    s_temporal_string = s_temporal_string + nombre_archivo + ",";
                    j += 1;

                }
            }
            s_temporal_string = j.ToString() + "," + s_temporal_string;
            LblArchivosExcel.Text= s_temporal_string;
            
            Actualizar_Archivos_excel(Url_api_Maquina(mq), s_temporal_string);
            
            //return horafinal_datetime;
        }
        public void Actualizar_Archivos_excel(string url, string archivos_excel)
        {
            string id_Rtubo = dgvTuboBuscado.Rows[0].Cells[13].Value.ToString();

            try
            {
                Dictionary<string, string> diccionario_archivos_excel = new Dictionary<string, string>
                {
                    {"T_ID_Rtubo", id_Rtubo },
                    {"T_Archivos_excel", archivos_excel},
                };

                var json = JObject.FromObject(diccionario_archivos_excel);
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                var response = Consultas.Update_API(url, content);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }

        

        public void Limpiar_objetos()
        {
            P_proyecto_datatable.Clear();
            Rellenar_tabla_proyectos();
            P_Tuberia_datatable.Clear();
            P_ATuberia_datatable.Clear();
            dgvTuboBuscado.DataSource = P_Tuberia_datatable;
            LtbArchivosExcel.Items.Clear();
            LtbTemporal.Items.Clear();
            LblRAFecha.Text = "-----";
            LblRAHora.Text = "-----";
            LblRAIDregistro.Text = "-----";
            LblRAMaquina.Text = "-----";
            LblRANotubo.Text = "-----";
            LblRBFecha.Text = "-----";
            LblRBHora.Text = "-----";
            LblRBIDregistro.Text = "-----";
            LblRBMaquina.Text = "-----";
            LblRBNotubo.Text = "-----";
            LblArchivosExcel.Text = "_____________";
        }
        public string Url_api_Maquina(string maquina)
        {
            int po = maquina.IndexOf("T");
            string soldadura = maquina.Substring(0, po);
            po = maquina.IndexOf("A");
            string no_maquina = maquina.Substring(po + 1);

            string url;

            if (soldadura == "IN")
            {
                url = P_url_apis + $"ar_tTuberiaInterna_{no_maquina}.php";
            }
            else
            {
                url = P_url_apis + $"ar_tTuberiaExterna_{no_maquina}.php";
            }
            return url;
        }

        private void dgvTuboBuscado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            1. mostrar en las labels los datos del registro(rb) selecionado
            2. mostrar en las labels los datos del registro anterior(ra) al seleccionado
            3. buscar los archivos excel generados por el GM10 correspondientes a la fecha del 
               registro seleccionado
            4. buscar los archivos dentro de las horas de los registros (hora inicial(ra) y
               hora final(rb))
            5.- mostrarlos en un label para que los vea el usuario
            */
            if (dgvTuboBuscado.Rows.Count != 0)
            {
                string ID_registro = dgvTuboBuscado.CurrentRow.Cells[13].Value.ToString();
                string maquina = dgvTuboBuscado.CurrentRow.Cells[0].Value.ToString();

                string fecha_db_b_string = dgvTuboBuscado.CurrentRow.Cells[11].Value.ToString();
                DateTime fecha_db_datetime = Convert.ToDateTime(fecha_db_b_string);
                fecha_db_b_string = fecha_db_datetime.ToString("yyyyMMdd");
                
                Busqueda_registros(maquina, ID_registro);

                string fecha_db_a_string = P_ATuberia_datatable.Rows[0]["T_hora_db"].ToString();
                DateTime fecha_db_a_datetime = Convert.ToDateTime(fecha_db_a_string);
                fecha_db_a_string = fecha_db_a_datetime.ToString("yyyyMMdd");

                string carpeta = "MONITOREO_" + LblRBMaquina.Text;
                Buscar_archivos_excel(pathP + carpeta, fecha_db_b_string, fecha_db_a_string);
                string fecha_inicial = fecha_db_a_datetime.ToString("yyyy/MM/dd") + " " + LblRAHora.Text;
                string fecha_final = fecha_db_datetime.ToString("yyyy/MM/dd") + " " + LblRBHora.Text;
                guardar_archivos_excel_tubo(fecha_inicial, fecha_final, carpeta, maquina);
                btnCrearReporte.Enabled=true;
            }
            
        }

        private void dgvTuboBuscado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        void Rellenar_tabla_proyectos(string ID_proyecto)
        {
            string url_proyecto = "http://10.10.20.15/backend/api/ar_tProyectos.php?Pro_ID=" + ID_proyecto;
            var resultado_proyecto = Consultas.Get_API(url_proyecto);
            List<Proyecto_tabla> temporal_results = JsonConvert.DeserializeObject<List<Proyecto_tabla>>(resultado_proyecto);
            foreach (var r in temporal_results)
            {
                P_proyecto_datatable.Rows.Add(r.pro_id, r.pro_nombre, r.pro_diametro, r.pro_espesor, r.pro_alambre,
                                             r.pro_fundente, r.pro_ordentrabajo, r.pro_especificacion);

            }
        }

        void Rellenar_tabla_operador(string folio_operador)
        {
            string url_operador = "http://10.10.20.15/backend/api/ar_tOperadores.php?Op_Folio=" + folio_operador;
            var resultado_operador = Consultas.Get_API(url_operador);

            List<Operadores_tabla> temporal_resultado = JsonConvert.DeserializeObject<List<Operadores_tabla>>(resultado_operador);
            foreach (var r in temporal_resultado)
            {
                P_operador_datatable.Rows.Add(r.op_folio, r.op_nombre, r.op_clave_soldador, r.op_puesto);

            }
        }

        void Actualizar_Reporte_excel(string nombre_reporte, string maquina_reporte, string ID_proyecto)
        {
            string id_Rtubo = P_Tuberia_datatable.Rows[0]["T_id_Rtubo"].ToString();

            Dictionary<string, string> diccionario_update_reporte = new Dictionary<string, string>
                {
                    {"T_ID_Rtubo", id_Rtubo },
                    {"T_Reporte_excel", nombre_reporte+".xlsx"}
                    //{"T_ID_proyecto",ID_proyecto}
                };

            //var content = new FormUrlEncodedContent(diccionario);
            var json = JObject.FromObject(diccionario_update_reporte);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            string url_update = Url_api_Maquina(maquina_reporte);
            
            Consultas.Update_API(url_update, content);
        }

        void Crear_excel_rutina()
        {
            PtbExcel.Image = Properties.Resources.RedLED;
            btnBusqueda.Enabled = false;
            btnCrearReporte.Enabled= false;
            //string exin_excel=dgvDatosTabla.Rows[0].Cells[6].Value.ToString().Substring(0,2);
            string maquina_reporte = LblRBMaquina.Text;
            LtbTemporal.Items.Clear();
            string S01 = LblArchivosExcel.Text;
            char[] delimit = new char[] { ',' };
            int i01 = S01.IndexOf(","), j = 0;
            string S02 = S01.Remove(i01, (S01.Length - i01));
            LtbTemporal.Items.Add(S02);
            int numero_archivos = Int32.Parse(S02);
            if (numero_archivos == 0)
            {
                return;
            }
            string[] array_string = new string[numero_archivos + 1];
            //separar los nombres de los archivos excel
            foreach (string substr in S01.Split(delimit))
            {
                LtbTemporal.Items.Add(substr);

                if (j < (numero_archivos + 1))
                {
                    array_string[j] = substr;
                    j += 1;
                }

            }

            try
            {
                //abrir archivos excel
                //crear archivo excel para reporte
                string path_temporal = pathP + "MONITOREO_" + LblRBMaquina.Text + "\\";
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

                //empieza creacion de reporte 
                //solicitar datos del proyecto
                P_proyecto_datatable.Clear();
                int po = CmbProyecto.Text.IndexOf("-");
                string ID_proyecto = CmbProyecto.Text.Substring(0, po);
                Rellenar_tabla_proyectos(ID_proyecto);
                
                P_operador_datatable.Clear();
                Rellenar_tabla_operador(P_Tuberia_datatable.Rows[0]["T_folioOperador"].ToString());
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
                rt_sheet.Range["P5"].Value = P_Tuberia_datatable.Rows[0]["T_fecha"].ToString();
                rt_sheet.Range["P5"].Font.Bold = true;
                rt_sheet.Range["O6"].Value = "HORA:";
                rt_sheet.Range["P6"].Value = P_Tuberia_datatable.Rows[0]["T_hora"].ToString();
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
                string tubo_nr = LblRBNotubo.Text;
                rt_sheet.Range["I6"].Value = tubo_nr;
                rt_sheet.Range["I6"].Font.Bold = true;
                rt_sheet.Range["G7"].Value = "No. PLACA:";
                string placa_nr = P_Tuberia_datatable.Rows[0]["T_no_placa"].ToString();
                rt_sheet.Range["I7"].Value = placa_nr;
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
                rt_sheet.Range["F10"].Value = P_Tuberia_datatable.Rows[0]["T_lote_alambre"].ToString();
                rt_sheet.Range["F10"].Font.Bold = true;
                rt_sheet.Range["I10"].Value = "FUNDENTE:";
                rt_sheet.Range["K10"].Value = P_proyecto_datatable.Rows[0]["Fundente"].ToString();
                rt_sheet.Range["K10"].Font.Bold = true;
                rt_sheet.Range["M10"].Value = "LOTE:";
                rt_sheet.Range["N10"].Value = P_Tuberia_datatable.Rows[0]["T_lote_fundente"].ToString();
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
                rt_sheet.Range["L14"].Value = P_operador_datatable.Rows[0]["Clave_soldador"];
                rt_sheet.Range["L14"].Font.Bold = true;
                rt_sheet.Range["A15"].Value = "SUPERVISOR";
                rt_sheet.Range["C15"].Value = "sin datos";
                rt_sheet.Range["C15"].Font.Bold = true;
                rt_sheet.Range["H15"].Value = "FOLIO";
                rt_sheet.Range["I15"].Value = "sin datos";
                rt_sheet.Range["I15"].Font.Bold = true;
                rt_sheet.Range["A16"].Value = "OBSERVACIONES";
                rt_sheet.Range["C16"].Value = P_Tuberia_datatable.Rows[0]["T_observaciones"].ToString();
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
                rt_s_tablas.Range["K2"].Value = P_Tuberia_datatable.Rows[0]["T_hora"].ToString();
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

                
                for (int i = 1; i < array_string.Length; i++)
                {
                    try
                    {
                        path_archivos_excel = path_temporal + array_string[i];
                        //Abrir archivo de datos de soldadura
                        ae_book = archivo_excel.Workbooks.Open(path_archivos_excel);
                        Excel.Worksheet ae_sheet = (Excel.Worksheet)ae_book.Worksheets.Item[1];
                        r = ae_sheet.UsedRange.Rows.Count;
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
                    rt_sheet.Range["F20"].Value = "A";
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
                    rt_sheet.Range["J20"].Value = "A";




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
                    chartpage.HasLegend = false;
                    chartpage.HasTitle = false;

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
                    chartpage.HasLegend = false;
                    chartpage.HasTitle = false;

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
                    chartpage.HasLegend = false;
                    chartpage.HasTitle = false;

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
                    chartpage.HasLegend = false;
                    chartpage.HasTitle = false;

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
                    chartpage.HasLegend = false;
                    chartpage.HasTitle = false;

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
                    chartpage.HasLegend = false;
                    chartpage.HasTitle = false;

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
                    chartpage.HasLegend = false;
                    chartpage.HasTitle = false;

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
                    chartpage.HasLegend = false;
                    chartpage.HasTitle = false;

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
                    chartpage.HasLegend = false;
                    chartpage.HasTitle = false;

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
                        chartpage.HasLegend = false;
                        chartpage.HasTitle = false;

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
                        chartpage.HasLegend = false;
                        chartpage.HasTitle = false;

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
                        chartpage.HasLegend = false;
                        chartpage.HasTitle = false;

                    }


                    //guardar excel del reporte 
                    string[] charsToRemove = new string[] { "/" };
                    string fecha = P_Tuberia_datatable.Rows[0]["T_fecha"].ToString();
                    string id_rtubo = P_Tuberia_datatable.Rows[0]["T_id_Rtubo"].ToString(); ;
                    foreach (var c in charsToRemove)
                    {
                        fecha = fecha.Replace(c, string.Empty);
                    }
                    //NOMBRE PARA EL ARCHIVO DEL REPORTE
                    //R_IDP-(ID_PROYECTO)_IDT-(ID_TUBO)_f-(FECHA)
                    ID_proyecto = P_proyecto_datatable.Rows[0]["ID"].ToString();
                    string nombre_reporte = "Tubo_" + tubo_nr + "_" + maquina_reporte + "_F_" + fecha + "_NR" + id_rtubo;
                    string pat = path_reportes_excel + maquina_reporte + "\\" + nombre_reporte + ".xlsx";
                    rt_book.SaveAs(pat, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, Excel.XlSaveAsAccessMode.xlNoChange,
                                    oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                    rt_book.Close(true, oMissiong, oMissiong);
                    reporte_tuberia.Workbooks.Close();
                    reporte_tuberia.Quit();


                    Actualizar_Reporte_excel(nombre_reporte, maquina_reporte, ID_proyecto);
                    PtbExcel.Image = Properties.Resources.GrayLED;
                    btnBusqueda.Enabled = true;
                    btnCrearReporte.Enabled = true;
                    //GC.Collect();
                    //GC.WaitForPendingFinalizers();
                    //habilitar botones


                }
                catch (Exception e)
                {
                    
                    MessageBox.Show("TABLA EXCEL ERROR: " + e.ToString());
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Crear excel: " + e.ToString());
                Iniciar_tabla_tuberia();
                Iniciar_tabla_operador();
                Iniciar_tabla_proyecto();


            }


        }

        private void btnCrearReporte_Click(object sender, EventArgs e)
        {
            Crear_excel_rutina();
        }

        private void btnArchivosPH_Click(object sender, EventArgs e)
        {
            AgregarArchivosdld_PH();
        }

        public void AgregarArchivosdld_PH()
        {
            bool status;

            string fecha_busqueda = DpkFechaArchivos.Value.ToString("yyyyMMdd");

            status = ArchivosPH_.AgregarArchivosdld_PH(fecha_busqueda);

            if (status) 
                LblDisplay1.Text = "Se encontraron archivos";
            else 
                LblDisplay1.Text = "No se encontraron archivos";
  
        }
       
        
    }
}
