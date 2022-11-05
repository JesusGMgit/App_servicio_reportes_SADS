
namespace app_servicio_SADS2
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnIniciarAuto = new System.Windows.Forms.Button();
            this.btnModoManual = new System.Windows.Forms.Button();
            this.gpbModo = new System.Windows.Forms.GroupBox();
            this.ptbIndicadorA = new System.Windows.Forms.PictureBox();
            this.btnAjustes = new System.Windows.Forms.Button();
            this.ptbIndicador2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPararAuto = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.iglImagenes = new System.Windows.Forms.ImageList(this.components);
            this.lblTemporal2 = new System.Windows.Forms.Label();
            this.dgvDatosTabla = new System.Windows.Forms.DataGridView();
            this.ltbArchivosExcel = new System.Windows.Forms.ListBox();
            this.gpbModoManual = new System.Windows.Forms.GroupBox();
            this.btnReportesDia = new System.Windows.Forms.Button();
            this.ckbExcel = new System.Windows.Forms.CheckBox();
            this.btnCrearExcel = new System.Windows.Forms.Button();
            this.cmbManualMaquina = new System.Windows.Forms.ComboBox();
            this.cmbManualSoldadura = new System.Windows.Forms.ComboBox();
            this.rdbHorafinal = new System.Windows.Forms.RadioButton();
            this.rdbHorainicial = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lable1 = new System.Windows.Forms.Label();
            this.txbManualFecha = new System.Windows.Forms.TextBox();
            this.btnGuardarExcel = new System.Windows.Forms.Button();
            this.btnBusquedaFecha = new System.Windows.Forms.Button();
            this.txbManualHoraFinal = new System.Windows.Forms.TextBox();
            this.txbManualHoraInicial = new System.Windows.Forms.TextBox();
            this.stsEstado = new System.Windows.Forms.StatusStrip();
            this.tssLEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLMinutosMon = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLNumeroArchivos = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLCarpeta = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTemporal = new System.Windows.Forms.Label();
            this.ltbTemporal = new System.Windows.Forms.ListBox();
            this.dgvTablaExcel = new System.Windows.Forms.DataGridView();
            this.ltbTemporal2 = new System.Windows.Forms.ListBox();
            this.tmrMonitoreo = new System.Windows.Forms.Timer(this.components);
            this.ptbIndicador1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gpbModo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIndicadorA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIndicador2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosTabla)).BeginInit();
            this.gpbModoManual.SuspendLayout();
            this.stsEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIndicador1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIniciarAuto
            // 
            this.btnIniciarAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarAuto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciarAuto.ImageIndex = 15;
            this.btnIniciarAuto.Location = new System.Drawing.Point(17, 61);
            this.btnIniciarAuto.Name = "btnIniciarAuto";
            this.btnIniciarAuto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnIniciarAuto.Size = new System.Drawing.Size(126, 41);
            this.btnIniciarAuto.TabIndex = 0;
            this.btnIniciarAuto.Text = "INICIAR";
            this.btnIniciarAuto.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnIniciarAuto.UseVisualStyleBackColor = true;
            this.btnIniciarAuto.Click += new System.EventHandler(this.btnIniciarAuto_Click);
            // 
            // btnModoManual
            // 
            this.btnModoManual.Location = new System.Drawing.Point(201, 61);
            this.btnModoManual.Name = "btnModoManual";
            this.btnModoManual.Size = new System.Drawing.Size(126, 41);
            this.btnModoManual.TabIndex = 1;
            this.btnModoManual.Text = "ABRIR";
            this.btnModoManual.UseVisualStyleBackColor = true;
            this.btnModoManual.Click += new System.EventHandler(this.button2_Click);
            // 
            // gpbModo
            // 
            this.gpbModo.BackColor = System.Drawing.Color.Transparent;
            this.gpbModo.Controls.Add(this.ptbIndicadorA);
            this.gpbModo.Controls.Add(this.btnAjustes);
            this.gpbModo.Controls.Add(this.ptbIndicador2);
            this.gpbModo.Controls.Add(this.label3);
            this.gpbModo.Controls.Add(this.label2);
            this.gpbModo.Controls.Add(this.btnPararAuto);
            this.gpbModo.Controls.Add(this.btnIniciarAuto);
            this.gpbModo.Controls.Add(this.btnModoManual);
            this.gpbModo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbModo.Location = new System.Drawing.Point(14, 113);
            this.gpbModo.Name = "gpbModo";
            this.gpbModo.Size = new System.Drawing.Size(345, 166);
            this.gpbModo.TabIndex = 3;
            this.gpbModo.TabStop = false;
            this.gpbModo.Text = "MODO";
            // 
            // ptbIndicadorA
            // 
            this.ptbIndicadorA.Location = new System.Drawing.Point(70, 39);
            this.ptbIndicadorA.Name = "ptbIndicadorA";
            this.ptbIndicadorA.Size = new System.Drawing.Size(34, 16);
            this.ptbIndicadorA.TabIndex = 16;
            this.ptbIndicadorA.TabStop = false;
            // 
            // btnAjustes
            // 
            this.btnAjustes.Image = global::app_servicio_SADS2.Properties.Resources.icons8_ajustes_48;
            this.btnAjustes.Location = new System.Drawing.Point(275, 108);
            this.btnAjustes.Name = "btnAjustes";
            this.btnAjustes.Size = new System.Drawing.Size(52, 52);
            this.btnAjustes.TabIndex = 14;
            this.btnAjustes.UseVisualStyleBackColor = true;
            this.btnAjustes.Click += new System.EventHandler(this.btnAjustes_Click);
            // 
            // ptbIndicador2
            // 
            this.ptbIndicador2.Location = new System.Drawing.Point(201, 119);
            this.ptbIndicador2.Name = "ptbIndicador2";
            this.ptbIndicador2.Size = new System.Drawing.Size(39, 41);
            this.ptbIndicador2.TabIndex = 13;
            this.ptbIndicador2.TabStop = false;
            this.ptbIndicador2.Click += new System.EventHandler(this.ptbIndicador2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "MANUAL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "AUTOMATICO";
            // 
            // btnPararAuto
            // 
            this.btnPararAuto.Location = new System.Drawing.Point(17, 119);
            this.btnPararAuto.Name = "btnPararAuto";
            this.btnPararAuto.Size = new System.Drawing.Size(126, 41);
            this.btnPararAuto.TabIndex = 2;
            this.btnPararAuto.Text = "PARAR";
            this.btnPararAuto.UseVisualStyleBackColor = true;
            this.btnPararAuto.Click += new System.EventHandler(this.btnPararAuto_Click);
            // 
            // button1
            // 
            this.button1.ImageIndex = 7;
            this.button1.ImageList = this.iglImagenes;
            this.button1.Location = new System.Drawing.Point(809, 448);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 34);
            this.button1.TabIndex = 17;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // iglImagenes
            // 
            this.iglImagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iglImagenes.ImageStream")));
            this.iglImagenes.TransparentColor = System.Drawing.Color.Transparent;
            this.iglImagenes.Images.SetKeyName(0, "Bartkowalski-1960-Matchbox-Cars-Pipe-Truck.ico");
            this.iglImagenes.Images.SetKeyName(1, "excel.png");
            this.iglImagenes.Images.SetKeyName(2, "fenix.ico");
            this.iglImagenes.Images.SetKeyName(3, "icons8-ajustes-64.png");
            this.iglImagenes.Images.SetKeyName(4, "key.png");
            this.iglImagenes.Images.SetKeyName(5, "lock_lock_15063.ico");
            this.iglImagenes.Images.SetKeyName(6, "lock_unlock_15064.ico");
            this.iglImagenes.Images.SetKeyName(7, "report_add.png");
            this.iglImagenes.Images.SetKeyName(8, "reporte.ico");
            this.iglImagenes.Images.SetKeyName(9, "tubos2.ico");
            this.iglImagenes.Images.SetKeyName(10, "search_102938.ico");
            this.iglImagenes.Images.SetKeyName(11, "search_locate_find_13974.ico");
            this.iglImagenes.Images.SetKeyName(12, "disk.png");
            this.iglImagenes.Images.SetKeyName(13, "backupdatabase_5665.png");
            this.iglImagenes.Images.SetKeyName(14, "pngegg.png");
            this.iglImagenes.Images.SetKeyName(15, "actualizar-restaure.png");
            this.iglImagenes.Images.SetKeyName(16, "GrayLED.bmp");
            this.iglImagenes.Images.SetKeyName(17, "RedLED.bmp");
            // 
            // lblTemporal2
            // 
            this.lblTemporal2.AutoSize = true;
            this.lblTemporal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemporal2.Location = new System.Drawing.Point(399, 148);
            this.lblTemporal2.Name = "lblTemporal2";
            this.lblTemporal2.Size = new System.Drawing.Size(35, 15);
            this.lblTemporal2.TabIndex = 15;
            this.lblTemporal2.Text = "xxxx";
            // 
            // dgvDatosTabla
            // 
            this.dgvDatosTabla.AllowUserToAddRows = false;
            this.dgvDatosTabla.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatosTabla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatosTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatosTabla.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatosTabla.Location = new System.Drawing.Point(391, 34);
            this.dgvDatosTabla.Name = "dgvDatosTabla";
            this.dgvDatosTabla.ReadOnly = true;
            this.dgvDatosTabla.Size = new System.Drawing.Size(456, 110);
            this.dgvDatosTabla.TabIndex = 5;
            this.dgvDatosTabla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosTabla_CellContentClick);
            // 
            // ltbArchivosExcel
            // 
            this.ltbArchivosExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltbArchivosExcel.FormattingEnabled = true;
            this.ltbArchivosExcel.HorizontalScrollbar = true;
            this.ltbArchivosExcel.ItemHeight = 16;
            this.ltbArchivosExcel.Location = new System.Drawing.Point(391, 294);
            this.ltbArchivosExcel.Name = "ltbArchivosExcel";
            this.ltbArchivosExcel.Size = new System.Drawing.Size(279, 148);
            this.ltbArchivosExcel.TabIndex = 6;
            // 
            // gpbModoManual
            // 
            this.gpbModoManual.BackColor = System.Drawing.Color.Transparent;
            this.gpbModoManual.Controls.Add(this.btnReportesDia);
            this.gpbModoManual.Controls.Add(this.ckbExcel);
            this.gpbModoManual.Controls.Add(this.btnCrearExcel);
            this.gpbModoManual.Controls.Add(this.cmbManualMaquina);
            this.gpbModoManual.Controls.Add(this.cmbManualSoldadura);
            this.gpbModoManual.Controls.Add(this.rdbHorafinal);
            this.gpbModoManual.Controls.Add(this.rdbHorainicial);
            this.gpbModoManual.Controls.Add(this.label7);
            this.gpbModoManual.Controls.Add(this.label6);
            this.gpbModoManual.Controls.Add(this.label5);
            this.gpbModoManual.Controls.Add(this.label4);
            this.gpbModoManual.Controls.Add(this.lable1);
            this.gpbModoManual.Controls.Add(this.txbManualFecha);
            this.gpbModoManual.Controls.Add(this.btnGuardarExcel);
            this.gpbModoManual.Controls.Add(this.btnBusquedaFecha);
            this.gpbModoManual.Controls.Add(this.txbManualHoraFinal);
            this.gpbModoManual.Controls.Add(this.txbManualHoraInicial);
            this.gpbModoManual.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbModoManual.Location = new System.Drawing.Point(14, 285);
            this.gpbModoManual.Name = "gpbModoManual";
            this.gpbModoManual.Size = new System.Drawing.Size(345, 191);
            this.gpbModoManual.TabIndex = 7;
            this.gpbModoManual.TabStop = false;
            // 
            // btnReportesDia
            // 
            this.btnReportesDia.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReportesDia.ImageIndex = 2;
            this.btnReportesDia.ImageList = this.iglImagenes;
            this.btnReportesDia.Location = new System.Drawing.Point(265, 135);
            this.btnReportesDia.Name = "btnReportesDia";
            this.btnReportesDia.Size = new System.Drawing.Size(70, 51);
            this.btnReportesDia.TabIndex = 16;
            this.btnReportesDia.Text = "R_DIA";
            this.btnReportesDia.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReportesDia.UseVisualStyleBackColor = true;
            this.btnReportesDia.Click += new System.EventHandler(this.btnReportesDia_Click);
            // 
            // ckbExcel
            // 
            this.ckbExcel.AutoSize = true;
            this.ckbExcel.Checked = true;
            this.ckbExcel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbExcel.Location = new System.Drawing.Point(164, 106);
            this.ckbExcel.Name = "ckbExcel";
            this.ckbExcel.Size = new System.Drawing.Size(73, 21);
            this.ckbExcel.TabIndex = 15;
            this.ckbExcel.Text = ".xlsx/.txt";
            this.ckbExcel.UseVisualStyleBackColor = true;
            // 
            // btnCrearExcel
            // 
            this.btnCrearExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrearExcel.ImageIndex = 1;
            this.btnCrearExcel.ImageList = this.iglImagenes;
            this.btnCrearExcel.Location = new System.Drawing.Point(164, 163);
            this.btnCrearExcel.Name = "btnCrearExcel";
            this.btnCrearExcel.Size = new System.Drawing.Size(92, 24);
            this.btnCrearExcel.TabIndex = 14;
            this.btnCrearExcel.Text = "EXCEL";
            this.btnCrearExcel.UseVisualStyleBackColor = true;
            this.btnCrearExcel.Click += new System.EventHandler(this.btnCrearExcel_Click);
            // 
            // cmbManualMaquina
            // 
            this.cmbManualMaquina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManualMaquina.FormattingEnabled = true;
            this.cmbManualMaquina.Location = new System.Drawing.Point(17, 86);
            this.cmbManualMaquina.Name = "cmbManualMaquina";
            this.cmbManualMaquina.Size = new System.Drawing.Size(127, 25);
            this.cmbManualMaquina.TabIndex = 1;
            this.cmbManualMaquina.SelectedIndexChanged += new System.EventHandler(this.cmbManualMaquina_SelectedIndexChanged);
            // 
            // cmbManualSoldadura
            // 
            this.cmbManualSoldadura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManualSoldadura.FormattingEnabled = true;
            this.cmbManualSoldadura.Location = new System.Drawing.Point(16, 38);
            this.cmbManualSoldadura.Name = "cmbManualSoldadura";
            this.cmbManualSoldadura.Size = new System.Drawing.Size(127, 25);
            this.cmbManualSoldadura.TabIndex = 0;
            this.cmbManualSoldadura.SelectedIndexChanged += new System.EventHandler(this.cmbManualSoldadura_SelectedIndexChanged);
            // 
            // rdbHorafinal
            // 
            this.rdbHorafinal.AutoSize = true;
            this.rdbHorafinal.Location = new System.Drawing.Point(301, 84);
            this.rdbHorafinal.Name = "rdbHorafinal";
            this.rdbHorafinal.Size = new System.Drawing.Size(14, 13);
            this.rdbHorafinal.TabIndex = 13;
            this.rdbHorafinal.UseVisualStyleBackColor = true;
            // 
            // rdbHorainicial
            // 
            this.rdbHorainicial.AutoSize = true;
            this.rdbHorainicial.Checked = true;
            this.rdbHorainicial.Location = new System.Drawing.Point(301, 44);
            this.rdbHorainicial.Name = "rdbHorainicial";
            this.rdbHorainicial.Size = new System.Drawing.Size(14, 13);
            this.rdbHorainicial.TabIndex = 12;
            this.rdbHorainicial.TabStop = true;
            this.rdbHorainicial.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(161, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Hora final: (hh:mm:ss pp)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(161, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Hora inicial: (hh:mm:ss pp)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha: (yyyy/MM/dd)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Maquina";
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(13, 17);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(68, 17);
            this.lable1.TabIndex = 7;
            this.lable1.Text = "Soldadura";
            // 
            // txbManualFecha
            // 
            this.txbManualFecha.Location = new System.Drawing.Point(17, 134);
            this.txbManualFecha.Name = "txbManualFecha";
            this.txbManualFecha.Size = new System.Drawing.Size(120, 25);
            this.txbManualFecha.TabIndex = 6;
            // 
            // btnGuardarExcel
            // 
            this.btnGuardarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarExcel.ImageIndex = 13;
            this.btnGuardarExcel.ImageList = this.iglImagenes;
            this.btnGuardarExcel.Location = new System.Drawing.Point(164, 133);
            this.btnGuardarExcel.Name = "btnGuardarExcel";
            this.btnGuardarExcel.Size = new System.Drawing.Size(92, 24);
            this.btnGuardarExcel.TabIndex = 5;
            this.btnGuardarExcel.Text = "GUARDAR";
            this.btnGuardarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarExcel.UseVisualStyleBackColor = true;
            this.btnGuardarExcel.Click += new System.EventHandler(this.btnGuardarExcel_Click);
            // 
            // btnBusquedaFecha
            // 
            this.btnBusquedaFecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBusquedaFecha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBusquedaFecha.ImageIndex = 10;
            this.btnBusquedaFecha.ImageList = this.iglImagenes;
            this.btnBusquedaFecha.Location = new System.Drawing.Point(20, 163);
            this.btnBusquedaFecha.Name = "btnBusquedaFecha";
            this.btnBusquedaFecha.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBusquedaFecha.Size = new System.Drawing.Size(92, 24);
            this.btnBusquedaFecha.TabIndex = 4;
            this.btnBusquedaFecha.Text = "BUSCAR";
            this.btnBusquedaFecha.UseVisualStyleBackColor = true;
            this.btnBusquedaFecha.Click += new System.EventHandler(this.btnBusquedaFecha_Click);
            // 
            // txbManualHoraFinal
            // 
            this.txbManualHoraFinal.Location = new System.Drawing.Point(164, 75);
            this.txbManualHoraFinal.Name = "txbManualHoraFinal";
            this.txbManualHoraFinal.Size = new System.Drawing.Size(120, 25);
            this.txbManualHoraFinal.TabIndex = 3;
            // 
            // txbManualHoraInicial
            // 
            this.txbManualHoraInicial.Location = new System.Drawing.Point(164, 36);
            this.txbManualHoraInicial.Name = "txbManualHoraInicial";
            this.txbManualHoraInicial.Size = new System.Drawing.Size(120, 25);
            this.txbManualHoraInicial.TabIndex = 2;
            this.txbManualHoraInicial.TextChanged += new System.EventHandler(this.txbManualHoraInicial_TextChanged);
            // 
            // stsEstado
            // 
            this.stsEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLEstado,
            this.tssLMinutosMon,
            this.tssLNumeroArchivos,
            this.tssLCarpeta});
            this.stsEstado.Location = new System.Drawing.Point(0, 485);
            this.stsEstado.Name = "stsEstado";
            this.stsEstado.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.stsEstado.Size = new System.Drawing.Size(859, 22);
            this.stsEstado.TabIndex = 8;
            this.stsEstado.Text = "En espera... ";
            // 
            // tssLEstado
            // 
            this.tssLEstado.Name = "tssLEstado";
            this.tssLEstado.Size = new System.Drawing.Size(63, 17);
            this.tssLEstado.Text = "En espera..";
            // 
            // tssLMinutosMon
            // 
            this.tssLMinutosMon.Name = "tssLMinutosMon";
            this.tssLMinutosMon.Size = new System.Drawing.Size(51, 17);
            this.tssLMinutosMon.Text = "minutos";
            // 
            // tssLNumeroArchivos
            // 
            this.tssLNumeroArchivos.Name = "tssLNumeroArchivos";
            this.tssLNumeroArchivos.Size = new System.Drawing.Size(48, 17);
            this.tssLNumeroArchivos.Text = "Archivo";
            // 
            // tssLCarpeta
            // 
            this.tssLCarpeta.Name = "tssLCarpeta";
            this.tssLCarpeta.Size = new System.Drawing.Size(48, 17);
            this.tssLCarpeta.Text = "Carpeta";
            // 
            // lblTemporal
            // 
            this.lblTemporal.AutoSize = true;
            this.lblTemporal.BackColor = System.Drawing.Color.Transparent;
            this.lblTemporal.Location = new System.Drawing.Point(399, 461);
            this.lblTemporal.Name = "lblTemporal";
            this.lblTemporal.Size = new System.Drawing.Size(39, 13);
            this.lblTemporal.TabIndex = 9;
            this.lblTemporal.Text = "datos..";
            // 
            // ltbTemporal
            // 
            this.ltbTemporal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltbTemporal.FormattingEnabled = true;
            this.ltbTemporal.HorizontalScrollbar = true;
            this.ltbTemporal.ItemHeight = 16;
            this.ltbTemporal.Location = new System.Drawing.Point(676, 294);
            this.ltbTemporal.Name = "ltbTemporal";
            this.ltbTemporal.Size = new System.Drawing.Size(171, 148);
            this.ltbTemporal.TabIndex = 10;
            // 
            // dgvTablaExcel
            // 
            this.dgvTablaExcel.AllowUserToAddRows = false;
            this.dgvTablaExcel.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTablaExcel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTablaExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTablaExcel.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTablaExcel.Location = new System.Drawing.Point(391, 169);
            this.dgvTablaExcel.Name = "dgvTablaExcel";
            this.dgvTablaExcel.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTablaExcel.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTablaExcel.Size = new System.Drawing.Size(279, 110);
            this.dgvTablaExcel.TabIndex = 11;
            // 
            // ltbTemporal2
            // 
            this.ltbTemporal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltbTemporal2.FormattingEnabled = true;
            this.ltbTemporal2.HorizontalScrollbar = true;
            this.ltbTemporal2.ItemHeight = 16;
            this.ltbTemporal2.Location = new System.Drawing.Point(676, 169);
            this.ltbTemporal2.Name = "ltbTemporal2";
            this.ltbTemporal2.Size = new System.Drawing.Size(171, 116);
            this.ltbTemporal2.TabIndex = 13;
            // 
            // tmrMonitoreo
            // 
            this.tmrMonitoreo.Interval = 1000;
            this.tmrMonitoreo.Tick += new System.EventHandler(this.tmrMonitoreo_Tick);
            // 
            // ptbIndicador1
            // 
            this.ptbIndicador1.Location = new System.Drawing.Point(782, 147);
            this.ptbIndicador1.Name = "ptbIndicador1";
            this.ptbIndicador1.Size = new System.Drawing.Size(34, 16);
            this.ptbIndicador1.TabIndex = 12;
            this.ptbIndicador1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::app_servicio_SADS2.Properties.Resources.logo_1;
            this.pictureBox1.Location = new System.Drawing.Point(27, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(310, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(859, 507);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTemporal2);
            this.Controls.Add(this.ltbTemporal2);
            this.Controls.Add(this.ptbIndicador1);
            this.Controls.Add(this.dgvTablaExcel);
            this.Controls.Add(this.ltbTemporal);
            this.Controls.Add(this.lblTemporal);
            this.Controls.Add(this.stsEstado);
            this.Controls.Add(this.gpbModoManual);
            this.Controls.Add(this.ltbArchivosExcel);
            this.Controls.Add(this.dgvDatosTabla);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gpbModo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Servicio de intergracion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.gpbModo.ResumeLayout(false);
            this.gpbModo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIndicadorA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIndicador2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosTabla)).EndInit();
            this.gpbModoManual.ResumeLayout(false);
            this.gpbModoManual.PerformLayout();
            this.stsEstado.ResumeLayout(false);
            this.stsEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIndicador1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciarAuto;
        private System.Windows.Forms.Button btnModoManual;
        private System.Windows.Forms.GroupBox gpbModo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPararAuto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvDatosTabla;
        private System.Windows.Forms.ListBox ltbArchivosExcel;
        private System.Windows.Forms.GroupBox gpbModoManual;
        private System.Windows.Forms.Button btnGuardarExcel;
        private System.Windows.Forms.Button btnBusquedaFecha;
        private System.Windows.Forms.TextBox txbManualHoraFinal;
        private System.Windows.Forms.TextBox txbManualHoraInicial;
        private System.Windows.Forms.ComboBox cmbManualMaquina;
        private System.Windows.Forms.ComboBox cmbManualSoldadura;
        private System.Windows.Forms.TextBox txbManualFecha;
        private System.Windows.Forms.StatusStrip stsEstado;
        private System.Windows.Forms.ToolStripStatusLabel tssLEstado;
        private System.Windows.Forms.Label lblTemporal;
        private System.Windows.Forms.ListBox ltbTemporal;
        private System.Windows.Forms.ToolStripStatusLabel tssLMinutosMon;
        private System.Windows.Forms.ToolStripStatusLabel tssLNumeroArchivos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.RadioButton rdbHorafinal;
        private System.Windows.Forms.RadioButton rdbHorainicial;
        private System.Windows.Forms.ImageList iglImagenes;
        private System.Windows.Forms.Button btnCrearExcel;
        private System.Windows.Forms.DataGridView dgvTablaExcel;
        private System.Windows.Forms.PictureBox ptbIndicador1;
        private System.Windows.Forms.ListBox ltbTemporal2;
        private System.Windows.Forms.Timer tmrMonitoreo;
        private System.Windows.Forms.PictureBox ptbIndicador2;
        private System.Windows.Forms.Button btnAjustes;
        private System.Windows.Forms.ToolStripStatusLabel tssLCarpeta;
        private System.Windows.Forms.Label lblTemporal2;
        private System.Windows.Forms.PictureBox ptbIndicadorA;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ckbExcel;
        private System.Windows.Forms.Button btnReportesDia;
    }
}

