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
using System.Xml;

namespace CRMagazine
{
    public partial class frmEstoqueNovaEntrada : Form
    {
        public frmEstoqueNovaEntrada(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consultar = new Consulta();


        private void frmEstoqueNovaEntrada_Load(object sender, EventArgs e)
        {
            FormatarGridTeste();
        }

        public void FormatarGrid()
        {
            dgvConsulta.RowHeadersVisible = false;
            dgvConsulta.Columns["DESCRIÇÃO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }



        public void ListarTudo()
        {
            /*
            string sql = "";
            sql += "select convert(numeric,[codpeçaenviada]) as Código, [descpeçaenviada] as Descrição, ";
            sql += "chamadopedido as Chamado, sum(qtdpeçaenviada) as Quantidade, ";
            sql += "'' as Status ";
            sql += "from tb_rel_consolidacao_fiscal ";
            sql += "where ";
            sql += "centrodetrabalho = '2791003' and notafiscal = '" + txtNota.Text + "' ";
            sql += "group by [codpeçaenviada], [descpeçaenviada], chamadopedido ";
            cx.ConectarAssist();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            da.SelectCommand.CommandTimeout = 120;
            DataSet ds = new DataSet();
            da.Fill(ds, "Assist_REL");
            dgvConsulta.DataSource = ds.Tables["Assist_REL"];
            cx.Desconectar();
             */
            lblTotal.Text = dgvConsulta.Rows.Count.ToString();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtNota.Text.Length == 0)//|| txtPreco.Text.Length == 0)
            {
                MessageBox.Show("PREENCHA O CAMPO NOTA");
            }
            else
            {
                consultar.comando = "";
                consultar.comando += "select count(*) as Quantidade from EntradaNotas where Nota = '" + txtNota.Text + "' and CT = '" + lblCT.Text + "'";
                consultar.consultarSimNao();
                if (consultar.Retorno == "falha" || consultar.qntNaPosicao == "0")
                {
                    btnEntrada.Visible = false;
                    ListarTudo();
                    FormatarGrid();
                    //VerificarEstoque();
                }
                else
                {
                    MessageBox.Show("NOTA JÁ RECEBIDA");
                }
            }   
        }

        public void ConsultarNoEstoque()
        {
            if (txtNota.Text.Length == 0)//|| txtPreco.Text.Length == 0)
            {
                MessageBox.Show("PREENCHA O CAMPO NOTA");
            }
            else
            {
                consultar.comando = "";
               // consultar.comando += "select count(*) as Quantidade from EntradaNotas where Nota = '" + txtNota.Text + "'";
                consultar.comando += "select count(*) as Quantidade from EntradaNotas where Chave = '" + txtChave.Text + "' and CT = '" + lblCT.Text + "'";
                consultar.consultarSimNao();
                if (consultar.Retorno == "falha" || consultar.qntNaPosicao == "0")
                {
                    btnEntrada.Visible = false;
                    ListarTudo();
                    FormatarGrid();
                    //VerificarEstoque();
                    btnEntrada.Visible = true;
                }
                else
                {
                    MessageBox.Show("NOTA JÁ RECEBIDA");
                }
            }   
        }

        public void VerificarEstoque()
        {
            string verificacao = "";
            for (int i = 0; i < dgvConsulta.RowCount; i++)
            {
                string Cod = dgvConsulta.Rows[i].Cells["Código"].Value.ToString();
                consultar.Codigo = Cod;
                consultar.consultarEstoque(lblCT.Text);
                if (consultar.Retorno == "ok")
                {
                    dgvConsulta.Rows[i].Cells["Status"].Value = "OK";



                }
                else
                {
                    dgvConsulta.Rows[i].Cells["Status"].Value = "NÃO";
                    verificacao = "Nao";
                }
            }
            if (verificacao != "Nao")
            {
                btnEntrada.Visible = true;
            }
        }

        

        private void dgvConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvConsulta.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "NÃO")
                {
                    panel3.Visible = true;
                    txtCodigo.Text = dgvConsulta.Rows[e.RowIndex].Cells["Código"].Value.ToString();
                    txtDescricao.Text = dgvConsulta.Rows[e.RowIndex].Cells["Descrição"].Value.ToString();
                }     
            }
            catch (Exception)
            {

            }
                   
        }

