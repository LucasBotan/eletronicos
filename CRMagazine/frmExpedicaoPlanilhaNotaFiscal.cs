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
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Data.OleDb;

namespace CRMagazine
{
    public partial class frmExpedicaoPlanilhaNotaFiscal : Form
    {
        public frmExpedicaoPlanilhaNotaFiscal(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        //BLOCO PARA FUNCIONAR O EXCEL
       // Microsoft.Office.Interop.Excel.Application xlexcel;
       // Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
       // Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
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

        Conexao cx = new Conexao();
        Conexao cx2 = new Conexao();     
        Consulta consultar = new Consulta();

        private void frmExpedicaoPlanilhaNotaFiscal_Load(object sender, EventArgs e)
        {
            ListarTudo();
            FormatarGrid();
        }

        public void FormatarGrid()
        {
            /*
            // dgvParaAbrir.Columns[0].Visible = false;
            dgvParaLançarNF.RowHeadersVisible = false;
            // dgvConsulta.Columns[1].Width = 60;
            dgvParaLançarNF.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvParaLançarNF.ScrollBars = System.Windows.Forms.ScrollBars.Both;
             */ 

            // dgvParaAbrir.Columns[0].Visible = false;
            dgvConsultaNotas.RowHeadersVisible = false;
            dgvConsultaNotas.AutoResizeColumns();
            // dgvConsulta.Columns[1].Width = 60;
           // dgvConsultaNotas.Columns["NotaFiscal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
          //  dgvConsultaNotas.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        }


        

        public void ListarTudo()
        {
          
            string sql = "";

            //sql = "select DISTINCT NotaFiscal, Classificacao, count(Classificacao) as QNT from Chamados where Status = 'FINALIZADO' and NotaFiscal != '' and NotaFiscalSaida = 'PENDENTE' group by NotaFiscal, Classificacao ORDER BY NotaFiscal";


            sql = "select DISTINCT NotaFiscal, ";
            sql += "case when Classificacao in ('GARANTIA', 'ORCAMENTO') then 'NOVO' ELSE Classificacao END AS Classificacao,  ";
            sql += "count(case wheN Classificacao in ('GARANTIA', 'ORCAMENTO') then 'NOVO' ELSE Classificacao END) as QNT, VAREJISTA ";
            sql += "from Chamados where Status = 'FINALIZADO' and NotaFiscal != '' and NotaFiscalSaida = 'PENDENTE' and CT = '" + lblCT.Text + "' ";
            sql += "group by NotaFiscal, case wheN Classificacao in ('GARANTIA', 'ORCAMENTO') then 'NOVO' ELSE Classificacao END, VAREJISTA ";
            sql += "ORDER BY NotaFiscal ";

            /*
            sql = "select M.NotaFiscal, COUNT(M.NotaFiscal) AS QNT_EXP, T2.Total AS TOTAL, DATEDIFF(day,convert(date, T2.Data,103), getdate()) as DNP ";
            sql += "from Chamados M, (SELECT sum(convert(numeric, QntProdutos)) as Total, NotaFiscal, Data from NotaFiscal GROUP BY NotaFiscal, Data) T2 ";
            sql += "where M.NotaFiscal = T2.NotaFiscal AND Status = 'FINALIZADO' and M.NotaFiscalSaida = 'PENDENTE' GROUP BY M.NotaFiscal,  T2.Total, T2.Data ORDER BY M.NotaFiscal ";
            */ 

         //   sql += "SELECT sum(convert(numeric,QntProdutos)) as Quantidade, NotaFiscal from NotaFiscal where NotaFiscal = 'M.NotaFiscal'"
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chamados");
            dgvConsultaNotas.DataSource = ds.Tables["Chamados"];
            cx.Desconectar();
            lblTotal.Text = dgvConsultaNotas.Rows.Count.ToString();
            //listar datas
            FormatarGrid();

            // LISTAR NOTAS DISPONIVEIS VS NOTA TOTAL
            // sql = "select M.NotaFiscal, COUNT(M.NotaFiscal) AS QNT_EXP, N.QntProdutos AS TOTAL from MaquinasNoPosto M, NotaFiscal N where N.NotaFiscal = M.NotaFiscal AND Status = 'EXPEDICAO' and M.NotaFiscal != '' GROUP BY M.NotaFiscal, N.QntProdutos ORDER BY M.NotaFiscal ";


            /*
            if (deonde == "")
            {
                sql = "select DISTINCT NotaFiscal, Classificacao, count(Classificacao) as QNT from Chamados where Status = 'FINALIZADO' and NotaFiscal" + NF + " group by NotaFiscal, Classificacao ORDER BY NotaFiscal";
           
                cx.Conectar();
                SqlDataAdapter da2 = new SqlDataAdapter(sql, cx.c);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2, "Chamados");
                dgvParaLançarNF.DataSource = ds2.Tables["Chamados"];
                cx.Desconectar();

                for (int i = 0; i < dgvParaLançarNF.RowCount; i++)
                {
                    string QNT_EXP = dgvParaLançarNF.Rows[i].Cells["QNT_EXP"].Value.ToString();
                    string TOTAL = dgvParaLançarNF.Rows[i].Cells["TOTAL"].Value.ToString();

                    if (QNT_EXP == TOTAL)
                    {
                        dgvParaLançarNF.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                    }
                }
            }
             */ 
        
        }

        public void ListarTudoPorFora()
        {
            string sql = "";
            sql += "select DISTINCT ";
            sql += " NotaFiscal ";
            sql += ", Classificacao ";
            sql += ", sum(convert(numeric,QNT)) as QNT ";
            sql += ", VAREJISTA ";
            sql += " from NOTAPORFORA where Status = 'PENDENTE' and CT = '" + lblCT.Text + "'";
            sql += " group by NotaFiscal, Classificacao, VAREJISTA ";
            sql += " ORDER BY NotaFiscal ";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chamados");
            dgvConsultaNotas.DataSource = ds.Tables["Chamados"];
            cx.Desconectar();
            lblTotal.Text = dgvConsultaNotas.Rows.Count.ToString();
            //listar datas
            FormatarGrid();
        }


        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if(chbPorFora.Checked)
            {
                ListarTudoPorFora();
            }
            else
            {
                ListarTudo();
            }
        }


        public void ConsultarItens(string NF, string Classi)
        {
            txtNS.Text = "";
            if (txtOrcamento.Text == "NOVO")
            {

            }
            string sql = "";
            //sql = "select NotaFiscal, Classificacao, CodVarejo, Descricao, count(NotaFiscal) as QNT from Chamados ";
           // sql += " where Status = 'FINALIZADO' and NotaFiscal = '" + NF + "' and Classificacao = '" + Classi + "' group by NotaFiscal, Classificacao, Descricao, CodVarejo ";
            sql = "select C.NotaFiscal, ";
            sql += "case when Classificacao in ('GARANTIA', 'ORCAMENTO') then 'NOVO' ELSE Classificacao END AS Classificacao, C.CodVarejo, ";
            //sql += "C.Descricao, ";
            sql += "CASE WHEN (N.Descricao is null or N.Descricao = '') THEN 'NAO' ELSE 'OK' END AS OK,  ";
            sql += "CASE WHEN (N.Descricao is null or N.Descricao = '') THEN C.Descricao ELSE N.Descricao END AS Descricao,  ";
            sql += "COUNT(C.CodVarejo) as QNT, CONVERT(FLOAT,N.Valor_uni) AS Valor_uni, ";
           // sql += " COUNT(C.CodVarejo) * CONVERT(FLOAT,N.Valor_uni) AS	VALOR_TOTAL ,N.NCM from Chamados C, NotaFiscal N ";
            sql += "replace(COUNT(C.CodVarejo) * CONVERT(NUMERIC(10,2),N.Valor_uni), '.', ',') AS VALOR_TOTAL ,N.NCM from Chamados C, NotaFiscal N ";
            sql += " where C.NotaFiscal = N.NotaFiscal and C.CodVarejo = N.CodVarejo and NotaFiscalSaida = 'PENDENTE' and C.CT = '" + lblCT.Text + "'";
            sql += " AND Status = 'FINALIZADO' and C.NotaFiscal = '" + NF + "' and C.Varejista = '" + txtVarejista.Text + "' and ";
            if (txtOrcamento.Text == "NOVO")
            {
                sql += "Classificacao in ('ORCAMENTO', 'GARANTIA') ";
            }
            else
            {
                sql += "Classificacao = '" + Classi + "' ";
            }
            sql += "group by C.NotaFiscal, case when Classificacao in ('GARANTIA', 'ORCAMENTO') then 'NOVO' ELSE Classificacao END, N.Descricao, C.Descricao, C.CodVarejo, N.Valor_uni, N.NCM ";
            cx.Conectar();
            SqlDataAdapter da2 = new SqlDataAdapter(sql, cx.c);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "Chamados");
            dgvParaLançarNF.DataSource = ds2.Tables["Chamados"];
            cx.Desconectar();
            lblTotal.Text = dgvParaLançarNF.RowCount.ToString();
            dgvParaLançarNF.RowHeadersVisible = false;
            dgvConsultaNotas.AutoResizeColumns();
            try
            {                                
                sql = "select idChamados from Chamados where NotaFiscal = '" + NF + "' and NotaFiscalSaida = 'PENDENTE' and CT = '" + lblCT.Text + "' AND ";
                if (txtOrcamento.Text == "NOVO")
                {
                    sql += "Classificacao in ('ORCAMENTO', 'GARANTIA') ";
                }
                else
                {
                    sql += "Classificacao = '" + Classi + "' ";
                }
                cx.Conectar();
                SqlCommand cd = new SqlCommand();
                cd.Connection = cx.c;
                cd.CommandText = sql;
                SqlDataReader dr = cd.ExecuteReader();                
                while (dr.Read())
                {
                    txtNS.Text += dr["idChamados"].ToString().Trim() + "\r\n";                    
                }
                dr.Close();
            }
            catch (SqlException x)
            {
                MessageBox.Show("Falha em Contar idChamados: \n" + x.Message);
            }
            cx.Desconectar();
            txtNS.Text = txtNS.Text.Trim();
            txtNS.Text = txtNS.Text.Replace(" ", "");
        }

