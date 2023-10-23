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
    public partial class frmTrocarSenha : Form
    {
        public frmTrocarSenha(string texto, string texto2, string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
            txtSenha.Text = texto;
            txtUsuario.Text = texto2;
        }

        Conexao cx = new Conexao();

        private void txtSenhaAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtSenhaAtual.Text == txtSenha.Text)
                {
                    grbSenha.Visible = true;
                }
                else
                {
                    MessageBox.Show("Senha incorreta");
                }
            }
        }

        public void MudarSenha()
        {
            string sql = "";
            try
            {
                sql += "update Usuarios set Senha = '" + txtNovaSenha.Text + "' where Usuario = '" + txtUsuario.Text + "' and CT = '" + lblCT.Text + "'";
                cx.Conectar();
                SqlCommand cd = new SqlCommand();
                cd.Connection = cx.c;
                cd.CommandText = sql;
                cd.ExecuteNonQuery();                
            }
            catch (Exception x)
            {
                MessageBox.Show("MudarSenha -> " + x.Message);
            }
            cx.Desconectar();            
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((txtNovaSenha.Text == txtConfirmaNovaSenha.Text) && (txtNovaSenha.Text.Length != 0))
            {
                MudarSenha();
                MessageBox.Show("Senha Alterada");
                txtSenhaAtual.Text = "";
                txtNovaSenha.Text = "";
                txtConfirmaNovaSenha.Text = "";
                grbSenha.Visible = false;
                this.Close();
            }
            else
            {
                MessageBox.Show("Senhas Não conferem");
            }
        }

        private void frmTrocarSenha_Load(object sender, EventArgs e)
        {

        }

        
    }
}
