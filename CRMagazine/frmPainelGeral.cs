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
    public partial class frmPainelGeral : Form
    {
        public frmPainelGeral(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();

        private void frmPainelGeral_Load(object sender, EventArgs e)
        {
            FormatarGrid();
        }

        public void FormatarGrid()
        {
            dgvGeral.AutoResizeColumns();
            dgvGeral.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;       
            dgvGeral.RowHeadersVisible = false;
        }

        public void DataHoje(out string hoje)
        {
            consulta.DataAtual();
            string data = consulta.dataNormal;
            hoje = data.Substring(6, 4) + data.Substring(3, 2) + data.Substring(0, 2);
           // MessageBox.Show(hoje);
        }

        public void Listar()
        {
            string Tipo = "";
            /*
            if (cbxTipoEquip.Text == "INFO")
            {
                Tipo = "'NOTEBOOK', 'DESKTOP', 'UNION', 'TABLET', 'MONITOR'";
            }
            else if (cbxTipoEquip.Text == "SMART")
            {
                Tipo = "'SMART'";
            }
            else if (cbxTipoEquip.Text == "FEATURE")
            {
                Tipo = "'FEATURE'";
            }            
            else if (cbxTipoEquip.Text == "TODOS")
            {
                Tipo = "'NOTEBOOK', 'DESKTOP', 'UNION', 'TABLET', 'MONITOR', 'SMART', 'NADA'";
            }
             */
            if (cbxTipoEquip.Text == "VIAVAREJO")
            {
                Tipo = "'VIAVAREJO'";
            }
            else if (cbxTipoEquip.Text == "CNOVA")
            {
                Tipo = "'CNOVA'";
            }
            else if (cbxTipoEquip.Text == "MULTIVAREJO")
            {
                Tipo = "'MULTIVAREJO'";
            }
            else if (cbxTipoEquip.Text == "TODOS")
            {
                Tipo = "'VIAVAREJO', 'CNOVA', 'MULTIVAREJO'";
            }

            string hoje = "";
            DataHoje(out hoje);
            string sql = "";
            sql += "Select M.OS, M.NS, DATEDIFF(DAY, DataEntrada, GETDATE()) as DPosto, ";
            sql += " DATEDIFF(day,MAX(substring(convert(varchar(10),H.Data),7,4)+substring(convert(varchar(10),H.Data),4,2)+substring(convert(varchar(10),H.Data),1,2)),'" + hoje + "') as DPosicao, ";
            sql += " Descricao, Varejista from Chamados M, Historico H where M.Status = '" + cbxStatus.Text + "' and ";
            sql += " Varejista in ( " + Tipo + ") and H.OS = M.OS and M.CT = '" + lblCT.Text + "' "; // and H.Status = 'REPARO' ";
            sql += " group by M.OS, M.NS, M.DataEntrada, M.Descricao, Varejista ";
            sql += " order by M.DataEntrada asc ";

            //   sql += "Select Historico, NS, DiasNoPosto as Dias, Descricao from Chamados where Status like '%RUNIN' and Descricao not like '%CELULAR%' order by DiasNoPosto desc";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chamados");
            dgvGeral.DataSource = ds.Tables["Chamados"];
            txtTotal.Text = dgvGeral.Rows.Count.ToString();
            cx.Desconectar();
            FormatarGrid();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            if (cbxStatus.Text.Length == 0 || cbxTipoEquip.Text.Length == 0)
            {
                MessageBox.Show("PREENCHA OS DOIS CAMPOS.");
            }
            else
            {
                Listar();
                MudarCores();
            }            
        }

        public void MudarCores()
        {
            int vermelho;
            int amarelo1;
            int amarelo2;
            if (cbxStatus.Text == "REPARO")
            {
                vermelho = 4;
                amarelo1 = 1;
                amarelo2 = 0;
            }
            else
            {
                vermelho = 20;
                amarelo1 = 15;
                amarelo2 = 19;
            }           
            if (dgvGeral.RowCount > 0)
            {
                for (int i = 0; i < dgvGeral.RowCount; i++)
                {                    
                    int Dias = Convert.ToInt32(dgvGeral.Rows[i].Cells["DPosto"].Value);
                    if (Dias >= vermelho)
                    {
                        dgvGeral.Rows[i].Cells["OS"].Style.BackColor = Color.Red;
                    }
                    else if (Dias <= amarelo2 && Dias >= amarelo1)
                    {
                        dgvGeral.Rows[i].Cells["OS"].Style.BackColor = Color.Yellow;
                    }
                    else
                    {
                        dgvGeral.Rows[i].Cells["OS"].Style.BackColor = Color.Green;
                    }
                }
               // dgvGeral.Rows[0].Cells["Descricao"].Selected = true;
                dgvGeral.Rows[0].Cells["OS"].Selected = false;
            }

        }

        private void cbxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTipoEquip.Text == "VIAVAREJO")
            {
                label1.Text = "VIAVAREJO";
            }
            else if (cbxTipoEquip.Text == "CNOVA")
            {
                label1.Text = "CNOVA";
            }
            else if (cbxTipoEquip.Text == "MULTIVAREJO")
            {
                label1.Text = "MULTIVAREJO";
            }
            else
            {
                label1.Text = "GERAL";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Listar();            
            MudarCores();
        }

        private void dgvGeral_SelectionChanged(object sender, EventArgs e)
        {           
            lblSelecionados.Text = dgvGeral.SelectedCells.Count.ToString();
        }

        /*
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dgvGeral.MultiSelect = true;
            label2.Text = dgvGeral.SelectedCells.Count.ToString();
        }
         */ 


    }
}
