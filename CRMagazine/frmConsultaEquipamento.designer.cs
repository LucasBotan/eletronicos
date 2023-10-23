namespace CRMagazine
{
    partial class frmConsultaEquipamento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaEquipamento));
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtObjeto = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtAcima = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOS = new System.Windows.Forms.TextBox();
            this.txtNS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClassificacao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDataSaida = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtStatusA1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtNF = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnlLimpar = new System.Windows.Forms.Button();
            this.dgvConsulta = new System.Windows.Forms.DataGridView();
            this.btnCriarExcel = new System.Windows.Forms.Button();
            this.btnGeraExcel = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.btnAllied = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.btnEtiquetas = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btnCarrefour = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.btnLoteAllied = new System.Windows.Forms.Button();
            this.btnExcelChamado = new System.Windows.Forms.Button();
            this.chbBuscarFinalizados = new System.Windows.Forms.CheckBox();
            this.lblCT = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(531, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "ACIMA DE";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "OBJETO";
            this.label8.Visible = false;
            // 
            // txtObjeto
            // 
            this.txtObjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObjeto.Location = new System.Drawing.Point(18, 89);
            this.txtObjeto.Name = "txtObjeto";
            this.txtObjeto.Size = new System.Drawing.Size(160, 22);
            this.txtObjeto.TabIndex = 11;
            this.txtObjeto.Visible = false;
            this.txtObjeto.Enter += new System.EventHandler(this.txtChamado_Enter);
            this.txtObjeto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChamado_KeyPress);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTotal.Location = new System.Drawing.Point(103, 480);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(19, 29);
            this.lblTotal.TabIndex = 301;
            this.lblTotal.Text = ".";
            // 
            // txtAcima
            // 
            this.txtAcima.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcima.Location = new System.Drawing.Point(534, 76);
            this.txtAcima.Name = "txtAcima";
            this.txtAcima.Size = new System.Drawing.Size(55, 26);
            this.txtAcima.TabIndex = 11;
            this.txtAcima.Enter += new System.EventHandler(this.txtAcima_Enter);
            this.txtAcima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcima_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "NÚMERO SÉRIE";
            // 
            // txtOS
            // 
            this.txtOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOS.Location = new System.Drawing.Point(18, 17);
            this.txtOS.Name = "txtOS";
            this.txtOS.Size = new System.Drawing.Size(160, 22);
            this.txtOS.TabIndex = 6;
            this.txtOS.Enter += new System.EventHandler(this.txtOS_Enter);
            this.txtOS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOS_KeyPress);
            // 
            // txtNS
            // 
            this.txtNS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNS.Location = new System.Drawing.Point(18, 53);
            this.txtNS.Name = "txtNS";
            this.txtNS.Size = new System.Drawing.Size(160, 22);
            this.txtNS.TabIndex = 9;
            this.txtNS.Enter += new System.EventHandler(this.txtNS_Enter);
            this.txtNS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNS_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "CLASSIFICAÇÃO";
            // 
            // txtClassificacao
            // 
            this.txtClassificacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClassificacao.Location = new System.Drawing.Point(191, 76);
            this.txtClassificacao.Name = "txtClassificacao";
            this.txtClassificacao.Size = new System.Drawing.Size(217, 26);
            this.txtClassificacao.TabIndex = 9;
            this.txtClassificacao.Enter += new System.EventHandler(this.txtStatus_Enter);
            this.txtClassificacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStatus_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "DESCRIÇÃO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "OS";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(25, 26);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(290, 26);
            this.txtDescricao.TabIndex = 4;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(951, 476);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(222, 42);
            this.label9.TabIndex = 306;
            this.label9.Text = "CONSULTA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(-1, 480);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 29);
            this.label7.TabIndex = 305;
            this.label7.Text = "TOTAL:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtObjeto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtOS);
            this.panel1.Controls.Add(this.txtNS);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(4, 531);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 120);
            this.panel1.TabIndex = 304;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(626, 7);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(96, 46);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "CONSULTAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.txtDataSaida);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtStatusA1);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtTipo);
            this.panel2.Controls.Add(this.txtNF);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtData);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtStatus);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtAcima);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtClassificacao);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Controls.Add(this.txtDescricao);
            this.panel2.Location = new System.Drawing.Point(213, 531);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(725, 120);
            this.panel2.TabIndex = 303;
            // 
            // txtDataSaida
            // 
            this.txtDataSaida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataSaida.Location = new System.Drawing.Point(535, 27);
            this.txtDataSaida.Name = "txtDataSaida";
            this.txtDataSaida.Size = new System.Drawing.Size(85, 26);
            this.txtDataSaida.TabIndex = 7;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(532, 14);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 13);
            this.label21.TabIndex = 28;
            this.label21.Text = "DATA SAIDA";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(592, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "NOTA FISCAL";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(411, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "STATUS A1";
            // 
            // txtStatusA1
            // 
            this.txtStatusA1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatusA1.Location = new System.Drawing.Point(414, 76);
            this.txtStatusA1.Name = "txtStatusA1";
            this.txtStatusA1.Size = new System.Drawing.Size(114, 26);
            this.txtStatusA1.TabIndex = 10;
            this.txtStatusA1.Enter += new System.EventHandler(this.txtVarejista_Enter);
            this.txtStatusA1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVarejista_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(318, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "TIPO";
            // 
            // txtTipo
            // 
            this.txtTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo.Location = new System.Drawing.Point(321, 27);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(118, 26);
            this.txtTipo.TabIndex = 5;
            this.txtTipo.Enter += new System.EventHandler(this.txtDataHist_Enter);
            this.txtTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDataHist_KeyPress);
            // 
            // txtNF
            // 
            this.txtNF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNF.Location = new System.Drawing.Point(595, 76);
            this.txtNF.Name = "txtNF";
            this.txtNF.Size = new System.Drawing.Size(114, 26);
            this.txtNF.TabIndex = 11;
            this.txtNF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChamadoTriagem_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "STATUS";
            // 
            // txtData
            // 
            this.txtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Location = new System.Drawing.Point(445, 27);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(85, 26);
            this.txtData.TabIndex = 6;
            this.txtData.Enter += new System.EventHandler(this.txtData_Enter);
            this.txtData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(442, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "DATA ENTRADA";
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(25, 76);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(162, 26);
            this.txtStatus.TabIndex = 8;
            this.txtStatus.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            this.txtStatus.Enter += new System.EventHandler(this.txtUsuario_Enter);
            this.txtStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // btnlLimpar
            // 
            this.btnlLimpar.Location = new System.Drawing.Point(826, 480);
            this.btnlLimpar.Name = "btnlLimpar";
            this.btnlLimpar.Size = new System.Drawing.Size(112, 45);
            this.btnlLimpar.TabIndex = 298;
            this.btnlLimpar.Text = "LIMPAR FILTROS";
            this.btnlLimpar.UseVisualStyleBackColor = true;
            this.btnlLimpar.Click += new System.EventHandler(this.btnlLimpar_Click);
            // 
            // dgvConsulta
            // 
            this.dgvConsulta.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvConsulta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsulta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConsulta.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConsulta.Location = new System.Drawing.Point(4, 8);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.RowHeadersWidth = 51;
            this.dgvConsulta.Size = new System.Drawing.Size(1230, 465);
            this.dgvConsulta.TabIndex = 296;
            // 
            // btnCriarExcel
            // 
            this.btnCriarExcel.Image = global::CRMagazine.Properties.Resources.excel;
            this.btnCriarExcel.Location = new System.Drawing.Point(77, 3);
            this.btnCriarExcel.Name = "btnCriarExcel";
            this.btnCriarExcel.Size = new System.Drawing.Size(43, 45);
            this.btnCriarExcel.TabIndex = 307;
            this.btnCriarExcel.UseVisualStyleBackColor = true;
            this.btnCriarExcel.Click += new System.EventHandler(this.btnCriarExcel_Click);
            // 
            // btnGeraExcel
            // 
            this.btnGeraExcel.Image = global::CRMagazine.Properties.Resources.excel;
            this.btnGeraExcel.Location = new System.Drawing.Point(11, 3);
            this.btnGeraExcel.Name = "btnGeraExcel";
            this.btnGeraExcel.Size = new System.Drawing.Size(43, 45);
            this.btnGeraExcel.TabIndex = 299;
            this.btnGeraExcel.UseVisualStyleBackColor = true;
            this.btnGeraExcel.Click += new System.EventHandler(this.btnGeraExcel_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(70, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 308;
            this.label13.Text = "MAGAZINE";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(136, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 13);
            this.label14.TabIndex = 310;
            this.label14.Text = "CHAMADO";
            this.label14.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 311;
            this.label16.Text = "TUDO";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.btnAllied);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.btnEtiquetas);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.btnCarrefour);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.btnLoteAllied);
            this.panel3.Controls.Add(this.btnExcelChamado);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.btnGeraExcel);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.btnCriarExcel);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Location = new System.Drawing.Point(944, 518);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(290, 133);
            this.panel3.TabIndex = 312;
            this.panel3.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(209, 114);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(44, 13);
            this.label20.TabIndex = 319;
            this.label20.Text = "ALLIED";
            this.label20.Visible = false;
            // 
            // btnAllied
            // 
            this.btnAllied.Image = global::CRMagazine.Properties.Resources.excel;
            this.btnAllied.Location = new System.Drawing.Point(210, 66);
            this.btnAllied.Name = "btnAllied";
            this.btnAllied.Size = new System.Drawing.Size(43, 45);
            this.btnAllied.TabIndex = 318;
            this.btnAllied.UseVisualStyleBackColor = true;
            this.btnAllied.Visible = false;
            this.btnAllied.Click += new System.EventHandler(this.btnAllied_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(129, 114);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 13);
            this.label19.TabIndex = 317;
            this.label19.Text = "ETIQUETAS";
            this.label19.Visible = false;
            // 
            // btnEtiquetas
            // 
            this.btnEtiquetas.Image = global::CRMagazine.Properties.Resources.excel;
            this.btnEtiquetas.Location = new System.Drawing.Point(143, 70);
            this.btnEtiquetas.Name = "btnEtiquetas";
            this.btnEtiquetas.Size = new System.Drawing.Size(43, 45);
            this.btnEtiquetas.TabIndex = 316;
            this.btnEtiquetas.UseVisualStyleBackColor = true;
            this.btnEtiquetas.Visible = false;
            this.btnEtiquetas.Click += new System.EventHandler(this.btnEtiquetas_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(-1, 114);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 13);
            this.label18.TabIndex = 315;
            this.label18.Text = "CARREFOUR";
            this.label18.Visible = false;
            // 
            // btnCarrefour
            // 
            this.btnCarrefour.Image = global::CRMagazine.Properties.Resources.excel;
            this.btnCarrefour.Location = new System.Drawing.Point(11, 70);
            this.btnCarrefour.Name = "btnCarrefour";
            this.btnCarrefour.Size = new System.Drawing.Size(43, 45);
            this.btnCarrefour.TabIndex = 314;
            this.btnCarrefour.UseVisualStyleBackColor = true;
            this.btnCarrefour.Visible = false;
            this.btnCarrefour.Click += new System.EventHandler(this.btnCarrefour_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(199, 47);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 13);
            this.label17.TabIndex = 313;
            this.label17.Text = "LOTE ALLIED";
            this.label17.Visible = false;
            // 
            // btnLoteAllied
            // 
            this.btnLoteAllied.Image = global::CRMagazine.Properties.Resources.Help;
            this.btnLoteAllied.Location = new System.Drawing.Point(210, 3);
            this.btnLoteAllied.Name = "btnLoteAllied";
            this.btnLoteAllied.Size = new System.Drawing.Size(43, 45);
            this.btnLoteAllied.TabIndex = 312;
            this.btnLoteAllied.UseVisualStyleBackColor = true;
            this.btnLoteAllied.Visible = false;
            this.btnLoteAllied.Click += new System.EventHandler(this.btnLoteAllied_Click);
            // 
            // btnExcelChamado
            // 
            this.btnExcelChamado.Image = global::CRMagazine.Properties.Resources.excel;
            this.btnExcelChamado.Location = new System.Drawing.Point(143, 3);
            this.btnExcelChamado.Name = "btnExcelChamado";
            this.btnExcelChamado.Size = new System.Drawing.Size(43, 45);
            this.btnExcelChamado.TabIndex = 309;
            this.btnExcelChamado.UseVisualStyleBackColor = true;
            this.btnExcelChamado.Visible = false;
            this.btnExcelChamado.Click += new System.EventHandler(this.btnExcelChamado_Click);
            // 
            // chbBuscarFinalizados
            // 
            this.chbBuscarFinalizados.AutoSize = true;
            this.chbBuscarFinalizados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbBuscarFinalizados.Location = new System.Drawing.Point(213, 505);
            this.chbBuscarFinalizados.Name = "chbBuscarFinalizados";
            this.chbBuscarFinalizados.Size = new System.Drawing.Size(184, 20);
            this.chbBuscarFinalizados.TabIndex = 313;
            this.chbBuscarFinalizados.Text = "MOSTRAR FINALIZADOS";
            this.chbBuscarFinalizados.UseVisualStyleBackColor = true;
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.ForeColor = System.Drawing.Color.Maroon;
            this.lblCT.Location = new System.Drawing.Point(10, 514);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(10, 14);
            this.lblCT.TabIndex = 533;
            this.lblCT.Text = ".";
            // 
            // frmConsultaEquipamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 663);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.chbBuscarFinalizados);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnlLimpar);
            this.Controls.Add(this.dgvConsulta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultaEquipamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONSULTAR";
            this.Load += new System.EventHandler(this.frmConsultaHistorico_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtObjeto;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtAcima;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOS;
        private System.Windows.Forms.TextBox txtNS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClassificacao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGeraExcel;
        private System.Windows.Forms.Button btnlLimpar;
        private System.Windows.Forms.DataGridView dgvConsulta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtStatusA1;
        private System.Windows.Forms.Button btnCriarExcel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNF;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExcelChamado;
        private System.Windows.Forms.Button btnLoteAllied;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnCarrefour;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnEtiquetas;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnAllied;
        private System.Windows.Forms.CheckBox chbBuscarFinalizados;
        private System.Windows.Forms.TextBox txtDataSaida;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblCT;
    }
}