        public void CadastrarCodigo()//string Cod, string Descricao, string Tipo, string Barebone, string BareboneEquivalente)
        {
            try
            {
                string Cod = txtCodigo.Text;
                string Descricao = txtDescricao.Text;
                string Tipo = txtTipo.Text;
                string Barebone = txtBarebone.Text;
                string BareboneEquivalente = txtBareboneEquivalente.Text;
                string posicao = "REC";
                string Quantidade = "0";

                string sql = "";
                sql = "";
                sql += " Insert into Estoque (CT, Codigo, Barebone, Descricao, Quantidade, Posicao, Tipo, BareboneEquivalente)";
                sql += " Values ( ";
                sql += " '" + lblCT.Text + "', ";
                sql += " '" + Cod + "', ";
                sql += " '" + Barebone + "', ";
                sql += " '" + Descricao + "', ";
                sql += " '" + Quantidade + "', ";
                sql += " '" + posicao + "', ";
                sql += " '" + Tipo + "', ";
                sql += " '" + BareboneEquivalente + "')";
                //MessageBox.Show(sql);
                cx.Conectar();
                SqlCommand cd = new SqlCommand();
                cd.Connection = cx.c;
                cd.CommandText = sql;
                cd.ExecuteNonQuery();
                cx.Desconectar();                     
            }
            catch (SqlException x)
            {
                MessageBox.Show("ERRO AO CONCLUIR CADASTRO NO ESTOQUE: \r\n" + x.Message);
            }
            cx.Desconectar();
        }

