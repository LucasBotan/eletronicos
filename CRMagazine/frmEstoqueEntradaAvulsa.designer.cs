namespace CRMagazine
{
    partial class frmEstoqueEntradaAvulsa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstoqueEntradaAvulsa));
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLimparTela = new System.Windows.Forms.Button();
            this.btnEntrada = new System.Windows.Forms.Button();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodPeca = new System.Windows.Forms.TextBox();
            this.txtDescPeca = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblCT = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(263, 148);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(494, 54);
            this.label6.TabIndex = 292;
            this.label6.Text = "ENTRADA DE PEÇAS";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel3.Controls.Add(this.txtTipo);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnLimparTela);
            this.panel3.Controls.Add(this.btnEntrada);
            this.panel3.Controls.Add(this.txtQuantidade);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtCodPeca);
            this.panel3.Controls.Add(this.txtDescPeca);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Location = new System.Drawing.Point(32, 213);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(969, 206);
            this.panel3.TabIndex = 291;
            // 
            // txtTipo
            // 
            this.txtTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo.Location = new System.Drawing.Point(235, 151);
            this.txtTipo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTipo.MaxLength = 50;
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(199, 37);
            this.txtTipo.TabIndex = 295;
            this.txtTipo.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(229, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 29);
            this.label2.TabIndex = 296;
            this.label2.Text = "Tipo";
            this.label2.Visible = false;
            // 
            // btnLimparTela
            // 
            this.btnLimparTela.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparTela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparTela.Location = new System.Drawing.Point(545, 154);
            this.btnLimparTela.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimparTela.Name = "btnLimparTela";
            this.btnLimparTela.Size = new System.Drawing.Size(135, 36);
            this.btnLimparTela.TabIndex = 294;
            this.btnLimparTela.Text = "LIMPAR TELA";
            this.btnLimparTela.UseVisualStyleBackColor = true;
            this.btnLimparTela.Click += new System.EventHandler(this.btnLimparTela_Click);
            // 
            // btnEntrada
            // 
            this.btnEntrada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrada.Location = new System.Drawing.Point(780, 130);
            this.btnEntrada.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(144, 58);
            this.btnEntrada.TabIndex = 279;
            this.btnEntrada.Text = "ENTRADA";
            this.btnEntrada.UseVisualStyleBackColor = true;
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.Location = new System.Drawing.Point(27, 151);
            this.txtQuantidade.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtQuantidade.MaxLength = 50;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(199, 37);
            this.txtQuantidade.TabIndex = 277;
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 118);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 29);
            this.label1.TabIndex = 278;
            this.label1.Text = "Quantidade";
            // 
            // txtCodPeca
            // 
            this.txtCodPeca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodPeca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodPeca.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodPeca.Location = new System.Drawing.Point(27, 64);
            this.txtCodPeca.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodPeca.MaxLength = 50;
            this.txtCodPeca.Name = "txtCodPeca";
            this.txtCodPeca.Size = new System.Drawing.Size(199, 37);
            this.txtCodPeca.TabIndex = 273;
            this.txtCodPeca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodPeca_KeyPress);
            // 
            // txtDescPeca
            // 
            this.txtDescPeca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescPeca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescPeca.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescPeca.Location = new System.Drawing.Point(235, 64);
            this.txtDescPeca.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescPeca.MaxLength = 50;
            this.txtDescPeca.Name = "txtDescPeca";
            this.txtDescPeca.ReadOnly = true;
            this.txtDescPeca.Size = new System.Drawing.Size(689, 37);
            this.txtDescPeca.TabIndex = 274;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(21, 31);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(186, 29);
            this.label16.TabIndex = 275;
            this.label16.Text = "Código da Peça";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(229, 30);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(215, 29);
            this.label17.TabIndex = 276;
            this.label17.Text = "Descrição da Peça";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox2.Image = global::CRMagazine.Properties.Resources.LOGOBSOFT;
            this.pictureBox2.Location = new System.Drawing.Point(4, 7);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(303, 137);
            this.pictureBox2.TabIndex = 293;
            this.pictureBox2.TabStop = false;
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.ForeColor = System.Drawing.Color.Maroon;
            this.lblCT.Location = new System.Drawing.Point(902, 20);
            this.lblCT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(12, 18);
            this.lblCT.TabIndex = 533;
            this.lblCT.Text = ".";
            // 
            // frmEstoqueEntradaAvulsa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 500);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmEstoqueEntradaAvulsa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ENTRADA DE PEÇAS";
            this.Load += new System.EventHandler(this.frmEstoqueEntradaSeparada_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCodPeca;
        private System.Windows.Forms.TextBox txtDescPeca;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Button btnLimparTela;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCT;
    }
}