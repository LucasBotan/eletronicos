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

namespace CRMagazine
{
    public partial class frmConsultaHistorico : Form
    {
        public frmConsultaHistorico(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        
        Conexao cx = new Conexao();
        Conexao cx2 = new Conexao();
        Consulta consultar = new Consulta();


        public void FormatarGrid()
        {
            //dgvConsulta.Columns[0].Visible = false;
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
                            if (j == 8 || j == 10)
                            {
                                string texto = dgvConsulta.Rows[i].Cells[j].Value.ToString();
                                if (texto.Length != 0)
                                {
                                    string confirmadia = texto.Substring(0, 2);
                                    int dia2 = Convert.ToInt32(confirmadia);
                                    if (dia2 < 13)
                                    {
                                        string dia = texto.Substring(3, 2);
                                        string mes = texto.Substring(0, 2);
                                        string ano = texto.Substring(6);
                                        string diapronto = dia + "/" + mes + "/" + ano;
                                        XcelApp.Cells[i + 2, j + 1] = diapronto.ToString();
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
                            }
                            else
                            {
                                XcelApp.Cells[i + 2, j + 1] = dgvConsulta.Rows[i].Cells[j].Value.ToString();
                            }
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
                sql += "select M.NS, M.Descricao, H.Status, H.Usuario, H.Data, H.Hora, H.OS, M.DataEntrada from Chamados M, Historico H where (H.OS = M.OS) and ";
                sql += "M.OS = '" + txtOS.Text + "' and M.CT = '" + lblCT.Text + "'";
               // sql += "union ";
               // sql += "select SUBSTRING(H.Data,4,7), E.NS, E.Descricao, E.CodPositivo, E.CodViaVarejo, E.OSViaVarejo, H.Status, H.Usuario, H.Data, H.Hora, E.Chamado, E.DataEntrada, E.DiasNoPosto, E.Restauracao from Expedicao E, Historico H where H.OSViaVarejo = E.OSViaVarejo and ";
               // sql += "E.OSViaVarejo = '" + txtOS.Text + "' order by SUBSTRING(H.Data,4,7), H.Data, H.Hora";
            }
            else if (txtNS.Text.Length != 0)
            {
                sql += "select M.NS, M.Descricao, H.Status, H.Usuario, H.Data, H.Hora, H.OS, M.DataEntrada from Chamados M, Historico H where (H.OS = M.OS) and ";
                sql += "M.NS = '" + txtNS.Text + "' and M.CT = '" + lblCT.Text + "'";
             //   sql += "union ";
            //    sql += "select SUBSTRING(H.Data,4,7), E.NS, E.Descricao, E.CodPositivo, E.CodViaVarejo, E.OSViaVarejo, H.Status, H.Usuario, H.Data, H.Hora, E.Chamado, E.DataEntrada, E.DiasNoPosto, E.Restauracao from Expedicao E, Historico H where H.OSViaVarejo = E.OSViaVarejo and ";
              //  sql += "E.NS = '" + txtNS.Text + "' order by SUBSTRING(H.Data,4,7), H.Data, H.Hora";
            }
            else if (txtObjeto.Text.Length != 0)
            {
                sql += "select M.NS, M.Descricao, H.Status, H.Usuario, H.Data, H.Hora, H.OS, M.DataEntrada from Chamados M, Historico H where (H.OS = M.OS) and ";
                sql += "M.Objeto = '" + txtObjeto.Text + "' M.and CT = '" + lblCT.Text + "'";
              //  sql += "union ";
              //  sql += "select SUBSTRING(H.Data,4,7), E.NS, E.Descricao, E.CodPositivo, E.CodViaVarejo, E.OSViaVarejo, H.Status, H.Usuario, H.Data, H.Hora, E.Chamado, E.DataEntrada, E.DiasNoPosto, E.Restauracao from Expedicao E, Historico H where H.OSViaVarejo = E.OSViaVarejo and ";
              //  sql += "E.Chamado = '" + txtChamado.Text + "' order by SUBSTRING(H.Data,4,7), H.Data, H.Hora";
            }
            else if (txtData.Text.Length == 0 && txtDescricao.Text.Length == 0 && txtStatus.Text.Length == 0 && txtAcima.Text.Length == 0 && txtDataHist.Text.Length == 0 && txtVarejista.Text.Length == 0 && txtUsuario.Text.Length == 0)
            {
                sql += "select M.NS, M.Descricao, H.Status, H.Usuario, H.Data, H.Hora, H.OS, M.DataEntrada from Chamados M, Historico H where (H.OS = M.OS) and M.CT = '" + lblCT.Text + "' ";
              //  sql += "union ";
             //   sql += "select SUBSTRING(H.Data,4,7), E.NS, E.Descricao, E.CodPositivo, E.CodViaVarejo, E.OSViaVarejo, H.Status, H.Usuario, H.Data, H.Hora, E.Chamado, E.DataEntrada, E.DiasNoPosto, E.Restauracao from Expedicao E, Historico H where H.OSViaVarejo = E.OSViaVarejo and ";
            }
            else
            {
                sql += "select M.NS, M.Descricao, H.Status, H.Usuario, H.Data, H.Hora, H.OS, M.DataEntrada from Chamados M, Historico H where (H.OS = M.OS) and M.CT = '" + lblCT.Text + "' and ";


                // ============== DESCRICAO.

                if (txtDescricao.Text.Length != 0)
                {
                    string status = txtDescricao.Text;
                    if (txtDescricao.Text.Contains('!'))
                    {
                        status = txtDescricao.Text.Replace("!", "");
                        //MessageBox.Show(status);
                        if (txtDescricao.Text.Contains('+'))
                        {
                            status = txtDescricao.Text.Replace("+", "%' and M.Descricao not like '%");
                            status = status.Replace("!", "");
                            //MessageBox.Show(status);
                            sql += "(M.Descricao not like '%" + status + "%')";
                        }
                        else if (txtDescricao.Text == "!0")
                        {
                            sql += "(M.Descricao != '' or M.Descricao is not null)";
                        }
                        else
                        {
                            sql += "M.Descricao not like '%" + status + "%'";
                        }
                    }
                    else if (txtDescricao.Text == "0")
                    {
                        //status = txtMotivoDevolucao.Text.Replace("0", "");
                        sql += "(M.Descricao = '' or M.Descricao is null)";
                    }
                    else if (txtDescricao.Text.Contains('+'))
                    {
                        status = txtDescricao.Text.Replace("+", "%' or M.Descricao like '%");
                        //MessageBox.Show(status);
                        sql += "(M.Descricao like '%" + status + "%')";
                    }
                    //sql += "M.Descricao like '%" + txtStatus.Text +  "%'";
                    else
                    {
                        sql += "M.Descricao like '%" + status + "%'";
                    }

                    
                    if (txtStatus.Text.Length != 0 || txtAcima.Text.Length != 0 || txtData.Text.Length != 0 || txtDataHist.Text.Length != 0 || txtUsuario.Text.Length != 0 || txtVarejista.Text.Length != 0)
                    {
                        sql += " and ";
                    }
                }

                // ============== STATUS.

                if (txtStatus.Text.Length != 0)
                {
                    string status = txtStatus.Text;
                    if (txtStatus.Text.Contains('!'))
                    {
                        status = txtStatus.Text.Replace("!", "");
                        //MessageBox.Show(status);                        
                        if (txtStatus.Text.Contains('+'))
                        {
                            status = txtStatus.Text.Replace("+", "%' and H.Status not like '%");
                            status = status.Replace("!", "");
                            //MessageBox.Show(status);
                            sql += "(H.Status not like '%" + status + "%')";
                        }
                        else if (txtStatus.Text == "!0")
                        {
                            sql += "(H.Status != '' or H.Status is not null)";
                        }
                        else
                        {
                            sql += "H.Status not like '%" + status + "%'";
                        }
                    }
                    else if (txtStatus.Text == "0")
                    {
                        //status = txtMotivoDevolucao.Text.Replace("0", "");
                        sql += "(H.Status = '' or H.Status is null)";
                    }
                    else if (txtStatus.Text.Contains('+'))
                    {
                        status = txtStatus.Text.Replace("+", "%' or H.Status like '%");
                        //MessageBox.Show(status);
                        sql += "(H.Status like '%" + status + "%')";
                    }
                    //sql += "M.Status like '%" + txtStatus.Text +  "%'";
                    else
                    {
                        sql += "H.Status like '%" + status + "%'";
                    }

                    if (txtAcima.Text.Length != 0 || txtData.Text.Length != 0 || txtDataHist.Text.Length != 0 || txtUsuario.Text.Length != 0 || txtVarejista.Text.Length != 0)
                    {
                        sql += " and ";
                    }
                }

                // ============== ACIMA.

                if (txtAcima.Text.Length != 0)
                {
                    sql += "DATEDIFF(DAY, M.DataEntrada, GETDATE()) > '" + txtAcima.Text + "'";
                    if (txtData.Text.Length != 0 || txtDataHist.Text.Length != 0 || txtUsuario.Text.Length != 0 || txtVarejista.Text.Length != 0)
                    {
                        sql += " and ";
                    }
                }

                // ============== DATA.

                if (txtData.Text.Length != 0)
                {
                    sql += "convert(varchar(10), M.DataEntrada, 103) like '%" + txtData.Text + "%'";
                    if (txtDataHist.Text.Length != 0 || txtUsuario.Text.Length != 0 || txtVarejista.Text.Length != 0)
                    {
                        sql += " and ";
                    }
                }

                // ============== DATA HISTORICO.

                if (txtDataHist.Text.Length != 0)
                {
                    sql += "convert(varchar(10), H.Data, 103) like '%" + txtDataHist.Text + "%'";
                    if (txtUsuario.Text.Length != 0 || txtVarejista.Text.Length != 0)
                    {
                        sql += " and ";
                    }
                }

                // ============== USUARIO.

                if (txtUsuario.Text.Length != 0)
                {
                    sql += "H.Usuario like '%" + txtUsuario.Text + "%'";
                    if (txtVarejista.Text.Length != 0)
                    {
                        sql += " and ";
                    }
                }

                // ============== VAREJISTA.

                if (txtVarejista.Text.Length != 0)
                {
                   // sql += "M.Varejista like '%" + txtVarejista.Text + "%'";


                    string status = txtVarejista.Text;
                    if (txtVarejista.Text.Contains('!'))
                    {
                        status = txtVarejista.Text.Replace("!", "");
                        //MessageBox.Show(status);                        
                        if (txtVarejista.Text.Contains('+'))
                        {
                            status = txtVarejista.Text.Replace("+", "%' and M.Varejista not like '%");
                            status = status.Replace("!", "");
                            //MessageBox.Show(status);
                            sql += "(M.Varejista not like '%" + status + "%')";
                        }
                        else if (txtVarejista.Text == "!0")
                        {
                            sql += "(M.Varejista != '' or M.Varejista is not null)";
                        }
                        else
                        {
                            sql += "M.Varejista not like '%" + status + "%'";
                        }
                    }
                    else if (txtVarejista.Text == "0")
                    {
                        //status = txtMotivoDevolucao.Text.Replace("0", "");
                        sql += "(M.Varejista = '' or M.Varejista is null)";
                    }
                    else if (txtVarejista.Text.Contains('+'))
                    {
                        status = txtVarejista.Text.Replace("+", "%' or M.Varejista like '%");
                        //MessageBox.Show(status);
                        sql += "(M.Varejista like '%" + status + "%')";
                    }
                    //sql += "M.Status like '%" + txtStatus.Text +  "%'";
                    else
                    {
                        sql += "M.Varejista like '%" + status + "%'";
                    }

                  //  if (txtAcima.Text.Length != 0 || txtData.Text.Length != 0 || txtDataHist.Text.Length != 0 || txtUsuario.Text.Length != 0 || txtVarejista.Text.Length != 0)
                    //{
                      //  sql += " and ";
                 //   }










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


        private void chbDescContem_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDescContem.Checked)
            {
                chbDescContem.Text = "Não Contém";
            }
            else
            {
                chbDescContem.Text = "Contém";
            }
        }

        private void frmConsultaHistorico_Load(object sender, EventArgs e)
        {

        }

        

        



    }
}
