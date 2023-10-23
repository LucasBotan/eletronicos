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
    public partial class frmEstoqueRecebeProducao : Form
    {
        public frmEstoqueRecebeProducao(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();

        private void frmEstoqueEntrega_Load(object sender, EventArgs e)
        {
            PreencherComboboxStatus();            
        }


        public string JaAtualizou = "";
        public void FormatarGrid()
        {            
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            //Image imagem = Image.FromFile(pictureBox1.Image);
            Image imagem = pictureBox1.Image;
            img.Image = imagem;
            dgvConsulta.Columns.Add(img);
            img.HeaderText = "RECEBER";
            img.Name = "CONCLUIR";

            DataGridViewImageColumn img2 = new DataGridViewImageColumn();
            Image imagem2 = pictureBox3.Image;
            img2.Image = imagem2;
            dgvConsulta.Columns.Add(img2);
            img2.HeaderText = "CANCELAR";
            img2.Name = "CANCELA";

            //dgvConsulta.AutoResizeColumns();
            dgvConsulta.Columns[0].Visible = false;
            //dgvConsulta.Columns["CodAntigo"].Visible = false;
            //dgvConsulta.Columns["DescPecaAntiga"].Visible = false;
          //  dgvConsulta.Columns["Situacao"].Visible = false;

          //  dgvConsulta.Columns["Descricao"].Visible = false; 
            dgvConsulta.RowHeadersVisible = false;
           // dgvConsulta.Columns[1].Width = 80;
            //dgvConsulta.Columns[2].Width = 80;
            //dgvConsulta.Columns[3].Width = 200;
            dgvConsulta.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvConsulta.ScrollBars = ScrollBars.Vertical;
            //dgvConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both;

            JaAtualizou = "SIM";
        }


        public void PreencherComboboxStatus()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql = "";
            sql += " SELECT DISTINCT Usuario FROM Producao WHERE Status = 'AGUARDANDO' and CT = '" + lblCT.Text + "'";
            cx.Conectar();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "Usuarios");
            cboUsuario.ValueMember = "idProducao";
            cboUsuario.DisplayMember = "Usuario";
            cboUsuario.DataSource = ds.Tables["Usuarios"];
            cx.Desconectar();
            cboUsuario.Text = null;
            cboUsuario.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboUsuario.AutoCompleteSource = AutoCompleteSource.ListItems;
        }


        public void ListarTudo()
        {
            string sql = "";
            //sql += " Select idPedidos, Situacao, Usuario, OS, NS, Codigo, Descricao, Quantidade as 'Qntd', Status, HoraPedido as 'Hora do Pedido' from Pedidos where Status = 'ATENDIMENTO' order by HoraPedido";
            sql += " Select idProducao, EAN, Descricao, SKU, Usuario, Data, Hora, Status from Producao where Status = 'AGUARDANDO' AND USUARIO = '" + cboUsuario.Text + "' and CT = '" + lblCT.Text + "'";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Producao");
            dgvConsulta.DataSource = ds.Tables["Producao"];
            cx.Desconectar();
            int total = 0;
            string totalgeral = dgvConsulta.Rows.Count.ToString();
            //total = dgvConsulta.Rows[1].Cells.Count.ToString();
            total = Convert.ToInt32(totalgeral);
            lblTotal.Text = total.ToString();
            LimparVariaveis();

            if (JaAtualizou == "")
            {
                FormatarGrid();
            }    

        }


        /*
        public void InserirRMA()
        {
            string Assist = "";
            if (OS == "")
            {
                Assist = "SEM ASSIST";
            }
            consulta.DataAtual();
            consulta.comando = "";
            consulta.comando += "insert into RMA (Usuario, OS, Chamado, Codigo, Descricao, Qntd, Status, Data, Assist, Situacao, idPedidos) Values ";
            consulta.comando += "('" + Usuario + "', '" + OS + "', '" + Chamado + "', '" + Codigo + "', '" + Descricao + "', '" + Qntd + "', 'PENDENTE', '" + consulta.data + "', '" + Assist + "', '" + Situacao + "', '" + ID + "' ) ";
            consulta.Atualizar();

         
             //ANTIGO
            //consulta.DataAtual();
            //consulta.comando = "";
            //consulta.comando += "insert into RMA (Usuario, OS, Codigo, Descricao, Qntd, Status, Data) Values ";
            //consulta.comando += "('" + Usuario + "', '" + OS + "', '" + Codigo + "', '" + Descricao + "', '" + Qntd + "', 'PENDENTE', '" + consulta.data + "') ";
            //consulta.Atualizar();
             
        }
    
    

    
        public void InsereConsumivelAssist()
        {
            consulta.comando = "";
            consulta.comando = "select count(*) as Quantidade from ConsumoAssist where Codigo = '" + Codigo +"' ";
            consulta.consultarSimNao();
            if (Convert.ToInt32(consulta.qntNaPosicao) > 0)
            {
                consulta.comando = "";
                consulta.comando = "update ConsumoAssist set Necessidade = Necessidade + " + Qntd + " where Codigo = '" + Codigo + "'";
                consulta.Atualizar();
            }            
        }
   
     */ 



        // ============= variaveis ===========
        public string ID = "";
        public string Usuario = "";
        public string OS = "";
        public string Chamado = "";
        public string Codigo = "";
        public string Descricao = "";
        public string Qntd = "";
        public string CodAntigo = "";
        public string DescPecaAntiga = "";
        public string Situacao = "";
        //====================================

        public void LimparVariaveis()
        {
            ID = "";
            Usuario = "";
            OS = "";
            Chamado = "";
            Codigo = "";
            Descricao = "";
            Qntd = "";
            CodAntigo = "";
            DescPecaAntiga = "";
            Situacao = "";
        }


        /*
        private void dgvConsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                ID = dgvConsulta.Rows[e.RowIndex].Cells["idPedidos"].Value.ToString();
                Usuario = dgvConsulta.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();
                OS = dgvConsulta.Rows[e.RowIndex].Cells["OS"].Value.ToString();
                Chamado = dgvConsulta.Rows[e.RowIndex].Cells["NS"].Value.ToString();
                Codigo = dgvConsulta.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                Descricao = dgvConsulta.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
                Qntd = dgvConsulta.Rows[e.RowIndex].Cells["Qntd"].Value.ToString();
               // CodAntigo = dgvConsulta.Rows[e.RowIndex].Cells["CodAntigo"].Value.ToString();
              //  DescPecaAntiga = dgvConsulta.Rows[e.RowIndex].Cells["DescPecaAntiga"].Value.ToString();
                Situacao = dgvConsulta.Rows[e.RowIndex].Cells["Situacao"].Value.ToString();
                if (dgvConsulta.Columns[e.ColumnIndex].Name == "CONCLUIR")
                {
                    if (MessageBox.Show("DESEJA CONCLUIR? ", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {    

                        consulta.DataAtual();
                        consulta.comando = "";
                        consulta.comando = "update Pedidos set Status = 'ATENDIDO', HoraFinalizacao = '" + consulta.dataCompleta + "' where idPedidos = '" + ID + "'";
                        consulta.Atualizar();
                        if (consulta.Retorno == "ok")
                        {
                            //InserirRMA();
                            //InsereConsumivelAssist();
                            //if (consulta.Retorno == "ok")
                           // {
                                MessageBox.Show("CONCLUIDO");
                                ListarTudo();
                           // }
                        }
                    }
                   
                }
                else if (dgvConsulta.Columns[e.ColumnIndex].Name == "CANCELA")
                {
                    if (MessageBox.Show("DESEJA CANCELAR? ", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        consulta.comando = "";
                        consulta.comando += "Select * from Estoque where Codigo = '" + Codigo + "' and Posicao = 'REC'";                       
                        consulta.consultarSimNao();                       
                        if (consulta.Retorno == "ok")
                        {
                            consulta.comando = "";
                            consulta.comando = "update Estoque set Quantidade = Quantidade + " + Qntd + " where Codigo = '" + Codigo + "' and Posicao = 'REC'";
                            consulta.Atualizar();
                        }
                        else
                        {
                            consulta.comando = "";
                            consulta.comando = "Insert into Estoque (Codigo, Barebone, Descricao, Quantidade, Posicao) Values (";
                            consulta.comando += " '" + Codigo + "', ";
                            consulta.comando += " '', ";
                            consulta.comando += " '" + Descricao + "', ";
                            consulta.comando += " '" + Qntd + "', ";
                            consulta.comando += " 'REC')";
                            consulta.Atualizar();
                        }

                        if (consulta.Retorno == "ok")
                        {
                            consulta.comando = "";
                            consulta.comando = "update Pedidos set Status = 'CANCELADO', HoraFinalizacao = '" + consulta.dataCompleta + "' where idPedidos = '" + ID + "'";
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
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
         */ 

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (cboUsuario.Text.Length == 0)
            {
                consulta.PlayFail();
                MessageBox.Show("INFORME O TÉCNICO.");
            }
            else
            {
                ListarTudo();
                            
            }
            
        }
               

        private void dgvConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LimparVariaveis();
                ID = dgvConsulta.Rows[e.RowIndex].Cells["idProducao"].Value.ToString();
                Usuario = dgvConsulta.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();
                Codigo = dgvConsulta.Rows[e.RowIndex].Cells["SKU"].Value.ToString();
                Descricao = dgvConsulta.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
                Qntd = "1";

                if (dgvConsulta.Columns[e.ColumnIndex].Name == "CONCLUIR")
                {
                    if (MessageBox.Show("DESEJA CONCLUIR? ", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        consulta.DataAtual();
                        consulta.comando = "";
                        consulta.comando = "update Producao set Status = 'RECEBIDO', HoraRecebimento = '" + consulta.dataCompleta + "' where idProducao = '" + ID + "' and CT = '" + lblCT.Text + "'";
                        consulta.Atualizar();
                        if (consulta.Retorno == "ok")
                        {

                            consulta.comando = "";
                            consulta.comando += "Select * from Estoque where Codigo = '" + Codigo + "' and Posicao = 'REC' and CT = '" + lblCT.Text + "'";
                            consulta.consultarSimNao();
                            if (consulta.Retorno == "ok")
                            {
                                consulta.comando = "";
                                consulta.comando = "update Estoque set Quantidade = Quantidade + " + Qntd + " where Codigo = '" + Codigo + "' and Posicao = 'REC' and CT = '" + lblCT.Text + "'";
                                consulta.Atualizar();
                            }
                            else
                            {
                                consulta.comando = "";
                                consulta.comando = "Insert into Estoque (CT, Codigo, Descricao, Quantidade, Posicao) Values (";
                                consulta.comando += " '" + lblCT.Text + "', ";
                                consulta.comando += " '" + Codigo + "', ";
                                consulta.comando += " '" + Descricao + "', ";
                                consulta.comando += " '" + Qntd + "', ";
                                consulta.comando += " 'REC')";
                                consulta.Atualizar();
                            }
                            if (consulta.Retorno == "ok")
                            {
                                MessageBox.Show("CONCLUIDO");
                                ListarTudo();
                            }                         
                         
                        }
                    }

                }
                else if (dgvConsulta.Columns[e.ColumnIndex].Name == "CANCELA")
                {
                    if (MessageBox.Show("DESEJA CANCELAR? ", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        consulta.DataAtual();
                        consulta.comando = "";
                        consulta.comando = "update Producao set Status = 'CANCELADO', HoraRecebimento = '" + consulta.dataCompleta + "' where idProducao = '" + ID + "' and CT = '" + lblCT.Text + "'";
                        consulta.Atualizar();
                        if (consulta.Retorno == "ok")
                        {
                            MessageBox.Show("CANCELAMENTO CONCLUIDO");
                            ListarTudo();
                        }
                    }
                }

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }

        private void lnkAtualizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PreencherComboboxStatus();
        }



    }

}
