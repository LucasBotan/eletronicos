namespace CRMagazine
{
    partial class frmLocalizador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocalizador));
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOS = new System.Windows.Forms.TextBox();
            this.txtOsParaLocalizar = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalListagem = new System.Windows.Forms.Label();
            this.lblTotalConferido = new System.Windows.Forms.Label();
            this.lstConferido = new System.Windows.Forms.ListBox();
            this.lstRestante = new System.Windows.Forms.ListBox();
            this.lblRestante = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCopiarRestante = new System.Windows.Forms.Button();
            this.btnCopiarConferido = new System.Windows.Forms.Button();
            this.lblCT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 29);
            this.label1.TabIndex = 122;
            this.label1.Text = "LISTAGEM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(413, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(189, 54);
            this.label9.TabIndex = 121;
            this.label9.Text = "BUSCA";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(450, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(508, 97);
            this.label5.TabIndex = 119;
            this.label5.Text = "LOCALIZADOR";
            // 
            // txtOS
            // 
            this.txtOS.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOS.Location = new System.Drawing.Point(580, 270);
            this.txtOS.Name = "txtOS";
            this.txtOS.Size = new System.Drawing.Size(307, 60);
            this.txtOS.TabIndex = 118;
            this.txtOS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOS_KeyPress);
            // 
            // txtOsParaLocalizar
            // 
            this.txtOsParaLocalizar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtOsParaLocalizar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOsParaLocalizar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOsParaLocalizar.Location = new System.Drawing.Point(31, 127);
            this.txtOsParaLocalizar.Multiline = true;
            this.txtOsParaLocalizar.Name = "txtOsParaLocalizar";
            this.txtOsParaLocalizar.Size = new System.Drawing.Size(149, 514);
            this.txtOsParaLocalizar.TabIndex = 117;
            this.txtOsParaLocalizar.TextChanged += new System.EventHandler(this.txtOsParaLocalizar_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.Image = global::CRMagazine.Properties.Resources.B1;
            this.pictureBox1.Location = new System.Drawing.Point(12, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 98);
            this.pictureBox1.TabIndex = 120;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(972, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 29);
            this.label2.TabIndex = 124;
            this.label2.Text = "CONFERIDO";
            // 
            // lblTotalListagem
            // 
            this.lblTotalListagem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalListagem.AutoSize = true;
            this.lblTotalListagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalListagem.Location = new System.Drawing.Point(96, 644);
            this.lblTotalListagem.Name = "lblTotalListagem";
            this.lblTotalListagem.Size = new System.Drawing.Size(17, 25);
            this.lblTotalListagem.TabIndex = 125;
            this.lblTotalListagem.Text = ".";
            // 
            // lblTotalConferido
            // 
            this.lblTotalConferido.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalConferido.AutoSize = true;
            this.lblTotalConferido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalConferido.Location = new System.Drawing.Point(972, 657);
            this.lblTotalConferido.Name = "lblTotalConferido";
            this.lblTotalConferido.Size = new System.Drawing.Size(17, 25);
            this.lblTotalConferido.TabIndex = 126;
            this.lblTotalConferido.Text = ".";
            // 
            // lstConferido
            // 
            this.lstConferido.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lstConferido.FormattingEnabled = true;
            this.lstConferido.ItemHeight = 16;
            this.lstConferido.Location = new System.Drawing.Point(976, 195);
            this.lstConferido.Name = "lstConferido";
            this.lstConferido.Size = new System.Drawing.Size(120, 452);
            this.lstConferido.TabIndex = 127;
            // 
            // lstRestante
            // 
            this.lstRestante.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lstRestante.FormattingEnabled = true;
            this.lstRestante.ItemHeight = 16;
            this.lstRestante.Location = new System.Drawing.Point(229, 195);
            this.lstRestante.Name = "lstRestante";
            this.lstRestante.Size = new System.Drawing.Size(120, 436);
            this.lstRestante.TabIndex = 129;
            // 
            // lblRestante
            // 
            this.lblRestante.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblRestante.AutoSize = true;
            this.lblRestante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestante.Location = new System.Drawing.Point(225, 644);
            this.lblRestante.Name = "lblRestante";
            this.lblRestante.Size = new System.Drawing.Size(17, 25);
            this.lblRestante.TabIndex = 128;
            this.lblRestante.Text = ".";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(225, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 29);
            this.label4.TabIndex = 130;
            this.label4.Text = "RESTANTE";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(145, 99);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(34, 25);
            this.btnOK.TabIndex = 131;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 644);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 132;
            this.label3.Text = "TOTAL:";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStatus.Location = new System.Drawing.Point(466, 371);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 52);
            this.lblStatus.TabIndex = 133;
            // 
            // btnCopiarRestante
            // 
            this.btnCopiarRestante.Location = new System.Drawing.Point(308, 644);
            this.btnCopiarRestante.Name = "btnCopiarRestante";
            this.btnCopiarRestante.Size = new System.Drawing.Size(41, 23);
            this.btnCopiarRestante.TabIndex = 134;
            this.btnCopiarRestante.Text = "Copy";
            this.btnCopiarRestante.UseVisualStyleBackColor = true;
            this.btnCopiarRestante.Click += new System.EventHandler(this.btnCopiarRestante_Click);
            // 
            // btnCopiarConferido
            // 
            this.btnCopiarConferido.Location = new System.Drawing.Point(1057, 657);
            this.btnCopiarConferido.Name = "btnCopiarConferido";
            this.btnCopiarConferido.Size = new System.Drawing.Size(39, 23);
            this.btnCopiarConferido.TabIndex = 135;
            this.btnCopiarConferido.Text = "Copy";
            this.btnCopiarConferido.UseVisualStyleBackColor = true;
            this.btnCopiarConferido.Click += new System.EventHandler(this.btnCopiarConferido_Click);
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.ForeColor = System.Drawing.Color.Maroon;
            this.lblCT.Location = new System.Drawing.Point(1113, 9);
            this.lblCT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(12, 18);
            this.lblCT.TabIndex = 533;
            this.lblCT.Text = ".";
            // 
            // frmLocalizador
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1241, 704);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.btnCopiarConferido);
            this.Controls.Add(this.btnCopiarRestante);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstRestante);
            this.Controls.Add(this.lblRestante);
            this.Controls.Add(this.lstConferido);
            this.Controls.Add(this.lblTotalConferido);
            this.Controls.Add(this.lblTotalListagem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOS);
            this.Controls.Add(this.txtOsParaLocalizar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLocalizador";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOCALIZADOR";
            this.Load += new System.EventHandler(this.frmLocalizador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOS;
        private System.Windows.Forms.TextBox txtOsParaLocalizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalListagem;
        private System.Windows.Forms.Label lblTotalConferido;
        private System.Windows.Forms.ListBox lstConferido;
        private System.Windows.Forms.ListBox lstRestante;
        private System.Windows.Forms.Label lblRestante;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnCopiarRestante;
        private System.Windows.Forms.Button btnCopiarConferido;
        private System.Windows.Forms.Label lblCT;
    }
}