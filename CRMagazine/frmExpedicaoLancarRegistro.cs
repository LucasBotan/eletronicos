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


namespace CRMagazine
{
    public partial class frmExpedicaoLancarRegistro : Form
    {
        public frmExpedicaoLancarRegistro(string CT, string User)
        {
            InitializeComponent();
            lblCT.Text = CT;
            lblUsuario.Text = User;
        }

        private void frmExpedicaoLancarRegistro_Load(object sender, EventArgs e)
        {
            VisualizaRomaneio(false);
        }

        Conexao cx = new Conexao();
        Conexao cx2 = new Conexao();
        Consulta consulta = new Consulta();

        Microsoft.Office.Interop.Excel.Application xlexcel;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet2;
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
             

        private void txtRegistroPositivo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if(txtFiltro.Text.Length > 0)
            {
                VisualizaRomaneio(true);
            }
            else
            {
                VisualizaRomaneio(false);
            }           
        }

        public void VisualizaRomaneio(bool porData)
        {
            string sql = "";
            sql += " Select OS, DataSaida,  Descricao as DESCRICAO, CLASSIFICACAO, VAREJISTA From CHAMADOS where (RegistroSaida = '' or RegistroSaida is null) and Status = 'FINALIZADO' and CT = '101' ";
            if(porData == true)
            {
                sql += " and convert(varchar(10), DataSaida, 103) like '%" + txtFiltro.Text + "%' ";
            }
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "CHAMADOS");
            dgvRomaneio.DataSource = ds.Tables["CHAMADOS"];
            cx.Desconectar();
            lblTotalRomaneio.Text = dgvRomaneio.Rows.Count.ToString();

            //fromata
            dgvRomaneio.RowHeadersVisible = false;
            dgvRomaneio.Columns["DESCRICAO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRomaneio.Columns["VAREJISTA"].Visible = false;
            dgvRomaneio.ScrollBars = System.Windows.Forms.ScrollBars.Both;            

            btnMarcarTudo.PerformClick();
            
        }

        private void btnGeraExcel_Click(object sender, EventArgs e)
        {
            //criarExcel();
        }

