namespace CRMagazine
{
    partial class frmAlterarBanco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlterarBanco));
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodVarejista = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtNS = new System.Windows.Forms.TextBox();
            this.txtOS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.chbData = new System.Windows.Forms.CheckBox();
            this.chbNS = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chbOS = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.rbOS = new System.Windows.Forms.RadioButton();
            this.rbNS = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chbCodViaVarejo = new System.Windows.Forms.CheckBox();
            this.chbDescricao = new System.Windows.Forms.CheckBox();
            this.ckbCodPositivo = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodPositivo = new System.Windows.Forms.TextBox();
            this.btnBusca = new System.Windows.Forms.Button();
            this.chbVarejista = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboVarejista = new System.Windows.Forms.ComboBox();
            this.lblCT = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(524, 433);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 61;
            this.label6.Text = "Descrição";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 433);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 60;
            this.label5.Text = "Número de Série";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 433);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 59;
            this.label4.Text = "Código Varejista";
            // 
            // txtCodVarejista
            // 
            this.txtCodVarejista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodVarejista.Enabled = false;
            this.txtCodVarejista.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodVarejista.Location = new System.Drawing.Point(35, 378);
            this.txtCodVarejista.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodVarejista.Name = "txtCodVarejista";
            this.txtCodVarejista.Size = new System.Drawing.Size(181, 46);
            this.txtCodVarejista.TabIndex = 58;
            // 
            // txtDescricao
            // 
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(528, 378);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(651, 46);
            this.txtDescricao.TabIndex = 57;
            // 
            // txtNS
            // 
            this.txtNS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNS.Enabled = false;
            this.txtNS.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNS.Location = new System.Drawing.Point(239, 378);
            this.txtNS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNS.Name = "txtNS";
            this.txtNS.Size = new System.Drawing.Size(263, 46);
            this.txtNS.TabIndex = 56;
            this.txtNS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNS_KeyPress);
            this.txtNS.Leave += new System.EventHandler(this.txtNS_Leave);
            // 
            // txtOS
            // 
            this.txtOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOS.Enabled = false;
            this.txtOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOS.Location = new System.Drawing.Point(140, 283);
            this.txtOS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOS.Name = "txtOS";
            this.txtOS.Size = new System.Drawing.Size(263, 46);
            this.txtOS.TabIndex = 54;
            this.txtOS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOS_KeyPress);
            this.txtOS.Leave += new System.EventHandler(this.txtOS_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 338);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 63;
            this.label1.Text = "Data Entrada";
            // 
            // txtData
            // 
            this.txtData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtData.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtData.Enabled = false;
            this.txtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Location = new System.Drawing.Point(429, 283);
            this.txtData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(205, 46);
            this.txtData.TabIndex = 62;
            this.txtData.TextChanged += new System.EventHandler(this.txtData_TextChanged);
            this.txtData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData_KeyPress);
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtID.Location = new System.Drawing.Point(35, 283);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(81, 45);
            this.txtID.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 338);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 65;
            this.label2.Text = "ID";
            // 
            // btnAlterar
            // 
            this.btnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(929, 484);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(107, 33);
            this.btnAlterar.TabIndex = 66;
            this.btnAlterar.Text = "ALTERAR";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(1079, 484);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(101, 33);
            this.btnExcluir.TabIndex = 67;
            this.btnExcluir.Text = "EXCLUIR";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // chbData
            // 
            this.chbData.AutoSize = true;
            this.chbData.Location = new System.Drawing.Point(615, 338);
            this.chbData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbData.Name = "chbData";
            this.chbData.Size = new System.Drawing.Size(18, 17);
            this.chbData.TabIndex = 68;
            this.chbData.UseVisualStyleBackColor = true;
            this.chbData.CheckedChanged += new System.EventHandler(this.chbData_CheckedChanged);
            // 
            // chbNS
            // 
            this.chbNS.AutoSize = true;
            this.chbNS.Location = new System.Drawing.Point(483, 432);
            this.chbNS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbNS.Name = "chbNS";
            this.chbNS.Size = new System.Drawing.Size(18, 17);
            this.chbNS.TabIndex = 70;
            this.chbNS.UseVisualStyleBackColor = true;
            this.chbNS.CheckedChanged += new System.EventHandler(this.chbNS_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 338);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 17);
            this.label3.TabIndex = 71;
            this.label3.Text = "OS";
            // 
            // chbOS
            // 
            this.chbOS.AutoSize = true;
            this.chbOS.Location = new System.Drawing.Point(384, 337);
            this.chbOS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbOS.Name = "chbOS";
            this.chbOS.Size = new System.Drawing.Size(18, 17);
            this.chbOS.TabIndex = 72;
            this.chbOS.UseVisualStyleBackColor = true;
            this.chbOS.CheckedChanged += new System.EventHandler(this.chbOS_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(341, 75);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(509, 61);
            this.label7.TabIndex = 73;
            this.label7.Text = "ALTERAÇÃO NO BANCO";
            // 
            // txtTexto
            // 
            this.txtTexto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTexto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexto.Location = new System.Drawing.Point(93, 42);
            this.txtTexto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(221, 46);
            this.txtTexto.TabIndex = 1;
            this.txtTexto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
            // 
            // rbOS
            // 
            this.rbOS.AutoSize = true;
            this.rbOS.Location = new System.Drawing.Point(16, 41);
            this.rbOS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbOS.Name = "rbOS";
            this.rbOS.Size = new System.Drawing.Size(49, 21);
            this.rbOS.TabIndex = 76;
            this.rbOS.TabStop = true;
            this.rbOS.Text = "OS";
            this.rbOS.UseVisualStyleBackColor = true;
            // 
            // rbNS
            // 
            this.rbNS.AutoSize = true;
            this.rbNS.Location = new System.Drawing.Point(16, 68);
            this.rbNS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbNS.Name = "rbNS";
            this.rbNS.Size = new System.Drawing.Size(48, 21);
            this.rbNS.TabIndex = 77;
            this.rbNS.TabStop = true;
            this.rbNS.Text = "NS";
            this.rbNS.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTexto);
            this.groupBox1.Controls.Add(this.rbNS);
            this.groupBox1.Controls.Add(this.rbOS);
            this.groupBox1.Location = new System.Drawing.Point(67, 139);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(337, 110);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BUSCAR POR:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CRMagazine.Properties.Resources.B1;
            this.pictureBox1.Location = new System.Drawing.Point(16, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 110);
            this.pictureBox1.TabIndex = 74;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // chbCodViaVarejo
            // 
            this.chbCodViaVarejo.AutoSize = true;
            this.chbCodViaVarejo.Location = new System.Drawing.Point(196, 432);
            this.chbCodViaVarejo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbCodViaVarejo.Name = "chbCodViaVarejo";
            this.chbCodViaVarejo.Size = new System.Drawing.Size(18, 17);
            this.chbCodViaVarejo.TabIndex = 79;
            this.chbCodViaVarejo.UseVisualStyleBackColor = true;
            this.chbCodViaVarejo.CheckedChanged += new System.EventHandler(this.chbCodViaVarejo_CheckedChanged);
            // 
            // chbDescricao
            // 
            this.chbDescricao.AutoSize = true;
            this.chbDescricao.Location = new System.Drawing.Point(1160, 432);
            this.chbDescricao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbDescricao.Name = "chbDescricao";
            this.chbDescricao.Size = new System.Drawing.Size(18, 17);
            this.chbDescricao.TabIndex = 80;
            this.chbDescricao.UseVisualStyleBackColor = true;
            this.chbDescricao.CheckedChanged += new System.EventHandler(this.chbDescricao_CheckedChanged);
            // 
            // ckbCodPositivo
            // 
            this.ckbCodPositivo.AutoSize = true;
            this.ckbCodPositivo.Location = new System.Drawing.Point(844, 338);
            this.ckbCodPositivo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckbCodPositivo.Name = "ckbCodPositivo";
            this.ckbCodPositivo.Size = new System.Drawing.Size(18, 17);
            this.ckbCodPositivo.TabIndex = 83;
            this.ckbCodPositivo.UseVisualStyleBackColor = true;
            this.ckbCodPositivo.CheckedChanged += new System.EventHandler(this.ckbCodPositivo_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(659, 338);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 17);
            this.label8.TabIndex = 82;
            this.label8.Text = "SKU";
            // 
            // txtCodPositivo
            // 
            this.txtCodPositivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodPositivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodPositivo.Enabled = false;
            this.txtCodPositivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodPositivo.Location = new System.Drawing.Point(659, 283);
            this.txtCodPositivo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodPositivo.Name = "txtCodPositivo";
            this.txtCodPositivo.Size = new System.Drawing.Size(205, 46);
            this.txtCodPositivo.TabIndex = 81;
            // 
            // btnBusca
            // 
            this.btnBusca.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusca.Image = global::CRMagazine.Properties.Resources.lupa_24x24;
            this.btnBusca.Location = new System.Drawing.Point(35, 453);
            this.btnBusca.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(43, 33);
            this.btnBusca.TabIndex = 84;
            this.btnBusca.UseVisualStyleBackColor = true;
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // chbVarejista
            // 
            this.chbVarejista.AutoSize = true;
            this.chbVarejista.Location = new System.Drawing.Point(1160, 337);
            this.chbVarejista.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbVarejista.Name = "chbVarejista";
            this.chbVarejista.Size = new System.Drawing.Size(18, 17);
            this.chbVarejista.TabIndex = 87;
            this.chbVarejista.UseVisualStyleBackColor = true;
            this.chbVarejista.CheckedChanged += new System.EventHandler(this.chbVarejista_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(889, 338);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 17);
            this.label9.TabIndex = 86;
            this.label9.Text = "Varejista";
            // 
            // cboVarejista
            // 
            this.cboVarejista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVarejista.Enabled = false;
            this.cboVarejista.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVarejista.FormattingEnabled = true;
            this.cboVarejista.Items.AddRange(new object[] {
            "ViaVarejo",
            "CNOVA",
            "MultiVarejo"});
            this.cboVarejista.Location = new System.Drawing.Point(893, 283);
            this.cboVarejista.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboVarejista.Name = "cboVarejista";
            this.cboVarejista.Size = new System.Drawing.Size(285, 47);
            this.cboVarejista.TabIndex = 88;
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.ForeColor = System.Drawing.Color.Maroon;
            this.lblCT.Location = new System.Drawing.Point(1076, 15);
            this.lblCT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(12, 18);
            this.lblCT.TabIndex = 533;
            this.lblCT.Text = ".";
            // 
            // frmAlterarBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 532);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.cboVarejista);
            this.Controls.Add(this.chbVarejista);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnBusca);
            this.Controls.Add(this.ckbCodPositivo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCodPositivo);
            this.Controls.Add(this.chbDescricao);
            this.Controls.Add(this.chbCodViaVarejo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chbOS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chbNS);
            this.Controls.Add(this.chbData);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCodVarejista);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtNS);
            this.Controls.Add(this.txtOS);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmAlterarBanco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ALTERAÇÃO NO BANCO";
            this.Load += new System.EventHandler(this.frmAlterarBanco_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodVarejista;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtNS;
        private System.Windows.Forms.TextBox txtOS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.CheckBox chbData;
        private System.Windows.Forms.CheckBox chbNS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbOS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.RadioButton rbOS;
        private System.Windows.Forms.RadioButton rbNS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbCodViaVarejo;
        private System.Windows.Forms.CheckBox chbDescricao;
        private System.Windows.Forms.CheckBox ckbCodPositivo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodPositivo;
        private System.Windows.Forms.Button btnBusca;
        private System.Windows.Forms.CheckBox chbVarejista;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboVarejista;
        private System.Windows.Forms.Label lblCT;
    }
}