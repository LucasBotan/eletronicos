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
    public partial class frmAjusteRetirarDePP : Form
    {
        public frmAjusteRetirarDePP(string texto, string CT)
        {
            InitializeComponent();
            lblUsuario.Text = texto;
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();

        private void frmAjusteRetirarDePP_Load(object sender, EventArgs e)
        {
            cboStatus.Text = "PP";
            ContadorDeProducao();
            ListarTudo();
            FormatarGrid();
        }

        public void ContadorDeProducao()
        {
            string Local = "SAIDAPPSEMPECA";
            consulta.DataAtual();
            consulta.comando = "select COUNT(*) as QNT from Historico where Usuario = '" + lblUsuario.Text + "' and Status = '" + Local + "' and Data = '" + consulta.dataNormal + "' and CT = '" + lblCT.Text + "'";
            consulta.consultarHistorico();
            lblContador.Text = consulta.cont.ToString();
        }


        public void FormatarGrid()
        {
            dgvConsulta.RowHeadersVisible = false;
            dgvConsulta.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        }

        public void ListarTudo()
        {
            string sql = "";
            sql += " Select NS as SERIE, OS From Chamados where Status = '" + cboStatus.Text + "' and CT = '" + lblCT.Text + "'";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chamados");
            dgvConsulta.DataSource = ds.Tables["Chamados"];
            cx.Desconectar();
            lblTotal.Text = dgvConsulta.Rows.Count.ToString();
        }

        public void ConsultaChamado()
        {
            consulta.Coluna = "OS";
            consulta.ValorDesejado = txtOS.Text;
            consulta.ComData = "SIM";
            // consulta.DataDesejada = txtDataDesejadaNaoLimpar.Text;
            consulta.ConsultaTudo(lblCT.Text);

            txtOS.Text = consulta.OS;
            txtModelo.Text = consulta.Descricao;
            txtNS.Text = consulta.NS;
            txtVarejista.Text = consulta.Varejista;
        }

        private void btnBuscarObj_Click(object sender, EventArgs e)
        {
            string texto = "";
            string retorno = "";
            for (int i = 0; i < dgvConsulta.RowCount; i++)
            {

                try
                {
                    texto = dgvConsulta.Rows[i].Cells["OS"].Value.ToString();
                    if (texto == txtBusca.Text)
                    {
                        txtOS.Text = texto;
                        retorno = "ok";
                        break;
                    }
                    else
                    {

                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
            if (retorno != "ok")
            {
                MessageBox.Show("Não encontrado");
            }
        }

        private void txtBusca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBuscarObj.PerformClick();
            }  
        }

        private void dgvConsulta_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //txtChamado.Text = dgvConsulta.Rows[e.RowIndex].Cells["CHAMADO"].Value.ToString();
        }

        private void txtChamado_TextChanged(object sender, EventArgs e)
        {
            ConsultaChamado();
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DESEJA CONCLUIR A OS?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {              
                string status = "REPARO";
                consulta.comando = "";
                consulta.comando = "update Chamados set Status = '" + status + "' where OS = '" + txtOS.Text + "' AND STATUS = '" + cboStatus.Text + "' and CT = '" + lblCT.Text + "'";
                consulta.Atualizar();

                //======Insere na tabela Historico==========================
                string Local = "SAIDAPPSEMPECA";
                consulta.DataAtual();
                consulta.InsereHistorico(txtOS.Text, lblUsuario.Text, Local, consulta.dataNormal, consulta.hora, lblCT.Text);
                //=====fim da inserção======================================
                ContadorDeProducao();
                consulta.LimparControles(this);
                MessageBox.Show("CONCLUIDO COM SUCESSO!");
                ListarTudo();
            }
        }

        private void btnDoa_Click(object sender, EventArgs e)
        {
        }

        private void txtSeguradora_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void txtNS_TextChanged(object sender, EventArgs e)
        {
            ConsultaChamado();
        }

        private void cboStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            ListarTudo();
        }






    }
}
