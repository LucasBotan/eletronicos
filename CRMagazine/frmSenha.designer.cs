namespace CRMagazine
{
    partial class frmSenha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSenha));
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlVolts = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtVolts = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAmper = new System.Windows.Forms.TextBox();
            this.lblCT = new System.Windows.Forms.Label();
            this.pnlVolts.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTexto
            // 
            this.txtTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexto.Location = new System.Drawing.Point(55, 140);
            this.txtTexto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.PasswordChar = '*';
            this.txtTexto.Size = new System.Drawing.Size(307, 37);
            this.txtTexto.TabIndex = 0;
            this.txtTexto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "EQUIPAMENTO COM 3G";
            this.label1.Visible = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(81, 95);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(23, 31);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = ".";
            // 
            // pnlVolts
            // 
            this.pnlVolts.Controls.Add(this.btnOK);
            this.pnlVolts.Controls.Add(this.txtVolts);
            this.pnlVolts.Controls.Add(this.label15);
            this.pnlVolts.Controls.Add(this.label14);
            this.pnlVolts.Controls.Add(this.txtAmper);
            this.pnlVolts.Location = new System.Drawing.Point(55, 186);
            this.pnlVolts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlVolts.Name = "pnlVolts";
            this.pnlVolts.Size = new System.Drawing.Size(308, 63);
            this.pnlVolts.TabIndex = 295;
            this.pnlVolts.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(228, 11);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(60, 48);
            this.btnOK.TabIndex = 294;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtVolts
            // 
            this.txtVolts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVolts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVolts.Location = new System.Drawing.Point(16, 27);
            this.txtVolts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVolts.Name = "txtVolts";
            this.txtVolts.Size = new System.Drawing.Size(63, 30);
            this.txtVolts.TabIndex = 290;
            this.txtVolts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVolts_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(113, 11);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 17);
            this.label15.TabIndex = 293;
            this.label15.Text = "Amperagem";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 11);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 17);
            this.label14.TabIndex = 291;
            this.label14.Text = "Voltagem";
            // 
            // txtAmper
            // 
            this.txtAmper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmper.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmper.Location = new System.Drawing.Point(117, 27);
            this.txtAmper.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAmper.Name = "txtAmper";
            this.txtAmper.Size = new System.Drawing.Size(71, 30);
            this.txtAmper.TabIndex = 292;
            this.txtAmper.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmper_KeyPress);
            // 
            // lblCT
            // 
            this.lblCT.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.ForeColor = System.Drawing.Color.Maroon;
            this.lblCT.Location = new System.Drawing.Point(297, 9);
            this.lblCT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(18, 25);
            this.lblCT.TabIndex = 296;
            this.lblCT.Text = ".";
            // 
            // frmSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 263);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.pnlVolts);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTexto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSenha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TELA DE SENHA";
            this.Load += new System.EventHandler(this.frmRecebeTexto_Load);
            this.pnlVolts.ResumeLayout(false);
            this.pnlVolts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlVolts;
        private System.Windows.Forms.TextBox txtVolts;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAmper;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblCT;
    }
}