namespace CRMagazine
{
    partial class frmAjusteRetirarDePP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAjusteRetirarDePP));
            this.label5 = new System.Windows.Forms.Label();
            this.btnConcluir = new System.Windows.Forms.Button();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVarejista = new System.Windows.Forms.TextBox();
            this.lblOS = new System.Windows.Forms.Label();
            this.txtNS = new System.Windows.Forms.TextBox();
            this.lblContador = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvConsulta = new System.Windows.Forms.DataGridView();
            this.btnBuscarObj = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDoa = new System.Windows.Forms.Button();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(320, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(676, 58);
            this.label5.TabIndex = 515;
            this.label5.Text = "RETIRAR DE AGUARDO SEM PEÇA";
            // 
            // btnConcluir
            // 
            this.btnConcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConcluir.Location = new System.Drawing.Point(939, 608);
            this.btnConcluir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(141, 53);
            this.btnConcluir.TabIndex = 513;
            this.btnConcluir.Text = "CONCLUIR";
            this.btnConcluir.UseVisualStyleBackColor = true;
            this.btnConcluir.Click += new System.EventHandler(this.btnConcluir_Click);
            // 
            // txtModelo
            // 
            this.txtModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelo.Location = new System.Drawing.Point(345, 464);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.ReadOnly = true;
            this.txtModelo.Size = new System.Drawing.Size(734, 30);
            this.txtModelo.TabIndex = 512;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(340, 436);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 511;
            this.label1.Text = "MODELO";
            // 
            // txtOS
            // 
            this.txtOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOS.Location = new System.Drawing.Point(491, 208);
            this.txtOS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOS.Name = "txtOS";
            this.txtOS.ReadOnly = true;
            this.txtOS.Size = new System.Drawing.Size(307, 30);
            this.txtOS.TabIndex = 510;
            this.txtOS.TextChanged += new System.EventHandler(this.txtNS_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(484, 180);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 25);
            this.label2.TabIndex = 509;
            this.label2.Text = "OS";
            // 
            // txtVarejista
            // 
            this.txtVarejista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVarejista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVarejista.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVarejista.Location = new System.Drawing.Point(491, 258);
            this.txtVarejista.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVarejista.Name = "txtVarejista";
            this.txtVarejista.ReadOnly = true;
            this.txtVarejista.Size = new System.Drawing.Size(393, 46);
            this.txtVarejista.TabIndex = 508;
            this.txtVarejista.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVarejista.TextChanged += new System.EventHandler(this.txtSeguradora_TextChanged);
            // 
            // lblOS
            // 
            this.lblOS.AutoSize = true;
            this.lblOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOS.Location = new System.Drawing.Point(433, 363);
            this.lblOS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOS.Name = "lblOS";
            this.lblOS.Size = new System.Drawing.Size(47, 29);
            this.lblOS.TabIndex = 507;
            this.lblOS.Text = "NS";
            // 
            // txtNS
            // 
            this.txtNS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNS.Location = new System.Drawing.Point(489, 359);
            this.txtNS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNS.Name = "txtNS";
            this.txtNS.ReadOnly = true;
            this.txtNS.Size = new System.Drawing.Size(339, 37);
            this.txtNS.TabIndex = 506;
            this.txtNS.TextChanged += new System.EventHandler(this.txtChamado_TextChanged);
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContador.Location = new System.Drawing.Point(325, 54);
            this.lblContador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(20, 29);
            this.lblContador.TabIndex = 505;
            this.lblContador.Text = ".";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(325, 9);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(20, 29);
            this.lblUsuario.TabIndex = 504;
            this.lblUsuario.Text = ".";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(28, 665);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(40, 17);
            this.lblTotal.TabIndex = 502;
            this.lblTotal.Text = "Total";
            // 
            // txtBusca
            // 
            this.txtBusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusca.Location = new System.Drawing.Point(28, 208);
            this.txtBusca.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(214, 30);
            this.txtBusca.TabIndex = 501;
            this.txtBusca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusca_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 180);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 500;
            this.label3.Text = "BUSCA";
            // 
            // dgvConsulta
            // 
            this.dgvConsulta.AllowUserToAddRows = false;
            this.dgvConsulta.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsulta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConsulta.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvConsulta.Location = new System.Drawing.Point(28, 246);
            this.dgvConsulta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.RowHeadersWidth = 51;
            this.dgvConsulta.Size = new System.Drawing.Size(265, 415);
            this.dgvConsulta.TabIndex = 499;
            this.dgvConsulta.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsulta_CellEnter);
            // 
            // btnBuscarObj
            // 
            this.btnBuscarObj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarObj.Image = global::CRMagazine.Properties.Resources.lupa_24x24;
            this.btnBuscarObj.Location = new System.Drawing.Point(241, 208);
            this.btnBuscarObj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscarObj.Name = "btnBuscarObj";
            this.btnBuscarObj.Size = new System.Drawing.Size(52, 32);
            this.btnBuscarObj.TabIndex = 514;
            this.btnBuscarObj.UseVisualStyleBackColor = true;
            this.btnBuscarObj.Click += new System.EventHandler(this.btnBuscarObj_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CRMagazine.Properties.Resources.B1;
            this.pictureBox1.Location = new System.Drawing.Point(23, -4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(289, 118);
            this.pictureBox1.TabIndex = 503;
            this.pictureBox1.TabStop = false;
            // 
            // btnDoa
            // 
            this.btnDoa.Enabled = false;
            this.btnDoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoa.Location = new System.Drawing.Point(347, 608);
            this.btnDoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDoa.Name = "btnDoa";
            this.btnDoa.Size = new System.Drawing.Size(141, 53);
            this.btnDoa.TabIndex = 517;
            this.btnDoa.Text = "PSR DOA";
            this.btnDoa.UseVisualStyleBackColor = true;
            this.btnDoa.Visible = false;
            this.btnDoa.Click += new System.EventHandler(this.btnDoa_Click);
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "PP",
            "AGUARDOBACKUP"});
            this.cboStatus.Location = new System.Drawing.Point(28, 140);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(239, 28);
            this.cboStatus.TabIndex = 518;
            this.cboStatus.SelectedValueChanged += new System.EventHandler(this.cboStatus_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 25);
            this.label4.TabIndex = 519;
            this.label4.Text = "SELECIONE O STATUS";
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.ForeColor = System.Drawing.Color.Maroon;
            this.lblCT.Location = new System.Drawing.Point(1067, 18);
            this.lblCT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(12, 18);
            this.lblCT.TabIndex = 533;
            this.lblCT.Text = ".";
            // 
            // frmAjusteRetirarDePP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 690);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.btnDoa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBuscarObj);
            this.Controls.Add(this.btnConcluir);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVarejista);
            this.Controls.Add(this.lblOS);
            this.Controls.Add(this.txtNS);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvConsulta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmAjusteRetirarDePP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RETIRAR DE PP";
            this.Load += new System.EventHandler(this.frmAjusteRetirarDePP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscarObj;
        private System.Windows.Forms.Button btnConcluir;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVarejista;
        private System.Windows.Forms.Label lblOS;
        private System.Windows.Forms.TextBox txtNS;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvConsulta;
        private System.Windows.Forms.Button btnDoa;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCT;
    }
}