namespace CRMagazine
{
    partial class frmInserirModelo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInserirModelo));
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodVarejo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.btnConcluir = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTipoEquip = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEAN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboVarejista = new System.Windows.Forms.ComboBox();
            this.lblCT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(405, 101);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(413, 61);
            this.label7.TabIndex = 75;
            this.label7.Text = "INSERIR PRODUTO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CRMagazine.Properties.Resources.B1;
            this.pictureBox1.Location = new System.Drawing.Point(32, 17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(289, 114);
            this.pictureBox1.TabIndex = 76;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 80;
            this.label6.Text = "DESCRIÇÃO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 17);
            this.label4.TabIndex = 79;
            this.label4.Text = "CÓDIGO VAREJO";
            // 
            // txtCodVarejo
            // 
            this.txtCodVarejo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodVarejo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodVarejo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodVarejo.Location = new System.Drawing.Point(19, 32);
            this.txtCodVarejo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodVarejo.Name = "txtCodVarejo";
            this.txtCodVarejo.Size = new System.Drawing.Size(213, 34);
            this.txtCodVarejo.TabIndex = 1;
            this.txtCodVarejo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodVarejista_KeyPress);
            this.txtCodVarejo.Leave += new System.EventHandler(this.txtCodVarejo_Leave);
            // 
            // txtDescricao
            // 
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(268, 32);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(857, 34);
            this.txtDescricao.TabIndex = 77;
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            // 
            // btnConcluir
            // 
            this.btnConcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConcluir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConcluir.Location = new System.Drawing.Point(212, 28);
            this.btnConcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(151, 59);
            this.btnConcluir.TabIndex = 81;
            this.btnConcluir.Text = "CONCLUIR";
            this.btnConcluir.UseVisualStyleBackColor = true;
            this.btnConcluir.Click += new System.EventHandler(this.btnConcluir_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 89);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 17);
            this.label10.TabIndex = 89;
            this.label10.Text = "SKU";
            // 
            // txtSKU
            // 
            this.txtSKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSKU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSKU.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSKU.Location = new System.Drawing.Point(19, 108);
            this.txtSKU.Margin = new System.Windows.Forms.Padding(4);
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Size = new System.Drawing.Size(213, 34);
            this.txtSKU.TabIndex = 88;
            this.txtSKU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSKU_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 17);
            this.label1.TabIndex = 91;
            this.label1.Text = "TIPO EQUIPAMENTO";
            // 
            // txtTipoEquip
            // 
            this.txtTipoEquip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoEquip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoEquip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoEquip.Location = new System.Drawing.Point(268, 108);
            this.txtTipoEquip.Margin = new System.Windows.Forms.Padding(4);
            this.txtTipoEquip.Name = "txtTipoEquip";
            this.txtTipoEquip.Size = new System.Drawing.Size(269, 34);
            this.txtTipoEquip.TabIndex = 90;
            this.txtTipoEquip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTipoEquip_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.txtEAN);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTipoEquip);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.txtCodVarejo);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSKU);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(51, 235);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1145, 160);
            this.panel1.TabIndex = 92;
            // 
            // txtEAN
            // 
            this.txtEAN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEAN.Location = new System.Drawing.Point(572, 108);
            this.txtEAN.Margin = new System.Windows.Forms.Padding(4);
            this.txtEAN.Name = "txtEAN";
            this.txtEAN.Size = new System.Drawing.Size(246, 34);
            this.txtEAN.TabIndex = 92;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(568, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 93;
            this.label2.Text = "EAN";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.btnLimpar);
            this.panel2.Controls.Add(this.btnConcluir);
            this.panel2.Location = new System.Drawing.Point(813, 414);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(383, 103);
            this.panel2.TabIndex = 93;
            // 
            // btnLimpar
            // 
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(20, 39);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(131, 48);
            this.btnLimpar.TabIndex = 434;
            this.btnLimpar.Text = "LIMPAR";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 499;
            this.label3.Text = "VAREJISTA";
            // 
            // cboVarejista
            // 
            this.cboVarejista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVarejista.FormattingEnabled = true;
            this.cboVarejista.Items.AddRange(new object[] {
            "VIAVAREJO",
            "MAGAZINE",
            "CNOVA",
            "MULTIVAREJO",
            "AMERICANAS",
            "B2W",
            "EXTERNO"});
            this.cboVarejista.Location = new System.Drawing.Point(51, 193);
            this.cboVarejista.Margin = new System.Windows.Forms.Padding(4);
            this.cboVarejista.Name = "cboVarejista";
            this.cboVarejista.Size = new System.Drawing.Size(355, 33);
            this.cboVarejista.TabIndex = 498;
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.ForeColor = System.Drawing.Color.Maroon;
            this.lblCT.Location = new System.Drawing.Point(1121, 17);
            this.lblCT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(12, 18);
            this.lblCT.TabIndex = 533;
            this.lblCT.Text = ".";
            // 
            // frmInserirModelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 532);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cboVarejista);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInserirModelo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INSERIR PRODUTO";
            this.Load += new System.EventHandler(this.frmInserirModelo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodVarejo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Button btnConcluir;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTipoEquip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.TextBox txtEAN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboVarejista;
        private System.Windows.Forms.Label lblCT;
    }
}