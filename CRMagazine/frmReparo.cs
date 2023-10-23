using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRMagazine
{
    public partial class frmReparo : Form
    {
        public frmReparo(string Usuario, string OS, string CT)
        {
            InitializeComponent();
            lblUsuario.Text = Usuario;
            IniciaOS = OS;
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();
        Impressao imprimir = new Impressao();
        Criterios criterios = new Criterios();
        public string IniciaOS = "";


        private void frmReparo_Load(object sender, EventArgs e)
        {
            txtOS.Select();
            AtualizaContadores();

            if (IniciaOS.Length > 0)
            {
                txtOS.Text = IniciaOS;
                btnBusca.PerformClick();
            }
            else
            {
                txtOS.Select();
            }
        }

        public void AtualizaContadores()
        {
            ContarChamadoemPP();
            ContadordePP();
            ContadorDeProducao();
            ContadordePecaParaDevolver();
            ContadordePecaemAguardo();            
        }

        public void ContadorDeProducao()
        {
            consulta.DataAtual();
            string Status = "REPARO";
            consulta.comando = "select COUNT(*) as QNT from Historico where Usuario = '" + lblUsuario.Text + "' and Status = '" + Status + "' and Data = '" + consulta.dataNormal + "' and CT = '" + lblCT.Text + "'";
            consulta.consultarHistorico();
            lblContador.Text = consulta.cont.ToString();

            Status = "VISTORIA";
            consulta.comando = "select COUNT(*) as QNT from Historico where Usuario = '" + lblUsuario.Text + "' and Status = '" + Status + "' and Data = '" + consulta.dataNormal + "' and CT = '" + lblCT.Text + "'";
            consulta.consultarHistorico();
            lblContadorVist.Text = consulta.cont.ToString();

        }

        public void ContadordePecaemAguardo()
        {
            consulta.comando = "";
            consulta.comando += "Select COUNT(OS) as Quantidade from Pedidos where (Usuario = '" + lblUsuario.Text + "' or OS = '" + txtOS.Text + "') and Status in ('PP-AGUARDANDO', 'AGUARDANDO', 'ATENDIDO', 'ATENDIMENTO') and CT = '" + lblCT.Text + "' ";
            consulta.consultarSimNao();
            lblTotalPecaAguardo.Text = consulta.qntNaPosicao;
        }        

        public void ContadordePP()
        {
            consulta.comando = "";
            consulta.comando += "Select count(C.OS) as Quantidade from Estoque E, Chamados C where (E.Posicao = 'PP' or E.Posicao = 'BACKUP') ";
            consulta.comando += "AND E.Chamado = C.OS and C.Status in ('PP', 'REPARO', 'AGUARDOBACKUP') and C.Responsavel = '" + lblUsuario.Text + "' and C.CT = '" + lblCT.Text + "' ";
            consulta.consultarSimNao();
            lblTotalPP.Text = consulta.qntNaPosicao;
        }

        public void ContarChamadoemPP()
        {
            consulta.comando = "";
            consulta.comando += "select count(*) as Quantidade from Chamados where Status in ('PP', 'AGUARDOBACKUP') and Responsavel = '" + lblUsuario.Text + "' and CT = '" + lblCT.Text + "' ";
            consulta.consultarSimNao();
            lblTotalEmPP.Text = consulta.qntNaPosicao;
        }

        public void ContadordePecaParaDevolver()
        {
            if (txtOS.Text.Length > 0)
            {
                consulta.comando = "";
                consulta.comando += "Select COUNT(*) as Quantidade from Pedidos where OS = '" + txtOS.Text + "' and Status in ('RECEBIDO') and CT = '" + lblCT.Text + "' ";
                consulta.consultarSimNao();
                lblTotalPecaParaDevolver.Text = consulta.qntNaPosicao;
            }
            else
            {
                lblTotalPecaParaDevolver.Text = "0";
            }

        }



        private void btnBusca_Click(object sender, EventArgs e)
        {
            consulta.Coluna = "OS";
            consulta.ValorDesejado = txtOS.Text;
                consulta.ComData = "SIM";
               // consulta.DataDesejada = txtDataDesejadaNaoLimpar.Text;
                consulta.ConsultaTudo(lblCT.Text);
                if (consulta.Descricao == "")
                {
                    MessageBox.Show("OS NÃO ENCONTRADO.");
                }
                else if (consulta.Status != "REPARO")
                {
                    MessageBox.Show("OS NÃO ESTA EM REPARO.\r\nSTATUS = " + consulta.Status);
                }
                else
                {
                    txtDescricao.Text = consulta.Descricao;
                    txtNS.Text = consulta.Chamado;
                    txtTipo.Text = consulta.TipoEquip;
                    txtSKU.Text = consulta.SKU;
                    txtVarejista.Text = consulta.Varejista;
                    txtCodVarejo.Text = consulta.CodVarejo;
                    DesembaladoNaEntrada();
                    if (txtNS.Text.Length == 0)
                    {
                        txtNS.Select();
                    }
                    else
                    {

                    }
                    /*
                    txtIMEI1.Text = consulta.IMEI1;
                    txtIMEI2.Text = consulta.IMEI2;
                    txtNF.Text = consulta.NF;
                    txtInicioGarantia.Text = consulta.DtFatura;
                    txtCalculoGarantia.Text = consulta.Meses;
                    txtOrcamento.Text = consulta.Orcamento;
                    txtDiasTroca.Text = consulta.DiasTroca;
                    txtDiasVistoria.Text = consulta.DiasVistoria;
                    txtObsDocumento.Text = consulta.ObsDocumento;                    
                    txtDefeitoRelatado.Text = consulta.DefeitoRelatado;
                     */
                    try
                    {
                        consulta.DataAtual();
                        string hoje = consulta.dataNormal;
                        DateTime dt = Convert.ToDateTime(consulta.DtEntrada);

                        txtDataEntrada.Text = dt.ToString("dd/MM/yyyy");
                        string DtEntrada = dt.ToString("dd/MM/yyyy");

                        DateTime data_hoje = Convert.ToDateTime(hoje);
                        DateTime data_entrada = Convert.ToDateTime(DtEntrada);
                        TimeSpan dif = data_hoje.Subtract(data_entrada);
                        int dias = dif.Days;
                        txtDias.Text = dias.ToString();
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show("ERRO CONVERSÃO DA DATA ENTRADA:\r\r" + x.Message);
                    }
                    
                    
                    ContadordePecaParaDevolver();

                    /*
                    consulta.comando = "";
                    consulta.comando += "select count(Chamado) as Quantidade from SalvarTecnica where Chamado = '" + txtNS.Text + "' AND Status != 'FINALIZADO'";
                    consulta.consultarSimNao();
                    if (Convert.ToInt32(consulta.qntNaPosicao) > 0)
                    {
                        PreencheSalvarTecnica();
                    }
                    */
                }
        }

        public void DesembaladoNaEntrada()  // se as informações da SAT já foram inseridas na entrada preenche automaticamente as informações; ou se os acessorios foram preenchidos na entrada então o lst recebe as informações.
        {
            if (consulta.NS != "")
            {
                txtNS.Text = consulta.NS;
            }
            if(consulta.Classificacao == "ORCAMENTO")
            {
                chbSemEmbalagem.Checked = true;
            }
            if (consulta.Filial != "")
            {
                txtFilial.Text = consulta.Filial;
            }

            if (consulta.DtCompra != "")
            {
                mtbDataCompra.Text = consulta.DtCompra;
            }

            if (consulta.DtTroca != "")
            {
                mtbDataTroca.Text = consulta.DtTroca;
            }
            if (consulta.DefeitoRelatado != "")
            {
                // txtDefeitoRelatado.Text = consulta.DefeitoRelatado;
                string Utilizacao = consulta.DefeitoRelatado;
                if (!Utilizacao.Contains("/"))
                {
                    txtDefeitoRelatado.Text = Utilizacao;
                }
                else
                {
                    try
                    {
                        //cboDefeitoSAT.Text = consulta.DefeitoRelatado;

                        int indiceDoPrimeiroUnderline = Utilizacao.IndexOf("/");
                        string texto = (Utilizacao.Substring(0, (indiceDoPrimeiroUnderline)));
                        cboFuncEst.Text = texto.Trim();
                        txtDefeitoRelatado.Text = Utilizacao.Substring(indiceDoPrimeiroUnderline + 1).Trim();
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(x.Message);
                    }
                }
            }
            if (consulta.NumLacre != "")
            {
                txtNumLacre.Text = consulta.NumLacre;
            }
            if (consulta.ObsDocumento != "")
            {
                switch (consulta.ObsDocumento)
                {
                    case "SemDocumento":
                        rbtSemDocumento.Checked = true;
                        break;
                    case "MaisDe30Dias":
                        rbtMaisDe30Dias.Checked = true;
                        break;
                    case "Processo":
                        rbtProcesso.Checked = true;
                        break;
                    case "SemPosto":
                        rbtSemPosto.Checked = true;
                        break;
                    default:
                        break;
                }
            }

            /*
            if (consulta.ItensFaltantes != "")
            {
                string Utilizacao = consulta.ItensFaltantes;
                lstFaltantes.Items.Clear();
                if (!Utilizacao.Contains("|"))
                {
                    lstFaltantes.Items.Add(Utilizacao);
                }
                else
                {
                    while (Utilizacao.Contains("|"))
                    {
                        int indiceDoPrimeiroUnderline = Utilizacao.IndexOf("|");
                        string texto = (Utilizacao.Substring(0, (indiceDoPrimeiroUnderline)));
                        lstFaltantes.Items.Add(texto);
                        Utilizacao = Utilizacao.Substring(indiceDoPrimeiroUnderline + 1);
                        if (!Utilizacao.Contains("|"))
                        {
                            lstFaltantes.Items.Add(Utilizacao);
                        }
                    }
                }
                recebeFaltantes();
            }
             */ 

            if (consulta.ItensFaltantes == "SEM EMBALAGEM")
            {
                chbSemEmbalagem.Checked = true;
            }
                

            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtTipo_TextChanged(object sender, EventArgs e)
        {
           //// cboEstetico.Items.Clear();
            //cboFuncional.Items.Clear();
           // cboFaltantes.Items.Clear();
           // cboReparo.Items.Clear();
         //   TratarModelo();
            if (txtTipo.Text.Length > 0)
            {
                PreencherComboboxEst();
                PreencherComboboxFun();
            }            
        }

        public void PreencherComboboxEst()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql += " Select Item from CheckListGeral where TipoEquip = '" + txtTipo.Text + "' and Especie = 'Estetico'";
            cx.Conectar();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "CheckListGeral");
            cboEstetico.ValueMember = "idCheckList";
            cboEstetico.DisplayMember = "Item";
            cboEstetico.DataSource = ds.Tables["CheckListGeral"];
            cx.Desconectar();
            cboEstetico.Text = null;
            cboEstetico.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboEstetico.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void PreencherComboboxFun()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql = "";
            sql += " Select Item from CheckListGeral where TipoEquip = '" + txtTipo.Text + "' and Especie = 'Funcional'";
            cx.Conectar();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "CheckListGeral");
            cboFuncional.ValueMember = "idCheckList";
            cboFuncional.DisplayMember = "Item";
            cboFuncional.DataSource = ds.Tables["CheckListGeral"];
            cx.Desconectar();
            cboFuncional.Text = null;
            cboFuncional.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboFuncional.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        /*
        public void TratarModelo()
        {
            String[] SMART = new String[] { "SEM AVARIAS", "LCD", "PLM", "TAMPA TRASEIRA", "CONJUNTO TRASEIRO", "BATERIA", "LATERAL" };
            String[] FEATURE = new String[] { "SEM AVARIAS", "LCD", "PLM", "TAMPA TRASEIRA", "CONJUNTO TRASEIRO", "BATERIA", "TECLADO", "LATERAL" };
            String[] NOTEBOOK = new String[] { "SEM AVARIAS", "LCD", "PLM", "MOLDURA", "TAMPA DO LCD", "TAMPA FRONTAL", "TAMPA TRASEIRA", "TECLADO", "DVD" };
            String[] DESKTOP = new String[] { "SEM AVARIAS", "PLM", "PAINEL FRONTAL", "GABINETE", "TAMPA ESQUERDA", "TAMPA DIREITA", "DVD" };
            String[] UNION = new String[] { "SEM AVARIAS", "LCD", "PLM", "TAMPA FONTAL", "TAMPA TRASEIRA", "DVD" };
            String[] TABLET = new String[] { "SEM AVARIAS", "LCD", "PLM", "TAMPA TRASEIRA" };
            String[] GENERICO = new String[] { "SEM AVARIAS", "LCD", "PLM", "FRONTAL", "TRASEIRA" };

            String[] FUNCIONAL = new String[] { "SEM DEFEITO", "NÃO LIGA", "SEM VIDEO", "TRAVANDO", "REINICIANDO", "IMAGEM", "AUTO FALANTE", "SEM AUDIO", "AQUECIMENTO", "PLM", "NÃO RECONHECE FONE" };

            String[] FSMART = new String[] { "CAMERA FRONTAL", "CAMERA TRASEIRA", "LCD", "WLAN", "BATERIA", "MICROFONE", "CONECTOR SD", "CONECTOR SIM", "TOUCH", "BOTÃO VOLUME", "BOTÃO POWER" };
            String[] FFEATURE = new String[] { "CAMERA FRONTAL", "CAMERA TRASEIRA", "LCD", "TECLADO", "WLAN", "BATERIA", "MICROFONE", "CONECTOR SD", "CONECTOR SIM", "TOUCH", "BOTÃO VOLUME", "BOTÃO POWER", "LANTERNA" };

            String[] FNOTE = new String[] { "DRIVERS", "WEBCAM", "LCD", "TECLADO", "DVD", "USB", "HDD", "TV", "WLAN", "BATERIA", "MICROFONE", "MOUSE" };
            String[] FDESK = new String[] { "DRIVERS", "LCD", "DVD", "USB", "HDD", "TV", "TECLADO", "MOUSE" };
            String[] FUNION = new String[] { "DRIVERS", "WEBCAM", "LCD", "TECLADO", "DVD", "USB", "HDD", "TV", "WLAN", "MOUSE" };

            String[] FTAB = new String[] { "CAMERA FRONTAL", "CAMERA TRASEIRA", "LCD", "WLAN", "TV", "BATERIA", "MICROFONE" };


            String[] REPARO = new String[] { "SALDO-A", "RESTAURAÇÃO DE IMAGEM", "BIOS", "TROCA LCD", "TROCA TAMPA", "TROCA DE HD", "TROCA DE AUTO FALANTE", "ENCAIXE DO CABO FLAT" };

            string[] FALTANTES = new String[] { "COMPLETO", "FONTE", "CABO USB", "FONE", "VGA", "BATERIA", "CARTÃO DE MEMORIA" };

            switch (txtTipo.Text)
            {
                case "SMART":
                    cboEstetico.Items.AddRange(SMART);
                    cboFuncional.Items.AddRange(FUNCIONAL);
                    cboFuncional.Items.AddRange(FSMART);
                    cboReparo.Items.AddRange(REPARO);
                    cboFaltantes.Items.AddRange(FALTANTES);
                    break;
                case "FEATURE":
                    cboEstetico.Items.AddRange(FEATURE);
                    cboFuncional.Items.AddRange(FUNCIONAL);
                    cboFuncional.Items.AddRange(FFEATURE);
                    cboReparo.Items.AddRange(REPARO);
                    cboFaltantes.Items.AddRange(FALTANTES);
                    break;
                case "NOTEBOOK":
                    cboEstetico.Items.AddRange(NOTEBOOK);
                    cboFuncional.Items.AddRange(FUNCIONAL);
                    cboFuncional.Items.AddRange(FNOTE);
                    cboReparo.Items.AddRange(REPARO);
                    cboFaltantes.Items.AddRange(FALTANTES);
                    break;
                case "DESKTOP":
                    cboEstetico.Items.AddRange(DESKTOP);
                    cboFuncional.Items.AddRange(FUNCIONAL);
                    cboFuncional.Items.AddRange(FDESK);
                    cboReparo.Items.AddRange(REPARO);
                    cboFaltantes.Items.AddRange(FALTANTES);
                    break;
                case "UNION":
                    cboEstetico.Items.AddRange(UNION);
                    cboFuncional.Items.AddRange(FUNCIONAL);
                    cboFuncional.Items.AddRange(FUNION);
                    cboReparo.Items.AddRange(REPARO);
                    cboFaltantes.Items.AddRange(FALTANTES);
                    break;
                case "TABLET":
                    cboEstetico.Items.AddRange(TABLET);
                    cboFuncional.Items.AddRange(FUNCIONAL);
                    cboFuncional.Items.AddRange(FTAB);
                    cboReparo.Items.AddRange(REPARO);
                    cboFaltantes.Items.AddRange(FALTANTES);
                    break;
                default:
                    cboEstetico.Items.AddRange(GENERICO);
                    cboFuncional.Items.AddRange(FUNCIONAL);
                    cboReparo.Items.AddRange(REPARO);
                    cboFaltantes.Items.AddRange(FALTANTES);
                    break;
            }
        }
         */ 

        public void Reset()
        {
            consulta.LimparControles(this);
            lstEstetico.BackColor = DefaultBackColor;
            lstFuncional.BackColor = DefaultBackColor;
            lstFaltantes.BackColor = DefaultBackColor;
           // cboEstetico.Items.Clear();
           // cboFuncional.Items.Clear();
           // cboFaltantes.Items.Clear();
          //  txtCodPeca.Enabled = false;
          //  txtCodPeca2.Enabled = false;
          //  txtCodPeca3.Enabled = false;
          //  txtCodPeca4.Enabled = false;
          //  txtCodPeca5.Enabled = false;
            AtualizaContadores();
            txtOS.Select();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DESEJA LIMPAR A TELA?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Reset();
            }
        }

        
        public void CalcularClassificacao()
        {           
            string check;
            Verificacao(out check);
            if (check == "falha")
            {
                consulta.PlayFail();
                MessageBox.Show("OS CAMPOS OBRIGATÓRIOS DEVEM ESTAR PREENCHIDOS.");
            }
           // else if (txtCalculoGarantia.Text.Length == 0)
           // {
           //     consulta.PlayFail();
           //     MessageBox.Show("NÃO É POSSIVEL CALCULAR GARANTIA, POIS A DATA DA COMPRA ESTA VAZIA.");
           // }
            else
            {
                CalcularCriterios();
                //txtClassificacao.Text = criterios.Classificacao;
                if (lstReparo.Items.Count > 0)
                {
                    txtTipoReparo.Text = "REPARO";
                }
                else
                {
                    txtTipoReparo.Text = "SEM REPARO";
                }             
                consulta.PlayOK();             

            }     
             //*/
        }

        public void CalcularCriterios()
        {
            if (chbSemEmbalagem.Checked == true)
            {
                txtClassificacao.Text = "ORCAMENTO";
            }
            else if (txtEstetico.Text != "SEM AVARIAS" && txtFuncional.Text == "SEM DEFEITO")
            {
                txtClassificacao.Text = "ORCAMENTO";
            }
            else
            {
                txtClassificacao.Text = "GARANTIA";
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            CalcularClassificacao();
        }

        public string check = "";
        public void Verificacao(out string check)
        {
            check = "";

            //===== OS
            if (txtOS.Text.Length == 0)
            {
                check = "falha";
                txtOS.BackColor = Color.Tomato;
            }
            else
            {
                txtOS.BackColor = DefaultBackColor;
            }

            if (txtOS.Text.Length == 0)
            {
                check = "falha";
                txtOS.BackColor = Color.Tomato;
            }
            else
            {
                txtOS.BackColor = DefaultBackColor;
            }        

            //===== NUMERO SERIE
            if (txtNS.Text.Length == 0)
            {
                check = "falha";
                txtNS.BackColor = Color.Tomato;
            }
            else
            {
                txtOS.BackColor = DefaultBackColor;
            }

            if (txtNS.Text.Length == 0)
            {
                check = "falha";
                txtNS.BackColor = Color.Tomato;
            }
            else
            {
                txtNS.BackColor = DefaultBackColor;
            }        

            /*
            //===== IMEI1.
            if (txtIMEI1.Text.Length == 0 && (txtTipo.Text == "SMART" || txtTipo.Text == "FEATURE"))
            {
                check = "falha";
                txtIMEI1.BackColor = Color.Tomato;
            }
            else
            {
                txtIMEI1.BackColor = DefaultBackColor;
            }

            //===== IMEI2.
            if (txtIMEI2.Text.Length == 0 && (txtTipo.Text == "SMART" || txtTipo.Text == "FEATURE"))
            {
                check = "falha";
                txtIMEI2.BackColor = Color.Tomato;
            }
            else
            {
                txtIMEI2.BackColor = DefaultBackColor;
            }
            */
            //===== TIPO.
            if (txtTipo.Text.Length == 0)
            {
                check = "falha";
                txtTipo.BackColor = Color.Tomato;
            }
            else
            {
                txtTipo.BackColor = DefaultBackColor;
            }
                 
            //===== ESTETICO
            if (lstEstetico.Items.Count <= 0)
            {
                check = "falha";
                lstEstetico.BackColor = Color.Tomato;
            }
            else
            {
                lstEstetico.BackColor = DefaultBackColor;
            }



            //===== FUNCIONAL
            if (lstFuncional.Items.Count <= 0)
            {
                check = "falha";
                lstFuncional.BackColor = Color.Tomato;
            }
            else
            {
                lstFuncional.BackColor = DefaultBackColor;
            }


            /*
            //===== ITENS (ACESSÓRIOS)
            if (lstFaltantes.Items.Count <= 0)
            {
                check = "falha";
                lstFaltantes.BackColor = Color.Tomato;
            }
            else
            {
                lstFaltantes.BackColor = DefaultBackColor;
            }
             */ 
        }


        /*
        public void CalcularCriterios()
        {
            criterios.tempotroca = txtDiasTroca.Text;
            criterios.tempotriagem = txtDiasVistoria.Text;
            criterios.motivo = txtFuncional.Text;
            criterios.garantia = txtCalculoGarantia.Text;
            //==========================================
            if (txtEstetico.Text == "SEM AVARIAS")
            {
                criterios.estadoequipamento = txtEstetico.Text;
            }
            else if (
                !txtEstetico.Text.Contains("RISCADO") &&
                !txtEstetico.Text.Contains("QUEBRADO") &&
                !txtEstetico.Text.Contains("AMASSADO") &&
                !txtEstetico.Text.Contains("MANCHADO")
                )
            {
                criterios.estadoequipamento = "SEM AVARIAS";
            }
            else
            {
                criterios.estadoequipamento = txtEstetico.Text;
            }
            //===========================================
            criterios.acessorios = txtFaltantes.Text;

            if (txtDefeito1.Text.Length > 0)
            {
                criterios.retencao = "SALDO";
            }
            else
            {
                criterios.retencao = "";
            }            
            criterios.semdocumento = "";
            
            if (chbForaGarantia.Checked)
            {
                criterios.ForaGarantia = "ForaGarantia";
            }
            else
            {
                criterios.ForaGarantia = "";
            }
              

            criterios.flag = "";
            if (txtObsDocumento.Text == "MomentoZero")
            {
                criterios.tempotroca = "0";
                criterios.tempotriagem = "0";
            }
            else if (txtObsDocumento.Text == "SemDocumento")
            {
                criterios.semdocumento = "SIM";
                criterios.tempotroca = "0";
                criterios.tempotriagem = "0";
            }
            else if (txtObsDocumento.Text == "SemPosto")
            {
                criterios.flag = "SemPosto";
            }
            else if (txtObsDocumento.Text == "MaisDe30Dias")
            {
                criterios.flag = "MaisDe30Dias";
            }
            else if (txtObsDocumento.Text == "Processo")
            {
                criterios.flag = "Processo";
            }



            //==============================================

            //============= ESPECIAL PARA FEATURES ========================
            if (txtTipo.Text == "FEATURE")  // insirido a pedido do Danilo... se for feature fone é independente de documentação (por isso chama um critétio especifo para feature)
            {
                criterios.FeaturePhone();
            }
            //=============================================================
           // else if (txtVarejista.Text == "MagazineLuiza")
            else
            {
                criterios.MagazineLojaFisica();
            }

       
        }

       */

        // ================= ESTÉTICO =================================

        private void btnAddEst_Click(object sender, EventArgs e)
        {
            //=============CHECA SE EXISTE O QUE ESTA NO CBO.TEXT EXISTE NA LISTA
            string check = "falha";
            for (int i = 0; i < cboEstetico.Items.Count; i++)
            {
                string value = cboEstetico.GetItemText(cboEstetico.Items[i]);
                if (value == cboEstetico.Text)
                {
                    check = "ok";
                    break;
                }
            }

            if (check == "ok")
            {
                int pos = lstEstetico.FindString(cboEstetico.Text);

                // AQUI FOI MODIFICADO POR CAUSA DO EXCEL SER GERADO NESSE FORME(System.Windows.Forms.ListBox.NoMatches) ANTES ERA SOMENTE (ListBox.NoMatches)
                if (pos != System.Windows.Forms.ListBox.NoMatches)
                {
                    consulta.PlayFail();
                    MessageBox.Show("ITEM JÁ CADASTRADO.");
                }
                else if (cboEstetico.Text.Length == 0 || cboClassificacao.Text.Length == 0 && cboEstetico.Text != "SEM AVARIAS")
                {
                    consulta.PlayFail();
                    MessageBox.Show("SELECIONE OS ITENS.");
                }
                else if (cboEstetico.Text == "SEM AVARIAS" && txtEstetico.Text.Length > 0)
                {
                    consulta.PlayFail();
                    MessageBox.Show("REMOVA AS AVARIAS JÁ CADASTRADAS.");
                }
                else if (txtEstetico.Text.Contains("SEM AVARIAS"))
                {
                    consulta.PlayFail();
                    MessageBox.Show("REMOVA O 'SEM AVARIAS'.");
                }
                else
                {
                    if (cboEstetico.Text == "SEM AVARIAS")
                    {
                        lstEstetico.Items.Add(cboEstetico.Text);
                    }
                    else
                    {
                        lstEstetico.Items.Add(cboEstetico.Text + " - " + cboClassificacao.Text);
                    }
                    cboEstetico.Text = null;
                    cboClassificacao.Text = null;
                    cboEstetico.Select();
                    recebeEstetico();
                }
            }
            else
            {
                MessageBox.Show("ITEM INVÁLIDO");
            }
        }

        private void btnRemEst_Click(object sender, EventArgs e)
        {
            lstEstetico.Items.Remove(lstEstetico.SelectedItem);
            recebeEstetico();
        }

        public void recebeEstetico()
        {
            txtEstetico.Text = "";
            int rows = lstEstetico.Items.Count;
            foreach (string item in lstEstetico.Items)
            {
                if (rows > 1)
                {
                    txtEstetico.Text += item + " | ";
                }
                else
                {
                    txtEstetico.Text += item;
                }
                rows--;
            }
        }

       
        // ================= FIM ESTÉTICO ==============================

        private void btnAddFun_Click(object sender, EventArgs e)
        {
            
            //=============CHECA SE EXISTE O QUE ESTA NO CBO.TEXT EXISTE NA LISTA
            string check = "falha";
            for (int i = 0; i < cboFuncional.Items.Count; i++)
            {
                string value = cboFuncional.GetItemText(cboFuncional.Items[i]);
                if (value == cboFuncional.Text)
                {
                    check = "ok";
                    break;
                }
            }
             

            if (check == "ok") // CONFIRMA SE EXISTE O ITEM
            {
                if (lstFuncional.Items.Contains(cboFuncional.Text))
                {
                    consulta.PlayFail();
                    MessageBox.Show("ITEM JÁ CADASTRADO.");
                }
                else if (cboFuncional.Text == "SEM DEFEITO" && txtFuncional.Text.Length > 0)
                {
                    consulta.PlayFail();
                    MessageBox.Show("REMOVA OS FUNCIONAIS JÁ CADASTRADOS.");
                }
                else if (txtFuncional.Text.Contains("SEM DEFEITO"))
                {
                    consulta.PlayFail();
                    MessageBox.Show("REMOVA O 'SEM DEFEITO'.");
                }
                else if (cboFuncional.Text.Length == 0)
                {
                    consulta.PlayFail();
                    MessageBox.Show("SELECIONE O ITEM.");
                }
                else
                {
                    lstFuncional.Items.Add(cboFuncional.Text);
                    cboFuncional.Text = null;
                    cboFuncional.Select();
                    recebeFuncional();
                }
            }
            else
            {
                MessageBox.Show("ITEM INVÁLIDO");
            }
        }

        private void btnRemFun_Click(object sender, EventArgs e)
        {
            lstFuncional.Items.Remove(lstFuncional.SelectedItem);
            recebeFuncional();
        }

        public void recebeFuncional()
        {
            txtFuncional.Text = "";
            int rows = lstFuncional.Items.Count;
            foreach (string item in lstFuncional.Items)
            {
                if (rows > 1)
                {
                    txtFuncional.Text += item + " | ";
                }
                else
                {
                    txtFuncional.Text += item;
                }
                rows--;
            }
        }       
        // ================= FIM FUNCIONAL =============================


        // ================= FALTANTES =================================

        private void btnAddFal_Click(object sender, EventArgs e)
        {
            if (lstFaltantes.Items.Contains(cboFaltantes.Text))
            {
                consulta.PlayFail();
                MessageBox.Show("ITEM JÁ CADASTRADO.");
            }
            else if (cboFaltantes.Text == "COMPLETO" && txtFaltantes.Text.Length > 0)
            {
                consulta.PlayFail();
                MessageBox.Show("REMOVA OS ITENS JÁ CADASTRADOS.");
            }
            else if (txtFaltantes.Text.Contains("COMPLETO"))
            {
                consulta.PlayFail();
                MessageBox.Show("REMOVA O 'COMPLETO'.");
            }
            else if (cboFaltantes.Text.Length == 0)
            {
                consulta.PlayFail();
                MessageBox.Show("SELECIONE O ITEM.");
            }
            else
            {
                lstFaltantes.Items.Add(cboFaltantes.Text);
                cboFaltantes.Text = null;
                cboFaltantes.Select();
                recebeFaltantes();
            }        
        }

        private void btnRemFal_Click(object sender, EventArgs e)
        {
            lstFaltantes.Items.Remove(lstFaltantes.SelectedItem);
            recebeFaltantes();
        }

        public void recebeFaltantes()
        {
            txtFaltantes.Text = "";
            int rows = lstFaltantes.Items.Count;
            foreach (string item in lstFaltantes.Items)
            {
                if (rows > 1)
                {
                    txtFaltantes.Text += item + " | ";
                }
                else
                {
                    txtFaltantes.Text += item;
                }
                rows--;
            }
        }
        // ================= FIM FALTANTES ==============================


        public void AdicionarNaLista()
        {
           
            string Aux = "";
            Aux += " '" + txtDefeito.Text + "', ";
            Aux += " '" + txtCodPeca.Text + "', ";
            Aux += " '" + txtDescPeca.Text + "', ";       
            if (lstReparo.Items.Contains(Aux))
            {
                MessageBox.Show("PEÇA JÁ INSERIDA NO PEDIDO");
            }
            else
            {
                lstReparo.Items.Add(Aux);
                txtDefeito.Text = "";
                txtCodPeca.Text = "";
                txtDescPeca.Text = "";
                txtDefeito.Select();
            }
        }

        private void btnAddReparo_Click(object sender, EventArgs e)
        {
            AdicionarNaLista();
            /*
            if (lstReparo.Items.Contains(cboReparo.Text))
            {
                consulta.PlayFail();
                MessageBox.Show("ITEM JÁ CADASTRADO.");
            }
            else if (cboReparo.Text.Length == 0)
            {
                consulta.PlayFail();
                MessageBox.Show("SELECIONE O ITEM.");
            }
            else
            {
                lstReparo.Items.Add(cboReparo.Text);
                cboReparo.Text = null;
                cboReparo.Select();
                recebeReparo();
            }    
             */ 
        }

        private void btnRemReparo_Click(object sender, EventArgs e)
        {
            lstReparo.Items.Remove(lstReparo.SelectedItem);
            recebeReparo();
        }

        public void recebeReparo()
        {
            txtReparo.Text = "";
            int rows = lstReparo.Items.Count;
            foreach (string item in lstReparo.Items)
            {
                if (rows > 1)
                {
                    txtReparo.Text += item + " | ";
                }
                else
                {
                    txtReparo.Text += item;
                }
                rows--;
            }
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

       

        

        private void btnSolicitarPeca_Click(object sender, EventArgs e)
        {
            if (txtNS.Text.Length == 0 || txtNS.Text == "PENDENTE")
            {
                MessageBox.Show("É NECESSÁRIO INFORMAR O NS PARA SOLICITAR A PEÇA");
            }
            else
            {
                frmEstoqueSolicitarPecasInterno c = new frmEstoqueSolicitarPecasInterno(lblUsuario.Text, txtOS.Text, txtSKU.Text, txtNS.Text, "BACKUP", lblCT.Text);
                c.ShowDialog();
                AtualizaContadores();
                /*
                consulta.Coluna = "OS";
                consulta.ValorDesejado = txtOS.Text;
                consulta.ComData = "SIM";
                // consulta.DataDesejada = txtDataDesejadaNaoLimpar.Text;
                consulta.ConsultaTudo();
                if (consulta.Status == "AGUARDOBACKUP")
                {
                    MessageBox.Show("EQUIPAMENTO ENVIADO PARA AGUARDOBACKUP.");
                    Reset();                
                }   
                 */ 
            }
            
        }

      
        // ================= FIM RETENÇÃO ===============================


        /*
        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((cbxNaturezaDeAtendimento.Text.Length == 0 || cbxRecursoComponente.Text.Length == 0 || cbxDescricaoDoProblema.Text.Length == 0 || cbxSolucaoAplicada.Text.Length == 0) && (chbEstetico.Checked == false && chbImagem.Checked == false && chbPecaNaoUtilizada.Checked == false))
            {
                MessageBox.Show("Os campos devem estar preenchidos");
            }
            else
            {
                txtClassificacao.Text = ""; // zera a classificação, pq esse campo pode mudar a classificação
                if (txtDefeito1.Text.Length == 0)
                {
                    if (chbEstetico.Checked == true)
                    {
                        txtDefeito1.Text = "ESTÉTICO";
                    }
                    else if (chbImagem.Checked == true)
                    {
                        txtDefeito1.Text = "IMAGEM";
                        txtCodPeca1.Text = "S/N";
                    }
                    else if (chbPecaNaoUtilizada.Checked == true)
                    {
                        //=========CANCELAMENTO DE PEÇA================================================================
                        int i = 1;
                        //CancelarPeca(i);
                        OrganizaPosicao(i);
                        //=============================================================================================                        
                    }
                    else
                    {
                        txtDefeito1.Text = cbxNaturezaDeAtendimento.Text + " | " + cbxRecursoComponente.Text + " | " + cbxDescricaoDoProblema.Text + " | " + cbxSolucaoAplicada.Text;
                    }
                    txtCodPeca1.Enabled = true;
                    txtSerialAntigo1.Enabled = true;
                    txtSerialNovo1.Enabled = true;
                    txtCodPeca1.Select();
                    cbxNaturezaDeAtendimento.Text = "";
                    chbImagem.Checked = false;
                }
                else if (txtDefeito2.Text.Length == 0)
                {
                    if (chbEstetico.Checked == true)
                    {
                        txtDefeito2.Text = "ESTÉTICO";
                    }
                    else if (chbImagem.Checked == true)
                    {
                        txtDefeito2.Text = "IMAGEM";
                        txtCodPeca2.Text = "S/N";
                    }
                    else if (chbPecaNaoUtilizada.Checked == true)
                    {
                        int i = 2;
                      //  CancelarPeca(i);
                        OrganizaPosicao(i);
                    }
                    else
                    {
                        txtDefeito2.Text = cbxNaturezaDeAtendimento.Text + " | " + cbxRecursoComponente.Text + " | " + cbxDescricaoDoProblema.Text + " | " + cbxSolucaoAplicada.Text;
                    }
                    txtCodPeca2.Enabled = true;
                    txtSerialAntigo2.Enabled = true;
                    txtSerialNovo2.Enabled = true;
                    txtCodPeca2.Select();
                    cbxNaturezaDeAtendimento.Text = "";
                    chbImagem.Checked = false;
                }
                else if (txtDefeito3.Text.Length == 0)
                {
                    if (chbEstetico.Checked == true)
                    {
                        txtDefeito3.Text = "ESTÉTICO";
                    }
                    else if (chbImagem.Checked == true)
                    {
                        txtDefeito3.Text = "IMAGEM";
                        txtCodPeca3.Text = "S/N";
                    }
                    else if (chbPecaNaoUtilizada.Checked == true)
                    {
                        int i = 3;
                       // CancelarPeca(i);
                        OrganizaPosicao(i);
                    }
                    else
                    {
                        txtDefeito3.Text = cbxNaturezaDeAtendimento.Text + " | " + cbxRecursoComponente.Text + " | " + cbxDescricaoDoProblema.Text + " | " + cbxSolucaoAplicada.Text;
                    }
                    txtCodPeca3.Enabled = true;
                    txtSerialAntigo3.Enabled = true;
                    txtSerialNovo3.Enabled = true;
                    txtCodPeca3.Select();
                    cbxNaturezaDeAtendimento.Text = "";
                    chbImagem.Checked = false;
                }
                else if (txtDefeito4.Text.Length == 0)
                {
                    if (chbEstetico.Checked == true)
                    {
                        txtDefeito4.Text = "ESTÉTICO";
                    }
                    else if (chbImagem.Checked == true)
                    {
                        txtDefeito4.Text = "IMAGEM";
                        txtCodPeca4.Text = "S/N";
                    }
                    else if (chbPecaNaoUtilizada.Checked == true)
                    {
                        int i = 4;
                       // CancelarPeca(i);
                        OrganizaPosicao(i);
                    }
                    else
                    {
                        txtDefeito4.Text = cbxNaturezaDeAtendimento.Text + " | " + cbxRecursoComponente.Text + " | " + cbxDescricaoDoProblema.Text + " | " + cbxSolucaoAplicada.Text;
                    }
                    txtCodPeca4.Enabled = true;
                    txtSerialAntigo4.Enabled = true;
                    txtSerialNovo4.Enabled = true;
                    txtCodPeca4.Select();
                    cbxNaturezaDeAtendimento.Text = "";
                    chbImagem.Checked = false;
                }
                else if (txtDefeito5.Text.Length == 0)
                {
                    if (chbEstetico.Checked == true)
                    {
                        txtDefeito5.Text = "ESTÉTICO";
                    }
                    else if (chbImagem.Checked == true)
                    {
                        txtDefeito5.Text = "IMAGEM";
                        txtCodPeca5.Text = "S/N";
                    }
                    else if (chbPecaNaoUtilizada.Checked == true)
                    {
                        int i = 5;
                       // CancelarPeca(i);
                        OrganizaPosicao(i);
                    }
                    else
                    {
                        txtDefeito5.Text = cbxNaturezaDeAtendimento.Text + " | " + cbxRecursoComponente.Text + " | " + cbxDescricaoDoProblema.Text + " | " + cbxSolucaoAplicada.Text;
                    }
                    txtCodPeca5.Enabled = true;
                    txtSerialAntigo5.Enabled = true;
                    txtSerialNovo5.Enabled = true;
                    txtCodPeca5.Select();
                    cbxNaturezaDeAtendimento.Text = "";
                    chbImagem.Checked = false;
                }
                else
                {
                    MessageBox.Show("Invalido");
                }                              
            }
        }
         

        public void OrganizaPosicao(int i)
        {
            int cont = i;
            int i2 = 0;
            for (int x = 5; x > cont; x--)
            {
                i2 = i + 1;
                this.pnlComPecas.Controls["txtDefeito" + i.ToString()].Text = this.pnlComPecas.Controls["txtDefeito" + i2.ToString()].Text;
                this.pnlComPecas.Controls["txtCodPeca" + i.ToString()].Text = this.pnlComPecas.Controls["txtCodPeca" + i2.ToString()].Text;
                this.pnlComPecas.Controls["txtDescPeca" + i.ToString()].Text = this.pnlComPecas.Controls["txtDescPeca" + i2.ToString()].Text;
                this.pnlComPecas.Controls["txtSerialNovo" + i.ToString()].Text = this.pnlComPecas.Controls["txtSerialNovo" + i2.ToString()].Text;
                i = i + 1;
            }
            if (cont == 5)
            {
                this.pnlComPecas.Controls["txtDefeito" + i.ToString()].Text = "";
                this.pnlComPecas.Controls["txtCodPeca" + i.ToString()].Text = "";
                this.pnlComPecas.Controls["txtDescPeca" + i.ToString()].Text = "";
                this.pnlComPecas.Controls["txtSerialNovo" + i.ToString()].Text = "";
            }
            else
            {
                this.pnlComPecas.Controls["txtDefeito" + i2.ToString()].Text = "";
                this.pnlComPecas.Controls["txtCodPeca" + i2.ToString()].Text = "";
                this.pnlComPecas.Controls["txtDescPeca" + i2.ToString()].Text = "";
                this.pnlComPecas.Controls["txtSerialNovo" + i2.ToString()].Text = "";
            }
        }


        public void CancelarPeca(int i)
        {
            string Codigo = this.pnlComPecas.Controls["txtCodPeca" + i.ToString()].Text;
            double num;
            if (double.TryParse(Codigo, out num))
            {
                consulta.comando = "";
                consulta.comando += "Select count(Codigo) as Quantidade from Pedidos where OS = '" + txtOS.Text + "' and Codigo = '" + Codigo + "' and Status = 'RECEBIDO' ";
                consulta.consultarSimNao();
                if (Convert.ToInt32(consulta.qntNaPosicao) > 0)
                {
                    consulta.DataAtual();
                    consulta.comando = "";
                    consulta.comando += "update Pedidos set Status = 'RETORNO', HoraFinalizacao = '" + consulta.dataCompleta + "' where ";
                    consulta.comando += "idPedidos = (select min(IdPedidos) from Pedidos where Codigo = '" + this.pnlComPecas.Controls["txtCodPeca" + i.ToString()].Text + "' and OS = '" + txtOS.Text + "' and Status = 'RECEBIDO')";
                    consulta.Atualizar();
                    //MessageBox.Show(consultar.comando);
                    if (consulta.Retorno == "ok")
                    {
                        MessageBox.Show("CANCELAMENTO CONCLUIDO");
                    }
                    else
                    {
                        MessageBox.Show("FALHA AO CONCLUIR RETORNO.");
                    }
                    // }
                    // else
                    // {
                    //     MessageBox.Show("FALHA AO RETORNAR.");
                    // }
                }
                else
                {
                    MessageBox.Show("ESSA PEÇA NÃO CONSTA NA RELAÇÃO DE PEÇAS PEDIDAS.");
                }
            }
            else
            {
                MessageBox.Show("APRESENTE UM CÓDIGO VALIDO");
            }

        }
         */

        /*
        private void lblBotao1_Click(object sender, EventArgs e)
        {
            int i = 1;
          //  CancelarPeca(i);
            OrganizaPosicao(i);
            txtCodPeca1.Enabled = false;
        }

        private void lblBotao2_Click(object sender, EventArgs e)
        {
            int i = 2;
           // CancelarPeca(i);
            OrganizaPosicao(i);
            txtCodPeca2.Enabled = false;
        }

        private void lblBotao3_Click(object sender, EventArgs e)
        {
            int i = 3;
         //   CancelarPeca(i);
            OrganizaPosicao(i);
            txtCodPeca3.Enabled = false;
        }

        private void lblBotao4_Click(object sender, EventArgs e)
        {
            int i = 4;
          //  CancelarPeca(i);
            OrganizaPosicao(i);
            txtCodPeca4.Enabled = false;
        }

        private void lblBotao5_Click(object sender, EventArgs e)
        {
            int i = 5;
         //   CancelarPeca(i);
            OrganizaPosicao(i);
            txtCodPeca5.Enabled = false;
        }

        public void VerificaPecaInserida(string Peca, int num)
        {
            //=======consulta se a peça foi pedidano estoque
            consulta.comando = "";
            consulta.comando = "select COUNT(*) as Quantidade from Pedidos where Codigo = '" + Peca + "' and OS = '" + txtOS.Text + "' and Status = 'RECEBIDO'";
            consulta.consultarSimNao();
            if (Convert.ToInt32(consulta.qntNaPosicao) > 0)
            {
                consulta.Codigo = Peca;
                consulta.consultarEstoque();
                if (consulta.Retorno == "ok")
                {
                    this.pnlComPecas.Controls["txtDescPeca" + num.ToString()].Text = consulta.Descricao;
                }
                else
                {
                    MessageBox.Show("Código não encontrado!");
                }
            }
            else
            {
                MessageBox.Show("PEÇA NÃO FOI SOLICITADA PARA ESSE CHAMADO");
                this.pnlComPecas.Controls["txtCodPeca" + num.ToString()].Text = "";
                this.pnlComPecas.Controls["txtDescPeca" + num.ToString()].Text = "";
                this.pnlComPecas.Controls["txtSerialAntigo" + num.ToString()].Text = "";
                this.pnlComPecas.Controls["txtSerialNovo" + num.ToString()].Text = "";

                this.pnlComPecas.Controls["txtCodPeca" + num.ToString()].Select();
            }
        }

        public void PreencheSemNecessidade(int num)
        {
            this.pnlComPecas.Controls["txtDescPeca" + num.ToString()].Text = "S/N";
            this.pnlComPecas.Controls["txtSerialAntigo" + num.ToString()].Text = "S/N";
            this.pnlComPecas.Controls["txtSerialNovo" + num.ToString()].Text = "S/N";
        }

        public void PreencheNada(int num)
        {
            this.pnlComPecas.Controls["txtDescPeca" + num.ToString()].Text = "";
            this.pnlComPecas.Controls["txtSerialAntigo" + num.ToString()].Text = "";
            this.pnlComPecas.Controls["txtSerialNovo" + num.ToString()].Text = "";
        }
         */ 

        /*
        private void txtCodPeca1_Leave(object sender, EventArgs e)
        {
            if (txtCodPeca1.Text == "S/N")
            {
                PreencheSemNecessidade(1);
            }
            else if (txtCodPeca1.Text == "")
            {
                PreencheNada(1);
            }
            else
            {
                VerificaPecaInserida(txtCodPeca1.Text, 1);
            }
        }
         */ 

        private void txtCodPeca1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ConsultaCodigo();       
            }            
        }


        public void ConsultaCodigo()
        {
            if (txtCodPeca.Text == "S/N")
            {
                txtDescPeca.Text = "S/N";
            }
            else
            {
                consulta.Codigo = txtCodPeca.Text;
                consulta.consultarEstoque(lblCT.Text);
                if (consulta.Retorno == "ok")
                {
                    txtDescPeca.Text = consulta.Descricao;
                }
                else
                {
                    MessageBox.Show("CÓDIGO NÃO ENCONTRADO NO ESTOQUE!");
                    txtCodPeca.Text = "";
                    txtCodPeca.Select();
                }
            }
            
        }


        /*
        private void txtCodPeca2_Leave(object sender, EventArgs e)
        {
            if (txtCodPeca2.Text == "S/N")
            {
                PreencheSemNecessidade(2);
            }
            else if (txtCodPeca2.Text == "")
            {
                PreencheNada(2);
            }
            else
            {
                VerificaPecaInserida(txtCodPeca2.Text, 2);
            }
        }

        private void txtCodPeca2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescPeca2.Select();
            }   
        }

        private void txtCodPeca3_Leave(object sender, EventArgs e)
        {
            if (txtCodPeca3.Text == "S/N")
            {
                PreencheSemNecessidade(3);
            }
            else if (txtCodPeca3.Text == "")
            {
                PreencheNada(3);
            }
            else
            {
                VerificaPecaInserida(txtCodPeca3.Text, 3);
            }
        }

        private void txtCodPeca3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescPeca3.Select();
            }    
        }

        private void txtCodPeca4_Leave(object sender, EventArgs e)
        {
            if (txtCodPeca4.Text == "S/N")
            {
                PreencheSemNecessidade(4);
            }
            else if (txtCodPeca4.Text == "")
            {
                PreencheNada(4);
            }
            else
            {
                VerificaPecaInserida(txtCodPeca4.Text, 4);
            }
        }

        private void txtCodPeca4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescPeca4.Select();
            }    
        }

        private void txtCodPeca5_Leave(object sender, EventArgs e)
        {
            if (txtCodPeca5.Text == "S/N")
            {
                PreencheSemNecessidade(5);
            }
            else if (txtCodPeca5.Text == "")
            {
                PreencheNada(5);
            }
            else
            {
                VerificaPecaInserida(txtCodPeca5.Text, 5);
            } 
        }

        private void txtCodPeca5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescPeca5.Select();
            }    
        }

         */

        public string Faltantes = "";
        public DateTime DtCompraConv;
        public string DtCompra = "";
        public DateTime DtTrocaConv;
        public string DtTroca = "";

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            txtClassificacao.Text = ""; //zera a classificação
            CalcularClassificacao(); // executa o calculo da classificação
            if (txtClassificacao.Text.Length > 0) // se o calculo da classificacao estiver ok
            {
                if (MessageBox.Show("DESEJA CONCLUIR O REPARO?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // if(MessageBox.Show("CLASSIFICAÇÃO = " + txtClassificacao.Text + "\r\nDESE);

                    consulta.Coluna = "OS";
                    consulta.ValorDesejado = txtOS.Text;
                    consulta.ComData = "SIM";
                    consulta.ConsultaTudo(lblCT.Text);
                    if (txtOS.Text.Length == 0)
                    {
                        MessageBox.Show("PREENCHA A OS");
                        Reset();
                    }
                    else if (txtNS.Text.Length < 12 && txtNS.Text != "SEM NS")
                    {
                        MessageBox.Show("PREENCHA O NUMERO DE SÉRIE. (DEVE CONTER MAIS DE 12 DIGITOS).");
                        txtNS.Select();
                    }
                    else if (consulta.Status != "REPARO")
                    {
                        MessageBox.Show("EQUIPAMENTO NÃO ESTA EM REPARO \n Status = " + consulta.Status);
                        Reset();
                    }
                    else if (txtClassificacao.Text.Length == 0)
                    {
                        MessageBox.Show("CALCULE A CLASSIFICAÇÃO.");
                    }
                   //  else if (lstReparo.Items.Count == 0)
                    //{
                    //    MessageBox.Show("PREENCHER AO MENOS UMA INFORMAÇÃO SOBRE O REPARO.");
                   // }
                        /*
                    else if (txtClassificacao.Text == "SALDO" &&
                        ((txtCodPeca1.Enabled == true) && (txtDescPeca1.Text.Length == 0 || txtSerialNovo1.Text.Length == 0 || txtSerialAntigo1.Text.Length == 0)) ||
                        ((txtCodPeca2.Enabled == true) && (txtDescPeca2.Text.Length == 0 || txtSerialNovo2.Text.Length == 0 || txtSerialAntigo2.Text.Length == 0)) ||
                        ((txtCodPeca3.Enabled == true) && (txtDescPeca3.Text.Length == 0 || txtSerialNovo3.Text.Length == 0 || txtSerialAntigo3.Text.Length == 0)) ||
                        ((txtCodPeca4.Enabled == true) && (txtDescPeca4.Text.Length == 0 || txtSerialNovo4.Text.Length == 0 || txtSerialAntigo4.Text.Length == 0)) ||
                        ((txtCodPeca5.Enabled == true) && (txtDescPeca5.Text.Length == 0 || txtSerialNovo5.Text.Length == 0 || txtSerialAntigo5.Text.Length == 0))
                        )
                    {
                        MessageBox.Show("PREENCHER OS CAMPOS VAZIOS DE INFORMAÇÕES DO REPARO.");
                    }
                         */ 
                    else
                    {
                        //verifica posicionamento de peças....
                        string feedBack = "";
                        ConferirPosicionamentoPeca(out feedBack);
                        if (feedBack == "ok")
                        {
                            if (lstReparo.Items.Count == 0 && txtClassificacao.Text == "SALDO")
                            {
                                MessageBox.Show("PREENCHER AO MENOS UM CAMPO DE REPARO.");
                            }
                            else
                            {
                                Faltantes = "";
                                DateTime DtCompraConv;
                                string DtCompra = "";
                                DateTime DtTrocaConv;
                                string DtTroca = "";
                                try
                                {
                                    DtCompraConv = Convert.ToDateTime(txtDataCompra.Text);
                                    DtCompra = DtCompraConv.ToString("MM/dd/yyyy");
                                }
                                catch (Exception x)
                                {
                                    MessageBox.Show(x.Message);
                                }
                                try
                                {
                                    DtTrocaConv = Convert.ToDateTime(txtDataTroca.Text);
                                    DtTroca = DtTrocaConv.ToString("MM/dd/yyyy");
                                }
                                catch (Exception x)
                                {
                                    MessageBox.Show(x.Message);
                                }
                                if (chbSemEmbalagem.Checked)
                                {
                                    Faltantes = "SEM EMBALAGEM";
                                }

                                

                               // if (txtClassificacao.Text == "SALDO")
                                if (lstReparo.Items.Count > 0)
                                {
                                    
                                    InserirRMA();
                                   

                                    // ============================= ATUALIZAR STATUS ============================
                                    MessageBox.Show(DtCompra + "---" + DtTroca);
                                    AtualizarStatus();
                                    /*
                                    string status = "HIGIENIZACAO";
                                    consulta.comando = "";
                                    consulta.comando = "update Chamados set NS = '" + txtNS.Text + "', Estetico = '" + txtEstetico.Text + "', Funcional = '" + txtFuncional.Text + "', ItensFaltantes = '" + Faltantes + "', Status = '" + status + "', Classificacao = '" + txtClassificacao.Text + "', Responsavel = '" + lblUsuario.Text + "', ";
                                    consulta.comando += " DtCompra = '" + DtCompra + "', DtTroca = '" + DtTroca + "', DefeitoRelatado = '" + txtDefeitoRelatado.Text + "', Filial = '" + txtFilial.Text + "', NumLacre = '" + txtNumLacre.Text + "', ObsDocumento = '" + txtObsDocumento.Text + "' ";
                                    consulta.comando += " where OS = '" + txtOS.Text + "' AND STATUS = 'REPARO'";
                                    consulta.Atualizar();
                                     */ 
                                    // ===========================================================================

                                    if (consulta.Retorno == "ok")
                                    {
                                        //======Insere na tabela Historico==========================
                                        string StatusHistorico = "REPARO";
                                        consulta.DataAtual();
                                        consulta.InsereHistorico(txtOS.Text, lblUsuario.Text, StatusHistorico, consulta.dataNormal, consulta.hora, lblCT.Text);
                                        //=====fim da inserção======================================
                                        Concluir();
                                        Reset();
                                        AtualizaContadores();
                                        MessageBox.Show("REPARO CADASTRADO COM SUCESSO.");
                                        if (IniciaOS.Length > 0)
                                        {
                                            this.Close();
                                        }                                        
                                    }
                                    

                                }
                                else // NÃO FOI FEITO REPARO
                                {
                                    InserirRMA();
                                   

                                    // ============================= ATUALIZAR STATUS ============================
                                    //MessageBox.Show(DtCompra + "---" + DtTroca);
                                    AtualizarStatus();
                                    /*
                                    string status = "HIGIENIZACAO";
                                    consulta.comando = "";
                                    consulta.comando = "update Chamados set NS = '" + txtNS.Text + "', Estetico = '" + txtEstetico.Text + "', Funcional = '" + txtFuncional.Text + "', ItensFaltantes = '" + Faltantes + "', Status = '" + status + "', Classificacao = '" + txtClassificacao.Text + "', Responsavel = '" + lblUsuario.Text + "', ";
                                    consulta.comando += " DtCompra = '" + DtCompra + "', DtTroca = '" + DtTroca + "', DefeitoRelatado = '" + txtDefeitoRelatado.Text + "', Filial = '" + txtFilial.Text + "', NumLacre = '" + txtNumLacre.Text + "', ObsDocumento = '" + txtObsDocumento.Text + "' ";
                                    consulta.comando += " where OS = '" + txtOS.Text + "' AND STATUS = 'REPARO'";
                                    consulta.Atualizar();
                                     */ 
                                    // ===========================================================================                                   
                                    if (consulta.Retorno == "ok")
                                    {
                                        //======Insere na tabela Historico==========================
                                        string StatusHistorico = "VISTORIA";
                                        consulta.DataAtual();
                                        consulta.InsereHistorico(txtOS.Text, lblUsuario.Text, StatusHistorico, consulta.dataNormal, consulta.hora, lblCT.Text);
                                        //=====fim da inserção======================================

                                        Reset();
                                        AtualizaContadores();
                                        MessageBox.Show("VISTORIA CADASTRADA COM SUCESSO.");
                                        if (IniciaOS.Length > 0)
                                        {
                                            this.Close();
                                        }
                                    }
                                    
                                }
                            }
                        }
                    }
                }
            }
        }

        public void AtualizarStatus()
        {
            string Faltantes = "";
            DateTime DtCompraConv;
            string DtCompra = "";
            DateTime DtTrocaConv;
            string DtTroca = "";
            try
            {
                DtCompraConv = Convert.ToDateTime(txtDataCompra.Text);
                DtCompra = DtCompraConv.ToString("MM/dd/yyyy");
            }
            catch (Exception)
            {

            }
            try
            {
                DtTrocaConv = Convert.ToDateTime(txtDataTroca.Text);
                DtTroca = DtTrocaConv.ToString("MM/dd/yyyy");
            }
            catch (Exception)
            {

            }
            if (chbSemEmbalagem.Checked)
            {
                Faltantes = "SEM EMBALAGEM";
            }

            //MessageBox.Show(DtCompra + "---" + DtTroca);
            string status = "REPARO";
            consulta.comando = "";
            consulta.comando = "update Chamados set NS = '" + txtNS.Text + "', Estetico = '" + txtEstetico.Text + "', Funcional = '" + txtFuncional.Text + "', ItensFaltantes = '" + Faltantes + "', Status = '" + status + "', Classificacao = '" + txtClassificacao.Text + "', Responsavel = '', ";
            consulta.comando += " DtCompra = '" + DtCompra + "', DtTroca = '" + DtTroca + "', DefeitoRelatado = '" + cboFuncEst.Text + " / " + txtDefeitoRelatado.Text + "', Filial = '" + txtFilial.Text + "', NumLacre = '" + txtNumLacre.Text + "', ObsDocumento = '" + txtObsDocumento.Text + "' ";
            consulta.comando += " where OS = '" + txtOS.Text + "' AND STATUS = 'REPARO' and CT = '" + lblCT.Text + "'";
            consulta.Atualizar();
            /*
            consulta.comando = "";
            consulta.comando += "Select COUNT(OS) as Quantidade from Chamados where Status = 'HIGIENIZACAO' and OS = '" + txtOS.Text + "'";
            consulta.consultarSimNao();
            if (Convert.ToInt32(consulta.qntNaPosicao) == 0)
            {
                MessageBox.Show("NÃO INSERIU NO BANCO.");
            }
             */ 
        }
       

        public void Concluir()
        {
            consulta.DataAtual();
            string data = consulta.dataCompleta;
            if (lstReparo.Items.Count > 0)
            {
                string stringMontada = "";
                stringMontada = "Insert into Tecnica (CT, Tecnico, OS, NS, SKU, Descricao, Defeito, CodPeca, DescPeca, DataReparo) Values ";
                int rows = lstReparo.Items.Count;
                foreach (string item in lstReparo.Items)
                {
                    if (rows > 1)
                    {
                        stringMontada += " (";
                        stringMontada += " '" + lblCT.Text + "', ";
                        stringMontada += " '" + lblUsuario.Text + "', ";
                        stringMontada += " '" + txtOS.Text + "' , ";
                        stringMontada += " '" + txtNS.Text + "' , ";
                        stringMontada += " '" + txtSKU.Text + "' , ";
                        stringMontada += " '" + txtDescricao.Text + "', ";                        
                        stringMontada += item;                       
                        stringMontada += " '" + data + "'), ";
                    }
                    else
                    {
                        //stringMontada += " ('" + lblUsuario.Text + "', ";
                        stringMontada += " (";
                        stringMontada += " '" + lblCT.Text + "', ";
                        stringMontada += " '" + lblUsuario.Text + "', ";
                        stringMontada += " '" + txtOS.Text + "' , ";
                        stringMontada += " '" + txtNS.Text + "' , ";
                        stringMontada += " '" + txtSKU.Text + "' , ";
                        stringMontada += " '" + txtDescricao.Text + "', ";
                        stringMontada += item;
                        stringMontada += " '" + data + "') ";
                    }
                    rows--;
                }
                consulta.comando = "";
                consulta.comando = stringMontada;
                consulta.Atualizar();
            }

           // MessageBox.Show("PROGRAMAR O CONCLUIR.");
            /*
            string sql = "";
            DateTime agora = DateTime.Now;
            string data = agora.ToString();
            try
            {
                sql += " Insert into Tecnica (Tecnico, NumeroSerie, CodPositivo, Chamado, DataReparo, Descricao, ";
                sql += "Defeito1, CodPeca1, DescPeca1, SerialAntigo1, SerialNovo1,";
                sql += "Defeito2, CodPeca2, DescPeca2, SerialAntigo2, SerialNovo2,";
                sql += "Defeito3, CodPeca3, DescPeca3, SerialAntigo3, SerialNovo3,";
                sql += "Defeito4, CodPeca4, DescPeca4, SerialAntigo4, SerialNovo4,";
                sql += "Defeito5, CodPeca5, DescPeca5, SerialAntigo5, SerialNovo5)";
                sql += " Values ( ";
                sql += " '" + lblUsuario.Text + "', ";
                sql += " '" + txtOS.Text + "', ";
                sql += " '" + txtCodPositivo.Text + "', ";
                sql += " '" + txtNS.Text + "', ";
                sql += " '" + data + "', ";
                sql += " '" + txtDescricao.Text + "', ";
                sql += " '" + txtDefeito1.Text + "', ";
                sql += " '" + txtCodPeca1.Text + "', ";
                sql += " '" + txtDescPeca1.Text + "', ";
                sql += " '" + txtSerialAntigo1.Text + "', ";
                sql += " '" + txtSerialNovo1.Text + "',";
                sql += " '" + txtDefeito2.Text + "', ";
                sql += " '" + txtCodPeca2.Text + "', ";
                sql += " '" + txtDescPeca2.Text + "', ";
                sql += " '" + txtSerialAntigo2.Text + "', ";
                sql += " '" + txtSerialNovo2.Text + "',";
                sql += " '" + txtDefeito3.Text + "', ";
                sql += " '" + txtCodPeca3.Text + "', ";
                sql += " '" + txtDescPeca3.Text + "', ";
                sql += " '" + txtSerialAntigo3.Text + "', ";
                sql += " '" + txtSerialNovo3.Text + "',";
                sql += " '" + txtDefeito4.Text + "', ";
                sql += " '" + txtCodPeca4.Text + "', ";
                sql += " '" + txtDescPeca4.Text + "', ";
                sql += " '" + txtSerialAntigo4.Text + "', ";
                sql += " '" + txtSerialNovo4.Text + "',";
                sql += " '" + txtDefeito5.Text + "', ";
                sql += " '" + txtCodPeca5.Text + "', ";
                sql += " '" + txtDescPeca5.Text + "', ";
                sql += " '" + txtSerialAntigo5.Text + "', ";
                sql += " '" + txtSerialNovo5.Text + "')";
                cx.Conectar();
                SqlCommand cd = new SqlCommand();
                cd.Connection = cx.c;
                cd.CommandText = sql;
                cd.ExecuteNonQuery();
                cx.Desconectar();
            }
            catch (SqlException x)
            {
                MessageBox.Show(x.Message);
            }
            cx.Desconectar();
             */ 
        }

        public void InserirRMA()
        {
            try
            {
                string sql = "select Codigo, Descricao from Pedidos where Status = 'RECEBIDO' and OS = '" + txtOS.Text + "' and CT = '" + lblCT.Text + "' ";
                cx.Conectar();
                SqlCommand cd = new SqlCommand();
                cd.Connection = cx.c;
                cd.CommandText = sql;
                SqlDataReader dr = cd.ExecuteReader();
                // if (dr.HasRows)
                //{               
                while (dr.Read())
                {
                    // string retorno = "";
                    string Codigo = dr["Codigo"].ToString();
                    string Descricao = dr["Descricao"].ToString();
                    consulta.DataAtual();
                    //========ATUALIZA PEDIDOS (SETA COMO UTILIZADO)
                    consulta.comando = "";
                    consulta.comando += "update Pedidos set Status = 'UTILIZADO', HoraFinalizacao = '" + consulta.dataCompleta + "' where ";
                    consulta.comando += " OS = '" + txtOS.Text + "' and Codigo = '" + Codigo + "' and Status = 'RECEBIDO' and CT = '" + lblCT.Text + "'";
                    consulta.Atualizar();
                    //  MessageBox.Show(consulta.comando);
                }
                dr.Close();
                cx.Desconectar();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }                      
        }

        
        
        public void ConferirPosicionamentoPeca(out string feedBack)
        {
            feedBack = "ok";
            consulta.comando = "";
            consulta.comando += "Select COUNT(OS) as Quantidade from Pedidos where Status in ('PP-AGUARDANDO', 'AGUARDANDO', 'ATENDIDO', 'ATENDIMENTO') and OS = '" + txtOS.Text + "' and CT = '" + lblCT.Text + "'";
            consulta.consultarSimNao();
            if (Convert.ToInt32(consulta.qntNaPosicao) > 0)
            {
                MessageBox.Show("FAVOR ACEITAR TODAS AS PEÇAS SOLICITADAS");
                feedBack = "falha";
            }
                /*
            else
            {
                string feedBackPeca = "";
                BuscaCodigosDePedidos(out feedBackPeca);
                if (feedBackPeca == "falha")
                {
                    feedBack = "falha";
                }
                for (int x = 1; x <= 5; x++)
                {
                    string Codigo = this.pnlComPecas.Controls["txtCodPeca" + x.ToString()].Text;
                    string Defeito = this.pnlComPecas.Controls["txtDefeito" + x.ToString()].Text;
                    if (Codigo.Length > 0 && Defeito.Length == 0)
                    {
                        MessageBox.Show("PREENCHER O DEFEITO PARA TODAS AS PEÇAS.");
                        feedBack = "falha";
                    }
                }
                // if (feedBack == "ok")
                //   {
                //      InserirRMA();
                //   }
                //verificar se os codigos estão preenchidos if ok{ InserirRMA();}
            }
            // MessageBox.Show("feedback = " + feedBack);
                 */ 
        }
          
        
        /*
        public void BuscaCodigosDePedidos(out string feedBackPeca)
        {
            feedBackPeca = "ok";
            try
            {
                string sql = "select Codigo from Pedidos where Status = 'RECEBIDO' and OS = '" + txtOS.Text + "' ";
                cx.Conectar();
                SqlCommand cd = new SqlCommand();
                cd.Connection = cx.c;
                cd.CommandText = sql;
                SqlDataReader dr = cd.ExecuteReader();
                // if (dr.HasRows)
                //{               
                while (dr.Read())
                {
                    string retorno = "";
                    string Codigo = dr["Codigo"].ToString();
                    for (int x = 1; x <= 5; x++)
                    {
                        if (this.pnlComPecas.Controls["txtCodPeca" + x.ToString()].Text == Codigo)
                        {
                            retorno = "tem";
                            // MessageBox.Show("tem");
                            break;
                        }
                    }

                    if (retorno != "tem")
                    {
                        if (txtCodPeca1.Text.Length == 0)
                        {
                            txtCodPeca1.Text = Codigo;
                            consulta.Codigo = txtCodPeca1.Text.ToString();
                            consulta.ConsultarCodigoSAP();
                            if (consulta.Retorno == "ok")
                            {
                                txtDescPeca1.Text = consulta.Descricao;
                            }
                            else
                            {
                                MessageBox.Show("Código não encontrado!");
                            }
                        }
                        else if (txtCodPeca2.Text.Length == 0)
                        {
                            txtCodPeca2.Text = Codigo;
                            consulta.Codigo = txtCodPeca2.Text.ToString();
                            consulta.ConsultarCodigoSAP();
                            if (consulta.Retorno == "ok")
                            {
                                txtDescPeca2.Text = consulta.Descricao;
                            }
                            else
                            {
                                MessageBox.Show("Código não encontrado!");
                            }
                        }
                        else if (txtCodPeca3.Text.Length == 0)
                        {
                            txtCodPeca3.Text = Codigo;
                            consulta.Codigo = txtCodPeca3.Text.ToString();
                            consulta.ConsultarCodigoSAP();
                            if (consulta.Retorno == "ok")
                            {
                                txtDescPeca3.Text = consulta.Descricao;
                            }
                            else
                            {
                                MessageBox.Show("Código não encontrado!");
                            }
                        }
                        else if (txtCodPeca4.Text.Length == 0)
                        {
                            txtCodPeca4.Text = Codigo;
                            consulta.Codigo = txtCodPeca4.Text.ToString();
                            consulta.ConsultarCodigoSAP();
                            if (consulta.Retorno == "ok")
                            {
                                txtDescPeca4.Text = consulta.Descricao;
                            }
                            else
                            {
                                MessageBox.Show("Código não encontrado!");
                            }
                        }
                        else if (txtCodPeca5.Text.Length == 0)
                        {
                            txtCodPeca5.Text = Codigo;
                            consulta.Codigo = txtCodPeca5.Text.ToString();
                            consulta.ConsultarCodigoSAP();
                            if (consulta.Retorno == "ok")
                            {
                                txtDescPeca5.Text = consulta.Descricao;
                            }
                            else
                            {
                                MessageBox.Show("Código não encontrado!");
                            }
                        }
                        else
                        {
                            // MessageBox.Show("É NECESSARIO APONTAR A PEÇA: " + Codigo);
                            // feedBackPeca = "falha";
                        }
                    }

                }
                // }
                dr.Close();
                cx.Desconectar();
            }
            catch (Exception x)
            {
                MessageBox.Show("ERRO AO BUSCAR CODIGOS PEDIDOS:\r\n" + x.Message);
                feedBackPeca = "falha";
            }
        }

        private void txtCodPeca1_TextChanged(object sender, EventArgs e)
        {
            if (txtCodPeca1.Text.Length == 0)
            {
                txtDescPeca1.Text = "";
                txtSerialAntigo1.Text = "";
                txtSerialAntigo1.Enabled = false;
                txtSerialNovo1.Text = "";
                txtSerialNovo1.Enabled = false;
            }
        }

        private void txtCodPeca2_TextChanged(object sender, EventArgs e)
        {
            if (txtCodPeca2.Text.Length == 0)
            {
                txtDescPeca2.Text = "";
                txtSerialAntigo2.Text = "";
                txtSerialAntigo2.Enabled = false;
                txtSerialNovo2.Text = "";
                txtSerialNovo2.Enabled = false;
            }
        }

        private void txtCodPeca3_TextChanged(object sender, EventArgs e)
        {
            if (txtCodPeca3.Text.Length == 0)
            {
                txtDescPeca3.Text = "";
                txtSerialAntigo3.Text = "";
                txtSerialAntigo3.Enabled = false;
                txtSerialNovo3.Text = "";
                txtSerialNovo3.Enabled = false;
            }
        }

        private void txtCodPeca4_TextChanged(object sender, EventArgs e)
        {
            if (txtCodPeca4.Text.Length == 0)
            {
                txtDescPeca4.Text = "";
                txtSerialAntigo4.Text = "";
                txtSerialAntigo4.Enabled = false;
                txtSerialNovo4.Text = "";
                txtSerialNovo4.Enabled = false;
            }
        }

        private void txtCodPeca5_TextChanged(object sender, EventArgs e)
        {
            if (txtCodPeca5.Text.Length == 0)
            {
                txtDescPeca5.Text = "";
                txtSerialAntigo5.Text = "";
                txtSerialAntigo5.Enabled = false;
                txtSerialNovo5.Text = "";
                txtSerialNovo5.Enabled = false;
            }
        }

        */

        private void txtClassificacao_TextChanged(object sender, EventArgs e)
        {
            if (txtClassificacao.Text.Length > 0)
            {
                txtClassificacao.BackColor = Color.Orange;
            }
            else
            {
                txtClassificacao.BackColor = System.Drawing.SystemColors.Window;               
            }
        }

        
        // ================== ARVORE DE FALHAS ========================

        private void cbxNaturezaDeAtendimento_Click(object sender, EventArgs e)
        {
            ListarNatureza();
        }

        public void ListarNatureza()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql += " Select distinct NaturezaDeAtendimento from ArvoreDeFalhas";
            cx.ConectarSP();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "ArvoreDeFalhas");
            cbxNaturezaDeAtendimento.ValueMember = "NaturezaDeAtendimento";
            cbxNaturezaDeAtendimento.DisplayMember = "NaturezaDeAtendimento";
            cbxNaturezaDeAtendimento.DataSource = ds.Tables["ArvoreDeFalhas"];
            cx.Desconectar();
            cbxNaturezaDeAtendimento.Text = "";
        }

        private void cbxRecursoComponente_Click(object sender, EventArgs e)
        {
            ListarRecursoComponente();
        }

        public void ListarRecursoComponente()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql += " Select distinct RecursoComponente from ArvoreDeFalhas where NaturezaDeAtendimento = '" + cbxNaturezaDeAtendimento.Text + "'";
            cx.ConectarSP();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "ArvoreDeFalhas");
            cbxRecursoComponente.ValueMember = "RecursoComponente";
            cbxRecursoComponente.DisplayMember = "RecursoComponente";
            cbxRecursoComponente.DataSource = ds.Tables["ArvoreDeFalhas"];
            cx.Desconectar();
            cbxRecursoComponente.Text = "";
        }

        public void ListarDescricaoDoProblema()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql += " Select distinct DescricaoDoProblema from ArvoreDeFalhas where RecursoComponente = '" + cbxRecursoComponente.Text + "'";
            cx.ConectarSP();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "ArvoreDeFalhas");
            cbxDescricaoDoProblema.ValueMember = "DescricaoDoProblema";
            cbxDescricaoDoProblema.DisplayMember = "DescricaoDoProblema";
            cbxDescricaoDoProblema.DataSource = ds.Tables["ArvoreDeFalhas"];
            cx.Desconectar();
            cbxDescricaoDoProblema.Text = "";
        }

        private void cbxDescricaoDoProblema_Click(object sender, EventArgs e)
        {
            ListarDescricaoDoProblema();
        }

        public void ListarSolucaoAplicada()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql += " Select distinct SolucaoAplicada from ArvoreDeFalhas where DescricaoDoProblema = '" + cbxDescricaoDoProblema.Text + "'";
            cx.ConectarSP();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "ArvoreDeFalhas");
            cbxSolucaoAplicada.ValueMember = "SolucaoAplicada";
            cbxSolucaoAplicada.DisplayMember = "SolucaoAplicada";
            cbxSolucaoAplicada.DataSource = ds.Tables["ArvoreDeFalhas"];
            cx.Desconectar();
            cbxSolucaoAplicada.Text = "";
        }      

        private void cbxSolucaoAplicada_Click(object sender, EventArgs e)
        {
            ListarSolucaoAplicada();
        }

        private void cbxNaturezaDeAtendimento_TextChanged(object sender, EventArgs e)
        {
            cbxRecursoComponente.Text = "";
            cbxDescricaoDoProblema.Text = "";
            cbxSolucaoAplicada.Text = "";
            chbEstetico.Checked = false;
            chbImagem.Checked = false;
        }

        private void cbxRecursoComponente_TextChanged(object sender, EventArgs e)
        {
            cbxDescricaoDoProblema.Text = "";
            cbxSolucaoAplicada.Text = "";
        }

        private void cbxDescricaoDoProblema_TextChanged(object sender, EventArgs e)
        {
            cbxSolucaoAplicada.Text = ""; 
        }

        private void cbxSolucaoAplicada_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxNaturezaDeAtendimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; //Não permitir
            }        
        }

        private void cbxRecursoComponente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; //Não permitir
            }        
        }

        private void cbxDescricaoDoProblema_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; //Não permitir
            }        
        }

        private void cbxSolucaoAplicada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; //Não permitir
            }        
        }

        private void txtNS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBusca.PerformClick();
            }
        }

        private void txtNS_Leave(object sender, EventArgs e)
        {
            if (txtNS.Text.Length >= 12 || txtNS.Text == "SEM NS")
            {
                consulta.comando = "";
                consulta.comando = "select count(*) as Quantidade from Chamados where NS = '" + txtNS.Text + "' and Status != 'FINALIZADO' and CT = '" + lblCT.Text + "'";
                consulta.consultarSimNao();
                if (Convert.ToInt32(consulta.qntNaPosicao) > 0 && txtNS.Text != "SEM NS")
                {
                    consulta.PlayFail();
                    MessageBox.Show("NS JÁ CADASTRADO NO POSTO.");
                    txtNS.Text = "";
                    txtNS.Select();
                }
            }
            else if (txtNS.Text.Length == 0)
            {

            }
            else
            {
                consulta.PlayFail();
                MessageBox.Show("O NS DEVE SER MAIOR QUE 12 DIGITOS.");
                txtNS.Text = "";
                txtNS.Select();
            }
           
            
        }

        private void btnPP_Click(object sender, EventArgs e)
        {
            if (txtNS.Text.Length == 0 || txtNS.Text == "PENDENTE")
            {
                MessageBox.Show("É NECESSÁRIO INFORMAR O NS PARA ENVIAR PARA PP");
            }
            else
            {
                if (MessageBox.Show("DESEJA COLOCAR O EQUIPAMENTO EM AGUARDO DE PEÇAS?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    frmReparoSolicitarPecasPP c = new frmReparoSolicitarPecasPP(lblUsuario.Text, txtOS.Text, txtSKU.Text, txtNS.Text, "PP", lblCT.Text);
                    c.ShowDialog();

                    consulta.comando = "";
                    consulta.comando = "select count(*) as Quantidade from AguardoBackup where Chamado = '" + txtOS.Text + "' and Status = 'PENDENTE' and CT = '" + lblCT.Text + "'";
                    consulta.consultarSimNao();
                    if (Convert.ToInt32(consulta.qntNaPosicao) > 0)
                    {
                        //======Insere na tabela Historico==========================
                        string Local = "PP";
                        consulta.DataAtual();
                        consulta.InsereHistorico(txtOS.Text, lblUsuario.Text, Local, consulta.dataNormal, consulta.hora, lblCT.Text);
                        //=====fim da inserção======================================

                        consulta.comando = "update Chamados set Status = 'PP', Responsavel = '" + lblUsuario.Text + "' where OS = '" + txtOS.Text + "' AND STATUS = 'REPARO' and CT = '" + lblCT.Text + "'";
                        consulta.Atualizar();
                        if (consulta.Retorno == "ok")
                        {
                            MessageBox.Show("EQUIPAMENTO ENVIADO PARA PP.");
                            Reset();
                        }
                    }
                }           
            }
        }

        private void lblTotalPP_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmReparoPPRecebido c = new frmReparoPPRecebido(lblUsuario.Text, lblCT.Text);
            c.ShowDialog();
            AtualizaContadores();
        }

        private void txtCodPeca1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtCodPeca.Text = "S/N";
        }

        private void txtCodPeca2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           // txtCodPeca2.Text = "S/N";
        }

        private void txtCodPeca3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           // txtCodPeca3.Text = "S/N";
        }

        private void txtCodPeca4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           //// txtCodPeca4.Text = "S/N";
        }

        private void txtCodPeca5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          //  txtCodPeca5.Text = "S/N";
        }

        private void lblTotalPecaParaDevolver_DoubleClick(object sender, EventArgs e)
        {
            frmReparoDevolverPeca c = new frmReparoDevolverPeca(txtOS.Text, lblCT.Text);
            c.ShowDialog();
            AtualizaContadores();
        }

        private void lblTotalPecaAguardo_DoubleClick(object sender, EventArgs e)
        {
            frmReparoConsultarMilkRun c = new frmReparoConsultarMilkRun(lblUsuario.Text, txtOS.Text, lblCT.Text);
            c.ShowDialog();
            AtualizaContadores();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //CalcularClassificacao();                   
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string feedBack = "";
          //  ConferirPosicionamentoPeca(out feedBack);
            if (feedBack == "ok")
            {
            }
        }

        private void lblTotalEmPP_DoubleClick(object sender, EventArgs e)
        {
            frmReparoChamadoemPP c = new frmReparoChamadoemPP(lblUsuario.Text, lblCT.Text);
            c.ShowDialog();
            AtualizaContadores();
        }

        private void chbForaGarantia_CheckedChanged(object sender, EventArgs e)
        {
            txtClassificacao.Text = ""; // zera a classificação, pq esse campo pode mudar a classificação
        }

        private void txtDefeito1_TextChanged(object sender, EventArgs e)
        {
           // txtClassificacao.Text = ""; // zera a classificação, pq esse campo pode mudar a classificação
        }

        private void txtEstetico_TextChanged(object sender, EventArgs e)
        {
            txtClassificacao.Text = ""; // zera a classificação, pq esse campo pode mudar a classificação
        }

        private void txtFuncional_TextChanged(object sender, EventArgs e)
        {
            txtClassificacao.Text = ""; // zera a classificação, pq esse campo pode mudar a classificação
        }

        private void txtFaltantes_TextChanged(object sender, EventArgs e)
        {
            txtClassificacao.Text = ""; // zera a classificação, pq esse campo pode mudar a classificação
        }

        private void txtChamado_TextChanged(object sender, EventArgs e)
        {
            if (txtNS.Text == "PENDENTE")
            {
                consulta.PlayFail();
                MessageBox.Show("SOLICITE A ABERTURA DO CHAMADO");
            }
        }


        /*
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DESEJA SALVAR INFORMAÇÕES?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (txtDefeito1.Text.Length == 0)
                {
                    MessageBox.Show("Preencher ao menos um campo de informação sobre o reparo");
                }
                else if (
                    ((txtCodPeca1.Enabled == true) && (txtDescPeca1.Text.Length == 0 || txtSerialNovo1.Text.Length == 0 || txtSerialAntigo1.Text.Length == 0)) ||
                    ((txtCodPeca2.Enabled == true) && (txtDescPeca2.Text.Length == 0 || txtSerialNovo2.Text.Length == 0 || txtSerialAntigo2.Text.Length == 0)) ||
                    ((txtCodPeca3.Enabled == true) && (txtDescPeca3.Text.Length == 0 || txtSerialNovo3.Text.Length == 0 || txtSerialAntigo3.Text.Length == 0)) ||
                    ((txtCodPeca4.Enabled == true) && (txtDescPeca4.Text.Length == 0 || txtSerialNovo4.Text.Length == 0 || txtSerialAntigo4.Text.Length == 0)) ||
                    ((txtCodPeca5.Enabled == true) && (txtDescPeca5.Text.Length == 0 || txtSerialNovo5.Text.Length == 0 || txtSerialAntigo5.Text.Length == 0))
                    )
                {
                    MessageBox.Show("PREENCHER OS CAMPOS VAZIOS DE INFORMAÇÕES DO REPARO.");
                }               
                else
                {
                    consulta.comando = "";
                    consulta.comando += "select count(Chamado) as Quantidade from SalvarTecnica where Chamado = '" + txtNS.Text + "'";
                    consulta.consultarSimNao();
                    if (Convert.ToInt32(consulta.qntNaPosicao) > 0)
                    {
                        AtualizaSalvar();
                    }
                    else
                    {
                        Salvar();
                    }
                    MessageBox.Show("CHAMADO SALVO");                    
                }
            }            
        }

        public void AtualizaSalvar()
        {
            consulta.DataAtual();
            string data = consulta.data;
            try
            {
                consulta.comando = "";
                consulta.comando += " update SalvarTecnica set ";//Tecnico = '" + lblUsuario.Text + "', NumeroSerie = '" + txtNS.Text + "', Chamado = '" + txtChamado.Text + "', Descricao = '" + txtModelo.Text + "', ";
                consulta.comando += "Defeito1 = '" + txtDefeito1.Text + "', CodPeca1 = '" + txtCodPeca1.Text + "', DescPeca1='" + txtDescPeca1.Text + "', SerialAntigo1 = '" + txtSerialAntigo1.Text + "', SerialNovo1 = '" + txtSerialNovo1.Text + "', ";
                consulta.comando += "Defeito2 = '" + txtDefeito2.Text + "', CodPeca2 = '" + txtCodPeca2.Text + "', DescPeca2='" + txtDescPeca2.Text + "', SerialAntigo2 = '" + txtSerialAntigo2.Text + "', SerialNovo2 = '" + txtSerialNovo2.Text + "', ";
                consulta.comando += "Defeito3 = '" + txtDefeito3.Text + "', CodPeca3 = '" + txtCodPeca3.Text + "', DescPeca3='" + txtDescPeca3.Text + "', SerialAntigo3 = '" + txtSerialAntigo3.Text + "', SerialNovo3 = '" + txtSerialNovo3.Text + "', ";
                consulta.comando += "Defeito4 = '" + txtDefeito4.Text + "', CodPeca4 = '" + txtCodPeca4.Text + "', DescPeca4='" + txtDescPeca4.Text + "', SerialAntigo4 = '" + txtSerialAntigo4.Text + "', SerialNovo4 = '" + txtSerialNovo4.Text + "', ";
                consulta.comando += "Defeito5 = '" + txtDefeito5.Text + "', CodPeca5 = '" + txtCodPeca5.Text + "', DescPeca5='" + txtDescPeca5.Text + "', SerialAntigo5 = '" + txtSerialAntigo5.Text + "', SerialNovo5 = '" + txtSerialNovo5.Text + "', ";
                             
                consulta.comando += "Status = 'SALVO' Where Chamado = '" + txtNS.Text + "'";
                consulta.Atualizar();
            }
            catch (SqlException x)
            {
                MessageBox.Show(x.Message);
            }
        }

         
        public void Salvar()
        {
            string sql = "";
            consulta.DataAtual();
            string data = consulta.dataNormal;
            try
            {
                sql += " Insert into SalvarTecnica (Tecnico, NumeroSerie, Chamado, DataReparo, Descricao, ";
                sql += "Defeito1, CodPeca1, DescPeca1, SerialAntigo1, SerialNovo1, ";
                sql += "Defeito2, CodPeca2, DescPeca2, SerialAntigo2, SerialNovo2, ";
                sql += "Defeito3, CodPeca3, DescPeca3, SerialAntigo3, SerialNovo3, ";
                sql += "Defeito4, CodPeca4, DescPeca4, SerialAntigo4, SerialNovo4, ";
                sql += "Defeito5, CodPeca5, DescPeca5, SerialAntigo5, SerialNovo5, Status) ";              
                sql += " Values ( ";
                sql += " '" + lblUsuario.Text + "', ";
                sql += " '" + txtOS.Text + "', ";
                sql += " '" + txtNS.Text + "', ";
                sql += " '" + data + "', ";
                sql += " '" + txtDescricao.Text + "', ";
                sql += " '" + txtDefeito1.Text + "', ";
                sql += " '" + txtCodPeca1.Text + "', ";
                sql += " '" + txtDescPeca1.Text + "', ";
                sql += " '" + txtSerialAntigo1.Text + "', ";
                sql += " '" + txtSerialNovo1.Text + "',";
                sql += " '" + txtDefeito2.Text + "', ";
                sql += " '" + txtCodPeca2.Text + "', ";
                sql += " '" + txtDescPeca2.Text + "', ";
                sql += " '" + txtSerialAntigo2.Text + "', ";
                sql += " '" + txtSerialNovo2.Text + "',";
                sql += " '" + txtDefeito3.Text + "', ";
                sql += " '" + txtCodPeca3.Text + "', ";
                sql += " '" + txtDescPeca3.Text + "', ";
                sql += " '" + txtSerialAntigo3.Text + "', ";
                sql += " '" + txtSerialNovo3.Text + "',";
                sql += " '" + txtDefeito4.Text + "', ";
                sql += " '" + txtCodPeca4.Text + "', ";
                sql += " '" + txtDescPeca4.Text + "', ";
                sql += " '" + txtSerialAntigo4.Text + "', ";
                sql += " '" + txtSerialNovo4.Text + "',";
                sql += " '" + txtDefeito5.Text + "', ";
                sql += " '" + txtCodPeca5.Text + "', ";
                sql += " '" + txtDescPeca5.Text + "', ";
                sql += " '" + txtSerialAntigo5.Text + "', ";
                sql += " '" + txtSerialNovo5.Text + "', ";
                sql += " 'SALVO') ";
                
                cx.Conectar();
                SqlCommand cd = new SqlCommand();
                cd.Connection = cx.c;
                cd.CommandText = sql;
                cd.ExecuteNonQuery();
                cx.Desconectar();
            }
            catch (SqlException x)
            {
                MessageBox.Show(x.Message);
            }
            cx.Desconectar();
        }

        public void PreencheSalvarTecnica()
        {
            consulta.Chamado = txtNS.Text;
            consulta.consultarTecnica();

            if (consulta.Retorno == "ok")
            {
                txtDefeito1.Text = consulta.Defeito1;
                txtCodPeca1.Text = consulta.CodPeca1;
                txtDescPeca1.Text = consulta.DescPeca1;
                txtSerialNovo1.Text = consulta.SerialNovo1;
                txtSerialAntigo1.Text = consulta.SerialAntigo1;

                txtDefeito2.Text = consulta.Defeito2;
                txtCodPeca2.Text = consulta.CodPeca2;
                txtDescPeca2.Text = consulta.DescPeca2;
                txtSerialNovo2.Text = consulta.SerialNovo2;
                txtSerialAntigo2.Text = consulta.SerialAntigo2;

                txtDefeito3.Text = consulta.Defeito3;
                txtCodPeca3.Text = consulta.CodPeca3;
                txtDescPeca3.Text = consulta.DescPeca3;
                txtSerialNovo3.Text = consulta.SerialNovo3;
                txtSerialAntigo3.Text = consulta.SerialAntigo3;

                txtDefeito4.Text = consulta.Defeito4;
                txtCodPeca4.Text = consulta.CodPeca4;
                txtDescPeca4.Text = consulta.DescPeca4;
                txtSerialNovo4.Text = consulta.SerialNovo4;
                txtSerialAntigo4.Text = consulta.SerialAntigo4;

                txtDefeito5.Text = consulta.Defeito5;
                txtCodPeca5.Text = consulta.CodPeca5;
                txtDescPeca5.Text = consulta.DescPeca5;
                txtSerialNovo5.Text = consulta.SerialNovo5;
                txtSerialAntigo5.Text = consulta.SerialAntigo5;
                               
            }
            else
            {
                MessageBox.Show("SEM HISTORICO SALVO");
            }
        }
        */

        private void txtDias_TextChanged(object sender, EventArgs e)
        {
            if (txtDias.Text.Length > 0)
            {
                if (Convert.ToInt32(txtDias.Text) > 5)
                {
                    txtDias.BackColor = Color.Tomato;
                }
                else
                {
                    txtDias.BackColor = Color.YellowGreen;
                }
            }
            else
            {
                txtDias.BackColor = Color.WhiteSmoke;
            }
            
        }

        private void lstReparo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNS_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtbDataCompra.Select();
            }
        }

        private void mtbDataCompra_Enter(object sender, EventArgs e)
        {
            if (rbtSemDocumento.Checked)
            {
                consulta.PlayFail();
                MessageBox.Show("OPÇÃO 'SEM DOCUMENTO' SELECIONADA.");
                rbtSemDocumento.Focus();
            }           
        }

        private void mtbDataCompra_Leave(object sender, EventArgs e)
        {
            // MessageBox.Show(mtbDataCompra.Text.Length.ToString());
            if (mtbDataCompra.Text.Length == 0)
            {
                txtDataCompra.Text = "";

                mtbDataTroca.Text = "";
                txtDataTroca.Text = "";
            }
            else if (mtbDataCompra.Text.Length < 8)
            {
                consulta.PlayFail();
                MessageBox.Show("DATA INVÁLIDA");
                mtbDataCompra.Focus();
            }
            else
            {
                string check = "";
                string Vdata = "";
                ValidaData(mtbDataCompra.Text, out check, out Vdata);
                if (check == "OK")
                {
                    txtDataCompra.Text = Vdata;
                    mtbDataTroca.Select();
                }
            }
        }

        private void mtbDataCompra_TextChanged(object sender, EventArgs e)
        {
            mtbDataTroca.Text = "";
            txtDataTroca.Text = "";

            txtDataCompra.Text = "";
            if (mtbDataCompra.Text.Length > 7)
            {
                txtDataCompra.Text = "";
                string check = "";
                string Vdata = "";
                ValidaData(mtbDataCompra.Text, out check, out Vdata);
                if (check == "OK")
                {
                    txtDataCompra.Text = Vdata;
                    mtbDataTroca.Select();
                }
                else
                {
                    mtbDataCompra.SelectAll();
                }
            }              
        }

        public void ValidaData(string data, out string check, out string Vdata)
        {
            check = "";
            string Data = "";
            Vdata = data.Substring(0, 2) + "/" + data.Substring(2, 2) + "/" + data.Substring(4, 4);
            //MessageBox.Show(Vdata);
            try
            {
                DateTime teste = Convert.ToDateTime(Vdata);
                if (teste > DateTime.Now)
                {
                    consulta.PlayFail();
                    MessageBox.Show("DATA MAIOR QUE HOJE");
                    // mtbDataCompra.SelectAll();
                }
                else
                {
                    Data = Vdata;
                    // mtbDataCompra.Select();
                    check = "OK";
                }
            }
            catch (Exception)
            {
                consulta.PlayFail();
                MessageBox.Show("DIGITE UMA DATA VÁLIDA");
                // mtbDataCompra.SelectAll();
            }
        }

        private void mtbDataTroca_Leave(object sender, EventArgs e)
        {
            if (mtbDataTroca.Text.Length == 0)
            {
                txtDataTroca.Text = "";
            }
            else if (mtbDataTroca.Text.Length < 8)
            {
                consulta.PlayFail();
                MessageBox.Show("DATA INVÁLIDA");
                mtbDataTroca.Focus();
            }
            else
            {
                string check = "";
                string Vdata = "";
                ValidaData(mtbDataTroca.Text, out check, out Vdata);
                if (check == "OK")
                {
                    txtDataTroca.Text = Vdata;
                    //txtNS.Select();
                    CalculaData();
                }
            }
        }

        private void mtbDataTroca_TextChanged(object sender, EventArgs e)
        {
            txtCalculoTroca.Text = "";
            txtCalculoTroca_Hoje.Text = "";
            if (mtbDataCompra.Text.Length == 0 && mtbDataTroca.Text.Length > 0)
            {
                mtbDataTroca.Text = "";
                txtDataTroca.Text = "";

                consulta.PlayFail();
                MessageBox.Show("PREENCHA A DATA DA COMPRA PRIMEIRO.");
                mtbDataCompra.Select();
            }
            else if (mtbDataTroca.Text.Length > 7)
            {
                txtDataTroca.Text = "";
                string check = "";
                string Vdata = "";
                ValidaData(mtbDataTroca.Text, out check, out Vdata);
                if (check == "OK")
                {
                    txtDataTroca.Text = Vdata;
                    //===
                    CalculaData();
                    txtDefeitoRelatado.Select();

                }
                else
                {
                    mtbDataTroca.SelectAll();
                }
            }
        }

        public void CalculaData()
        {
            // CALCULA A DIFERENÇA DAS DATAS
            string compra = txtDataCompra.Text;
            string troca = txtDataTroca.Text;

            // converte resultado para date                      
            DateTime data_compra = Convert.ToDateTime(compra);
            DateTime data_troca = Convert.ToDateTime(troca);
            // obtém a diferença
            TimeSpan dif = data_troca.Subtract(data_compra);
            TimeSpan Calc = DateTime.Now.Subtract(data_troca);
            // exibe o resultado
            //int meses = (dif.Days / 30);
            int totalDias = dif.Days;
            int CalcDias = Calc.Days;
            if (totalDias < 0)
            {
                consulta.PlayFail();
                MessageBox.Show("DATA DA TROCA INFERIOR A DATA DA COMPRA");
                mtbDataTroca.SelectAll();
            }
            else
            {
                txtCalculoTroca.Text = totalDias.ToString();
                txtCalculoTroca_Hoje.Text = CalcDias.ToString();

            }
        }

        private void txtDefeitoRelatado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtDefeitoRelatado.Text.Length > 0)
                {
                    txtFilial.Select();
                }
                else
                {
                    consulta.PlayFail();
                    MessageBox.Show("O CAMPO NÃO PODE ESTAR VAZIO.");
                }
            } 
        }

        private void txtDefeitoRelatado_Leave(object sender, EventArgs e)
        {
            if (txtDefeitoRelatado.Text.Contains(";"))
            {
                txtDefeitoRelatado.Text = txtDefeitoRelatado.Text.Replace(";", "");
            }
        }
        
        private void txtDefeitoRelatado_Enter(object sender, EventArgs e)
        {
            if (rbtSemDocumento.Checked)
            {
                consulta.PlayFail();
                MessageBox.Show("OPÇÃO 'SEM DOCUMENTO' SELECIONADA.");
                rbtSemDocumento.Focus();
            }
        }

        private void txtFilial_Enter(object sender, EventArgs e)
        {
            if (rbtSemDocumento.Checked)
            {
                consulta.PlayFail();
                MessageBox.Show("OPÇÃO 'SEM DOCUMENTO' SELECIONADA.");
                rbtSemDocumento.Focus();
            }
        }

        private void txtFilial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNumLacre.Select();
            }
        }

        private void txtFilial_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFilial_Leave(object sender, EventArgs e)
        {
            if (txtFilial.Text.Contains(";"))
            {
                txtFilial.Text = txtFilial.Text.Replace(";", "");
            }
        }

        private void txtNumLacre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cboEstetico.Select();
            }
        }

        private void lnkLimpar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {           
            rbtSemDocumento.Checked = false;
            rbtMaisDe30Dias.Checked = false;
            rbtProcesso.Checked = false;
            rbtSemPosto.Checked = false;
            txtObsDocumento.Text = "";
        }

        private void rbtSemDocumento_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtSemDocumento.Checked)
            {
                mtbDataCompra.Text = "";
                mtbDataTroca.Text = "";
                txtDefeitoRelatado.Text = "";
                txtFilial.Text = "";
                txtObsDocumento.Text = "SemDocumento";
            }   
        }

        private void rbtSemPosto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtSemPosto.Checked)
            {
                //consulta.PlayFail();
                txtObsDocumento.Text = "SemPosto";
            }
        }

        private void rbtMaisDe30Dias_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtMaisDe30Dias.Checked)
            {
                consulta.PlayFail();
                MessageBox.Show("VOCÊ DEVE TER OS COMPROVANTES EM MÃOS.");
                txtObsDocumento.Text = "MaisDe30Dias";
            }    
        }

        private void rbtProcesso_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtProcesso.Checked)
            {
                txtObsDocumento.Text = "Processo";
                //consulta.PlayFail();
            }
        }

        private void txtNumLacre_TextChanged(object sender, EventArgs e)
        {
        
        }


       

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string Faltantes = "";
            DateTime DtCompraConv;
            string DtCompra = "";
            DateTime DtTrocaConv;
            string DtTroca = "";
            try
            {
                DtCompraConv = Convert.ToDateTime(txtDataCompra.Text);
                DtCompra = DtCompraConv.ToString("MM/dd/yyyy");
            }
            catch (Exception)
            {

            }
            try
            {
                DtTrocaConv = Convert.ToDateTime(txtDataTroca.Text);
                DtTroca = DtTrocaConv.ToString("MM/dd/yyyy");
            }
            catch (Exception)
            {

            }
            if (chbSemEmbalagem.Checked)
            {
                Faltantes = "SEM EMBALAGEM";
            }
            

            consulta.comando = "";
            consulta.comando = "update Chamados set NS = '" + txtNS.Text + "', Estetico = '" + txtEstetico.Text + "', Funcional = '" + txtFuncional.Text + "', ItensFaltantes = '" + Faltantes + "', Classificacao = '" + txtClassificacao.Text + "', " ;
            consulta.comando += " DtCompra = '" + DtCompra + "', DtTroca = '" + DtTroca + "', DefeitoRelatado = '" + txtDefeitoRelatado.Text + "', Filial = '" + txtFilial.Text + "', NumLacre = '" + txtNumLacre.Text + "', ObsDocumento = '" + txtObsDocumento.Text + "' ";
            consulta.comando += " where OS = '" + txtOS.Text + "' AND STATUS = 'REPARO' and CT = '" + lblCT.Text + "'";
            consulta.Atualizar();
            consulta.PlayOK();
            MessageBox.Show("INFORMAÇÕES SALVAS.");
        }

        private void chbPelado_CheckedChanged(object sender, EventArgs e)
        {
           /*
            if (chbSemEmbalagem.Checked)
            {
                txtFaltantes.Text = "SEM EMBALAGEM";
            }
            else
            {
                txtFaltantes.Text = "";
            }
            */ 
             
        }

        private void txtTipoReparo_TextChanged(object sender, EventArgs e)
        {
            if (txtClassificacao.Text.Length > 0)
            {
                txtTipoReparo.BackColor = Color.Orange;
            }
            else
            {
                txtTipoReparo.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizaContadores();
        }

        private void chbSemNS_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSemNS.Checked)
            {
                txtNS.Text = "SEM NS";
            }
            else
            {
                txtNS.Text = "";
            }
        }

        private void lstPecasUsadasNaOS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        




    }
}
