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
    public partial class frmReparoChamadoemPP : Form
    {
        public frmReparoChamadoemPP(string texto, string CT)
        {
            InitializeComponent();
            lblUsuario.Text = texto;
            lblCT.Text = CT;
        }

        private void frmReparoChamadoemPP_Load(object sender, EventArgs e)
        {           
            ListarChamadoAguardo();
            FormatarGrid();
            FormatarGridPP();
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();

        public void FormatarGrid()
        {
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            Image imagem = pictureBox2.Image;
            img.Image = imagem;
            dgvAguardo.Columns.Add(img);
            img.HeaderText = "PESQUISAR";
            img.Name = "PESQUISAR";
            dgvAguardo.RowHeadersVisible = false;
            // dgvConsulta.Columns[1].Width = 80;
            //
        }

        public void FormatarGridPP()
        {
            dgvPP.RowHeadersVisible = false;
            dgvPP.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void ListarChamadoAguardo()
        {
            string sql = "select OS, NS, Descricao, Status, DataEntrada, DATEDIFF(DAY, DataEntrada, GETDATE()) as DiasNoPosto ";
            sql += "from Chamados where Status = 'PP' AND Responsavel = '" + lblUsuario.Text + "' and CT = '" + lblCT.Text + "'";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chamados");
            dgvAguardo.DataSource = ds.Tables["Chamados"];
            cx.Desconectar();
            lblTotalChamadoAguardo.Text = dgvAguardo.Rows.Count.ToString();
        }


        public void BuscarPecasApontadas(string Chamado)
        {
            string sql = "";
            sql += "select * from AguardoBackup where Chamado = '" + Chamado + "' and status = 'PENDENTE' and CT = '" + lblCT.Text + "'";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chamados");
            dgvPP.DataSource = ds.Tables["Chamados"];
            cx.Desconectar();

            /*
            string sql = "";
            sql += "select QPCT.KURZTEXT AS STAUTS, ";
            sql += "convert(numeric, QMMA.QMNUM) AS CHAMADO, ";
            sql += "convert(numeric, QMMA.MATNR) AS [PEÇA SOLICITADA], ";
            sql += "MARA.MAKTX as DESCRICAO ";
            sql += "from QMMA, QPCT, MARA ";
            sql += "where ";
            sql += "MARA.MATNR = QMMA.MATNR AND ";
            sql += "QPCT.CODE = QMMA.MNCOD and QPCT.CODEGRUPPE = QMMA.MNGRP ";
            sql += "and QPCT.KURZTEXT in ('PEÇA SOLICITADA', 'POSIC C/ PEDIDO DE PEÇAS FORA COMPOSIÇÃO', 'ORÇAMENTO') ";
            sql += "AND QMMA.QMNUM = '0" + Chamado + "'";
            cx.ConectarSAP();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chamados");
            dgvPP.DataSource = ds.Tables["Chamados"];
            cx.Desconectar();
             */ 
        }

        private void dgvAguardo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string Chamado = dgvAguardo.Rows[e.RowIndex].Cells["OS"].Value.ToString();            

                if (dgvAguardo.Columns[e.ColumnIndex].Name == "PESQUISAR")
                {
                    if (MessageBox.Show("DESEJA VISUALIZAR PEÇAS? ", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        lblChamado.Text = Chamado;
                        BuscarPecasApontadas(Chamado);
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }



    }
}
