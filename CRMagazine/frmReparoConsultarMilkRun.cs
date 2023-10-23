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
    public partial class frmReparoConsultarMilkRun : Form
    {
        public frmReparoConsultarMilkRun(string texto, string NS, string CT)
        {
            InitializeComponent();
            lblUsuario.Text = texto;
            txtOS.Text = NS;
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();  

        private void frmReparoConsultarMilkRun_Load(object sender, EventArgs e)
        {
            dgvAguardo.RowHeadersVisible = false;
            FormatarGridAguardo();
            ListarPedidoDePeca();
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
            img.HeaderText = "Retira";
            img.Name = "Retira";            
        }

        public void ListarPedidoDePeca()
        {
            string ParteTexto = "";
            if (chbTodasPeças.Checked)
            {
                ParteTexto = "(OS = '" + txtOS.Text + "' or Usuario = '" + lblUsuario.Text + "')";
            }
            else
            {
                ParteTexto = "OS = '" + txtOS.Text + "'";
            }
            string sql = "";
            sql += " Select idPedidos, OS, Codigo, Descricao, Status, HoraPedido as 'Hora do Pedido' from Pedidos where " + ParteTexto + " and Status in ('PP-AGUARDANDO', 'AGUARDANDO', 'ATENDIMENTO', 'ATENDIDO') and CT = '" + lblCT.Text + "' order by HoraPedido";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Pedidos");
            dgvAguardo.DataSource = ds.Tables["Pedidos"];
            cx.Desconectar();
            lblTotalPecaAguardo.Text = dgvAguardo.Rows.Count.ToString();
        }

        private void dgvAguardo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Limpar();
            try
            {
                if (dgvAguardo.Columns[e.ColumnIndex].Name == "Retira")
                {
                    consulta.DataAtual();
                    string data = consulta.dataCompleta;
                    string retorno = "";
                    Chamado = dgvAguardo.Rows[e.RowIndex].Cells["OS"].Value.ToString();
                    Cod = dgvAguardo.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                    idPedidos = dgvAguardo.Rows[e.RowIndex].Cells["idPedidos"].Value.ToString();
                    // string Chamado = dgvPP.Rows[e.RowIndex].Cells["CHAMADO"].Value.ToString();
                    Des = dgvAguardo.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
                    Status = dgvAguardo.Rows[e.RowIndex].Cells["Status"].Value.ToString();

                    if (Status == "ATENDIDO")
                    {
                        if (MessageBox.Show("CONFIRMA?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            consulta.comando = "";
                            consulta.comando = "update Pedidos set Status = 'RECEBIDO', HoraRecebimento = '" + data + "' where idPedidos = '" + idPedidos + "' and CT = '" + lblCT.Text + "'";
                            consulta.Atualizar();
                            ListarPedidoDePeca();
                            // consultarOSPeloChamado();

                            //verifica se existe outra peça para mesma OS
                            for (int i = 0; i < dgvAguardo.RowCount; i++)
                            {
                                string OSdaVez = dgvAguardo.Rows[i].Cells["OS"].Value.ToString();
                                if (Chamado == OSdaVez)
                                {
                                    retorno = "TEM";
                                }
                            }
                            //verifica se ainda há peças para o OS.
                            if (retorno == "TEM")
                            {
                                MessageBox.Show("AINDA EXISTE OUTRA PEÇA PARA ESSA OS");
                            }
                            else
                            {
                              //  RetirarAguardo();
                                MessageBox.Show("SOLICITAÇÃO DE PEÇA CONCLUIDO!");
                            }
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        MessageBox.Show("PEDIDO AINDA NÃO ATENDIDO");
                    }

                   
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        public void Limpar()
        {
            Cod = "";
            Des = "";
            idPedidos = "";
            Chamado = "";
            Status = "";
        }

        public void RetirarAguardo()
        {
            //======Insere na tabela Historico==========================
            string StatusHistorico = "SAIDAAGUARDO";
            consulta.DataAtual();
            consulta.InsereHistorico(Chamado, lblUsuario.Text, StatusHistorico, consulta.data, consulta.hora, lblCT.Text);
            //=====fim da inserção======================================
            // consulta.DataAtual();
            // consulta.Coluna = "Chamado";
            //  consulta.ValorDesejado = Chamado;
            //  consulta.ConsultarChamado();
            consulta.comando = "";
            consulta.comando = "update Chamados set Status = 'REPARO' where Chamado = '" + Chamado + "' and CT = '" + lblCT.Text + "'";
            consulta.Atualizar();          
            //MessageBox.Show(consultar.comando);
            if (consulta.Retorno == "ok")
            {
                //MessageBox.Show("CONCLUIDO COM SUCESSO!");
                // ListarPP();
                // consultarOSPeloChamado();
                MessageBox.Show("OS " + Chamado + " ENVIADA PARA REPARO");
            }
            else
            {
                MessageBox.Show("FALHA AO RETIRAR DO AGUARDO");
            }
        }

        private void chbTodasPeças_CheckedChanged(object sender, EventArgs e)
        {
            ListarPedidoDePeca();
        }



    }
}
