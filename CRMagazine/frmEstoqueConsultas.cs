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
    public partial class frmEstoqueConsultas : Form
    {
        public frmEstoqueConsultas(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }
        
        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();

        private void frmEstoqueConsultas_Load(object sender, EventArgs e)
        {
            //FormatarGrid();
        }

        public string texto = "";
        public string opcao = "";
        public string tipo = "";


        public void FormatarGrid()
        {
            if (dgvConsulta.RowCount > 0)
            {
                //dgvConsulta.AutoResizeColumns();
                dgvConsulta.Columns[0].Visible = false;
                dgvConsulta.RowHeadersVisible = false;
                // dgvConsulta.Columns[1].Width = 80;
                //dgvConsulta.Columns[2].Width = 80;
                //dgvConsulta.Columns[3].Width = 200;
                dgvConsulta.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvConsulta.ScrollBars = ScrollBars.Vertical;
                //dgvConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            }           
        }


        public void ListarTudo()
        {
            string sql = "";
            sql += " Select idCod, Codigo, Descricao, Quantidade, Posicao from Estoque WHERE CT = '" + lblCT.Text + "'";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Estoque");
            dgvConsulta.DataSource = ds.Tables["Estoque"];
            cx.Desconectar();
            int total = 0;
            string totalgeral = dgvConsulta.Rows.Count.ToString();
            total = Convert.ToInt32(totalgeral);
            lblTotal.Text = total.ToString();
        }



        public void Listar()
        {
            string sql = "";
            if (rbtCodigo.Checked == true)
            {
                opcao = "Codigo";
                tipo = "exato";
            }
            else if (rbtDescricao.Checked == true)
            {
                opcao = "Descricao";
                tipo = "parte";
            }
            else if (rbtPOSICAO.Checked == true)
            {
                opcao = "Posicao";
                tipo = "exato";
            }
            else if (rbtBarebone.Checked == true)
            {
                opcao = "Barebone";
                tipo = "parte";
            }
            else
            {
                MessageBox.Show("Selecionar uma Opção");
            }
            if (tipo == "exato")
            {
                sql = "";
                sql += " Select idCod, Codigo, Descricao, Quantidade, Posicao from Estoque where " + opcao + " = '" + txtTexto.Text + "' and CT = '" + lblCT.Text + "'";
            }
            else
            {
                sql = "";
                sql += " Select idCod, Codigo, Descricao, Quantidade, Posicao from Estoque where " + opcao + " like '%" + txtTexto.Text + "%' and CT = '" + lblCT.Text + "'";
            }            
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Estoque");
            dgvConsulta.DataSource = ds.Tables["Estoque"];
            cx.Desconectar();
            int total = 0;
            string totalgeral = dgvConsulta.Rows.Count.ToString();
            total = Convert.ToInt32(totalgeral);
            lblTotal.Text = total.ToString();
        }


        public void ListarNew()
        {
            string sql = "";
            string select = "select idCod, Codigo, Descricao, Quantidade, Posicao from Estoque where Codigo is not null and CT = '" + lblCT.Text + "' ";
            string orderby = " order by Quantidade desc";

            string NaoMostarZerados = "";
            if(chbMostrarQntZero.Checked)
            {
                NaoMostarZerados = "";
            }
            else
            {
                NaoMostarZerados = " and Quantidade > 0";
            }
            

            if (txtCodigo.Text.Length == 0 && txtDescParte1.Text.Length == 0 && txtDescParte2.Text.Length == 0 && txtPosicao.Text.Length == 0 && txtBarebone.Text.Length == 0)
            {
                if (MessageBox.Show("DESEJA CONSULTAR TUDO?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sql += select;
                    sql += NaoMostarZerados;
                    sql += orderby;
                }
                else
                {
                    sql = "";
                }
            }
            else
            {
                sql += select;               
                //====================== INICIO DAS CONDIÇÕES DO WHERE =========================
                //============================== CODIGO =====================================
                if (txtCodigo.Text.Length != 0)
                {
                    sql += " and ";
                    string status = txtCodigo.Text;
                    sql += "Codigo = '" + status + "'";
                }



                //=========================== DESCRICAO PARTE 1 ================================
                if (txtDescParte1.Text.Length != 0)
                {
                    sql += " and ";

                    string status = txtDescParte1.Text;
                    if (txtDescParte1.Text.Contains('!'))
                    {
                        status = txtDescParte1.Text.Replace("!", "");
                        if (txtDescParte1.Text.Contains('+'))
                        {
                            status = txtDescParte1.Text.Replace("+", "%' and Descricao not like '%");
                            status = status.Replace("!", "");
                            sql += "(Descricao not like '%" + status + "%')";
                        }
                        else if (txtDescParte1.Text == "!0")
                        {
                            sql += "(Descricao != '' or Descricao is not null)";
                        }
                        else
                        {
                            sql += "Descricao not like '%" + status + "%'";
                        }
                    }
                    else if (txtDescParte1.Text == "0")
                    {
                        sql += "(Descricao = '' or Descricao is null)";
                    }
                    else if (txtDescParte1.Text.Contains('+'))
                    {
                        status = txtDescParte1.Text.Replace("+", "%' or Descricao like '%");
                        sql += "(Descricao like '%" + status + "%')";
                    }
                    else
                    {
                        sql += "Descricao like '%" + status + "%'";
                    }
                }

                //=========================== DESCRICAO PARTE 2 ================================
                if (txtDescParte2.Text.Length != 0)
                {
                    sql += " and ";

                    string status = txtDescParte2.Text;
                    if (txtDescParte2.Text.Contains('!'))
                    {
                        status = txtDescParte2.Text.Replace("!", "");
                        if (txtDescParte2.Text.Contains('+'))
                        {
                            status = txtDescParte2.Text.Replace("+", "%' and Descricao not like '%");
                            status = status.Replace("!", "");
                            sql += "(Descricao not like '%" + status + "%')";
                        }
                        else if (txtDescParte2.Text == "!0")
                        {
                            sql += "(Descricao != '' or Descricao is not null)";
                        }
                        else
                        {
                            sql += "Descricao not like '%" + status + "%'";
                        }
                    }
                    else if (txtDescParte2.Text == "0")
                    {
                        sql += "(Descricao = '' or Descricao is null)";
                    }
                    else if (txtDescParte2.Text.Contains('+'))
                    {
                        status = txtDescParte2.Text.Replace("+", "%' or Descricao like '%");
                        sql += "(Descricao like '%" + status + "%')";
                    }
                    else
                    {
                        sql += "Descricao like '%" + status + "%'";
                    }
                }

                //=========================== POSIÇÃO ================================
                if (txtPosicao.Text.Length != 0)
                {
                    sql += " and ";

                    string status = txtPosicao.Text;
                    if (txtPosicao.Text.Contains('!'))
                    {
                        status = txtPosicao.Text.Replace("!", "");
                        if (txtPosicao.Text.Contains('+'))
                        {
                            status = txtPosicao.Text.Replace("+", "%' and Posicao not like '%");
                            status = status.Replace("!", "");
                            sql += "(Posicao not like '%" + status + "%')";
                        }
                        else if (txtPosicao.Text == "!0")
                        {
                            sql += "(Posicao != '' or Posicao is not null)";
                        }
                        else
                        {
                            sql += "Posicao not like '%" + status + "%'";
                        }
                    }
                    else if (txtPosicao.Text == "0")
                    {
                        sql += "(Posicao = '' or Posicao is null)";
                    }
                    else if (txtPosicao.Text.Contains('+'))
                    {
                        status = txtPosicao.Text.Replace("+", "%' or Posicao like '%");
                        sql += "(Posicao like '%" + status + "%')";
                    }
                    else
                    {
                        sql += "Posicao like '%" + status + "%'";
                    }
                }

                //=========================== BAREBONE ================================
                if (txtBarebone.Text.Length != 0)
                {
                    sql += " and ";

                    string status = txtBarebone.Text;
                    if (txtBarebone.Text.Contains('!'))
                    {
                        status = txtBarebone.Text.Replace("!", "");
                        if (txtBarebone.Text.Contains('+'))
                        {
                            status = txtBarebone.Text.Replace("+", "%' and Barebone not like '%");
                            status = status.Replace("!", "");
                            sql += "(Barebone not like '%" + status + "%')";
                        }
                        else if (txtBarebone.Text == "!0")
                        {
                            sql += "(Barebone != '' or Barebone is not null)";
                        }
                        else
                        {
                            sql += "Barebone not like '%" + status + "%'";
                        }
                    }
                    else if (txtBarebone.Text == "0")
                    {
                        sql += "(Barebone = '' or Barebone is null)";
                    }
                    else if (txtBarebone.Text.Contains('+'))
                    {
                        status = txtBarebone.Text.Replace("+", "%' or Barebone like '%");
                        sql += "(Barebone like '%" + status + "%')";
                    }
                    else
                    {
                        sql += "Barebone like '%" + status + "%'";
                    }
                }

                sql += NaoMostarZerados;
                sql += orderby;
            }

            if(sql.Length > 0)
            {
                //MessageBox.Show(sql);
                cx.Conectar();
                SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
                DataSet ds = new DataSet();
                da.Fill(ds, "Estoque");
                dgvConsulta.DataSource = ds.Tables["Estoque"];
                cx.Desconectar();
                int total = 0;
                string totalgeral = dgvConsulta.Rows.Count.ToString();
                total = Convert.ToInt32(totalgeral);
                lblTotal.Text = total.ToString();
            }     
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //Listar();
            ListarNew();
            FormatarGrid();
        }

        private void btnTudo_Click(object sender, EventArgs e)
        {
            ListarTudo();
            FormatarGrid();
        }

        public void gerarexcel2()
        {
            if (dgvConsulta.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();

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
                            XcelApp.Cells[i + 2, j + 1] = dgvConsulta.Rows[i].Cells[j].Value.ToString();
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            gerarexcel2();
        }


        ToolTip t = new ToolTip();

        private void btnExcel_MouseEnter(object sender, EventArgs e)
        {
            t.SetToolTip(this.btnExcel, "Gerar planilha de Excel");
        }

        private void btnTudo_MouseEnter(object sender, EventArgs e)
        {
            t.SetToolTip(this.btnTudo, "Listar tudo em estoque");
        }

        private void btnLimparTela_Click(object sender, EventArgs e)
        {
            consulta.LimparControles(this);
            txtCodigo.Select();
        }

    }
}
