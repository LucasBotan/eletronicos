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
    public partial class frmAlterarBanco : Form
    {
        public frmAlterarBanco(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();

        private void frmAlterarBanco_Load(object sender, EventArgs e)
        {

        }

      
        private void chbOS_CheckedChanged(object sender, EventArgs e)
        {
            if (chbOS.Checked)
            {
                txtOS.Enabled = true;
            }
            else
            {
                txtOS.Enabled = false;
            }
        }

        private void chbData_CheckedChanged(object sender, EventArgs e)
        {
            if (chbData.Checked)
            {
                txtData.Enabled = true;
            }
            else
            {
                txtData.Enabled = false;
            }
        }

        private void chbNS_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNS.Checked)
            {
                txtNS.Enabled = true;
            }
            else
            {
                txtNS.Enabled = false;
            }
                
        }

        private void txtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {
            int num = txtData.Text.Length;
            if (num == 2)
            {
                txtData.Text = txtData.Text + "/";
                txtData.Select(3, 3);
            }
            if (num == 5)
            {
                txtData.Text = txtData.Text + "/";
                txtData.Select(6, 6);
            }
            if (num == 10)
            {
                string Vdata = txtData.Text.ToString();
                //ValidaData(Vdata);
                try
                {
                    DateTime teste = Convert.ToDateTime(Vdata);
                }
                catch (Exception)
                {
                    MessageBox.Show("Não é uma Data Valida");
                    txtData.Text = "";
                    txtData.Select();
                }
                btnAlterar.Select();
            }            
        }

        private void txtNS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAlterar.Select();
            }
        }

        private void txtNS_Leave(object sender, EventArgs e)
        {
            if (txtNS.Text.Length >= 9)
            {
                btnAlterar.Select();
            }
            else
            {
                MessageBox.Show("O Número de Série deve conter 9 Digitos!");
                txtNS.Text = "";
                txtNS.Select();
            }
        }

        private void txtOS_Leave(object sender, EventArgs e)
        {
            VerificaSeOSJaPassouNoPosto();
            if (txtOS.Text.Length > 0)
            {
                try
                {
                    string PrimeiroDigito = txtOS.Text.Substring(0, 1);
                    if ((txtOS.Text.Length == 8) || ((txtOS.Text.Length == 11) && (PrimeiroDigito == "0")))
                    {
                        btnAlterar.Focus();
                    }
                    else
                    {
                        MessageBox.Show("OS INVALIDA");
                        txtOS.Text = "";
                        txtOS.Select();
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
            else
            {
                txtOS.Select();
            }
            
        }

        private void txtOS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAlterar.Focus();
            }
        }

        private void txtTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BuscaPor();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtTexto.Text.Length == 0)
            {
                MessageBox.Show("Preencha o Campo de Busca!");
                txtTexto.Select();
               
            }
            else if ((txtID.Text.Length == 0) || (txtOS.Text.Length == 0) || (txtData.Text.Length == 0) || (txtCodVarejista.Text.Length == 0) || (txtDescricao.Text.Length == 0) || (cboVarejista.Text.Length == 0))
            {
                MessageBox.Show("Preencha Todos os Campos!");
                txtTexto.Select();
            }
            else
            {
                if (MessageBox.Show("DESEJA ALTERAR?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Alterar();
                    //===========HISTORICO==================
                    consulta.comando = "";
                    consulta.comando = "update Historico set OS = '" + txtOS.Text + "' where OS = '" + OSOriginal + "' and CT = '" + lblCT.Text + "'";
                    consulta.Atualizar();

                    /*
                    //===========AVARIAS====================
                    consulta.comando = "";
                    consulta.comando = "update Avarias set OS = '" + txtOS.Text + "' where OS = '" + OSOriginal + "' and CT = '" + lblCT.Text + "'";
                    consulta.Atualizar();
                     */

                    MessageBox.Show("ALTERADO COM SUCESSO");
                    LimparControles(this);
                    txtTexto.Select();
                }
                else
                {
                    LimparControles(this);
                    txtTexto.Select();
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtTexto.Text.Length == 0)
            {
                MessageBox.Show("Preencha o Campo de Busca!");
                txtTexto.Select();
            }
            else if ((txtID.Text.Length == 0) || (txtOS.Text.Length == 0) || (txtData.Text.Length == 0))
            {
                MessageBox.Show("Preencha Todos os Campos!");
                txtTexto.Select();
            }
            else
            {
                if (MessageBox.Show("DESEJA EXCLUIR?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Excluir();
                    ExcluirDoHistorico();
                    MessageBox.Show("EXCLUIDO COM SUCESSO");
                    LimparControles(this);    
                    txtTexto.Select();
                }
                else
                {
                    LimparControles(this);
                    txtTexto.Select();
                }                
            }
        }     

        //=====================================================================================================
        //=============== METODOS =============================

        public void LimparControles(Control parent)
        {
            OSOriginal = "";
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

                if (cont is CheckBox) { (cont as CheckBox).Checked = false; }

                if (cont is ListView) { (cont as ListView).Items.Clear(); }

                cboVarejista.Text = null;

                // varre os filhos...
                this.LimparControles(cont);
            }
        }


        public string OSOriginal = "";

        public void BuscaPor()
        {
            string valor = "";
            if (rbNS.Checked)
            {
                valor = "NS";
            }
            else if (rbOS.Checked)
            {
                valor = "OS";
            }
            else
            {
                MessageBox.Show("Preencha um campo!");
                txtTexto.Select();
            }


            
            try
            {
                string sql = "";
                sql += " Select idChamados, NS, Descricao, CodVarejo, OS, DataEntrada, SKU, Varejista From Chamados";
                sql += " Where " + valor + " = '" + txtTexto.Text + "' and CT = '" + lblCT.Text + "'";
                cx.Conectar();
                SqlCommand cd = new SqlCommand();
                cd.Connection = cx.c;
                cd.CommandText = sql;
                SqlDataReader dr = cd.ExecuteReader();
                if (dr.Read())
                {
                    OSOriginal = dr["OS"].ToString();
                    txtNS.Text = dr["NS"].ToString();
                    txtData.Text = dr["DataEntrada"].ToString();
                    txtDescricao.Text = dr["Descricao"].ToString();
                    txtOS.Text = dr["OS"].ToString();
                    txtID.Text = dr["idChamados"].ToString();
                    txtCodVarejista.Text = dr["CodVarejo"].ToString();
                    txtCodPositivo.Text = dr["SKU"].ToString();
                    cboVarejista.Text = dr["Varejista"].ToString();
                }
                else
                {
                    MessageBox.Show("Não encontrado");
                    txtTexto.Text = "";
                    txtTexto.Select();
                    txtNS.Text = "";
                    txtData.Text = "";
                    txtDescricao.Text = "";
                    txtOS.Text = "";
                    txtID.Text = "";
                    txtCodVarejista.Text = "";     
                }
                dr.Close();                
            }
            catch (Exception x)
            {
                MessageBox.Show("Falha ao buscar equipamneto: \n" + x.Message);
            }
            cx.Desconectar();
        }
        
        public void Alterar()
        {

            string data = "";
            try
            {
                DateTime Data = Convert.ToDateTime(txtData.Text);
                data = Data.ToString("MM/dd/yyyy");
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
            
           
            string sql = "";
            try
            {
                sql += " Update Chamados";
                sql += " Set NS = '" + txtNS.Text + "', ";
                sql += " DataEntrada = '" + data + "', ";
                sql += " OS = '" + txtOS.Text + "', ";
                sql += " Descricao = '" + txtDescricao.Text + "', ";
                sql += " CodVarejo = '" + txtCodVarejista.Text + "', ";
                sql += " SKU = '" + txtCodPositivo.Text + "', ";
                sql += " Varejista = '" + cboVarejista.Text + "'";
                sql += " Where idChamados = '" + txtID.Text + "' and CT = '" + lblCT.Text + "'";
                cx.Conectar();
                SqlCommand cd = new SqlCommand();
                cd.Connection = cx.c;
                cd.CommandText = sql;
                cd.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                MessageBox.Show("Erro ao Alterar Equipamento: \n" + x.Message);
                txtTexto.Text = "";
                txtTexto.Select();
            }
            cx.Desconectar();
        }

        

        public void Excluir()
        {
            string sql = "";
            try
            {
                sql += " Delete from Chamados";
                sql += " Where idChamados = '" + txtID.Text + "' and CT = '" + lblCT.Text + "'";
                cx.Conectar();
                SqlCommand cd = new SqlCommand();
                cd.Connection = cx.c;
                cd.CommandText = sql;
                cd.ExecuteNonQuery();
            }
            catch (SqlException x)
            {
                MessageBox.Show("ERRO AO EXCLUIR EQUIPAMENTO: \n" + x.Message);
            }
            cx.Desconectar();
        }

        public void ExcluirDoHistorico()
        {
            string sql = "";
            try
            {
                sql += " Delete from Historico";
                sql += " Where OS = '" + txtOS.Text + "' and CT = '" + lblCT.Text + "'";
                cx.Conectar();
                SqlCommand cd = new SqlCommand();
                cd.Connection = cx.c;
                cd.CommandText = sql;
                cd.ExecuteNonQuery();
            }
            catch (SqlException x)
            {
                MessageBox.Show("ERRO AO EXCLUIR EQUIPAMENTO DO HISTORICO: \n" + x.Message);
            }
            cx.Desconectar();
        }

        public void VerificaSeOSJaPassouNoPosto()
        {
            try
            {
                string sql = "";
                sql += " Select OS, Status from Chamados";
                sql += " where OS = '" + txtOS.Text + "' and CT = '" + lblCT.Text + "'";
                cx.Conectar();
                SqlCommand cd2 = new SqlCommand();
                cd2.Connection = cx.c;
                cd2.CommandText = sql;
                SqlDataReader dr2 = cd2.ExecuteReader();
                if (dr2.Read())
                {
                    string status = dr2["Status"].ToString();
                    string OS = dr2["OS"].ToString();
                    if (txtTexto.Text != OS)
                    {
                        MessageBox.Show("OS JÁ CADASTRADA.\r\nSTATUS = " + status);
                        txtOS.Text = "";
                        txtOS.Select();
                    }                    
                }
                dr2.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show("verifica se OS ja passou no posto ERRO: \n" + x.Message);
                txtOS.Text = "";
            }
            cx.Desconectar();
        }

        private void chbCodViaVarejo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCodViaVarejo.Checked)
            {
                txtCodVarejista.Enabled = true;
            }
            else
            {
                txtCodVarejista.Enabled = false;
            }
        }

        private void chbDescricao_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDescricao.Checked)
            {
                txtDescricao.Enabled = true;
            }
            else
            {
                txtDescricao.Enabled = false;
            }
        }

        private void ckbCodPositivo_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCodPositivo.Checked)
            {
                txtCodPositivo.Enabled = true;
            }
            else
            {
                txtCodPositivo.Enabled = false;
            }
        }

        private void chbVarejista_CheckedChanged(object sender, EventArgs e)
        {
            if (chbVarejista.Checked)
            {
                cboVarejista.Enabled = true;
            }
            else
            {
                cboVarejista.Enabled = false;
            }
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            consulta.ConsultarCodVarejo(txtCodVarejista.Text, cboVarejista.Text);
            txtCodPositivo.Text = consulta.SKU;
            txtDescricao.Text = consulta.Descricao;            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

      
        
    }
}
