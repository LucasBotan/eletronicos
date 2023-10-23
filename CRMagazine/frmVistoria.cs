using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;


namespace CRMagazine
{
    public partial class frmVistoria : Form
    {
        public frmVistoria(string texto, string CT)
        {
            InitializeComponent();
            lblUsuario.Text = texto;
            lblCT.Text = CT;
        }

        private void frmVistoria_Load(object sender, EventArgs e)
        {
            txtOS.Select();
            PreencherComboboxVarejista();           
            ContadorDeProducao();
            chbIrParaReparo.Checked = false;
        }


        Consulta consulta = new Consulta();
        Impressao imprimir = new Impressao();
        Criterios criterios = new Criterios();
        Conexao cx = new Conexao();

        public void ContadorDeProducao()
        {
            consulta.DataAtual();
            string Status = "ENTRADA";
            consulta.comando = "select COUNT(*) as QNT from Historico where Usuario = '" + lblUsuario.Text + "' and Status = '" + Status + "' and Data = '" + consulta.dataNormal + "' and CT = '" + lblCT.Text + "'";
            consulta.consultarHistorico();
            lblContador.Text = consulta.cont.ToString();

            if (lblRestanteNF.Text != "0")
            {
                //===============verificando restante ============
                string comando = "";               
                //comando = "SELECT sum(convert(numeric,QntRestanteEnt)) as Quantidade from NotaFiscal where NotaFiscal = '" + cboNotaFiscal.Text + "'";
                comando = "SELECT sum(convert(numeric,QntRestanteEnt)) as Quantidade from NotaFiscal where QntRestanteEnt > 0 and CT = '" + lblCT.Text + "'";
                consulta.comando = comando;
                consulta.consultarSimNao();
                lblRestanteNF.Text = consulta.qntNaPosicao.ToString();

                if (lblRestanteNF.Text == "0")
                {
                    consulta.PlayOK();
                    MessageBox.Show("NOTA CONCLUIDA.");
                    PreencherComboboxVarejista();
                }
                //================================================                
            }

        }


