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
    public partial class frmReparoLacarProdutoMontado : Form
    {
        public frmReparoLacarProdutoMontado(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();

        private void frmReparoLacarProdutoMontado_Load(object sender, EventArgs e)
        {
            consulta.ListarVarejistas(cboVarejista);
            PreencherComboboxStatus();
            cboVarejista.Text = "VIAVAREJO";
            cboBusca.Text = "EAN";
           
        }

        public void ContadorDeProducao()
        {
            if (cboUsuario.Text.Length > 0)
            {
                consulta.DataAtual();                
                consulta.comando = "select COUNT(*) as Quantidade from Producao where Usuario = '" + cboUsuario.Text + "' and Status = 'RECEBIDO' AND Data = '" + consulta.dataNormal + "' and CT = '" + lblCT.Text + "'";
                consulta.consultarHistorico();
                lblContador.Text = consulta.cont.ToString();
                                
                consulta.comando = "select COUNT(*) as Quantidade from Producao where Usuario = '" + cboUsuario.Text + "' and Status = 'AGUARDANDO' AND Data = '" + consulta.dataNormal + "' and CT = '" + lblCT.Text + "'";
                consulta.consultarHistorico();
                lblContadorAg.Text = consulta.cont.ToString();

                consulta.comando = "select COUNT(*) as Quantidade from Producao where Usuario = '" + cboUsuario.Text + "' and Status = 'CANCELADO' AND Data = '" + consulta.dataNormal + "' and CT = '" + lblCT.Text + "'";
                consulta.consultarHistorico();
                lblContadorCanc.Text = consulta.cont.ToString();

            }
        }

        public void PreencherComboboxStatus()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql = "";
            sql += " SELECT DISTINCT Usuario FROM Usuarios WHERE REPARO = 'yes' and CT = '" + lblCT.Text + "'";
            cx.Conectar();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "Usuarios");
            cboUsuario.ValueMember = "idUsuario";
            cboUsuario.DisplayMember = "Usuario";
            cboUsuario.DataSource = ds.Tables["Usuarios"];
            cx.Desconectar();
            cboUsuario.Text = null;
            cboUsuario.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboUsuario.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {

            string BuscaColuna = "CODVAREJO";
            if (cboBusca.Text == "CÓDIGO VAREJO")
            {
                BuscaColuna = "CODVAREJO";
            }
            else if (cboBusca.Text == "EAN")
            {
                BuscaColuna = "EAN";
            }
            else
            {
                BuscaColuna = "SKU";
            }

            if (txtEAN.Text.Length == 0)
            {
                MessageBox.Show("INFORME O SKU OU EAN.");
            }
            else
            {
               // consulta.ConsultarEAN("EAN", txtEAN.Text, "NÃO");

                consulta.ConsultarEAN(BuscaColuna, txtEAN.Text, cboVarejista.Text);

                if (consulta.Retorno == "ok")
                {
                    txtDescricao.Text = consulta.Descricao;

                    txtSKU.Text = consulta.SKU;
                    txtEAN.Text = consulta.EANpuri;
                    btnConcluir.Select();
                }
                else
                {
                    consulta.PlayFail();
                    MessageBox.Show("MODELO NÃO ENCONTRADO.");
                    txtEAN.Select();
                    txtEAN.SelectAll();
                }
            }
        }

        private void txtOS_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBusca.PerformClick();
            }
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if (txtEAN.Text.Length == 0)
            {
                MessageBox.Show("INFORME O CÓDIGO DO PRODUTO.");
            }
            if (cboUsuario.Text.Length == 0)
            {
                MessageBox.Show("INFORME O USUÁRIO.");
            }
            else if (txtDescricao.Text.Length == 0)
            {
                MessageBox.Show("INFORME O MODELO.");
            }
            else
            {
                consulta.DataAtual();
                consulta.comando = "insert into Producao (CT, EAN, Descricao, SKU, Usuario, Data, Hora, Status) Values ";
                consulta.comando += " ('" + lblCT.Text + "', '" + txtEAN.Text + "', '" + txtDescricao.Text + "', '" + txtSKU.Text + "', '" + cboUsuario.Text + "', ";
                consulta.comando += " '" + consulta.dataNormal + "', '" + consulta.hora + "', 'AGUARDANDO')";
                consulta.Atualizar();
                if (consulta.Retorno == "ok")
                {
                    MessageBox.Show("PRODUTO CADASTRADO.");
                    btnLimpar.PerformClick();

                }
                else
                {
                    MessageBox.Show("ERRO AO INSERIR PRODUTO MONTADO.");
                }
            }
            

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtEAN.Text = "";
            txtSKU.Text = "";
            txtDescricao.Text = "";
            txtEAN.Select();
            ContadorDeProducao();
        }

        private void cboUsuario_SelectedValueChanged(object sender, EventArgs e)
        {
            ContadorDeProducao();
            lblUsuario.Text = cboUsuario.Text;
            ContadorDeProducao();
        }

        private void cboBusca_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboBusca.Text == "CÓDIGO VAREJO")
            {
                lblTipoBusca.Text = "CÓDIGO VAREJO";
                txtEAN.Select();
            }
            else if (cboBusca.Text == "EAN")
            {
                lblTipoBusca.Text = "EAN";
                txtEAN.Select();
            }
            else
            {
                lblTipoBusca.Text = "SKU";
                txtEAN.Select();
            }
        }


    }
}
