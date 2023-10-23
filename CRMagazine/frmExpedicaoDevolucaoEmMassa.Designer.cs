namespace CRMagazine
{
    partial class frmExpedicaoDevolucaoEmMassa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpedicaoDevolucaoEmMassa));
            this.dgvExpedicao = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cboClassificacao = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQntTotal = new System.Windows.Forms.TextBox();
            this.btnBusca = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboVarejista = new System.Windows.Forms.ComboBox();
            this.txtCodVarejo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnConcluir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblQnt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRetornoRetirada = new System.Windows.Forms.TextBox();
            this.txtRetorno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpedicao)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvExpedicao
            // 
            this.dgvExpedicao.AllowUserToAddRows = false;
            this.dgvExpedicao.AllowUserToDeleteRows = false;
            this.dgvExpedicao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvExpedicao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpedicao.Location = new System.Drawing.Point(65, 191);
            this.dgvExpedicao.Margin = new System.Windows.Forms.Padding(4);
            this.dgvExpedicao.Name = "dgvExpedicao";
            this.dgvExpedicao.RowHeadersWidth = 51;
            this.dgvExpedicao.Size = new System.Drawing.Size(1405, 481);
            this.dgvExpedicao.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cboClassificacao);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtQntTotal);
            this.panel3.Controls.Add(this.btnBusca);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cboVarejista);
            this.panel3.Controls.Add(this.txtCodVarejo);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(65, 79);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1013, 105);
            this.panel3.TabIndex = 526;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(612, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 20);
            this.label4.TabIndex = 471;
            this.label4.Text = "CLASSIFICAÇÃO";
            // 
            // cboClassificacao
            // 
            this.cboClassificacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClassificacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClassificacao.FormattingEnabled = true;
            this.cboClassificacao.Items.AddRange(new object[] {
            "",
            "NOVO",
            "SALDO",
            "DEVOLUCAO",
            "SUCATA"});
            this.cboClassificacao.Location = new System.Drawing.Point(616, 44);
            this.cboClassificacao.Margin = new System.Windows.Forms.Padding(4);
            this.cboClassificacao.Name = "cboClassificacao";
            this.cboClassificacao.Size = new System.Drawing.Size(245, 33);
            this.cboClassificacao.TabIndex = 4;
            this.cboClassificacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboClassificacao_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(232, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 469;
            this.label3.Text = "QNT";
            // 
            // txtQntTotal
            // 
            this.txtQntTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQntTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQntTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQntTotal.Location = new System.Drawing.Point(236, 44);
            this.txtQntTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtQntTotal.Name = "txtQntTotal";
            this.txtQntTotal.Size = new System.Drawing.Size(107, 37);
            this.txtQntTotal.TabIndex = 2;
            this.txtQntTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQntTotal_KeyPress);
            // 
            // btnBusca
            // 
            this.btnBusca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusca.Image = global::CRMagazine.Properties.Resources.lupa_24x24;
            this.btnBusca.Location = new System.Drawing.Point(920, 22);
            this.btnBusca.Margin = new System.Windows.Forms.Padding(4);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(67, 57);
            this.btnBusca.TabIndex = 5;
            this.btnBusca.UseVisualStyleBackColor = true;
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(348, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 466;
            this.label1.Text = "VAREJISTA";
            // 
            // cboVarejista
            // 
            this.cboVarejista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVarejista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVarejista.FormattingEnabled = true;
            this.cboVarejista.Items.AddRange(new object[] {
            "",
            "VIAVAREJO",
            "CNOVA",
            "MULTIVAREJO",
            "MAGAZINE",
            "AMERICANAS",
            "B2W",
            "EXTERNO"});
            this.cboVarejista.Location = new System.Drawing.Point(352, 44);
            this.cboVarejista.Margin = new System.Windows.Forms.Padding(4);
            this.cboVarejista.Name = "cboVarejista";
            this.cboVarejista.Size = new System.Drawing.Size(255, 33);
            this.cboVarejista.TabIndex = 3;
            this.cboVarejista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboVarejista_KeyPress);
            // 
            // txtCodVarejo
            // 
            this.txtCodVarejo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodVarejo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodVarejo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodVarejo.Location = new System.Drawing.Point(20, 44);
            this.txtCodVarejo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodVarejo.Name = "txtCodVarejo";
            this.txtCodVarejo.Size = new System.Drawing.Size(207, 37);
            this.txtCodVarejo.TabIndex = 1;
            this.txtCodVarejo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodVarejo_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 21);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 20);
            this.label8.TabIndex = 434;
            this.label8.Text = "COD VAREJISTA";
            // 
            // btnConcluir
            // 
            this.btnConcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConcluir.Location = new System.Drawing.Point(13, 44);
            this.btnConcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(157, 44);
            this.btnConcluir.TabIndex = 435;
            this.btnConcluir.Text = "CONCLUIR";
            this.btnConcluir.UseVisualStyleBackColor = true;
            this.btnConcluir.Visible = false;
            this.btnConcluir.Click += new System.EventHandler(this.btnConcluir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.lblQnt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnConcluir);
            this.panel1.Location = new System.Drawing.Point(1180, 79);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 105);
            this.panel1.TabIndex = 527;
            // 
            // lblQnt
            // 
            this.lblQnt.AutoSize = true;
            this.lblQnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQnt.Location = new System.Drawing.Point(220, 9);
            this.lblQnt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQnt.Name = "lblQnt";
            this.lblQnt.Size = new System.Drawing.Size(29, 31);
            this.lblQnt.TabIndex = 469;
            this.lblQnt.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 31);
            this.label2.TabIndex = 468;
            this.label2.Text = "QUANTIDADE:";
            // 
            // txtRetornoRetirada
            // 
            this.txtRetornoRetirada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRetornoRetirada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRetornoRetirada.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetornoRetirada.Location = new System.Drawing.Point(479, 585);
            this.txtRetornoRetirada.Margin = new System.Windows.Forms.Padding(4);
            this.txtRetornoRetirada.Multiline = true;
            this.txtRetornoRetirada.Name = "txtRetornoRetirada";
            this.txtRetornoRetirada.Size = new System.Drawing.Size(405, 123);
            this.txtRetornoRetirada.TabIndex = 553;
            this.txtRetornoRetirada.Visible = false;
            // 
            // txtRetorno
            // 
            this.txtRetorno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRetorno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRetorno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetorno.Location = new System.Drawing.Point(65, 585);
            this.txtRetorno.Margin = new System.Windows.Forms.Padding(4);
            this.txtRetorno.Multiline = true;
            this.txtRetorno.Name = "txtRetorno";
            this.txtRetorno.Size = new System.Drawing.Size(405, 123);
            this.txtRetorno.TabIndex = 552;
            this.txtRetorno.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(468, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(682, 58);
            this.label5.TabIndex = 554;
            this.label5.Text = "SAÍDA DE NOTA FISCAL POR FORA";
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.ForeColor = System.Drawing.Color.Maroon;
            this.lblCT.Location = new System.Drawing.Point(1417, 11);
            this.lblCT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(12, 18);
            this.lblCT.TabIndex = 555;
            this.lblCT.Text = ".";
            // 
            // frmExpedicaoDevolucaoEmMassa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1541, 722);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRetornoRetirada);
            this.Controls.Add(this.txtRetorno);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvExpedicao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmExpedicaoDevolucaoEmMassa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAÍDA DE NF POR FORA";
            this.Load += new System.EventHandler(this.frmExpedicaoDevolucaoEmMassa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpedicao)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvExpedicao;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCodVarejo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnConcluir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboVarejista;
        private System.Windows.Forms.Button btnBusca;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblQnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQntTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboClassificacao;
        private System.Windows.Forms.TextBox txtRetornoRetirada;
        private System.Windows.Forms.TextBox txtRetorno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCT;
    }
}