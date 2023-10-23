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

namespace CRMagazine
{
    public partial class old_frmAberturaChamados : Form
    {
        public old_frmAberturaChamados()
        {
            InitializeComponent();
        }

        Conexao cx = new Conexao();
        Conexao consulte = new Conexao();

        private void frmAberturaChamados_Load(object sender, EventArgs e)
        {
            ListarTudo();
            FormatarGrid();
        }

        public void FormatarGrid()
        {
            dgvParaAbrir.Columns[0].Visible = false;
            dgvParaAbrir.RowHeadersVisible = false;
            // dgvConsulta.Columns[1].Width = 60;
            //dgvParaAbrir.Columns[1].Width = 200;
            dgvParaAbrir.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvConsulta.ScrollBars = ScrollBars.Vertical;
            dgvParaAbrir.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        }

        public void ListarTudo()
        {
            string sql = "";
            sql += " Select idChamados, NS, DtEntrada as Data From Chamados where Chamado = 'PENDENTE'";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chamados");
            dgvParaAbrir.DataSource = ds.Tables["Chamados"];
            cx.Desconectar();            
            lblTotal.Text = dgvParaAbrir.Rows.Count.ToString();          
            //listar datas     
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void txtEncerramento_TextChanged(object sender, EventArgs e)
        {
            //System.IO.TextReader read = new System.IO.StringReader(txtEncerramento.Text);
            int rows = txtEncerramento.Lines.Length;
            int rowslabel = rows - 1;
            lblTotalEncerrar.Text = rowslabel.ToString();

            /*
            if (txtEncerramento.Text.Length != 0)
            {
                try
                {
                    string[] text1 = new string[rows];
                    lblComando.Text = "";
                    for (int r = 1; r < rows; r++)
                    {

                        if (r == rows - 1)
                        {
                            text1[r] = "'" + read.ReadLine() + "'";
                        }
                        else
                        {
                            text1[r] = "'" + read.ReadLine() + "',\n";
                        }
                        lblComando.Text += text1[r];
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show("ERRO CONCATENAR: \n" + x.Message);
                }
            }
            else
            {
                txtEncerramento.Select();
            }      
             */ 
        }


        private void txtNumeroChamado_TextChanged(object sender, EventArgs e)
        {
            int nrows =  txtNumeroChamado.Lines.Length;
            int rowslabel = nrows - 1;
            lblTotalChamados.Text = rowslabel.ToString();

            
            System.IO.TextReader read = new System.IO.StringReader(txtEncerramento.Text);
            int rows = txtEncerramento.Lines.Length;

            System.IO.TextReader read2 = new System.IO.StringReader(txtNumeroChamado.Text);
            //  int rows2 = textBox3.Lines.Length;

            string[] text1 = new string[rows];
            string[] text2 = new string[rows];

            lblComando.Text = "";
            for (int r = 1; r < rows; r++)
            {
                text1[r] = "'" + read.ReadLine().Trim() + "'";
                text2[r] = "'" + read2.ReadLine().Trim() + "'";
                lblComando.Text += "update Chamados Set Chamado = " + text2[r] + " where NS = " + text1[r] + " and Status != 'FINALIZADO'\n";
            }
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if ((lblTotalEncerrar.Text == lblTotalChamados.Text) && (lblTotalEncerrar.Text != "0"))            
            {                
                AtualizarChamado();
                ListarTudo();
                FormatarGrid();
                lblComando.Text = "";
                txtEncerramento.Text = "";
                txtNumeroChamado.Text = "";
            }
            else
            {
                MessageBox.Show("As quantidades devem ser iguais");
                txtEncerramento.Select();
            }
        }

        public void AtualizarChamado()
        {
            string sql = "";
            //string Chamado = "YES";                  
            try
            {
                //sql += "update MaquinasNoPosto set Chamado = '" + Chamado +  "'  where NumeroSerie IN (" + lblComando.Text + ")";
                sql = lblComando.Text;
                cx.Conectar();
                SqlCommand cd = new SqlCommand();
                cd.Connection = cx.c;
                cd.CommandText = sql;
                cd.ExecuteNonQuery();                
            }
            catch (Exception x)
            {
                MessageBox.Show("ERRO ATUALIZAR CHAMADO ENCERRADO: \n" + x.Message);                
            }
            cx.Desconectar();
        }


        private void lblTotalEncerrar_TextChanged(object sender, EventArgs e)
        {
            if (lblTotalEncerrar.Text == "-1")
            {
                lblTotalEncerrar.Text = "0";
            }
        }

        private void lblTotalChamados_TextChanged(object sender, EventArgs e)
        {
            if (lblTotalChamados.Text == "-1")
            {
                lblTotalChamados.Text = "0";
            }
        }

        private void btnMostrarData_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            for (int i = 0; i < dgvParaAbrir.RowCount; i++)
            {
                string OS = dgvParaAbrir.Rows[i].Cells["OSViaVarejo"].Value.ToString();
                try
                {
                    string comando = "select Data from Historico where Status = 'ENTRADA' and OSViaVarejo = '" + OS + "'";
                    string data = "";
                    cx.Conectar();
                    SqlCommand cd = new SqlCommand();
                    cd.Connection = cx.c;
                    cd.CommandText = comando;
                    SqlDataReader dr = cd.ExecuteReader();
                    if (dr.Read())
                    {
                        data = dr["Data"].ToString();
                        dgvParaAbrir.Rows[i].Cells["Data"].Value = data;
                    }
                    else
                    {
                        dgvParaAbrir.Rows[i].Cells["Data"].Value = "0";
                    }
                    dr.Close();
                }
                catch (SqlException x)
                {
                    MessageBox.Show("Falha ao consultar data do historico: \n" + x.Message);
                }
                cx.Desconectar();
            }
            this.Cursor = Cursors.Default;
        }

       


    }
}
