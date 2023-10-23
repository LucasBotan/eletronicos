namespace CRMagazine
{
    partial class frmExpedicaoPlanilhaNotaFiscal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpedicaoPlanilhaNotaFiscal));
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvParaLançarNF = new System.Windows.Forms.DataGridView();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvConsultaNotas = new System.Windows.Forms.DataGridView();
            this.btnBusca = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNF = new System.Windows.Forms.TextBox();
            this.btnGeraPlanilha = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlNF = new System.Windows.Forms.Panel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.txtRetornoNF = new System.Windows.Forms.TextBox();
            this.lnkBuscarNFdaOS = new System.Windows.Forms.LinkLabel();
            this.pnlVisualizarOS = new System.Windows.Forms.Panel();
            this.dgvVisualizar = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVarejista = new System.Windows.Forms.TextBox();
            this.txtOrcamento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQnt = new System.Windows.Forms.TextBox();
            this.txtNS = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnConcluir = new System.Windows.Forms.Button();
            this.txtNFSaida = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.chbPorFora = new System.Windows.Forms.CheckBox();
            this.picJB1 = new System.Windows.Forms.PictureBox();
            this.lblTextoQRCode = new System.Windows.Forms.Label();
            this.lblCT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParaLançarNF)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaNotas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlNF.SuspendLayout();
            this.pnlVisualizarOS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisualizar)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picJB1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTotal.Location = new System.Drawing.Point(479, 179);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(15, 24);
            this.lblTotal.TabIndex = 21;
            this.lblTotal.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(343, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "TOTAL ITENS:";
            // 
            // dgvParaLançarNF
            // 
            this.dgvParaLançarNF.AllowUserToAddRows = false;
            this.dgvParaLançarNF.AllowUserToDeleteRows = false;
            this.dgvParaLançarNF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvParaLançarNF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParaLançarNF.Location = new System.Drawing.Point(347, 270);
            this.dgvParaLançarNF.Name = "dgvParaLançarNF";
            this.dgvParaLançarNF.RowHeadersWidth = 51;
            this.dgvParaLançarNF.Size = new System.Drawing.Size(905, 420);
            this.dgvParaLançarNF.TabIndex = 19;
            this.dgvParaLançarNF.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParaLançarNF_CellClick);
            this.dgvParaLançarNF.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParaLançarNF_CellEnter);
            // 
            // txtEndereco
            // 
            this.txtEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndereco.Location = new System.Drawing.Point(15, 33);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.ReadOnly = true;
            this.txtEndereco.Size = new System.Drawing.Size(593, 22);
            this.txtEndereco.TabIndex = 282;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Location = new System.Drawing.Point(614, 28);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(45, 27);
            this.btnExcel.TabIndex = 281;
            this.btnExcel.Text = "...";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtEndereco);
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Location = new System.Drawing.Point(1274, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 58);
            this.panel1.TabIndex = 283;
            this.panel1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 20);
            this.label2.TabIndex = 284;
            this.label2.Text = "SELECIONAR BASE:";
            // 
            // dgvConsultaNotas
            // 
            this.dgvConsultaNotas.AllowUserToAddRows = false;
            this.dgvConsultaNotas.AllowUserToDeleteRows = false;
            this.dgvConsultaNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultaNotas.Location = new System.Drawing.Point(12, 270);
            this.dgvConsultaNotas.Name = "dgvConsultaNotas";
            this.dgvConsultaNotas.RowHeadersWidth = 51;
            this.dgvConsultaNotas.Size = new System.Drawing.Size(329, 420);
            this.dgvConsultaNotas.TabIndex = 287;
            this.dgvConsultaNotas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultaNotas_CellClick);
            this.dgvConsultaNotas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultaNotas_CellEnter_1);
            // 
            // btnBusca
            // 
            this.btnBusca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusca.Image = ((System.Drawing.Image)(resources.GetObject("btnBusca.Image")));
            this.btnBusca.Location = new System.Drawing.Point(1293, 87);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(35, 26);
            this.btnBusca.TabIndex = 433;
            this.btnBusca.UseVisualStyleBackColor = true;
            this.btnBusca.Visible = false;
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 432;
            this.label7.Text = "NOTA FISCAL";
            // 
            // txtNF
            // 
            this.txtNF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNF.Location = new System.Drawing.Point(10, 22);
            this.txtNF.Name = "txtNF";
            this.txtNF.ReadOnly = true;
            this.txtNF.Size = new System.Drawing.Size(137, 26);
            this.txtNF.TabIndex = 431;
            // 
            // btnGeraPlanilha
            // 
            this.btnGeraPlanilha.Image = ((System.Drawing.Image)(resources.GetObject("btnGeraPlanilha.Image")));
            this.btnGeraPlanilha.Location = new System.Drawing.Point(1293, 6);
            this.btnGeraPlanilha.Name = "btnGeraPlanilha";
            this.btnGeraPlanilha.Size = new System.Drawing.Size(43, 45);
            this.btnGeraPlanilha.TabIndex = 284;
            this.btnGeraPlanilha.UseVisualStyleBackColor = true;
            this.btnGeraPlanilha.Visible = false;
            this.btnGeraPlanilha.Click += new System.EventHandler(this.btnGeraPlanilha_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 20);
            this.label3.TabIndex = 434;
            this.label3.Text = "NOTAS DISPONIVEIS";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox2.Location = new System.Drawing.Point(940, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(226, 30);
            this.pictureBox2.TabIndex = 435;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(257, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(777, 78);
            this.label5.TabIndex = 516;
            this.label5.Text = "PENDENTES DE NF DE SAÍDA";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // pnlNF
            // 
            this.pnlNF.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlNF.Controls.Add(this.btnFechar);
            this.pnlNF.Controls.Add(this.txtRetornoNF);
            this.pnlNF.Location = new System.Drawing.Point(1311, 513);
            this.pnlNF.Name = "pnlNF";
            this.pnlNF.Size = new System.Drawing.Size(674, 254);
            this.pnlNF.TabIndex = 519;
            this.pnlNF.Visible = false;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFechar.Location = new System.Drawing.Point(584, 12);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(76, 26);
            this.btnFechar.TabIndex = 519;
            this.btnFechar.Text = "FECHAR";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // txtRetornoNF
            // 
            this.txtRetornoNF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRetornoNF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRetornoNF.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetornoNF.Location = new System.Drawing.Point(107, 63);
            this.txtRetornoNF.Name = "txtRetornoNF";
            this.txtRetornoNF.Size = new System.Drawing.Size(453, 116);
            this.txtRetornoNF.TabIndex = 518;
            this.txtRetornoNF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRetornoNF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRetornoNF_KeyPress);
            // 
            // lnkBuscarNFdaOS
            // 
            this.lnkBuscarNFdaOS.AutoSize = true;
            this.lnkBuscarNFdaOS.Location = new System.Drawing.Point(1262, 254);
            this.lnkBuscarNFdaOS.Name = "lnkBuscarNFdaOS";
            this.lnkBuscarNFdaOS.Size = new System.Drawing.Size(159, 13);
            this.lnkBuscarNFdaOS.TabIndex = 520;
            this.lnkBuscarNFdaOS.TabStop = true;
            this.lnkBuscarNFdaOS.Text = "BUSCAR NOTA FISCAL DA OS";
            this.lnkBuscarNFdaOS.Visible = false;
            this.lnkBuscarNFdaOS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBuscarNFdaOS_LinkClicked);
            // 
            // pnlVisualizarOS
            // 
            this.pnlVisualizarOS.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlVisualizarOS.Controls.Add(this.dgvVisualizar);
            this.pnlVisualizarOS.Controls.Add(this.button1);
            this.pnlVisualizarOS.Location = new System.Drawing.Point(1311, 25);
            this.pnlVisualizarOS.Name = "pnlVisualizarOS";
            this.pnlVisualizarOS.Size = new System.Drawing.Size(674, 472);
            this.pnlVisualizarOS.TabIndex = 521;
            this.pnlVisualizarOS.Visible = false;
            // 
            // dgvVisualizar
            // 
            this.dgvVisualizar.AllowUserToAddRows = false;
            this.dgvVisualizar.AllowUserToDeleteRows = false;
            this.dgvVisualizar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisualizar.Location = new System.Drawing.Point(16, 44);
            this.dgvVisualizar.Name = "dgvVisualizar";
            this.dgvVisualizar.RowHeadersWidth = 51;
            this.dgvVisualizar.Size = new System.Drawing.Size(644, 406);
            this.dgvVisualizar.TabIndex = 520;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(584, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 26);
            this.button1.TabIndex = 519;
            this.button1.Text = "FECHAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(1289, 47);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(34, 34);
            this.btnImprimir.TabIndex = 522;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(1289, 111);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(31, 31);
            this.btnRefresh.TabIndex = 523;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtVarejista);
            this.panel2.Controls.Add(this.txtOrcamento);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtQnt);
            this.panel2.Controls.Add(this.txtNF);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(347, 206);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(587, 58);
            this.panel2.TabIndex = 524;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(439, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 438;
            this.label9.Text = "VEREJISTA";
            // 
            // txtVarejista
            // 
            this.txtVarejista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVarejista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVarejista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVarejista.Location = new System.Drawing.Point(442, 22);
            this.txtVarejista.Name = "txtVarejista";
            this.txtVarejista.ReadOnly = true;
            this.txtVarejista.Size = new System.Drawing.Size(131, 26);
            this.txtVarejista.TabIndex = 437;
            // 
            // txtOrcamento
            // 
            this.txtOrcamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrcamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrcamento.Location = new System.Drawing.Point(153, 22);
            this.txtOrcamento.Name = "txtOrcamento";
            this.txtOrcamento.ReadOnly = true;
            this.txtOrcamento.Size = new System.Drawing.Size(191, 26);
            this.txtOrcamento.TabIndex = 435;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 436;
            this.label6.Text = "ORCAMENTO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(350, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 434;
            this.label4.Text = "QNT";
            // 
            // txtQnt
            // 
            this.txtQnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQnt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQnt.Location = new System.Drawing.Point(353, 22);
            this.txtQnt.Name = "txtQnt";
            this.txtQnt.ReadOnly = true;
            this.txtQnt.Size = new System.Drawing.Size(83, 26);
            this.txtQnt.TabIndex = 433;
            // 
            // txtNS
            // 
            this.txtNS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNS.Location = new System.Drawing.Point(1258, 270);
            this.txtNS.Multiline = true;
            this.txtNS.Name = "txtNS";
            this.txtNS.ReadOnly = true;
            this.txtNS.Size = new System.Drawing.Size(47, 341);
            this.txtNS.TabIndex = 525;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel3.Controls.Add(this.btnConcluir);
            this.panel3.Controls.Add(this.txtNFSaida);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(940, 179);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(312, 85);
            this.panel3.TabIndex = 525;
            // 
            // btnConcluir
            // 
            this.btnConcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConcluir.Location = new System.Drawing.Point(213, 36);
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(75, 31);
            this.btnConcluir.TabIndex = 435;
            this.btnConcluir.Text = "CONCLUIR";
            this.btnConcluir.UseVisualStyleBackColor = true;
            this.btnConcluir.Click += new System.EventHandler(this.btnConcluir_Click);
            // 
            // txtNFSaida
            // 
            this.txtNFSaida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNFSaida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNFSaida.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNFSaida.Location = new System.Drawing.Point(27, 36);
            this.txtNFSaida.Name = "txtNFSaida";
            this.txtNFSaida.Size = new System.Drawing.Size(180, 31);
            this.txtNFSaida.TabIndex = 433;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 16);
            this.label8.TabIndex = 434;
            this.label8.Text = "NF SAÍDA";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Image = global::CRMagazine.Properties.Resources.Refresh;
            this.btnAtualizar.Location = new System.Drawing.Point(295, 228);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(46, 39);
            this.btnAtualizar.TabIndex = 526;
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // chbPorFora
            // 
            this.chbPorFora.AutoSize = true;
            this.chbPorFora.Location = new System.Drawing.Point(26, 163);
            this.chbPorFora.Name = "chbPorFora";
            this.chbPorFora.Size = new System.Drawing.Size(228, 17);
            this.chbPorFora.TabIndex = 527;
            this.chbPorFora.Text = "BUSCAR NOTAS LANÇADAS POR FORA";
            this.chbPorFora.UseVisualStyleBackColor = true;
            this.chbPorFora.CheckedChanged += new System.EventHandler(this.chbPorFora_CheckedChanged);
            // 
            // picJB1
            // 
            this.picJB1.Location = new System.Drawing.Point(78, 47);
            this.picJB1.Name = "picJB1";
            this.picJB1.Size = new System.Drawing.Size(91, 87);
            this.picJB1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picJB1.TabIndex = 528;
            this.picJB1.TabStop = false;
            // 
            // lblTextoQRCode
            // 
            this.lblTextoQRCode.AutoSize = true;
            this.lblTextoQRCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoQRCode.Location = new System.Drawing.Point(74, 14);
            this.lblTextoQRCode.Name = "lblTextoQRCode";
            this.lblTextoQRCode.Size = new System.Drawing.Size(15, 24);
            this.lblTextoQRCode.TabIndex = 529;
            this.lblTextoQRCode.Text = ".";
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.ForeColor = System.Drawing.Color.Maroon;
            this.lblCT.Location = new System.Drawing.Point(1244, 11);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(10, 14);
            this.lblCT.TabIndex = 533;
            this.lblCT.Text = ".";
            // 
            // frmExpedicaoPlanilhaNotaFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 711);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.lblTextoQRCode);
            this.Controls.Add(this.picJB1);
            this.Controls.Add(this.chbPorFora);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtNS);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlVisualizarOS);
            this.Controls.Add(this.pnlNF);
            this.Controls.Add(this.dgvConsultaNotas);
            this.Controls.Add(this.lnkBuscarNFdaOS);
            this.Controls.Add(this.btnBusca);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGeraPlanilha);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvParaLançarNF);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnRefresh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExpedicaoPlanilhaNotaFiscal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PENDENTES DE NF DE SAÍDA";
            this.Load += new System.EventHandler(this.frmExpedicaoPlanilhaNotaFiscal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParaLançarNF)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaNotas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlNF.ResumeLayout(false);
            this.pnlNF.PerformLayout();
            this.pnlVisualizarOS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisualizar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picJB1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvParaLançarNF;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvConsultaNotas;
        private System.Windows.Forms.Button btnBusca;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNF;
        private System.Windows.Forms.Button btnGeraPlanilha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlNF;
        private System.Windows.Forms.TextBox txtRetornoNF;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.LinkLabel lnkBuscarNFdaOS;
        private System.Windows.Forms.Panel pnlVisualizarOS;
        private System.Windows.Forms.DataGridView dgvVisualizar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtOrcamento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQnt;
        private System.Windows.Forms.TextBox txtNS;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnConcluir;
        private System.Windows.Forms.TextBox txtNFSaida;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVarejista;
        private System.Windows.Forms.CheckBox chbPorFora;
        private System.Windows.Forms.PictureBox picJB1;
        private System.Windows.Forms.Label lblTextoQRCode;
        private System.Windows.Forms.Label lblCT;
    }
}