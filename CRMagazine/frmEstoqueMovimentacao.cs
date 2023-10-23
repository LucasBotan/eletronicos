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
    public partial class frmEstoqueMovimentacao : Form
    {
        public frmEstoqueMovimentacao(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        private void frmEstoqueMovimentacao_Load(object sender, EventArgs e)
        {
            ListarPosicaoes();
            ListarTudo();
            FormatarGrid();
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();

        public string idCod = "";
        public string codigo = "";
      //  public string Barebone = "";
        public string Descricao = "";
        public string qnt = "";
        public string Posicao = "";
        public string qntNaPosicao = "";
        //public string tipo = "";

       
        public void ListarPosicaoes()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql += " Select Distinct Posicao from Estoque WHERE CT = '" + lblCT.Text + "'";
            cx.Conectar();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "Estoque");
            cbxPosicao.ValueMember = "idEstoque";
            cbxPosicao.DisplayMember = "Posicao";
            cbxPosicao.DataSource = ds.Tables["Estoque"];
            cx.Desconectar();
            cbxPosicao.Text = "REC";
        }        

        public void ListarTudo()
        {
            string sql = "";
            sql += " Select idCod, Codigo, Descricao, Quantidade, Posicao from Estoque where Posicao = '" + cbxPosicao.Text + "' and Quantidade > 0 and CT = '" + lblCT.Text + "'";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Estoque");
            dgvConsulta.DataSource = ds.Tables["Estoque"];
            cx.Desconectar();
            int total = 0;
            string totalgeral = dgvConsulta.Rows.Count.ToString();
            //total = dgvConsulta.Rows[1].Cells.Count.ToString();
            total = Convert.ToInt32(totalgeral);
            lblTotal.Text = total.ToString();
        }

        public void ListarComCodigo()
        {
            string sql = "";
            sql += " Select idCod, Codigo, Descricao, Quantidade, Posicao from Estoque where Posicao = '" + cbxPosicao.Text + "' and Codigo = '" + txtConsultaCodigo.Text + "' and Quantidade > 0 and CT = '" + lblCT.Text + "'";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Estoque");
            dgvConsulta.DataSource = ds.Tables["Estoque"];
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
            sql += " select idCod, Codigo, Descricao, Quantidade, Posicao from Estoque where Codigo = '" + codigo + "' and Posicao != '" + Posicao + "' and Posicao != 'PP' and CT = '" + lblCT.Text + "'";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Estoque");
            dgvLocal.DataSource = ds.Tables["Estoque"];
            cx.Desconectar();
        }
              
        public void FormatarGrid()
        {

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            //Image imagem = Image.FromFile(pictureBox1.Image);
            Image imagem = pictureBox1.Image;
            img.Image = imagem;
            dgvConsulta.Columns.Add(img);
            img.HeaderText = "Busca";
            img.Name = "Busca";
            //dgvConsulta.AutoResizeColumns();
            dgvConsulta.Columns[0].Visible = false;
            dgvConsulta.RowHeadersVisible = false;
            // dgvConsulta.Columns[1].Width = 80;
            //dgvConsulta.Columns[2].Width = 80;
            //dgvConsulta.Columns[3].Width = 200;
            dgvConsulta.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvConsulta.ScrollBars = ScrollBars.Vertical;
            //dgvConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        }

        public void ReFormatarGrid()
        {            

            //dgvConsulta.AutoResizeColumns();
            dgvConsulta.Columns[0].Visible = false;
            dgvConsulta.RowHeadersVisible = false;
            // dgvConsulta.Columns[1].Width = 80;
            //dgvConsulta.Columns[2].Width = 80;
            //dgvConsulta.Columns[3].Width = 200;
            dgvConsulta.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvConsulta.ScrollBars = ScrollBars.Vertical;
            //dgvConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        }

        public void FormatarGridListar()
        {
            dgvLocal.AutoResizeColumns();
            dgvLocal.Columns[0].Visible = false;
            dgvLocal.RowHeadersVisible = false;
            //dgvConsulta.Columns[1].Width = 80;
            //dgvConsulta.Columns[2].Width = 80;
            //dgvConsulta.Columns[3].Width = 200;
            dgvLocal.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvConsulta.ScrollBars = ScrollBars.Vertical;
            dgvLocal.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        }
        

        private void dgvConsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvConsulta.Columns[e.ColumnIndex].Name == "Busca")
                {
                    qnt = dgvConsulta.Rows[e.RowIndex].Cells["Quantidade"].Value.ToString();
                    codigo = dgvConsulta.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                    Posicao = dgvConsulta.Rows[e.RowIndex].Cells["Posicao"].Value.ToString();
                    Descricao = dgvConsulta.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
                   // Barebone = dgvConsulta.Rows[e.RowIndex].Cells["Barebone"].Value.ToString();
                   // tipo = dgvConsulta.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();
                    txtCodigo.Text = codigo;
                    txtQnt.Text = qnt;
                    txtDescricao.Text = Descricao;
                   // txtTipo.Text = tipo;
                    ListarLocais();
                    FormatarGridListar();
                    txtQntdASerMovida.Select();
                    //  MessageBox.Show(oi);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
                
               

        public void Insere()
        {
            consulta.comando = "";
            consulta.comando = "Insert into Estoque (CT, Codigo, Descricao, Quantidade, Posicao) Values (";
            consulta.comando += " '" + lblCT.Text + "', ";
            consulta.comando += " '" + codigo + "', ";
           // consulta.comando += " '" + Barebone + "', ";
            consulta.comando += " '" + Descricao + "', ";
            consulta.comando += " '" + txtQntdASerMovida.Text + "', ";
            consulta.comando += " '" + txtRetirar.Text + "') ";
          //  consulta.comando += " '" + txtTipo.Text + "')";
            consulta.Atualizar();
        }

        public void AtualizaDestino()
        {
            int total = 0;
            total = Convert.ToInt32(qntNaPosicao) + Convert.ToInt32(txtQntdASerMovida.Text);
            consulta.comando = "";
            consulta.comando = "update Estoque set Quantidade = '" + total + "' where Posicao = '" + txtRetirar.Text + "' and Codigo = '" + codigo + "' and CT = '" + lblCT.Text + "'";
            consulta.Atualizar();
            
        }

        public void AtualizaLocal()
        {
            int total = 0;
            total = Convert.ToInt32(txtQnt.Text) - Convert.ToInt32(txtQntdASerMovida.Text);
            consulta.comando = "";
            consulta.comando = "update Estoque set Quantidade = '" + total + "' where Posicao = '" + Posicao + "' and Codigo = '" + codigo + "' and CT = '" + lblCT.Text + "'";
            consulta.Atualizar();
            Reset();
        }

        public void Reset()
        {
            LimparControles(this);
            //===========zerar variaveis========
            idCod = "";
            codigo = "";
            //Barebone = "";
           // tipo = "";
            Descricao = "";
            qnt = "";
            Posicao = "";
            qntNaPosicao = "";
            //==================================
            pictureBox2.Select();
            ListarTudo();
            ListarLocais();
            txtConsultaCodigo.Select();
        }


        public void LimparControles(Control parent)
        {
            foreach (Control cont in parent.Controls)
            {
                if (cont is TextBox) { (cont as TextBox).Text = ""; }

               // if (cont is ComboBox) { (cont as ComboBox).Text = ""; }

                if (cont is MaskedTextBox) { (cont as MaskedTextBox).Text = ""; }

                if (cont is RadioButton) { (cont as RadioButton).Checked = false; }

                if (cont is CheckedListBox)
                {
                    foreach (ListControl item in (cont as CheckedListBox).Items)
                        item.SelectedIndex = -1;
                }
                if (cont is ListBox) { (cont as ListBox).Items.Clear(); }

                if (cont is ListView) { (cont as ListView).Items.Clear(); }

                // varre os filhos...
                this.LimparControles(cont);
            }
        }


        public void Concluir()
        {
            if ((txtQntdASerMovida.Text.Length == 0) || (Convert.ToInt32(txtQntdASerMovida.Text) <= 0) || (Convert.ToInt32(txtQntdASerMovida.Text) > Convert.ToInt32(txtQnt.Text)))
            {
                MessageBox.Show("VERIFIQUE A QUANTIDADE");
                txtQntdASerMovida.Text = "";
                txtQntdASerMovida.Select();
            }
            else
            {
                string confirmaPosicao = "";
                for (int i = 0; i < dgvLocal.RowCount; i++)
                {

                    try
                    {
                        string texto = dgvLocal.Rows[i].Cells[5].Value.ToString();
                        if (texto == txtRetirar.Text)
                        {
                            confirmaPosicao = texto;
                            break;
                        }
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(x.Message);
                    }
                }

                if (confirmaPosicao == txtRetirar.Text)
                {
                    consulta.comando = "";
                    consulta.comando += "Select * from Estoque where Codigo = '" + txtCodigo.Text + "' and Posicao = '" + txtRetirar.Text + "' and CT = '" + lblCT.Text + "'";
                    //MessageBox.Show(consulta.comando);
                    consulta.consultarSimNao();
                    if (consulta.Retorno == "ok")
                    {
                        qntNaPosicao = consulta.qntNaPosicao;
                        AtualizaDestino();
                        AtualizaLocal();
                       // ListarPosicaoes();
                    }
                    else if (consulta.Retorno == "falha")
                    {
                        Insere();
                        AtualizaLocal();
                       // ListarPosicaoes();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao consultar se existe esse codigo nessa posição");
                    }
                }
                else
                {
                    if (MessageBox.Show("Esse código ainda não existe nessa posição\r\nDeseja inseri-lo mesmo assim?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        consulta.comando = "";
                        consulta.comando += "Select * from Estoque where Codigo = '" + txtCodigo.Text + "' and Posicao = '" + txtRetirar.Text + "' and CT = '" + lblCT.Text + "'";
                        //MessageBox.Show(consulta.comando);
                        consulta.consultarSimNao();
                        if (consulta.Retorno == "ok")
                        {
                            qntNaPosicao = consulta.qntNaPosicao;
                            AtualizaDestino();
                            AtualizaLocal();
                           // ListarPosicaoes();
                        }
                        else if (consulta.Retorno == "falha")
                        {
                            Insere();
                            AtualizaLocal();
                            //ListarPosicaoes();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao consultar se existe esse codigo nessa posição");
                        }
                    }
                }
            }         
        }

        private void txtRetirar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtQntdASerMovida.Select();
            }
        }

        private void txtQntdASerMovida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnConcluir.Select();
            }
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            Concluir();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Reset();
        }              

        private void cbxPosicao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ListarTudo();
            }
        }

        private void txtConsultaCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ListarComCodigo();
            }
        }

        private void txtQntdASerMovida_Leave(object sender, EventArgs e)
        {
            btnConcluir.Select();
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

        private void dgvLocal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbxPosicao_MouseClick(object sender, MouseEventArgs e)
        {
           // ListarPosicaoes();
        }

       
    }
}