        public void InsereEntradaNotas()
        {
            consultar.DataAtual();
            string data = consultar.dataNormal;
            string hora = consultar.hora;
            for (int i = 0; i < dgvConsulta.RowCount; i++)
            {
                string Cod = dgvConsulta.Rows[i].Cells["Código"].Value.ToString();
               // string Chamado = dgvConsulta.Rows[i].Cells["Chamado"].Value.ToString();
                string Quantidade = dgvConsulta.Rows[i].Cells["Quantidade"].Value.ToString();
                string Descricao = dgvConsulta.Rows[i].Cells["Descrição"].Value.ToString();
                string Preco = dgvConsulta.Rows[i].Cells["VALOR_UNI"].Value.ToString();
                //consultar.Codigo = Cod;
                //consultar.ConsultarCodigoSAP();                
                
                try
                {                    
                    string sql = "";
                    sql = "";
                    sql += " Insert into EntradaNotas (CT, Nota, Data, Hora, Codigo, Descricao, Quantidade, Chave, Preco)";
                    sql += " Values ( ";
                    sql += " '" + lblCT.Text + "', ";
                    sql += " '" + txtNota.Text + "', ";
                    sql += " '" + data + "', ";
                    sql += " '" + hora + "', ";
                    sql += " '" + Cod + "', ";
                    sql += " '" + Descricao + "', ";                    
                    sql += " '" + Quantidade + "', ";                    
                    sql += " '" + txtChave.Text  + "', ";
                    sql += " '" + Preco + "') ";
                   // MessageBox.Show(sql);                  
                    cx.Conectar();
                    SqlCommand cd = new SqlCommand();
                    cd.Connection = cx.c;
                    cd.CommandText = sql;
                    cd.ExecuteNonQuery();
                    cx.Desconectar();
                }
                catch (SqlException x)
                {
                    MessageBox.Show("ERRO AO INSERIR EM ENTRADANOTAS: \r\n" + x.Message);
                }
                cx.Desconectar();

            }
           
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CadastrarCodigo();
            ConsultarNoEstoque();
            panel3.Visible = false;
            txtCodigo.Text = "";
            txtDescricao.Text = "";
            txtTipo.Text = "";
            txtBarebone.Text = "";
            txtBareboneEquivalente.Text = "";
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {            
            for (int i = 0; i < dgvConsulta.RowCount; i++)
            {
                string Cod = dgvConsulta.Rows[i].Cells["Código"].Value.ToString();
                //string Chamado = dgvConsulta.Rows[i].Cells["Chamado"].Value.ToString();
                string Quantidade = dgvConsulta.Rows[i].Cells["Quantidade"].Value.ToString();
                string Descricao = dgvConsulta.Rows[i].Cells["Descrição"].Value.ToString();
                //MessageBox.Show("Chamado = '" + Chamado + "'");
                //if (Chamado == "0")
                //{
                //MessageBox.Show("sem chamado");
                    Concluir(Cod, Quantidade, Descricao);
                //}
               // else
               // {
                //MessageBox.Show("com chamado");
                //    ConcluirComChamado(Cod, Chamado, Quantidade, Descricao);
               // }
            }

            InsereEntradaNotas();

            btnEntrada.Visible = false;
          //  dgvConsulta.DataSource = null;
           // dgvConsulta.Rows.Clear();

            dgvConsulta.Rows.Clear();
            txtChave.Text = "";
            txtNota.Text = "";
            // txtSerie.Text = "";
            lblTotal.Text = "0";           
            txtPreco.Text = "";
            MessageBox.Show("PEÇAS INSERIDAS.");
           
        }

        public void Concluir(string Cod, string Quantidade, string Descricao)
        {
            string posicao = "REC";
            string qntNaPosicao = "";
            consultar.comando = "";
            consultar.comando += "Select * from Estoque where Codigo = '" + Cod + "' and Posicao = '" + posicao + "' and CT = '" + lblCT.Text + "'";
            consultar.consultarSimNao();
            if (consultar.Retorno == "ok")
            {
                qntNaPosicao = consultar.qntNaPosicao;
                int total = 0;
                total = Convert.ToInt32(qntNaPosicao) + Convert.ToInt32(Quantidade);
                consultar.comando = "";
                consultar.comando = "update Estoque set Quantidade = '" + total + "' where Posicao = '" + posicao + "' and Codigo = '" + Cod + "' and CT = '" + lblCT.Text + "'";
               // MessageBox.Show(consultar.comando);

                consultar.Atualizar();
            }
            else
            {
                string sql = "";
                // consultar.comando = "";
                //consultar.comando += "Select * from Estoque where Codigo = '" + Cod + "' and CT = '" + lblCT.Text + "'";
                consultar.Codigo = Cod;
                consultar.consultarEstoque(lblCT.Text);
                string Barebone = consultar.Barebone;
              //  string Descricao = consultar.Descricao;
                string Tipo = consultar.Tipo;
                string BareboneEquivalente = consultar.BareboneEquivalente;
                try
                {
                    sql = "";
                    sql += " Insert into Estoque (CT, Codigo, Barebone, Descricao, Quantidade, Posicao, Tipo, BareboneEquivalente)";
                    sql += " Values ( ";
                    sql += " '" + lblCT.Text + "', ";
                    sql += " '" + Cod + "', ";
                    sql += " '" + Barebone + "', ";
                    sql += " '" + Descricao + "', ";
                    sql += " '" + Quantidade + "', ";
                    sql += " '" + posicao + "', ";
                    sql += " '" + Tipo + "', ";
                    sql += " '" + BareboneEquivalente + "')";
                    //MessageBox.Show(sql);        

                    cx.Conectar();
                    SqlCommand cd = new SqlCommand();
                    cd.Connection = cx.c;
                    cd.CommandText = sql;
                    cd.ExecuteNonQuery();
                    cx.Desconectar();   

                }
                catch (SqlException x)
                {
                    MessageBox.Show("ERRO AO CONCLUIR ENTRADA DE ESTOQUE: \r\n" + x.Message);
                }
                cx.Desconectar();
            }            
       }

        public void ConcluirComChamado(string Cod, string Chamado, string Quantidade, string Descricao)
        {
            consultar.ConsultarChamado = Chamado;
            consultar.ConsultarPeloChamado(lblCT.Text);
            // se esta em agurdo lança em pp
            if (consultar.Status == "PP")
            {
                //consultar.comando = "";
                // consultar.comando += "Select * from Estoque where Codigo = '" + Cod + "' and CT = '" + lblCT.Text + "'";
                consultar.Codigo = Cod;
                consultar.consultarEstoque(lblCT.Text);
                string Barebone = consultar.Barebone;
                //string Descricao = consultar.Descricao;
                string Tipo = consultar.Tipo;
                string BareboneEquivalente = consultar.BareboneEquivalente;
                string sql = "";
                string posicao = "PP";
                try
                {
                    sql = "";
                    sql += " Insert into Estoque (CT, Codigo, Barebone, Descricao, Quantidade, Posicao, Chamado, Tipo, BareboneEquivalente)";
                    sql += " Values ( ";
                    sql += " '" + lblCT.Text + "', ";
                    sql += " '" + Cod + "', ";
                    sql += " '" + Barebone + "', ";
                    sql += " '" + Descricao + "', ";
                    sql += " '" + Quantidade + "', ";
                    sql += " '" + posicao + "', ";
                    sql += " '" + Chamado + "', ";
                    sql += " '" + Tipo + "', ";
                    sql += " '" + BareboneEquivalente + "')";
                    //MessageBox.Show(sql); 
                    cx.Conectar();
                    SqlCommand cd = new SqlCommand();
                    cd.Connection = cx.c;
                    cd.CommandText = sql;
                    cd.ExecuteNonQuery();
                    cx.Desconectar();                        
                }
                catch (SqlException x)
                {
                    MessageBox.Show("ERRO AO INSERIR ENTRADA DE ESTOQUE COM CHAMADO: \r\n" + x.Message);
                }                   


            }
            // senão lança normalmente
            else
            {              
                Concluir(Cod, Quantidade, Descricao);               
            }

            
        }

      

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            //======limpa o grid 
            dgvConsulta.Rows.Clear();
            txtChave.Text = "";
            txtNota.Text = "";
           // txtSerie.Text = "";
            btnEntrada.Visible = false;



           // lstRetorno.Items.Clear();
           // textBox1.Text = "";
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

            //btnConsultar.PerformClick();
            ConsultarNoEstoque();
        }


