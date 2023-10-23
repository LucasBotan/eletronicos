namespace CRMagazine
{
    partial class old_frmEstoqueRMA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(old_frmEstoqueRMA));
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvConsulta = new System.Windows.Forms.DataGridView();
            this.chkColuna = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblQnt = new System.Windows.Forms.Label();
            this.btnDescate = new System.Windows.Forms.Button();
            this.btnDevolucao = new System.Windows.Forms.Button();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnDesmarcar = new System.Windows.Forms.Button();
            this.btnMarcarTudo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDataAssist = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxAssist = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInsereDescricao = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtInsereCodigo = new System.Windows.Forms.TextBox();
            this.pnlInserirNaMao = new System.Windows.Forms.Panel();
            this.btnInserir = new System.Windows.Forms.Button();
            this.txtInsereQuantidade = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.chbInsereNaMao = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlInserirNaMao.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CRMagazine.Properties.Resources.vermelho;
            this.pictureBox3.Location = new System.Drawing.Point(1286, 17);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 27);
            this.pictureBox3.TabIndex = 271;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CRMagazine.Properties.Resources.verde;
            this.pictureBox1.Location = new System.Drawing.Point(1212, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 26);
            this.pictureBox1.TabIndex = 270;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox2.Image = global::CRMagazine.Properties.Resources.logo1;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(215, 49);
            this.pictureBox2.TabIndex = 269;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(196, 151);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(18, 25);
            this.lblTotal.TabIndex = 267;
            this.lblTotal.Text = ".";
            // 
            // dgvConsulta
            // 
            this.dgvConsulta.AllowUserToAddRows = false;
            this.dgvConsulta.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvConsulta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvConsulta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvConsulta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsulta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsulta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkColuna});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConsulta.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConsulta.Location = new System.Drawing.Point(51, 179);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsulta.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvConsulta.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvConsulta.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvConsulta.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsulta.Size = new System.Drawing.Size(1261, 327);
            this.dgvConsulta.TabIndex = 268;
            this.dgvConsulta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsulta_CellContentClick);
            // 
            // chkColuna
            // 
            this.chkColuna.HeaderText = "Selecionar";
            this.chkColuna.Name = "chkColuna";
            this.chkColuna.Width = 90;
            // 
            // lblQnt
            // 
            this.lblQnt.AutoSize = true;
            this.lblQnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQnt.Location = new System.Drawing.Point(46, 151);
            this.lblQnt.Name = "lblQnt";
            this.lblQnt.Size = new System.Drawing.Size(154, 25);
            this.lblQnt.TabIndex = 266;
            this.lblQnt.Text = "QUANTIDADE:";
            // 
            // btnDescate
            // 
            this.btnDescate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescate.Location = new System.Drawing.Point(1081, 531);
            this.btnDescate.Name = "btnDescate";
            this.btnDescate.Size = new System.Drawing.Size(101, 38);
            this.btnDescate.TabIndex = 273;
            this.btnDescate.Text = "DESCARTE";
            this.btnDescate.UseVisualStyleBackColor = true;
            this.btnDescate.Click += new System.EventHandler(this.btnDescate_Click);
            // 
            // btnDevolucao
            // 
            this.btnDevolucao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevolucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevolucao.Location = new System.Drawing.Point(1212, 531);
            this.btnDevolucao.Name = "btnDevolucao";
            this.btnDevolucao.Size = new System.Drawing.Size(101, 38);
            this.btnDevolucao.TabIndex = 274;
            this.btnDevolucao.Text = "DEVOLUÇÃO";
            this.btnDevolucao.UseVisualStyleBackColor = true;
            this.btnDevolucao.Click += new System.EventHandler(this.btnDevolucao_Click);
            // 
            // txtLote
            // 
            this.txtLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLote.Location = new System.Drawing.Point(50, 531);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(163, 29);
            this.txtLote.TabIndex = 275;
            this.txtLote.Leave += new System.EventHandler(this.txtLote_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 515);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 276;
            this.label2.Text = "LOTE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 515);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 278;
            this.label3.Text = "VOLUME";
            // 
            // txtVolume
            // 
            this.txtVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVolume.Location = new System.Drawing.Point(251, 531);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.Size = new System.Drawing.Size(105, 29);
            this.txtVolume.TabIndex = 277;
            this.txtVolume.Enter += new System.EventHandler(this.txtVolume_Enter);
            this.txtVolume.Leave += new System.EventHandler(this.txtVolume_Leave);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.Location = new System.Drawing.Point(779, 55);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(101, 35);
            this.btnAtualizar.TabIndex = 279;
            this.btnAtualizar.Text = "ATUALIZAR";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnDesmarcar
            // 
            this.btnDesmarcar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesmarcar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesmarcar.Location = new System.Drawing.Point(271, 113);
            this.btnDesmarcar.Name = "btnDesmarcar";
            this.btnDesmarcar.Size = new System.Drawing.Size(121, 28);
            this.btnDesmarcar.TabIndex = 280;
            this.btnDesmarcar.Text = "DESMARCAR";
            this.btnDesmarcar.UseVisualStyleBackColor = true;
            this.btnDesmarcar.Click += new System.EventHandler(this.btnDesmarcar_Click);
            // 
            // btnMarcarTudo
            // 
            this.btnMarcarTudo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcarTudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarcarTudo.Location = new System.Drawing.Point(271, 70);
            this.btnMarcarTudo.Name = "btnMarcarTudo";
            this.btnMarcarTudo.Size = new System.Drawing.Size(121, 28);
            this.btnMarcarTudo.TabIndex = 281;
            this.btnMarcarTudo.Text = "MARCAR TUDO";
            this.btnMarcarTudo.UseVisualStyleBackColor = true;
            this.btnMarcarTudo.Click += new System.EventHandler(this.btnMarcarTudo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtDataAssist);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cbxAssist);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtData);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.btnAtualizar);
            this.panel1.Location = new System.Drawing.Point(418, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 97);
            this.panel1.TabIndex = 282;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(627, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 291;
            this.label8.Text = "DATA";
            // 
            // txtDataAssist
            // 
            this.txtDataAssist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataAssist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataAssist.Location = new System.Drawing.Point(630, 64);
            this.txtDataAssist.Name = "txtDataAssist";
            this.txtDataAssist.Size = new System.Drawing.Size(139, 26);
            this.txtDataAssist.TabIndex = 290;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(482, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 289;
            this.label7.Text = "CONCLUIDO ASSIST";
            // 
            // cbxAssist
            // 
            this.cbxAssist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAssist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxAssist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAssist.FormattingEnabled = true;
            this.cbxAssist.Items.AddRange(new object[] {
            "SIM",
            "NÃO",
            "SEM ASSIST",
            "ESTORNO",
            "TUDO"});
            this.cbxAssist.Location = new System.Drawing.Point(485, 64);
            this.cbxAssist.Name = "cbxAssist";
            this.cbxAssist.Size = new System.Drawing.Size(139, 26);
            this.cbxAssist.TabIndex = 288;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(700, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 287;
            this.label6.Text = "STATUS";
            // 
            // txtStatus
            // 
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(703, 20);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(177, 26);
            this.txtStatus.TabIndex = 286;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(337, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 285;
            this.label5.Text = "DATA";
            // 
            // txtData
            // 
            this.txtData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Location = new System.Drawing.Point(340, 64);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(139, 26);
            this.txtData.TabIndex = 284;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 283;
            this.label4.Text = "DESCRIÇÃO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 281;
            this.label1.Text = "CODIGO";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(16, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(678, 26);
            this.txtCodigo.TabIndex = 280;
            // 
            // txtDescricao
            // 
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(16, 64);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(318, 26);
            this.txtDescricao.TabIndex = 282;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(190, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 286;
            this.label9.Text = "DESCRIÇÃO";
            // 
            // txtInsereDescricao
            // 
            this.txtInsereDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInsereDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInsereDescricao.Location = new System.Drawing.Point(193, 29);
            this.txtInsereDescricao.Name = "txtInsereDescricao";
            this.txtInsereDescricao.Size = new System.Drawing.Size(565, 29);
            this.txtInsereDescricao.TabIndex = 285;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 284;
            this.label10.Text = "CODIGO";
            // 
            // txtInsereCodigo
            // 
            this.txtInsereCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInsereCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInsereCodigo.Location = new System.Drawing.Point(24, 29);
            this.txtInsereCodigo.Name = "txtInsereCodigo";
            this.txtInsereCodigo.Size = new System.Drawing.Size(163, 29);
            this.txtInsereCodigo.TabIndex = 283;
            this.txtInsereCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInsereCodigo_KeyPress);
            // 
            // pnlInserirNaMao
            // 
            this.pnlInserirNaMao.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlInserirNaMao.Controls.Add(this.btnInserir);
            this.pnlInserirNaMao.Controls.Add(this.txtInsereQuantidade);
            this.pnlInserirNaMao.Controls.Add(this.label11);
            this.pnlInserirNaMao.Controls.Add(this.txtInsereDescricao);
            this.pnlInserirNaMao.Controls.Add(this.label9);
            this.pnlInserirNaMao.Controls.Add(this.txtInsereCodigo);
            this.pnlInserirNaMao.Controls.Add(this.label10);
            this.pnlInserirNaMao.Location = new System.Drawing.Point(51, 610);
            this.pnlInserirNaMao.Name = "pnlInserirNaMao";
            this.pnlInserirNaMao.Size = new System.Drawing.Size(1031, 73);
            this.pnlInserirNaMao.TabIndex = 287;
            this.pnlInserirNaMao.Visible = false;
            // 
            // btnInserir
            // 
            this.btnInserir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInserir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInserir.Location = new System.Drawing.Point(902, 29);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(101, 29);
            this.btnInserir.TabIndex = 289;
            this.btnInserir.Text = "INSERIR";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // txtInsereQuantidade
            // 
            this.txtInsereQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInsereQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInsereQuantidade.Location = new System.Drawing.Point(764, 29);
            this.txtInsereQuantidade.Name = "txtInsereQuantidade";
            this.txtInsereQuantidade.Size = new System.Drawing.Size(95, 29);
            this.txtInsereQuantidade.TabIndex = 287;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(761, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 288;
            this.label11.Text = "QUANTIDADE";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(233, 12);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(16, 24);
            this.lblUsuario.TabIndex = 288;
            this.lblUsuario.Text = ".";
            // 
            // chbInsereNaMao
            // 
            this.chbInsereNaMao.AutoSize = true;
            this.chbInsereNaMao.Location = new System.Drawing.Point(50, 593);
            this.chbInsereNaMao.Name = "chbInsereNaMao";
            this.chbInsereNaMao.Size = new System.Drawing.Size(164, 17);
            this.chbInsereNaMao.TabIndex = 289;
            this.chbInsereNaMao.Text = "INSERIR RMA SEM ASSIST";
            this.chbInsereNaMao.UseVisualStyleBackColor = true;
            this.chbInsereNaMao.CheckedChanged += new System.EventHandler(this.chbInsereNaMao_CheckedChanged);
            // 
            // frmEstoqueRMA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 722);
            this.Controls.Add(this.chbInsereNaMao);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pnlInserirNaMao);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMarcarTudo);
            this.Controls.Add(this.btnDesmarcar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVolume);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLote);
            this.Controls.Add(this.btnDevolucao);
            this.Controls.Add(this.btnDescate);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvConsulta);
            this.Controls.Add(this.lblQnt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEstoqueRMA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RMA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEstoqueRMA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlInserirNaMao.ResumeLayout(false);
            this.pnlInserirNaMao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvConsulta;
        private System.Windows.Forms.Label lblQnt;
        private System.Windows.Forms.Button btnDescate;
        private System.Windows.Forms.Button btnDevolucao;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkColuna;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDesmarcar;
        private System.Windows.Forms.Button btnMarcarTudo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDataAssist;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxAssist;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtInsereDescricao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtInsereCodigo;
        private System.Windows.Forms.Panel pnlInserirNaMao;
        private System.Windows.Forms.TextBox txtInsereQuantidade;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.CheckBox chbInsereNaMao;

    }
}