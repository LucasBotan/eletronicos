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
using System.Media;
using System.Drawing.Printing;


namespace CRMagazine
{
    public partial class frmEstoquePainelPedidos : Form
    {
        public frmEstoquePainelPedidos(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();
        Impressao imprimir = new Impressao();

        private void frmEstoquePainelPedidos_Load(object sender, EventArgs e)
        {
            ListarTudo();
            FormatarGrid();
            //FormatarGridListar();
        }

        public void FormatarGrid()
        {
            DataGridViewImageColumn img = new DataGridViewImageColumn();          
            Image imagem = pictureBox1.Image;
            img.Image = imagem;
            dgvConsulta.Columns.Add(img);
            img.HeaderText = "Busca";
            img.Name = "Busca";

            DataGridViewImageColumn img2 = new DataGridViewImageColumn();
            Image imagem2 = pictureBox3.Image;
            img2.Image = imagem2;
            dgvConsulta.Columns.Add(img2);
            img2.HeaderText = "Imp";
            img2.Name = "Imp";


            //dgvConsulta.AutoResizeColumns();
            dgvConsulta.Columns[0].Visible = false;

           // dgvConsulta.Columns["CodAntigo"].Visible = false;
          //  dgvConsulta.Columns["DescPecaAntiga"].Visible = false;
            dgvConsulta.Columns["Situacao"].Visible = false;

            dgvConsulta.RowHeadersVisible = false;
           // dgvConsulta.Columns[1].Width = 80;
            //dgvConsulta.Columns[2].Width = 80;
            //dgvConsulta.Columns[3].Width = 200;
            //dgvConsulta.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvConsulta.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvConsulta.ScrollBars = ScrollBars.Vertical;
            //dgvConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both;  
        }

        public void FormatarGridListar()
        {
            dgvLocal.AutoResizeColumns();
            //dgvLocal.Columns[0].Visible = false;
            dgvLocal.RowHeadersVisible = false;
            //dgvConsulta.Columns[1].Width = 80;
            //dgvConsulta.Columns[2].Width = 80;
            //dgvConsulta.Columns[3].Width = 200;
            dgvLocal.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLocal.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLocal.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvConsulta.ScrollBars = ScrollBars.Vertical;
            dgvLocal.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            
        }


        public void ListarTudo()
        {
            string sql = "";
            sql += " Select idPedidos, Usuario, OS, NS, Codigo, Descricao, Quantidade as 'Qntd', Status, HoraPedido as 'Hora do Pedido', Situacao from Pedidos where Status like '%AGUARDANDO%' and CT = '" + lblCT.Text + "' order by HoraPedido";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Pedidos");
            dgvConsulta.DataSource = ds.Tables["Pedidos"];
            cx.Desconectar();
            int total = 0;
            string totalgeral = dgvConsulta.Rows.Count.ToString();
            //total = dgvConsulta.Rows[1].Cells.Count.ToString();
            total = Convert.ToInt32(totalgeral);
            lblTotal.Text = total.ToString();
        }

        public void ListarLocais()
        {
            string sql = "";
            sql += " Select Codigo, Quantidade, Posicao from Estoque where Codigo = '" + Codigo + "' and Posicao != 'PP' and CT = '" + lblCT.Text + "' order by Quantidade desc";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Estoque");
            dgvLocal.DataSource = ds.Tables["Estoque"];
            cx.Desconectar();
        }

        public void LimparLocais()
        {
            dgvLocal.DataSource = null;
            txtDescricao.Text = ""; 
        }
        
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
           
        }

        public string Codigo = "";
        public string Qntd = "";
        public string ID = "";
        public string Descricao = "";
        public string Status = "";

        public void LimparVariaveis()
        {
             Codigo = "";
             Qntd = "";
             ID = "";
             Descricao = "";
             Status = "";
             txtHabilitado.Text = "";
        }


        public string senha = "";
        public void ConferirLogar()
        {
            try
            {
                string sql = "";
                sql += " Select Senha From Usuarios ";
                sql += " Where Usuario = 'Master' ";
                cx.Conectar();
                SqlCommand cd = new SqlCommand();
                cd.Connection = cx.c;
                cd.CommandText = sql;
                SqlDataReader dr = cd.ExecuteReader();
                if (dr.Read())
                {
                    senha = dr["Senha"].ToString();                   
                }
                else
                {
                    MessageBox.Show("Usuario não Cadastrado");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Erro: " + x.Message);
            }
            cx.Desconectar();


        }


        public string Habilitado = "";
        

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ConferirLogar();               
                if (txtSenha.Text == senha)
                {
                    txtSenha.Text = "";
                    txtHabilitado.Text = "sim";
                    pnlSenha.Visible = false;
                }
                else
                {
                    MessageBox.Show("Senha Invalida");
                    txtSenha.Select();
                }
            }
        }