        public void ConsultarItensPorfora(string NF, string Classi)
        {
            txtNS.Text = "";
            if (txtOrcamento.Text == "NOVO")
            {

            }
            string sql = "";            
            sql = "select NotaFiscal ";
            sql += " , Classificacao, CodVarejo ";
            sql += " , CASE WHEN Descricao is null THEN 'NAO' ELSE 'OK' END AS OK ";
            sql += " , Descricao ";
            sql += " , sum(convert(numeric,QNT)) as QNT, CONVERT(FLOAT,Valor_uni) AS Valor_uni ";
            sql += " , replace(sum(convert(numeric,QNT)) * CONVERT(NUMERIC(10,2),Valor_uni), '.', ',') AS VALOR_TOTAL , NCM from NotaPorFora ";
            sql += " where Status = 'PENDENTE' and CT = '" + lblCT.Text + "' ";
            sql += " and NotaFiscal = '" + NF + "' and Varejista = '" + txtVarejista.Text + "' and Classificacao = '" + Classi + "' ";
            sql += " group by NotaFiscal, Classificacao, Descricao, Descricao, CodVarejo, Valor_uni, NCM ";
            cx.Conectar();
            SqlDataAdapter da2 = new SqlDataAdapter(sql, cx.c);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "Chamados");
            dgvParaLançarNF.DataSource = ds2.Tables["Chamados"];
            cx.Desconectar();
            lblTotal.Text = dgvParaLançarNF.RowCount.ToString();
            dgvParaLançarNF.RowHeadersVisible = false;
            dgvConsultaNotas.AutoResizeColumns();
            try
            {
                sql = "select idNotaPorFora from NotaPorFora where NotaFiscal = '" + NF + "' and Status = 'PENDENTE' and CT = '" + lblCT.Text + "' AND Classificacao = '" + Classi + "' ";
                cx.Conectar();
                SqlCommand cd = new SqlCommand();
                cd.Connection = cx.c;
                cd.CommandText = sql;
                SqlDataReader dr = cd.ExecuteReader();
                while (dr.Read())
                {
                    txtNS.Text += dr["idNotaPorFora"].ToString().Trim() + "\r\n";
                }
                dr.Close();
            }
            catch (SqlException x)
            {
                MessageBox.Show("Falha em Contar idNotaPorFora: \n" + x.Message);
            }
            cx.Desconectar();
            txtNS.Text = txtNS.Text.Trim();
            txtNS.Text = txtNS.Text.Replace(" ", "");
        }

