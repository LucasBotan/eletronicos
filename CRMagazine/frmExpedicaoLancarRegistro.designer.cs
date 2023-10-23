namespace CRMagazine
{
    partial class frmExpedicaoLancarRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpedicaoLancarRegistro));
            this.lblTotalRomaneio = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.dgvRomaneio = new System.Windows.Forms.DataGridView();
            this.chbColuna = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblContador = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtRegistroVarejista = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConcluir = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGeraExcel = new System.Windows.Forms.Button();
            this.btnMarcarTudo = new System.Windows.Forms.Button();
            this.btnDesmarcar = new System.Windows.Forms.Button();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblCT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlConcluir = new System.Windows.Forms.Panel();
            this.pnlAlterar = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRegistroAntigo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRegistroNovo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOSAlterar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAlterar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRomaneio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlConcluir.SuspendLayout();
            this.pnlAlterar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotalRomaneio
            // 
            this.lblTotalRomaneio.AutoSize = true;
            this.lblTotalRomaneio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRomaneio.Location = new System.Drawing.Point(153, 150);
            this.lblTotalRomaneio.Name = "lblTotalRomaneio";
            this.lblTotalRomaneio.Size = new System.Drawing.Size(13, 18);
            this.lblTotalRomaneio.TabIndex = 533;
            this.lblTotalRomaneio.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(101, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 18);
            this.label6.TabIndex = 532;
            this.label6.Text = "Total: ";
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualizar.Location = new System.Drawing.Point(764, 142);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(68, 26);
            this.btnVisualizar.TabIndex = 531;
            this.btnVisualizar.Text = "FILTRAR";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // dgvRomaneio
            // 
            this.dgvRomaneio.AllowUserToAddRows = false;
            this.dgvRomaneio.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRomaneio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRomaneio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRomaneio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chbColuna});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRomaneio.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRomaneio.Location = new System.Drawing.Point(104, 171);
            this.dgvRomaneio.Name = "dgvRomaneio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRomaneio.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRomaneio.Size = new System.Drawing.Size(728, 374);
            this.dgvRomaneio.TabIndex = 530;
            // 
            // chbColuna
            // 
            this.chbColuna.HeaderText = "Selecionar";
            this.chbColuna.Name = "chbColuna";
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContador.Location = new System.Drawing.Point(246, 41);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(16, 24);
            this.lblContador.TabIndex = 536;
            this.lblContador.Text = ".";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(246, 6);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(16, 24);
            this.lblUsuario.TabIndex = 535;
            this.lblUsuario.Text = ".";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CRMagazine.Properties.Resources.LOGOBSOFT;
            this.pictureBox1.Location = new System.Drawing.Point(8, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(217, 117);
            this.pictureBox1.TabIndex = 534;
            this.pictureBox1.TabStop = false;
            // 
            // txtRegistroVarejista
            // 
            this.txtRegistroVarejista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegistroVarejista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistroVarejista.Location = new System.Drawing.Point(351, 12);
            this.txtRegistroVarejista.Name = "txtRegistroVarejista";
            this.txtRegistroVarejista.Size = new System.Drawing.Size(237, 26);
            this.txtRegistroVarejista.TabIndex = 538;
            this.txtRegistroVarejista.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(143, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 18);
            this.label2.TabIndex = 540;
            this.label2.Text = "REGISTRO VAREJISTA";
            // 
            // btnConcluir
            // 
            this.btnConcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConcluir.Location = new System.Drawing.Point(604, 12);
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(106, 26);
            this.btnConcluir.TabIndex = 541;
            this.btnConcluir.Text = "CONCLUIR";
            this.btnConcluir.UseVisualStyleBackColor = true;
            this.btnConcluir.Click += new System.EventHandler(this.btnConcluir_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(242, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(471, 45);
            this.label5.TabIndex = 542;
            this.label5.Text = "LANÇAR REGISTRO VAREJISTA";
            // 
            // btnGeraExcel
            // 
            this.btnGeraExcel.Image = global::CRMagazine.Properties.Resources.excel;
            this.btnGeraExcel.Location = new System.Drawing.Point(11, 274);
            this.btnGeraExcel.Name = "btnGeraExcel";
            this.btnGeraExcel.Size = new System.Drawing.Size(43, 45);
            this.btnGeraExcel.TabIndex = 546;
            this.btnGeraExcel.UseVisualStyleBackColor = true;
            this.btnGeraExcel.Visible = false;
            this.btnGeraExcel.Click += new System.EventHandler(this.btnGeraExcel_Click);
            // 
            // btnMarcarTudo
            // 
            this.btnMarcarTudo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcarTudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarcarTudo.Location = new System.Drawing.Point(11, 193);
            this.btnMarcarTudo.Name = "btnMarcarTudo";
            this.btnMarcarTudo.Size = new System.Drawing.Size(87, 26);
            this.btnMarcarTudo.TabIndex = 548;
            this.btnMarcarTudo.Text = "MARCAR TUDO";
            this.btnMarcarTudo.UseVisualStyleBackColor = true;
            this.btnMarcarTudo.Click += new System.EventHandler(this.btnMarcarTudo_Click);
            // 
            // btnDesmarcar
            // 
            this.btnDesmarcar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesmarcar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesmarcar.Location = new System.Drawing.Point(11, 225);
            this.btnDesmarcar.Name = "btnDesmarcar";
            this.btnDesmarcar.Size = new System.Drawing.Size(87, 26);
            this.btnDesmarcar.TabIndex = 547;
            this.btnDesmarcar.Text = "DESMARCAR";
            this.btnDesmarcar.UseVisualStyleBackColor = true;
            this.btnDesmarcar.Click += new System.EventHandler(this.btnDesmarcar_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(562, 142);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(196, 26);
            this.txtFiltro.TabIndex = 549;
            this.txtFiltro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.ForeColor = System.Drawing.Color.Maroon;
            this.lblCT.Location = new System.Drawing.Point(809, 9);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(10, 14);
            this.lblCT.TabIndex = 550;
            this.lblCT.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(559, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 18);
            this.label1.TabIndex = 551;
            this.label1.Text = "FILTRAR POR DATA";
            // 
            // pnlConcluir
            // 
            this.pnlConcluir.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlConcluir.Controls.Add(this.txtRegistroVarejista);
            this.pnlConcluir.Controls.Add(this.label2);
            this.pnlConcluir.Controls.Add(this.btnConcluir);
            this.pnlConcluir.Location = new System.Drawing.Point(104, 551);
            this.pnlConcluir.Name = "pnlConcluir";
            this.pnlConcluir.Size = new System.Drawing.Size(728, 47);
            this.pnlConcluir.TabIndex = 552;
            // 
            // pnlAlterar
            // 
            this.pnlAlterar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlAlterar.Controls.Add(this.label8);
            this.pnlAlterar.Controls.Add(this.txtRegistroAntigo);
            this.pnlAlterar.Controls.Add(this.label7);
            this.pnlAlterar.Controls.Add(this.txtRegistroNovo);
            this.pnlAlterar.Controls.Add(this.label4);
            this.pnlAlterar.Controls.Add(this.txtOSAlterar);
            this.pnlAlterar.Controls.Add(this.label3);
            this.pnlAlterar.Controls.Add(this.btnAlterar);
            this.pnlAlterar.Location = new System.Drawing.Point(104, 603);
            this.pnlAlterar.Name = "pnlAlterar";
            this.pnlAlterar.Size = new System.Drawing.Size(728, 67);
            this.pnlAlterar.TabIndex = 553;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(199, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 16);
            this.label8.TabIndex = 546;
            this.label8.Text = "REGISTRO ANTIGO";
            // 
            // txtRegistroAntigo
            // 
            this.txtRegistroAntigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegistroAntigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistroAntigo.Location = new System.Drawing.Point(202, 33);
            this.txtRegistroAntigo.Name = "txtRegistroAntigo";
            this.txtRegistroAntigo.Size = new System.Drawing.Size(151, 26);
            this.txtRegistroAntigo.TabIndex = 545;
            this.txtRegistroAntigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(415, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 16);
            this.label7.TabIndex = 544;
            this.label7.Text = "REGISTRO NOVO";
            // 
            // txtRegistroNovo
            // 
            this.txtRegistroNovo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegistroNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistroNovo.Location = new System.Drawing.Point(418, 33);
            this.txtRegistroNovo.Name = "txtRegistroNovo";
            this.txtRegistroNovo.Size = new System.Drawing.Size(151, 26);
            this.txtRegistroNovo.TabIndex = 543;
            this.txtRegistroNovo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 16);
            this.label4.TabIndex = 542;
            this.label4.Text = "OS";
            // 
            // txtOSAlterar
            // 
            this.txtOSAlterar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOSAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOSAlterar.Location = new System.Drawing.Point(7, 33);
            this.txtOSAlterar.Name = "txtOSAlterar";
            this.txtOSAlterar.Size = new System.Drawing.Size(186, 26);
            this.txtOSAlterar.TabIndex = 538;
            this.txtOSAlterar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOSAlterar.TextChanged += new System.EventHandler(this.txtOSAlterar_TextChanged);
            this.txtOSAlterar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOSAlterar_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 15);
            this.label3.TabIndex = 540;
            this.label3.Text = "ALTERAR REGISTRO JÁ CADASTRADO";
            // 
            // btnAlterar
            // 
            this.btnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlterar.Location = new System.Drawing.Point(604, 33);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(106, 26);
            this.btnAlterar.TabIndex = 541;
            this.btnAlterar.Text = "ALTERAR";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // frmExpedicaoLancarRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 696);
            this.Controls.Add(this.pnlAlterar);
            this.Controls.Add(this.pnlConcluir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.btnMarcarTudo);
            this.Controls.Add(this.btnDesmarcar);
            this.Controls.Add(this.btnGeraExcel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTotalRomaneio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.dgvRomaneio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExpedicaoLancarRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LANÇAR REGISTRO";
            this.Load += new System.EventHandler(this.frmExpedicaoLancarRegistro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRomaneio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlConcluir.ResumeLayout(false);
            this.pnlConcluir.PerformLayout();
            this.pnlAlterar.ResumeLayout(false);
            this.pnlAlterar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalRomaneio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.DataGridView dgvRomaneio;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtRegistroVarejista;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConcluir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGeraExcel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chbColuna;
        private System.Windows.Forms.Button btnMarcarTudo;
        private System.Windows.Forms.Button btnDesmarcar;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label lblCT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlConcluir;
        private System.Windows.Forms.Panel pnlAlterar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRegistroAntigo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRegistroNovo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOSAlterar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAlterar;
    }
}