        private void dgvConsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            try
            {
                Habilitado = "sim";
                if (dgvConsulta.Columns[e.ColumnIndex].Name == "Busca")
                {
                    LimparLocais();
                    /*
                    string AvaliaChamado = dgvConsulta.Rows[e.RowIndex].Cells["Chamado"].Value.ToString();
                    if ((AvaliaChamado == "" || AvaliaChamado == "NO") && txtHabilitado.Text != "sim")
                    {
                        Habilitado = "nao";
                        MessageBox.Show("SEM CHAMDO, CHAMAR SUPORTE DO GESTOR");
                        pnlSenha.Visible = true;
                        txtSenha.Select();
                    }
                     */ 

                    if (Habilitado == "sim" || txtHabilitado.Text == "sim")
                    {
                        LimparVariaveis();
                        LimparLocais();
                        Status = dgvConsulta.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                        if (Status == "PP-AGUARDANDO")
                        {
                            //ListarLocais();
                            // FormatarGridListar();
                            Codigo = dgvConsulta.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                            Descricao = dgvConsulta.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
                            ID = dgvConsulta.Rows[e.RowIndex].Cells["idPedidos"].Value.ToString();
                            txtRetirar.Text = "PP";
                            txtRetirar.Select();
                        }
                        else
                        {
                            //fazer direito --- usar variaveis (e retirar ação do txtCodigo) 
                            Codigo = dgvConsulta.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                            Qntd = dgvConsulta.Rows[e.RowIndex].Cells["Qntd"].Value.ToString();
                            ID = dgvConsulta.Rows[e.RowIndex].Cells["idPedidos"].Value.ToString();
                            Descricao = dgvConsulta.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
                            txtDescricao.Text = Descricao;
                            ListarLocais();
                            FormatarGridListar();
                            txtRetirar.Select();
                        }
                    }
                    
                }
                else if (dgvConsulta.Columns[e.ColumnIndex].Name == "Imp")
                {                   
                    if (MessageBox.Show("DESEJA IMPRIMIR? ", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        consulta.DataAtual();
                        string codZPL = "";
                        imprimir.Chamado = dgvConsulta.Rows[e.RowIndex].Cells["Chamado"].Value.ToString();
                        imprimir.Codigo = dgvConsulta.Rows[e.RowIndex].Cells["CodAntigo"].Value.ToString();
                        imprimir.DescPeca = dgvConsulta.Rows[e.RowIndex].Cells["DescPecaAntiga"].Value.ToString();
                        imprimir.DataRMA = consulta.dataNormal;
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


        private void txtRetirar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Status == "PP-AGUARDANDO")
            {
                if (MessageBox.Show("DESEJA CONCLUIR O PP?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    consulta.DataAtual();
                    //atualizar a tabela Pedidos
                    consulta.comando = "";
                    consulta.comando = "update Pedidos set Status = 'ATENDIMENTO', HoraAtendimento = '" + consulta.dataCompleta + "' where idPedidos = '" + ID + "' and CT = '" + lblCT.Text + "'";
                    //MessageBox.Show(consulta.comando);
                    consulta.Atualizar();
                    ListarTudo();
                    LimparLocais();
                }
                else
                {

                }
            }
            else if (Status == "AGUARDANDO")
            {
                if (MessageBox.Show("DESEJA CONCLUIR?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string valor = "";
                    string tot = "";
                    int qntdEmEstoque = 0;
                    string Codigo = "";
                    int i = 0;
                    for (i = 0; i < dgvLocal.Rows.Count; i++)
                    {
                        tot = Convert.ToString(dgvLocal.Rows[i].Cells["Posicao"].Value);
                        if (tot == txtRetirar.Text)
                        {
                            valor = "sim";
                            qntdEmEstoque = Convert.ToInt32(dgvLocal.Rows[i].Cells["Quantidade"].Value);
                            Codigo = Convert.ToString(dgvLocal.Rows[i].Cells["Codigo"].Value);
                            break;
                        }
                        else
                        {
                            valor = "não";
                        }
                    }

                    if (valor == "sim")
                    {
                        int total = 0;
                        int qnt = Convert.ToInt32(Qntd);
                        total = qntdEmEstoque - qnt;
                        if (total >= 0)
                        {
                            consulta.DataAtual();
                            //atualizar a tabela Pedidos
                            consulta.comando = "";
                            consulta.comando = "update Pedidos set Status = 'ATENDIMENTO', HoraAtendimento = '" + consulta.dataCompleta + "' where idPedidos = '" + ID + "' and CT = '" + lblCT.Text + "'";
                            consulta.Atualizar();
                            //atualizar a tabela Estoque
                            consulta.comando = "";
                            consulta.comando = "update Estoque set Quantidade = '" + total + "' where Codigo = '" + Codigo + "' and Posicao = '" + txtRetirar.Text + "' and CT = '" + lblCT.Text + "'";
                            consulta.Atualizar();
                            if (consulta.Retorno == "ok")
                            {
                                consulta.LimparControles(this);
                                pictureBox1.Select();
                                LimparLocais();
                                ListarTudo();
                                //FormatarGrid();
                            }
                            else
                            {
                                MessageBox.Show("ERRO AO ATUALIZAR TABELA ESTOQUE");
                            }
                        }
                        else
                        {
                            MessageBox.Show("VALOR NEGATIVO");
                        }
                    }
                    else
                    {
                        MessageBox.Show("NÃO PODE TIRAR DESSA POSIÇÃO");
                    }
                }
                else
                {
                }
            }              
        }

       

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           // ListarTudo();
           // LimparLocais();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
           // if (lblTotal.Text == "0")
            //{
                //SoundPlayer myPlayer = new SoundPlayer(Positivo.Properties.Resources.AlertSound);
                //myPlayer.Play();
           // }
            ListarTudo();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            ListarTudo();
        }

        public void Insere()
        {
            consulta.comando = "";
            consulta.comando = "Insert into Estoque (CT, Codigo, Barebone, Descricao, Quantidade, Posicao) Values (";
            consulta.comando += " '" + lblCT.Text + "', ";
            consulta.comando += " '" + Codigo + "', ";
            consulta.comando += " '', ";
            consulta.comando += " '" + Descricao + "', ";
            consulta.comando += " '1', ";
            consulta.comando += " 'REC')";
             //MessageBox.Show(consulta.comando);
            consulta.Atualizar();
        }

        public void AtualizaDestino(string qntNaPosicao)
        {
            int total = 0;
            total = Convert.ToInt32(qntNaPosicao) + 1;
            consulta.comando = "";
            consulta.comando = "update Estoque set Quantidade = '" + total + "' where Posicao = 'REC' and Codigo = '" + Codigo + "' and CT = '" + lblCT.Text + "'";
         //   MessageBox.Show(consulta.comando);
            consulta.Atualizar();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DESEJA CANCELAR O CÓDIGO " + Codigo + "?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                consulta.DataAtual();
                //atualizar a tabela Pedidos

                if (Status == "PP-AGUARDANDO")
                {
                    consulta.comando = "";
                    consulta.comando += "Select * from Estoque where Codigo = '" + Codigo + "' and Posicao = 'REC' and CT = '" + lblCT.Text + "'";
                    //MessageBox.Show(consulta.comando);
                    consulta.consultarSimNao();                  
                    if (consulta.Retorno == "ok")
                    {                       
                        AtualizaDestino(consulta.qntNaPosicao);
                    }
                    else if (consulta.Retorno == "falha")
                    {
                        Insere();          
                    }
                    else
                    {
                        MessageBox.Show("Falha ao consultar se existe esse codigo nessa posição");
                    }
                }

                consulta.comando = "";
                consulta.comando = "update Pedidos set Status = 'CANCELADO', HoraAtendimento = '" + consulta.dataCompleta + "' where idPedidos = '" + ID + "' and CT = '" + lblCT.Text + "'";
                consulta.Atualizar();
                if (consulta.Retorno == "ok")
                {
                    consulta.LimparControles(this);
                    pictureBox1.Select();
                    ListarTudo();
                }
                else
                {
                    MessageBox.Show("ERRO AO CANCELAR");
                }
            }
        }



        public void RetirarDoPP()
        {
            consulta.comando = "";
            consulta.comando = "Delete from Estoque where idCod in ( " + ID + " ) and CT = '" + lblCT.Text + "'";
            //MessageBox.Show(consultar.comando);
            consulta.Atualizar();
        }

        private void dgvLocal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvLocal.Columns[e.ColumnIndex].Name == "Posicao")
                {
                    txtRetirar.Text = dgvLocal.Rows[e.RowIndex].Cells["Posicao"].Value.ToString();
                    txtRetirar.Select();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            txtSenha.Text = "";
            pnlSenha.Visible = false;
        }

       

        
      

    }
}
