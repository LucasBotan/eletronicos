using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using LeitorXML;
using System.Xml;
using System.IO;
using System.Data.SqlClient;

namespace CRMagazine
{
    public partial class frmEntradaDeNotas : Form
    {
        public frmEntradaDeNotas(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Consulta consultar = new Consulta();
        Conexao cx = new Conexao();

        private void frmEntradaDeNotas_Load(object sender, EventArgs e)
        {
            FormatarGridTeste();
            consultar.ListarVarejistas(cboVarejista);
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if(cboVarejista.Text.Length == 0)
            {
                MessageBox.Show("INFORME O VAREJISTA.");
            }
            else
            {
                //======limpa o grid 
                dgvConsulta.Rows.Clear();
                txtChave.Text = "";
                txtNota.Text = "";
                txtSerie.Text = "";
                btnEntrada.Visible = false;



                lstRetorno.Items.Clear();
                textBox1.Text = "";
                OpenFileDialog vAbreArq = new OpenFileDialog();
                vAbreArq.Filter = "XML |*.XML";
                vAbreArq.Title = "Selecione o Arquivo";
                if (vAbreArq.ShowDialog() == DialogResult.OK)
                {
                    //MessageBox.Show("igual =" + vAbreArq.FileName);
                    string pasta = vAbreArq.FileName;
                    //txtEndereco.Text = pasta;

                    LerXML(pasta, 0, "XML");
                }
            }
           

            /*
            lstRetorno.Items.Clear();
            textBox1.Text = "";
            FolderBrowserDialog dirDialog = new FolderBrowserDialog();
            DialogResult res = dirDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                // Como o utilizador carregou no OK, o directorio escolhido pode ser acedido da seguinte forma:
                string directorio = dirDialog.SelectedPath;
                string[] arquivos = Directory.GetFiles(directorio, "*.xml", SearchOption.AllDirectories);
                int Cont = 1;
                foreach (string arq in arquivos)
                {
                    Cont = Cont + 1;
                    FileInfo infoArquivo = new FileInfo(arq);
                    string nome = infoArquivo.Name;
                    // MessageBox.Show(nome);
                    //trata o nome
                    if (nome.Contains("."))
                    {
                        int indiceDoPonto = nome.IndexOf(".");
                        string primeiraParte = nome.Substring(0, (indiceDoPonto));
                        nome = primeiraParte;
                    }
                    //============
                    //  MessageBox.Show(nome);
                    lblStatus.Text = nome;
                    LerXML(arq, Cont, nome);
                }
                // finito     
                //  var folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //   string arquivo = folder;
                this.Cursor = Cursors.WaitCursor;
                lblStatus.Text = "AGUARDE. GERANDO O ARQUIVO EM EXCEL.";
                /*
                if (chbMagazine.Checked)
                {
                    inserirNoExcelFran();
                }
                else
                {
                    inserirNoExcel();
                }
                */
            /*
                lblStatus.Text = "FINALIZADO";
                this.Cursor = Cursors.Default;
            }
            */

        }

        public void LerXML(string NS, int Cont, string nome)
        {

            //  string sCaminhoDoArquivo = ("C:\\Users\\lbotan\\Desktop\\xml\\" + NS + ".xml");
            string sCaminhoDoArquivo = (NS);
            //MessageBox.Show(sCaminhoDoArquivo);

            if (System.IO.File.Exists(sCaminhoDoArquivo))
            {
              //  string feedback = "";

                //============
                string CFOP = "";
                string BASEST = "";
                string VALORST = "";
                string BASEICMS = "";
                string VALORICMS = "";
                string IPI = "";
                string PIS = "";
                string COFINS = "";
                string CNPJORIGEM = "";
                string ENDEREÇOORIGEM = "";
                string CEPORIGEM = "";
                string BAIRROORIGEM = "";

                string RAZÃOSOCIALTRANSPORTADORA = "";
                string CNPJTRANSPORTADORA = "";
                string ENDEREÇOTRANSPORTADORA = "";
               // string CEPTRANSPORTADORA = "";
               // string DATAPREVISTADECOLETA = "";

                string CHAVEACESSO = "";
                string PROTOCOLOSEFAZ = "";

                string AliqICMS = "";

                //=============


                string Emissor = "";
                string RazaoSocial = "";
                string Nota = "";
                string DataEmissao = "";
                string Valor = "";
                string Volume = "";
                string PesoL = "";
                string PesoB = "";
                // string Quantidade = "";
                DateTime DataEmissaoDT;
                string NFDevolucao = "";
                string Serie = "";

                string Codigo = "";
                string Descricao = "";
                string Quant = "";

                string CodigoEDescricaoQnt = "";
                string Quantidade = "";
                string ValorUnintario = "";
                string Valor_Uni = "";
                string NCM_PROD = "";

                string CNPJ = "";

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(sCaminhoDoArquivo); //Carregando o arquivo
                //Pegando elemento pelo nome da TAG


                //cnpj emissor
                XmlNodeList emit = xmlDoc.GetElementsByTagName("emit");
                for (int i = 0; i < emit.Count; i++)
                {
                    CNPJORIGEM = emit[i]["CNPJ"].InnerText;
                    Emissor = emit[i]["xNome"].InnerText;
                }


                XmlNodeList enderEmit = xmlDoc.GetElementsByTagName("enderEmit");
                for (int i = 0; i < enderEmit.Count; i++)
                {
                    ENDEREÇOORIGEM = enderEmit[i]["xLgr"].InnerText + " " + enderEmit[i]["nro"].InnerText;
                    CEPORIGEM = enderEmit[i]["CEP"].InnerText;
                    BAIRROORIGEM = enderEmit[i]["xBairro"].InnerText;
                }


                //Numero da nota fiscal
                XmlNodeList total = xmlDoc.GetElementsByTagName("ICMSTot");
                for (int i = 0; i < total.Count; i++)
                {
                    BASEST = total[i]["vBCST"].InnerText;
                    VALORST = total[i]["vST"].InnerText;
                    BASEICMS = total[i]["vBC"].InnerText;
                    VALORICMS = total[i]["vICMS"].InnerText;
                    IPI = total[i]["vIPI"].InnerText;
                    PIS = total[i]["vPIS"].InnerText;
                    COFINS = total[i]["vCOFINS"].InnerText;

                }

                //Numero CFOP
                XmlNodeList prod = xmlDoc.GetElementsByTagName("prod");
                for (int i = 0; i < prod.Count; i++)
                {
                    //RazaoSocial = dest[i]["xNome"].InnerText;
                    CFOP = prod[i]["CFOP"].InnerText;
                }


                //ICMS
                string ICMS = "ICMS";
                for (int i = 0; i < 100; i = i + 10)
                {
                    ICMS = ICMS + i;
                    if (ICMS == "ICMS0")
                    {
                        ICMS = "ICMS00";
                    }
                    else
                    {
                        ICMS = "ICMS" + i;
                    }

                    XmlNodeList teste = xmlDoc.GetElementsByTagName(ICMS);
                    for (int x = 0; x < teste.Count; x++)
                    {
                        try
                        {
                            //RazaoSocial = dest[i]["xNome"].InnerText;
                            AliqICMS = teste[x]["pICMS"].InnerText;
                            break;
                        }
                        catch (Exception)
                        {
                        }
                    }

                }


                /*
                
                XmlNodeList ICMS2 = xmlDoc.GetElementsByTagName("ICMS10");
                for (int i = 0; i < ICMS2.Count; i++)
                {
                    try
                    {
                        //RazaoSocial = dest[i]["xNome"].InnerText;
                        AliqICMS = ICMS2[i]["pICMS"].InnerText;
                    }
                    catch (Exception x)
                    {
                    }
                }

                XmlNodeList ICMS3 = xmlDoc.GetElementsByTagName("ICMS70");
                for (int i = 0; i < ICMS3.Count; i++)
                {
                    try
                    {
                        //RazaoSocial = dest[i]["xNome"].InnerText;
                        AliqICMS = ICMS3[i]["pICMS"].InnerText;
                    }
                    catch (Exception x)
                    {
                    }
                }

                XmlNodeList ICMS4 = xmlDoc.GetElementsByTagName("ICMS40");
                for (int i = 0; i < ICMS4.Count; i++)
                {
                    try
                    {
                        //RazaoSocial = dest[i]["xNome"].InnerText;
                        AliqICMS = ICMS4[i]["pICMS"].InnerText;
                    }
                    catch (Exception x)
                    {
                    }
                }
                      
               //=-========================== fim ICMS          

                 */



                //ICMS
                XmlNodeList ide = xmlDoc.GetElementsByTagName("ide");
                for (int i = 0; i < ide.Count; i++)
                {
                    Nota = ide[i]["nNF"].InnerText;
                    Serie = ide[i]["serie"].InnerText;
                    DataEmissao = ide[i]["dhEmi"].InnerText;
                    try
                    {
                        DataEmissao = DataEmissao.Substring(0, 10);
                        DataEmissaoDT = Convert.ToDateTime(DataEmissao);
                        // DataEmissao = DataEmissaoDT.ToString();
                    }
                    catch (Exception)
                    {

                    }
                }


                //dados da transportadora

                XmlNodeList transporta = xmlDoc.GetElementsByTagName("transporta");
                for (int i = 0; i < transporta.Count; i++)
                {
                    try
                    {
                        RAZÃOSOCIALTRANSPORTADORA = transporta[i]["xNome"].InnerText;
                        CNPJTRANSPORTADORA = transporta[i]["CNPJ"].InnerText;
                        ENDEREÇOTRANSPORTADORA = transporta[i]["xEnder"].InnerText;
                        //CEPTRANSPORTADORA = "";//transporta[i]["CNPJ"].InnerText; ;
                        // DATAPREVISTADECOLETA = transporta[i]["CNPJ"].InnerText;


                    }
                    catch (Exception)
                    {
                        //MessageBox.Show(x.Message);
                    }
                }


                XmlNodeList refNF = xmlDoc.GetElementsByTagName("refNF");
                for (int i = 0; i < refNF.Count; i++)
                {
                    try
                    {
                        CNPJ = refNF[i]["CNPJ"].InnerText;
                        NFDevolucao = refNF[i]["nNF"].InnerText;
                        NFDevolucao = NFDevolucao.PadLeft(9, '0');
                    }
                    catch (Exception)
                    {
                        //MessageBox.Show(x.Message);
                    }
                }


                XmlNodeList dest = xmlDoc.GetElementsByTagName("enderDest");
                for (int i = 0; i < dest.Count; i++)
                {
                    //RazaoSocial = dest[i]["xNome"].InnerText;
                    RazaoSocial = dest[i]["xMun"].InnerText;
                }

                XmlNodeList NFref = xmlDoc.GetElementsByTagName("NFref");
                for (int i = 0; i < NFref.Count; i++)
                {
                    try
                    {
                        NFDevolucao = NFref[i]["refNFe"].InnerText;
                        NFDevolucao = NFDevolucao.Substring(27, 7);
                        NFDevolucao = NFDevolucao.PadLeft(9, '0');
                    }
                    catch (Exception)
                    {
                        //MessageBox.Show(x.Message);
                    }
                }


                XmlNodeList infProt = xmlDoc.GetElementsByTagName("infProt");
                for (int i = 0; i < dest.Count; i++)
                {
                    CHAVEACESSO = infProt[i]["chNFe"].InnerText;
                    PROTOCOLOSEFAZ = infProt[i]["nProt"].InnerText;
                }


                XmlNodeList vol = xmlDoc.GetElementsByTagName("vol");
                for (int i = 0; i < vol.Count; i++)
                {
                    try
                    {
                        Volume = vol[i]["qVol"].InnerText;

                        PesoL = vol[i]["pesoL"].InnerText;
                        PesoB = vol[i]["pesoB"].InnerText;
                    }
                    catch (Exception)
                    {
                        //MessageBox.Show(x.Message);
                    }

                }

                XmlNodeList ICMSTot = xmlDoc.GetElementsByTagName("ICMSTot");
                for (int i = 0; i < ICMSTot.Count; i++)
                {
                    Valor = ICMSTot[i]["vNF"].InnerText;
                }



                // SETA A A CHAVE A NOTA E A SERIE
                txtChave.Text = CHAVEACESSO.Trim();
                txtNota.Text = Nota.Trim();
                txtSerie.Text = Serie.Trim();


                // AKI COMEÇA A LEITURA DOS PRODUTOS 

                double qnt = 0;

                XmlNodeList det = xmlDoc.GetElementsByTagName("prod");
                for (int i = 0; i < det.Count; i++)
                {
                    Quantidade = det[i]["qCom"].InnerText;
                    Codigo = det[i]["cProd"].InnerText;
                    //TRATA O CODIGO, PQ A VIA VAREOS MANDA O CODIGO COM 001-CODVAREJO, PRECISA TIRAR O 001-
                    if (Codigo.Contains("-") && (cboVarejista.Text == "VIAVAREJO" || cboVarejista.Text == "CNOVA" || cboVarejista.Text == "MULTIVAREJO"))
                    {
                        int indiceDoPonto = Codigo.IndexOf("-");
                        string resto = Codigo.Substring(indiceDoPonto + 1);
                        Codigo = resto.TrimStart('0');
                    }
                    Descricao = det[i]["xProd"].InnerText;
                    Quant = det[i]["qCom"].InnerText;
                    ValorUnintario = det[i]["vUnCom"].InnerText;
                    NCM_PROD = det[i]["NCM"].InnerText;

                    

                    Valor_Uni = det[i]["vUnCom"].InnerText;
                    try
                    {
                        Valor_Uni = Valor_Uni.TrimEnd('0');
                    }
                    catch(Exception)
                    {

                    }
                 //   if (chbMagazine.Checked)
                  //  {
                        //feedback = "'" + CHAVEACESSO + ";" + Emissor + ";" + RazaoSocial + ";" + Nota + "-" + Serie + ";" + Volume + ";" + ValorUnintario + ";" + Quant + ";" + DataEmissao + ";" + NFDevolucao + ";" + "'" + PROTOCOLOSEFAZ + ";" + Codigo + ";" + Descricao + ";" + "'" + CNPJORIGEM + ";";
                      //  feedback = CHAVEACESSO + "\r" + Nota + "\r" + Serie + "\r" + Codigo + "\r" + Quantidade + "\n";
                      //  lstRetorno.Items.Add(feedback);
                      //  textBox1.Text += feedback + "\r\n";
                  //  }
                    if (Quantidade.Contains("."))
                    {
                        int indiceDoPonto = Quantidade.IndexOf(".");
                        string primeiraParte = Quantidade.Substring(0, (indiceDoPonto + 0));
                        qnt = qnt + Convert.ToDouble(primeiraParte);

                        //recebe o codigo a descrição e a qnt para o codigo
                        if (CodigoEDescricaoQnt.Length == 0)
                        {
                            CodigoEDescricaoQnt += det[i]["cProd"].InnerText + " - ";
                            CodigoEDescricaoQnt += det[i]["xProd"].InnerText + " (" + primeiraParte + ")";
                            ValorUnintario = det[i]["vUnCom"].InnerText;
                            Quantidade = primeiraParte;

                        }
                        else
                        {
                            CodigoEDescricaoQnt += " | " + det[i]["cProd"].InnerText + " - ";
                            CodigoEDescricaoQnt += det[i]["xProd"].InnerText + " (" + primeiraParte + ")";
                            ValorUnintario = det[i]["vUnCom"].InnerText;
                            Quantidade = primeiraParte;
                        }
                    }
                    else
                    {
                        qnt = qnt + Convert.ToDouble(Quantidade);

                        //recebe o codigo a descrição e a qnt para o codigo
                        if (CodigoEDescricaoQnt.Length == 0)
                        {
                            CodigoEDescricaoQnt += det[i]["cProd"].InnerText + " - ";
                            CodigoEDescricaoQnt += det[i]["xProd"].InnerText + " (" + Quantidade + ")";
                            ValorUnintario = det[i]["vUnCom"].InnerText;
                            Quantidade = Quantidade.Trim();
                        }
                        else
                        {
                            CodigoEDescricaoQnt += " | " + det[i]["cProd"].InnerText + " - ";
                            CodigoEDescricaoQnt += det[i]["xProd"].InnerText + " (" + Quantidade + ")";
                            ValorUnintario = det[i]["vUnCom"].InnerText;
                            Quantidade = Quantidade.Trim();
                        }
                    }

                    string Data= Convert.ToDateTime(DataEmissao).ToString("dd/MM/yyyy");

                    //string Data = DataEmissaoDT.ToString("dd/MM/yyyy");
                    dgvConsulta.Rows.Add(CHAVEACESSO, Data, Nota, Serie, Codigo, Quantidade, Valor_Uni, NCM_PROD, Descricao);

                    //MessageBox.Show(CHAVEACESSO + "\r" + Nota + "\r" + Serie + "\r" + Codigo + "\r" + Quantidade);
                }

               
               // textBox1.Text += CHAVEACESSO + "\r" + Nota + "\r" + Serie + "\r" + Codigo + "\r" + Quantidade + "\n";

            }

            //desmarkar aki
            
            consultar.comando = "";
            consultar.comando = "select NotaFiscal as Quantidade from NotaFiscal where NotaFiscal = '" + txtNota.Text + "' and Varejista = '" + cboVarejista.Text + "' and CT = '" + lblCT.Text + "'";
            consultar.consultarSimNao();
            if (consultar.Retorno == "ok" || Convert.ToInt32(consultar.qntNaPosicao) > 0)
            {
                MessageBox.Show("NOTA FISCAL JÁ CADASTRADA.");
            }
            else
            {
                btnEntrada.Visible = true;
            }

        }


        public void FormatarGridTeste()
        {
            dgvConsulta.Rows.Clear();
            dgvConsulta.ColumnCount = 9;
            dgvConsulta.Columns[0].Name = "CHAVEACESSO";
            dgvConsulta.Columns[1].Name = "DATAEMISSAO";
            dgvConsulta.Columns[2].Name = "NOTA";
            dgvConsulta.Columns[3].Name = "SERIE";
            dgvConsulta.Columns[4].Name = "CODIGO";
            dgvConsulta.Columns[5].Name = "QUANTIDADE";
            dgvConsulta.Columns[6].Name = "VALOR_UNI";
            dgvConsulta.Columns[7].Name = "NCM";
            dgvConsulta.Columns[8].Name = "DESCRICAO";
           // dgvConsulta.Columns[6].Name = "PROTOCOLO";

            dgvConsulta.RowHeadersVisible = false;
            //dgvConsulta.Columns[0].Visible = false;
            //dgvConsulta.Columns[1].Width = 80;
            //dgvConsultaa.Columns[2].Width = 80;
            //  dgvConsulta.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvConsulta.AutoResizeColumns();
            //dgvConsulta.ScrollBars = ScrollBars.Vertical;
            //dgvConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both;  
        }


        public void inserirNotaFiscal(string NF, string Serie, string Chave, string Data, string Valor_uni, string NCM, string QntPorCodigo, string Codigo, string Varejista, string Descricao, out string Feed)
        {           
            string sql = "";         
            try
            {
                sql += " Insert into NotaFiscal (NotaFiscal, Serie, Chave, Data, Valor_uni, NCM, QntProdutos, QntRestanteEnt, CodVarejo, QntRestante, Varejista, Descricao, CT)";
                sql += " Values ( ";
                sql += " '" + NF + "', ";
                sql += " '" + Serie + "', ";
                sql += " '" + Chave + "', ";              
                sql += " '" + Data + "',";
                sql += " '" + Valor_uni + "',";
                sql += " '" + NCM + "',";
                sql += " '" + QntPorCodigo + "', ";
                sql += " '" + QntPorCodigo + "', ";
                sql += " '" + Codigo + "', ";
                sql += " '" + QntPorCodigo + "', ";
                sql += " '" + Varejista + "', ";
                sql += " '" + Descricao + "', ";
                sql += " '" + lblCT.Text + "')";
                cx.Conectar();
                SqlCommand cd = new SqlCommand();
                cd.Connection = cx.c;
                cd.CommandText = sql;
                cd.ExecuteNonQuery();
                cx.Desconectar();
                Feed = "";
            }
            catch (SqlException x)
            {
                MessageBox.Show("ERRO INSERIR NOTA FISCAL: \n" + x.Message);
                Feed = "Falha";
            }
            cx.Desconectar();
        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            string feed = "";
            for (int i = 0; i < dgvConsulta.RowCount; i++)
            {
                string NotaFiscal = dgvConsulta.Rows[i].Cells["NOTA"].Value.ToString();
                string Serie = dgvConsulta.Rows[i].Cells["SERIE"].Value.ToString();
                string Chave = dgvConsulta.Rows[i].Cells["CHAVEACESSO"].Value.ToString();
                string DataEmissao = dgvConsulta.Rows[i].Cells["DATAEMISSAO"].Value.ToString();
                string QntProdutos = dgvConsulta.Rows[i].Cells["QUANTIDADE"].Value.ToString();
                string CodVarejo = dgvConsulta.Rows[i].Cells["CODIGO"].Value.ToString();
                string Valor_uni = dgvConsulta.Rows[i].Cells["VALOR_UNI"].Value.ToString();
                string NCM = dgvConsulta.Rows[i].Cells["NCM"].Value.ToString();
                string Descricao = dgvConsulta.Rows[i].Cells["DESCRICAO"].Value.ToString();

                inserirNotaFiscal(NotaFiscal, Serie, Chave, DataEmissao, Valor_uni, NCM, QntProdutos, CodVarejo, cboVarejista.Text, Descricao, out feed);
            }
            if (feed == "")
            {
                MessageBox.Show("NOTA " + txtNota.Text + " INSERIDA COM SUCESSO!");
                dgvConsulta.Rows.Clear();
                txtChave.Text = "";
                txtNota.Text = "";
                txtSerie.Text = "";
                //cboVarejista.Text = "";
                btnEntrada.Visible = false;
            }          
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DESEJA LIMPAR A TELA?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dgvConsulta.Rows.Clear();
                    txtChave.Text = "";
                    txtNota.Text = "";
                    txtSerie.Text = "";
                    btnEntrada.Visible = false;
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //LerXML();
        }
        






    
    }
}