        private void btnGeraPlanilha_Click(object sender, EventArgs e)
        {
            /*
            consultar.DataAtual();
            string Datou = consultar.dataParaArquivo;

            for (int i = 0; i < dgvParaAbrir.RowCount; i++)
            {
                string NotaFiscal = dgvParaAbrir.Rows[i].Cells["NotaFiscal"].Value.ToString();
                string Classificacao = dgvParaAbrir.Rows[i].Cells["Classificacao"].Value.ToString();

                try
                {
                    int linha = 2;                                 

                    var folder = "";
                    if (txtEndereco.Text.Length > 0)
                    {
                        folder = System.IO.Path.GetDirectoryName(txtEndereco.Text);
                    }
                    else
                    {
                        folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    }

                    bool existeDiretorio = File.Exists(folder + "\\MODELO ENCERRAR NF.csv"); //verifica se o diretorio existe
                    if (existeDiretorio == true)
                    {
                        bool existeDiretorio2 = File.Exists(folder + "\\NF " + NotaFiscal + " " + Classificacao + " " + Datou + ".csv"); //verifica se o diretorio existe
                        if (existeDiretorio2 == false)
                        {
                            File.Copy(folder + "\\MODELO ENCERRAR NF.csv", folder + "\\NF " + NotaFiscal + " " + Classificacao + " " + Datou + ".csv");//Copia o arquivo “arquivo.txt” da unidade C: para a D:
                            try
                            {
                                xlexcel = new Excel.Application();

                                xlexcel.Visible = true;

                                // Open a File
                                xlWorkBook = xlexcel.Workbooks.Open(folder + "\\NF " + NotaFiscal + " " + Classificacao + " " + Datou + ".csv", 0, false, 5, "", "", false,
                                Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                                this.Cursor = Cursors.WaitCursor;

                                try
                                {
                                    consultar.ConsultaNotaFiscal(NotaFiscal);

                                    string busca = " Classificacao = '" + Classificacao + "'";
                                    //if (Classificacao == "ESTOQUE")
                                  //  {
                                  //      busca = " (Classificacao = 'ESTOQUE' OR Classificacao = 'ORCAMENTO') ";
                                  //  }

                                    string sql2 = "";
                                    sql2 += "SELECT NumeroSerie, NotaFiscal, CodViaVarejo, OSViaVarejo FROM MaquinasNoPosto WHERE Status = 'EXPEDICAO' and NotaFiscal = '" + NotaFiscal + "' AND " + busca + "";
                                    cx2.Conectar();
                                    SqlCommand cd2 = new SqlCommand();
                                    cd2.Connection = cx2.c;
                                    cd2.CommandText = sql2;
                                    SqlDataReader dr2 = cd2.ExecuteReader();
                                    if (dr2.HasRows)
                                    {
                                        while (dr2.Read())
                                        {
                                            string NumeroSerie = dr2["NumeroSerie"].ToString();
                                            string NFOrigem = dr2["NotaFiscal"].ToString();
                                            string CodViaVarejo = dr2["CodViaVarejo"].ToString();
                                            string OSViaVarejo = dr2["OSViaVarejo"].ToString();
                                           

                                            xlWorkSheet.Cells[linha, 1] = NumeroSerie;
                                            xlWorkSheet.Cells[linha, 2] = NFOrigem;
                                            xlWorkSheet.Cells[linha, 3] = "1000317633";

                                            decimal Valor = Convert.ToDecimal(consultar.Valor) / Convert.ToDecimal(consultar.QntProdutos);
                                            xlWorkSheet.Cells[linha, 4] = Valor;

                                            xlWorkSheet.Cells[linha, 5] = Convert.ToDateTime(consultar.DataEmissao);
                                            xlWorkSheet.Cells[linha, 6] = OSViaVarejo;
                                            xlWorkSheet.Cells[linha, 8] = "E001";


                                            string Chamado = "";
                                            importdatafromexcel(txtEndereco.Text, NumeroSerie, out Chamado);

                                            xlWorkSheet.Cells[linha, 9] = Chamado;

                                            string classi = "";
                                            switch (Classificacao)
                                            {
                                                case "SALDO":
                                                    classi = "PRODUTO REPARADO PARA SALDO";
                                                    break;
                                                case "ESTOQUE":
                                                    classi = "PRODUTO REPARADO PARA ESTOQUE";
                                                    break;
                                                case "ORCAMENTO":
                                                    classi = "PRODUTO REPARADO ORÇAMENTO";
                                                    break;                                                
                                                default:
                                                    classi = Classificacao;
                                                    break;
                                            }
                                            xlWorkSheet.Cells[linha, 12] = classi;

                                            linha = linha + 1;
                                        }
                                    }
                                    dr2.Close();
                                }
                                catch (SqlException x)
                                {
                                    MessageBox.Show("Falha ao consultar os: \n" + x.Message);
                                }
                                cx2.Desconectar();
                                
                                this.Cursor = Cursors.Default;

                                xlWorkBook.Close(true, misValue, misValue);
                                xlexcel.Quit();
                                releaseObject(xlWorkSheet);
                                releaseObject(xlWorkBook);
                                releaseObject(xlexcel);

                                MessageBox.Show("\\NF " + NotaFiscal + " " + Classificacao + " " + Datou + " FOI GERADO EM:\r\n"+ folder);
                                
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("ERRO ao inserir no excel: \n" + x.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("ARQUIVO JÁ EXISTE.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("É NECESSARIO QUE O MODELO ESTEJA EM:\r\n" + folder);
                    }
                }
                catch (Exception x)
                {

                }
            }           
             */ 
        }


