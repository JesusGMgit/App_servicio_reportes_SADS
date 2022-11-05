using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace app_servicio_SADS2
{
    public partial class pruebas_archivos : Form
    {
        public string P_path_archivos = @"C:\Users\Public\Documents\SMARTDAC+ Data Logging Software\Data\test_archivos";
        public pruebas_archivos()
        {
            InitializeComponent();
        }

        void Buscar_archivos_txt(string path_archivos,string fecha)
        {
            try
            {

                DirectoryInfo di = new DirectoryInfo(path_archivos);
                string fechabuscada = "*" + fecha + "*?.txt";
                foreach (var fi in di.GetFiles(fechabuscada))
                {

                    
                        ltbArchivos.Items.Add(fi.Name);
                        //ltbArchivos.Items.Add(fi.LastWriteTime.ToString());
                        //ltbTemporal2.Items.Add(fi.Length.ToString());
                    

                }
            }
            catch (Exception e)
            {

                MessageBox.Show("error:" + e.ToString());
            }
        }
        private void btnCambiarExtension_Click(object sender, EventArgs e)
        {
            string path_archivo = P_path_archivos + "\\" + lblArchivotxt.Text;
            string path_archivo_nuevo = @"C:\xampp\htdocs\Reportes\EXTERNA2\" + lblArchivotxt.Text;
            File.Copy(path_archivo,path_archivo_nuevo); 
            File.Move(path_archivo_nuevo, Path.ChangeExtension(path_archivo, ".csv"));
            txbDatosArchivo.Text = lblArchivotxt.Text.Replace(".txt", ".csv");
            File.Delete(path_archivo_nuevo);
            //Fuente: https://www.iteramos.com/pregunta/32986/cambiar-la-extension-del-archivo-usando-c

        }

        private void btnChecarArchivo_Click(object sender, EventArgs e)
        {
            
            string fecha_achivos = txbFecha.Text.Replace("/", "");

            Buscar_archivos_txt(P_path_archivos, fecha_achivos);

        }

        private void ltbArchivos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ltbArchivos_MouseClick(object sender, MouseEventArgs e)
        {
            lblArchivotxt.Text = ltbArchivos.SelectedItem.ToString();
        }

        private void pruebas_archivos_Load(object sender, EventArgs e)
        {
            string directorio_resource = Directory.GetCurrentDirectory();
            lblDirectorio.Text = directorio_resource+ "\\logo-1.png";
            
        }
    }
}
