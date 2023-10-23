namespace CRMagazine
{
    partial class frmImprimirEAN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImprimirEAN));
            this.btnLimpar = new System.Windows.Forms.Button();
            this.chbSelecionarImpressora = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBusca = new System.Windows.Forms.Button();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.lblTipoBusca = new System.Windows.Forms.Label();
            this.btnReimprimir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtBIv = new System.Windows.Forms.RadioButton();
            this.cboTipoBusca = new System.Windows.Forms.Label();
            this.cboBusca = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboVarejista = new System.Windows.Forms.ComboBox();
            this.txtEAN = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCodVarejo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbt220 = new System.Windows.Forms.RadioButton();
            this.rbt110 = new System.Windows.Forms.RadioButton();
            this.chbConfigImpressora = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbSemConexao = new System.Windows.Forms.CheckBox();
            this.lblCT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLimpar
            // 
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Location = new System.Drawing.Point(45, 263);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(103, 31);
            this.btnLimpar.TabIndex = 481;
            this.btnLimpar.Text = "LIMPAR";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // chbSelecionarImpressora
            // 
            this.chbSelecionarImpressora.AutoSize = true;
            this.chbSelecionarImpressora.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbSelecionarImpressora.Location = new System.Drawing.Point(193, 274);
            this.chbSelecionarImpressora.Margin = new System.Windows.Forms.Padding(4);
            this.chbSelecionarImpressora.Name = "chbSelecionarImpressora";
            this.chbSelecionarImpressora.Size = new System.Drawing.Size(188, 19);
            this.chbSelecionarImpressora.TabIndex = 477;
            this.chbSelecionarImpressora.Text = "SELECIONAR IMPRESSORA";
            this.chbSelecionarImpressora.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CRMagazine.Properties.Resources.LOGOBSOFT;
            this.pictureBox1.Location = new System.Drawing.Point(579, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 137);
            this.pictureBox1.TabIndex = 481;
            this.pictureBox1.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(4, 10);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(472, 54);
            this.label20.TabIndex = 430;
            this.label20.Text = "IMPRIMIR ETQ EAN";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(45, 156);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ReadOnly = true;
            this.txtDescricao.Size = new System.Drawing.Size(569, 29);
            this.txtDescricao.TabIndex = 466;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(41, 140);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 17);
            this.label7.TabIndex = 467;
            this.label7.Text = "DESCRIÇÃO";
            // 
            // btnBusca
            // 
            this.btnBusca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusca.Image = global::CRMagazine.Properties.Resources.lupa_24x24;
            this.btnBusca.Location = new System.Drawing.Point(339, 91);
            this.btnBusca.Margin = new System.Windows.Forms.Padding(4);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(56, 36);
            this.btnBusca.TabIndex = 434;
            this.btnBusca.UseVisualStyleBackColor = true;
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // txtBusca
            // 
            this.txtBusca.BackColor = System.Drawing.Color.GhostWhite;
            this.txtBusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusca.Location = new System.Drawing.Point(45, 91);
            this.txtBusca.Margin = new System.Windows.Forms.Padding(4);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(297, 34);
            this.txtBusca.TabIndex = 432;
            this.txtBusca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusca_KeyPress);
            // 
            // lblTipoBusca
            // 
            this.lblTipoBusca.AutoSize = true;
            this.lblTipoBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoBusca.Location = new System.Drawing.Point(41, 68);
            this.lblTipoBusca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoBusca.Name = "lblTipoBusca";
            this.lblTipoBusca.Size = new System.Drawing.Size(47, 24);
            this.lblTipoBusca.TabIndex = 433;
            this.lblTipoBusca.Text = "SKU";
            // 
            // btnReimprimir
            // 
            this.btnReimprimir.Image = global::CRMagazine.Properties.Resources.REIMPRIMIR;
            this.btnReimprimir.Location = new System.Drawing.Point(544, 228);
            this.btnReimprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnReimprimir.Name = "btnReimprimir";
            this.btnReimprimir.Size = new System.Drawing.Size(72, 66);
            this.btnReimprimir.TabIndex = 431;
            this.btnReimprimir.UseVisualStyleBackColor = true;
            this.btnReimprimir.Click += new System.EventHandler(this.btnReimprimir_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.rbtBIv);
            this.panel2.Controls.Add(this.cboTipoBusca);
            this.panel2.Controls.Add(this.cboBusca);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cboVarejista);
            this.panel2.Controls.Add(this.txtEAN);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtCodVarejo);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtSKU);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.rbt220);
            this.panel2.Controls.Add(this.rbt110);
            this.panel2.Controls.Add(this.chbConfigImpressora);
            this.panel2.Controls.Add(this.btnLimpar);
            this.panel2.Controls.Add(this.chbSelecionarImpressora);
            this.panel2.Controls.Add(this.txtDescricao);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnBusca);
            this.panel2.Controls.Add(this.txtBusca);
            this.panel2.Controls.Add(this.lblTipoBusca);
            this.panel2.Controls.Add(this.btnReimprimir);
            this.panel2.Location = new System.Drawing.Point(89, 159);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 322);
            this.panel2.TabIndex = 483;
            // 
            // rbtBIv
            // 
            this.rbtBIv.AutoSize = true;
            this.rbtBIv.Location = new System.Drawing.Point(639, 274);
            this.rbtBIv.Margin = new System.Windows.Forms.Padding(4);
            this.rbtBIv.Name = "rbtBIv";
            this.rbtBIv.Size = new System.Drawing.Size(50, 21);
            this.rbtBIv.TabIndex = 500;
            this.rbtBIv.TabStop = true;
            this.rbtBIv.Text = "BIV";
            this.rbtBIv.UseVisualStyleBackColor = true;
            // 
            // cboTipoBusca
            // 
            this.cboTipoBusca.AutoSize = true;
            this.cboTipoBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoBusca.Location = new System.Drawing.Point(41, 12);
            this.cboTipoBusca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cboTipoBusca.Name = "cboTipoBusca";
            this.cboTipoBusca.Size = new System.Drawing.Size(92, 17);
            this.cboTipoBusca.TabIndex = 499;
            this.cboTipoBusca.Text = "BUSCA POR:";
            // 
            // cboBusca
            // 
            this.cboBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBusca.FormattingEnabled = true;
            this.cboBusca.Items.AddRange(new object[] {
            "CÓDIGO VAREJO",
            "EAN",
            "SKU"});
            this.cboBusca.Location = new System.Drawing.Point(45, 28);
            this.cboBusca.Margin = new System.Windows.Forms.Padding(4);
            this.cboBusca.Name = "cboBusca";
            this.cboBusca.Size = new System.Drawing.Size(245, 28);
            this.cboBusca.TabIndex = 498;
            this.cboBusca.SelectedValueChanged += new System.EventHandler(this.cboBusca_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(364, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 497;
            this.label1.Text = "VAREJISTA";
            // 
            // cboVarejista
            // 
            this.cboVarejista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVarejista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVarejista.FormattingEnabled = true;
            this.cboVarejista.Items.AddRange(new object[] {
            "VIAVAREJO",
            "MAGAZINE",
            "CNOVA",
            "MULTIVAREJO",
            "AMERICANAS",
            "B2W",
            "EXTERNO"});
            this.cboVarejista.Location = new System.Drawing.Point(368, 28);
            this.cboVarejista.Margin = new System.Windows.Forms.Padding(4);
            this.cboVarejista.Name = "cboVarejista";
            this.cboVarejista.Size = new System.Drawing.Size(245, 28);
            this.cboVarejista.TabIndex = 496;
            // 
            // txtEAN
            // 
            this.txtEAN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEAN.Location = new System.Drawing.Point(220, 206);
            this.txtEAN.Margin = new System.Windows.Forms.Padding(4);
            this.txtEAN.Name = "txtEAN";
            this.txtEAN.ReadOnly = true;
            this.txtEAN.Size = new System.Drawing.Size(222, 29);
            this.txtEAN.TabIndex = 494;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(216, 190);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 17);
            this.label9.TabIndex = 495;
            this.label9.Text = "EAN";
            // 
            // txtCodVarejo
            // 
            this.txtCodVarejo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodVarejo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodVarejo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodVarejo.Location = new System.Drawing.Point(475, 97);
            this.txtCodVarejo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodVarejo.Name = "txtCodVarejo";
            this.txtCodVarejo.ReadOnly = true;
            this.txtCodVarejo.Size = new System.Drawing.Size(139, 29);
            this.txtCodVarejo.TabIndex = 492;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(471, 81);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 17);
            this.label8.TabIndex = 493;
            this.label8.Text = "COD VAREJO";
            // 
            // txtSKU
            // 
            this.txtSKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSKU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSKU.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSKU.Location = new System.Drawing.Point(45, 206);
            this.txtSKU.Margin = new System.Windows.Forms.Padding(4);
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.ReadOnly = true;
            this.txtSKU.Size = new System.Drawing.Size(162, 29);
            this.txtSKU.TabIndex = 490;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 190);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 491;
            this.label3.Text = "SKU";
            // 
            // rbt220
            // 
            this.rbt220.AutoSize = true;
            this.rbt220.Location = new System.Drawing.Point(639, 251);
            this.rbt220.Margin = new System.Windows.Forms.Padding(4);
            this.rbt220.Name = "rbt220";
            this.rbt220.Size = new System.Drawing.Size(62, 21);
            this.rbt220.TabIndex = 447;
            this.rbt220.TabStop = true;
            this.rbt220.Text = "220V";
            this.rbt220.UseVisualStyleBackColor = true;
            // 
            // rbt110
            // 
            this.rbt110.AutoSize = true;
            this.rbt110.Location = new System.Drawing.Point(639, 229);
            this.rbt110.Margin = new System.Windows.Forms.Padding(4);
            this.rbt110.Name = "rbt110";
            this.rbt110.Size = new System.Drawing.Size(62, 21);
            this.rbt110.TabIndex = 446;
            this.rbt110.TabStop = true;
            this.rbt110.Text = "110V";
            this.rbt110.UseVisualStyleBackColor = true;
            // 
            // chbConfigImpressora
            // 
            this.chbConfigImpressora.AutoSize = true;
            this.chbConfigImpressora.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbConfigImpressora.Location = new System.Drawing.Point(193, 254);
            this.chbConfigImpressora.Margin = new System.Windows.Forms.Padding(4);
            this.chbConfigImpressora.Name = "chbConfigImpressora";
            this.chbConfigImpressora.Size = new System.Drawing.Size(212, 19);
            this.chbConfigImpressora.TabIndex = 489;
            this.chbConfigImpressora.Text = "USAR CONFIG DA IMPRESSORA";
            this.chbConfigImpressora.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.label20);
            this.panel1.Location = new System.Drawing.Point(-3, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 71);
            this.panel1.TabIndex = 482;
            // 
            // chbSemConexao
            // 
            this.chbSemConexao.AutoSize = true;
            this.chbSemConexao.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbSemConexao.Location = new System.Drawing.Point(85, 132);
            this.chbSemConexao.Margin = new System.Windows.Forms.Padding(4);
            this.chbSemConexao.Name = "chbSemConexao";
            this.chbSemConexao.Size = new System.Drawing.Size(89, 19);
            this.chbSemConexao.TabIndex = 490;
            this.chbSemConexao.Text = "USAR EAN";
            this.chbSemConexao.UseVisualStyleBackColor = true;
            this.chbSemConexao.Visible = false;
            this.chbSemConexao.CheckedChanged += new System.EventHandler(this.chbUsarEAN_CheckedChanged);
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.ForeColor = System.Drawing.Color.Maroon;
            this.lblCT.Location = new System.Drawing.Point(482, 106);
            this.lblCT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(12, 18);
            this.lblCT.TabIndex = 533;
            this.lblCT.Text = ".";
            // 
            // frmImprimirEAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 496);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.chbSemConexao);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmImprimirEAN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IMPRIMIR ETIQUETA EAN";
            this.Load += new System.EventHandler(this.frmImprimirEAN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.CheckBox chbSelecionarImpressora;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBusca;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label lblTipoBusca;
        private System.Windows.Forms.Button btnReimprimir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chbConfigImpressora;
        private System.Windows.Forms.RadioButton rbt220;
        private System.Windows.Forms.RadioButton rbt110;
        private System.Windows.Forms.CheckBox chbSemConexao;
        private System.Windows.Forms.TextBox txtEAN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCodVarejo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label cboTipoBusca;
        private System.Windows.Forms.ComboBox cboBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboVarejista;
        private System.Windows.Forms.RadioButton rbtBIv;
        private System.Windows.Forms.Label lblCT;
    }
}