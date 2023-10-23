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
    public partial class frmConsultaEquipamento : Form
    {
        public frmConsultaEquipamento(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        
        Conexao cx = new Conexao();
        Conexao cx2 = new Conexao();
        Conexao cx3 = new Conexao();
        Consulta consultar = new Consulta();

        //Microsoft.Office.Interop.Excel.Application xlexcel;
        //Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        //Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        //Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet2;
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

        private void frmConsultaHistorico_Load(object sender, EventArgs e)
        {

        }

        public void FormatarGrid()
        {
            dgvConsulta.Columns["idChamados"].Visible = false;
            dgvConsulta.RowHeadersVisible = false;
            dgvConsulta.AutoResizeColumns();
            //dgvConsulta.Columns[1].Width = 80;
            // dgvConsulta.Columns[2].Width = 200;
            // dgvConsulta.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 
            //dgvConsulta.ScrollBars = ScrollBars.Vertical;
            dgvConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both;

        }

        public void gerarexcel2()
        {
            Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
            if (dgvConsulta.Rows.Count > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dgvConsulta.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dgvConsulta.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dgvConsulta.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvConsulta.Columns.Count; j++)
                        {
                            
                            if (j == 6 || j == 9 || j == 10 || j==31)
                            {
                                string texto = dgvConsulta.Rows[i].Cells[j].Value.ToString();
                                if (texto.Length != 0)
                                {
                                    try
                                    {
                                        string confirmadia = texto.Substring(0, 2);
                                        //int dia2 = Convert.ToInt32(confirmadia);
                                        //  if (dia2 < 13)
                                        //  {
                                        /*
                                        string dia = texto.Substring(3, 2);
                                        string mes = texto.Substring(0, 2);
                                        string ano = texto.Substring(6);
                                        string diapronto = dia + "/" + mes + "/" + ano;
                                         */
                                        //string diapronto = string.Format("{0:d}", texto);
                                        string diapronto = texto.Substring(0, 10);
                                        DateTime dt = Convert.ToDateTime(diapronto);
                                        XcelApp.Cells[i + 2, j + 1] = dt;
                                        //  }
                                        //  else
                                        //  {
                                        //XcelApp.Cells[i + 2, j + 1] = dgvConsulta.Rows[i].Cells[j].Value.ToString();
                                        //  }
                                    }
                                    catch (Exception)
                                    {

                                    }                                    
                                }
                                else
                                {
                                    XcelApp.Cells[i + 2, j + 1] = dgvConsulta.Rows[i].Cells[j].Value.ToString();
                                }
                            }
                            else
                            {
                                XcelApp.Cells[i + 2, j + 1] = dgvConsulta.Rows[i].Cells[j].Value.ToString();
                            }
                             
                            //XcelApp.Cells[i + 2, j + 1] = dgvConsulta.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    XcelApp.Columns.AutoFit();

                    XcelApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gerar excel: \n" + ex.Message);
                    XcelApp.Quit();
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void btnlLimpar_Click(object sender, EventArgs e)
        {
            consultar.LimparControles(this);
            lblTotal.Select();
        }

        private void btnGeraExcel_Click(object sender, EventArgs e)
        {
            gerarexcel2();
        }

        public void FazerConsulta()
        {
            string sql = "";
            if (txtOS.Text.Length != 0)
            {
                sql += "select DATEDIFF(DAY, DataEntrada, GETDATE()) as DNP, * from CHAMADOS where ";
                sql += "OS = '" + txtOS.Text + "' and CT = '" + lblCT.Text + "'";              
            }
            else if (txtNS.Text.Length != 0)
            {
                sql += "select DATEDIFF(DAY, DataEntrada, GETDATE()) as DNP, * from CHAMADOS where ";
                sql += "NS = '" + txtNS.Text + "' and CT = '" + lblCT.Text + "'";          
            }
            else if (txtObjeto.Text.Length != 0)
            {
                sql += "select DATEDIFF(DAY, DataEntrada, GETDATE()) as DNP, * from CHAMADOS where ";
                sql += "NS = '" + txtNS.Text + "' and CT = '" + lblCT.Text + "'";          
            }
            else if (txtData.Text.Length == 0 && txtDescricao.Text.Length == 0 && txtClassificacao.Text.Length == 0 && txtAcima.Text.Length == 0 && txtTipo.Text.Length == 0 && txtStatusA1.Text.Length == 0 && txtStatus.Text.Length == 0 && txtNF.Text.Length == 0 && txtDataSaida.Text.Length == 0)
            {
                sql += "select DATEDIFF(DAY, DataEntrada, GETDATE()) as DNP, * from CHAMADOS WHERE CT = '" + lblCT.Text + "'";
                //================verifica se busca tudo ou só no posto=====================
                if (chbBuscarFinalizados.Checked == true)
                {                    
                }
                else
                {
                    sql += " AND Status != 'FINALIZADO'";
                }


              //  sql += "union ";
             //   sql += "select SUBSTRING(H.Data,4,7), E.NumeroSerie, E.Descricao, E.CodPositivo, E.CodViaVarejo, E.OSViaVarejo, H.Status, H.Usuario, H.Data, H.Hora, E.Chamado, E.DataEntrada, E.DiasNoPosto, E.Restauracao from Expedicao E, Historico H where H.OSViaVarejo = E.OSViaVarejo and ";
            }
            else
            {
                sql += "select DATEDIFF(DAY, DataEntrada, GETDATE()) as DNP, * from CHAMADOS where CT = '" + lblCT.Text + "' ";   


                // ============== DESCRICAO.

                if (txtDescricao.Text.Length != 0)
                {
                    sql += " and ";
                    string status = txtDescricao.Text;
                    if (txtDescricao.Text.Contains('!'))
                    {
                        status = txtDescricao.Text.Replace("!", "");
                        //MessageBox.Show(status);
                        if (txtDescricao.Text.Contains('+'))
                        {
                            status = txtDescricao.Text.Replace("+", "%' and Descricao not like '%");
                            status = status.Replace("!", "");
                            //MessageBox.Show(status);
                            sql += "(Descricao not like '%" + status + "%')";
                        }
                        else if (txtDescricao.Text == "!0")
                        {
                            sql += "(Descricao != '' or Descricao is not null)";
                        }
                        else
                        {
                            sql += "Descricao not like '%" + status + "%'";
                        }
                    }
                    else if (txtDescricao.Text == "0")
                    {
                        //status = txtMotivoDevolucao.Text.Replace("0", "");
                        sql += "(Descricao = '' or Descricao is null)";
                    }
                    else if (txtDescricao.Text.Contains('+'))
                    {
                        status = txtDescricao.Text.Replace("+", "%' or Descricao like '%");
                        //MessageBox.Show(status);
                        sql += "(Descricao like '%" + status + "%')";
                    }
                    //sql += "M.Descricao like '%" + txtStatus.Text +  "%'";
                    else
                    {
                        sql += "Descricao like '%" + status + "%'";
                    }
                    
                    //if (txtClassificacao.Text.Length != 0 || txtAcima.Text.Length != 0 || txtData.Text.Length != 0 || txtTipo.Text.Length != 0 || txtStatus.Text.Length != 0 || txtStatusA1.Text.Length != 0 || txtNF.Text.Length != 0 || txtDataSaida.Text.Length != 0)
                    //{
                    //    sql += " and ";
                    //}
                }              
                
                
                // ============== CLASSIFICACAO.

                if (txtClassificacao.Text.Length != 0)
                {
                    sql += " and ";
                    string status = txtClassificacao.Text;
                    if (txtClassificacao.Text.Contains('!'))
                    {
                        status = txtClassificacao.Text.Replace("!", "");
                        //MessageBox.Show(status);                        
                        if (txtClassificacao.Text.Contains('+'))
                        {
                            status = txtClassificacao.Text.Replace("+", "%' and CLASSIFICACAO not like '%");
                            status = status.Replace("!", "");
                            //MessageBox.Show(status);
                            sql += "(CLASSIFICACAO not like '%" + status + "%')";
                        }
                        else if (txtClassificacao.Text == "!0")
                        {
                            sql += "(CLASSIFICACAO != '' or CLASSIFICACAO is not null)";
                        }
                        else
                        {
                            sql += "CLASSIFICACAO not like '%" + status + "%'";
                        }
                    }
                    else if (txtClassificacao.Text == "0")
                    {
                        //status = txtMotivoDevolucao.Text.Replace("0", "");
                        sql += "(CLASSIFICACAO = '' or CLASSIFICACAO is null)";
                    }
                    else if (txtClassificacao.Text.Contains('+'))
                    {
                        status = txtClassificacao.Text.Replace("+", "%' or CLASSIFICACAO like '%");
                        //MessageBox.Show(status);
                        sql += "(CLASSIFICACAO like '%" + status + "%')";
                    }
                    //sql += "M.Status like '%" + txtStatus.Text +  "%'";
                    else
                    {
                        sql += "CLASSIFICACAO like '%" + status + "%'";
                    }

                    //if (txtAcima.Text.Length != 0 || txtData.Text.Length != 0 || txtTipo.Text.Length != 0 || txtStatus.Text.Length != 0 || txtStatusA1.Text.Length != 0 || txtNF.Text.Length != 0 || txtDataSaida.Text.Length != 0)
                    //{
                     //   sql += " and ";
                    //}
                }

                // ============== ACIMA.

                if (txtAcima.Text.Length != 0)
                {
                    sql += " and ";
                    sql += "DATEDIFF(DAY, DataEntrada, GETDATE()) > '" + txtAcima.Text + "'";
                   // if (txtData.Text.Length != 0 || txtTipo.Text.Length != 0 || txtStatus.Text.Length != 0 || txtStatusA1.Text.Length != 0 || txtNF.Text.Length != 0 || txtDataSaida.Text.Length != 0)
                    //{
                    //    sql += " and ";
                    //}
                }

                // ============== DATA.

                if (txtData.Text.Length != 0)
                {
                    sql += " and ";
                    sql += "convert(varchar(10), DataEntrada, 103) like '%" + txtData.Text + "%'";
                    //if (txtTipo.Text.Length != 0 || txtStatus.Text.Length != 0 || txtStatusA1.Text.Length != 0 || txtNF.Text.Length != 0 || txtDataSaida.Text.Length != 0)
                    //{
                     //   sql += " and ";
                    //}
                }

                // ============== TipoEquipEQUIPAMENTO.

                if (txtTipo.Text.Length != 0)
                {
                    sql += " and ";
                    string status = txtTipo.Text;
                    if (txtTipo.Text.Contains('!'))
                    {
                        status = txtTipo.Text.Replace("!", "");
                        //MessageBox.Show(status);
                        if (txtTipo.Text.Contains('+'))
                        {
                            status = txtTipo.Text.Replace("+", "%' and TipoEquip not like '%");
                            status = status.Replace("!", "");
                            //MessageBox.Show(status);
                            sql += "(TipoEquip not like '%" + status + "%')";
                        }
                        else if (txtTipo.Text == "!0")
                        {
                            sql += "(TipoEquip != '' or TipoEquip is not null)";
                        }
                        else
                        {
                            sql += "TipoEquip not like '%" + status + "%'";
                        }
                    }
                    else if (txtTipo.Text == "0")
                    {
                        //status = txtMotivoDevolucao.Text.Replace("0", "");
                        sql += "(TipoEquip = '' or TipoEquip is null)";
                    }
                    else if (txtTipo.Text.Contains('+'))
                    {
                        status = txtTipo.Text.Replace("+", "%' or TipoEquip like '%");
                        //MessageBox.Show(status);
                        sql += "(TipoEquip like '%" + status + "%')";
                    }
                    //sql += "M.TipoEquiplike '%" + txtStatus.Text +  "%'";
                    else
                    {
                        sql += "TipoEquip like '%" + status + "%'";
                    }

                   
                    //sql += "TipoEquiplike '%" + txtTipo.Text + "%'";
                    //if (txtStatus.Text.Length != 0 || txtStatusA1.Text.Length != 0 || txtNF.Text.Length != 0 || txtDataSaida.Text.Length != 0)
                    //{
                    //    sql += " and ";
                    //}
                   
                }

                // ============== STATUS.

                if (txtStatus.Text.Length != 0)
                {
                    //  sql += "Responsavel like '%" + txtUsuario.Text + "%'";
                    sql += " and ";
                    string status = txtStatus.Text;
                    if (txtStatus.Text.Contains('!'))
                    {
                        status = txtStatus.Text.Replace("!", "");
                        //MessageBox.Show(status);
                        if (txtStatus.Text.Contains('+'))
                        {
                            status = txtStatus.Text.Replace("+", "%' and Status not like '%");
                            status = status.Replace("!", "");
                            //MessageBox.Show(status);
                            sql += "(Status not like '%" + status + "%')";
                        }
                        else if (txtStatus.Text == "!0")
                        {
                            sql += "(Status != '' or Status is not null)";
                        }
                        else
                        {
                            sql += "Status not like '%" + status + "%'";
                        }
                    }
                    else if (txtStatus.Text == "0")
                    {
                        //status = txtMotivoDevolucao.Text.Replace("0", "");
                        sql += "(Status = '' or Status is null)";
                    }
                    else if (txtStatus.Text.Contains('+'))
                    {
                        status = txtStatus.Text.Replace("+", "%' or Status like '%");
                        //MessageBox.Show(status);
                        sql += "(Status like '%" + status + "%')";
                    }
                    //sql += "M.Status like '%" + txtStatus.Text +  "%'";
                    else
                    {
                        sql += "Status like '%" + status + "%'";
                    }


                    //=======================
                    //if (txtStatusA1.Text.Length != 0 || txtNF.Text.Length != 0 || txtDataSaida.Text.Length != 0)
                    //{
                    //    sql += " and ";
                    //}
                }




                // ============== STATUS A1.

                if (txtStatusA1.Text.Length != 0)
                {
                    if (txtStatusA1.Text.Length != 0)
                    {
                        sql += " and ";
                        //  sql += "Responsavel like '%" + txtUsuario.Text + "%'";

                        string status = txtStatusA1.Text;
                        if (txtStatusA1.Text.Contains('!'))
                        {
                            status = txtStatusA1.Text.Replace("!", "");
                            //MessageBox.Show(status);
                            if (txtStatusA1.Text.Contains('+'))
                            {
                                status = txtStatusA1.Text.Replace("+", "%' and StatusA1 not like '%");
                                status = status.Replace("!", "");
                                //MessageBox.Show(status);
                                sql += "(StatusA1 not like '%" + status + "%')";
                            }
                            else if (txtStatusA1.Text == "!0")
                            {
                                sql += "(StatusA1 != '' or StatusA1 is not null)";
                            }
                            else
                            {
                                sql += "StatusA1 not like '%" + status + "%'";
                            }
                        }
                        else if (txtStatusA1.Text == "0")
                        {
                            //status = txtMotivoDevolucao.Text.Replace("0", "");
                            sql += "(StatusA1 = '' or StatusA1 is null)";
                        }
                        else if (txtStatusA1.Text.Contains('+'))
                        {
                            status = txtStatusA1.Text.Replace("+", "%' or StatusA1 like '%");
                            //MessageBox.Show(status);
                            sql += "(StatusA1 like '%" + status + "%')";
                        }
                        //sql += "M.Status like '%" + txtStatus.Text +  "%'";
                        else
                        {
                            sql += "StatusA1 like '%" + status + "%'";
                        }



                        // ====================================================
                        //if (txtNF.Text.Length != 0 || txtDataSaida.Text.Length != 0)
                        //{
                         //   sql += " and ";
                        //}
                    }       
                }


                // ============== NOTA FISCAL.
                if (txtNF.Text.Length != 0)
                {
                    sql += " and ";
                    sql += "NotaFiscal like '%" + txtNF.Text + "%'";
                    //if (txtDataSaida.Text.Length != 0)
                    //{
                    //    sql += " and ";
                    //}
                }


                // ============== DATA SAIDA.

                if (txtDataSaida.Text.Length != 0)
                {
                    sql += " and ";
                    sql += "convert(varchar(10), DataSaida, 103) like '%" + txtDataSaida.Text + "%'";
                }


                //================verifica se busca tudo ou só no posto=====================
                if (chbBuscarFinalizados.Checked == true)
                {
                   // sql += groupBy;
                }
                else
                {
                    sql += " and Status != 'FINALIZADO' ";// + groupBy;
                }                
            }

            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chamados");
            dgvConsulta.DataSource = ds.Tables["Chamados"];
            cx.Desconectar();
            int total = 0;
            string totalgeral = dgvConsulta.Rows.Count.ToString();
            //total = dgvConsulta.Rows[1].Cells.Count.ToString();
            total = Convert.ToInt32(totalgeral);
            lblTotal.Text = total.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FazerConsulta();
            FormatarGrid();
        }

        private void txtOS_Enter(object sender, EventArgs e)
        {
            consultar.LimparControles(this);
        }

        private void txtNS_Enter(object sender, EventArgs e)
        {
            consultar.LimparControles(this);
        }

        private void txtChamado_Enter(object sender, EventArgs e)
        {
            consultar.LimparControles(this);
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            txtOS.Text = "";
            txtNS.Text = "";
            txtObjeto.Text = "";
        }

        private void txtData_Enter(object sender, EventArgs e)
        {
            txtOS.Text = "";
            txtNS.Text = "";
            txtObjeto.Text = "";
        }

        private void txtAcima_Enter(object sender, EventArgs e)
        {
            txtOS.Text = "";
            txtNS.Text = "";
            txtObjeto.Text = "";
        }

        private void txtStatus_Enter(object sender, EventArgs e)
        {
            txtOS.Text = "";
            txtNS.Text = "";
            txtObjeto.Text = "";
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            txtOS.Text = "";
            txtNS.Text = "";
            txtObjeto.Text = "";
        }

        private void txtDataHist_Enter(object sender, EventArgs e)
        {
            txtOS.Text = "";
            txtNS.Text = "";
            txtObjeto.Text = "";
        }

        private void txtVarejista_Enter(object sender, EventArgs e)
        {
            txtOS.Text = "";
            txtNS.Text = "";
            txtObjeto.Text = "";
        }
               
        //================================ Buscar pelo Enter ==========================================

        private void txtOS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                FazerConsulta();
                FormatarGrid();
            }  
        }

        private void txtNS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                FazerConsulta();
                FormatarGrid();
            }  
        }

        private void txtChamado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                FazerConsulta();
                FormatarGrid();
            }  
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                FazerConsulta();
                FormatarGrid();
            }  
        }

        private void txtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                FazerConsulta();
                FormatarGrid();
            }  
        }

        private void txtAcima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                FazerConsulta();
                FormatarGrid();
            }  
        }

        private void txtStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                FazerConsulta();
                FormatarGrid();
            }  
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                FazerConsulta();
                FormatarGrid();
            }  
        }

        private void txtDataHist_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                FazerConsulta();
                FormatarGrid();
            }  
        }

        private void txtVarejista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                FazerConsulta();
                FormatarGrid();
            }  
        }

        private void txtChamadoTriagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                FazerConsulta();
                FormatarGrid();
            }  
        }


       //==================== GERAR EXCEL PARA O VAREJISTA ======================

        public void criarExcel()
        {
            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
             //   Excel.Range xlwidthadjust; //used this to adjust width of columns
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Cells[1, 1] = "DIA";
                xlWorkSheet.Cells[1, 2] = "TRIADOR AGENDADO";
                xlWorkSheet.Cells[1, 3] = "GEMCO";
                xlWorkSheet.Cells[1, 4] = "TIPO";
                xlWorkSheet.Cells[1, 5] = "Numero de Série";
                xlWorkSheet.Cells[1, 6] = "Resultado";
                xlWorkSheet.Cells[1, 7] = "Defeito Encontrado";
                xlWorkSheet.Cells[1, 8] = "Lacre interno";
                xlWorkSheet.Cells[1, 9] = "AVARIAS IDENTIFICADAS";
                xlWorkSheet.Cells[1, 10] = "PEÇAS FALTANTES";
                xlWorkSheet.Cells[1, 11] = "CIDADE";
                xlWorkSheet.Cells[1, 12] = "OBSERVAÇÃO";


                var chartRange = xlWorkSheet.get_Range("a1", "l1");
                chartRange.Interior.Color = System.Drawing.Color.Black;
                chartRange.Font.Color = System.Drawing.Color.Yellow;

                int linha = 1;
                for (int i = 0; i < dgvConsulta.RowCount; i++)
                {
                    linha = linha + 1;
                    string DTTriagem = "";                                
                    string CodVarejista = "";
                    string TipoEquip= "";
                    string NS = "";

                    string Resultado = "";
                    string ObsResultado = "";
                    string DefeitoEncontrado = "";
                    string Lacre = "";
                    string Avarias = "";
                    string PecaFaltante = "";
                    string Cidade = "";
                    string Observacao = "";


                    DTTriagem = dgvConsulta.Rows[i].Cells["DataEntrada"].Value.ToString();
                    /*
                    try
                    {                       
                        DTTriagem = DTTriagem.Substring(0, 10);             
                    }
                    catch (Exception)
                    {

                    }
                     */ 
                    CodVarejista = dgvConsulta.Rows[i].Cells["CodVarejo"].Value.ToString();
                    TipoEquip= dgvConsulta.Rows[i].Cells["Tipo"].Value.ToString();
                    NS = dgvConsulta.Rows[i].Cells["NS"].Value.ToString();

                    Resultado = dgvConsulta.Rows[i].Cells["Classificacao"].Value.ToString();
                    ObsResultado = dgvConsulta.Rows[i].Cells["ObsClassificacao"].Value.ToString();

                    // ==== here =========
                    if (Resultado == "FORA DE GARANTIA")
                    {
                        if (ObsResultado == "MAU USO / SUCATA")
                        {
                            Resultado = "OBSOLETO";
                        }
                        else
                        {
                            Resultado = "REMESSA ORCAMENTO";
                        }
                    }
                    else if (Resultado.Contains("DEVOLUÇÃO DE VENDA"))
                    {
                        Resultado = "DEVOLUÇÃO DOA";
                    }
                    else if (Resultado == "REPARO FUNCIONAL - GARANTIA")
                    {
                        Resultado = "REMESSA GARANTIA";
                    }
                    else if (Resultado == "REPARO FUNCIONAL - ORÇAMENTO")
                    {
                        Resultado = "REMESSA ORÇAMENTO";
                    }
                    else if (Resultado == "RETENCAO")
                    {
                        Resultado = "SALDO";
                    }
                    else if (Resultado == "SALDO-A")
                    {
                        Resultado = "SALDO-A";
                    }
                    //=========================




                    DefeitoEncontrado = dgvConsulta.Rows[i].Cells["Funcional"].Value.ToString();
                    Lacre = dgvConsulta.Rows[i].Cells["NumLacre"].Value.ToString();
                    Avarias = dgvConsulta.Rows[i].Cells["Estetico"].Value.ToString();                   
                    PecaFaltante = dgvConsulta.Rows[i].Cells["ItensFaltantes"].Value.ToString();
                    if (PecaFaltante == "COMPLETO")
                    {
                        PecaFaltante = "NÃO";
                    }
                    else
                    {
                        PecaFaltante = "SIM";
                    }
                    Cidade = dgvConsulta.Rows[i].Cells["CIDADE"].Value.ToString();
                    Observacao = dgvConsulta.Rows[i].Cells["ItensFaltantes"].Value.ToString();


                    xlWorkSheet.Cells[linha, 1] = Convert.ToDateTime(DTTriagem);
                    xlWorkSheet.Cells[linha, 2] = "EQUIPE POSITIVO";
                    xlWorkSheet.Cells[linha, 3] = CodVarejista;
                    xlWorkSheet.Cells[linha, 4] = TipoEquip;
                    xlWorkSheet.Cells[linha, 5] = NS;
                    xlWorkSheet.Cells[linha, 6] = Resultado;
                    xlWorkSheet.Cells[linha, 7] = DefeitoEncontrado;
                    xlWorkSheet.Cells[linha, 8] = Lacre;
                    xlWorkSheet.Cells[linha, 9] = Avarias;
                    xlWorkSheet.Cells[linha, 10] = PecaFaltante;
                    xlWorkSheet.Cells[linha, 11] = Cidade;
                    xlWorkSheet.Cells[linha, 12] = Observacao;                  
                }

                xlWorkSheet.Columns.AutoFit();

                var folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                consultar.DataAtual();
                xlWorkBook.SaveAs(folder + "\\Planilha Padrão Magazine " + consultar.dataParaArquivo, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
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
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void btnCriarExcel_Click(object sender, EventArgs e)
        {
            criarExcel();
        }



        //==================== GERAR EXCEL PARA O VAREJISTA ======================

        public void criarExcelChamadoPendente()
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
                xlWorkSheet.Cells[1, 1] = "CHAMADO VISTORIA";
                xlWorkSheet.Cells[1, 2] = "NÚMERO DE SÉRIE";
                xlWorkSheet.Cells[1, 3] = "DATA DA COMPRA";
                xlWorkSheet.Cells[1, 4] = "MODELO";
                xlWorkSheet.Cells[1, 5] = "CÓD. EQUIPAMENTO";
                xlWorkSheet.Cells[1, 6] = "STATUS";
                xlWorkSheet.Cells[1, 7] = "RAZÃO SOCIAL";
                xlWorkSheet.Cells[1, 8] = "CIDADE";
                xlWorkSheet.Cells[1, 9] = "ATP";
                xlWorkSheet.Cells[1, 10] = "CHAMADO";
                xlWorkSheet.Cells[1, 11] = "OK";


                var chartRange = xlWorkSheet.get_Range("a1", "K1");
                chartRange.Interior.Color = System.Drawing.Color.Black;
                chartRange.Font.Color = System.Drawing.Color.White;

                int linha = 1;
                for (int i = 0; i < dgvConsulta.RowCount; i++)
                {
                    linha = linha + 1;
                   // string DTTriagem = "";
                    string CodVarejista = "";
                    string TipoEquip= "";
                    string NS = "";

                    string Resultado = "";
                    string DefeitoEncontrado = "";
                    string Lacre = "";
                    string Avarias = "";
                    string PecaFaltante = "";
                    string ChamadoPai = "";
                    string Observacao = "";

                    string DtCompra = "";
                    string SKU = "";
                    DateTime DtC;


                    DtCompra = dgvConsulta.Rows[i].Cells["DTCompra"].Value.ToString();
                    try
                    {
                        DtCompra = DtCompra.Substring(0, 10);
                        DtC = Convert.ToDateTime(DtCompra);

                    }
                    catch (Exception)
                    {

                    }
                    CodVarejista = dgvConsulta.Rows[i].Cells["CodVarejo"].Value.ToString();
                    TipoEquip= dgvConsulta.Rows[i].Cells["Tipo"].Value.ToString();
                    NS = dgvConsulta.Rows[i].Cells["NS"].Value.ToString();

                    Resultado = dgvConsulta.Rows[i].Cells["Classificacao"].Value.ToString();
                    if (Resultado == "FORA DE GARANTIA")
                    {
                        Resultado = "REMESSA ORÇAMENTO";
                    }
                    if (Resultado == "SALDO-A")
                    {
                        Resultado = "VALIDADO N";
                    }
                    DefeitoEncontrado = dgvConsulta.Rows[i].Cells["Funcional"].Value.ToString();
                    Lacre = dgvConsulta.Rows[i].Cells["NumLacre"].Value.ToString();
                    Avarias = dgvConsulta.Rows[i].Cells["Estetico"].Value.ToString();
                    PecaFaltante = dgvConsulta.Rows[i].Cells["ItensFaltantes"].Value.ToString();


                    if (PecaFaltante == "COMPLETO")
                    {
                        PecaFaltante = "NÃO";
                    }
                    else
                    {
                        PecaFaltante = "SIM";
                    }
                    ChamadoPai = dgvConsulta.Rows[i].Cells["ChamadoPai"].Value.ToString();
                    Observacao = dgvConsulta.Rows[i].Cells["ItensFaltantes"].Value.ToString();
                   
                    SKU = dgvConsulta.Rows[i].Cells["SKU"].Value.ToString();
                    string Varejista = dgvConsulta.Rows[i].Cells["Varejista"].Value.ToString();
                    string Cidade = dgvConsulta.Rows[i].Cells["Cidade"].Value.ToString();
                    if (Varejista == "MagazineLuiza")
                    {
                        Varejista = "MAGAZINE LUIZA S/A";                        
                    }


                    xlWorkSheet.Cells[linha, 1] = ChamadoPai;
                    xlWorkSheet.Cells[linha, 2] = NS;
                    xlWorkSheet.Cells[linha, 3] = Convert.ToDateTime(DtCompra);
                    xlWorkSheet.Cells[linha, 4] = TipoEquip;
                    xlWorkSheet.Cells[linha, 5] = SKU;
                    xlWorkSheet.Cells[linha, 6] = Resultado;
                    xlWorkSheet.Cells[linha, 7] = Varejista;
                    xlWorkSheet.Cells[linha, 8] = Cidade;
                    xlWorkSheet.Cells[linha, 9] = "POSITIVO";
                    xlWorkSheet.Cells[linha, 10] = "";
                    xlWorkSheet.Cells[linha, 11] = "";
                   // xlWorkSheet.Cells[linha, 12] = Observacao;
                }

                xlWorkSheet.Columns.AutoFit();

                var folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                consultar.DataAtual();
                xlWorkBook.SaveAs(folder + "\\CHAMADOS DE VISTORIA " + consultar.dataParaArquivo, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
                Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                //MessageBox.Show("O arquivo Excel foi criado com sucesso. Você pode encontrá-lo em : DESKTOP");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }



        private void btnExcelChamado_Click(object sender, EventArgs e)
        {
            criarExcelChamadoPendente();
        }



        private void btnLoteAllied_Click(object sender, EventArgs e)
        {
           // string sql = "";
            try
            {
                consultar.DataAtual();
                cx.Desconectar();
                string comando1 = "SELECT DISTINCT CIDADE FROM PSREXTERNO_CHAMADOS WHERE chamadopai = '" + txtStatusA1.Text + "'";
                cx.Conectar();
                SqlCommand cd = new SqlCommand();
                cd.Connection = cx.c;
                cd.CommandText = comando1;
                SqlDataReader dr = cd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string Lote = "";
                        Lote = dr["CIDADE"].ToString();
                       // MessageBox.Show(Lote);
                       
                        if (Lote.Length != 0)
                        {
                            string comando2 = "SELECT DISTINCT CLASSIFICACAO FROM PSREXTERNO_CHAMADOS WHERE chamadopai = '" + txtStatusA1.Text + "' AND CIDADE = '" + Lote + "'";
                            cx2.Conectar();
                            SqlCommand cd2 = new SqlCommand();
                            cd2.Connection = cx2.c;
                            cd2.CommandText = comando2;
                            SqlDataReader dr2 = cd2.ExecuteReader();
                            while (dr2.Read())
                            {
                                string Classificacao = "";
                                Classificacao = dr2["CLASSIFICACAO"].ToString();
                              //  MessageBox.Show(Classificacao);
                                
                                string comando3 = "select CODVAREJO, DESCRICAO, COUNT(CODVAREJO) AS QNT  from psrExterno_chamados WHERE ";
                                comando3 += "chamadopai = '" + txtStatusA1.Text + "' AND CIDADE = '" + Lote + "' AND CLASSIFICACAO = '" + Classificacao + "' ";
                                comando3 += "GROUP BY CODVAREJO, DESCRICAO ";
                                cx3.Conectar();
                                SqlCommand cd3 = new SqlCommand();
                                cd3.Connection = cx3.c;
                                cd3.CommandText = comando3;
                                SqlDataReader dr3 = cd3.ExecuteReader();

                                try
                                {
                                    Excel.Application xlApp;
                                    Excel.Workbook xlWorkBook;
                                    Excel.Worksheet xlWorkSheet;
                                   // Excel.Range xlwidthadjust; //used this to adjust width of columns
                                    object misValue = System.Reflection.Missing.Value;

                                    xlApp = new Excel.Application();
                                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                                  //  System.Drawing.Image myImage = System.Drawing.Image.FromFile(img);

                                    //xlWorkSheet.Cells[1, 1] = "POSITIVO";
                            //        var pictureStream = new MemoryStream(File.ReadAllBytes(PositivoPSRExterno.Properties.Resources._038));
                                  //  var pictureStream = pictureBox1.Image;

                                    
                                    
                                  //   xlWorkSheet.Shapes.AddPicture(pic, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 50, 50, 300, 45);



                                    Image image = Properties.Resources.logo1;
                                    Image _platypusLogo;
                                    _platypusLogo = image;
                                    Clipboard.SetDataObject(_platypusLogo, true);
                                    var cellRngImg = xlWorkSheet.Cells[1, 1];
                                    xlWorkSheet.Paste(cellRngImg, _platypusLogo);


                                    /*
                                    Excel.Range oRange = (Excel.Range)xlWorkSheet.Cells[10, 1];
                                    Image oImage = pictureBox1.Image;
                                    System.Windows.Forms.Clipboard.SetDataObject(oImage, true);
                                    xlWorkSheet.Paste(oRange, image);
                                     */
                              

                                    xlWorkSheet.Cells[5, 1] = "FORNECEDOR:";
                                    xlWorkSheet.Cells[5, 2] = "POSITIVO TECNOLOGIA S/A";

                                    xlWorkSheet.Cells[6, 1] = "CLIENTE:";
                                    xlWorkSheet.Cells[6, 2] = "ALLIED BRASIL JUNDIAÍ";

                                    xlWorkSheet.Cells[8, 1] = "LOTE:";
                                    xlWorkSheet.Cells[8, 2] = Lote;
                                    xlWorkSheet.Cells[9, 1] = "CLASSIFICAÇÃO:";
                                    xlWorkSheet.Cells[9, 2] = Classificacao;

                                    xlWorkSheet.Cells[10, 1] = "CHAMADO:";
                                    xlWorkSheet.Cells[10, 2] = txtStatusA1.Text;
                                    xlWorkSheet.Cells[10, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;

                                    xlWorkSheet.Cells[11, 1] = "DATA:";
                                    xlWorkSheet.Cells[11, 2] = consultar.dataNormal;

                                    xlWorkSheet.Cells[13, 1] = "CODIGO";
                                    xlWorkSheet.Cells[13, 2] = "DESCRIÇÃO";
                                    xlWorkSheet.Cells[13, 3] = "QUANTIDADE";

                                    int num = 13;
                                    int qntTotal = 0;
                                    while (dr3.Read())
                                    {
                                        //========================
                                        num = num + 1;
                                        string CODVAREJO = "";
                                        CODVAREJO = dr3["CODVAREJO"].ToString();
                                        xlWorkSheet.Cells[num, 1] = Convert.ToString(CODVAREJO);
                                        string DESCRICAO = "";
                                        DESCRICAO = dr3["DESCRICAO"].ToString();
                                        xlWorkSheet.Cells[num, 2] = DESCRICAO;
                                        string QNT = "";
                                        QNT = dr3["QNT"].ToString();
                                        qntTotal = qntTotal + Convert.ToInt32(QNT);
                                        xlWorkSheet.Cells[num, 3] = QNT;
                                        //========================
                                        //   MessageBox.Show(CODVAREJO + " - " + DESCRICAO + " - " + QNT);
                                    }


                                    xlWorkSheet.Cells[num + 1, 2] = "TOTAL:";
                                    xlWorkSheet.Cells[num + 1, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                                    xlWorkSheet.Cells[num + 1, 2].EntireRow.Font.Bold = true;

                                    xlWorkSheet.Cells[num + 1, 3] = qntTotal;
                                    xlWorkSheet.Cells[num + 1, 3].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                                    xlWorkSheet.Cells[num + 1, 3].EntireRow.Font.Bold = true;

                                    xlWorkSheet.Cells[num + 4, 1] = "ASS. ALLIED:";
                                   // xlWorkSheet.Cells[num + 2, 2].Borders.LineStyle = Excel.XlBordersIndex.xlEdgeBottom;
                                    xlWorkSheet.Cells[num + 4, 2].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 1;



                                    xlWorkSheet.Cells[num + 6, 1] = "ASS. POSITIVO:";
                                    xlWorkSheet.Cells[num + 6, 2].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = XlLineStyle.xlContinuous;
                                 //   xlWorkSheet.Cells[num + 4, 2].Borders.LineStyle = Excel.XlBordersIndex.xlEdgeBottom;

                                    xlWorkSheet.Columns.AutoFit();

                                   

                                    var chartRange = xlWorkSheet.get_Range("a14", "a" + num);
                                    chartRange.NumberFormat = "0000000000000";

                                    var chartRange2 = xlWorkSheet.get_Range("a13", "c13");
                                    chartRange2.EntireRow.Font.Bold = true;
                                    //chartRange2.Interior.Color = ColorTranslator.ToWin32(Color.LightGray);
                                    chartRange2.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                                    var chartRange3 = xlWorkSheet.get_Range("a13", "c" + num);
                                    chartRange3.Borders.LineStyle = 1;
                                    chartRange3.Borders.Weight = 2;
                                    chartRange3.Borders.Color = Color.Black;
                                    chartRange3.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                                    var folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                                    
                                    string arquivo = ""; //endereço onde sera salvo as planilhas                                   
                                    bool existeDiretorio = Directory.Exists(folder + "\\" + txtStatusA1.Text); //verifica se o diretorio existe
                                    if (existeDiretorio == true)
                                    {
                                        //arquivo = folder + "\\ETIQUETAS\\" + txtChamado.Text + ".pdf"; //define o local e o nome do arquivo pdf
                                        arquivo = folder + "\\" + txtStatusA1.Text;
                                    }
                                    else
                                    {
                                        Directory.CreateDirectory(folder + "\\" + txtStatusA1.Text);  // se não existir, cria o diretorio no desktop
                                        arquivo = folder + "\\" + txtStatusA1.Text;
                                        //arquivo = folder + "\\ETIQUETAS\\" + txtChamado.Text + ".pdf"; //define o local e o nome do arquivo pdf
                                    }

                                    xlWorkBook.SaveAs(arquivo + "\\" + Lote + " - " + Classificacao + consultar.dataParaArquivo, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
                                    Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                                    xlWorkBook.Close(true, misValue, misValue);
                                    xlApp.Quit();

                                    releaseObject(xlWorkSheet);
                                    releaseObject(xlWorkBook);
                                    releaseObject(xlApp);

                                 //   MessageBox.Show("O arquivo Excel foi criado com sucesso. Você pode encontrá-lo em : DESKTOP");
                                        
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Erro : " + ex.Message);
                                }

                               // cx.Desconectar();
                              //  dr.Close();

                               // cx2.Desconectar();
                               // dr2.Close();

                                cx3.Desconectar();
                                dr3.Close();
                                //break;
                            }
                            cx2.Desconectar();
                            dr2.Close();

                        }
                    }
                    dr.Close();
                }

            }
            catch (SqlException x)
            {
                MessageBox.Show("FALHA AO LISTAR BAREBONES:\r\n" + x.Message);
            }
            cx.Desconectar();
            MessageBox.Show("O arquivo Excel foi criado com sucesso. Você pode encontrá-lo em : DESKTOP /" + txtStatusA1.Text);
        }

        private void btnCarrefour_Click(object sender, EventArgs e)
        {
            criarExcelCarrefour();
        }

        //==================== GERAR EXCEL PARA O CARREFOUR ======================

        public void criarExcelCarrefour()
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
                xlWorkSheet.Cells[1, 1] = "CLIENTE";
                xlWorkSheet.Cells[1, 2] = "TRIADOR";
                xlWorkSheet.Cells[1, 3] = "P.A";
                xlWorkSheet.Cells[1, 4] = "FORNECEDOR";
                xlWorkSheet.Cells[1, 5] = "DATA";
                xlWorkSheet.Cells[1, 6] = "LOTE DE TRIAGEM";
                xlWorkSheet.Cells[1, 7] = "FILIAL";
                xlWorkSheet.Cells[1, 8] = "LACRE";
                xlWorkSheet.Cells[1, 9] = "O.S";
                xlWorkSheet.Cells[1, 10] = "MODELO";
                xlWorkSheet.Cells[1, 11] = "Nº DE SÉRIE";
                xlWorkSheet.Cells[1, 12] = "ESTETICA";
                xlWorkSheet.Cells[1, 13] = "ACESSÓRIOS FALTANTES";
                xlWorkSheet.Cells[1, 14] = "DEFEITO INFORMADO";
                xlWorkSheet.Cells[1, 15] = "DEFEITO CONSTATADO";
                xlWorkSheet.Cells[1, 16] = "CLASSIFICAÇÃO";
                xlWorkSheet.Cells[1, 17] = "OBSERVAÇÃO";


                var chartRange = xlWorkSheet.get_Range("a1", "q1");
                chartRange.Interior.Color = System.Drawing.Color.Blue;
                chartRange.Font.Color = System.Drawing.Color.Black;

                int linha = 1;
                for (int i = 0; i < dgvConsulta.RowCount; i++)
                {
                    linha = linha + 1;


                    DateTime DtC;

                    string DtTriagem = dgvConsulta.Rows[i].Cells["DTTRIAGEM"].Value.ToString();
                    try
                    {
                        DtTriagem = DtTriagem.Substring(0, 10);
                        DtC = Convert.ToDateTime(DtTriagem);

                    }
                    catch (Exception)
                    {

                    }                                    

                    
                    xlWorkSheet.Cells[linha, 1] = "CARREFOUR";
                    xlWorkSheet.Cells[linha, 2] = dgvConsulta.Rows[i].Cells["TRIADOR"].Value.ToString();
                    xlWorkSheet.Cells[linha, 3] = "POSITIVO";
                    xlWorkSheet.Cells[linha, 4] = "POSITIVO TECNOLOGIA";
                    xlWorkSheet.Cells[linha, 5] = Convert.ToDateTime(DtTriagem);
                    xlWorkSheet.Cells[linha, 6] = "";
                    xlWorkSheet.Cells[linha, 7] = "LOJA ONLINE";
                    xlWorkSheet.Cells[linha, 8] = dgvConsulta.Rows[i].Cells["NumLacre"].Value.ToString();
                    xlWorkSheet.Cells[linha, 9] = dgvConsulta.Rows[i].Cells["Filial"].Value.ToString();
                    xlWorkSheet.Cells[linha, 10] = dgvConsulta.Rows[i].Cells["Descricao"].Value.ToString();
                    xlWorkSheet.Cells[linha, 11] = dgvConsulta.Rows[i].Cells["NS"].Value.ToString();
                    xlWorkSheet.Cells[linha, 12] = dgvConsulta.Rows[i].Cells["Estetico"].Value.ToString();
                    xlWorkSheet.Cells[linha, 13] = dgvConsulta.Rows[i].Cells["ItensFaltantes"].Value.ToString();
                    xlWorkSheet.Cells[linha, 14] = dgvConsulta.Rows[i].Cells["DEFEITORELATADO"].Value.ToString();
                    xlWorkSheet.Cells[linha, 15] = dgvConsulta.Rows[i].Cells["Funcional"].Value.ToString();
                    xlWorkSheet.Cells[linha, 16] = dgvConsulta.Rows[i].Cells["Classificacao"].Value.ToString();
                    xlWorkSheet.Cells[linha, 17] = dgvConsulta.Rows[i].Cells["ObsRetencao"].Value.ToString();
                    // xlWorkSheet.Cells[linha, 12] = Observacao;
                }

                xlWorkSheet.Columns.AutoFit();

                var chartRange3 = xlWorkSheet.get_Range("a1", "q" + linha);
                chartRange3.Borders.LineStyle = 1;
                chartRange3.Borders.Weight = 2;
                chartRange3.Borders.Color = Color.Black;
                chartRange3.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                var folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                consultar.DataAtual();
                xlWorkBook.SaveAs(folder + "\\VISTORIA CARREFOUR " + consultar.dataParaArquivo, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
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
                MessageBox.Show("Erro : " + ex.Message);
            }
        }




       

       
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

        public void criarExcelParaImpressao()
        {
            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
               // Excel.Range xlwidthadjust; //used this to adjust width of columns
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

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


             //   var chartRange = xlWorkSheet.get_Range("a1", "q1");
               // chartRange.Interior.Color = System.Drawing.Color.Blue;
              //  chartRange.Font.Color = System.Drawing.Color.Black;

                int linha = 1;
                for (int i = 0; i < dgvConsulta.RowCount; i++)
                {
                    linha = linha + 1;                                     

                    xlWorkSheet.Cells[linha, 1] = dgvConsulta.Rows[i].Cells["NS"].Value.ToString();
                    xlWorkSheet.Cells[linha, 2] = dgvConsulta.Rows[i].Cells["IMEI1"].Value.ToString();
                    xlWorkSheet.Cells[linha, 3] = dgvConsulta.Rows[i].Cells["IMEI2"].Value.ToString();
                    xlWorkSheet.Cells[linha, 4] = dgvConsulta.Rows[i].Cells["VAREJISTA"].Value.ToString();
                    xlWorkSheet.Cells[linha, 5] = dgvConsulta.Rows[i].Cells["CIDADE"].Value.ToString();
                    xlWorkSheet.Cells[linha, 6] = dgvConsulta.Rows[i].Cells["CLASSIFICACAO"].Value.ToString();
                    xlWorkSheet.Cells[linha, 7] = dgvConsulta.Rows[i].Cells["OBSCLASSIFICACAO"].Value.ToString();
                    xlWorkSheet.Cells[linha, 8] = dgvConsulta.Rows[i].Cells["NF"].Value.ToString();
                    xlWorkSheet.Cells[linha, 9] = dgvConsulta.Rows[i].Cells["CODVAREJO"].Value.ToString();
                    xlWorkSheet.Cells[linha, 10] = dgvConsulta.Rows[i].Cells["CHAMADOPAI"].Value.ToString();
                    xlWorkSheet.Cells[linha, 11] = dgvConsulta.Rows[i].Cells["DESCRICAO"].Value.ToString();
                    xlWorkSheet.Cells[linha, 12] = dgvConsulta.Rows[i].Cells["NUMLACRE"].Value.ToString();

                    //pause para buscar as informações da etiqueta
                    consultar.CodPositivo = dgvConsulta.Rows[i].Cells["SKU"].Value.ToString();
                   // consultar.consultarImpressao();
                    if (consultar.Retorno == "falha")
                    {
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
                    else
                    {
                        TipoEtiqueta = consultar.TipoEtiqueta;
                        CodPositivo = consultar.CodPositivo;
                        EAN = consultar.EAN;
                        DescricaoEan = consultar.DescricaoEan;
                        Anatel = consultar.Anatel;
                        Config1 = consultar.Config1;
                        Config2 = consultar.Config2;
                        Config3 = consultar.Config3;
                        Config4 = consultar.Config4;
                        Config5 = consultar.Config5;
                        Config6 = consultar.Config6;
                        Config7 = consultar.Config7;
                        Config8 = consultar.Config8;
                        Config9 = consultar.Config9;
                        Config10 = consultar.Config10;
                        Config11 = consultar.Config11;
                    }

                    //continuaçãode inserir na planilha
                    xlWorkSheet.Cells[linha, 13] = TipoEtiqueta;
                    xlWorkSheet.Cells[linha, 14] = CodPositivo;
                    xlWorkSheet.Cells[linha, 15] = EAN;
                    xlWorkSheet.Cells[linha, 16] = DescricaoEan;
                    xlWorkSheet.Cells[linha, 17] = Anatel;
                    xlWorkSheet.Cells[linha, 18] = Config1;
                    xlWorkSheet.Cells[linha, 19] = Config2;
                    xlWorkSheet.Cells[linha, 20] = Config3;
                    xlWorkSheet.Cells[linha, 21] = Config4;
                    xlWorkSheet.Cells[linha, 22] = Config5;
                    xlWorkSheet.Cells[linha, 23] = Config6;
                    xlWorkSheet.Cells[linha, 24] = Config7;
                    xlWorkSheet.Cells[linha, 25] = Config8;
                    xlWorkSheet.Cells[linha, 26] = Config9;
                    xlWorkSheet.Cells[linha, 27] = Config10;
                    xlWorkSheet.Cells[linha, 28] = Config11;
                    
                }

                xlWorkSheet.Columns.AutoFit();

                /*
                var chartRange3 = xlWorkSheet.get_Range("a1", "q" + linha);
                chartRange3.Borders.LineStyle = 1;
                chartRange3.Borders.Weight = 2;
                chartRange3.Borders.Color = Color.Black;
                chartRange3.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                 */ 


                string chamadoPai = dgvConsulta.Rows[1].Cells["CHAMADOPAI"].Value.ToString();

                var folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                consultar.DataAtual();
                xlWorkBook.SaveAs(folder + "\\ImpressaoEtiqueta - " + chamadoPai, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
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
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void btnEtiquetas_Click(object sender, EventArgs e)
        {
            criarExcelParaImpressao();
        }

        private void btnAllied_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        
        



    }
}
