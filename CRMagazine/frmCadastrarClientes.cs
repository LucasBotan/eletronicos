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
    public partial class frmCadastrarClientes : Form
    {
        public frmCadastrarClientes(string CPF, string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
            if (CPF.Length > 0)
            {
                Inicio = CPF;               
            }
        }

        Consulta consulta = new Consulta();
        Conexao cx = new Conexao();

        public string Inicio = "";
        private void frmRHCadastraColaborador_Load(object sender, EventArgs e)
        {
            PreencherComboboxVarejista();

            if(Inicio.Length > 0)
            {
                txtBusca.Text = Inicio;
                btnBusca.PerformClick();
            }
            else
            {
                txtBusca.Text = "";
            }            
        }

        public void Verificacao(Control parent, out string check)
        {
            check = "";

            foreach (Control cont in parent.Controls)
            {
                if (cont is TextBox)
                {
                    if ((cont as TextBox).Text.Length == 0)
                    {
                        check = "falha";
                        (cont as TextBox).BackColor = Color.Tomato;
                    }
                    else
                    {
                        (cont as TextBox).BackColor = DefaultBackColor;
                    }
                }
               // this.Verificacao(cont, out check);
            }


        }

        public void PreencherComboboxVarejista()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql = "";
            sql += " Select DISTINCT Nome from Clientes";
            cx.Conectar();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "Clientes");
            cboUsers.ValueMember = "idClientes";
            cboUsers.DisplayMember = "Nome";
            cboUsers.DataSource = ds.Tables["Clientes"];
            cx.Desconectar();
            cboUsers.Text = null;
            cboUsers.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboUsers.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboUsers.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            string check;
            Verificacao(panel2, out check);

            if (check == "falha")
            {
                consulta.PlayFail();
                MessageBox.Show("OS CAMPOS OBRIGATÓRIOS DEVEM ESTAR PREENCHIDOS.");
            }
            else
            {
                if (btnConcluir.Text == "CONCLUIR")
                {
                    consulta.InserirClientes(txtNome.Text, txtCPF.Text, txtEnderecoCli.Text, txtCidade.Text, txtBairro.Text, txtTelefone.Text, txtEmailPessoal.Text);
                    if (consulta.Retorno == "ok")
                    {
                        MessageBox.Show("COLABORADOR CADASTRADO COM SUCESSO.");
                        consulta.LimparControles(this);
                        btnConcluir.Text = "CONCLUIR";
                        panel2.Visible = false;
                        txtBusca.Select();
                        if (Inicio.Length > 0)
                        {
                            this.Close();
                        }
                    }
                }
                else
                {
                    Atualizar();
                    if (consulta.Retorno == "ok")
                    {
                        MessageBox.Show("DADOS DO COLABORADOR ALTERADOS COM SUCESSO.");
                        consulta.LimparControles(this);
                        btnConcluir.Text = "CONCLUIR";
                        panel2.Visible = false;
                        txtBusca.Select();                        
                    }
                }
                
            }
        }

        public void Atualizar()
        {
            string sql = "";
            sql = "update Clientes set ";
            sql += "Nome =  '" + txtNome.Text + "', ";
            sql += "CPF =  '" + txtCPF.Text + "', ";           
            sql += "Endereco =  '" + txtEnderecoCli.Text + "', ";
            sql += "Bairro =  '" + txtBairro.Text + "', ";
            sql += "Cidade =  '" + txtCidade.Text + "', ";
            sql += "Telefone =  '" + txtTelefone.Text + "', ";           
            sql += "EmailPessoal =  '" + txtEmailPessoal.Text + "' ";           
            sql += " where CPF = '" + txtBusca.Text + "'";
            consulta.comando = "";
            consulta.comando = sql;
            consulta.Atualizar();
           // MessageBox.Show(sql);
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            consulta.consultarClientes ("CPF", txtBusca.Text);
            if (consulta.Retorno == "ok")
            {
                if (MessageBox.Show("MATRICULA JÁ CADASTRADA.\r\nDEJESA ALTERAR?", "PERGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    panel2.Visible = true;
                    txtNome.Text = consulta.Nome;
                    txtCPF.Text = consulta.CPF;
                    txtEnderecoCli.Text = consulta.Endereco;
                    txtBairro.Text = consulta.Bairro;
                    txtCidade.Text = consulta.CidadeCliente;
                    txtTelefone.Text = consulta.Telefone;                   
                    txtEmailPessoal.Text = consulta.EmailPessoal;                
                    btnConcluir.Text = "ALTERAR";
                }
            }
            else
            {
                btnConcluir.Text = "CONCLUIR";
                txtCPF.Text = txtBusca.Text;
                panel2.Visible = true;
                txtNome.Select();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DEJESA LIMPAR A TELA?", "PERGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                consulta.LimparControles(this);
                btnConcluir.Text = "CONCLUIR";
                panel2.Visible = false;
                txtBusca.Select();
            }
        }

        private void rbtProducao_CheckedChanged(object sender, EventArgs e)
        {
           

        }

        private void rbtADM_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void cboUsers_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboUsers.Text.Length > 0)
            {
                consulta.consultarClientes("NOME", cboUsers.Text);
                txtBusca.Text = consulta.CPF;
                //txtUserBloqueio.Text = consulta.Login;
            }     
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        

          
    }
}
