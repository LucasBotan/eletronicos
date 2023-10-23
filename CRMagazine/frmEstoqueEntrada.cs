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
    public partial class frmEstoqueEntrada : Form
    {
        public frmEstoqueEntrada(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        private void frmEstoqueEntrada_Load(object sender, EventArgs e)
        {

        }

        Consulta consultar = new Consulta();
        Conexao cx = new Conexao();
        Conexao cx2 = new Conexao();

        ToolTip t = new ToolTip();

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog vAbreArq = new OpenFileDialog();
            vAbreArq.Filter = "Microsoft Excel |*.xls; *.xlsx";
            vAbreArq.Title = "Selecione o Arquivo";
            if (vAbreArq.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show("igual =" + vAbreArq.FileName);
                string pasta = vAbreArq.FileName;

                importdatafromexcel(pasta);
            }
        }

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

        //adc posicao --- retirrar
        public void Concluir(string Cod, string Descricao, string Quantidade, string Barebone)
        {
            DateTime agora = DateTime.Now;
            string sql = "";
            string posicao = "REC";
            string qntNaPosicao = "";
            string dataHistorico = agora.ToString();
            string Historico = lblUsuario.Text + " - ENTRADA: " + dataHistorico;

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
                consultar.Atualizar();
            }
             else
             {
                try
                {
                    sql = "";
                    sql += " Insert into Estoque (CT, Codigo, Barebone, Descricao, Quantidade, Posicao)";
                    sql += " Values ( ";
                    sql += " '" + lblCT.Text + "', ";
                    sql += " '" + Cod + "', ";
                    sql += " '" + Barebone + "', ";
                    sql += " '" + Descricao + "', ";
                    sql += " '" + Quantidade + "', ";
                    sql += " '" + posicao + "') ";                    
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


        public void ConcluirComChamado(string Cod, string Descricao, string Barebone, string OS)
        {
            DateTime agora = DateTime.Now;
            string sql = "";
            string posicao = "PP";
            int Quantidade = 1;
            string dataHistorico = agora.ToString();
            string Historico = lblUsuario.Text + " - ENTRADA: " + dataHistorico;            
            try
            {
                sql = "";
                sql += " Insert into Estoque (CT, Codigo, Barebone, Descricao, Quantidade, Posicao, Chamado)";
                sql += " Values ( ";
                sql += " '" + lblCT.Text + "', ";
                sql += " '" + Cod + "', ";
                sql += " '" + Barebone + "', ";
                sql += " '" + Descricao + "', ";
                sql += " '" + Quantidade + "', ";
                sql += " '" + posicao + "', ";
                sql += " '" + OS + "')"; 
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
            //cx.Desconectar();                      
        }

        public void importdatafromexcel(string pasta)
        {
            //declare variables - edit these based on your particular situation
            //string ssqltable = "BaseCodigos";
            //string ssqltable = "BaseDados";
            // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have different
            //string myexceldataquery = "select IdEquipamento, Equipamento, Modelo, Material, DataVenda from [Plan1$]";
            string myexceldataquery = "select Codigo, Quantidade from [Plan1$]";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //create our connection strings
                string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + pasta + ";extended properties=" + "\"excel 8.0;hdr=yes;IMEX=1\"";
                // string ssqlconnectionstring = "Server=011EIND2899\\SQLEXPRESS;Database=Vistoria;UID=sa;PWD=123";
                //string ssqlconnectionstring = "Data Source=10.83.200.23,49172;Initial Catalog=Positivo;User ID=sa;Password=Maiden!@#";
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
               // SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);


               // bulkcopy.DestinationTableName = ssqltable;

                string RetornoCodigo = "";
                string RetornoQuantidade = "";
                string Descricao = "";
                string Barebone = "";
                //string Chamado = "";
                string Erro = "";
                int Cont = 1;
                while (dr.Read())
                {                    
                    Cont = Cont + 1;
                    lblStatus.Text = "Executando Linha: " + Cont;
                    string Cod = dr["Codigo"].ToString();
                    string Qnt = dr["Quantidade"].ToString();
                    //string ChamadoAssist = dr["Chamado"].ToString();
                    //MessageBox.Show(Cod + " - " + ChamadoAssist + " - " + Qnt);
                    if (Cod.Length != 0)
                    {                        
                        consultar.consultarBaseCodigos(Cod);
                        if (consultar.Retorno == "ok")
                        {
                            RetornoCodigo = "ok";
                            Descricao = consultar.Descricao;
                            Descricao = Descricao.Replace("'", " ");
                            Barebone = consultar.Barebone;
                        }
                        else
                        {
                            RetornoCodigo = "falha";
                            Erro += "ERRO: Linha " + Cont + " Codigo: " + Cod + " Inexistente \r\n";
                        }


                        int Quantidade = Convert.ToInt32(Qnt);
                        if (Quantidade > 0)
                        {
                            RetornoQuantidade = "ok";          
                        }
                        else
                        {
                            RetornoQuantidade = "falha";
                            Erro += "ERRO: Linha " + Cont + " Quantidade não pode ser igual a zero ou menor \r\n";
                        }
                        if (RetornoCodigo == "ok" && RetornoQuantidade == "ok")
                        {

                            //================================ INICIO (TUDO JÁ VERIFICADO) ==============================
                            //VERIFICA SE EXISTE AGURADO DE BACKUP PARA ESSA PEÇA
                            consultar.comando = "";
                            consultar.comando += "select count(*) as Quantidade from AguardoBackup WHERE Codigo = '" + Cod + "' AND Status = 'PENDENTE' and CT = '" + lblCT.Text + "'";
                            consultar.consultarSimNao();
                            if (consultar.Retorno == "ok" || Convert.ToInt32(consultar.qntNaPosicao) > 0)
                            {
                                int QntE;
                                AguardoBackUp(Cod, Qnt, Descricao, out QntE);
                                Qnt = QntE.ToString();
                            }

                            //string OS ="";
                          //  string Chamado = "texto";
                           // Chamado = ChamadoAssist;
                           // int indice = 0;
                            if (Convert.ToInt32(Qnt) > 0)
                            {
                                Concluir(Cod, Descricao, Qnt, Barebone);
                               // MessageBox.Show("inseriu normal de primeira");
                            }
                                /*
                            else
                            {
                               // OS = Chamado.Trim();
                               // OS = Chamado.Replace(" ", "");
                                int x = 0;
                                while (x < Convert.ToInt32(Qnt))
                                {
                                   // MessageBox.Show("estou no while  e x vale " + x);
                                    if (!Chamado.Contains(','))
                                    {
                                        OS = Chamado;
                                    }
                                    else
                                    {
                                        indice = Chamado.IndexOf(",");
                                        OS = Chamado.Substring(0, (indice));
                                        Chamado = Chamado.Substring(indice + 1);
                                    }
                                    OS = OS.Trim();
                                    consultar.ConsultarChamado = OS;                                   
                                    consultar.ConsultarPeloChamado();
                                  //  MessageBox.Show(consultar.Status + " - " + OS);
                                    // se esta em agurdo lança em pp
                                    if (consultar.Status == "AGUARDOPECA" || consultar.Status == "APROVACAO")
                                    {
                                        ConcluirComChamado(Cod, Descricao, Barebone, OS);
                                        //MessageBox.Show("inseriu no pp");
                                    }
                                        // senão lança normalmente
                                    else
                                    {
                                        string Qntd = "1";
                                        Concluir(Cod, Descricao, Qntd, Barebone);
                                        //MessageBox.Show("inseriu normal consultando");
                                    }
                                    x = x + 1;
                                }
                            }  
                                 */ 
                        }
                        else
                        {
                        }                       
                    }
                }
                lblStatus.Text = "Finalizado";
                if (Erro == "")
                {
                    MessageBox.Show("Tudo ocorreu Bem!");
                }
                else
                {
                    StreamWriter writer = new StreamWriter(@"c:\ArquivoDeErro.txt");
                    writer.Write(Erro);
                    writer.Close();
                    writer.Dispose();
                    Process.Start("notepad.exe", @"c:\ArquivoDeErro.txt");
                }
                oledbconn.Close();
                this.Cursor = Cursors.Default;
                MessageBox.Show("FINALIZADO!");
            }
            catch (Exception ex)
            {
                //handle exception
                MessageBox.Show(" = " + ex);
                this.Cursor = Cursors.Default;
            }
        }


        public void AguardoBackUp(string Cod, string Quantidade, string Descricao, out int Qnt)
        {
            Qnt = Convert.ToInt32(Quantidade);
            //================= VERIFICA AGUARDO DE BACKUP
            try
            {
                cx2.Desconectar();
                string comando = "select * FROM AguardoBackup WHERE Codigo = '" + Cod + "' AND Status = 'PENDENTE' and CT = '" + lblCT.Text + "' ";
                cx2.Conectar();
                SqlCommand cd2 = new SqlCommand();
                cd2.Connection = cx2.c;
                cd2.CommandText = comando;
                SqlDataReader dr2 = cd2.ExecuteReader();
                if (dr2.HasRows)
                {
                    while (dr2.Read())
                    {
                        if (Qnt > 0) // SE AINDA TEM QUANTIDADE, FAZ O PROCESSO
                        {
                            string id = dr2["idAguardoBackup"].ToString();
                            string Chamado = dr2["Chamado"].ToString();

                            consultar.Coluna = "OS";
                            consultar.ValorDesejado = Chamado;
                            consultar.ComData = "SIM";                         
                            consultar.ConsultaTudo(lblCT.Text);
                            if (consultar.Status == "PP") //VERIFICA O STATUS DO POSSIVEL AGUARDO DE BACKUP
                            {
                                txtFeedBack.Text += Chamado + " AGUARDOBACKUP - PEÇA: " + Cod + " " + Descricao + "\r\n";
                                //======================================INSERE NO ESTOQUE O CHAMADO COMO PP ========================================
                                string sql = "";
                                string posicao = "BACKUP";
                                string Orc = "BACKUP";
                                try
                                {
                                    sql = "";
                                    sql += " Insert into Estoque (CT, Codigo, Barebone, Descricao, Quantidade, Posicao, Chamado, Tipo, BareboneEquivalente, Orc)";
                                    sql += " Values ( ";
                                    sql += " '" + lblCT.Text + "', ";
                                    sql += " '" + Cod + "', ";
                                    sql += " '', ";
                                    sql += " '" + Descricao + "', ";
                                    sql += " '1', ";
                                    sql += " '" + posicao + "', ";
                                    sql += " '" + Chamado + "', ";
                                    sql += " '', ";
                                    sql += " '', ";
                                    sql += " '" + Orc + "')";
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
                                    MessageBox.Show("ERRO AO INSERIR ENTRADA DE ESTOQUE COM CHAMADO BACKUP: \r\n" + x.Message);
                                }
                                //================================================ FIM DA INSERÇÃO =================================================


                                // ===================================== ALTERA O STATUS DO AGUARDOBACKUP PARA RECEBIDO
                                consultar.comando = "";
                                consultar.comando = "update AguardoBackup set Status = 'RECEBIDO' where idAguardoBackup = '" + id + "' and CT = '" + lblCT.Text + "'";
                                consultar.Atualizar();

                                // ===================================== RETIRA 1 DA QUANTIDADE QUE IRA ENTRAR NO REC DO ESTOQUE
                                Qnt = Qnt - 1;

                                // =================================================
                            }
                            else // NÃO PÕE NO ESTOQUE E ALTERA O STATUS DO AGUARDOBACKUP PARA CANCELADO
                            {
                                // =====================================
                                consultar.comando = "";
                                consultar.comando = "update AguardoBackup set Status = 'CANCELADO' where idAguardoBackup = '" + id + "' and CT = '" + lblCT.Text + "'";
                                consultar.Atualizar();
                                // =====================================
                            }
                        }
                        else
                        {

                        }

                    }
                }
                dr2.Close();

            }
            catch (SqlException x)
            {
                MessageBox.Show("FALHA AO LISTAR CONSUMO ASSIT:\r\n" + x.Message);
            }
            cx2.Desconectar();
            //==================== FIM DA VERIFICAÇÃO DE AGUARDO DE BACKUP
        }

        public void criarExcel()
        {
            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Cells[1, 1] = "Codigo";
                xlWorkSheet.Cells[1, 2] = "Quantidade";

                xlWorkBook.SaveAs("C:\\Modelo Entrada Estoque", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
                Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("O arquivo Excel foi criado com sucesso. Você pode encontrá-lo em : C:\\Modelo Inserir Nota Fiscal");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            t.SetToolTip(this.pictureBox2, "Clique duas vezes para Gerar uma Planilha Modelo");
        }

        private void pictureBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            criarExcel();
        }



    }
}
