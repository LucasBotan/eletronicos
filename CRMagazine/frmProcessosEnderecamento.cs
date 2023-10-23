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
    public partial class frmProcessosEnderecamento : Form
    {
        public frmProcessosEnderecamento(string texto, string Chamado, string CT)
        {
            InitializeComponent();
            lblUsuario.Text = texto;
            txtOS.Text = Chamado;
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Conexao cx2 = new Conexao();
        Consulta consulta = new Consulta();

        private void frmEnderecamento_Load(object sender, EventArgs e)
        {
            txtOS.Select();
            if (txtOS.Text.Length > 0)
            {
                btnBuscarChamado.PerformClick();
            }
        }

        public void ListarLocais()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql += " Select Local from Locais where Status = '" + txtStatus.Text + "' and CT = '" + lblCT.Text + "'";
            cx.Conectar();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "Locais");
            cbxLocalEnderecamento.ValueMember = "idLocal";
            cbxLocalEnderecamento.DisplayMember = "Local";
            cbxLocalEnderecamento.DataSource = ds.Tables["Locais"];
            cx.Desconectar();
            cbxLocalEnderecamento.Text = txtMemorizar.Text;
            
        }        

        private void btnBuscarChamado_Click(object sender, EventArgs e)
        {
            if (txtOS.Text.Length > 0)
            {
                consulta.Coluna = "OS";
                consulta.ValorDesejado = txtOS.Text;
                consulta.ConsultaTudo(lblCT.Text);
                if (consulta.Retorno == "ok")
                {
                   // txtOS.Text = consulta.OS;
                    txtModelo.Text = consulta.Descricao;
                    txtStatus.Text = consulta.Status;

                    ListarLocais();
                    
                    if (txtMemorizar.Text.Length > 0)
                    {
                        if ((txtMemorizar.Text.Length != 0) && (cbxLocalEnderecamento.Text != txtMemorizar.Text))
                        {
                            consulta.PlayFail();
                            MessageBox.Show("O LOCAL MEMORIZADO DIVERGE DO STATUS ATUAL");
                            LimparControles(this);
                            txtOS.Select();
                        }
                        else
                        {
                            //btnConcluir.Select();
                            btnConcluir.PerformClick();
                        }                        
                    }
                    else
                    {
                        cbxLocalEnderecamento.Select();
                    }

                }
                else
                {
                    consulta.PlayFail();
                    MessageBox.Show("CHAMADO NÃO ENCONTRADO");
                    txtOS.Text = "";
                    txtOS.Select();
                }
            }
            else
            {
                consulta.PlayFail();
                MessageBox.Show("INFORME UM CHAMADO.");
            }
            
        }

        private void txtChamado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBuscarChamado.PerformClick();
            }
        }

        private void cbxLocalEnderecamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnConcluir.Select();
            }
        }

        public void Concluir()
        {
            consulta.comando = "";
            consulta.comando += "update Chamados set LocalDeGuarda = '" + cbxLocalEnderecamento.Text + "' where OS = '" + txtOS.Text + "' and CT = '" + lblCT.Text + "'";
            consulta.Atualizar();
            
            if (consulta.Retorno == "ok")
            {
                //MessageBox.Show("ENDEREÇAMENTO CONCLUIDO");
                consulta.PlayOK();
                btnLimpar.PerformClick();
                cbxLocalEnderecamento.DataSource = null;
            }
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            Concluir();
        }

        private void cbxLocalEnderecamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnMemorizar_Click(object sender, EventArgs e)
        {
            txtMemorizar.Text = cbxLocalEnderecamento.Text;
        }


        public void LimparControles(Control parent)
        {
            foreach (Control cont in parent.Controls)
            {
                if (cont is TextBox)
                {
                    if ((cont as TextBox).Name != "txtMemorizar")
                    {
                        (cont as TextBox).Text = "";
                    }
                }
              
                if (cont is ComboBox) { (cont as ComboBox).Text = ""; }

                if (cont is DateTimePicker) { (cont as DateTimePicker).Text = ""; }

                if (cont is MaskedTextBox) { (cont as MaskedTextBox).Text = ""; }

                if (cont is RadioButton) { (cont as RadioButton).Checked = false; }

                if (cont is CheckBox) { (cont as CheckBox).Checked = false; }

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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparControles(this);        
            cbxLocalEnderecamento.DataSource = null;
            cbxLocalEnderecamento.Items.Clear();
        }

        private void btnLimparMemoria_Click(object sender, EventArgs e)
        {
            txtMemorizar.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
