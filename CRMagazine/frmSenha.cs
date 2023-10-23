using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMagazine
{
    public partial class frmSenha : Form
    {
        public frmSenha(string tipo, string Mensagem, string CT)
        {
            InitializeComponent();
            txtTexto.Focus();
            Tipo = tipo;
            lblTitulo.Text = Mensagem;
            lblCT.Text = CT;
            this.Text = Mensagem;
        }

        //TIPOS:
        //"VOLTAGEM" PARA INSERIR OS VOLTS
        //"SENHA" PARA SOLICITAR SENHA
        //"OUTROS" PARA SOLICITAR TEXTOS AVLSOS
        //"3G" PARA INFORMAR O IMEI DO TABLET COM 3G

        Consulta consulta = new Consulta();

        public string Tipo = "";

        private void frmRecebeTexto_Load(object sender, EventArgs e)
        {
            if (Tipo != "SENHA" && Tipo != "3G" && Tipo != "OUTROS")
            {
                txtTexto.Visible = false;
                pnlVolts.Visible = true;
            }
            else if (Tipo != "SENHA")
            {
                txtTexto.PasswordChar = '\u0000';
            }
        }

        public string TextoTeste { get; set; }

        private void txtTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //Atribuir valor na propriedade
                TextoTeste = txtTexto.Text.ToString();
                //Fechar este Form
                this.Close();
        
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(txtVolts.Text + " V  ---  " + txtAmper.Text + " A\r\n\r\nDESEJA CADASTRAR?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                consulta.comando = "";
                consulta.comando = "update CodVarDescricao set voltagem ='" + txtVolts.Text + "', amperagem = '" + txtAmper.Text + "' where CodPositivo = '" + Tipo + "'";
                consulta.Atualizar();
                this.Close();
            }           
        }

        private void txtVolts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAmper_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       
    }
}