        private void btnBusca_Click(object sender, EventArgs e)
        {
            if (chbPorFora.Checked)
            {
                ListarTudoPorFora();
            }
            else
            {
                ListarTudo();
            }
        }



        public void importdatafromexcel(string pasta, string NS, out string Chamado)
        {
            string pasta2 = Path.GetFileNameWithoutExtension(pasta);
            //MessageBox.Show(pasta2);
            Chamado = "";
            //declare variables - edit these based on your particular situation
            //  string ssqltable = "BaseCodigos";
            //string ssqltable = "BaseDados";
            // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have different
            //string myexceldataquery = "select IdEquipamento, Equipamento, Modelo, Material, DataVenda from [Plan1$]";
            string myexceldataquery = "select NS, CHAMADO from ["+pasta2+"$]";
            myexceldataquery += " WHERE NS = '" + NS + "'";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //create our connection strings
                string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + txtEndereco.Text + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
                // string ssqlconnectionstring = "Server=011EIND2899\\SQLEXPRESS;Database=Vistoria;UID=sa;PWD=123";
             //   string ssqlconnectionstring = "Data Source=10.83.200.23,49172;Initial Catalog=Positivo;User ID=sa;Password=Maiden!@#";
                //execute a query to erase any previous data from our destination table

                /*string sclearsql = "delete from " + ssqltable;
                
                SqlConnection sqlconn = new SqlConnection(ssqlconnectionstring);
                SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);                
                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();                
                sqlconn.Close();
                 */
                //series of commands to bulk copy data from the excel file into our sql table
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);

