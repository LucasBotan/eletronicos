namespace CRMagazine
{
    partial class frmConsultaHistorico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaHistorico));
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtObjeto = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtAcima = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOS = new System.Windows.Forms.TextBox();
            this.txtNS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtVarejista = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDataHist = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chbDescContem = new System.Windows.Forms.CheckBox();
            this.btnGeraExcel = new System.Windows.Forms.Button();
            this.btnlLimpar = new System.Windows.Forms.Button();
            this.dgvConsulta = new System.Windows.Forms.DataGridView();
            this.lblCT = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(443, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "ACIMA DE";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "OBJETO";
            this.label8.Visible = false;
            // 
            // txtObjeto
            // 
            this.txtObjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObjeto.Location = new System.Drawing.Point(18, 89);
            this.txtObjeto.Name = "txtObjeto";
            this.txtObjeto.Size = new System.Drawing.Size(160, 22);
            this.txtObjeto.TabIndex = 11;
            this.txtObjeto.Visible = false;
            this.txtObjeto.Enter += new System.EventHandler(this.txtChamado_Enter);
            this.txtObjeto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChamado_KeyPress);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTotal.Location = new System.Drawing.Point(129, 514);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(19, 29);
            this.lblTotal.TabIndex = 301;
            this.lblTotal.Text = ".";
            // 
            // txtAcima
            // 
            this.txtAcima.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcima.Location = new System.Drawing.Point(446, 27);
            this.txtAcima.Name = "txtAcima";
            this.txtAcima.Size = new System.Drawing.Size(55, 26);
            this.txtAcima.TabIndex = 11;
            this.txtAcima.Enter += new System.EventHandler(this.txtAcima_Enter);
            this.txtAcima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcima_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "NÚMERO SÉRIE";
            // 
            // txtOS
            // 
            this.txtOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOS.Location = new System.Drawing.Point(18, 17);
            this.txtOS.Name = "txtOS";
            this.txtOS.Size = new System.Drawing.Size(160, 22);
            this.txtOS.TabIndex = 6;
            this.txtOS.Enter += new System.EventHandler(this.txtOS_Enter);
            this.txtOS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOS_KeyPress);
            // 
            // txtNS
            // 
            this.txtNS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNS.Location = new System.Drawing.Point(18, 53);
            this.txtNS.Name = "txtNS";
            this.txtNS.Size = new System.Drawing.Size(160, 22);
            this.txtNS.TabIndex = 9;
            this.txtNS.Enter += new System.EventHandler(this.txtNS_Enter);
            this.txtNS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNS_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "STATUS";
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(25, 76);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(173, 26);
            this.txtStatus.TabIndex = 9;
            this.txtStatus.Enter += new System.EventHandler(this.txtStatus_Enter);
            this.txtStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStatus_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "DESCRIÇÃO";
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
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(25, 26);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(290, 26);
            this.txtDescricao.TabIndex = 4;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1057, 511);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(290, 55);
            this.label9.TabIndex = 306;
            this.label9.Text = "HISTÓRICO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 514);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 29);
            this.label7.TabIndex = 305;
            this.label7.Text = "TOTAL:";
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
            this.panel1.Location = new System.Drawing.Point(30, 562);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 120);
            this.panel1.TabIndex = 304;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(507, 14);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 46);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "CONSULTAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtVarejista);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtDataHist);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtUsuario);
            this.panel2.Controls.Add(this.txtData);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtAcima);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtStatus);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Controls.Add(this.txtDescricao);
            this.panel2.Controls.Add(this.chbDescContem);
            this.panel2.Location = new System.Drawing.Point(239, 562);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(620, 120);
            this.panel2.TabIndex = 303;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(489, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "VAREJISTA";
            // 
            // txtVarejista
            // 
            this.txtVarejista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVarejista.Location = new System.Drawing.Point(492, 76);
            this.txtVarejista.Name = "txtVarejista";
            this.txtVarejista.Size = new System.Drawing.Size(115, 26);
            this.txtVarejista.TabIndex = 24;
            this.txtVarejista.Enter += new System.EventHandler(this.txtVarejista_Enter);
            this.txtVarejista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVarejista_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(379, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "DATA";
            // 
            // txtDataHist
            // 
            this.txtDataHist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataHist.Location = new System.Drawing.Point(382, 76);
            this.txtDataHist.Name = "txtDataHist";
            this.txtDataHist.Size = new System.Drawing.Size(104, 26);
            this.txtDataHist.TabIndex = 18;
            this.txtDataHist.Enter += new System.EventHandler(this.txtDataHist_Enter);
            this.txtDataHist.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDataHist_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(201, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "USUÁRIO";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(204, 76);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(172, 26);
            this.txtUsuario.TabIndex = 16;
            this.txtUsuario.Enter += new System.EventHandler(this.txtUsuario_Enter);
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // txtData
            // 
            this.txtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Location = new System.Drawing.Point(321, 27);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(116, 26);
            this.txtData.TabIndex = 15;
            this.txtData.Enter += new System.EventHandler(this.txtData_Enter);
            this.txtData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "DATA ENTRADA";
            // 
            // chbDescContem
            // 
            this.chbDescContem.AutoSize = true;
            this.chbDescContem.Location = new System.Drawing.Point(109, 12);
            this.chbDescContem.Name = "chbDescContem";
            this.chbDescContem.Size = new System.Drawing.Size(62, 17);
            this.chbDescContem.TabIndex = 20;
            this.chbDescContem.Text = "Contém";
            this.chbDescContem.UseVisualStyleBackColor = true;
            this.chbDescContem.Visible = false;
            this.chbDescContem.CheckedChanged += new System.EventHandler(this.chbDescContem_CheckedChanged);
            // 
            // btnGeraExcel
            // 
            this.btnGeraExcel.Image = global::CRMagazine.Properties.Resources.excel;
            this.btnGeraExcel.Location = new System.Drawing.Point(816, 511);
            this.btnGeraExcel.Name = "btnGeraExcel";
            this.btnGeraExcel.Size = new System.Drawing.Size(43, 45);
            this.btnGeraExcel.TabIndex = 299;
            this.btnGeraExcel.UseVisualStyleBackColor = true;
            this.btnGeraExcel.Click += new System.EventHandler(this.btnGeraExcel_Click);
            // 
            // btnlLimpar
            // 
            this.btnlLimpar.Location = new System.Drawing.Point(698, 511);
            this.btnlLimpar.Name = "btnlLimpar";
            this.btnlLimpar.Size = new System.Drawing.Size(112, 45);
            this.btnlLimpar.TabIndex = 298;
            this.btnlLimpar.Text = "LIMPAR FILTROS";
            this.btnlLimpar.UseVisualStyleBackColor = true;
            this.btnlLimpar.Click += new System.EventHandler(this.btnlLimpar_Click);
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
            this.dgvConsulta.Location = new System.Drawing.Point(4, 23);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.RowHeadersWidth = 51;
            this.dgvConsulta.Size = new System.Drawing.Size(1343, 465);
            this.dgvConsulta.TabIndex = 296;
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.ForeColor = System.Drawing.Color.Maroon;
            this.lblCT.Location = new System.Drawing.Point(28, 545);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(10, 14);
            this.lblCT.TabIndex = 533;
            this.lblCT.Text = ".";
            // 
            // frmConsultaHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1369, 714);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnGeraExcel);
            this.Controls.Add(this.btnlLimpar);
            this.Controls.Add(this.dgvConsulta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultaHistorico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONSULTAR HISTÓRICO";
            this.Load += new System.EventHandler(this.frmConsultaHistorico_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtObjeto;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtAcima;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOS;
        private System.Windows.Forms.TextBox txtNS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGeraExcel;
        private System.Windows.Forms.Button btnlLimpar;
        private System.Windows.Forms.DataGridView dgvConsulta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDataHist;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.CheckBox chbDescContem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtVarejista;
        private System.Windows.Forms.Label lblCT;
    }
}