using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.SqlClient;

namespace CRMagazine
{
    public partial class frmHigienizacao : Form
    {
        public frmHigienizacao(string texto, string CT)
        {
            InitializeComponent();
            lblUsuario.Text = texto;
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();
        Impressao imprimir = new Impressao();
        Criterios criterios = new Criterios();

        private void frmHigienizacao_Load(object sender, EventArgs e)
        {
            ContadorDeProducao();
            PreencherComboboxStatus();
            txtOS.Select();
            rbt200dpi.Checked = true;
            rbt220.Checked = true;
        }


        public void ContadorDeProducao()
        {
            consulta.DataAtual();
            string Status = "HIGIENIZACAO";
            consulta.comando = "select COUNT(*) as QNT from Historico where Usuario = '" + lblUsuario.Text + "' and Status = '" + Status + "' and Data = '" + consulta.dataNormal + "' and CT = '" + lblCT.Text + "'";
            consulta.consultarHistorico();
            lblContador.Text = consulta.cont.ToString();
        }

        public void PreencherComboboxStatus()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql = "";
            sql += " SELECT DISTINCT Usuario FROM Usuarios WHERE Embalagem = 'yes' and CT = '" + lblCT.Text + "'";
            cx.Conectar();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "Usuarios");
            cboUsuario.ValueMember = "idUsuario";
            cboUsuario.DisplayMember = "Usuario";
            cboUsuario.DataSource = ds.Tables["Usuarios"];
            cx.Desconectar();
            cboUsuario.Text = null;
            cboUsuario.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboUsuario.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
       
        private void btnBusca_Click(object sender, EventArgs e)
        {
            

        }

