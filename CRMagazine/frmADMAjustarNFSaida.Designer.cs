namespace CRMagazine
{
    partial class frmADMAjustarNFSaida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmADMAjustarNFSaida));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscarNF = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvNFSaida = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlAlteracao = new System.Windows.Forms.Panel();
            this.btnDuplicar = new System.Windows.Forms.Button();
            this.txtNCM = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtValor_Total = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtValor_uni = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodVarejo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtNFEntrada = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVarejista = new System.Windows.Forms.TextBox();
            this.txtClassificacao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQnt = new System.Windows.Forms.TextBox();
            this.txtNF = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblCT = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNFSaida)).BeginInit();
            this.pnlAlteracao.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel3.Controls.Add(this.btnLimpar);
            this.panel3.Controls.Add(this.btnBuscar);
            this.panel3.Controls.Add(this.txtBuscarNF);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(16, 132);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(573, 81);
            this.panel3.TabIndex = 527;
            // 
            // btnLimpar
            // 
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Location = new System.Drawing.Point(452, 46);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(100, 27);
            this.btnLimpar.TabIndex = 436;
            this.btnLimpar.Text = "LIMPAR";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(281, 34);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 38);
            this.btnBuscar.TabIndex = 435;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscarNF
            // 
            this.txtBuscarNF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarNF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarNF.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarNF.Location = new System.Drawing.Point(33, 34);
            this.txtBuscarNF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBuscarNF.Name = "txtBuscarNF";
            this.txtBuscarNF.Size = new System.Drawing.Size(239, 37);
            this.txtBuscarNF.TabIndex = 433;
            this.txtBuscarNF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarNF_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 11);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 20);
            this.label8.TabIndex = 434;
            this.label8.Text = "NF SAÍDA";
            // 
            // dgvNFSaida
            // 
            this.dgvNFSaida.AllowUserToAddRows = false;
            this.dgvNFSaida.AllowUserToDeleteRows = false;
            this.dgvNFSaida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvNFSaida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNFSaida.Location = new System.Drawing.Point(16, 220);
            this.dgvNFSaida.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvNFSaida.Name = "dgvNFSaida";
            this.dgvNFSaida.RowHeadersWidth = 51;
            this.dgvNFSaida.Size = new System.Drawing.Size(1503, 354);
            this.dgvNFSaida.TabIndex = 526;
            this.dgvNFSaida.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNFSaida_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1321, 193);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 436;
            this.label1.Text = "QUANTIDADE:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(1463, 193);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(18, 20);
            this.lblTotal.TabIndex = 528;
            this.lblTotal.Text = "0";
            // 
            // pnlAlteracao
            // 
            this.pnlAlteracao.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pnlAlteracao.Controls.Add(this.btnDuplicar);
            this.pnlAlteracao.Controls.Add(this.txtNCM);
            this.pnlAlteracao.Controls.Add(this.label13);
            this.pnlAlteracao.Controls.Add(this.btnDelete);
            this.pnlAlteracao.Controls.Add(this.label12);
            this.pnlAlteracao.Controls.Add(this.txtValor_Total);
            this.pnlAlteracao.Controls.Add(this.label11);
            this.pnlAlteracao.Controls.Add(this.txtValor_uni);
            this.pnlAlteracao.Controls.Add(this.txtDescricao);
            this.pnlAlteracao.Controls.Add(this.label10);
            this.pnlAlteracao.Controls.Add(this.label5);
            this.pnlAlteracao.Controls.Add(this.txtCodVarejo);
            this.pnlAlteracao.Controls.Add(this.label3);
            this.pnlAlteracao.Controls.Add(this.txtData);
            this.pnlAlteracao.Controls.Add(this.txtNFEntrada);
            this.pnlAlteracao.Controls.Add(this.label2);
            this.pnlAlteracao.Controls.Add(this.txtID);
            this.pnlAlteracao.Controls.Add(this.lblID);
            this.pnlAlteracao.Controls.Add(this.btnAtualizar);
            this.pnlAlteracao.Controls.Add(this.label9);
            this.pnlAlteracao.Controls.Add(this.txtVarejista);
            this.pnlAlteracao.Controls.Add(this.txtClassificacao);
            this.pnlAlteracao.Controls.Add(this.label6);
            this.pnlAlteracao.Controls.Add(this.label4);
            this.pnlAlteracao.Controls.Add(this.txtQnt);
            this.pnlAlteracao.Controls.Add(this.txtNF);
            this.pnlAlteracao.Controls.Add(this.label7);
            this.pnlAlteracao.Location = new System.Drawing.Point(16, 582);
            this.pnlAlteracao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlAlteracao.Name = "pnlAlteracao";
            this.pnlAlteracao.Size = new System.Drawing.Size(1503, 162);
            this.pnlAlteracao.TabIndex = 529;
            // 
            // btnDuplicar
            // 
            this.btnDuplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuplicar.Location = new System.Drawing.Point(1397, 108);
            this.btnDuplicar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDuplicar.Name = "btnDuplicar";
            this.btnDuplicar.Size = new System.Drawing.Size(96, 38);
            this.btnDuplicar.TabIndex = 456;
            this.btnDuplicar.Text = "DUPLICAR";
            this.btnDuplicar.UseVisualStyleBackColor = true;
            this.btnDuplicar.Click += new System.EventHandler(this.btnDuplicar_Click);
            // 
            // txtNCM
            // 
            this.txtNCM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNCM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNCM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNCM.Location = new System.Drawing.Point(1187, 30);
            this.txtNCM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNCM.Name = "txtNCM";
            this.txtNCM.Size = new System.Drawing.Size(305, 30);
            this.txtNCM.TabIndex = 454;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1183, 14);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 17);
            this.label13.TabIndex = 455;
            this.label13.Text = "NCM";
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(1293, 108);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 38);
            this.btnDelete.TabIndex = 453;
            this.btnDelete.Text = "DELETAR";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(928, 95);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 17);
            this.label12.TabIndex = 452;
            this.label12.Text = "VALOR TOTAL";
            // 
            // txtValor_Total
            // 
            this.txtValor_Total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValor_Total.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValor_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor_Total.Location = new System.Drawing.Point(932, 111);
            this.txtValor_Total.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtValor_Total.Name = "txtValor_Total";
            this.txtValor_Total.Size = new System.Drawing.Size(194, 30);
            this.txtValor_Total.TabIndex = 451;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(725, 95);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 17);
            this.label11.TabIndex = 450;
            this.label11.Text = "VALOR UNITARIO";
            // 
            // txtValor_uni
            // 
            this.txtValor_uni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValor_uni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValor_uni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor_uni.Location = new System.Drawing.Point(729, 111);
            this.txtValor_uni.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtValor_uni.Name = "txtValor_uni";
            this.txtValor_uni.Size = new System.Drawing.Size(194, 30);
            this.txtValor_uni.TabIndex = 449;
            // 
            // txtDescricao
            // 
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(408, 30);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(287, 30);
            this.txtDescricao.TabIndex = 447;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(404, 14);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 17);
            this.label10.TabIndex = 448;
            this.label10.Text = "DESCRIÇÃO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 95);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 446;
            this.label5.Text = "COD VAREJO";
            // 
            // txtCodVarejo
            // 
            this.txtCodVarejo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodVarejo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodVarejo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodVarejo.Location = new System.Drawing.Point(224, 111);
            this.txtCodVarejo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodVarejo.Name = "txtCodVarejo";
            this.txtCodVarejo.Size = new System.Drawing.Size(174, 30);
            this.txtCodVarejo.TabIndex = 445;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(704, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 444;
            this.label3.Text = "DATA";
            // 
            // txtData
            // 
            this.txtData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtData.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Location = new System.Drawing.Point(708, 30);
            this.txtData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(174, 30);
            this.txtData.TabIndex = 443;
            // 
            // txtNFEntrada
            // 
            this.txtNFEntrada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNFEntrada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNFEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNFEntrada.Location = new System.Drawing.Point(33, 111);
            this.txtNFEntrada.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNFEntrada.Name = "txtNFEntrada";
            this.txtNFEntrada.Size = new System.Drawing.Size(182, 30);
            this.txtNFEntrada.TabIndex = 441;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 442;
            this.label2.Text = "NOTA ENTRADA";
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(33, 30);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(157, 30);
            this.txtID.TabIndex = 439;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(29, 14);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 17);
            this.lblID.TabIndex = 440;
            this.lblID.Text = "ID";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Location = new System.Drawing.Point(1151, 108);
            this.btnAtualizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(135, 38);
            this.btnAtualizar.TabIndex = 436;
            this.btnAtualizar.Text = "ATUALIZAR";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(404, 95);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 17);
            this.label9.TabIndex = 438;
            this.label9.Text = "VEREJISTA";
            // 
            // txtVarejista
            // 
            this.txtVarejista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVarejista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVarejista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVarejista.Location = new System.Drawing.Point(408, 111);
            this.txtVarejista.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVarejista.Name = "txtVarejista";
            this.txtVarejista.Size = new System.Drawing.Size(194, 30);
            this.txtVarejista.TabIndex = 437;
            // 
            // txtClassificacao
            // 
            this.txtClassificacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClassificacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClassificacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClassificacao.Location = new System.Drawing.Point(891, 30);
            this.txtClassificacao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtClassificacao.Name = "txtClassificacao";
            this.txtClassificacao.Size = new System.Drawing.Size(287, 30);
            this.txtClassificacao.TabIndex = 435;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(887, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 436;
            this.label6.Text = "CLASSIFICAÇÃO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(607, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 434;
            this.label4.Text = "QNT";
            // 
            // txtQnt
            // 
            this.txtQnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQnt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQnt.Location = new System.Drawing.Point(611, 111);
            this.txtQnt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtQnt.Name = "txtQnt";
            this.txtQnt.Size = new System.Drawing.Size(110, 30);
            this.txtQnt.TabIndex = 433;
            // 
            // txtNF
            // 
            this.txtNF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNF.Location = new System.Drawing.Point(217, 30);
            this.txtNF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNF.Name = "txtNF";
            this.txtNF.Size = new System.Drawing.Size(182, 30);
            this.txtNF.TabIndex = 431;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 17);
            this.label7.TabIndex = 432;
            this.label7.Text = "NOTA FISCAL SAÍDA";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(536, 33);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(465, 46);
            this.label14.TabIndex = 530;
            this.label14.Text = "AJUSTAR NF DE SAÍDA";
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.ForeColor = System.Drawing.Color.Maroon;
            this.lblCT.Location = new System.Drawing.Point(1403, 13);
            this.lblCT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(12, 18);
            this.lblCT.TabIndex = 531;
            this.lblCT.Text = ".";
            // 
            // frmADMAjustarNFSaida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1535, 817);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pnlAlteracao);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvNFSaida);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmADMAjustarNFSaida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AJUSTE DE NF DE SAIDA";
            this.Load += new System.EventHandler(this.frmADMAjustarNFSaida_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNFSaida)).EndInit();
            this.pnlAlteracao.ResumeLayout(false);
            this.pnlAlteracao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscarNF;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvNFSaida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel pnlAlteracao;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVarejista;
        private System.Windows.Forms.TextBox txtClassificacao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQnt;
        private System.Windows.Forms.TextBox txtNF;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.TextBox txtNFEntrada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtValor_Total;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtValor_uni;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodVarejo;
        private System.Windows.Forms.TextBox txtNCM;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnDuplicar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblCT;
    }
}