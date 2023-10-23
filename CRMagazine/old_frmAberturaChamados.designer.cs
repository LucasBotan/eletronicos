namespace CRMagazine
{
    partial class old_frmAberturaChamados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(old_frmAberturaChamados));
            this.dgvParaAbrir = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtEncerramento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConcluir = new System.Windows.Forms.Button();
            this.lblTotalEncerrar = new System.Windows.Forms.Label();
            this.lblComando = new System.Windows.Forms.Label();
            this.txtNumeroChamado = new System.Windows.Forms.TextBox();
            this.lblTotalChamados = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMostrarData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParaAbrir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvParaAbrir
            // 
            this.dgvParaAbrir.AllowUserToAddRows = false;
            this.dgvParaAbrir.AllowUserToDeleteRows = false;
            this.dgvParaAbrir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParaAbrir.Location = new System.Drawing.Point(28, 169);
            this.dgvParaAbrir.Name = "dgvParaAbrir";
            this.dgvParaAbrir.Size = new System.Drawing.Size(318, 492);
            this.dgvParaAbrir.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(24, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "NECESSITAM ABERTURA:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(352, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(557, 59);
            this.label3.TabIndex = 17;
            this.label3.Text = "ABERTURA DE CHAMADOS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CRMagazine.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(28, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(215, 66);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(28, 668);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(10, 13);
            this.lblTotal.TabIndex = 18;
            this.lblTotal.Text = ".";
            // 
            // txtEncerramento
            // 
            this.txtEncerramento.Location = new System.Drawing.Point(446, 166);
            this.txtEncerramento.Multiline = true;
            this.txtEncerramento.Name = "txtEncerramento";
            this.txtEncerramento.Size = new System.Drawing.Size(223, 492);
            this.txtEncerramento.TabIndex = 19;
            this.txtEncerramento.TextChanged += new System.EventHandler(this.txtEncerramento_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(442, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "INSIRA AS NSs";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnConcluir
            // 
            this.btnConcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConcluir.Location = new System.Drawing.Point(987, 602);
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(118, 59);
            this.btnConcluir.TabIndex = 22;
            this.btnConcluir.Text = "CONCLUIR";
            this.btnConcluir.UseVisualStyleBackColor = true;
            this.btnConcluir.Click += new System.EventHandler(this.btnConcluir_Click);
            // 
            // lblTotalEncerrar
            // 
            this.lblTotalEncerrar.AutoSize = true;
            this.lblTotalEncerrar.Location = new System.Drawing.Point(454, 668);
            this.lblTotalEncerrar.Name = "lblTotalEncerrar";
            this.lblTotalEncerrar.Size = new System.Drawing.Size(13, 13);
            this.lblTotalEncerrar.TabIndex = 23;
            this.lblTotalEncerrar.Text = "0";
            this.lblTotalEncerrar.TextChanged += new System.EventHandler(this.lblTotalEncerrar_TextChanged);
            // 
            // lblComando
            // 
            this.lblComando.AutoSize = true;
            this.lblComando.Location = new System.Drawing.Point(359, 153);
            this.lblComando.Name = "lblComando";
            this.lblComando.Size = new System.Drawing.Size(35, 13);
            this.lblComando.TabIndex = 24;
            this.lblComando.Text = "label5";
            this.lblComando.Visible = false;
            // 
            // txtNumeroChamado
            // 
            this.txtNumeroChamado.Location = new System.Drawing.Point(716, 169);
            this.txtNumeroChamado.Multiline = true;
            this.txtNumeroChamado.Name = "txtNumeroChamado";
            this.txtNumeroChamado.Size = new System.Drawing.Size(223, 492);
            this.txtNumeroChamado.TabIndex = 25;
            this.txtNumeroChamado.TextChanged += new System.EventHandler(this.txtNumeroChamado_TextChanged);
            // 
            // lblTotalChamados
            // 
            this.lblTotalChamados.AutoSize = true;
            this.lblTotalChamados.Location = new System.Drawing.Point(723, 668);
            this.lblTotalChamados.Name = "lblTotalChamados";
            this.lblTotalChamados.Size = new System.Drawing.Size(13, 13);
            this.lblTotalChamados.TabIndex = 26;
            this.lblTotalChamados.Text = "0";
            this.lblTotalChamados.TextChanged += new System.EventHandler(this.lblTotalChamados_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(712, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "INSIRA OS CHAMADOS";
            // 
            // btnMostrarData
            // 
            this.btnMostrarData.Location = new System.Drawing.Point(301, 140);
            this.btnMostrarData.Name = "btnMostrarData";
            this.btnMostrarData.Size = new System.Drawing.Size(45, 23);
            this.btnMostrarData.TabIndex = 28;
            this.btnMostrarData.Text = "Datas";
            this.btnMostrarData.UseVisualStyleBackColor = true;
            this.btnMostrarData.Visible = false;
            this.btnMostrarData.Click += new System.EventHandler(this.btnMostrarData_Click);
            // 
            // frmAberturaChamados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 703);
            this.Controls.Add(this.btnMostrarData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTotalChamados);
            this.Controls.Add(this.txtNumeroChamado);
            this.Controls.Add(this.lblComando);
            this.Controls.Add(this.lblTotalEncerrar);
            this.Controls.Add(this.btnConcluir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEncerramento);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvParaAbrir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAberturaChamados";
            this.Text = "frmAberturaChamados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAberturaChamados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParaAbrir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvParaAbrir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtEncerramento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConcluir;
        private System.Windows.Forms.Label lblTotalEncerrar;
        private System.Windows.Forms.Label lblComando;
        private System.Windows.Forms.TextBox txtNumeroChamado;
        private System.Windows.Forms.Label lblTotalChamados;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnMostrarData;
    }
}