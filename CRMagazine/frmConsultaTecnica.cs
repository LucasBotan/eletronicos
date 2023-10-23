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
    public partial class frmConsultaTecnica : Form
    {
        public frmConsultaTecnica(string CT)
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

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("0 = VAZIO\r\n!  = NÃO CONTÉM\r\n+ = CONCATENAR PESQUISA\r\n\r\nPARA 'DIAS' UTILIZE:\r\n< OU > para maior ou menor \r\n");
        }

        //=========================================NOVA PARTE=================================================

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
            consultar.DataAtual();
            string data = consultar.data.ToString();
            string hoje = data.Substring(6, 4) + data.Substring(3, 2) + data.Substring(0, 2);
            string sql = "";
            string select = "";
            string groupBy = "";

            select = " select  Tecnico, OS, NS, Descricao, SKU, DataReparo, Defeito, CodPeca, DescPeca from Tecnica where CT = '" + lblCT.Text + "' ";
            groupBy = "group by Tecnico, OS, NS, Descricao, SKU, DataReparo, Defeito, CodPeca, DescPeca";
                  

            if (txtOS.Text.Length != 0)
            {
                sql += select;
                sql += " AND OS = '" + txtOS.Text + "'";
                sql += groupBy;
            }
            else if (txtNS.Text.Length != 0)
            {
                sql += select;
                sql += " AND NS = '" + txtNS.Text + "'";
                sql += groupBy;
            }
            else if (txtObjeto.Text.Length != 0)
            {
                sql += select;
                sql += " AND Objeto = '" + txtObjeto.Text + "'";
                sql += groupBy;
            }
            else if (txtDataReparo.Text.Length == 0 && txtDescricao.Text.Length == 0 && txtUsuario.Text.Length == 0 && txtseguradora.Text.Length == 0)
            {
                sql += select;
                sql += " AND OS != '' ";               
                sql += groupBy;               
            }
            else
            {
                sql += select;                
                //====================== INICIO DAS CONDIÇÕES DO WHERE =========================
                //============================== DESCRICAO =====================================
                if (txtDescricao.Text.Length != 0)
                {
                    sql += " AND ";
                    string status = txtDescricao.Text;
                    if (txtDescricao.Text.Contains('!'))
                    {
                        status = txtDescricao.Text.Replace("!", "");
                        if (txtDescricao.Text.Contains('+'))
                        {
                            status = txtDescricao.Text.Replace("+", "%' and Descricao not like '%");
                            status = status.Replace("!", "");
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
                        sql += "(Descricao = '' or Descricao is null)";
                    }
                    else if (txtDescricao.Text.Contains('+'))
                    {
                        status = txtDescricao.Text.Replace("+", "%' or Descricao like '%");
                        sql += "(Descricao like '%" + status + "%')";
                    }
                    else
                    {
                        sql += "Descricao like '%" + status + "%'";
                    }
                    //if (txtDataReparo.Text.Length != 0 || txtUsuario.Text.Length != 0 || txtseguradora.Text.Length != 0 )
                    //{
                    //    sql += " and ";
                    //}
                }
                //============================== Usuario =====================================
                if (txtUsuario.Text.Length != 0)
                {
                    sql += " AND ";
                    string status = txtUsuario.Text;
                    if (txtUsuario.Text.Contains('!'))
                    {
                        status = txtUsuario.Text.Replace("!", "");
                        if (txtUsuario.Text.Contains('+'))
                        {
                            status = txtUsuario.Text.Replace("+", "%' and Tecnico not like '%");
                            status = status.Replace("!", "");
                            sql += "(Tecnico not like '%" + status + "%')";
                        }
                        else if (txtUsuario.Text == "!0")
                        {
                            sql += "(Tecnico != '' or Tecnico is not null)";
                        }
                        else
                        {
                            sql += "Tecnico not like '%" + status + "%'";
                        }
                    }
                    else if (txtUsuario.Text == "0")
                    {
                        sql += "(Tecnico = '' or Tecnico is null)";
                    }
                    else if (txtUsuario.Text.Contains('+'))
                    {
                        status = txtUsuario.Text.Replace("+", "%' or Tecnico like '%");
                        sql += "(Tecnico like '%" + status + "%')";
                    }
                    else
                    {
                        sql += "Tecnico like '%" + status + "%'";
                    }

                    //if (txtDataReparo.Text.Length != 0 || txtseguradora.Text.Length != 0)
                    //{
                    //    sql += " and ";
                    //}
                }
               
                //============================== DATA =====================================
                if (txtDataReparo.Text.Length != 0)
                {
                    sql += " AND ";
                    sql += "convert(varchar(10), DataReparo, 103) like '%" + txtDataReparo.Text + "%'";
                    //if (txtseguradora.Text.Length != 0)
                    //{
                     //   sql += " and ";
                    //}
                }
                //============================== SEGURADORA/ EVENTO =====================================
                if (txtseguradora.Text.Length != 0)
                {
                    sql += " AND ";
                    string status = txtseguradora.Text;
                    if (txtseguradora.Text.Contains('!'))
                    {
                        status = txtseguradora.Text.Replace("!", "");
                        if (txtseguradora.Text.Contains('+'))
                        {
                            status = txtseguradora.Text.Replace("+", "%' and Seguradora not like '%");
                            status = status.Replace("!", "");
                            sql += "(Seguradora not like '%" + status + "%')";
                        }
                        else if (txtseguradora.Text == "!0")
                        {
                            sql += "(Seguradora != '' or Seguradora is not null)";
                        }
                        else
                        {
                            sql += "Seguradora not like '%" + status + "%'";
                        }
                    }
                    else if (txtseguradora.Text == "0")
                    {
                        sql += "(Seguradora = '' or Seguradora is null)";
                    }
                    else if (txtseguradora.Text.Contains('+'))
                    {
                        status = txtseguradora.Text.Replace("+", "%' or Seguradora like '%");
                        sql += "(Seguradora like '%" + status + "%')";
                    }
                    else
                    {
                        sql += "Seguradora like '%" + status + "%'";
                    }

                    /*
                    if (txtDiasNaPosicao.Text.Length != 0 || txtLocalDeGuarda.Text.Length != 0 || txtImagem.Text.Length != 0)
                    {
                        sql += " and ";
                    
                     */ 
                }

                sql += groupBy;

                //============================== FIM =====================================

            }
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chamado");
            dgvConsulta.DataSource = ds.Tables["Chamado"];
            cx.Desconectar();
            lblTotal.Text = dgvConsulta.Rows.Count.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FazerConsulta();
            FormatarGrid();
        }

        private void txtChamado_Enter(object sender, EventArgs e)
        {
            consultar.LimparControles(this);
        }

        private void txtNS_Enter(object sender, EventArgs e)
        {
            consultar.LimparControles(this);
        }

        private void txtObjeto_Enter(object sender, EventArgs e)
        {
            consultar.LimparControles(this);
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
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

        private void txtDataReparo_Enter(object sender, EventArgs e)
        {
            txtOS.Text = "";
            txtNS.Text = "";
            txtObjeto.Text = "";
        }

        private void txtseguradora_Enter(object sender, EventArgs e)
        {
            txtOS.Text = "";
            txtNS.Text = "";
            txtObjeto.Text = "";
        }

        private void txtChamado_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtObjeto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDataReparo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtseguradora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                FazerConsulta();
                FormatarGrid();
            }      
        }

        private void frmConsultaTecnica_Load(object sender, EventArgs e)
        {

        }



       

       
    }
}
