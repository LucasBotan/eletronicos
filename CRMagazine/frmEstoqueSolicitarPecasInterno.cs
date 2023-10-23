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
    public partial class frmEstoqueSolicitarPecasInterno : Form
    {
        public string tecnica = "";
        public frmEstoqueSolicitarPecasInterno(string texto, string OS, string SKU, string Chamado, string Situacao, string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
            lblUsuario.Text = texto;
            txtOS.Text = OS;
            txtNS.Text = Chamado;
            txtParteDesc.Text = "";
            txtSKU.Text = SKU;
            txtSituacao.Text = Situacao;
            if (OS != "")
            {
                btnAdicionar.Visible = true;
                btnRetirar.Visible = true;
                lstPedidos.Visible = true;
                btnConcluir.Enabled = false;
                btnLimparTela.Enabled = false;
                txtQntd.Text = "1";
                txtQntd.ReadOnly = true;
                tecnica = "yes";
                consultarEstoque();
            }
        }

        Conexao cx = new Conexao();
        Consulta consultar = new Consulta();

        private void frmEstoqueSolicitarPecas_Load(object sender, EventArgs e)
        {
            consultarEstoque();
            FormatarGrid();
            txtParteDesc.Select();
        }

        public void FormatarGrid()
        {
            //NAO PRECISA ADD IMAGEM PARA BUSCA, PQ NO ESQUEMA NOVA VAI PUXAR DO CHECKLIST
            /*
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            //Image imagem = Image.FromFile(pictureBox1.Image);
            Image imagem = pictureBox2.Image;
            img.Image = imagem;
            dgvConsulta.Columns.Add(img);
            img.HeaderText = "Busca";
            img.Name = "Busca";
             */ 

            //dgvConsulta.AutoResizeColumns();
          //  dgvConsulta.Columns[0].Visible = false;
            dgvConsulta.RowHeadersVisible = false;
            // dgvConsulta.Columns[1].Width = 80;
            //dgvConsulta.Columns[2].Width = 80;
            //dgvConsulta.Columns[3].Width = 200;
            dgvConsulta.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvConsulta.ScrollBars = ScrollBars.Vertical;
            //dgvConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        }

        public void consultarEstoque()
        {
            string sql = "";

            if ((txtParteDesc.Text.Length == 0) && (txtDescricao.Text.Length == 0))
            {
                sql = "";
                // sql = "select Codigo, Descricao, Barebone, sum(Quantidade)As Quantidade from Estoque E, BaseCodigo B where E.Codigo = B.Codigo and B.SKU = '%"+txtSKU.Text+ "%' and Descricao like '%xxzzyy%' and Barebone like '%xxzzyy%' group by Codigo, Descricao, Barebone ";

                sql = "select Codigo, Descricao, sum(Quantidade) As Quantidade from Estoque where Descricao like '%xxzzyy%' and Descricao like '%xxzzyy%' and CT = '" + lblCT.Text + "' group by Codigo, Descricao order by Quantidade";
                
                //sql = "select * FROM CheckListGeral WHERE TIPOEQUIP = '" + txtSKU.Text + "' ORDER BY ESPECIE";
                cx.Conectar();
                SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
                DataSet ds = new DataSet();
                da.Fill(ds, "Estoque");
                dgvConsulta.DataSource = ds.Tables["Estoque"];
                cx.Desconectar();
            }
            else
            {
                sql = "";
                // sql = "select Codigo, Descricao, Barebone, sum(Quantidade)As Quantidade from Estoque E, BaseCodigo B where E.Codigo = B.Codigo and B.SKU = '%"+txtSKU.Text+ "%' and Descricao like '%xxzzyy%' and Barebone like '%xxzzyy%' group by Codigo, Descricao, Barebone ";

                sql = "select Codigo, Descricao, sum(Quantidade) As Quantidade from Estoque where Descricao like '%" + txtDescricao.Text + "%' and Descricao like '%" + txtParteDesc.Text + "%' and CT = '" + lblCT.Text + "' group by Codigo, Descricao order by Quantidade";
                
               // sql = "select * FROM CheckListGeral WHERE TIPOEQUIP = '" + txtSKU.Text + "' AND ITEM like '%" + txtDescricao.Text + "%' and ITEM like '%" + txtParteDesc.Text + "%' ORDER BY ESPECIE";
                cx.Conectar();
                SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
                DataSet ds = new DataSet();
                da.Fill(ds, "Estoque");
                dgvConsulta.DataSource = ds.Tables["Estoque"];
                cx.Desconectar();
            }

            /*
            if ((txtParteDesc.Text.Length == 0) && (txtDescricao.Text.Length == 0))
            {
                sql = "";
               // sql = "select Codigo, Descricao, Barebone, sum(Quantidade)As Quantidade from Estoque E, BaseCodigo B where E.Codigo = B.Codigo and B.SKU = '%"+txtSKU.Text+ "%' and Descricao like '%xxzzyy%' and Barebone like '%xxzzyy%' group by Codigo, Descricao, Barebone ";
                sql = "select E.Codigo, E.Descricao, Barebone, sum(Quantidade)As Quantidade from Estoque E, BaseCodigos B where E.Codigo = B.Codigo and B.SKU = '" + txtSKU.Text + "' and Quantidade > '0' group by E.Codigo, E.Descricao, E.Barebone ";
                cx.Conectar();
                SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
                DataSet ds = new DataSet();
                da.Fill(ds, "Estoque");
                dgvConsulta.DataSource = ds.Tables["Estoque"];
                cx.Desconectar();
            }
            else
            {
                sql = "";
               // sql = "select Codigo, Descricao, Barebone, sum(Quantidade)As Quantidade from Estoque where Descricao like '%" + txtDescricao.Text + "%' and Descricao like '%" + txtParteDesc.Text + "%' group by Codigo, Descricao, Barebone ";
                sql = "select E.Codigo, E.Descricao, Barebone, sum(Quantidade)As Quantidade from Estoque E, BaseCodigos B where E.Codigo = B.Codigo and B.SKU = '" + txtSKU.Text + "' AND E.Descricao like '%" + txtDescricao.Text + "%' and E.Descricao like '%" + txtParteDesc.Text + "%' group by E.Codigo, E.Descricao, E.Barebone ";
                cx.Conectar();
                SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
                DataSet ds = new DataSet();
                da.Fill(ds, "Estoque");
                dgvConsulta.DataSource = ds.Tables["Estoque"];
                cx.Desconectar();
            }   
             */ 
        }


        public void ConsultaCodigo()
        {
            consultar.Codigo = txtCodPeca.Text.ToString();
            consultar.consultarEstoque(lblCT.Text);
            if (consultar.Retorno == "ok")
            {
                txtDescPeca.Text = consultar.Descricao;
                txtTipo.Text = consultar.Tipo;
                if ((txtNS.Text == "") && (txtTipo.Text == "Bateria" || txtTipo.Text == "PLM"))
                {
                    MessageBox.Show("NÃO É POSSIVEL SOLICITAR PEÇAS FUNCIONAIS!");
                    txtCodPeca.Text = "";
                    txtDescricao.Text = "";
                    txtDescPeca.Text = "";
                    txtTipo.Text = "";
                    txtCodPeca.Select();
                }
                txtQntd.Select();
            }
            else
            {
                MessageBox.Show("CÓDIGO NÃO ENCONTRADO NO ESTOQUE!");
                txtCodPeca.Text = "";
                txtCodPeca.Select();
            }

            //contar a qntd em estoque 
            int Estoque = 0;
            consultar.Codigo = txtCodPeca.Text.ToString();
            consultar.ContarEstoque(lblCT.Text);
            Estoque = consultar.Contagem;
            //contar a qntd já solicitada
            int Pedidos = 0;
            consultar.Codigo = txtCodPeca.Text.ToString();
            consultar.ContarEmPedidos(lblCT.Text);
            Pedidos = consultar.Contagem;
            //subtrai as qntds para obter a disponibilidade real em estoque
            txtDisponivel.Text = Convert.ToString(Estoque - Pedidos);
        }


        private void txtCodPeca_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            //{
            //    e.Handled = true;
            //}
            if (e.KeyChar == 13)
            {
                ConsultaCodigo();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(txtDisponivel.Text) < Convert.ToInt32(txtQntd.Text)) || (Convert.ToInt32(txtQntd.Text) <= 0))
            {
                MessageBox.Show("Quantidade Indisponivel");
                // txtQntd.Text = "";
                // txtQntd.Select();
            }
           // else if (txtCodAntigo.Text.Length == 0 || txtDescPecaAntiga.Text.Length == 0)
          //  {
          //      MessageBox.Show("PREENCHA O CÓDIGO ANTIGO E TECLE ENTER.\r\n\r\n(O MESMO DO ASSIST).");
          //  }
            else
            {
                AdicionarNaLista();
                btnConcluir.Enabled = true;
                txtCodPeca.Text = "";
                txtDescPeca.Text = "";
                txtQntd.Text = "";
                txtCodPeca.Select();
                

            }
           
        }

        public void AdicionarNaLista()
        {
            consultar.DataAtual();
            string data = consultar.dataCompleta;
            string Aux = "";
            //consultar.comando = "Insert into Pedidos (Usuario, Codigo, Descricao, Quantidade, Status, HoraPedido, OS, CodAntigo, DescPecaAntiga) Values ( ";
            //Aux += " '" + lblUsuario.Text + "', ";
            Aux += " '" + txtCodPeca.Text + "', ";
            Aux += " '" + txtDescPeca.Text + "', ";
            Aux += " '" + txtQntd.Text + "', ";
            //Aux += " '" + txtCodAntigo.Text + "', ";
            //Aux += " '" + txtDescPecaAntiga.Text + "', ";
            // Aux += "'AGUARDANDO', ";
            // Aux += " '" + data + "', ";
            // Aux += " '" + txtOS.Text + "' )";
            if (lstPedidos.Items.Contains(Aux))
            {
                MessageBox.Show("PEÇA JÁ INSERIDA NO PEDIDO");
            }
            else
            {
                lstPedidos.Items.Add(Aux);
            }                    
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            RetirarDaLista();
        }

        public void RetirarDaLista()
        {
            //lstPedidos.SelectedItems.Clear();
            try
            {
                lstPedidos.Items.RemoveAt(lstPedidos.SelectedIndex);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            
        }

        public void concluirPedido()
        {
            consultar.DataAtual();
            string data = consultar.dataCompleta;
            if (txtNS.Text != "")
            {
                string stringMontada = "";
                stringMontada = "Insert into Pedidos (CT, Usuario, Codigo, Descricao, Quantidade, Status, HoraPedido, OS, NS, Situacao) Values ";
                int rows = lstPedidos.Items.Count;
                foreach (string item in lstPedidos.Items)
                {
                    if (rows > 1)
                    {
                        stringMontada += " (";
                        stringMontada += " '" + lblCT.Text + "', ";
                        stringMontada += " '" + lblUsuario.Text + "', ";
                        stringMontada += item;
                        stringMontada += "'AGUARDANDO', ";
                        stringMontada += " '" + data + "', ";
                        stringMontada += " '" + txtOS.Text + "' , ";
                        stringMontada += " '" + txtNS.Text + "', ";
                        stringMontada += " '" + txtSituacao.Text + "' ), ";
                    }
                    else
                    {
                        stringMontada += " (";
                        stringMontada += " '" + lblCT.Text + "', ";
                        stringMontada += " '" + lblUsuario.Text + "', ";
                        stringMontada += item;
                        stringMontada += "'AGUARDANDO', ";
                        stringMontada += " '" + data + "', ";
                        stringMontada += " '" + txtOS.Text + "' , ";
                        stringMontada += " '" + txtNS.Text + "', ";
                        stringMontada += " '" + txtSituacao.Text + "' ) ";
                    }
                    rows--;
                }
                consultar.comando = "";
                consultar.comando = stringMontada;
            }
            else
            {
                consultar.comando = "";
                consultar.comando = "Insert into Pedidos (CT, Usuario, Codigo, Descricao, Quantidade, Status, HoraPedido, OS, NS, Situacao) Values ( ";
                consultar.comando += " '" + lblCT.Text + "', ";
                consultar.comando += " '" + lblUsuario.Text + "', ";
                consultar.comando += " '" + txtCodPeca.Text + "', ";
                consultar.comando += " '" + txtDescPeca.Text + "', ";
                consultar.comando += " '" + txtQntd.Text + "', ";
                consultar.comando += "'AGUARDANDO', ";
                consultar.comando += " '" + data + "', ";
                consultar.comando += " '" + txtOS.Text + "', ";
                consultar.comando += " '" + txtNS.Text + "', ";
              //  consultar.comando += " '" + txtCodAntigo.Text + "', ";
               // consultar.comando += " '" + txtDescPecaAntiga.Text + "', ";
                consultar.comando += " '" + txtSituacao.Text + "' )";
            }
            // MessageBox.Show(consultar.comando);            
            consultar.Atualizar();
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            /*
            if ((Convert.ToInt32(txtDisponivel.Text) < Convert.ToInt32(txtQntd.Text)) || (Convert.ToInt32(txtQntd.Text) <= 0))
            {
                MessageBox.Show("Quantidade Indisponivel");
                txtQntd.Text = "";
                txtQntd.Select();
            }
             */ 
          //  else if (lstPedidos.Items.Count == 0 && txtDescPecaAntiga.Text.Length == 0)
          //  {
          //      MessageBox.Show("INFORME A PEÇA ANTIGA.");
          //  }
            if (lstPedidos.Items.Count == 0)
            {
                MessageBox.Show("INSIRA OS PEDIDO DO CAMPO DE TEXTO UTILIZANDO O BOTÃO '+'.");
            }
            else
            {
                concluirPedido();
                if (consultar.Retorno == "ok")
                {
                    MessageBox.Show("PEDIDO CONCLUIDO");
                    if (txtNS.Text != "")
                    {
                        this.Close();
                    }
                    else
                    {
                        consultar.LimparControles(this);
                        txtCodPeca.Select();
                    }                    
                }
                else
                {
                    MessageBox.Show("ERRO: PEDIDO NÃO CONCLUIDO");
                }
            }
            
        }

        private void btnLimparTela_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            consultar.LimparControles(this);
            txtCodPeca.Select();
        }

        private void txtQntd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            consultarEstoque();
        }

        private void dgvConsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvConsulta.Columns[e.ColumnIndex].Name == "Busca")
                {
                    txtCodPeca.Text = dgvConsulta.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                    ConsultaCodigo();   
                   // txtDescricao.Text = dgvConsulta.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void lnkConsultarEstoqueSP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtOS.Text.Length == 0 || txtOS.Text == "PENDENTE")
            {
                MessageBox.Show("É NECESSÁRIO ABRIR O CHAMADO PARA ESSE EQUIPAMENTO.");
            }
            else
            {
               // old_frmEstoqueSolicitarPecasSAOPAULO c = new old_frmEstoqueSolicitarPecasSAOPAULO(lblUsuario.Text, txtNS.Text, "", txtOS.Text, "BACKUP");
               // c.ShowDialog();
               // this.Close();
            }
            
        }

        private void txtCodAntigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtCodAntigo.Text == "S/N")
                {
                    txtDescPecaAntiga.Text = "S/N";
                }
                else if (txtCodAntigo.Text.Length == 0)
                {
                    MessageBox.Show("INFORME O CÓDIGO DA PEÇA ANTIGA.");
                }
                else
                {
                    consultar.Codigo = txtCodAntigo.Text.ToString();
                    consultar.consultarEstoque(lblCT.Text);
                    if (consultar.Retorno == "ok")
                    {
                        txtDescPecaAntiga.Text = consultar.Descricao;
                    }
                    else
                    {
                        MessageBox.Show("CÓDIGO NÃO ENCONTRADO NO ESTOQUE!");
                    }
                }
            }
        }

        

       


    }
}
