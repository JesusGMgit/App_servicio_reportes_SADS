
namespace app_servicio_SADS2
{
    partial class pruebas_archivos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCambiarExtension = new System.Windows.Forms.Button();
            this.ltbArchivos = new System.Windows.Forms.ListBox();
            this.txbDatosArchivo = new System.Windows.Forms.TextBox();
            this.btnChecarArchivo = new System.Windows.Forms.Button();
            this.txbFecha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblArchivotxt = new System.Windows.Forms.Label();
            this.lblDirectorio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCambiarExtension
            // 
            this.btnCambiarExtension.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarExtension.Location = new System.Drawing.Point(12, 399);
            this.btnCambiarExtension.Name = "btnCambiarExtension";
            this.btnCambiarExtension.Size = new System.Drawing.Size(161, 38);
            this.btnCambiarExtension.TabIndex = 0;
            this.btnCambiarExtension.Text = "CAMBIAR EXTENSION";
            this.btnCambiarExtension.UseVisualStyleBackColor = true;
            this.btnCambiarExtension.Click += new System.EventHandler(this.btnCambiarExtension_Click);
            // 
            // ltbArchivos
            // 
            this.ltbArchivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltbArchivos.FormattingEnabled = true;
            this.ltbArchivos.ItemHeight = 16;
            this.ltbArchivos.Location = new System.Drawing.Point(16, 33);
            this.ltbArchivos.Name = "ltbArchivos";
            this.ltbArchivos.Size = new System.Drawing.Size(230, 228);
            this.ltbArchivos.TabIndex = 1;
            this.ltbArchivos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ltbArchivos_MouseClick);
            this.ltbArchivos.SelectedIndexChanged += new System.EventHandler(this.ltbArchivos_SelectedIndexChanged);
            // 
            // txbDatosArchivo
            // 
            this.txbDatosArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDatosArchivo.Location = new System.Drawing.Point(273, 33);
            this.txbDatosArchivo.Multiline = true;
            this.txbDatosArchivo.Name = "txbDatosArchivo";
            this.txbDatosArchivo.Size = new System.Drawing.Size(515, 238);
            this.txbDatosArchivo.TabIndex = 2;
            // 
            // btnChecarArchivo
            // 
            this.btnChecarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChecarArchivo.Location = new System.Drawing.Point(12, 319);
            this.btnChecarArchivo.Name = "btnChecarArchivo";
            this.btnChecarArchivo.Size = new System.Drawing.Size(161, 38);
            this.btnChecarArchivo.TabIndex = 3;
            this.btnChecarArchivo.Text = "CHECAR ARCHIVOS";
            this.btnChecarArchivo.UseVisualStyleBackColor = true;
            this.btnChecarArchivo.Click += new System.EventHandler(this.btnChecarArchivo_Click);
            // 
            // txbFecha
            // 
            this.txbFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFecha.Location = new System.Drawing.Point(60, 282);
            this.txbFecha.Name = "txbFecha";
            this.txbFecha.Size = new System.Drawing.Size(132, 22);
            this.txbFecha.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "FECHA:";
            // 
            // lblArchivotxt
            // 
            this.lblArchivotxt.AutoSize = true;
            this.lblArchivotxt.Location = new System.Drawing.Point(13, 371);
            this.lblArchivotxt.Name = "lblArchivotxt";
            this.lblArchivotxt.Size = new System.Drawing.Size(56, 13);
            this.lblArchivotxt.TabIndex = 6;
            this.lblArchivotxt.Text = "archivo.txt";
            // 
            // lblDirectorio
            // 
            this.lblDirectorio.AutoSize = true;
            this.lblDirectorio.Location = new System.Drawing.Point(258, 319);
            this.lblDirectorio.Name = "lblDirectorio";
            this.lblDirectorio.Size = new System.Drawing.Size(56, 13);
            this.lblDirectorio.TabIndex = 7;
            this.lblDirectorio.Text = "archivo.txt";
            // 
            // pruebas_archivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDirectorio);
            this.Controls.Add(this.lblArchivotxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbFecha);
            this.Controls.Add(this.btnChecarArchivo);
            this.Controls.Add(this.txbDatosArchivo);
            this.Controls.Add(this.ltbArchivos);
            this.Controls.Add(this.btnCambiarExtension);
            this.Name = "pruebas_archivos";
            this.Text = "pruebas_archivos";
            this.Load += new System.EventHandler(this.pruebas_archivos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCambiarExtension;
        private System.Windows.Forms.ListBox ltbArchivos;
        private System.Windows.Forms.TextBox txbDatosArchivo;
        private System.Windows.Forms.Button btnChecarArchivo;
        private System.Windows.Forms.TextBox txbFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblArchivotxt;
        private System.Windows.Forms.Label lblDirectorio;
    }
}