        public void LerXML(string NS, int Cont, string nome)
        {

            //  string sCaminhoDoArquivo = ("C:\\Users\\lbotan\\Desktop\\xml\\" + NS + ".xml");
            string sCaminhoDoArquivo = (NS);
            //MessageBox.Show(sCaminhoDoArquivo);

            if (System.IO.File.Exists(sCaminhoDoArquivo))
            {
               // string feedback = "";

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
                //string CEPTRANSPORTADORA = "";
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

               // string CNPJ = "";

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
                       // CEPTRANSPORTADORA = "";//transporta[i]["CNPJ"].InnerText; ;
                        // DATAPREVISTADECOLETA = transporta[i]["CNPJ"].InnerText;


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
               // txtSerie.Text = Serie.Trim();


                // AKI COMEÇA A LEITURA DOS PRODUTOS 

                double qnt = 0;

                XmlNodeList det = xmlDoc.GetElementsByTagName("prod");
                for (int i = 0; i < det.Count; i++)
                {
                    Quantidade = det[i]["qCom"].InnerText;
                    Codigo = det[i]["cProd"].InnerText;
                    //TRATA O CODIGO, PQ A VIA VAREOS MANDA O CODIGO COM 001-CODVAREJO, PRECISA TIRAR O 001-
                    //if (Codigo.Contains("-") && (cboVarejista.Text == "VIAVAREJO" || cboVarejista.Text == "CNOVA" || cboVarejista.Text == "MULTIVAREJO"))
                    //{
                    //    int indiceDoPonto = Codigo.IndexOf("-");
                    //    string resto = Codigo.Substring(indiceDoPonto + 1);
                    //    Codigo = resto.TrimStart('0');
                    //}
                    Descricao = det[i]["xProd"].InnerText;
                    Quant = det[i]["qCom"].InnerText;
                    ValorUnintario = det[i]["vUnCom"].InnerText;
                    NCM_PROD = det[i]["NCM"].InnerText;



                    Valor_Uni = det[i]["vUnCom"].InnerText;
                    try
                    {
                        Valor_Uni = Valor_Uni.TrimEnd('0');
                    }
                    catch (Exception)
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

                    string Data = Convert.ToDateTime(DataEmissao).ToString("dd/MM/yyyy");

                    //string Data = DataEmissaoDT.ToString("dd/MM/yyyy");
                    dgvConsulta.Rows.Add(Nota, Serie, Codigo, Descricao, Quantidade, Valor_Uni);

                    //MessageBox.Show(CHAVEACESSO + "\r" + Nota + "\r" + Serie + "\r" + Codigo + "\r" + Quantidade);
                }


                // textBox1.Text += CHAVEACESSO + "\r" + Nota + "\r" + Serie + "\r" + Codigo + "\r" + Quantidade + "\n";

            }

            //desmarkar aki


            // DESMARCAR PARA FUCIONAR A VERIFICAÇAÕ
            /*
            consultar.comando = "";
            consultar.comando += "select count(*) as Quantidade from EntradaNotas where Nota = '" + txtNota.Text + "'";
            consultar.consultarSimNao();
            if (consultar.Retorno == "falha" || consultar.qntNaPosicao == "0")
            {
                // btnEntrada.Visible = false;
                //ListarTudo();
               // FormatarGrid();
               // VerificarEstoque();

                btnEntrada.Visible = true;

            }
            else
            {
                btnEntrada.Visible = false;
                MessageBox.Show("NOTA JÁ RECEBIDA");
            } 
             */ 
             


        }

