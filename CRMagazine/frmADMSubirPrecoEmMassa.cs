using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace CRMagazine
{
    public partial class frmADMSubirPrecoEmMassa : Form
    {
        public frmADMSubirPrecoEmMassa(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Consulta consulta = new Consulta();
        Conexao cx = new Conexao();
        Criterios criterios = new Criterios();

        public DateTime DtCompraConv;
        public DateTime DtTrocaConv;
        public DateTime DtTriagemConv;
        public string Erro = "";

        private void frmSubirEmMassa_Load(object sender, EventArgs e)
        {

        }

        //=========================Variaveis publicas ============================
        public string NS = "";
        public string Varejista = "";
        public string Descricao = "";    
        public string Tipo = ""; 
        //public string SKU = ""; 
        public string NF = ""; 
        public string DtFatura = ""; 
        public string Meses = ""; 
        public string Orcamento = "";
        public string DtCompra = ""; 
        public string DtTroca = ""; 
        public string DiasTroca = ""; 
        public string DiasVistoria = ""; 
        public string DefeitoRelatado = ""; 
        public string Filial = ""; 
        public string ObsDocumento = "";
        public string Estetico = ""; 
        public string Funcional = ""; 
        public string ItensFaltantes = ""; 
        public string AcaoRetencao = ""; 
        public string ObsRetencao = "";
        public string Classificacao = "";
        public string IMEI1 = "";
        public string IMEI2 = "";
        public string CidadeVarejo = "";
        public string ObsClassificacao = "";

        public string DtTriagem = "";
        public string Triador = "";
        public string Chamado = "";
        public string NFVarejo = "";
        public string CodVarejo = "";
        public string NumLacre = "";

        public int LinhaAtual = 0;

        // VARIAVEIS PARA AS ETIQUETAS
        public string TipoEtiqueta = "";
        public string CodPositivo = "";
        public string EAN = "";
        public string DescricaoEan = "";
        public string Anatel = "";
        public string Config1 = "";
        public string Config2 = "";
        public string Config3 = "";
        public string Config4 = "";
        public string Config5 = "";
        public string Config6 = "";
        public string Config7 = "";
        public string Config8 = "";
        public string Config9 = "";
        public string Config10 = "";
        public string Config11 = "";



        //novas variaveis

        public string Cod = "";
        public string Des = "";
        public string Pre = "";
        public string SKU = "";
        public string Categoria = "";
        public string Localizacao = "";

        public void ZeraVariaveis()
        {
            NS = "";
            Varejista = "";
            Descricao = "";
            Tipo = "";
            SKU = "";
            NF = "";
            DtFatura = "";
            Meses = "";
            Orcamento = "";
            DtCompra = "";
            DtTroca = "";
            DiasTroca = "";
            DiasVistoria = "";
            DefeitoRelatado = "";
            Filial = "";
            ObsDocumento = "";
            Estetico = "";
            Funcional = "";
            ItensFaltantes = "";
            AcaoRetencao = "";
            ObsRetencao = "";
            Classificacao = "";
            DtTriagem = "";
            Triador = "";
            Chamado = "";
            NFVarejo = "";
            CodVarejo = "";
            NumLacre = "";
            IMEI1 = "";
            IMEI2 = "";
            CidadeVarejo = "";
            Erro = "";

            TipoEtiqueta = "";
            CodPositivo = "";
            EAN = "";
            DescricaoEan = "";
            Anatel = "";
            Config1 = "";
            Config2 = "";
            Config3 = "";
            Config4 = "";
            Config5 = "";
            Config6 = "";
            Config7 = "";
            Config8 = "";
            Config9 = "";
            Config10 = "";
            Config11 = "";
        }

        /*
        // ======================== BLOCO DE NOTAS ===========================
        public void LerArquivo()
        {
            string filePath = "";
            LinhaAtual = 0;
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
                        LinhaAtual = LinhaAtual + 1;
                        //MessageBox.Show(line);
                        string linha = line;
                        if (linha.Contains(";"))
                        {
                            string[] contador = new string[23];
                            int i = 0;
                            while (linha.Contains(";"))
                            {
                                int indiceDoPrimeiroUnderline = linha.IndexOf(";");
                                contador[i] = linha.Substring(0, (indiceDoPrimeiroUnderline + 1));
                                linha = linha.Substring(indiceDoPrimeiroUnderline + 1);
                                contador[i] = contador[i].Replace(";", "").Replace(",", "");
                                contador[i] = contador[i].Trim();
                             //   MessageBox.Show(contador[i]);
                                i = i + 1;
                            }
                            
                            NS = contador[0];
                            Varejista = contador[1];
                            DtCompra = contador[2];
                            DtTroca = contador[3];
                            DefeitoRelatado = contador[4];
                            Filial = contador[5];
                            ObsDocumento = contador[6];
                            Estetico = contador[7];
                            Funcional = contador[8];
                            ItensFaltantes = contador[9];
                            AcaoRetencao = contador[10];
                            ObsRetencao = contador[11];
                            Classificacao = contador[12];
                            DtTriagem = contador[13];
                            Triador = contador[14];
                            Chamado = contador[15];
                            NFVarejo = contador[16];
                            CodVarejo = contador[17];
                            NumLacre = contador[18];
                            IMEI1 = contador[19];
                            IMEI2 = contador[20];
                            CidadeVarejo = contador[21];
                            ObsClassificacao = contador[22]; 



                            ConsultaNS();
                            if (DtCompra.Length > 0)
                            {
                                CalculaData();
                            }
                            if (Erro == "")
                            {
                                CalcularCriterios();
                            }
                            try
                            {
                                DtCompraConv = Convert.ToDateTime(DtCompra);
                                DtCompra = DtCompraConv.ToString("MM/dd/yyyy");
                            }
                            catch (Exception)
                            {

                            }
                            try
                            {
                                DtTrocaConv = Convert.ToDateTime(DtTroca);
                                DtTroca = DtTrocaConv.ToString("MM/dd/yyyy");
                            }
                            catch (Exception)
                            {

                            }
                           
                            //consulta.DataAtual();
                           // MessageBox.Show(DtTriagem);
                            try
                            {
                                DtTriagemConv = Convert.ToDateTime(DtTriagem);
                                DtTriagem = DtTriagemConv.ToString("MM/dd/yyyy");
                            }
                            catch (Exception)
                            {                                

                            }                          

                           // MostrarTudo();
                            if (Erro == "")
                            {
                                //Concluir();
                               // ConcluirData();
                            }
                            else
                            {

                            }                 
                            ZeraVariaveis();
                        }
                    }
                }
            }
            if (txtErro.Text.Length == 0)
            {
                btnGravar.Enabled = true;
            }
        }


        public void InserirNoBanco()
        {
            string filePath = "";
            LinhaAtual = 0;
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
                        LinhaAtual = LinhaAtual + 1;
                        //MessageBox.Show(line);
                        string linha = line;
                        if (linha.Contains(";"))
                        {
                            string[] contador = new string[23];
                            int i = 0;
                            while (linha.Contains(";"))
                            {
                                int indiceDoPrimeiroUnderline = linha.IndexOf(";");
                                contador[i] = linha.Substring(0, (indiceDoPrimeiroUnderline + 1));
                                linha = linha.Substring(indiceDoPrimeiroUnderline + 1);
                                contador[i] = contador[i].Replace(";", "").Replace(",", "");
                                contador[i] = contador[i].Trim();
                                //   MessageBox.Show(contador[i]);
                                i = i + 1;
                            }

                            NS = contador[0];
                            Varejista = contador[1];
                            DtCompra = contador[2];
                            DtTroca = contador[3];
                            DefeitoRelatado = contador[4];
                            Filial = contador[5];
                            ObsDocumento = contador[6];
                            Estetico = contador[7];
                            Funcional = contador[8];
                            ItensFaltantes = contador[9];
                            AcaoRetencao = contador[10];
                            ObsRetencao = contador[11];
                            Classificacao = contador[12];
                            DtTriagem = contador[13];
                            Triador = contador[14];
                            Chamado = contador[15];
                            NFVarejo = contador[16];
                            CodVarejo = contador[17];
                            NumLacre = contador[18];
                            IMEI1 = contador[19];
                            IMEI2 = contador[20];
                            CidadeVarejo = contador[21];
                            ObsClassificacao = contador[22];



                            ConsultaNS();
                            ConsultaDuplicidadeNS();
                            if (DtCompra.Length > 0)
                            {
                                CalculaData();
                            }
                            if (Erro == "")
                            {
                                CalcularCriterios();
                            }
                            try
                            {
                                DtCompraConv = Convert.ToDateTime(DtCompra);
                                DtCompra = DtCompraConv.ToString("MM/dd/yyyy");
                            }
                            catch (Exception)
                            {

                            }
                            try
                            {
                                DtTrocaConv = Convert.ToDateTime(DtTroca);
                                DtTroca = DtTrocaConv.ToString("MM/dd/yyyy");
                            }
                            catch (Exception)
                            {

                            }

                            //consulta.DataAtual();
                            // MessageBox.Show(DtTriagem);
                            try
                            {
                                DtTriagemConv = Convert.ToDateTime(DtTriagem);
                                DtTriagem = DtTriagemConv.ToString("MM/dd/yyyy");
                            }
                            catch (Exception)
                            {

                            }

                            // MostrarTudo();
                            if (Erro == "")
                            {
                                //Concluir();
                                ConcluirData();
                            }
                            else
                            {

                            }
                            ZeraVariaveis();
                        }
                    }
                }
            }
            btnGravar.Enabled = false;
        }


        public void MostrarTudo()
        {
            MessageBox.Show(NS + " / " + Varejista + " / " + Descricao + " / " + Tipo + " / " + SKU + " / " + NF + " / " + DtFatura + " / " + Meses + " / " + Orcamento + " / " + DtCompra + " / " + DtTroca + " / " + DiasTroca + " / " + DiasVistoria + " / " + DefeitoRelatado + " / " + Filial);
            MessageBox.Show(ObsDocumento + " / " + Estetico + " / " + Funcional + " / " + ItensFaltantes + " / " + AcaoRetencao + " / " + ObsRetencao + " / " + Classificacao + " / " + IMEI1 + " / " + IMEI2);
        }


        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            LerArquivo();          
        }

        // ======================== FIM DO BLOCO DE NOTAS ===========================
        */
          
         
        // ======================== INICIO EXCEL ====================================


        private void btnExcel_Click(object sender, EventArgs e)
        {
            txtErro.Text = "";
            lblStatus.Text = "";
            btnGravar.Enabled = false;
            OpenFileDialog vAbreArq = new OpenFileDialog();
            vAbreArq.Filter = "Microsoft Excel |*.xls; *.xlsx";
            vAbreArq.Title = "Selecione o Arquivo";
            if (vAbreArq.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show("igual =" + vAbreArq.FileName);
                string pasta = vAbreArq.FileName;
                txtEndereco.Text = pasta;                
            }
        }

        private void btnLerPlanilha_Click(object sender, EventArgs e)
        {
            txtErro.Text = "";
            lblStatus.Text = "";
            btnGravar.Enabled = false;
            importdatafromexcel(txtEndereco.Text);
        }

        public void importdatafromexcel(string pasta)
        {

            string myexceldataquery = "select PEÇA, [DESCRIÇÃO PEÇA], [SKU BRITANIA], CATEGORIA, LOCALIZAÇÃO, [VENDA] from [PEÇA$]";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //create our connection strings
                string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + pasta + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
                // string ssqlconnectionstring = "Server=011EIND2899\\SQLEXPRESS;Database=Vistoria;UID=sa;PWD=123";
              //  string ssqlconnectionstring = "Data Source=10.83.200.23,49172;Initial Catalog=Positivo;User ID=sa;Password=Maiden!@#";

                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);

                oledbconn.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
            //    SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);


                int Cont = 1;
                while (dr.Read())
                {
                    Cont = Cont + 1;
                    lblStatus.Text = "Executando Linha: " + Cont;
                    Cod = dr["PEÇA"].ToString();
                    Des = dr["DESCRIÇÃO PEÇA"].ToString();

                    SKU = dr["SKU BRITANIA"].ToString();
                    Categoria = dr["CATEGORIA"].ToString();
                    Localizacao = dr["LOCALIZAÇÃO"].ToString();

                    Pre = dr["VENDA"].ToString();

                    Des = Des.Replace("'", "*");

                    if (Pre == "")
                    {
                        Pre = "0";
                    }

                  //  MessageBox.Show(Pre);
                   // if (!Pre.Contains(","))
                 //   {
                 //       Pre = "0";
                 //   }

                    string comando = "select * from BaseCodigos where Codigo = '" + Cod + "' and SKU = '" + SKU + "' ";
                    consulta.ConsultarPreco(comando);
                    if (consulta.Retorno == "ok")
                    {
                    //    MessageBox.Show(Convert.ToDouble(Pre) + "  -  " + Convert.ToDouble(consulta.Preco));
                       
                        if (Convert.ToDouble(Pre) == Convert.ToDouble(consulta.Preco))                            
                        {
                           // MessageBox.Show("ja existe e esta OK");
                        }
                        else
                        {
                          //  MessageBox.Show("ja existe mas tem q atualizar");
                            Pre = Pre.Replace(".", "");
                            Pre = Pre.Replace(",", ".");
                          //  MessageBox.Show("preco antes = " + Pre);
                           // decimal preco = Convert.ToDecimal(Pre);
                            
                         //   MessageBox.Show("preco = " + preco);
                            consulta.comando = "";
                            consulta.comando = "update BaseCodigos set preco = '" + Pre + "' where Codigo = '" + Cod + "'";
                            consulta.Atualizar();
                        }
                    }
                    else
                    {
                        Pre = Pre.Replace(".", "");
                        Pre = Pre.Replace(",", ".");                       
                       // MessageBox.Show("ainda não existe");
                        consulta.InserePreco(Cod, Des, SKU, Categoria, Localizacao, Pre);
                    }

                  //  MessageBox.Show(Cod + "   " + Des + "   " + Pre);

                    LinhaAtual = Cont;
                    // ConsultaNS();
                    // ConsultaDuplicidadeNS();
                    // ConsultarEtiqueta();

                    //   ZeraVariaveis();                    
                }
                oledbconn.Close();
                this.Cursor = Cursors.Default;
                MessageBox.Show("PLANILHA INSERIDA COM SUCESSO.");
            }
            catch (Exception ex)
            {
                //handle exception
                MessageBox.Show("ERRO AO LER PLANILHA DE CÓDIGOS E PREÇOS:\r\n" + ex);
                this.Cursor = Cursors.Default;
            }
        }
        
        // ======================== FIM EXCEL ===========================================


     
        /*
        public void ConsultaNS()
        {
            
            string tipo = "";
            string data = "";
            consulta.NumeroSerie = NS;
            consulta.ConsultarNSEQUISAP();
            if (consulta.Retorno == "ok")
            {
                SKU = consulta.SAPCodPos.TrimStart('0');
                Descricao = consulta.SAPDescricao;
                // txtTipoSap.Text = consulta.SAPTipo;
                NF = consulta.NFFaturamento;
                data = consulta.InicioGarantia;
                TratarData(data.Trim());
                CalculaMeses();
                tipo = consulta.SAPTipo;
                TipoEquip(tipo.Trim());
            }
            else
            {
                Erro = "ERRO LINHA " + LinhaAtual + ": NS " + NS + " NÃO ENCONTRADO NO SAP.\r\n";
                txtErro.Text += Erro;
            }   
        }
         */ 
        
        public void ConsultaDuplicidadeNS()
        {                      
            consulta.Coluna = "NS";
            consulta.ValorDesejado = NS;
           // consulta.ConsultaTudo();
            if (consulta.Retorno != "ok" || consulta.Chamado != "PENDENTE")
            {
                
            }
            else
            {
                Erro = "ERRO LINHA " + LinhaAtual + ": NS " + NS + " JÁ CADASTRADO.\r\n";
                txtErro.Text += Erro;
            }
        }
        
        /*
        public void ConsultarEtiqueta()
        {
            consulta.CodPositivo = SKU;
            consulta.consultarImpressao();
            if (consulta.Retorno == "falha")
            {
                Erro = "ERRO LINHA " + LinhaAtual + ": NS " + NS + " SEM ETIQUETA CADASTRADA.\r\n";
                txtErro.Text += Erro;
            }
            else
            {
               / *
                TipoEtiqueta = consulta.TipoEtiqueta;
                CodPositivo = consulta.CodPositivo;
                EAN = consulta.EAN;
                DescricaoEan = consulta.DescricaoEan;
                Anatel = consulta.Anatel;
                Config1 = consulta.Config1;
                Config2 = consulta.Config2;
                Config3 = consulta.Config3;
                Config4 = consulta.Config4;
                Config5 = consulta.Config5;
                Config6 = consulta.Config6;
                Config7 = consulta.Config7;
                Config8 = consulta.Config8;
                Config9 = consulta.Config9;
                Config10 = consulta.Config10;
                Config11 = consulta.Config11;
                * /
            }
        }
        */

        public void TratarData(string data)
        {
            if (data.Length == 8)
            {
                string texto = data;
                string ano = texto.Substring(0, 4);
                string mes = texto.Substring(4, 2);
                string dia = texto.Substring(6, 2);
                DtFatura = dia + "/" + mes + "/" + ano;
            }
        }

        public void TipoEquip(string tipo)
        {
            if (tipo == "SMART2CHIP" ||
                tipo == "MESG3CHIP" ||
                tipo == "SMART3CHIP" ||
                tipo == "MESG2CHIP" ||
                tipo == "SMART1CHIP"
               )
            {              
                
                if (Descricao.Contains("SMART"))
                {
                    Tipo = "SMART";
                }
                else if (Descricao.Contains("FEATURE"))
                {
                    Tipo = "FEATURE";
                }
                else if (Descricao.Contains("S421"))
                {
                    Tipo = "SMART";
                }
                else
                {
                    Tipo = "FEATURE";
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
                if (Descricao.Contains("UNION"))
                {
                    Tipo = "UNION";
                }
                else
                {
                    Tipo = tipo;
                }
            }
            else
            {
                Tipo = tipo;
            }
        }

        public void CalculaMeses()
        {
            if (DtFatura.Length > 0)
            {
                DateTime agora = DateTime.Now;
                string hoje = agora.ToString("dd/MM/yyyy");
                string venda = DtFatura;
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
                //MessageBox.Show(meses + " Meses" + "\n" + orçamento);
                Meses = meses.ToString();
                Orcamento = orçamento;
            }    
        }

        public void CalculaData()
        {
            // CALCULA A DIFERENÇA DAS DATAS
            string compra = DtCompra;
            string troca = DtTroca;

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
                //MessageBox.Show("DATA DA TROCA INFERIOR A DATA DA COMPRA");
                Erro = "ERRO LINHA " + LinhaAtual + ": NS " + NS + " DATA DA TROCA INFERIOR A DATA DA COMPRA.\r\n";
                
            }
            else
            {
                DiasTroca = totalDias.ToString();
                DiasVistoria = CalcDias.ToString();

            }
        }

  

        /* retirar esse aki


        public void CalcularCriterios()
        {
            criterios.tempotroca = DiasTroca;
            criterios.tempotriagem = DiasVistoria;
            criterios.motivo = Funcional;
            criterios.garantia = Meses;
            // criterios.estadoequipamento = Estetico;
            //==========================================
            if (Estetico == "SEM AVARIAS")
            {
                criterios.estadoequipamento = Estetico;
            }
            else if (
                !Estetico.Contains("RISCADO") &&
                !Estetico.Contains("QUEBRADO") &&
                !Estetico.Contains("AMASSADO") &&
                !Estetico.Contains("MANCHADO")
                )
            {
                criterios.estadoequipamento = "SEM AVARIAS";
            }
            else
            {
                criterios.estadoequipamento = Estetico;
            }
            //===========================================
            criterios.acessorios = ItensFaltantes;
            criterios.retencao = AcaoRetencao;
            criterios.semdocumento = ObsDocumento;
            criterios.flag = "";
            if (ObsDocumento == "MomentoZero")
            {
                criterios.tempotroca = "0";
                criterios.tempotriagem = "0";
            }
            else if (ObsDocumento == "SemDocumento")
            {
                criterios.semdocumento = "SIM";
                criterios.tempotroca = "0";
                criterios.tempotriagem = "0";
            }
            else if (ObsDocumento == "SemPosto")
            {
                criterios.flag = "SemPosto";
            }
            else if (ObsDocumento == "MaisDe30Dias")
            {
                criterios.flag = "MaisDe30Dias";
            }
            else if (ObsDocumento == "Processo")
            {
                criterios.flag = "Processo";
            }

            if (Tipo == "FEATURE") // insirido a pedido do Danilo... se for feature fone é independente de documentação (por isso chama um critétio especifo para feature)
            {
                criterios.FeaturePhone();
                Classificacao = criterios.Classificacao;
            }
            else if (Varejista == "MagazineLuiza")
            {
                criterios.MagazineLojaFisica();
                Classificacao = criterios.Classificacao;
            }
            else if (Varejista == "Allied")
            {
                criterios.Allied();
                Classificacao = criterios.Classificacao;
            }
                /*
            else if (Varejista == "MasterEletronica")
            {
                if (Tipo == "SMART" || Tipo == "FEATURE")
                {
                    criterios.diaParaOrcamento = 7;
                }
                else
                {
                    criterios.diaParaOrcamento = 3;
                }
                criterios.MasterEletronica();
                Classificacao = criterios.Classificacao;
            }
                  
            else
            {
                // preparando os prazos conforme cada varejista
                int TrocaCel;
                int TrocaInfo;
                int PrazoTroca;
                if (Varejista == "RCell" || Varejista == "Mixtel")
                {
                    TrocaCel = 7;
                    TrocaInfo = 3;
                    PrazoTroca = 45;
                }
                else if (Varejista == "Ricardo Eletro")
                {
                    TrocaCel = 7;
                    TrocaInfo = 3;
                    PrazoTroca = 60;
                }
                else // se não for expecifico, recebe os criterios padrões
                {
                    TrocaCel = 7;
                    TrocaInfo = 3;
                    PrazoTroca = 30;
                }

                //chamando o a conculta dos criterios na classe Criterios
                if (Tipo == "SMART" || Tipo == "FEATURE")
                {
                    criterios.diaParaOrcamento = TrocaCel;
                }
                else
                {
                    criterios.diaParaOrcamento = TrocaInfo;
                }
                criterios.prazoTroca = PrazoTroca;               
                criterios.DemaisVarejistas();
                Classificacao = criterios.Classificacao;
               
            }

        }


        
        public void Concluir()
        {
            consulta.InsereNoBanco(NS, Descricao, Tipo, SKU,
                NF, DtFatura, Meses, Orcamento, DtCompra,
                DtTroca, DiasTroca, DiasVistoria, DefeitoRelatado,
                Filial, ObsDocumento, NFVarejo, CodVarejo, NumLacre, Estetico, Funcional, ItensFaltantes,
                AcaoRetencao, ObsRetencao, Classificacao, ObsClassificacao, Varejista, CidadeVarejo, Triador, Chamado, DtTriagem, IMEI1, IMEI2, "");
        }
          


        public void ConcluirData()
        {
            // com string ===
            consulta.InsereNoBancoDATA(NS, Descricao, Tipo, SKU,
                NF, DtFatura, Meses, Orcamento, DtCompraConv,
                DtTrocaConv, DiasTroca, DiasVistoria, DefeitoRelatado,
                Filial, ObsDocumento, NFVarejo, CodVarejo, NumLacre, Estetico, Funcional, ItensFaltantes,
                AcaoRetencao, ObsRetencao, Classificacao, ObsClassificacao, Varejista, CidadeVarejo, Triador, Chamado, DtTriagemConv, IMEI1, IMEI2, "");
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            InserirNoBancoFromExcel();
            //InserirNoBanco();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        */ //retirar esse aki


        // =================== INSERIR DADOS NO EXCEL DE ETIQUETAS ================

        //BLOCO PARA FUNCIONAR O EXCEL
        Microsoft.Office.Interop.Excel.Application xlexcel;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
       // Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet2;
        object misValue = System.Reflection.Missing.Value;

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


        public void GravarNoExcel()
        {    
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
           // string arquivo = ""; //endereço onde sera salvo as planilhas                                   
            bool existeDiretorio = File.Exists(folder + "\\ImpressaoEtiqueta - " + Chamado + ".xls "); //verifica se o diretorio existe
            if (existeDiretorio == true)
            {
            }
            else
            {
                try
                {
                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                  //  Excel.Range xlwidthadjust; //used this to adjust width of columns
                    object misValue = System.Reflection.Missing.Value;
                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    xlWorkBook.SaveAs(folder + "\\ImpressaoEtiqueta - " + Chamado, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
                                    Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();
                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                }
            }
            try
            {
                xlexcel = new Excel.Application();
                xlexcel.Visible = false;
                // Open a File
                xlWorkBook = xlexcel.Workbooks.Open(folder + "\\ImpressaoEtiqueta - " + Chamado + ".xls ", 0, false, 5, "", "", false,
                Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Cells[1, 1] = "NS";
                xlWorkSheet.Cells[1, 2] = "IMEI1";
                xlWorkSheet.Cells[1, 3] = "IMEI2";
                xlWorkSheet.Cells[1, 4] = "Varejista";
                xlWorkSheet.Cells[1, 5] = "Cidade";
                xlWorkSheet.Cells[1, 6] = "Classificacao";
                xlWorkSheet.Cells[1, 7] = "ObsClassificacao";
                xlWorkSheet.Cells[1, 8] = "NF";
                xlWorkSheet.Cells[1, 9] = "CodVarejo";
                xlWorkSheet.Cells[1, 10] = "ChamadoPai";
                xlWorkSheet.Cells[1, 11] = "Descricao";
                xlWorkSheet.Cells[1, 12] = "NumLacre";
                xlWorkSheet.Cells[1, 13] = "TipoEtiqueta";
                xlWorkSheet.Cells[1, 14] = "CodPositivo";
                xlWorkSheet.Cells[1, 15] = "EAN";
                xlWorkSheet.Cells[1, 16] = "DescricaoEan";
                xlWorkSheet.Cells[1, 17] = "Anatel";
                xlWorkSheet.Cells[1, 18] = "Config1";
                xlWorkSheet.Cells[1, 19] = "Config2";
                xlWorkSheet.Cells[1, 20] = "Config3";
                xlWorkSheet.Cells[1, 21] = "Config4";
                xlWorkSheet.Cells[1, 22] = "Config5";
                xlWorkSheet.Cells[1, 23] = "Config6";
                xlWorkSheet.Cells[1, 24] = "Config7";
                xlWorkSheet.Cells[1, 25] = "Config8";
                xlWorkSheet.Cells[1, 26] = "Config9";
                xlWorkSheet.Cells[1, 27] = "Config10";
                xlWorkSheet.Cells[1, 28] = "Config11";

                int _lastRow = xlWorkSheet.Range["A" + xlWorkSheet.Rows.Count].End[Excel.XlDirection.xlUp].Row + 1;

                xlWorkSheet.Cells[_lastRow, 1] = NS;
                xlWorkSheet.Cells[_lastRow, 2] = IMEI1;
                xlWorkSheet.Cells[_lastRow, 3] = IMEI2;
                xlWorkSheet.Cells[_lastRow, 4] = Varejista;
                xlWorkSheet.Cells[_lastRow, 5] = CidadeVarejo;
                xlWorkSheet.Cells[_lastRow, 6] = Classificacao;
                xlWorkSheet.Cells[_lastRow, 7] = ObsClassificacao;
                xlWorkSheet.Cells[_lastRow, 8] = NF;
                xlWorkSheet.Cells[_lastRow, 9] = CodVarejo;
                xlWorkSheet.Cells[_lastRow, 10] = Chamado;
                xlWorkSheet.Cells[_lastRow, 11] = Descricao;
                xlWorkSheet.Cells[_lastRow, 12] = NumLacre;
                xlWorkSheet.Cells[_lastRow, 13] = TipoEtiqueta;
                xlWorkSheet.Cells[_lastRow, 14] = CodPositivo;
                xlWorkSheet.Cells[_lastRow, 15] = EAN;
                xlWorkSheet.Cells[_lastRow, 16] = DescricaoEan;
                xlWorkSheet.Cells[_lastRow, 17] = Anatel;
                xlWorkSheet.Cells[_lastRow, 18] = Config1;
                xlWorkSheet.Cells[_lastRow, 19] = Config2;
                xlWorkSheet.Cells[_lastRow, 20] = Config3;
                xlWorkSheet.Cells[_lastRow, 21] = Config4;
                xlWorkSheet.Cells[_lastRow, 22] = Config5;
                xlWorkSheet.Cells[_lastRow, 23] = Config6;
                xlWorkSheet.Cells[_lastRow, 24] = Config7;
                xlWorkSheet.Cells[_lastRow, 25] = Config8;
                xlWorkSheet.Cells[_lastRow, 26] = Config9;
                xlWorkSheet.Cells[_lastRow, 27] = Config10;
                xlWorkSheet.Cells[_lastRow, 28] = Config11;

                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);    
            }
            catch (Exception x)
            {
                MessageBox.Show("ERRO ao inserir no excel: \n" + x.Message);               
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        


    }
}
