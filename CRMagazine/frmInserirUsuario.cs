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
    public partial class frmInserirUsuario : Form
    {
        public frmInserirUsuario(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        private void frmInserirUsuario_Load(object sender, EventArgs e)
        {

        }
        Consulta consulta = new Consulta();
        Conexao cx = new Conexao();



        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if ((rbtDeleteUsuario.Checked == false) && (rbtNovoUsuario.Checked == false) && (rbtUsuarioExistente.Checked == false) && (rbtResetSenha.Checked == false))
            {
                MessageBox.Show("Selecione uma das Opções");
            }
            else
            {
                if (rbtUsuarioExistente.Checked == true)
                {
                    if (MessageBox.Show("DESEJA ALTERAR AS PERMISSÕES DO USUÁRIO " + cbxUsuario.Text + " ? ", "Pergunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        consulta.comando = "update Usuarios set ";
                        consulta.comando += " Entrada = '" + cbxEntrada.Text + "', ";
                        consulta.comando += " Vistoria = '" + cbxVistoria.Text + "', ";
                        consulta.comando += " Reparo = '" + cbxReparo.Text + "', ";
                        consulta.comando += " Runin = '" + cbxRunin.Text + "', ";
                        consulta.comando += " Expedicao = '" + cbxExpedicao.Text + "', ";
                        consulta.comando += " Consultas = '" + cbxConsultas.Text + "', ";
                        consulta.comando += " Embalagem = '" + cbxEmbalagem.Text + "', ";
                        consulta.comando += " Estoque = '" + cbxEstoque.Text + "', ";
                        consulta.comando += " Assist = '" + cbxAssist.Text + "', ";
                        consulta.comando += " Ajuste = '" + cbxAjuste.Text + "', ";
                        consulta.comando += " ADM = '" + cbxADM.Text + "' ";
                        consulta.comando += " Where Usuario = '" + cbxUsuario.Text + "' AND CT = '" + lblCT.Text + "' ";
                        consulta.Atualizar();
                        if (consulta.Retorno == "ok")
                        {
                            LimparControles();
                            MessageBox.Show("Concluido");
                        }
                        else
                        {
                            MessageBox.Show("Falha");
                        }
                    }                    
                }
                else if (rbtNovoUsuario.Checked == true)
                {
                    if (MessageBox.Show("CONFIRMA O CADASTRO DO USUÁRIO " + cbxUsuario.Text + " ? ", "Pergunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        consulta.comando = "insert into Usuarios (Usuario, Senha, Entrada, Vistoria, Reparo, Runin, Expedicao, Consultas, Embalagem, Estoque, Assist, Ajuste, ADM, CT ) values ";
                        consulta.comando += "('" + txtUsuario.Text + "', ";
                        consulta.comando += "'123', ";
                        consulta.comando += "'" + cbxEntrada.Text + "', ";
                        consulta.comando += "'" + cbxVistoria.Text + "', ";
                        consulta.comando += "'" + cbxReparo.Text + "', ";
                        consulta.comando += "'" + cbxRunin.Text + "', ";
                        consulta.comando += "'" + cbxExpedicao.Text + "', ";
                        consulta.comando += "'" + cbxConsultas.Text + "', ";
                        consulta.comando += "'" + cbxEmbalagem.Text + "', ";
                        consulta.comando += "'" + cbxEstoque.Text + "', ";
                        consulta.comando += "'" + cbxAssist.Text + "', ";
                        consulta.comando += "'" + cbxAjuste.Text + "', ";
                        consulta.comando += "'" + cbxADM.Text + "', ";
                        consulta.comando += "'" + lblCT.Text + "')";
                        consulta.Atualizar();
                        //MessageBox.Show(consulta.comando);
                        if (consulta.Retorno == "ok")
                        {
                            LimparControles();
                            MessageBox.Show("Concluido");
                        }
                        else
                        {
                            MessageBox.Show("Falha");
                        }
                    }                    
                }
                else if (rbtDeleteUsuario.Checked == true)
                {
                    if (MessageBox.Show("DESEJA DELETAR O USUÁRIO " + cbxUsuario.Text + " ? ", "Pergunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        consulta.comando = "delete from Usuarios Where Usuario = '" + cbxUsuario.Text + "' AND CT = '" + lblCT.Text + "' ";
                        consulta.Atualizar();
                        if (consulta.Retorno == "ok")
                        {
                            LimparControles();
                            MessageBox.Show("Excluido");
                        }
                        else
                        {
                            MessageBox.Show("Falha");
                        }
                    }  
                    
                }
                else if (rbtResetSenha.Checked == true)
                {
                    if (MessageBox.Show("DESEJA RESETAR A SENHA DO USUÁRIO " + cbxUsuario.Text + " ? ", "Pergunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        consulta.comando = "update Usuarios set ";
                        consulta.comando += " Senha = '123' ";
                        consulta.comando += " Where Usuario = '" + cbxUsuario.Text + "' AND CT = '" + lblCT.Text + "' ";
                        consulta.Atualizar();
                        if (consulta.Retorno == "ok")
                        {
                            LimparControles();
                            MessageBox.Show("Senha Alterada Para 123");
                        }
                        else
                        {
                            MessageBox.Show("Falha");
                        }
                    }
                    
                }
            }
        }

        private void cbxUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            consulta.Usuario = cbxUsuario.Text;
            consulta.consultarUsuario(cbxUsuario.Text, lblCT.Text);
            if (consulta.Retorno == "ok")
            {
                cbxEntrada.Text = consulta.Entrada;
                cbxVistoria.Text = consulta.Vistoria;
                cbxReparo.Text = consulta.Reparo;
                cbxRunin.Text = consulta.Runin;
                cbxEmbalagem.Text = consulta.Embalagem;
                cbxExpedicao.Text = consulta.Expedicao;
                cbxConsultas.Text = consulta.Consultas;
                cbxEstoque.Text = consulta.Estoque;
                cbxAssist.Text = consulta.Assist;
                cbxAjuste.Text = consulta.Ajuste;
                cbxADM.Text = consulta.ADM;
            }
            else
            {
                MessageBox.Show("Usuário Não Encontrado");
            }
        }

        public void ListarUsuarios()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql += " Select Usuario from Usuarios where CT = '" + lblCT.Text + "' ";
            // sql += " Order by  Categoria ";
            cx.Conectar();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "Usuarios");
            cbxUsuario.ValueMember = "idUsuario";
            cbxUsuario.DisplayMember = "Usuario";
            cbxUsuario.DataSource = ds.Tables["Usuarios"];
            cx.Desconectar();
            cbxUsuario.Text = "";
        }

        private void rbtUsuarioExistente_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtUsuarioExistente.Checked == true)
            {
                ListarUsuarios();
                cbxUsuario.Visible = true;
                txtUsuario.Visible = false;
            }
        }

        private void rbtDeleteUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtDeleteUsuario.Checked == true)
            {
                ListarUsuarios();
                cbxUsuario.Visible = true;
                txtUsuario.Visible = false;
            }
        }

        private void rbtResetSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtResetSenha.Checked == true)
            {
                ListarUsuarios();
                cbxUsuario.Visible = true;
                txtUsuario.Visible = false;
            }
        }

        private void rbtNovoUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtNovoUsuario.Checked == true)
            {
                cbxUsuario.Text = "";
                cbxUsuario.Visible = false;
                txtUsuario.Visible = true;
            }
           
        }

        private void btnLimparTela_Click(object sender, EventArgs e)
        {
            LimparControles();
            cbxUsuario.Visible = false;
            txtUsuario.Visible = false;
        }

        public void LimparControles()
        {
            this.LimparControles(this);
        }

        public void LimparControles(Control parent)
        {
            foreach (Control cont in parent.Controls)
            {
                if (cont is TextBox) { (cont as TextBox).Text = ""; }

                if (cont is ComboBox) { (cont as ComboBox).Text = ""; }

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

       
    }
}
