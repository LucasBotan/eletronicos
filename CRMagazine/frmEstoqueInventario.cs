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
    public partial class frmEstoqueInventario : Form
    {
        public frmEstoqueInventario(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();

        private void frmEstoqueInventario_Load(object sender, EventArgs e)
        {
            FormatarGridAoIniciar();
        }

        public void FormatarGridAoIniciar()
        {
            dgvConsulta.RowHeadersVisible = false;
            dgvConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            dgvConsulta.AutoResizeColumns();

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            Image imagem = pictureBox1.Image;
            img.Image = imagem;
            dgvConsulta.Columns.Add(img);
            img.HeaderText = "BUSCAR";
            img.Name = "BUSCAR";
            dgvConsulta.Columns["BUSCAR"].Width = 60;
        }

        public void FormatarGrid()
        {
            dgvConsulta.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvConsulta.Columns["idCod"].Visible = false;
        }

        public void ListarTudo()
        {
            string sql = "";
            sql += " Select idCod, Codigo, Descricao, Quantidade, Posicao From Estoque where Codigo = '" + txtCodigo.Text + "' and CT = '" + lblCT.Text + "'";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Estoque");
            dgvConsulta.DataSource = ds.Tables["Estoque"];
            cx.Desconectar();
            FormatarGrid();
           
            dgvConsulta.Columns["BUSCAR"].Visible = true;
            
        }


        private void btnListar_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text.Length > 0)
            {
                ListarTudo();
            }
            
        }

        private void dgvConsulta_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvConsulta.Columns[e.ColumnIndex].Name == "BUSCAR")
                {
                    txtID.Text = dgvConsulta.Rows[e.RowIndex].Cells["idCod"].Value.ToString();
                    txtCodigoDesejado.Text = dgvConsulta.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                    txtDescricao.Text = dgvConsulta.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
                    txtPosicao.Text = dgvConsulta.Rows[e.RowIndex].Cells["Posicao"].Value.ToString();

                    txtNovaQuantidade.Select();
                  //  txtNovaQuantidade.Text = dgvConsulta.Rows[e.RowIndex].Cells["Item"].Value.ToString();
                   // if (cboAcao.Text == "INSERIR")
                 //   {
                  //      txtID.Text = "";
                 //       txtItem.Text = "";
                  //  }
                }
            }
            catch (Exception x)
            {
                 MessageBox.Show(x.Message);
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if (txtNovaQuantidade.Text.Length > 0)
            {
                consulta.comando = "";
                consulta.comando = "update Estoque set Quantidade = '" + txtNovaQuantidade.Text + "' where idCod = '" + txtID.Text + "' and CT = '" + lblCT.Text + "'";
                consulta.Atualizar();
                if (consulta.LinhasAfetadas > 0)
                {
                    MessageBox.Show(txtCodigoDesejado.Text + " ALTERADO COM SUCESSO NA POSIÇÃO " + txtPosicao.Text + " .");
                    txtCodigoDesejado.Text = "";
                    txtID.Text = "";
                    txtDescricao.Text = "";
                    txtPosicao.Text = "";
                    txtNovaQuantidade.Text = "";
                    btnListar.PerformClick();
                }
                else
                {
                    MessageBox.Show("ERRO AO ALTERAR");
                }
            }
            
        }

        private void txtNovaQuantidade_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

       
    }
}
