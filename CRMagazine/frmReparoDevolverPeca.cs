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
    public partial class frmReparoDevolverPeca : Form
    {
        public frmReparoDevolverPeca(string texto, string CT)
        {
            InitializeComponent();
            txtOS.Text = texto;
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();  

        private void frmReparoDevolverPeca_Load(object sender, EventArgs e)
        {
            dgvAguardo.RowHeadersVisible = false;
            ListarPedidoDePeca();
            FormatarGridAguardo();
            
        }

        public string Cod = "";
        public string Des = "";
        public string idPedidos = "";
        public string Chamado = "";
        public string Status = "";


        public void FormatarGridAguardo()
        {
            dgvAguardo.RowHeadersVisible = false;
            //ListarPP();
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            Image imagem = pictureBox2.Image;
            img.Image = imagem;
            dgvAguardo.Columns.Add(img);
            img.HeaderText = "RETORNO";
            img.Name = "RETORNO";
            /*
            DataGridViewImageColumn img2 = new DataGridViewImageColumn();
            Image imagem2 = pictureBox3.Image;
            img2.Image = imagem2;
            dgvAguardo.Columns.Add(img2);
            img2.HeaderText = "RMDF";
            img2.Name = "RMDF";
             */ 
        }

        public void ListarPedidoDePeca()
        {
            string sql = "";
            sql += " Select idPedidos, OS, NS, Codigo, Descricao, Status, HoraPedido as 'Hora do Pedido' from Pedidos where OS = '" + txtOS.Text + "' and Status in ('RECEBIDO') and CT = '" + lblCT.Text + "' order by HoraPedido";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Pedidos");
            dgvAguardo.DataSource = ds.Tables["Pedidos"];
            cx.Desconectar();
            lblTotalPecaAguardo.Text = dgvAguardo.Rows.Count.ToString();
        }

        public void Limpar()
        {
            Cod = "";
            Des = "";
            idPedidos = "";
            Chamado = "";
            Status = "";
        }

        private void dgvAguardo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Limpar();
            try
            {
                if (dgvAguardo.Columns[e.ColumnIndex].Name == "RETORNO")
                {
                    Chamado = dgvAguardo.Rows[e.RowIndex].Cells["OS"].Value.ToString();
                    Cod = dgvAguardo.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                    idPedidos = dgvAguardo.Rows[e.RowIndex].Cells["idPedidos"].Value.ToString();

                    consulta.DataAtual();
                    consulta.comando = "";
                    consulta.comando += "update Pedidos set Status = 'RETORNO', HoraRetornoPeca = '" + consulta.dataCompleta + "' where ";
                    consulta.comando += "idPedidos =  '" + idPedidos + "' and CT = '" + lblCT.Text + "'";
                    consulta.Atualizar();

                    //consulta.comando = "";
                    //consulta.comando += "update RMA set Status = 'RETORNO', Data = '" + consulta.data + "' where ";
                   // consulta.comando += "idPedidos =  '" + idPedidos + "'";
                   // consulta.Atualizar();

                   // MessageBox.Show(consulta.comando);
                    if (consulta.Retorno == "ok")
                    {
                        MessageBox.Show("CANCELAMENTO PEÇA BOA CONCLUIDO");
                    }
                    else
                    {
                        MessageBox.Show("FALHA AO CONCLUIR RETORNO.");
                    }
                }
                    /*
                else if (dgvAguardo.Columns[e.ColumnIndex].Name == "RMDF")
                {
                    Chamado = dgvAguardo.Rows[e.RowIndex].Cells["Chamado"].Value.ToString();
                    Cod = dgvAguardo.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                    idPedidos = dgvAguardo.Rows[e.RowIndex].Cells["idPedidos"].Value.ToString();

                    consulta.DataAtual();
                    consulta.comando = "";
                    consulta.comando += "update Pedidos set Status = 'RMDF', HoraRetornoPeca = '" + consulta.dataCompleta + "' where ";
                    consulta.comando += "idPedidos =  '" + idPedidos + "'";
                   // MessageBox.Show(consulta.comando);
                    consulta.Atualizar();                   
                    if (consulta.Retorno == "ok")
                    {
                        MessageBox.Show("CANCELAMENTO RMDF CONCLUIDO");
                    }
                    else
                    {
                        MessageBox.Show("FALHA AO CONCLUIR RETORNO.");
                    }
                }
                     */
                ListarPedidoDePeca();               
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }




    }
}