                oledbconn.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
             //   SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);


                //   bulkcopy.DestinationTableName = ssqltable;

                if (dr.HasRows)
                {
                   
                    while (dr.Read())
                    {                                             
                        NS = dr["NS"].ToString();
                        Chamado = dr["CHAMADO"].ToString();
                    }
                }
                else
                {
                    //consulta.PlayFail();
                    MessageBox.Show("NÚMERO DE SÉRIE INEXISTENTE NA PLANILHA.");
                   // btnLimpar.PerformClick();
                }




                oledbconn.Close();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                //handle exception
                MessageBox.Show(" = " + ex);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog vAbreArq = new OpenFileDialog();
            vAbreArq.Filter = "Microsoft Excel |*.xls; *.xlsx; *.csv";
            vAbreArq.Title = "Selecione o Arquivo";
            if (vAbreArq.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show("igual =" + vAbreArq.FileName);
                string pasta = vAbreArq.FileName;
                txtEndereco.Text = pasta;
              //string diretorio = System.IO.Path.GetDirectoryName(pasta);
               
            }
        }


        public void ListarOS(string NF)
        {
            string sql = "";
            sql = "select OS, Descricao, NS, Status from Chamados where Notafiscal = '" + NF + "' and Status != 'EXPEDICAO' and CT = '" + lblCT.Text + "' order by Status";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "MaquinasNoPosto");
            dgvVisualizar.DataSource = ds.Tables["MaquinasNoPosto"];
            cx.Desconectar();

            try
            {
                dgvVisualizar.RowHeadersVisible = false;
                dgvVisualizar.AutoResizeColumns();
                //dgvVisualizar.Columns[1].Width = 80;
                // dgvVisualizar.Columns[2].Width = 200;
                dgvVisualizar.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvVisualizar.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
           
        }

        
        

        private void dgvConsultaNotas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
              
        }
              

        private void txtRetornoNF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                consultar.comando = "";
                consultar.comando = "select Notafiscal as Quantidade from Chamados where OS = '" + txtRetornoNF.Text + "' and CT = '" + lblCT.Text + "'";
                consultar.consultarSimNao();
                consultar.PlayOK();
                txtRetornoNF.Text = consultar.qntNaPosicao;
                txtRetornoNF.Select();
                txtRetornoNF.SelectAll();                
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            txtRetornoNF.Text = "";
            pnlNF.Visible = false;
        }

        private void lnkBuscarNFdaOS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlNF.Visible = true;
            txtRetornoNF.Select();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlVisualizarOS.Visible = false;
            dgvVisualizar.DataSource = null;
        }

        Impressao imprimir = new Impressao();
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            /*
            if (txtBusca.Text.Length > 0)
            {
                if (MessageBox.Show("DESEJA IMPRIMIR UMA ETIQUETA COM A NF " + txtBusca.Text + " ?", "PERGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string codZPL = "";
                    imprimir.NFiscal(txtBusca.Text);
                    codZPL = imprimir.s;
                    string nomeImpressoraPadrao = (new PrinterSettings()).PrinterName;
                    RawPrinterHelper.SendStringToPrinter(nomeImpressoraPadrao, codZPL);
                }
            }
            else
            {
                MessageBox.Show("INFORME O NÚMERO DA NOTA FISCAL QUE SERÁ IMPRESSA.");
            }
             */ 
        }

        private void dgvConsultaNotas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtNF.Text = "";
            if (chbPorFora.Checked)
            {
                ListarTudoPorFora();
            }
            else
            {
                ListarTudo();
            }
        }

        private void dgvConsultaNotas_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvConsultaNotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvConsultaNotas.Columns[e.ColumnIndex].Name == "NotaFiscal")
                {
                    string NF = dgvConsultaNotas.Rows[e.RowIndex].Cells["NotaFiscal"].Value.ToString();
                    string Classificacao = dgvConsultaNotas.Rows[e.RowIndex].Cells["Classificacao"].Value.ToString();
                    string QNT = dgvConsultaNotas.Rows[e.RowIndex].Cells["QNT"].Value.ToString();
                    string Verejista = dgvConsultaNotas.Rows[e.RowIndex].Cells["Varejista"].Value.ToString();
                    txtNF.Text = NF;
                    txtOrcamento.Text = Classificacao;
                    txtQnt.Text = QNT;
                    txtVarejista.Text = Verejista;
                    if (chbPorFora.Checked)
                    {
                        ConsultarItensPorfora(NF, Classificacao);
                    }
                    else
                    {
                        ConsultarItens(NF, Classificacao);
                    }
                }
                else if (dgvConsultaNotas.Columns[e.ColumnIndex].Name == "TOTAL")
                {
                    // MessageBox.Show("biundas");
                    /*
                    string NF = dgvConsultaNotas.Rows[e.RowIndex].Cells["NotaFiscal"].Value.ToString();
                    pnlVisualizarOS.Visible = true;
                    ListarOS(NF);
                     */
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                cx.Desconectar();
            }
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if (txtNFSaida.Text.Length > 0)
            {
                consultar.DataAtual();
                string text = "";
                string[] txtChamadosBoxLines = txtNS.Lines;
                foreach (string linha in txtChamadosBoxLines)
                {                   
                    if (text.Length == 0)
                    {
                        text += "'" + linha + "'";
                    }
                    else
                    {
                        text += ", '" + linha + "'";
                    }
                }
                if(chbPorFora.Checked)
                {
                    //INSERE A NF DE SAIDA NO BANCO NOTAS POR FORA
                    consultar.comando = "update NotaPorFora set NotaFiscalSaida = '" + txtNFSaida.Text + "', Status = 'CONCLUIDO' where idNotaPorFora in (" + text + ") and CT = '" + lblCT.Text + "'";
                   // MessageBox.Show(consultar.comando);
                    consultar.Atualizar();
                    //==================================
                }
                else
                {
                    //INSERE A NF DE SAIDA NO CHAMADOS
                    consultar.comando = "update chamados set NotaFiscalSaida = '" + txtNFSaida.Text + "' where idChamados in (" + text + ") and CT = '" + lblCT.Text + "'";
                   //MessageBox.Show(consultar.comando);
                    consultar.Atualizar();
                    //==================================
                }
               // MessageBox.Show("pAROU");
                //==============INSERE OS ITENS DA NOTA DE SAIDA NO BANCO NOTA FISCAL DE SAÍDA
                string feed = "";
                for (int i = 0; i < dgvParaLançarNF.RowCount; i++) 
                {
                    string NotaFiscal = dgvParaLançarNF.Rows[i].Cells["NotaFiscal"].Value.ToString();
                    string Classificacao = dgvParaLançarNF.Rows[i].Cells["Classificacao"].Value.ToString();
                    string CodVarejo = dgvParaLançarNF.Rows[i].Cells["CodVarejo"].Value.ToString();
                    string Descricao = dgvParaLançarNF.Rows[i].Cells["Descricao"].Value.ToString();
                    string QNT = dgvParaLançarNF.Rows[i].Cells["QNT"].Value.ToString();
                    string Valor_uni = dgvParaLançarNF.Rows[i].Cells["Valor_uni"].Value.ToString();
                    string VALOR_TOTAL = dgvParaLançarNF.Rows[i].Cells["VALOR_TOTAL"].Value.ToString();
                    string NCM = dgvParaLançarNF.Rows[i].Cells["NCM"].Value.ToString();
                    string Tipo = "";
                    if (chbPorFora.Checked)
                    {
                        Tipo = "PORFORA";
                    }
                    else
                    {
                        Tipo = "NORMAL";
                    }
                    // ATUALIZADO PARA INSERIR TMB, O TIPO DE SAIDA, SE FOI NORMAL OU PORFORA.
                    inserirNotaFiscal(txtNFSaida.Text, NotaFiscal, consultar.dataNormal, Classificacao, CodVarejo, Descricao, QNT, Valor_uni, VALOR_TOTAL, NCM, txtVarejista.Text, Tipo, out feed);
                }
                if (feed == "")
                {
                    MessageBox.Show("NOTA DE SAÍDA " + txtNFSaida.Text + " INSERIDA COM SUCESSO!");
                    dgvParaLançarNF.DataSource = null;
                    txtNF.Text = "";
                    txtOrcamento.Text = "";
                    txtQnt.Text = "";
                    txtNFSaida.Text = "";
                    txtNS.Text = "";
                    txtVarejista.Text = "";
                   // btnConcluir.Visible = false;
                    if (chbPorFora.Checked)
                    {
                        ListarTudoPorFora();
                    }
                    else
                    {
                        ListarTudo();
                    }
                }
            }
            else
            {
                MessageBox.Show("INFORME A NOTA FISCAL DE SAÍDA.");
            }
        }


        public void inserirNotaFiscal(string NFSaida, string NFEntrada, string Data, string Classificacao, string CodVarejo, string Descricao, string QNT, string Valor_uni, string VALOR_TOTAL, string NCM, string Varejista, string Tipo, out string Feed)
        {
            string sql = "";
            try
            {
                sql += " Insert into NotaFiscalSaida (CT, NotaSaida, NotaEntrada, Data, Classificacao, CodVarejo, Descricao, QNT, Valor_uni, VALOR_TOTAL, NCM, Varejista ,Tipo)";
                sql += " Values ( ";
                sql += " '" + lblCT.Text + "', ";
                sql += " '" + NFSaida + "', ";
                sql += " '" + NFEntrada + "', ";
                sql += " '" + Data + "', ";
                sql += " '" + Classificacao + "',";
                sql += " '" + CodVarejo + "',";
                sql += " '" + Descricao + "',";
                sql += " '" + QNT + "', ";
                sql += " '" + Valor_uni + "', ";
                sql += " '" + VALOR_TOTAL + "', ";
                sql += " '" + NCM + "', ";
                sql += " '" + Varejista + "', ";
                sql += " '" + Tipo + "')";
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

        private void chbPorFora_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPorFora.Checked)
            {
                ListarTudoPorFora();
                dgvParaLançarNF.DataSource = null;
                txtNF.Text = "";
                txtOrcamento.Text = "";
                txtQnt.Text = "";
                txtNFSaida.Text = "";
                txtNS.Text = "";
                txtVarejista.Text = "";
            }
            else
            {
                ListarTudo();
                dgvParaLançarNF.DataSource = null;
                txtNF.Text = "";
                txtOrcamento.Text = "";
                txtQnt.Text = "";
                txtNFSaida.Text = "";
                txtNS.Text = "";
                txtVarejista.Text = "";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //Zen.Barcode.CodeQrBarcodeDraw rubi = Zen.Barcode.BarcodeDrawFactory.CodeQr;
        }

        
        public void formaString()
        {
            /*
            //$A = enter
            //$I = tab
            string CLASS = "";
            string inicioCodBarra = "";
            Zen.Barcode.CodeQrBarcodeDraw rubi = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            CLASS = "QUEBRADO";
            inicioCodBarra = "X$I2121$AN";
            txtTextoPt1.Text = "*" + txtOS.Text + "$AS" + "*";
            txtTextoPt2.Text = "*" + txtNS.Text + "*";
            txtTextoPt3.Text = "*" + "$I$I" + inicioCodBarra + "*";
            txtTextoPt4.Text = "*" + CLASS + "$AS$A$A" + "*";
            picBarcode.Image = rubi.Draw(txtOS.Text + "\r\nS" + txtNS.Text + "\t\tX\t2121\r\nN" + CLASS + "\r\nS\r\n\r\n", 20);
             */           
        }

        private void dgvParaLançarNF_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            try
            {
                Zen.Barcode.CodeQrBarcodeDraw rubi = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                if (dgvParaLançarNF.Columns[e.ColumnIndex].Name == "NotaFiscal")
                {
                    string NF = dgvParaLançarNF.Rows[e.RowIndex].Cells["NotaFiscal"].Value.ToString();
                    string DESC = dgvParaLançarNF.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
                    string NCM = dgvParaLançarNF.Rows[e.RowIndex].Cells["NCM"].Value.ToString();
                    string QNT = dgvParaLançarNF.Rows[e.RowIndex].Cells["QNT"].Value.ToString();

                    string Valor_uni = dgvParaLançarNF.Rows[e.RowIndex].Cells["Valor_uni"].Value.ToString();
                    string VALOR_TOTAL = dgvParaLançarNF.Rows[e.RowIndex].Cells["VALOR_TOTAL"].Value.ToString();

                    //string texto = "313160\t\tFERRO VAPOR PHILCO PFV3200V TITANIUM\t85164000\t\t\t\tp;\t2\t100,25\tp;\t2\t100,25\t\t\t\t\t\t\t200,50";
                    string texto = NF + "\t\t" + DESC + "\t" + NCM + "\t\t\t\tPC\t" + QNT + "\t" + Valor_uni + "\tPC\t" + QNT + "\t" + Valor_uni + "\t\t\t\t\t\t\t" + VALOR_TOTAL;
                    picJB1.Image = rubi.Draw(texto, 10);
                    lblTextoQRCode.Text = texto;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                cx.Desconectar();
            }
             */ 
        }

        private void dgvParaLançarNF_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               // Zen.Barcode.CodeQrBarcodeDraw rubi = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                string NF = dgvParaLançarNF.Rows[e.RowIndex].Cells["NotaFiscal"].Value.ToString();
                string DESC = dgvParaLançarNF.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
                string NCM = dgvParaLançarNF.Rows[e.RowIndex].Cells["NCM"].Value.ToString();
                string QNT = dgvParaLançarNF.Rows[e.RowIndex].Cells["QNT"].Value.ToString();

                string Valor_uni = dgvParaLançarNF.Rows[e.RowIndex].Cells["Valor_uni"].Value.ToString();
                string VALOR_TOTAL = dgvParaLançarNF.Rows[e.RowIndex].Cells["VALOR_TOTAL"].Value.ToString();

                //string texto = "313160\t\tFERRO VAPOR PHILCO PFV3200V TITANIUM\t85164000\t\t\t\tp;\t2\t100,25\tp;\t2\t100,25\t\t\t\t\t\t\t200,50";
                //string texto = NF + "\t\t" + DESC + "\t" + NCM + "\t\t\t\tPC\t" + QNT + "\t" + Valor_uni + "\tPC\t" + QNT + "\t" + Valor_uni + "\t\t\t\t\t\t\t" + VALOR_TOTAL;
                //picJB1.Image = rubi.Draw(texto, 10);
                //lblTextoQRCode.Text = NF + " - " + DESC;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                cx.Desconectar();
            }
        }
         
        


       







    }
}
