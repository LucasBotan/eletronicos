namespace CRMagazine
{
    partial class frmVistoria
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
                components.Dispose();
            {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVistoria));
            this.label2 = new System.Windows.Forms.Label();
            this.txtOS = new System.Windows.Forms.TextBox();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mtbDataCompra = new System.Windows.Forms.MaskedTextBox();
            this.mtbDataTroca = new System.Windows.Forms.MaskedTextBox();
            this.txtDataCompra = new System.Windows.Forms.TextBox();
            this.txtDataTroca = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCalculoTroca = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCalculoTroca_Hoje = new System.Windows.Forms.TextBox();
            this.lblFilial = new System.Windows.Forms.Label();
            this.txtFilial = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDefeitoRelatado = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbtMomentoZero = new System.Windows.Forms.RadioButton();
            this.label28 = new System.Windows.Forms.Label();
            this.txtNFVarejo = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtNumLacre = new System.Windows.Forms.TextBox();
            this.txtObsDocumento = new System.Windows.Forms.TextBox();
            this.lnkLimpar = new System.Windows.Forms.LinkLabel();
            this.rbtProcesso = new System.Windows.Forms.RadioButton();
            this.rbtSemDocumento = new System.Windows.Forms.RadioButton();
            this.rbtSemPosto = new System.Windows.Forms.RadioButton();
            this.rbtMaisDe30Dias = new System.Windows.Forms.RadioButton();
            this.txtCodVarejo = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chbSemNS = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NS = new System.Windows.Forms.Label();
            this.cboFuncEst = new System.Windows.Forms.ComboBox();
            this.txtNS = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnConcluir = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.chbNaoImprimir = new System.Windows.Forms.CheckBox();
            this.chbSelecionarImpressora = new System.Windows.Forms.CheckBox();
            this.btnBusca = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblContador = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cboVarejista = new System.Windows.Forms.ComboBox();
            this.mtbDataGaiola = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chbIrParaReparo = new System.Windows.Forms.CheckBox();
            this.lnkAtualizar = new System.Windows.Forms.LinkLabel();
            this.cboNotaFiscal = new System.Windows.Forms.ComboBox();
            this.lblRestanteNF = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCT = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 24);
            this.label2.TabIndex = 286;
            this.label2.Text = "ORDEM DE SERVIÇO";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtOS
            // 
            this.txtOS.BackColor = System.Drawing.Color.GhostWhite;
            this.txtOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOS.Location = new System.Drawing.Point(21, 37);
            this.txtOS.Margin = new System.Windows.Forms.Padding(4);
            this.txtOS.Name = "txtOS";
            this.txtOS.Size = new System.Drawing.Size(223, 29);
            this.txtOS.TabIndex = 285;
            this.txtOS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNS_KeyPress);
            this.txtOS.Leave += new System.EventHandler(this.txtNS_Leave);
            // 
            // txtSKU
            // 
            this.txtSKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSKU.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSKU.Location = new System.Drawing.Point(768, 34);
            this.txtSKU.Margin = new System.Windows.Forms.Padding(4);
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.ReadOnly = true;
            this.txtSKU.Size = new System.Drawing.Size(214, 29);
            this.txtSKU.TabIndex = 284;
            this.txtSKU.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCodPositivo_MouseDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 17);
            this.label7.TabIndex = 283;
            this.label7.Text = "DESCRIÇÃO";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(21, 34);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ReadOnly = true;
            this.txtDescricao.Size = new System.Drawing.Size(529, 29);
            this.txtDescricao.TabIndex = 282;
            // 
            // txtTipo
            // 
            this.txtTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo.Location = new System.Drawing.Point(559, 34);
            this.txtTipo.Margin = new System.Windows.Forms.Padding(4);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(197, 29);
            this.txtTipo.TabIndex = 288;
            this.txtTipo.TextChanged += new System.EventHandler(this.txtTipo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(764, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 289;
            this.label1.Text = "SKU";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(555, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 290;
            this.label3.Text = "TIPO";
            // 
            // mtbDataCompra
            // 
            this.mtbDataCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDataCompra.Location = new System.Drawing.Point(21, 20);
            this.mtbDataCompra.Margin = new System.Windows.Forms.Padding(4);
            this.mtbDataCompra.Mask = "00/00/0000";
            this.mtbDataCompra.Name = "mtbDataCompra";
            this.mtbDataCompra.Size = new System.Drawing.Size(119, 30);
            this.mtbDataCompra.TabIndex = 404;
            this.mtbDataCompra.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbDataCompra.ValidatingType = typeof(System.DateTime);
            this.mtbDataCompra.TextChanged += new System.EventHandler(this.mtbDataCompra_TextChanged);
            this.mtbDataCompra.Enter += new System.EventHandler(this.mtbDataCompra_Enter);
            this.mtbDataCompra.Leave += new System.EventHandler(this.mtbDataCompra_Leave);
            // 
            // mtbDataTroca
            // 
            this.mtbDataTroca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDataTroca.Location = new System.Drawing.Point(145, 20);
            this.mtbDataTroca.Margin = new System.Windows.Forms.Padding(4);
            this.mtbDataTroca.Mask = "00/00/0000";
            this.mtbDataTroca.Name = "mtbDataTroca";
            this.mtbDataTroca.Size = new System.Drawing.Size(119, 30);
            this.mtbDataTroca.TabIndex = 405;
            this.mtbDataTroca.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbDataTroca.ValidatingType = typeof(System.DateTime);
            this.mtbDataTroca.TextChanged += new System.EventHandler(this.mtbDataTroca_TextChanged);
            // 
            // txtDataCompra
            // 
            this.txtDataCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataCompra.Location = new System.Drawing.Point(364, 21);
            this.txtDataCompra.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataCompra.Name = "txtDataCompra";
            this.txtDataCompra.ReadOnly = true;
            this.txtDataCompra.Size = new System.Drawing.Size(26, 29);
            this.txtDataCompra.TabIndex = 406;
            this.txtDataCompra.Visible = false;
            // 
            // txtDataTroca
            // 
            this.txtDataTroca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataTroca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataTroca.Location = new System.Drawing.Point(271, 21);
            this.txtDataTroca.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataTroca.Name = "txtDataTroca";
            this.txtDataTroca.ReadOnly = true;
            this.txtDataTroca.Size = new System.Drawing.Size(26, 29);
            this.txtDataTroca.TabIndex = 407;
            this.txtDataTroca.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 4);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 17);
            this.label8.TabIndex = 408;
            this.label8.Text = "DT COMPRA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(141, 4);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 17);
            this.label9.TabIndex = 409;
            this.label9.Text = "DT TROCA";
            // 
            // txtCalculoTroca
            // 
            this.txtCalculoTroca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCalculoTroca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalculoTroca.Location = new System.Drawing.Point(336, 21);
            this.txtCalculoTroca.Margin = new System.Windows.Forms.Padding(4);
            this.txtCalculoTroca.Name = "txtCalculoTroca";
            this.txtCalculoTroca.ReadOnly = true;
            this.txtCalculoTroca.Size = new System.Drawing.Size(54, 29);
            this.txtCalculoTroca.TabIndex = 410;
            this.txtCalculoTroca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(332, 5);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 17);
            this.label10.TabIndex = 411;
            this.label10.Text = "D TROCA";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(267, 5);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 17);
            this.label11.TabIndex = 413;
            this.label11.Text = "D VIST.";
            // 
            // txtCalculoTroca_Hoje
            // 
            this.txtCalculoTroca_Hoje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCalculoTroca_Hoje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalculoTroca_Hoje.Location = new System.Drawing.Point(272, 21);
            this.txtCalculoTroca_Hoje.Margin = new System.Windows.Forms.Padding(4);
            this.txtCalculoTroca_Hoje.Name = "txtCalculoTroca_Hoje";
            this.txtCalculoTroca_Hoje.ReadOnly = true;
            this.txtCalculoTroca_Hoje.Size = new System.Drawing.Size(54, 29);
            this.txtCalculoTroca_Hoje.TabIndex = 412;
            this.txtCalculoTroca_Hoje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFilial
            // 
            this.lblFilial.AutoSize = true;
            this.lblFilial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilial.Location = new System.Drawing.Point(289, 73);
            this.lblFilial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilial.Name = "lblFilial";
            this.lblFilial.Size = new System.Drawing.Size(47, 17);
            this.lblFilial.TabIndex = 415;
            this.lblFilial.Text = "FILIAL";
            // 
            // txtFilial
            // 
            this.txtFilial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilial.Location = new System.Drawing.Point(293, 89);
            this.txtFilial.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilial.Name = "txtFilial";
            this.txtFilial.Size = new System.Drawing.Size(97, 26);
            this.txtFilial.TabIndex = 417;
            this.txtFilial.Enter += new System.EventHandler(this.txtFilial_Enter);
            this.txtFilial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilial_KeyPress);
            this.txtFilial.Leave += new System.EventHandler(this.txtFilial_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(549, 74);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 17);
            this.label13.TabIndex = 417;
            this.label13.Text = "DEFEITO RELATADO";
            // 
            // txtDefeitoRelatado
            // 
            this.txtDefeitoRelatado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDefeitoRelatado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDefeitoRelatado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefeitoRelatado.Location = new System.Drawing.Point(552, 90);
            this.txtDefeitoRelatado.Margin = new System.Windows.Forms.Padding(4);
            this.txtDefeitoRelatado.Name = "txtDefeitoRelatado";
            this.txtDefeitoRelatado.Size = new System.Drawing.Size(430, 26);
            this.txtDefeitoRelatado.TabIndex = 416;
            this.txtDefeitoRelatado.Enter += new System.EventHandler(this.txtDefeitoRelatado_Enter);
            this.txtDefeitoRelatado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDefeitoRelatado_KeyPress);
            this.txtDefeitoRelatado.Leave += new System.EventHandler(this.txtDefeitoRelatado_Leave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.rbtMomentoZero);
            this.panel3.Controls.Add(this.label28);
            this.panel3.Controls.Add(this.txtNFVarejo);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.txtNumLacre);
            this.panel3.Controls.Add(this.txtObsDocumento);
            this.panel3.Controls.Add(this.lnkLimpar);
            this.panel3.Controls.Add(this.rbtProcesso);
            this.panel3.Controls.Add(this.rbtSemDocumento);
            this.panel3.Controls.Add(this.txtDataCompra);
            this.panel3.Controls.Add(this.txtDataTroca);
            this.panel3.Controls.Add(this.mtbDataCompra);
            this.panel3.Controls.Add(this.mtbDataTroca);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtCalculoTroca);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtCalculoTroca_Hoje);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.rbtSemPosto);
            this.panel3.Controls.Add(this.rbtMaisDe30Dias);
            this.panel3.Location = new System.Drawing.Point(115, 506);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1005, 111);
            this.panel3.TabIndex = 425;
            this.panel3.Visible = false;
            // 
            // rbtMomentoZero
            // 
            this.rbtMomentoZero.AutoSize = true;
            this.rbtMomentoZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtMomentoZero.Location = new System.Drawing.Point(708, 7);
            this.rbtMomentoZero.Margin = new System.Windows.Forms.Padding(4);
            this.rbtMomentoZero.Name = "rbtMomentoZero";
            this.rbtMomentoZero.Size = new System.Drawing.Size(128, 19);
            this.rbtMomentoZero.TabIndex = 430;
            this.rbtMomentoZero.Text = "MOMENTO ZERO";
            this.rbtMomentoZero.UseVisualStyleBackColor = true;
            this.rbtMomentoZero.CheckedChanged += new System.EventHandler(this.rbtMomentoZero_CheckedChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(555, 4);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(85, 17);
            this.label28.TabIndex = 429;
            this.label28.Text = "NF VAREJO";
            // 
            // txtNFVarejo
            // 
            this.txtNFVarejo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNFVarejo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNFVarejo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNFVarejo.Location = new System.Drawing.Point(559, 21);
            this.txtNFVarejo.Margin = new System.Windows.Forms.Padding(4);
            this.txtNFVarejo.Name = "txtNFVarejo";
            this.txtNFVarejo.Size = new System.Drawing.Size(138, 29);
            this.txtNFVarejo.TabIndex = 428;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(563, 55);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(72, 17);
            this.label24.TabIndex = 426;
            this.label24.Text = "Nº LACRE";
            // 
            // txtNumLacre
            // 
            this.txtNumLacre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumLacre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumLacre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumLacre.Location = new System.Drawing.Point(567, 71);
            this.txtNumLacre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumLacre.Name = "txtNumLacre";
            this.txtNumLacre.Size = new System.Drawing.Size(130, 29);
            this.txtNumLacre.TabIndex = 418;
            this.txtNumLacre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumLacre_KeyPress);
            // 
            // txtObsDocumento
            // 
            this.txtObsDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObsDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObsDocumento.Location = new System.Drawing.Point(712, 4);
            this.txtObsDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.txtObsDocumento.Name = "txtObsDocumento";
            this.txtObsDocumento.ReadOnly = true;
            this.txtObsDocumento.Size = new System.Drawing.Size(181, 19);
            this.txtObsDocumento.TabIndex = 423;
            this.txtObsDocumento.Visible = false;
            this.txtObsDocumento.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lnkLimpar
            // 
            this.lnkLimpar.AutoSize = true;
            this.lnkLimpar.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lnkLimpar.Location = new System.Drawing.Point(901, 4);
            this.lnkLimpar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkLimpar.Name = "lnkLimpar";
            this.lnkLimpar.Size = new System.Drawing.Size(94, 17);
            this.lnkLimpar.TabIndex = 422;
            this.lnkLimpar.TabStop = true;
            this.lnkLimpar.Text = "DESMARCAR";
            this.lnkLimpar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLimpar_LinkClicked);
            // 
            // rbtProcesso
            // 
            this.rbtProcesso.AutoSize = true;
            this.rbtProcesso.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtProcesso.Location = new System.Drawing.Point(708, 87);
            this.rbtProcesso.Margin = new System.Windows.Forms.Padding(4);
            this.rbtProcesso.Name = "rbtProcesso";
            this.rbtProcesso.Size = new System.Drawing.Size(154, 19);
            this.rbtProcesso.TabIndex = 421;
            this.rbtProcesso.Text = "PROCESSO JURIDICO";
            this.rbtProcesso.UseVisualStyleBackColor = true;
            this.rbtProcesso.CheckedChanged += new System.EventHandler(this.rbtProcesso_CheckedChanged);
            // 
            // rbtSemDocumento
            // 
            this.rbtSemDocumento.AutoSize = true;
            this.rbtSemDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtSemDocumento.Location = new System.Drawing.Point(708, 28);
            this.rbtSemDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.rbtSemDocumento.Name = "rbtSemDocumento";
            this.rbtSemDocumento.Size = new System.Drawing.Size(137, 19);
            this.rbtSemDocumento.TabIndex = 418;
            this.rbtSemDocumento.Text = "SEM DOCUMENTO";
            this.rbtSemDocumento.UseVisualStyleBackColor = true;
            this.rbtSemDocumento.CheckedChanged += new System.EventHandler(this.rbtSemDocumento_CheckedChanged);
            // 
            // rbtSemPosto
            // 
            this.rbtSemPosto.AutoSize = true;
            this.rbtSemPosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtSemPosto.Location = new System.Drawing.Point(708, 48);
            this.rbtSemPosto.Margin = new System.Windows.Forms.Padding(4);
            this.rbtSemPosto.Name = "rbtSemPosto";
            this.rbtSemPosto.Size = new System.Drawing.Size(272, 19);
            this.rbtSemPosto.TabIndex = 419;
            this.rbtSemPosto.Text = "SEM POSTO AUTORIZADO NA RESIDÊNCIA";
            this.rbtSemPosto.UseVisualStyleBackColor = true;
            this.rbtSemPosto.CheckedChanged += new System.EventHandler(this.rbtSemPosto_CheckedChanged);
            // 
            // rbtMaisDe30Dias
            // 
            this.rbtMaisDe30Dias.AutoSize = true;
            this.rbtMaisDe30Dias.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtMaisDe30Dias.Location = new System.Drawing.Point(708, 68);
            this.rbtMaisDe30Dias.Margin = new System.Windows.Forms.Padding(4);
            this.rbtMaisDe30Dias.Name = "rbtMaisDe30Dias";
            this.rbtMaisDe30Dias.Size = new System.Drawing.Size(286, 19);
            this.rbtMaisDe30Dias.TabIndex = 420;
            this.rbtMaisDe30Dias.Text = "+ 30 DIAS OU +3 PASSAGENS POSTO AUTOR.";
            this.rbtMaisDe30Dias.UseVisualStyleBackColor = true;
            this.rbtMaisDe30Dias.CheckedChanged += new System.EventHandler(this.rbtMaisDe30Dias_CheckedChanged);
            // 
            // txtCodVarejo
            // 
            this.txtCodVarejo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodVarejo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodVarejo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodVarejo.Location = new System.Drawing.Point(284, 37);
            this.txtCodVarejo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodVarejo.Name = "txtCodVarejo";
            this.txtCodVarejo.Size = new System.Drawing.Size(207, 29);
            this.txtCodVarejo.TabIndex = 419;
            this.txtCodVarejo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodVarejo_KeyPress);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Controls.Add(this.chbSemNS);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.NS);
            this.panel4.Controls.Add(this.cboFuncEst);
            this.panel4.Controls.Add(this.txtNS);
            this.panel4.Controls.Add(this.txtDescricao);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtSKU);
            this.panel4.Controls.Add(this.txtTipo);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtFilial);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtDefeitoRelatado);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.lblFilial);
            this.panel4.Location = new System.Drawing.Point(115, 356);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1005, 143);
            this.panel4.TabIndex = 426;
            // 
            // chbSemNS
            // 
            this.chbSemNS.AutoSize = true;
            this.chbSemNS.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbSemNS.Location = new System.Drawing.Point(192, 118);
            this.chbSemNS.Margin = new System.Windows.Forms.Padding(4);
            this.chbSemNS.Name = "chbSemNS";
            this.chbSemNS.Size = new System.Drawing.Size(76, 19);
            this.chbSemNS.TabIndex = 541;
            this.chbSemNS.Text = "SEM NS";
            this.chbSemNS.UseVisualStyleBackColor = true;
            this.chbSemNS.CheckedChanged += new System.EventHandler(this.chbSemNS_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(427, 71);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 542;
            this.label5.Text = "FUNC/EST";
            // 
            // NS
            // 
            this.NS.AutoSize = true;
            this.NS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NS.Location = new System.Drawing.Point(21, 71);
            this.NS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NS.Name = "NS";
            this.NS.Size = new System.Drawing.Size(29, 18);
            this.NS.TabIndex = 429;
            this.NS.Text = "NS";
            // 
            // cboFuncEst
            // 
            this.cboFuncEst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuncEst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFuncEst.FormattingEnabled = true;
            this.cboFuncEst.Items.AddRange(new object[] {
            "",
            "FUNCIONAL",
            "ESTETICO",
            "DESISTENCIA"});
            this.cboFuncEst.Location = new System.Drawing.Point(428, 89);
            this.cboFuncEst.Margin = new System.Windows.Forms.Padding(4);
            this.cboFuncEst.Name = "cboFuncEst";
            this.cboFuncEst.Size = new System.Drawing.Size(92, 25);
            this.cboFuncEst.TabIndex = 541;
            this.cboFuncEst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboFuncEst_KeyPress);
            // 
            // txtNS
            // 
            this.txtNS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNS.Location = new System.Drawing.Point(25, 90);
            this.txtNS.Margin = new System.Windows.Forms.Padding(4);
            this.txtNS.Name = "txtNS";
            this.txtNS.Size = new System.Drawing.Size(246, 26);
            this.txtNS.TabIndex = 428;
            this.txtNS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNS_KeyPress_1);
            this.txtNS.Leave += new System.EventHandler(this.txtNS_Leave_1);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(4, 10);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(737, 54);
            this.label20.TabIndex = 430;
            this.label20.Text = "ENTRADA DE EQUIPAMENTOS";
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Location = new System.Drawing.Point(257, 23);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(103, 47);
            this.btnLimpar.TabIndex = 433;
            this.btnLimpar.Text = "LIMPAR";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnConcluir
            // 
            this.btnConcluir.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnConcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConcluir.ForeColor = System.Drawing.SystemColors.Info;
            this.btnConcluir.Location = new System.Drawing.Point(443, 16);
            this.btnConcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(141, 54);
            this.btnConcluir.TabIndex = 434;
            this.btnConcluir.Text = "CONCLUIR";
            this.btnConcluir.UseVisualStyleBackColor = false;
            this.btnConcluir.Click += new System.EventHandler(this.btnConcluir_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel7.Controls.Add(this.chbNaoImprimir);
            this.panel7.Controls.Add(this.chbSelecionarImpressora);
            this.panel7.Controls.Add(this.btnLimpar);
            this.panel7.Controls.Add(this.btnConcluir);
            this.panel7.Location = new System.Drawing.Point(513, 624);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(607, 79);
            this.panel7.TabIndex = 435;
            // 
            // chbNaoImprimir
            // 
            this.chbNaoImprimir.AutoSize = true;
            this.chbNaoImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbNaoImprimir.Location = new System.Drawing.Point(15, 43);
            this.chbNaoImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.chbNaoImprimir.Name = "chbNaoImprimir";
            this.chbNaoImprimir.Size = new System.Drawing.Size(114, 19);
            this.chbNaoImprimir.TabIndex = 477;
            this.chbNaoImprimir.Text = "NÃO IMPRIMIR";
            this.chbNaoImprimir.UseVisualStyleBackColor = true;
            // 
            // chbSelecionarImpressora
            // 
            this.chbSelecionarImpressora.AutoSize = true;
            this.chbSelecionarImpressora.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbSelecionarImpressora.Location = new System.Drawing.Point(15, 16);
            this.chbSelecionarImpressora.Margin = new System.Windows.Forms.Padding(4);
            this.chbSelecionarImpressora.Name = "chbSelecionarImpressora";
            this.chbSelecionarImpressora.Size = new System.Drawing.Size(188, 19);
            this.chbSelecionarImpressora.TabIndex = 476;
            this.chbSelecionarImpressora.Text = "SELECIONAR IMPRESSORA";
            this.chbSelecionarImpressora.UseVisualStyleBackColor = true;
            // 
            // btnBusca
            // 
            this.btnBusca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusca.Image = global::CRMagazine.Properties.Resources.lupa_24x24;
            this.btnBusca.Location = new System.Drawing.Point(487, 37);
            this.btnBusca.Margin = new System.Windows.Forms.Padding(4);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(47, 30);
            this.btnBusca.TabIndex = 296;
            this.btnBusca.UseVisualStyleBackColor = true;
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CRMagazine.Properties.Resources.LOGOBSOFT;
            this.pictureBox1.Location = new System.Drawing.Point(963, 27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 137);
            this.pictureBox1.TabIndex = 428;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.label20);
            this.panel1.Location = new System.Drawing.Point(-1, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 71);
            this.panel1.TabIndex = 461;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(8, 10);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(16, 24);
            this.lblUsuario.TabIndex = 462;
            this.lblUsuario.Text = ".";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.lblContador);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.lblUsuario);
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(309, 60);
            this.panel2.TabIndex = 462;
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContador.Location = new System.Drawing.Point(148, 32);
            this.lblContador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(16, 24);
            this.lblContador.TabIndex = 464;
            this.lblContador.Text = ".";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 32);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(131, 24);
            this.label12.TabIndex = 463;
            this.label12.Text = "PRODUÇÃO:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.txtOS);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.btnBusca);
            this.panel5.Controls.Add(this.txtCodVarejo);
            this.panel5.Location = new System.Drawing.Point(115, 272);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(615, 76);
            this.panel5.TabIndex = 463;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(280, 14);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(165, 24);
            this.label14.TabIndex = 298;
            this.label14.Text = "CODIGO VAREJO";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel6.Location = new System.Drawing.Point(443, 171);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(828, 12);
            this.panel6.TabIndex = 462;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Location = new System.Drawing.Point(476, 123);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(441, 21);
            this.panel8.TabIndex = 463;
            // 
            // cboVarejista
            // 
            this.cboVarejista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVarejista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVarejista.FormattingEnabled = true;
            this.cboVarejista.Items.AddRange(new object[] {
            "VIAVAREJO",
            "CNOVA",
            "MULTIVAREJO",
            "MAGAZINE",
            "AMERICANAS",
            "B2W",
            "EXTERNO"});
            this.cboVarejista.Location = new System.Drawing.Point(823, 209);
            this.cboVarejista.Margin = new System.Windows.Forms.Padding(4);
            this.cboVarejista.Name = "cboVarejista";
            this.cboVarejista.Size = new System.Drawing.Size(291, 33);
            this.cboVarejista.TabIndex = 464;
            this.cboVarejista.SelectedValueChanged += new System.EventHandler(this.cboVarejista_SelectedValueChanged);
            // 
            // mtbDataGaiola
            // 
            this.mtbDataGaiola.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDataGaiola.Location = new System.Drawing.Point(941, 272);
            this.mtbDataGaiola.Margin = new System.Windows.Forms.Padding(4);
            this.mtbDataGaiola.Mask = "00/00/0000";
            this.mtbDataGaiola.Name = "mtbDataGaiola";
            this.mtbDataGaiola.Size = new System.Drawing.Size(172, 37);
            this.mtbDataGaiola.TabIndex = 431;
            this.mtbDataGaiola.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbDataGaiola.ValidatingType = typeof(System.DateTime);
            this.mtbDataGaiola.TextChanged += new System.EventHandler(this.mtbDataGaiola_TextChanged);
            this.mtbDataGaiola.Leave += new System.EventHandler(this.mtbDataGaiola_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(937, 252);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 431;
            this.label4.Text = "DATA GAIOLA";
            // 
            // chbIrParaReparo
            // 
            this.chbIrParaReparo.AutoSize = true;
            this.chbIrParaReparo.Location = new System.Drawing.Point(963, 708);
            this.chbIrParaReparo.Margin = new System.Windows.Forms.Padding(4);
            this.chbIrParaReparo.Name = "chbIrParaReparo";
            this.chbIrParaReparo.Size = new System.Drawing.Size(151, 21);
            this.chbIrParaReparo.TabIndex = 540;
            this.chbIrParaReparo.Text = "ABRIR A VISTORIA";
            this.chbIrParaReparo.UseVisualStyleBackColor = true;
            // 
            // lnkAtualizar
            // 
            this.lnkAtualizar.AutoSize = true;
            this.lnkAtualizar.Location = new System.Drawing.Point(263, 194);
            this.lnkAtualizar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkAtualizar.Name = "lnkAtualizar";
            this.lnkAtualizar.Size = new System.Drawing.Size(63, 17);
            this.lnkAtualizar.TabIndex = 544;
            this.lnkAtualizar.TabStop = true;
            this.lnkAtualizar.Text = "Atualizar";
            this.lnkAtualizar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAtualizar_LinkClicked);
            // 
            // cboNotaFiscal
            // 
            this.cboNotaFiscal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cboNotaFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNotaFiscal.FormattingEnabled = true;
            this.cboNotaFiscal.Location = new System.Drawing.Point(115, 218);
            this.cboNotaFiscal.Margin = new System.Windows.Forms.Padding(4);
            this.cboNotaFiscal.Name = "cboNotaFiscal";
            this.cboNotaFiscal.Size = new System.Drawing.Size(209, 25);
            this.cboNotaFiscal.TabIndex = 543;
            this.cboNotaFiscal.SelectedValueChanged += new System.EventHandler(this.cboNotaFiscal_SelectedValueChanged);
            this.cboNotaFiscal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboNotaFiscal_KeyDown);
            // 
            // lblRestanteNF
            // 
            this.lblRestanteNF.AutoSize = true;
            this.lblRestanteNF.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestanteNF.Location = new System.Drawing.Point(333, 214);
            this.lblRestanteNF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRestanteNF.Name = "lblRestanteNF";
            this.lblRestanteNF.Size = new System.Drawing.Size(20, 29);
            this.lblRestanteNF.TabIndex = 542;
            this.lblRestanteNF.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(111, 194);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 17);
            this.label6.TabIndex = 541;
            this.label6.Text = "NOTA FISCAL";
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCT.ForeColor = System.Drawing.Color.Maroon;
            this.lblCT.Location = new System.Drawing.Point(767, 102);
            this.lblCT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(12, 18);
            this.lblCT.TabIndex = 545;
            this.lblCT.Text = ".";
            // 
            // frmVistoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 736);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.lnkAtualizar);
            this.Controls.Add(this.cboNotaFiscal);
            this.Controls.Add(this.lblRestanteNF);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chbIrParaReparo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mtbDataGaiola);
            this.Controls.Add(this.cboVarejista);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmVistoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ENTRADA";
            this.Load += new System.EventHandler(this.frmVistoria_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOS;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBusca;
        private System.Windows.Forms.MaskedTextBox mtbDataCompra;
        private System.Windows.Forms.MaskedTextBox mtbDataTroca;
        private System.Windows.Forms.TextBox txtDataCompra;
        private System.Windows.Forms.TextBox txtDataTroca;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCalculoTroca;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCalculoTroca_Hoje;
        private System.Windows.Forms.Label lblFilial;
        private System.Windows.Forms.TextBox txtFilial;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDefeitoRelatado;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnConcluir;
        private System.Windows.Forms.RadioButton rbtProcesso;
        private System.Windows.Forms.RadioButton rbtMaisDe30Dias;
        private System.Windows.Forms.RadioButton rbtSemPosto;
        private System.Windows.Forms.RadioButton rbtSemDocumento;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.LinkLabel lnkLimpar;
        private System.Windows.Forms.TextBox txtObsDocumento;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtCodVarejo;
        private System.Windows.Forms.TextBox txtNumLacre;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtNFVarejo;
        private System.Windows.Forms.RadioButton rbtMomentoZero;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.CheckBox chbSelecionarImpressora;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboVarejista;
        private System.Windows.Forms.MaskedTextBox mtbDataGaiola;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbIrParaReparo;
        private System.Windows.Forms.CheckBox chbNaoImprimir;
        private System.Windows.Forms.Label NS;
        private System.Windows.Forms.TextBox txtNS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboFuncEst;
        private System.Windows.Forms.CheckBox chbSemNS;
        private System.Windows.Forms.LinkLabel lnkAtualizar;
        private System.Windows.Forms.ComboBox cboNotaFiscal;
        private System.Windows.Forms.Label lblRestanteNF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCT;
    }
}

