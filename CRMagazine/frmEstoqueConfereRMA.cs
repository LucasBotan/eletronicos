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
using System.Drawing.Printing;

namespace CRMagazine
{
    public partial class frmEstoqueConfereRMA : Form
    {
        public frmEstoqueConfereRMA(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();
        Impressao imprimir = new Impressao();

        private void frmEstoqueConfereRMA_Load(object sender, EventArgs e)
        {
            ListarTudo();
            FormatarGrid();
        }

        public void FormatarGrid()
        {
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            //Image imagem = Image.FromFile(pictureBox1.Image);
            Image imagem = pictureBox1.Image;
            img.Image = imagem;
            dgvConsulta.Columns.Add(img);
            img.HeaderText = "OK";
            img.Name = "CONCLUIR";
            /*
            DataGridViewImageColumn img2 = new DataGridViewImageColumn();        
            Image imagem2 = pictureBox3.Image;
            img2.Image = imagem2;
            dgvConsulta.Columns.Add(img2);
            img2.HeaderText = "X";
            img2.Name = "CANCELA";
            */
            dgvConsulta.Columns[0].Visible = false;
            dgvConsulta.Columns["Situacao"].Visible = false;
            dgvConsulta.RowHeadersVisible = false;
            dgvConsulta.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;             
        }




        public void ListarTudo()
        {
            string sql = "";

            sql += " Select idRMA, Usuario, Chamado, OS, CodAntigo, DescPecaAntiga, Codigo, Descricao, Qntd, Status, Data, Situacao from RMA where CT = '" + lblCT.Text + "' and Status like '%PENDENTE%'";      

            if (txtCodigo.Text.Length > 0)
            {
                string status = txtCodigo.Text;

                if (txtCodigo.Text.Contains('+'))
                {
                    status = txtCodigo.Text.Replace("+", "' or Codigo = '");
                    //MessageBox.Show(status);
                    sql += "and (Codigo = '" + status + "' )";
                }
                //sql += "M.Descricao like '%" + txtStatus.Text +  "%'";
                else
                {
                    sql += " and Codigo = '" + status + "' ";
                }


                // sql += "and Codigo like '" + txtCodigo.Text +"' ";
            }

            if (txtDescricao.Text.Length > 0)
            {
                sql += "and Descricao like '%" + txtDescricao.Text + "%' ";
            }

            if (txtData.Text.Length > 0)
            {
                sql += "and Data like '%" + txtData.Text + "%' ";
            }

            if (txtUsuario.Text.Length > 0)
            {
                sql += "and Usuario like '%" + txtUsuario.Text + "%' ";
            }



            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "RMA");
            dgvConsulta.DataSource = ds.Tables["RMA"];
            cx.Desconectar();
            lblTotal.Text = dgvConsulta.Rows.Count.ToString();
        }

        // ============= variaveis ===========
        public string ID = "";
        public string Usuario = "";
        public string OS = "";
        public string Codigo = "";
        public string Descricao = "";
        public string Qntd = "";
        //====================================

        private void dgvConsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ID = dgvConsulta.Rows[e.RowIndex].Cells["idRMA"].Value.ToString();
                Usuario = dgvConsulta.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();
                OS = dgvConsulta.Rows[e.RowIndex].Cells["OS"].Value.ToString();
                Codigo = dgvConsulta.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                Descricao = dgvConsulta.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
                Qntd = dgvConsulta.Rows[e.RowIndex].Cells["Qntd"].Value.ToString();
                if (dgvConsulta.Columns[e.ColumnIndex].Name == "CONCLUIR")
                {
                    if (MessageBox.Show("DESEJA CONCLUIR? ", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        consulta.DataAtual();
                        consulta.comando = "";
                        consulta.comando = "update RMA set Status = 'CONFIRMADO' where idRMA = '" + ID + "' and CT = '" + lblCT.Text + "'";
                        consulta.Atualizar();
                        if (consulta.Retorno == "ok")
                        {
                            //InserirRMA();
                            // if (consulta.Retorno == "ok")
                            // {
                            MessageBox.Show("CONCLUIDO");
                            ListarTudo();
                            // }                           
                        }
                    }
                }
                /*
            else if (dgvConsulta.Columns[e.ColumnIndex].Name == "CANCELA")
            {
                if (MessageBox.Show("DESEJA CANCELAR? ", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    consulta.comando = "";
                    consulta.comando = "update Estoque set Quantidade = Quantidade + " + Qntd + " where Codigo = '" + Codigo + "' and Posicao = 'REC' and CT = '" + lblCT.Text + "'";
                    consulta.Atualizar();
                    if (consulta.Retorno == "ok")
                    {
                        consulta.comando = "";
                        consulta.comando = "update Pedidos set Status = 'CANCELADO', HoraEntrega = '" + consulta.dataCompleta + "' where idPedidos = '" + ID + "' and CT = '" + lblCT.Text + "'";
                        consulta.Atualizar();
                        if (consulta.Retorno == "ok")
                        {
                            MessageBox.Show("CANCELAMENTO CONCLUIDO");
                            ListarTudo();
                        }
                        else
                        {
                            MessageBox.Show("FALHA AO CONCLUIR RETORNO.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("FALHA AO RETORNAR.");
                    }
                }
            }
                 */
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void dgvConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            ListarTudo();
        }

        private void dgvConsulta_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {               
                if (dgvConsulta.Columns[e.ColumnIndex].Name == "CodAntigo")
                {
                    if (MessageBox.Show("DESEJA IMPRIMIR? ", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {                       

                        consulta.DataAtual();
                        string codZPL = "";
                        imprimir.Chamado = dgvConsulta.Rows[e.RowIndex].Cells["Chamado"].Value.ToString();
                        imprimir.Codigo = dgvConsulta.Rows[e.RowIndex].Cells["CodAntigo"].Value.ToString();
                        imprimir.DescPeca = dgvConsulta.Rows[e.RowIndex].Cells["DescPecaAntiga"].Value.ToString();
                        imprimir.DataRMA = dgvConsulta.Rows[e.RowIndex].Cells["Data"].Value.ToString();
                        imprimir.Usuario = dgvConsulta.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();
                        imprimir.Situacao = dgvConsulta.Rows[e.RowIndex].Cells["Situacao"].Value.ToString();
                        imprimir.RMA();
                        codZPL = imprimir.s;
                        string nomeImpressoraPadrao = (new PrinterSettings()).PrinterName;
                        RawPrinterHelper.SendStringToPrinter(nomeImpressoraPadrao, codZPL); 
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
