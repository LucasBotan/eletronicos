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
    public partial class old_frmEstoqueEntregaPecaSP : Form
    {
        public old_frmEstoqueEntregaPecaSP()
        {
            InitializeComponent();
        }

        Conexao cx = new Conexao();
        Conexao cx2 = new Conexao();
        Consulta consulta = new Consulta();

        private void frmEstoqueEntregaKamban_Load(object sender, EventArgs e)
        {
            ListarTudo();
            FormatarGrid();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ListarFiltrado();           
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

            DataGridViewImageColumn img2 = new DataGridViewImageColumn();
            Image imagem2 = pictureBox3.Image;
            img2.Image = imagem2;
            dgvConsulta.Columns.Add(img2);
            img2.HeaderText = "X";
            img2.Name = "CANCELA";

            //dgvConsulta.AutoResizeColumns();
            dgvConsulta.Columns["idMovimentacao"].Visible = false;
            dgvConsulta.RowHeadersVisible = false;
            // dgvConsulta.Columns[1].Width = 80;
            //dgvConsulta.Columns[2].Width = 80;
            //dgvConsulta.Columns[3].Width = 200;
            dgvConsulta.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvConsulta.ScrollBars = ScrollBars.Vertical;
            //dgvConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        }



        public void ListarTudo()
        {
            string sql = "";
            sql += " Select idMovimentacao, Usuario, Codigo, Descricao, Quantidade, Status, DataPedido, NF, Chamado from MovimentacaoEstoque where Status in ('ATENDIDO', 'INDISPONIVEL') order by DataPedido";
            cx.ConectarSP();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "MovimentacaoEstoque");
            dgvConsulta.DataSource = ds.Tables["MovimentacaoEstoque"];
            cx.Desconectar();
            int total = 0;
            string totalgeral = dgvConsulta.Rows.Count.ToString();
            //total = dgvConsulta.Rows[1].Cells.Count.ToString();
            total = Convert.ToInt32(totalgeral);
            lblTotal.Text = total.ToString();
        }

        public void ListarFiltrado()
        {
            string sql = "";
            sql += " Select idMovimentacao, Usuario, Codigo, Descricao, Quantidade, Status, DataPedido, NF, Chamado from MovimentacaoEstoque where Status = '" + cboStatus.Text + "' order by DataPedido";
            cx.ConectarSP();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "MovimentacaoEstoque");
            dgvConsulta.DataSource = ds.Tables["MovimentacaoEstoque"];
            cx.Desconectar();
            int total = 0;
            string totalgeral = dgvConsulta.Rows.Count.ToString();
            //total = dgvConsulta.Rows[1].Cells.Count.ToString();
            total = Convert.ToInt32(totalgeral);
            lblTotal.Text = total.ToString();
        }

        // ============= variaveis ===========
        public string ID = "";
        public string Usuario = "";
        public string status = "";
        public string Codigo = "";
        public string Descricao = "";
        public string Qntd = "";
        public string Chamado = "";

        //====================================


        private void dgvConsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ID = dgvConsulta.Rows[e.RowIndex].Cells["idMovimentacao"].Value.ToString();
               // Usuario = dgvConsulta.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();
               // OS = dgvConsulta.Rows[e.RowIndex].Cells["OS"].Value.ToString();
                Codigo = dgvConsulta.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                status = dgvConsulta.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                Qntd = dgvConsulta.Rows[e.RowIndex].Cells["Quantidade"].Value.ToString();
                Descricao = dgvConsulta.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
                Chamado = dgvConsulta.Rows[e.RowIndex].Cells["Chamado"].Value.ToString();
                if (dgvConsulta.Columns[e.ColumnIndex].Name == "CONCLUIR")
                {
                    if (MessageBox.Show("DESEJA CONCLUIR? ", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {                    
                        consulta.DataAtual();

                        if (status == "INDISPONIVEL")
                        {
                            consulta.comando = "";
                            consulta.comando = "update MovimentacaoEstoque set Status = 'INDISPONIVEL-OK', DataConfirmacao = '" + consulta.dataCompleta + "' where idMovimentacao = '" + ID + "'";
                            consulta.AtualizarSP();
                        }
                        else
                        {
                            if (Chamado.Length > 0)
                            {
                                ConcluirComChamado(Codigo, Chamado, Qntd, Descricao);
                            }
                            else
                            {
                                Concluir(Codigo, Qntd, Descricao);
                            }                            
                            consulta.comando = "";
                            consulta.comando = "update MovimentacaoEstoque set Status = 'RECEBIDO', DataConfirmacao = '" + consulta.dataCompleta + "' where idMovimentacao = '" + ID + "'";
                            consulta.AtualizarSP();
                        }
                        
                        if (consulta.Retorno == "ok")
                        {
                         //   InserirRMA();
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
                        /*
                        consulta.comando = "";
                        consulta.comando = "update Estoque set Quantidade = Quantidade + " + Qntd +" where Codigo = '" + Codigo + "' and Posicao = 'REC'";
                        consulta.Atualizar();
                         */ 
                       // if (consulta.Retorno == "ok")
                       // {
                        if (status == "AGUARDANDO")
                        {
                            consulta.comando = "";
                            consulta.comando = "update MovimentacaoEstoque set Status = 'CANCELADO', DataConfirmacao = '" + consulta.dataCompleta + "' where idMovimentacao = '" + ID + "'";
                            consulta.AtualizarSP();
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
                            MessageBox.Show("NÃO PODE CANCELAR. O ESTOQUE SP JÁ ATENDEU.");
                        }
                            
                            
                 
                    }                    
                }
            }            
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }


        public void AguardoBackUp(string Cod, string Quantidade, string Descricao, out int Qnt)
        {
            Qnt = Convert.ToInt32(Quantidade);
            //================= VERIFICA AGUARDO DE BACKUP
            try
            {
                cx2.Desconectar();
                string comando = "select * FROM AguardoBackup WHERE Codigo = '" + Cod + "' AND Status = 'PENDENTE'";
                cx2.Conectar();
                SqlCommand cd2 = new SqlCommand();
                cd2.Connection = cx2.c;
                cd2.CommandText = comando;
                SqlDataReader dr2 = cd2.ExecuteReader();
                if (dr2.HasRows)
                {
                    while (dr2.Read())
                    {
                        if (Qnt > 0) // SE AINDA TEM QUANTIDADE, FAZ O PROCESSO
                        {
                            string id = dr2["idAguardoBackup"].ToString();
                            string Chamado = dr2["Chamado"].ToString();

                            consulta.Coluna = "Chamado";
                            consulta.ValorDesejado = Chamado;
                            consulta.ComData = "SIM";
                            // consulta.ConsultaTudo(lblCT.Text);
                            if (consulta.Status == "AGUARDOBACKUP")
                            {
                               // txtFeedBack.Text += Chamado + " AGUARDOBACKUP - PEÇA: " + Cod + " " + Descricao + "\r\n";
                                //======================================INSERE NO ESTOQUE O CHAMADO COMO PP ========================================
                                string sql = "";
                                string posicao = "BACKUP";
                                string Orc = "";
                                try
                                {
                                    sql = "";
                                    sql += " Insert into Estoque (Codigo, Barebone, Descricao, Quantidade, Posicao, Chamado, Tipo, BareboneEquivalente, Orc)";
                                    sql += " Values ( ";
                                    sql += " '" + Cod + "', ";
                                    sql += " '', ";
                                    sql += " '" + Descricao + "', ";
                                    sql += " '1', ";
                                    sql += " '" + posicao + "', ";
                                    sql += " '" + Chamado + "', ";
                                    sql += " '', ";
                                    sql += " '', ";
                                    sql += " '" + Orc + "')";
                                    //MessageBox.Show(sql); 
                                    cx.Conectar();
                                    SqlCommand cd = new SqlCommand();
                                    cd.Connection = cx.c;
                                    cd.CommandText = sql;
                                    cd.ExecuteNonQuery();
                                    cx.Desconectar();
                                }
                                catch (SqlException x)
                                {
                                    MessageBox.Show("ERRO AO INSERIR ENTRADA DE ESTOQUE COM CHAMADO BACKUP: \r\n" + x.Message);
                                }
                                //================================================ FIM DA INSERÇÃO =================================================


                                // ===================================== ALTERA O STATUS DO AGUARDOBACKUP PARA RECEBIDO
                                consulta.comando = "";
                                consulta.comando = "update AguardoBackup set Status = 'RECEBIDO' where idAguardoBackup = '" + id + "'";
                                consulta.Atualizar();

                                // ===================================== RETIRA 1 DA QUANTIDADE QUE IRA ENTRAR NO REC DO ESTOQUE
                                Qnt = Qnt - 1;

                                // =================================================
                            }
                            else // NÃO PÕE NO ESTOQUE E ALTERA O STATUS DO AGUARDOBACKUP PARA CANCELADO
                            {
                                // =====================================
                                consulta.comando = "";
                                consulta.comando = "update AguardoBackup set Status = 'CANCELADO' where idAguardoBackup = '" + id + "'";
                                consulta.Atualizar();
                                // =====================================
                            }
                        }
                        else
                        {

                        }

                    }
                }
                dr2.Close();

            }
            catch (SqlException x)
            {
                MessageBox.Show("FALHA AO LISTAR CONSUMO ASSIT:\r\n" + x.Message);
            }
            cx2.Desconectar();
            //==================== FIM DA VERIFICAÇÃO DE AGUARDO DE BACKUP

        }

        public void ConcluirComChamado(string Cod, string Chamado, string Quantidade, string Descricao)
        {
            consulta.comando = "";
            consulta.comando += "select count(*) as Quantidade from Chamados WHERE Chamado = '" + Chamado + "' AND Status = 'PP'";
            consulta.consultarSimNao();
            // se esta em agurdo lança em pp
            if (consulta.Retorno == "ok" || Convert.ToInt32(consulta.qntNaPosicao) > 0)
            {               
                string Barebone = "";               
                string Tipo = "";
                string BareboneEquivalente = "";
                string sql = "";
                string posicao = "PP";
                try
                {
                    sql = "";
                    sql += " Insert into Estoque (Codigo, Barebone, Descricao, Quantidade, Posicao, Chamado, Tipo, BareboneEquivalente)";
                    sql += " Values ( ";
                    sql += " '" + Cod + "', ";
                    sql += " '" + Barebone + "', ";
                    sql += " '" + Descricao + "', ";
                    sql += " '" + Quantidade + "', ";
                    sql += " '" + posicao + "', ";
                    sql += " '" + Chamado + "', ";
                    sql += " '" + Tipo + "', ";
                    sql += " '" + BareboneEquivalente + "')";
                    //MessageBox.Show(sql); 
                    cx.Conectar();
                    SqlCommand cd = new SqlCommand();
                    cd.Connection = cx.c;
                    cd.CommandText = sql;
                    cd.ExecuteNonQuery();
                    cx.Desconectar();
                }
                catch (SqlException x)
                {
                    MessageBox.Show("ERRO AO INSERIR ENTRADA DE ESTOQUE COM CHAMADO: \r\n" + x.Message);
                }

            }
            // senão lança normalmente
            else
            {
                Concluir(Cod, Quantidade, Descricao);
            }


        }

        public void Concluir(string Cod, string Quantidade, string Descricao)
        {
            //VERIFICA SE EXISTE AGURADO DE BACKUP PARA ESSA PEÇA
            consulta.comando = "";
            consulta.comando += "select count(*) as Quantidade from AguardoBackup WHERE Codigo = '" + Cod + "' AND Status = 'PENDENTE'";
            consulta.consultarSimNao();
            if (consulta.Retorno == "ok" || Convert.ToInt32(consulta.qntNaPosicao) > 0)
            {
                int Qnt;
                AguardoBackUp(Cod, Quantidade, Descricao, out Qnt);
                Quantidade = Qnt.ToString();
            }

            if (Convert.ToInt32(Quantidade) > 0) //VERIFICA SE MESMO APOS INSERIR NO AGUARDO DE BACKUP AINDA TEM SALDO
            {
                string posicao = "REC";
                string qntNaPosicao = "";
                consulta.comando = "";
                consulta.comando += "Select * from Estoque where Codigo = '" + Cod + "' and Posicao = '" + posicao + "'";
                consulta.consultarSimNao();
                if (consulta.Retorno == "ok")
                {
                    qntNaPosicao = consulta.qntNaPosicao;
                    int total = 0;
                    total = Convert.ToInt32(qntNaPosicao) + Convert.ToInt32(Quantidade);
                    consulta.comando = "";
                    consulta.comando = "update Estoque set Quantidade = '" + total + "' where Posicao = '" + posicao + "' and Codigo = '" + Cod + "'";
                    // MessageBox.Show(consulta.comando);
                    consulta.Atualizar();
                }
                else
                {
                    string sql = "";
                    // consulta.comando = "";
                    //consulta.comando += "Select * from Estoque where Codigo = '" + Cod + "'";
                    consulta.Codigo = Cod;
                   // consulta.consultarEstoque(lblCT.Text);
                    string Barebone = consulta.Barebone;
                    //  string Descricao = consulta.Descricao;
                    string Tipo = consulta.Tipo;
                    string BareboneEquivalente = consulta.BareboneEquivalente;
                    try
                    {
                        sql = "";
                        sql += " Insert into Estoque (Codigo, Barebone, Descricao, Quantidade, Posicao, Tipo, BareboneEquivalente)";
                        sql += " Values ( ";
                        sql += " '" + Cod + "', ";
                        sql += " '" + Barebone + "', ";
                        sql += " '" + Descricao + "', ";
                        sql += " '" + Quantidade + "', ";
                        sql += " '" + posicao + "', ";
                        sql += " '" + Tipo + "', ";
                        sql += " '" + BareboneEquivalente + "')";
                        //MessageBox.Show(sql);        

                        cx.Conectar();
                        SqlCommand cd = new SqlCommand();
                        cd.Connection = cx.c;
                        cd.CommandText = sql;
                        cd.ExecuteNonQuery();
                        cx.Desconectar();

                    }
                    catch (SqlException x)
                    {
                        MessageBox.Show("ERRO AO CONCLUIR ENTRADA DE ESTOQUE: \r\n" + x.Message);
                    }
                    cx.Desconectar();
                }
            }
            
        }
       
       


    }
}