        /*
        public void criarExcel()
        {
            try
            {
                consulta.DataAtual();
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Range xlwidthadjust; //used this to adjust width of columns
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                Image image = Properties.Resources.logo;
                Image _platypusLogo;
                _platypusLogo = image;
                Clipboard.SetDataObject(_platypusLogo, true);
                var cellRngImg = xlWorkSheet.Cells[1, 1];
                xlWorkSheet.Paste(cellRngImg, _platypusLogo);

                xlWorkSheet.Cells[1, 2] = "Nº ROMANEIO:";
                xlWorkSheet.Cells[1, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                xlWorkSheet.Cells[1, 3] = "";// cbxUsuario.Text;
                xlWorkSheet.Cells[1, 3].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                xlWorkSheet.Cells[1, 3].Font.Bold = true;
                xlWorkSheet.Cells[1, 3].Font.Size = 14;
                xlWorkSheet.Cells[1, 3].Borders.LineStyle = 1;
                xlWorkSheet.Cells[1, 3].Borders.Weight = 2;
                xlWorkSheet.Cells[1, 3].Borders.Color = Color.Black;

                xlWorkSheet.Cells[3, 2] = "DESENVOLVIDO POR LUCAS MARQUES BOTAN PARA A POSITIVO.";
                xlWorkSheet.Cells[3, 2].Font.Color = Color.White;

                xlWorkSheet.Cells[4, 1] = "ROMANEIO DE SAÍDA " + txtVarejistaRomaneio.Text;
                var chartRange = xlWorkSheet.get_Range("a4", "b4");
                chartRange.Merge();
                chartRange.Font.Size = 18;


                xlWorkSheet.Cells[5, 1] = "DATA SAÍDA";
                xlWorkSheet.Cells[5, 2] = consulta.data;
                xlWorkSheet.Cells[5, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;

                xlWorkSheet.Cells[6, 2] = "TOTAL:";
                xlWorkSheet.Cells[6, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                xlWorkSheet.Cells[6, 3] = dgvRomaneio.RowCount.ToString();
                xlWorkSheet.Cells[6, 3].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                xlWorkSheet.Cells[7, 1] = "OS";
                xlWorkSheet.Cells[7, 2] = "DESCRIÇÃO";
                xlWorkSheet.Cells[7, 3] = "CLASSIFICAÇÃO";


                // var chartRange = xlWorkSheet.get_Range("a1", "l1");
                //   chartRange.Interior.Color = System.Drawing.Color.Black;
                //   chartRange.Font.Color = System.Drawing.Color.Yellow;


                int linha = 7;
                for (int i = 0; i < dgvRomaneio.RowCount; i++)
                {
                    linha = linha + 1;
                    string OS = "";
                    string Descricao = "";
                    string Classificacao = "";
                    OS = dgvRomaneio.Rows[i].Cells["OS"].Value.ToString();
                    Descricao = dgvRomaneio.Rows[i].Cells["DESCRICAO"].Value.ToString();
                    Classificacao = dgvRomaneio.Rows[i].Cells["CLASSIFICACAO"].Value.ToString();
                    //=========================
                    xlWorkSheet.Cells[linha, 1] = OS;
                    xlWorkSheet.Cells[linha, 2] = Descricao;
                    xlWorkSheet.Cells[linha, 3] = Classificacao;
                }


                var chartRange2 = xlWorkSheet.get_Range("a7", "c7");
                chartRange2.Font.Size = 12;
                chartRange2.Font.Bold = true;
                // chartRange2.Interior.Color = System.Drawing.Color.LightGray;

                var chartRange3 = xlWorkSheet.get_Range("a7", "c" + linha);
                chartRange3.Borders.LineStyle = 1;
                chartRange3.Borders.Weight = 2;
                chartRange3.Borders.Color = Color.Black;
                chartRange3.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;


                xlWorkSheet.Columns.AutoFit();

                var folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                xlWorkBook.SaveAs(folder + "\\Romaneio " + cbxUsuario.Text + " " + consulta.dataParaArquivo, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
                Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("O arquivo Excel foi criado com sucesso. Você pode encontrá-lo em : DESKTOP");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro A1 : " + ex.Message);
            }
        }
        */

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if (txtRegistroVarejista.Text.Length > 0)
            {
                if (MessageBox.Show("TODOS OS EQUIPAMENTOS MARCADOS SERÃO AMARRADOS A ESSE REGISTRO DE SAÍDA\r\n\r\nDESEJA CONCLUIR? ", "Pergunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
                    foreach (DataGridViewRow row in dgvRomaneio.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["chbColuna"].Value) == true)
                        {
                            string OS = row.Cells["OS"].Value.ToString();

                            consulta.comando = "";
                            consulta.comando = "update Chamados set RegistroSaida = '" + consulta.Prevent(txtRegistroVarejista.Text) + "' WHERE (RegistroSaida = '' or RegistroSaida is null) AND Status = 'FINALIZADO' AND OS = '" + consulta.Prevent(OS) + "'";
                            //MessageBox.Show(consulta.comando);
                            consulta.Atualizar();
                        }
                        else
                        {

                        }
                    }
                    consulta.LimparControles(this);
                    dgvRomaneio.DataSource = null;
                    VisualizaRomaneio(false);                   
                    txtRegistroVarejista.Text = "";
                    txtRegistroVarejista.Select();
                }                
            }
            else
            {
                MessageBox.Show("INFORME OS REGISTROS.");
            }

            /*
            if (txtRegistroVarejista.Text.Length > 0 && txtRegistroPositivo.Text.Length > 0)
            {
                if (MessageBox.Show("CONCLUIR? ", "Pergunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    consulta.comando = "";
                    consulta.comando = "update Expedicao set RegistroSaida = '" + txtRegistroVarejista.Text + "', A1 = '" + txtRegistroPositivo.Text + "' WHERE RegistroSaida = '" + txtRegistroPositivo.Text + "' AND A1 = 'CONFIRMADO' ";
                    consulta.Atualizar();
                    if (consulta.Retorno == "ok")
                    {
                        MessageBox.Show("REGISTROS CADASTRADOS.");
                        //=======
                        try
                        {
                            dgvRomaneio.DataSource = null;
                        }
                        catch (Exception x)
                        {

                        }
                        //=======
                        ListarRegistros();
                        txtRegistroVarejista.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("ERRO AO ATUALIZAR.");
                    }
                }             
            }
            else
            {
                MessageBox.Show("INFORME OS REGISTROS.");
            }
             */ 
            
        }

        private void btnMarcarTudo_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgvRomaneio.Rows)
            {
               
                    if (Convert.ToBoolean(row.Cells["chbColuna"].Value) == false)
                    {
                        row.Cells["chbColuna"].Value = true;
                    }


            }
        }

        private void btnDesmarcar_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgvRomaneio.Rows)
            {
                if (Convert.ToBoolean(row.Cells["chbColuna"].Value) == true)
                {
                    row.Cells["chbColuna"].Value = false;
                }
                else
                {

                }
            }
            //lstID.Items.Clear();
        }

        private void txtOSAlterar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                consulta.comando = "SELECT RegistroSaida as Quantidade from Chamados where Status = 'FINALIZADO' and CT = '101' and OS = '" + consulta.Prevent(txtOSAlterar.Text) + "' ";
                consulta.consultarSimNao();
                string registro = consulta.qntNaPosicao;
                if(consulta.Retorno == "ok")
                {
                    txtRegistroAntigo.Text = registro;
                    txtRegistroNovo.Select();
                }
                else
                {
                    txtRegistroAntigo.Text = "";
                    txtOSAlterar.Select();
                    txtOSAlterar.SelectAll();
                    MessageBox.Show("REGISTRO NÃO ENCONTRADO PARA A OS INFORMADA.");
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if(txtRegistroAntigo.Text.Length == 0)
            {
                MessageBox.Show("INFORME O REGISTRO ANTIGO.");
                txtOSAlterar.Select();
                txtOSAlterar.SelectAll();
            }
            else if(txtRegistroNovo.Text.Length == 0)
            {
                MessageBox.Show("INFORME O REGISTRO NOVO.");
                txtRegistroNovo.Select();
            }
            else
            {
                if (MessageBox.Show("DESEJA ALTERAR O REGISTRO DE SAIDA? ", "Pergunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    consulta.comando = "update Chamados set RegistroSaida = '" + consulta.Prevent(txtRegistroNovo.Text) + "' where RegistroSaida = '" + txtRegistroAntigo.Text + "' and OS = '" + consulta.Prevent(txtOSAlterar.Text) + "' ";
                    consulta.Atualizar();
                    if (consulta.LinhasAfetadas > 0)
                    {
                        MessageBox.Show("REGISTRO ALTERADO.");
                        consulta.LimparControles(pnlAlterar);
                        txtOSAlterar.Select();
                    }
                    else
                    {
                        MessageBox.Show("OCORREU ALGUMA FALHA AO TENTAR ALTERAR.");
                    }
                }
            }
        }

        private void txtOSAlterar_TextChanged(object sender, EventArgs e)
        {
            txtRegistroAntigo.Text = "";
        }
    }
}
