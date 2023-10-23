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
    public partial class frmProcessosDevolucao : Form
    {
        public frmProcessosDevolucao(string texto, string CT)
        {
            InitializeComponent();
            lblUsuario.Text = texto;
            lblCT.Text = CT;
        }

        public string DevOuSuc = "";
        private void frmAjusteDevolucao_Load(object sender, EventArgs e)
        {
            txtOS.Select();
            rbtDevolucao.Checked = true;
            DevOuSuc = "DEVOLUÇÃO";
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();

        private void btnBuscarChamado_Click(object sender, EventArgs e)
        {
            if (txtOS.Text.Length > 0)
            {
                consulta.Coluna = "OS";
                consulta.ValorDesejado = txtOS.Text;
                consulta.ComData = "SIM";
                consulta.ConsultaTudo(lblCT.Text);
                if (consulta.Retorno == "ok")
                {
                    txtModelo.Text = consulta.Descricao;
                    txtStatus.Text = consulta.Status;
                    txtVarejista.Text = consulta.Varejista;
                    //txtMotivoDevolucao.Select();
                    txtMotivoDevolucao.Text = DevOuSuc;
                    btnConcluir.Select();
                }
                else
                {
                    MessageBox.Show("OS NÃO ENCONTRADA");
                    txtOS.Text = "";
                    txtOS.Select();
                }
            }
            else
            {
                MessageBox.Show("INFORME UMA OS.");
            }
        }

       
        private void btnConcluir_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("DESEJA CONCLUIR A " + DevOuSuc + " ?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (txtOS.Text.Length == 0)
                {
                    MessageBox.Show("PEENCHA A OS.");
                }
                else if (txtModelo.Text.Length == 0)
                {
                    MessageBox.Show("INFORME O MODELO.");
                }
                else if (txtMotivoDevolucao.Text.Length == 0)
                {
                    MessageBox.Show("PEENCHA O MOTIVO DA " + DevOuSuc);
                }
                else
                {
                    string Classificacao = "DEVOLUCAO";
                    if (rbtSucata.Checked)
                    {
                        Classificacao = "SUCATA";
                    }
                    consulta.comando = "";
                    consulta.comando += "update Chamados set status = 'EXPEDICAO', Classificacao = '" + Classificacao + "', MotivoDevolucao = '" + txtMotivoDevolucao.Text + "' where OS = '" + txtOS.Text + "' and CT = '" + lblCT.Text + "'";
                    consulta.Atualizar();
                    if (consulta.Retorno == "ok")
                    {
                        //======Insere na tabela Historico==========================
                        string Local = Classificacao;
                        consulta.DataAtual();
                        consulta.InsereHistorico(txtOS.Text, lblUsuario.Text, Local, consulta.dataNormal, consulta.hora, lblCT.Text);
                        //=====fim da inserção======================================
                        MessageBox.Show(DevOuSuc + " CONCLUIDA. \r\nENVIAR PARA EXPEDIÇÃO.");
                        consulta.LimparControles(this);
                        txtOS.Select();
                    }
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DESEJA LIMPAR A TELA?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                consulta.LimparControles(this);
                txtOS.Select();
            }
        }

        private void txtChamado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBuscarChamado.PerformClick();
            }
        }

        private void rbtSucata_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtSucata.Checked)
            {
                DevOuSuc = "SUCATA";
                lblTitulo.Text = DevOuSuc;
            }
            else
            {
                DevOuSuc = "DEVOLUÇÃO";
                lblTitulo.Text = DevOuSuc;
            }
        }



    }
}