        private void btnBusca_Click_1(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("rasdial.exe", "vpn1.positivoinformatica.com.br 56683 Maiden123");
            //System.Diagnostics.Process.Start("rasdial.exe", "\"vpn1.positivoinformatica.com.br\" 56683 Maiden123");
            //===========
            //System.Diagnostics.Process process = Process.Start("rasdial.exe", "\"vpn1.positivoinformatica.com.br\" 56683 Maiden123");
            //process.WaitForExit();

            consulta.Coluna = "OS";
            consulta.ValorDesejado = txtOS.Text;
            consulta.ComData = "SIM";  // para não puxar os finalizados
            // consulta.DataDesejada = txtDataDesejadaNaoLimpar.Text;
            consulta.ConsultaTudo(lblCT.Text);
            if (consulta.Descricao == "")
            {
                MessageBox.Show("CHAMADO NÃO ENCONTRADO.");
            }
            else if (consulta.Status != "HIGIENIZACAO")
            {
                MessageBox.Show("CHAMADO NÃO ESTA EM HIGIENIZACAO.\r\nSTATUS = " + consulta.Status);
            }
            else
            {
                txtDescricao.Text = consulta.Descricao;
                txtClassificacao.Text = consulta.Classificacao;
                txtStatusA1.Text = consulta.StatusA1;
                txtCodVarejo.Text = consulta.CodVarejo;
                txtVarejista.Text = consulta.Varejista;    

                txtCodPositivo.Text = consulta.SKU;
                txtNS.Text = consulta.NS;

                consulta.ConsultarCodVarejo(txtCodVarejo.Text, txtVarejista.Text);
                if (consulta.Retorno == "ok")
                {
                    txtEAN.Text = consulta.EANpuri;
                }

                try
                {
                    consulta.DataAtual();
                    string hoje = consulta.dataNormal;
                    DateTime dt = Convert.ToDateTime(consulta.DtEntrada);                                       
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

                btnConcluir.Select();
                /*
                txtTipo.Text = consulta.TipoEquip;
                txtCodPositivo.Text = consulta.SKU;
                txtIMEI1.Text = consulta.IMEI1;
                txtIMEI2.Text = consulta.IMEI2;
                txtNF.Text = consulta.NF;
                txtInicioGarantia.Text = consulta.DtFatura;
                txtCalculoGarantia.Text = consulta.Meses;
                txtOrcamento.Text = consulta.Orcamento;
                txtDiasTroca.Text = consulta.DiasTroca;
                txtDiasVistoria.Text = consulta.DiasVistoria;
                txtObsDocumento.Text = consulta.ObsDocumento;
                txtVarejista.Text = consulta.Varejista;
                txtDefeitoRelatado.Text = consulta.DefeitoRelatado;
                 */
            }
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if (txtClassificacao.Text.Length > 0)
            {
                if (cboUsuario.Text.Length == 0)
                {
                    MessageBox.Show("INFORME O USUARIO.");
                }
                else
                {
                    string DOA = "";
                    if (chbEnviarComoDoa.Checked)
                    {
                        if (MessageBox.Show("EQUIPAMENTO É MEMSO DOA?", "CONFIRMACAO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            txtClassificacao.Text = "DEVOLUÇÃO DE VENDA - DOA";
                            DOA = "DOA";
                        }
                    }

                    if (chbNaoImprimir.Checked == false)
                    {
                        Imprimir();
                    }   

                    /*
                    if (txtClassificacao.Text.Contains("SALDO"))
                    {
                        ImprimirEAN();
                    }
                     */ 

                    string status = "EXPEDICAO";
                    consulta.comando = "";
                    consulta.comando = "update Chamados set Status = '" + status + "', Classificacao = '" + txtClassificacao.Text + "' where OS = '" + txtOS.Text + "' AND STATUS = 'HIGIENIZACAO' and CT = '" + lblCT.Text + "'";
                    consulta.Atualizar();
                    if (consulta.Retorno == "ok")
                    {
                        //======Insere na tabela Historico==========================
                        string StatusHistorico = "HIGIENIZACAO";
                        consulta.DataAtual();
                        consulta.InsereHistorico(txtOS.Text, lblUsuario.Text, StatusHistorico, consulta.dataNormal, consulta.hora, lblCT.Text);
                        //=====fim da inserção======================================


                        //   string Historico = txtHistorico.Text + " | " + lblTecnico.Text + " - REPARO: " + data;
                        if (consulta.Varejista != "MULTIVAREJO" && txtClassificacao.Text == "ORCAMENTO" && !txtStatusA1.Text.Contains("APROVADO"))
                        {
                            MessageBox.Show("SEPARAR O PRODUTO.\r\n\r\nPRODUTO AINDA NÃO APROVADO PELO VAREJISTA.");
                        }
                        btnLimpar.PerformClick();
                        ContadorDeProducao();
                        MessageBox.Show("HIGIENIZAÇÃO CADASTRADA COM SUCESSO.");
                        txtOS.Select();
                    }
                }             
               
            }
            else
            {
                MessageBox.Show("INFORME O EQUIPAMENTO.");
            }
        }

        public string RemoverAcentos(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";
            else
            {
                byte[] bytes = System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(input);
                return System.Text.Encoding.UTF8.GetString(bytes);
            }
        }

        public void Imprimir()
        {           
            string Voltagem = "";
            if (rbt110.Checked)
            {
                Voltagem = "110";
            }
            else if (rbtBIv.Checked)
            {
                Voltagem = "BI";
            }
            else
            {
                Voltagem = "220";
            }


            if (chbConfigImpressora.Checked)
            {
                imprimir.EtiquetaEANPuriConfig(Voltagem, txtCodVarejo.Text, txtCodPositivo.Text, txtEAN.Text, txtDescricao.Text);
            }
            else
            {
                imprimir.EtiquetaEANPuri(Voltagem, txtCodVarejo.Text, txtCodPositivo.Text, txtEAN.Text, txtDescricao.Text);
            }
           

            string codZPL = imprimir.s;

            // SELECIONAR IMPRESSORA OU UTILIZAR A PADRÃO
            if (chbSelecionarImpressora.Checked)
            {
                // Allow the user to select a printer.
                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new PrinterSettings();
                if (DialogResult.OK == pd.ShowDialog(this))
                {
                    // Send a printer-specific to the printer.
                    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, codZPL);
                }
            }
            else
            {
                string nomeImpressoraPadrao = (new PrinterSettings()).PrinterName;
                RawPrinterHelper.SendStringToPrinter(nomeImpressoraPadrao, codZPL);
            }

        }

        /*
        public void Imprimir()
        {
            
                string codZPL = "";
                //imprimir.TextoLivre = txtNS.Text;

                imprimir.Varejista = "MAGAZINE LUIZA - " + RemoverAcentos(consulta.Cidade);
                   
               
                consulta.CodPositivo = txtCodPositivo.Text;
                consulta.consultarImpressao();
                if (consulta.Retorno == "falha")
                {
                    consulta.PlayFail();
                    MessageBox.Show("CODIGO EAN NÃO CADASTRADO");
                }
                imprimir.CodEAN = consulta.EAN.Trim();
                imprimir.Serial = txtOS.Text;
                imprimir.NS = txtOS.Text;

                string Class = RemoverAcentos(txtClassificacao.Text);
                if (Class == "FORA DE GARANTIA")
                {
                    if (consulta.ObsClassificacao == "MAU USO / SUCATA")
                    {
                        Class = "OBSOLETO";
                    }
                    else
                    {
                        Class = "REMESSA ORCAMENTO";
                    }
                }
                else if (Class.Contains("DEVOLUCAO DE VENDA"))
                {
                    Class = "DEVOLUCAO DOA";
                }
                if (Class == "REPARO FUNCIONAL - GARANTIA")
                {
                    Class = "REMESSA GARANTIA";
                }
                if (Class == "REPARO FUNCIONAL - ORCAMENTO")
                {
                    Class = "REMESSA ORCAMENTO";
                }
               
                    
                
                imprimir.Classificacao = Class;
                imprimir.Genco = consulta.CodVarejo;
                imprimir.ChamadoPai = consulta.Chamado;
                imprimir.IMEI1 = consulta.IMEI1;
                imprimir.Filial = consulta.Filial;
                imprimir.Cidade = consulta.Cidade;

                /*
                imprimir.NFOrigem = txtNF.Text;                
                string PrimeiroDigito = txtNS.Text.Substring(0, 2);
                if (PrimeiroDigito == "1A")
                {
                    imprimir.Destino = "CURITIBA";
                }
                else
                {
                    imprimir.Destino = "MANAUS";
                }                        
                imprimir.Funcional = RemoverAcentos(txtFuncional.Text);
                imprimir.Estetico = RemoverAcentos(txtEstetico.Text);
                imprimir.Faltante = RemoverAcentos(txtFaltantes.Text);
                 


                //================VERIFICA SE É RETENÇÃO OU NÃO =================
                if (txtClassificacao.Text == "RETENCAO" || txtClassificacao.Text.Contains("SALDO"))
                {
                    imprimir.Classificacao = txtClassificacao.Text;
                    imprimir.Genco = consulta.CodVarejo; ;

                    imprimir.ModeloMag = txtDescricao.Text;
                    imprimir.EtiqChameOGenio = consulta.NumLacre;
                    imprimir.Lacre = consulta.NumLacre;
                    imprimir.Filial = consulta.Filial;
                    imprimir.Cidade = consulta.Cidade;
                    imprimir.CodAtendimentoChameGenio = "";

                    if (rbt300dpi.Checked)
                    {
                        imprimir.Magazine();
                    }
                    else if (rbt200dpi.Checked)
                    {
                        imprimir.Magazine200dpi();
                    }
                    else
                    {
                        imprimir.Magazine600dpi();
                    }

                    codZPL = imprimir.s;
                    // SELECIONAR IMPRESSORA OU UTILIZAR A PADRÃO
                    if (chbSelecionarImpressora.Checked)
                    {
                        // Allow the user to select a printer.
                        PrintDialog pd = new PrintDialog();
                        pd.PrinterSettings = new PrinterSettings();
                        if (DialogResult.OK == pd.ShowDialog(this))
                        {
                            // Send a printer-specific to the printer.
                            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, codZPL);
                        }
                    }
                    else
                    {
                        string nomeImpressoraPadrao = (new PrinterSettings()).PrinterName;
                        RawPrinterHelper.SendStringToPrinter(nomeImpressoraPadrao, codZPL);
                    }              
                }
                else
                {
                    if (rbt200dpi.Checked)
                    {
                        imprimir.EtiquetaLivre200dpi();
                        //codZPL = imprimir.s;
                    }
                    else if (rbt300dpi.Checked)
                    {
                        imprimir.EtiquetaLivre300dpi();
                        //codZPL = imprimir.s;
                    }
                    else
                    {
                        imprimir.EtiquetaLivre600dpi();
                    }

                    codZPL = imprimir.s;
                    // SELECIONAR IMPRESSORA OU UTILIZAR A PADRÃO
                    if (chbSelecionarImpressora.Checked)
                    {
                        // Allow the user to select a printer.
                        PrintDialog pd = new PrintDialog();
                        pd.PrinterSettings = new PrinterSettings();
                        if (DialogResult.OK == pd.ShowDialog(this))
                        {
                            // Send a printer-specific to the printer.
                            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, codZPL);
                        }
                    }
                    else
                    {
                        string nomeImpressoraPadrao = (new PrinterSettings()).PrinterName;
                        RawPrinterHelper.SendStringToPrinter(nomeImpressoraPadrao, codZPL);
                    }
                }
            
        }
*/




        public void ImprimirEAN()
        {
            imprimir.s = "";
            string codZPL = "";
            imprimir.IMEI1 = consulta.IMEI1;
            imprimir.IMEI2 = consulta.IMEI2;
            imprimir.CodEAN = consulta.EAN.Trim();
            imprimir.codPositivo = txtCodPositivo.Text;
            imprimir.NS = txtOS.Text;

            consulta.CodPositivo = txtCodPositivo.Text;
            ///consulta.consultarImpressao();
            if (consulta.Retorno == "falha")
            {
                consulta.PlayFail();
                MessageBox.Show("CODIGO EAN NÃO CADASTRADO");
            }

            imprimir.Anatel = consulta.Anatel;
            imprimir.produto = consulta.DescricaoEan;
            imprimir.configuracao1 = consulta.Config1;
            imprimir.configuracao2 = consulta.Config2;
            imprimir.configuracao3 = consulta.Config3;
            imprimir.configuracao4 = consulta.Config4;
            imprimir.configuracao5 = consulta.Config5;
            imprimir.configuracao6 = consulta.Config6;
            imprimir.configuracao7 = consulta.Config7;
            imprimir.configuracao8 = consulta.Config8;
            imprimir.configuracao9 = consulta.Config9;
            imprimir.configuracao10 = consulta.Config10;
            imprimir.configuracao11 = consulta.Config11;

            if (consulta.TipoEtiqueta == "CELULAR")
            {
                if (rbt600dpi.Checked)
                {
                    imprimir.EtiqCelularNova600();
                }
                else if (rbt200dpi.Checked)
                {
                    imprimir.EtiqCelularNova200();
                }
                else
                {
                    imprimir.EtiqCelularNova();
                }
            }
            else if (consulta.TipoEtiqueta == "EANHORIZONTAL")
            {
                if (rbt600dpi.Checked)
                {
                    imprimir.EtiqEANHorizontal600();
                }
                else if (rbt200dpi.Checked)
                {
                    imprimir.EtiqEANHorizontal200();
                }
                else
                {
                    imprimir.EtiqEANHorizontal();
                }
            }
            else if (consulta.TipoEtiqueta == "EANVERTICAL")
            {
                if (rbt600dpi.Checked)
                {
                    imprimir.EtiqEAN600();
                }
                else if (rbt200dpi.Checked)
                {
                    imprimir.EtiqEAN200();
                }
                else
                {
                    imprimir.EtiqEAN();
                }
            }
            else if (consulta.TipoEtiqueta == "TABLET")
            {
                if (rbt600dpi.Checked)
                {
                    imprimir.Tablet600();
                }
                else if (rbt200dpi.Checked)
                {
                    imprimir.Tablet200();
                }
                else
                {
                    imprimir.Tablet();
                }
            }
            else if (consulta.TipoEtiqueta == "TABLET3G")
            {
                if (rbt600dpi.Checked)
                {
                    imprimir.Tablet3G600();
                }
                else if (rbt200dpi.Checked)
                {
                    imprimir.Tablet3G200();
                }
                else
                {
                    imprimir.Tablet3G();
                }
            }
            else if (consulta.TipoEtiqueta == "QUANTUM")
            {
                if (rbt600dpi.Checked)
                {
                    imprimir.Quantum600();
                }
                else if (rbt200dpi.Checked)
                {
                    imprimir.Quantum200();
                }
                else
                {
                    imprimir.Quantum();
                }
            }
            else
            {
                MessageBox.Show("Etiqueta não encontrada!\r\nChamar o Suporte.");
            }
            codZPL = imprimir.s;

            if (codZPL.Length == 0)
            {
                MessageBox.Show("MODELO NÃO CADASTRADO");
            }
            else
            {
                if (chbSelecionarImpressora.Checked)
                {
                    // Allow the user to select a printer.
                    PrintDialog pd = new PrintDialog();
                    pd.PrinterSettings = new PrinterSettings();
                    if (DialogResult.OK == pd.ShowDialog(this))
                    {
                        // Send a printer-specific to the printer.
                        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, codZPL);
                    }
                }
                else
                {
                    string nomeImpressoraPadrao = (new PrinterSettings()).PrinterName;
                    RawPrinterHelper.SendStringToPrinter(nomeImpressoraPadrao, codZPL);
                }
            }                
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            consulta.LimparControles(this);
            chbSaldoA.Visible = false;
            chbSaldoB.Visible = false;            
        }

