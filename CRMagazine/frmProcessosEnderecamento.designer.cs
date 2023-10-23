namespace CRMagazine
{
    partial class frmProcessosEnderecamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessosEnderecamento));
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscarChamado = new System.Windows.Forms.Button();
            this.txtOS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxLocalEnderecamento = new System.Windows.Forms.ComboBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConcluir = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMemorizar = new System.Windows.Forms.TextBox();
            this.btnMemorizar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnLimparMemoria = new System.Windows.Forms.Button();
            this.lblCT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(299, 6);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(20, 29);
            this.lblUsuario.TabIndex = 334;
            this.lblUsuario.Text = ".";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CRMagazine.Properties.Resources.B1;
            this.pictureBox1.Location = new System.Drawing.Point(16, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(275, 108);
            this.pictureBox1.TabIndex = 333;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtModelo
            // 
            this.txtModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelo.Location = new System.Drawing.Point(105, 318);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.ReadOnly = true;
            this.txtModelo.Size = new System.Drawing.Size(731, 30);
            this.txtModelo.TabIndex = 421;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(100, 289);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 25);
            this.label3.TabIndex = 420;
            this.label3.Text = "MODELO";
            // 
            // btnBuscarChamado
            // 
            this.btnBuscarChamado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarChamado.Image = global::CRMagazine.Properties.Resources.lupa_24x24;
            this.btnBuscarChamado.Location = new System.Drawing.Point(432, 236);
            this.btnBuscarChamado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscarChamado.Name = "btnBuscarChamado";
            this.btnBuscarChamado.Size = new System.Drawing.Size(51, 32);
            this.btnBuscarChamado.TabIndex = 427;
            this.btnBuscarChamado.UseVisualStyleBackColor = true;
            this.btnBuscarChamado.Click += new System.EventHandler(this.btnBuscarChamado_Click);
            // 
            // txtOS
            // 
            this.txtOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOS.Location = new System.Drawing.Point(105, 236);
            this.txtOS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOS.Name = "txtOS";
            this.txtOS.Size = new System.Drawing.Size(329, 30);
            this.txtOS.TabIndex = 426;
            this.txtOS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChamado_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 208);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 25);
            this.label2.TabIndex = 425;
            this.label2.Text = "OS";
            // 
            // cbxLocalEnderecamento
            // 
            this.cbxLocalEnderecamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLocalEnderecamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxLocalEnderecamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxLocalEnderecamento.FormattingEnabled = true;
            this.cbxLocalEnderecamento.Location = new System.Drawing.Point(105, 412);
            this.cbxLocalEnderecamento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxLocalEnderecamento.Name = "cbxLocalEnderecamento";
            this.cbxLocalEnderecamento.Size = new System.Drawing.Size(376, 33);
            this.cbxLocalEnderecamento.TabIndex = 429;
            this.cbxLocalEnderecamento.SelectedIndexChanged += new System.EventHandler(this.cbxLocalEnderecamento_SelectedIndexChanged);
            this.cbxLocalEnderecamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxLocalEnderecamento_KeyPress);
            // 
            // txtStatus
            // 
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(491, 236);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(346, 30);
            this.txtStatus.TabIndex = 430;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(487, 208);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 431;
            this.label1.Text = "STATUS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(100, 384);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 25);
            this.label4.TabIndex = 432;
            this.label4.Text = "ENDEREÇAR EM:";
            // 
            // btnConcluir
            // 
            this.btnConcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConcluir.Location = new System.Drawing.Point(695, 412);
            this.btnConcluir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(143, 34);
            this.btnConcluir.TabIndex = 433;
            this.btnConcluir.Text = "CONCLUIR";
            this.btnConcluir.UseVisualStyleBackColor = true;
            this.btnConcluir.Click += new System.EventHandler(this.btnConcluir_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(228, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(488, 73);
            this.label5.TabIndex = 434;
            this.label5.Text = "ENDEREÇAMENTO";
            // 
            // txtMemorizar
            // 
            this.txtMemorizar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMemorizar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMemorizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemorizar.Location = new System.Drawing.Point(105, 498);
            this.txtMemorizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMemorizar.Name = "txtMemorizar";
            this.txtMemorizar.ReadOnly = true;
            this.txtMemorizar.Size = new System.Drawing.Size(377, 30);
            this.txtMemorizar.TabIndex = 437;
            // 
            // btnMemorizar
            // 
            this.btnMemorizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemorizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemorizar.Location = new System.Drawing.Point(105, 460);
            this.btnMemorizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMemorizar.Name = "btnMemorizar";
            this.btnMemorizar.Size = new System.Drawing.Size(112, 31);
            this.btnMemorizar.TabIndex = 438;
            this.btnMemorizar.Text = "MEMORIZAR";
            this.btnMemorizar.UseVisualStyleBackColor = true;
            this.btnMemorizar.Click += new System.EventHandler(this.btnMemorizar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Location = new System.Drawing.Point(544, 412);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(143, 34);
            this.btnLimpar.TabIndex = 439;
            this.btnLimpar.Text = "LIMPAR";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnLimparMemoria
            // 
            this.btnLimparMemoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparMemoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparMemoria.Location = new System.Drawing.Point(371, 460);
            this.btnLimparMemoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimparMemoria.Name = "btnLimparMemoria";
            this.btnLimparMemoria.Size = new System.Drawing.Size(112, 31);
            this.btnLimparMemoria.TabIndex = 440;
            this.btnLimparMemoria.Text = "LIMPA MEM";
            this.btnLimparMemoria.UseVisualStyleBackColor = true;
            this.btnLimparMemoria.Click += new System.EventHandler(this.btnLimparMemoria_Click);
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.ForeColor = System.Drawing.Color.Maroon;
            this.lblCT.Location = new System.Drawing.Point(862, 17);
            this.lblCT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(12, 18);
            this.lblCT.TabIndex = 533;
            this.lblCT.Text = ".";
            // 
            // frmProcessosEnderecamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 597);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.btnLimparMemoria);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnMemorizar);
            this.Controls.Add(this.txtMemorizar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnConcluir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.cbxLocalEnderecamento);
            this.Controls.Add(this.btnBuscarChamado);
            this.Controls.Add(this.txtOS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmProcessosEnderecamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ENDEREÇAMENTO";
            this.Load += new System.EventHandler(this.frmEnderecamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscarChamado;
        private System.Windows.Forms.TextBox txtOS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxLocalEnderecamento;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConcluir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMemorizar;
        private System.Windows.Forms.Button btnMemorizar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnLimparMemoria;
        private System.Windows.Forms.Label lblCT;
    }
}