        public void FormatarGridTeste()
        {
            dgvConsulta.Rows.Clear();
            dgvConsulta.ColumnCount = 7;
           
            
            dgvConsulta.Columns[0].Name = "NOTA";
            dgvConsulta.Columns[1].Name = "SERIE";
            dgvConsulta.Columns[2].Name = "CÓDIGO";
            dgvConsulta.Columns[3].Name = "DESCRIÇÃO";
            dgvConsulta.Columns[4].Name = "QUANTIDADE";
            dgvConsulta.Columns[5].Name = "VALOR_UNI";
            dgvConsulta.Columns[6].Name = "STATUS";
            //dgvConsulta.Columns[7].Name = "NCM";
            
           // dgvConsulta.Columns[0].Name = "CHAVEACESSO";
            //dgvConsulta.Columns[1].Name = "DATAEMISSAO";
            // dgvConsulta.Columns[6].Name = "PROTOCOLO";

            //   dgvConsulta.Rows.Add(Nota, Serie, Codigo, Descricao, Quantidade, Valor_Uni);


            dgvConsulta.RowHeadersVisible = false;
            //dgvConsulta.Columns[0].Visible = false;
            //dgvConsulta.Columns[1].Width = 80;
            //dgvConsultaa.Columns[2].Width = 80;
            //  dgvConsulta.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvConsulta.AutoResizeColumns();
            //dgvConsulta.ScrollBars = ScrollBars.Vertical;
            //dgvConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both;  
        }





    }
}
