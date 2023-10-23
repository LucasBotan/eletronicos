namespace CRMagazine
{
    partial class frmConsultaTecnica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaTecnica));
            this.txtOS = new System.Windows.Forms.TextBox();
            this.txtNS = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtObjeto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtseguradora = new System.Windows.Forms.TextBox();
            this.txtDataReparo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTecnico = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGeraExcel = new System.Windows.Forms.Button();
            this.chbBuscarFinalizados = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.chbBuscarTudo = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnlLimpar = new System.Windows.Forms.Button();
            this.txtExibir = new System.Windows.Forms.TextBox();
            this.dgvConsulta = new System.Windows.Forms.DataGridView();
            this.lblCT = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOS
            // 
            this.txtOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOS.Location = new System.Drawing.Point(18, 17);
            this.txtOS.Name = "txtOS";
            this.txtOS.Size = new System.Drawing.Size(160, 22);
            this.txtOS.TabIndex = 6;
            this.txtOS.Enter += new System.EventHandler(this.txtChamado_Enter);
            this.txtOS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChamado_KeyPress);
            // 
            // txtNS
            // 
            this.txtNS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNS.Location = new System.Drawing.Point(18, 58);
            this.txtNS.Name = "txtNS";
            this.txtNS.Size = new System.Drawing.Size(160, 22);
            this.txtNS.TabIndex = 9;
            this.txtNS.Enter += new System.EventHandler(this.txtNS_Enter);
            this.txtNS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNS_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtObjeto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtOS);
            this.panel1.Controls.Add(this.txtNS);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(30, 551);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 128);
            this.panel1.TabIndex = 307;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "OBJETO";
            this.label8.Visible = false;
            // 
            // txtObjeto
            // 
            this.txtObjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObjeto.Location = new System.Drawing.Point(18, 99);
            this.txtObjeto.Name = "txtObjeto";
            this.txtObjeto.Size = new System.Drawing.Size(160, 22);
            this.txtObjeto.TabIndex = 11;
            this.txtObjeto.Visible = false;
            this.txtObjeto.Enter += new System.EventHandler(this.txtObjeto_Enter);
            this.txtObjeto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObjeto_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "NÚMERO SÉRIE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "OS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(252, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "EVENTO";
            this.label10.Visible = false;
            // 
            // txtseguradora
            // 
            this.txtseguradora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtseguradora.Location = new System.Drawing.Point(255, 84);
            this.txtseguradora.Name = "txtseguradora";
            this.txtseguradora.Size = new System.Drawing.Size(147, 26);
            this.txtseguradora.TabIndex = 20;
            this.txtseguradora.Visible = false;
            this.txtseguradora.Enter += new System.EventHandler(this.txtseguradora_Enter);
            this.txtseguradora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtseguradora_KeyPress);
            // 
            // txtDataReparo
            // 
            this.txtDataReparo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataReparo.Location = new System.Drawing.Point(396, 32);
            this.txtDataReparo.Name = "txtDataReparo";
            this.txtDataReparo.Size = new System.Drawing.Size(112, 26);
            this.txtDataReparo.TabIndex = 15;
            this.txtDataReparo.Enter += new System.EventHandler(this.txtDataReparo_Enter);
            this.txtDataReparo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDataReparo_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(393, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "DATA REPARO";
            // 
            // txtTecnico
            // 
            this.txtTecnico.AutoSize = true;
            this.txtTecnico.Location = new System.Drawing.Point(4, 71);
            this.txtTecnico.Name = "txtTecnico";
            this.txtTecnico.Size = new System.Drawing.Size(54, 13);
            this.txtTecnico.TabIndex = 10;
            this.txtTecnico.Text = "TECNICO";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(7, 84);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(242, 26);
            this.txtUsuario.TabIndex = 9;
            this.txtUsuario.Enter += new System.EventHandler(this.txtUsuario_Enter);
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = global::CRMagazine.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(778, 647);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(32, 32);
            this.btnHelp.TabIndex = 310;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1112, 489);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(235, 55);
            this.label9.TabIndex = 309;
            this.label9.Text = "TECNICA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 503);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 29);
            this.label7.TabIndex = 308;
            this.label7.Text = "TOTAL:";
            // 
            // btnGeraExcel
            // 
            this.btnGeraExcel.Image = global::CRMagazine.Properties.Resources.excel;
            this.btnGeraExcel.Location = new System.Drawing.Point(729, 498);
            this.btnGeraExcel.Name = "btnGeraExcel";
            this.btnGeraExcel.Size = new System.Drawing.Size(43, 45);
            this.btnGeraExcel.TabIndex = 301;
            this.btnGeraExcel.UseVisualStyleBackColor = true;
            this.btnGeraExcel.Click += new System.EventHandler(this.btnGeraExcel_Click);
            // 
            // chbBuscarFinalizados
            // 
            this.chbBuscarFinalizados.AutoSize = true;
            this.chbBuscarFinalizados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbBuscarFinalizados.Location = new System.Drawing.Point(239, 524);
            this.chbBuscarFinalizados.Name = "chbBuscarFinalizados";
            this.chbBuscarFinalizados.Size = new System.Drawing.Size(184, 20);
            this.chbBuscarFinalizados.TabIndex = 303;
            this.chbBuscarFinalizados.Text = "MOSTRAR FINALIZADOS";
            this.chbBuscarFinalizados.UseVisualStyleBackColor = true;
            this.chbBuscarFinalizados.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "MODELO";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(408, 66);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 46);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "CONSULTAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(7, 31);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(383, 26);
            this.txtDescricao.TabIndex = 4;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            // 
            // chbBuscarTudo
            // 
            this.chbBuscarTudo.AutoSize = true;
            this.chbBuscarTudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbBuscarTudo.Location = new System.Drawing.Point(239, 498);
            this.chbBuscarTudo.Name = "chbBuscarTudo";
            this.chbBuscarTudo.Size = new System.Drawing.Size(216, 20);
            this.chbBuscarTudo.TabIndex = 311;
            this.chbBuscarTudo.Text = "BUSCAR TODOS OS CAMPOS";
            this.chbBuscarTudo.UseVisualStyleBackColor = true;
            this.chbBuscarTudo.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtseguradora);
            this.panel2.Controls.Add(this.txtDataReparo);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtTecnico);
            this.panel2.Controls.Add(this.txtUsuario);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Controls.Add(this.txtDescricao);
            this.panel2.Location = new System.Drawing.Point(239, 551);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(533, 128);
            this.panel2.TabIndex = 306;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTotal.Location = new System.Drawing.Point(129, 503);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(19, 29);
            this.lblTotal.TabIndex = 302;
            this.lblTotal.Text = ".";
            // 
            // btnlLimpar
            // 
            this.btnlLimpar.Location = new System.Drawing.Point(611, 498);
            this.btnlLimpar.Name = "btnlLimpar";
            this.btnlLimpar.Size = new System.Drawing.Size(112, 45);
            this.btnlLimpar.TabIndex = 300;
            this.btnlLimpar.Text = "LIMPAR FILTROS";
            this.btnlLimpar.UseVisualStyleBackColor = true;
            this.btnlLimpar.Click += new System.EventHandler(this.btnlLimpar_Click);
            // 
            // txtExibir
            // 
            this.txtExibir.Location = new System.Drawing.Point(1232, 616);
            this.txtExibir.Name = "txtExibir";
            this.txtExibir.Size = new System.Drawing.Size(121, 20);
            this.txtExibir.TabIndex = 299;
            this.txtExibir.Visible = false;
            // 
            // dgvConsulta
            // 
            this.dgvConsulta.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvConsulta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsulta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConsulta.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConsulta.Location = new System.Drawing.Point(4, 12);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.RowHeadersWidth = 51;
            this.dgvConsulta.Size = new System.Drawing.Size(1343, 465);
            this.dgvConsulta.TabIndex = 298;
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.ForeColor = System.Drawing.Color.Maroon;
            this.lblCT.Location = new System.Drawing.Point(28, 533);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(10, 14);
            this.lblCT.TabIndex = 533;
            this.lblCT.Text = ".";
            // 
            // frmConsultaTecnica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 714);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnGeraExcel);
            this.Controls.Add(this.chbBuscarFinalizados);
            this.Controls.Add(this.chbBuscarTudo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnlLimpar);
            this.Controls.Add(this.txtExibir);
            this.Controls.Add(this.dgvConsulta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultaTecnica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONSULTA TECNICA";
            this.Load += new System.EventHandler(this.frmConsultaTecnica_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOS;
        private System.Windows.Forms.TextBox txtNS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtObjeto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtseguradora;
        private System.Windows.Forms.TextBox txtDataReparo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtTecnico;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGeraExcel;
        private System.Windows.Forms.CheckBox chbBuscarFinalizados;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.CheckBox chbBuscarTudo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnlLimpar;
        private System.Windows.Forms.TextBox txtExibir;
        private System.Windows.Forms.DataGridView dgvConsulta;
        private System.Windows.Forms.Label lblCT;
    }
}