        private void chbSaldoA_CheckedChanged(object sender, EventArgs e)
        {
            if(chbSaldoA.Checked)
            {
                txtClassificacao.Text = "SALDO-A";
                chbSaldoB.Checked = false;
            }
            else
            {
                if (chbSaldoB.Checked == false)
                {
                    txtClassificacao.Text = "SALDO";
                }
                
            }
            
        }

        private void chbSaldoB_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSaldoB.Checked)
            {
                txtClassificacao.Text = "SALDO-B";
                chbSaldoA.Checked = false;
            }
            else
            {
                if (chbSaldoA.Checked == false)
                {
                    txtClassificacao.Text = "SALDO";
                }
            }
        }

        private void txtNS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBusca.PerformClick();
            }
        }

        private void btnRetornarReparo_Click(object sender, EventArgs e)
        {
            if (txtClassificacao.Text.Length > 0)
            {
                if (MessageBox.Show("DESEJA RETORNAR?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //======Insere na tabela Historico==========================
                    string StatusHistorico = "RETORNO-H";
                    consulta.DataAtual();
                    consulta.InsereHistorico(txtOS.Text, lblUsuario.Text, StatusHistorico, consulta.dataNormal, consulta.hora, lblCT.Text);
                    //=====fim da inserção======================================

                    string status = "REPARO";
                    consulta.comando = "";
                    consulta.comando = "update Chamados set Status = '" + status + "', Classificacao = '' where OS = '" + txtOS.Text + "' AND STATUS = 'HIGIENIZACAO' and CT = '" + lblCT.Text + "'";
                    consulta.Atualizar();
                    //   string Historico = txtHistorico.Text + " | " + lblTecnico.Text + " - REPARO: " + data;
                    btnLimpar.PerformClick();
                    ContadorDeProducao();
                    MessageBox.Show("RETORNADO COM SUCESSO.");
                    txtOS.Select();
                }               
            }
            else
            {
                MessageBox.Show("INFORME O EQUIPAMENTO.");
            }

        }

        private void chbEnviarComoDoa_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEnviarComoDoa.Checked)
            {
                MessageBox.Show("ESSE EQUIPAMENTO SERA ENVIADO COMO DOA");
               // txtClassificacao.Text = "DEVOLUÇÃO DE VENDA - DOA";               
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cboUsuario_SelectedValueChanged(object sender, EventArgs e)
        {
            ContadorDeProducao();
            lblUsuario.Text = cboUsuario.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void chbSALDO_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSALDO.Checked)
            {
                txtClassificacao.Text = "SALDO";
            }
            else
            {
                txtClassificacao.Text = consulta.Classificacao;
            }
        }



       




    }
}