        public void PreencherComboboxVarejista()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql = "";
            sql += " Select DISTINCT NotaFiscal from NotaFiscal where QntRestanteEnt != 0 and CT = '" + lblCT.Text + "'";
            cx.Conectar();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "NotaFiscal");
            cboNotaFiscal.ValueMember = "idNotaFiscal";
            cboNotaFiscal.DisplayMember = "NotaFiscal";
            cboNotaFiscal.DataSource = ds.Tables["NotaFiscal"];
            cx.Desconectar();
            cboNotaFiscal.Text = null;
            cboNotaFiscal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboNotaFiscal.AutoCompleteSource = AutoCompleteSource.ListItems;
           // cboNotaFiscal.Text = "";
           // lblRestanteNF.Text = "0";
        }


        public DateTime DtCompraConv;
        public string DtCompra = "";
        public DateTime DtTrocaConv;
        public string DtTroca = "";
        public DateTime DtEntradaConv;
        public string DtEntrada = "";



        public void consultaOS()
        {
            consulta.Coluna = "OS";
            consulta.ValorDesejado = txtOS.Text;
          //  consulta.ComData = "SIM"; // para não puxar os finalizados
            consulta.ConsultaTudo(lblCT.Text);
            if (consulta.Retorno != "ok")
            {
                txtCodVarejo.Select();
            }
            else
            {
                consulta.PlayFail();
                MessageBox.Show("OS JÁ CADASTRADA.");
                txtOS.Text = "";
                txtOS.Select();
            }
        }

        //================================ EVENTOS TXT OS =====================================
        private void txtNS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if(cboVarejista.Text == "MAGAZINE")
                {
                    txtNS.Text = txtNS.Text.TrimStart('0');
                }
                string PrimeiroDigito = "";
                try
                {
                    PrimeiroDigito = txtOS.Text.Substring(0, 1);
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }

                if ((cboVarejista.Text != "VIAVAREJO" && cboVarejista.Text != "CNOVA" && cboVarejista.Text != "MULTIVAREJO" && cboVarejista.Text != "MAGAZINE") || ((txtOS.Text.Length == 11) && (PrimeiroDigito == "0")) || ((txtOS.Text.Length == 8)))
                {
                    //((txtOS.Text.Length == 8) && (PrimeiroDigito == "d" || PrimeiroDigito == "D")) ||
                    consultaOS();
                }
               // if (txtOS.Text.Length == 8 || (cboVarejista.Text == "MULTIVAREJO" && txtOS.Text.Length == 11))
               // {
               //     consultaOS();
               // }
                else
                {
                    consulta.PlayFail();
                    MessageBox.Show("A OS DEVE TER 8 DIGITOS PARA VIA VAREJO E CNOVA\r\nOU\r\n11 DIGITOS PARA MULTI VAREJO.");
                    txtOS.Text = "";
                    txtOS.Select();
                }
            }
        }

        private void txtNS_Leave(object sender, EventArgs e)
        {
            if (txtOS.Text.Length > 0)
            {
                if (cboVarejista.Text == "MAGAZINE")
                {
                    txtNS.Text = txtNS.Text.TrimStart('0');
                }
                string PrimeiroDigito = "";
                try
                {
                    PrimeiroDigito = txtOS.Text.Substring(0, 1);
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }

                if ((cboVarejista.Text != "VIAVAREJO" && cboVarejista.Text != "CNOVA" && cboVarejista.Text != "MULTIVAREJO" && cboVarejista.Text != "MAGAZINE") || ((txtOS.Text.Length == 11) && (PrimeiroDigito == "0")) || ((txtOS.Text.Length == 8)))
                {                   
                    consultaOS();
                }
                // if (txtOS.Text.Length == 8 || (cboVarejista.Text == "MULTIVAREJO" && txtOS.Text.Length == 11))
                // {
                //     consultaOS();
                // }
                else
                {
                    consulta.PlayFail();
                    MessageBox.Show("A OS DEVE TER 8 DIGITOS PARA VIA VAREJO E CNOVA\r\nOU\r\n11 DIGITOS PARA MULTI VAREJO.");
                    txtOS.Text = "";
                    txtOS.Select();
                }
                /*
                if (txtOS.Text.Length == 8 || (cboVarejista.Text == "MULTIVAREJO" && txtOS.Text.Length == 11))
                {
                    consultaOS();
                }
                else
                {
                    consulta.PlayFail();
                    MessageBox.Show("A OS DEVE TER 8 DIGITOS PARA VIA VAREJO E CNOVA\r\nOU\r\n11 DIGITOS PARA MULTI VAREJO.");
                    txtOS.Text = "";
                    txtOS.Select();
                }
                 */ 
            }
        }
        //=======================================================================================




        private void txtCodVarejo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBusca.PerformClick();
            }
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            if (txtOS.Text.Length > 0)
            {
                txtCodVarejo.Text = txtCodVarejo.Text.TrimStart('0');
                consulta.ConsultarCodVarejo(txtCodVarejo.Text, cboVarejista.Text);
                if (consulta.Retorno == "ok")
                {
                    txtDescricao.Text = consulta.Descricao;
                    txtSKU.Text = consulta.SKU;
                    txtTipo.Text = consulta.TipoEquip;
                    //btnConcluir.Select();

                    //AKI
                    consulta.comando = "";
                    //consulta.comando = "select CodVarejo as Quantidade from Notafiscal where Notafiscal = '" + cboNotaFiscal.Text + "' and CodVarejo = '"+ txtCodVarejo.Text + "' and QntRestanteEnt > 0";
                    
                    
                    //consulta.comando = "select CodVarejo as Quantidade from Notafiscal where CodVarejo = '"+ txtCodVarejo.Text + "' and QntRestanteEnt > 0";
                    //consulta.consultarSimNao();
                    //if(consulta.qntNaPosicao != txtCodVarejo.Text && cboNotaFiscal.Text.Length > 0)
                    
                    consulta.comando = "";
                    consulta.comando = "SELECT count(NotaFiscal) as Quantidade FROM NotaFiscal where idNotaFiscal = (select top 1 idNotaFiscal from NotaFiscal where CodVarejo = '" + txtCodVarejo.Text + "' and QntRestanteEnt > 0 and Varejista = '" + cboVarejista.Text + "' and CT = '" + lblCT.Text + "')";
                    consulta.consultarSimNao();
                    if (Convert.ToInt32(consulta.qntNaPosicao) > 0 || lblCT.Text == "101")
                    {
                         txtNS.Select();
                    }
                    else                    
                    {
                        consulta.PlayFail();
                        MessageBox.Show("NOTA FISCAL SEM QUANTIDADE PARA ESSE CÓDIGO VAREJO.");
                        btnLimpar.PerformClick();

                    }
                }
                else
                {
                    consulta.PlayFail();
                    MessageBox.Show("CODIGO VAREJO NÃO CADASTRADO PARA ESSE VAREJISTA.");
                    txtCodVarejo.SelectAll();
                }
            }
            else
            {
                consulta.PlayFail();
                MessageBox.Show("PREENCHA A OS.");
                txtOS.Select();
            }
           
        }

       
       

        private void lnkLimpar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rbtMomentoZero.Checked = false;
            rbtSemDocumento.Checked = false;
            rbtMaisDe30Dias.Checked = false;
            rbtProcesso.Checked = false;
            rbtSemPosto.Checked = false;
            txtObsDocumento.Text = "";
        }


        private void rbtMomentoZero_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtMomentoZero.Checked)
            {
                mtbDataCompra.Text = "";
                mtbDataTroca.Text = "";           
                txtObsDocumento.Text = "MomentoZero";
            }     
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

        //===========================METODOS=============================================
        public void Tipo(string tipo)
        {
            if (tipo == "SMART2CHIP" ||
                tipo == "MESG3CHIP"  ||
                tipo == "SMART3CHIP" ||
                tipo == "MESG2CHIP"  ||
                tipo == "SMART1CHIP"
               )
            {
                if (txtDescricao.Text.Contains("SMART"))
                {
                    txtTipo.Text = "SMART";
                }
                else if (txtDescricao.Text.Contains("FEATURE"))
                {
                    txtTipo.Text = "FEATURE";
                }
                else if (txtDescricao.Text.Contains("S421"))
                {
                    txtTipo.Text = "SMART";
                }
                else
                {
                    txtTipo.Text = "FEATURE";
                }

            }
          //  else if( tipo == "MESG3CHIP" ||
          //    tipo == "MESG2CHIP" 
          //      )
          //  {
         //       txtTipo.Text = "FEATURE";
         //   }
            else if (tipo == "DESKTOP")
            {
                if (txtDescricao.Text.Contains("UNION"))
                {
                    txtTipo.Text = "UNION";
                }
                else
                {
                    txtTipo.Text = tipo;
                }
            }
            else
            {
                txtTipo.Text = tipo;
            }
        }

        /*
        public void TratarData(string data)
        {
            if (data.Length == 8)
            {
                string texto = data;
                string ano = texto.Substring(0, 4);
                string mes = texto.Substring(4, 2);
                string dia = texto.Substring(6, 2);              
                txtInicioGarantia.Text = dia + "/" + mes + "/" + ano;
            }            
        }
        */
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

            //===== NUMERO SERIE
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
            //===== DEFEITO RELATADO.
            if (txtDefeitoRelatado.Text.Length == 0 && rbtSemDocumento.Checked == false)
            {
                check = "falha";
                txtDefeitoRelatado.BackColor = Color.Tomato;
            }
            else
            {
                txtDefeitoRelatado.BackColor = DefaultBackColor;
            }

            //===== FILIAL.
            if (txtFilial.Text.Length == 0 && rbtSemDocumento.Checked == false)
            {
                check = "falha";
                txtFilial.BackColor = Color.Tomato;
            }
            else
            {
                txtFilial.BackColor = DefaultBackColor;
            }
             */ 
            //===== CODIGO VAREJO.
            if (txtCodVarejo.Text.Length == 0)
            {
                check = "falha";
                txtCodVarejo.BackColor = Color.Tomato;
            }
            else
            {
                txtCodVarejo.BackColor = DefaultBackColor;
            }

           
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

            /* DEIXEI REMARCADO PQ SE NÃO TIVER SAT NÃO PRECISA APONTAR
            // ==============================NOVO 03/12/2019================================================

            //===== DEFEITO RELATADO ( FUNC ou EST).
            if (cboFuncEst.Text.Length == 0 && rbtSemDocumento.Checked == false)
            {
                check = "falha";
                cboFuncEst.BackColor = Color.Tomato;
            }
            else
            {
                cboFuncEst.BackColor = DefaultBackColor;
            }
             */ 

            /*
            //===== DATA COMPRA
            if (mtbDataCompra.Text.Length == 0 && rbtSemDocumento.Checked == false && rbtMomentoZero.Checked == false)
            {
                check = "falha";
                mtbDataCompra.BackColor = Color.Tomato;
            }
            else
            {
                mtbDataCompra.BackColor = DefaultBackColor;
            }

            //===== DATA TROCA
            if (mtbDataTroca.Text.Length == 0 && rbtSemDocumento.Checked == false && rbtMomentoZero.Checked == false)
            {
                check = "falha";
                mtbDataTroca.BackColor = Color.Tomato;
            }
            else
            {
                mtbDataTroca.BackColor = DefaultBackColor;
            }    
             */ 

                    
        }

        

        //=====================================================================================

              
        /*
        private void txtInicioGarantia_TextChanged(object sender, EventArgs e)
        {
            if (txtInicioGarantia.Text.Length > 0)
            {
                DateTime agora = DateTime.Now;
                string hoje = agora.ToString("dd/MM/yyyy");
                string venda = txtInicioGarantia.Text;
                // converte resultado para date
                DateTime data_final = Convert.ToDateTime(hoje);
                DateTime data_inicial = Convert.ToDateTime(venda);
                // obtém a diferença
                TimeSpan dif = data_final.Subtract(data_inicial);
                // exibe o resultado
                int meses = (dif.Days / 30);
                string orçamento = "";
                if (meses > 15)
                {
                    orçamento = "FORA GARANTIA";
                }
                else { orçamento = "GARANTIA"; }
                consulta.PlayFail();
              //  MessageBox.Show(meses + " Meses" + "\n" + orçamento);
                txtCalculoGarantia.Text = meses.ToString();
                txtOrcamento.Text = orçamento;
            }            
        }
        */

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

        private void mtbDataCompra_Enter(object sender, EventArgs e)
        {
            if (rbtSemDocumento.Checked)
            {
                consulta.PlayFail();
                MessageBox.Show("OPÇÃO 'SEM DOCUMENTO' SELECIONADA.");
                rbtSemDocumento.Focus();
            }
            else if (rbtMomentoZero.Checked)
            {
                consulta.PlayFail();
                MessageBox.Show("OPÇÃO 'MOMENTO ZERO' SELECIONADA.");
                rbtMomentoZero.Focus();
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

        private void mtbDataCompra_Leave(object sender, EventArgs e)
        {
           // MessageBox.Show(mtbDataCompra.Text.Length.ToString());
            if(mtbDataCompra.Text.Length == 0)
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

      
       
        
        /*
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string check;
            Verificacao(out check);
            if (check == "falha")
            {
                consulta.PlayFail();
                MessageBox.Show("OS CAMPOS OBRIGATÓRIOS DEVEM ESTAR PREENCHIDOS.");
            }
            else if (cboCidade.Text.Length == 0)
            {
                consulta.PlayFail();
                MessageBox.Show("SELECIONE A CIDADE.");
            }
            else if (txtCalculoGarantia.Text.Length == 0)
            {
                consulta.PlayFail();
                MessageBox.Show("NÃO É POSSIVEL CALCULAR GARANTIA, POIS A DATA DA COMPRA ESTA VAZIA.");
            }
            else
            {
               // CalcularCriterios();
             //   txtClassificacao.Text = criterios.Classificacao;
                consulta.PlayOK();
                MessageBox.Show(criterios.Classificacao);
                MessageBox.Show("CALCULO DA GARANTIA CONCLUÍDO.\r\nCLIQUE EM CONCLUIR PARA FINALIZAR.");
            }                 
        }
         */ 

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            string check;
            Verificacao(out check);
            if (check == "falha")
            {
                consulta.PlayFail();
                MessageBox.Show("OS CAMPOS OBRIGATÓRIOS DEVEM ESTAR PREENCHIDOS.");
            }
            else if (txtOS.Text.Length < 8 && (cboVarejista.Text == "VIAVAREJO" || cboVarejista.Text == "CNOVA" || cboVarejista.Text == "MAGAZINE"))
            {
                consulta.PlayFail();
                MessageBox.Show("VERIFIQUE A OS.");
            }
            else if (txtOS.Text.Length < 11 && cboVarejista.Text == "MULTIVAREJO")
            {
                consulta.PlayFail();
                MessageBox.Show("VERIFIQUE A OS.");
            }            
            else if (cboVarejista.Text.Length == 0)
            {
                consulta.PlayFail();
                MessageBox.Show("SELECIONE O VAREJISTA.");
            }
            else if (mtbDataGaiola.Text.Length == 0)
            {
                consulta.PlayFail();
                MessageBox.Show("INFORME A DATA DA GAOILA.");
            }
            else
            {
                
                /*
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
                try
                {
                    consulta.DataAtual();
                    DtEntradaConv = Convert.ToDateTime(consulta.dataNormal);
                    DtEntrada = DtEntradaConv.ToString("MM/dd/yyyy");
                }
                catch (Exception)
                {

                }
                 */
                consulta.comando = "";
                consulta.comando = "SELECT count(NotaFiscal) as Quantidade FROM NotaFiscal where idNotaFiscal = (select top 1 idNotaFiscal from NotaFiscal where CodVarejo = '" + txtCodVarejo.Text + "' and QntRestanteEnt > 0 and Varejista = '" + cboVarejista.Text + "' and CT = '" + lblCT.Text + "')";
                consulta.consultarSimNao();
                if (Convert.ToInt32(consulta.qntNaPosicao) > 0 || lblCT.Text == "101")
                {
                    Concluir();
                    if (consulta.Retorno == "ok")
                    {

                        //USAR ESSE DE EXEMPLO
                        /*
                         * update Orcamento set DataRecebido = '06/04/2020' where idOrcamento = 
                            (select top 1 idOrcamento from Orcamento where Data='06/04/2020')
                         */
                        //=============Diminui o restante na NotaFical==============

                        /* ESSE É O ERRADO, Q DIMINUIA TODOS DO CODIGO (NÃO SÓ DA PRIMEIRA LINHA Q ENCONTRASSE)
                        consulta.comando = "";
                        //consulta.comando = "update NotaFiscal set QntRestanteEnt = QntRestanteEnt - 1 where Notafiscal = '" + cboNotaFiscal.Text + "' and CodVarejo = '"+ txtCodVarejo.Text + "'";
                        consulta.comando = "update NotaFiscal set QntRestanteEnt = QntRestanteEnt - 1 where CodVarejo = '" + txtCodVarejo.Text + "' and QntRestanteEnt > 0";
                        consulta.Atualizar();
                         */

                        //EXEMPLO que é para dar certo --> é só revisar
                        if(lblCT.Text != "101")
                        {
                            consulta.comando = "";
                            consulta.comando = "update NotaFiscal set QntRestanteEnt = QntRestanteEnt - 1 where idNotaFiscal = (select top 1 idNotaFiscal from NotaFiscal where CodVarejo = '" + txtCodVarejo.Text + "' and QntRestanteEnt > 0 and Varejista = '" + cboVarejista.Text + "' and CT = '" + lblCT.Text + "' order by CONVERT(date, Data, 103) ASC) ";
                            consulta.Atualizar();
                        }
                        

                        //==========================================================



                        //======Insere na tabela Historico==========================
                        if (cboVarejista.Text == "VIAVAREJO" || cboVarejista.Text == "MULTIVAREJO" || cboVarejista.Text == "CNOVA" || cboVarejista.Text == "MAGAZINE")
                        {
                            string StatusHistorico = "ENTRADA";
                            consulta.DataAtual();
                            consulta.InsereHistorico(txtOS.Text, lblUsuario.Text, StatusHistorico, consulta.dataNormal, consulta.hora, lblCT.Text);
                        }
                        else //SE NÃO VOR DA VIA INSERE A OS GERADA (consulta.OSoutros)
                        {
                            txtOS.Text = consulta.OSoutros;
                            string StatusHistorico = "ENTRADA";
                            consulta.DataAtual();
                            consulta.InsereHistorico(consulta.OSoutros, lblUsuario.Text, StatusHistorico, consulta.dataNormal, consulta.hora, lblCT.Text);

                            MessageBox.Show("OS GERADA = " + consulta.OSoutros);
                        }
                        //=====fim da inserção======================================

                        if (chbNaoImprimir.Checked == false)
                        {
                            Imprimir();
                        }


                        if (chbIrParaReparo.Checked)
                        {
                            frmReparo c = new frmReparo(lblUsuario.Text, txtOS.Text, lblCT.Text);
                            c.ShowDialog();
                        }

                        consulta.PlayOK();
                        btnLimpar.PerformClick();
                        MessageBox.Show("EQUIPAMENTO CADASTRADO COM SUCESSO.");
                        ContadorDeProducao();
                    }
                    else
                    {
                        MessageBox.Show("ERRO AO SALVAR INFORMAÇÕES.");
                    }
                }
                else
                {
                    consulta.PlayFail();
                    MessageBox.Show("NÃO FOI POSSÍVEL ATRIBUIR UMA NOTA FISCAL.");
                }

                               
                    
            }      
        }


        public void Imprimir()
        {
           // consulta.DataAtual();


            // converte resultado para date                      
            DateTime data_compra = Convert.ToDateTime(consulta.dataNormal);
            DateTime Mais30 = data_compra.AddDays(30);
            string DataMais30 = Mais30.ToString("dd/MM/yyyy");

            imprimir.EtiquetaEntrada(txtOS.Text, consulta.dataNormal, DataMais30);

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
       
        public void Concluir()
        {
            string DataGaiola = "";
            try
            {              
                DataGaiola = mtbDataGaiola.Text.Substring(0, 2) + "/" + mtbDataGaiola.Text.Substring(2, 2) + "/" + mtbDataGaiola.Text.Substring(4, 4);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

            if(cboVarejista.Text == "VIAVAREJO" || cboVarejista.Text == "MULTIVAREJO" || cboVarejista.Text == "CNOVA" || cboVarejista.Text == "MAGAZINE")
            {
                consulta.InsereNoBanco(txtOS.Text, txtCodVarejo.Text, txtDescricao.Text, txtSKU.Text, consulta.data, "REPARO", txtTipo.Text, cboVarejista.Text, txtNS.Text, cboFuncEst.Text + " / " + txtDefeitoRelatado.Text, txtFilial.Text, DataGaiola, lblCT.Text);
            }
            else
            {
                //SE FOR OUTROS VAREJISTAS VAI GERAR A OS AUTOMATICAMENTE
                 consulta.InsereNoBancoOutros(txtCodVarejo.Text, txtDescricao.Text, txtSKU.Text, consulta.data, "REPARO", txtTipo.Text, cboVarejista.Text, txtNS.Text, cboFuncEst.Text + " / " + txtDefeitoRelatado.Text, txtFilial.Text, DataGaiola, lblCT.Text);
            }
            
           


            /*
            consulta.comando = "";
            consulta.comando += "Select COUNT(OS) as Quantidade from Chamados where Status = 'REPARO' and OS = '" + txtOS.Text + "'";
            consulta.consultarSimNao();
            if (Convert.ToInt32(consulta.qntNaPosicao) == 0)
            {
                MessageBox.Show("NÃO INSERIU NO BANCO.");
            }
             */ 
        }

        /*
        public void ConcluirData()
        {
            string ObsClassificacao = "";
            if (chbForaGarantia.Checked)
            {
                ObsClassificacao = "MAU USO / SUCATA";
            }
            else if (txtClassificacao.Text == "FORA DE GARANTIA" && chbForaGarantia.Checked == false)
            {
                ObsClassificacao = "ORCAMENTO";
            }

            string Doa_NoaDoa = "";
            if (txtClassificacao.Text.Contains("DEVOLUÇÃO DE VENDA") || txtClassificacao.Text.Contains("DEVOLUCAO DE VENDA"))
            {
                Doa_NoaDoa = "DOA";
            }
            else
            {
                Doa_NoaDoa = "NAO DOA";
            }

            consulta.InsereNoBancoDATA(txtNS.Text, txtDescricao.Text, txtTipo.Text, txtCodPositivo.Text,
                txtNF.Text, txtInicioGarantia.Text, txtCalculoGarantia.Text, txtOrcamento.Text, DtCompraConv,
                DtTrocaConv, txtCalculoTroca.Text, txtCalculoTroca_Hoje.Text, txtDefeitoRelatado.Text,
                txtFilial.Text, txtObsDocumento.Text, txtNFVarejo.Text, txtCodVarejo.Text, txtNumLacre.Text, txtEstetico.Text, txtFuncional.Text, txtFaltantes.Text,
                txtReparo.Text, txtObsReparo.Text, txtClassificacao.Text, Doa_NoaDoa, ObsClassificacao, cboVarejista.Text, cboCidade.Text, txtTriador.Text, txtChamado.Text, DtEntradaConv, txtIMEI1.Text, txtIMEI2.Text, "");
        }
         */ 
                  

        // ===== ALIMENTA AS VARIAVEIS E CHAMA O METODO DOS CRITERIOS DOS VAREJISTAS ======================
               
        /*
        public void CalcularCriterios()
        {
            criterios.tempotroca = txtCalculoTroca.Text;
            criterios.tempotriagem = txtCalculoTroca_Hoje.Text;
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
            criterios.retencao = txtReparo.Text;            
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
            if (rbtMomentoZero.Checked)
            {
                criterios.tempotroca = "0";
                criterios.tempotriagem = "0";
            }
            else if (rbtSemDocumento.Checked)
            {
                criterios.semdocumento = "SIM";
                criterios.tempotroca = "0";
                criterios.tempotriagem = "0";
            }
            else if (rbtSemPosto.Checked)
            {
                criterios.flag = "SemPosto";
            }
            else if (rbtMaisDe30Dias.Checked)
            {
                criterios.flag = "MaisDe30Dias";
            }
            else if (rbtProcesso.Checked)
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
            else if(cboVarejista.Text == "MagazineLuiza")
            {
                criterios.MagazineLojaFisica();
            }

            else if (cboVarejista.Text == "Allied")
            {
                criterios.Allied();
            }
               / *
            else if (cboVarejista.Text == "MasterEletronica")
            {
                if (txtTipo.Text == "SMART" || txtTipo.Text == "FEATURE")
                {
                    criterios.diaParaOrcamento = 7;
                }
                else
                {
                    criterios.diaParaOrcamento = 3;
                }
                criterios.MasterEletronica();
            }
            else if (cboVarejista.Text == "Carrefour")
            {
                if (txtTipo.Text == "SMART" || txtTipo.Text == "FEATURE")
                {
                    criterios.diaParaOrcamento = 7;
                }
                else
                {
                    criterios.diaParaOrcamento = 3;
                }
                criterios.MasterEletronica();
            }
             * /
            else
            {
                if (txtTipo.Text == "SMART" || txtTipo.Text == "FEATURE")
                {
                    criterios.diaParaOrcamento = Convert.ToInt32(txtTrocaCel.Text);
                }
                else
                {
                    criterios.diaParaOrcamento = Convert.ToInt32(txtTrocaInfo.Text);
                }
                criterios.prazoTroca = Convert.ToInt32(txtPrazoTroca.Text);

                criterios.DemaisVarejistas();
            }
        }       
        */



       
      
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            DtCompra = "";
            DtTroca = "";
            DtCompraConv = DateTime.MinValue;
            DtTrocaConv = DateTime.MinValue;
            consulta.LimparControles(this);
            ContadorDeProducao();
            txtOS.Select();
            if (cboVarejista.Text != "VIAVAREJO" && cboVarejista.Text != "CNOVA" && cboVarejista.Text != "MULTIVAREJO" && cboVarejista.Text != "MAGAZINE")
            {
                txtOS.Text = "JBINFO";
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

       


        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDefeitoRelatado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnConcluir.Select();
            }
            /*
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
             */ 
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            
        }


        // = MAGAZINE LOJA VIRTUAL





        //========= TRATAMENTOS OFF LINE ===================

        //BLOCO PARA FUNCIONAR O EXCEL
        //Microsoft.Office.Interop.Excel.Application xlexcel;
        //Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        //Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        //Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet2;
        //object misValue = System.Reflection.Missing.Value;

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        // FIM DO BLOCO PARA FUNCIONAR O EXCEL


        /*
        public void gerarString(out string texto)
        {
            string ObsClassificacao = "";
            if (chbForaGarantia.Checked)
            {
                ObsClassificacao = "MAU USO / SUCATA";
            }
            else if (txtClassificacao.Text == "FORA DE GARANTIA" && chbForaGarantia.Checked == false)
            {
                ObsClassificacao = "ORCAMENTO";
            }
            /*
            texto = "";
            texto = txtNS.Text + ";" + txtDescricao.Text + ";" + txtCodPositivo.Text + ";" + txtNF.Text + ";" + txtInicioGarantia.Text + ";" + txtCalculoGarantia.Text + ";" + txtOrcamento.Text + ";" + cboVarejista.Text + ";";
            texto += "";
            texto += txtDataCompra.Text + ";" + txtDataTroca.Text + ";" + txtCalculoTroca.Text + ";" + txtCalculoTroca_Hoje.Text + ";" + txtDefeitoRelatado.Text + ";" + txtFilial.Text + ";" + txtOrcamento.Text + ";";
            texto += txtEstetico.Text + ";" + txtFuncional.Text + ";" + txtFaltantes.Text + ";" + txtReparo.Text + ";" + txtObsReparo.Text + ";" + txtClassificacao.Text + ";";     
            */
           // consulta.DataAtual();
          //  data = agora.ToString("MM/dd/yyyy");
        /*
            DateTime agora = DateTime.Now;
            string hoje = agora.ToString("dd/MM/yyyy");

            texto = "";
            texto = txtNS.Text + ";" + cboVarejista.Text + ";";
            texto += txtDataCompra.Text + ";" + txtDataTroca.Text + ";" + txtDefeitoRelatado.Text + ";" + txtFilial.Text + ";" + txtObsDocumento.Text + ";";
            texto += txtEstetico.Text + ";" + txtFuncional.Text + ";" + txtFaltantes.Text + ";" + txtReparo.Text + ";" + txtObsReparo.Text + ";" + txtClassificacao.Text + ";";
            texto += hoje + ";" + txtTriador.Text + ";" + txtChamado.Text + ";" + txtNFVarejo.Text + ";" + txtCodVarejo.Text + ";" + txtNumLacre.Text + ";" + txtIMEI1.Text + ";" + txtIMEI2.Text + ";" + cboCidade.Text + ";" + ObsClassificacao + ";";   
            
        }

    */

        public void LerArquivo()
        {
            string filePath = "";
            OpenFileDialog vAbreArq = new OpenFileDialog();
            vAbreArq.Filter = "NotePad |*.LOG";
            vAbreArq.Title = "Selecione o Arquivo";
            if (vAbreArq.ShowDialog() == DialogResult.OK)
            {
                filePath = vAbreArq.FileName;
            }            
            string line = "";
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {                    
                    while ((line = reader.ReadLine()) != null)
                    {
                        MessageBox.Show(line);
                        string linha = line;
                        if (linha.Contains(";"))
                        {
                            string[] contador = new string[20];
                            int i = 0;
                            while(linha.Contains(";"))
                            {
                                int indiceDoPrimeiroUnderline = linha.IndexOf(";");
                                contador[i]= linha.Substring(0, (indiceDoPrimeiroUnderline + 1));
                                linha = linha.Substring(indiceDoPrimeiroUnderline + 1);
                                contador[i] = contador[i].Replace(";", "").Replace(",", "");
                                contador[i] = contador[i].Trim();
                                MessageBox.Show(contador[i]);
                                i = i + 1;
                            }
                            MessageBox.Show("NS: " + contador[0]);
                            MessageBox.Show("outro: " + contador[1]);
                        }
                    }
                }
            }           
        }

        private void btnLocalArquivo_Click(object sender, EventArgs e)
        {
            LerArquivo();
        }

        private void txtDefeitoRelatado_Leave(object sender, EventArgs e)
        {
            if (txtDefeitoRelatado.Text.Contains(";"))
            {
                txtDefeitoRelatado.Text = txtDefeitoRelatado.Text.Replace(";", "");
            }
        }

        private void txtFilial_Leave(object sender, EventArgs e)
        {
            if (txtFilial.Text.Contains(";"))
            {
                txtFilial.Text = txtFilial.Text.Replace(";", "");
            }
        }

        private void txtObsReparo_Leave(object sender, EventArgs e)
        {
            
         
        }

        private void label20_Click(object sender, EventArgs e)
        {
            //frmSubirEmMassa c = new frmSubirEmMassa();
            //c.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFilial_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {               
                cboFuncEst.Select();
            }
            /*
            if (e.KeyChar == 13)
            {
                txtNumLacre.Select();
            }
             */ 
        }

        private void txtNumLacre_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCodVarejo.Select();
            }
        }

       

        private void btnConsulta_Click(object sender, EventArgs e)
        {
          //  frmConsultaEquipamento c = new frmConsultaEquipamento();
           // c.Show();
        }

        private void txtTriador_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
           
        }

        private void txtChamado_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
               // cboVarejista.Select();
            }
        }

        private void cboVarejista_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtOS.Select();
            }
        }


        
        
        private void label19_Click(object sender, EventArgs e)
        {
            //TratarModelo();
        }

        private void txtTipo_TextChanged(object sender, EventArgs e)
        {
            
        }

       
       
        /*
        private void txtTipo_Leave(object sender, EventArgs e)
        {
            if (txtTipo.Text != "SMART" && txtTipo.Text != "FEATURE" && txtTipo.Text != "NOTEBOOK" && txtTipo.Text != "DESKTOP" && txtTipo.Text != "UNION" && txtTipo.Text != "TABLET" && txtTipo.Text != "MONITOR" && txtTipo.Text != "")
            {
                txtTipo.Text = "";
                consulta.PlayFail();
                MessageBox.Show("PREENCHA COM:\r\nSMART\r\nFEATURE\r\nNOTEBOOK\r\nDESKTOP\r\nUNION\r\nTABLET\r\nMONITOR");
                txtTipo.Select();
            }
        }
        */

        public void Ping(out string feed)
        {
            feed = "";
            Ping myPing = new Ping();
            //PingReply reply = myPing.Send("8.8.8.8",1000);
            PingReply reply = myPing.Send("10.83.200.23", 1000);
            if (reply != null)
            {
                feed = reply.Status.ToString();   
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            /*
            string feed ="";
            Ping(out feed);
            MessageBox.Show(feed);
             */
         //   Imprimir();
         //   ImprimirEAN();
        }

        private void rbt300dpi_CheckedChanged(object sender, EventArgs e)
        {

        }

        /*
        public void ImprimirEtqMagazine()
        {
            string codZPL = "";
            string Cidade = RemoverAcentos(cboCidade.Text);
            consulta.DataAtual();
            imprimir.Entrada(txtOS.Text, txtDescricao.Text, Cidade, consulta.dataNormal);
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
         */

        private void txtCodPositivo_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            txtSKU.ReadOnly = false;
        }

        private void chbForaGarantia_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cboVarejista_TextChanged(object sender, EventArgs e)
        {   
            

        }
               
       
        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void mtbDataGaiola_TextChanged(object sender, EventArgs e)
        {
            if (mtbDataGaiola.Text.Length > 7)
            {                
                string check = "";
                string Vdata = "";
                ValidaData(mtbDataGaiola.Text, out check, out Vdata);
                if (check == "OK")
                {                    
                   
                }
                else
                {
                    mtbDataGaiola.SelectAll();
                }
            }                
        }

        private void mtbDataGaiola_Leave(object sender, EventArgs e)
        {
            if (mtbDataGaiola.Text.Length == 0)
            {
                
            }
            else if (mtbDataGaiola.Text.Length < 8)
            {
                consulta.PlayFail();
                MessageBox.Show("DATA INVÁLIDA");
                mtbDataGaiola.Focus();
            }
            else
            {
                string check = "";
                string Vdata = "";
                ValidaData(mtbDataGaiola.Text, out check, out Vdata);
                if (check == "OK")
                {
                    
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           // Imprimir();
            
        }

        private void txtNS_KeyPress_1(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtFilial.Select();
                //cboFuncEst.Select();
            }
        }

        private void cboFuncEst_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDefeitoRelatado.Select();
            }
        }

        private void txtNS_Leave_1(object sender, EventArgs e)
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
                MessageBox.Show("O NS DEVE TER 15 DIGITOS.");
                txtNS.Text = "";
                txtNS.Select();
            }
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

        private void cboNotaFiscal_SelectedValueChanged(object sender, EventArgs e)
        {
            ContadorDeProducao();
        }

        private void lnkAtualizar_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            PreencherComboboxVarejista();
        }

        private void cboNotaFiscal_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            MessageBox.Show("ESCRITA NÃO PERMITIDA.");
            if (cboNotaFiscal.Text.Length > 0)
            {
                cboNotaFiscal.Text = "";
            }
        }

        private void cboVarejista_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboVarejista.Text != "VIAVAREJO" && cboVarejista.Text != "CNOVA" && cboVarejista.Text != "MULTIVAREJO" && cboVarejista.Text != "MAGAZINE")
            {
                txtOS.Text = "JBINFO";
                txtOS.Select();
            }
            else
            {
                txtOS.Text = "";
                txtOS.Select();
            }
        }

        

       



      





    }       

}
