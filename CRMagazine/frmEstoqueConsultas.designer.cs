namespace CRMagazine
{
    partial class frmEstoqueConsultas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstoqueConsultas));
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvConsulta = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLimparTela = new System.Windows.Forms.Button();
            this.chbMostrarQntZero = new System.Windows.Forms.CheckBox();
            this.txtDescParte2 = new System.Windows.Forms.TextBox();
            this.txtPosicao = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescParte1 = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPosicao = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDescParte2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBarebone = new System.Windows.Forms.TextBox();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.rbtBarebone = new System.Windows.Forms.RadioButton();
            this.rbtPOSICAO = new System.Windows.Forms.RadioButton();
            this.rbtDescricao = new System.Windows.Forms.RadioButton();
            this.rbtCodigo = new System.Windows.Forms.RadioButton();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnTudo = new System.Windows.Forms.Button();
            this.lblCT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(794, 30);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(18, 25);
            this.lblTotal.TabIndex = 98;
            this.lblTotal.Text = ".";
            // 
            // dgvConsulta
            // 
            this.dgvConsulta.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvConsulta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvConsulta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvConsulta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsulta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConsulta.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConsulta.Location = new System.Drawing.Point(34, 194);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.ReadOnly = true;
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
            this.dgvConsulta.Size = new System.Drawing.Size(1223, 470);
            this.dgvConsulta.TabIndex = 99;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(708, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 97;
            this.label1.Text = "TOTAL";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.btnLimparTela);
            this.panel1.Controls.Add(this.chbMostrarQntZero);
            this.panel1.Controls.Add(this.txtDescParte2);
            this.panel1.Controls.Add(this.txtPosicao);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.txtDescParte1);
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblPosicao);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblDescParte2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Location = new System.Drawing.Point(257, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 123);
            this.panel1.TabIndex = 101;
            // 
            // btnLimparTela
            // 
            this.btnLimparTela.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparTela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparTela.Location = new System.Drawing.Point(852, 26);
            this.btnLimparTela.Name = "btnLimparTela";
            this.btnLimparTela.Size = new System.Drawing.Size(121, 29);
            this.btnLimparTela.TabIndex = 458;
            this.btnLimparTela.Text = "LIMPAR";
            this.btnLimparTela.UseVisualStyleBackColor = true;
            this.btnLimparTela.Click += new System.EventHandler(this.btnLimparTela_Click);
            // 
            // chbMostrarQntZero
            // 
            this.chbMostrarQntZero.AutoSize = true;
            this.chbMostrarQntZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbMostrarQntZero.Location = new System.Drawing.Point(429, 37);
            this.chbMostrarQntZero.Name = "chbMostrarQntZero";
            this.chbMostrarQntZero.Size = new System.Drawing.Size(163, 20);
            this.chbMostrarQntZero.TabIndex = 455;
            this.chbMostrarQntZero.Text = "MOSTRAR ZERADOS";
            this.chbMostrarQntZero.UseVisualStyleBackColor = true;
            // 
            // txtDescParte2
            // 
            this.txtDescParte2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescParte2.Location = new System.Drawing.Point(429, 88);
            this.txtDescParte2.Name = "txtDescParte2";
            this.txtDescParte2.Size = new System.Drawing.Size(384, 26);
            this.txtDescParte2.TabIndex = 454;
            // 
            // txtPosicao
            // 
            this.txtPosicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosicao.Location = new System.Drawing.Point(228, 31);
            this.txtPosicao.Name = "txtPosicao";
            this.txtPosicao.Size = new System.Drawing.Size(184, 26);
            this.txtPosicao.TabIndex = 452;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(28, 31);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(184, 26);
            this.txtCodigo.TabIndex = 450;
            // 
            // txtDescParte1
            // 
            this.txtDescParte1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescParte1.Location = new System.Drawing.Point(28, 88);
            this.txtDescParte1.Name = "txtDescParte1";
            this.txtDescParte1.Size = new System.Drawing.Size(384, 26);
            this.txtDescParte1.TabIndex = 453;
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Location = new System.Drawing.Point(852, 64);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(121, 50);
            this.btnConsultar.TabIndex = 456;
            this.btnConsultar.Text = "CONSULTAR";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 451;
            this.label2.Text = "CÓDIGO";
            // 
            // lblPosicao
            // 
            this.lblPosicao.AutoSize = true;
            this.lblPosicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosicao.Location = new System.Drawing.Point(224, 12);
            this.lblPosicao.Name = "lblPosicao";
            this.lblPosicao.Size = new System.Drawing.Size(81, 20);
            this.lblPosicao.TabIndex = 453;
            this.lblPosicao.Text = "POSIÇÃO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 20);
            this.label3.TabIndex = 454;
            this.label3.Text = "DESCRIÇÃO PARTE 1";
            // 
            // lblDescParte2
            // 
            this.lblDescParte2.AutoSize = true;
            this.lblDescParte2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescParte2.Location = new System.Drawing.Point(425, 69);
            this.lblDescParte2.Name = "lblDescParte2";
            this.lblDescParte2.Size = new System.Drawing.Size(175, 20);
            this.lblDescParte2.TabIndex = 456;
            this.lblDescParte2.Text = "DESCRIÇÃO PARTE 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(229, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 458;
            this.label4.Text = "BAREBONE";
            this.label4.Visible = false;
            // 
            // txtBarebone
            // 
            this.txtBarebone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarebone.Location = new System.Drawing.Point(233, 21);
            this.txtBarebone.Name = "txtBarebone";
            this.txtBarebone.Size = new System.Drawing.Size(184, 26);
            this.txtBarebone.TabIndex = 457;
            this.txtBarebone.Visible = false;
            // 
            // txtTexto
            // 
            this.txtTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexto.Location = new System.Drawing.Point(697, 8);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(474, 31);
            this.txtTexto.TabIndex = 4;
            this.txtTexto.Visible = false;
            // 
            // rbtBarebone
            // 
            this.rbtBarebone.AutoSize = true;
            this.rbtBarebone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtBarebone.Location = new System.Drawing.Point(542, 35);
            this.rbtBarebone.Name = "rbtBarebone";
            this.rbtBarebone.Size = new System.Drawing.Size(117, 24);
            this.rbtBarebone.TabIndex = 3;
            this.rbtBarebone.TabStop = true;
            this.rbtBarebone.Text = "BAREBONE";
            this.rbtBarebone.UseVisualStyleBackColor = true;
            this.rbtBarebone.Visible = false;
            // 
            // rbtPOSICAO
            // 
            this.rbtPOSICAO.AutoSize = true;
            this.rbtPOSICAO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtPOSICAO.Location = new System.Drawing.Point(542, 12);
            this.rbtPOSICAO.Name = "rbtPOSICAO";
            this.rbtPOSICAO.Size = new System.Drawing.Size(99, 24);
            this.rbtPOSICAO.TabIndex = 2;
            this.rbtPOSICAO.TabStop = true;
            this.rbtPOSICAO.Text = "POSIÇÃO";
            this.rbtPOSICAO.UseVisualStyleBackColor = true;
            this.rbtPOSICAO.Visible = false;
            // 
            // rbtDescricao
            // 
            this.rbtDescricao.AutoSize = true;
            this.rbtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtDescricao.Location = new System.Drawing.Point(371, 36);
            this.rbtDescricao.Name = "rbtDescricao";
            this.rbtDescricao.Size = new System.Drawing.Size(123, 24);
            this.rbtDescricao.TabIndex = 1;
            this.rbtDescricao.TabStop = true;
            this.rbtDescricao.Text = "DESCRIÇÃO";
            this.rbtDescricao.UseVisualStyleBackColor = true;
            this.rbtDescricao.Visible = false;
            // 
            // rbtCodigo
            // 
            this.rbtCodigo.AutoSize = true;
            this.rbtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtCodigo.Location = new System.Drawing.Point(371, 13);
            this.rbtCodigo.Name = "rbtCodigo";
            this.rbtCodigo.Size = new System.Drawing.Size(92, 24);
            this.rbtCodigo.TabIndex = 0;
            this.rbtCodigo.TabStop = true;
            this.rbtCodigo.Text = "CÓDIGO";
            this.rbtCodigo.UseVisualStyleBackColor = true;
            this.rbtCodigo.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::CRMagazine.Properties.Resources.excel;
            this.btnExcel.Location = new System.Drawing.Point(1215, 13);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(42, 47);
            this.btnExcel.TabIndex = 102;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            this.btnExcel.MouseEnter += new System.EventHandler(this.btnExcel_MouseEnter);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox2.Image = global::CRMagazine.Properties.Resources.B1;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(215, 91);
            this.pictureBox2.TabIndex = 100;
            this.pictureBox2.TabStop = false;
            // 
            // btnTudo
            // 
            this.btnTudo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTudo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTudo.Location = new System.Drawing.Point(638, 12);
            this.btnTudo.Name = "btnTudo";
            this.btnTudo.Size = new System.Drawing.Size(53, 47);
            this.btnTudo.TabIndex = 6;
            this.btnTudo.Text = "TUDO";
            this.btnTudo.UseVisualStyleBackColor = true;
            this.btnTudo.Visible = false;
            this.btnTudo.Click += new System.EventHandler(this.btnTudo_Click);
            this.btnTudo.MouseEnter += new System.EventHandler(this.btnTudo_MouseEnter);
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.ForeColor = System.Drawing.Color.Maroon;
            this.lblCT.Location = new System.Drawing.Point(1187, 8);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(10, 14);
            this.lblCT.TabIndex = 533;
            this.lblCT.Text = ".";
            // 
            // frmEstoqueConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 716);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTudo);
            this.Controls.Add(this.txtBarebone);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.rbtBarebone);
            this.Controls.Add(this.rbtPOSICAO);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rbtDescricao);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.rbtCodigo);
            this.Controls.Add(this.dgvConsulta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEstoqueConsultas";
            this.Text = "CONSULTAR ESTOQUE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEstoqueConsultas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvConsulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.RadioButton rbtBarebone;
        private System.Windows.Forms.RadioButton rbtPOSICAO;
        private System.Windows.Forms.RadioButton rbtDescricao;
        private System.Windows.Forms.RadioButton rbtCodigo;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnTudo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBarebone;
        private System.Windows.Forms.Label lblDescParte2;
        private System.Windows.Forms.TextBox txtDescParte2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPosicao;
        private System.Windows.Forms.TextBox txtPosicao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescParte1;
        private System.Windows.Forms.CheckBox chbMostrarQntZero;
        private System.Windows.Forms.Button btnLimparTela;
        private System.Windows.Forms.Label lblCT;
    }
}