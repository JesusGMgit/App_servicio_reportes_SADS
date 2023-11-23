namespace app_servicio_SADS2
{
    partial class Busqueda_tubo
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
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbNoTubo = new System.Windows.Forms.TextBox();
            this.dgvTuboBuscado = new System.Windows.Forms.DataGridView();
            this.CmbProyecto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LtbArchivosExcel = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblRAMaquina = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblRAHora = new System.Windows.Forms.Label();
            this.LblRAFecha = new System.Windows.Forms.Label();
            this.LblRANotubo = new System.Windows.Forms.Label();
            this.LblRAIDregistro = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LblRBMaquina = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LblRBHora = new System.Windows.Forms.Label();
            this.LblRBFecha = new System.Windows.Forms.Label();
            this.LblRBNotubo = new System.Windows.Forms.Label();
            this.LblRBIDregistro = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblArchivosExcel = new System.Windows.Forms.Label();
            this.btnCrearReporte = new System.Windows.Forms.Button();
            this.LtbTemporal = new System.Windows.Forms.ListBox();
            this.PtbExcel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTuboBuscado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PtbExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusqueda.Location = new System.Drawing.Point(400, 26);
            this.btnBusqueda.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(188, 46);
            this.btnBusqueda.TabIndex = 0;
            this.btnBusqueda.Text = "BUSCAR";
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "No Tubo";
            // 
            // txbNoTubo
            // 
            this.txbNoTubo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNoTubo.Location = new System.Drawing.Point(46, 36);
            this.txbNoTubo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txbNoTubo.Name = "txbNoTubo";
            this.txbNoTubo.Size = new System.Drawing.Size(128, 26);
            this.txbNoTubo.TabIndex = 2;
            // 
            // dgvTuboBuscado
            // 
            this.dgvTuboBuscado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTuboBuscado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTuboBuscado.Location = new System.Drawing.Point(14, 99);
            this.dgvTuboBuscado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvTuboBuscado.Name = "dgvTuboBuscado";
            this.dgvTuboBuscado.Size = new System.Drawing.Size(788, 106);
            this.dgvTuboBuscado.TabIndex = 3;
            this.dgvTuboBuscado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTuboBuscado_CellContentClick);
            this.dgvTuboBuscado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTuboBuscado_CellDoubleClick);
            // 
            // CmbProyecto
            // 
            this.CmbProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProyecto.FormattingEnabled = true;
            this.CmbProyecto.Location = new System.Drawing.Point(202, 36);
            this.CmbProyecto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CmbProyecto.Name = "CmbProyecto";
            this.CmbProyecto.Size = new System.Drawing.Size(140, 28);
            this.CmbProyecto.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(197, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "OT proyecto";
            // 
            // LtbArchivosExcel
            // 
            this.LtbArchivosExcel.FormattingEnabled = true;
            this.LtbArchivosExcel.Location = new System.Drawing.Point(12, 223);
            this.LtbArchivosExcel.Name = "LtbArchivosExcel";
            this.LtbArchivosExcel.Size = new System.Drawing.Size(305, 95);
            this.LtbArchivosExcel.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "No Tubo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "ID registro:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 83);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fecha:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblRAMaquina);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.LblRAHora);
            this.groupBox1.Controls.Add(this.LblRAFecha);
            this.groupBox1.Controls.Add(this.LblRANotubo);
            this.groupBox1.Controls.Add(this.LblRAIDregistro);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 334);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 172);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro anterior";
            // 
            // LblRAMaquina
            // 
            this.LblRAMaquina.AutoSize = true;
            this.LblRAMaquina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRAMaquina.Location = new System.Drawing.Point(114, 149);
            this.LblRAMaquina.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRAMaquina.Name = "LblRAMaquina";
            this.LblRAMaquina.Size = new System.Drawing.Size(39, 20);
            this.LblRAMaquina.TabIndex = 17;
            this.LblRAMaquina.Text = "-----";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 149);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Maquina:";
            // 
            // LblRAHora
            // 
            this.LblRAHora.AutoSize = true;
            this.LblRAHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRAHora.Location = new System.Drawing.Point(114, 114);
            this.LblRAHora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRAHora.Name = "LblRAHora";
            this.LblRAHora.Size = new System.Drawing.Size(39, 20);
            this.LblRAHora.TabIndex = 15;
            this.LblRAHora.Text = "-----";
            // 
            // LblRAFecha
            // 
            this.LblRAFecha.AutoSize = true;
            this.LblRAFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRAFecha.Location = new System.Drawing.Point(114, 83);
            this.LblRAFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRAFecha.Name = "LblRAFecha";
            this.LblRAFecha.Size = new System.Drawing.Size(39, 20);
            this.LblRAFecha.TabIndex = 14;
            this.LblRAFecha.Text = "-----";
            // 
            // LblRANotubo
            // 
            this.LblRANotubo.AutoSize = true;
            this.LblRANotubo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRANotubo.Location = new System.Drawing.Point(114, 54);
            this.LblRANotubo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRANotubo.Name = "LblRANotubo";
            this.LblRANotubo.Size = new System.Drawing.Size(39, 20);
            this.LblRANotubo.TabIndex = 13;
            this.LblRANotubo.Text = "-----";
            // 
            // LblRAIDregistro
            // 
            this.LblRAIDregistro.AutoSize = true;
            this.LblRAIDregistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRAIDregistro.Location = new System.Drawing.Point(114, 27);
            this.LblRAIDregistro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRAIDregistro.Name = "LblRAIDregistro";
            this.LblRAIDregistro.Size = new System.Drawing.Size(39, 20);
            this.LblRAIDregistro.TabIndex = 12;
            this.LblRAIDregistro.Text = "-----";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Hora:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LblRBMaquina);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.LblRBHora);
            this.groupBox2.Controls.Add(this.LblRBFecha);
            this.groupBox2.Controls.Add(this.LblRBNotubo);
            this.groupBox2.Controls.Add(this.LblRBIDregistro);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(400, 334);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 172);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registro buscado";
            // 
            // LblRBMaquina
            // 
            this.LblRBMaquina.AutoSize = true;
            this.LblRBMaquina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRBMaquina.Location = new System.Drawing.Point(114, 149);
            this.LblRBMaquina.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRBMaquina.Name = "LblRBMaquina";
            this.LblRBMaquina.Size = new System.Drawing.Size(39, 20);
            this.LblRBMaquina.TabIndex = 19;
            this.LblRBMaquina.Text = "-----";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 149);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Maquina:";
            // 
            // LblRBHora
            // 
            this.LblRBHora.AutoSize = true;
            this.LblRBHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRBHora.Location = new System.Drawing.Point(114, 114);
            this.LblRBHora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRBHora.Name = "LblRBHora";
            this.LblRBHora.Size = new System.Drawing.Size(39, 20);
            this.LblRBHora.TabIndex = 15;
            this.LblRBHora.Text = "-----";
            // 
            // LblRBFecha
            // 
            this.LblRBFecha.AutoSize = true;
            this.LblRBFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRBFecha.Location = new System.Drawing.Point(114, 83);
            this.LblRBFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRBFecha.Name = "LblRBFecha";
            this.LblRBFecha.Size = new System.Drawing.Size(39, 20);
            this.LblRBFecha.TabIndex = 14;
            this.LblRBFecha.Text = "-----";
            // 
            // LblRBNotubo
            // 
            this.LblRBNotubo.AutoSize = true;
            this.LblRBNotubo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRBNotubo.Location = new System.Drawing.Point(114, 54);
            this.LblRBNotubo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRBNotubo.Name = "LblRBNotubo";
            this.LblRBNotubo.Size = new System.Drawing.Size(39, 20);
            this.LblRBNotubo.TabIndex = 13;
            this.LblRBNotubo.Text = "-----";
            // 
            // LblRBIDregistro
            // 
            this.LblRBIDregistro.AutoSize = true;
            this.LblRBIDregistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRBIDregistro.Location = new System.Drawing.Point(114, 27);
            this.LblRBIDregistro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRBIDregistro.Name = "LblRBIDregistro";
            this.LblRBIDregistro.Size = new System.Drawing.Size(39, 20);
            this.LblRBIDregistro.TabIndex = 12;
            this.LblRBIDregistro.Text = "-----";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(7, 114);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 20);
            this.label15.TabIndex = 11;
            this.label15.Text = "Hora:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(7, 27);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 20);
            this.label16.TabIndex = 9;
            this.label16.Text = "ID registro:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(7, 83);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 20);
            this.label17.TabIndex = 10;
            this.label17.Text = "Fecha:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(7, 54);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 20);
            this.label18.TabIndex = 8;
            this.label18.Text = "No Tubo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(324, 223);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(229, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Archvos excel encontrados:";
            // 
            // LblArchivosExcel
            // 
            this.LblArchivosExcel.AutoSize = true;
            this.LblArchivosExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblArchivosExcel.Location = new System.Drawing.Point(324, 243);
            this.LblArchivosExcel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblArchivosExcel.Name = "LblArchivosExcel";
            this.LblArchivosExcel.Size = new System.Drawing.Size(37, 16);
            this.LblArchivosExcel.TabIndex = 18;
            this.LblArchivosExcel.Text = "------";
            // 
            // btnCrearReporte
            // 
            this.btnCrearReporte.Enabled = false;
            this.btnCrearReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearReporte.Location = new System.Drawing.Point(673, 268);
            this.btnCrearReporte.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCrearReporte.Name = "btnCrearReporte";
            this.btnCrearReporte.Size = new System.Drawing.Size(129, 60);
            this.btnCrearReporte.TabIndex = 19;
            this.btnCrearReporte.Text = "CREAR REPORTE";
            this.btnCrearReporte.UseVisualStyleBackColor = true;
            this.btnCrearReporte.Click += new System.EventHandler(this.btnCrearReporte_Click);
            // 
            // LtbTemporal
            // 
            this.LtbTemporal.FormattingEnabled = true;
            this.LtbTemporal.Location = new System.Drawing.Point(323, 275);
            this.LtbTemporal.Name = "LtbTemporal";
            this.LtbTemporal.Size = new System.Drawing.Size(305, 43);
            this.LtbTemporal.TabIndex = 20;
            // 
            // PtbExcel
            // 
            this.PtbExcel.Image = global::app_servicio_SADS2.Properties.Resources.GrayLED;
            this.PtbExcel.Location = new System.Drawing.Point(647, 275);
            this.PtbExcel.Name = "PtbExcel";
            this.PtbExcel.Size = new System.Drawing.Size(19, 20);
            this.PtbExcel.TabIndex = 21;
            this.PtbExcel.TabStop = false;
            // 
            // Busqueda_tubo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(811, 507);
            this.Controls.Add(this.PtbExcel);
            this.Controls.Add(this.LtbTemporal);
            this.Controls.Add(this.btnCrearReporte);
            this.Controls.Add(this.LblArchivosExcel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LtbArchivosExcel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbProyecto);
            this.Controls.Add(this.dgvTuboBuscado);
            this.Controls.Add(this.txbNoTubo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBusqueda);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Busqueda_tubo";
            this.Text = "BUSCAR TUBO";
            this.Load += new System.EventHandler(this.Busqueda_tubo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTuboBuscado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PtbExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbNoTubo;
        private System.Windows.Forms.DataGridView dgvTuboBuscado;
        private System.Windows.Forms.ComboBox CmbProyecto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox LtbArchivosExcel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblRAHora;
        private System.Windows.Forms.Label LblRAFecha;
        private System.Windows.Forms.Label LblRANotubo;
        private System.Windows.Forms.Label LblRAIDregistro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LblRBHora;
        private System.Windows.Forms.Label LblRBFecha;
        private System.Windows.Forms.Label LblRBNotubo;
        private System.Windows.Forms.Label LblRBIDregistro;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label LblRAMaquina;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblRBMaquina;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblArchivosExcel;
        private System.Windows.Forms.Button btnCrearReporte;
        private System.Windows.Forms.ListBox LtbTemporal;
        private System.Windows.Forms.PictureBox PtbExcel;
    }
}