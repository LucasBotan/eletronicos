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
    public partial class frmReparoLancarRapido : Form
    {
        public frmReparoLancarRapido(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();

        private void frmReparoLancarRapido_Load(object sender, EventArgs e)
        {
            PreencherComboboxStatus();
        }

        public void ContadorDeProducao()
        {
            if (cboUsuario.Text.Length > 0)
            {
                consulta.DataAtual();
                string Status = "REPARO";
                consulta.comando = "select COUNT(*) as QNT from Historico where Usuario = '" + cboUsuario.Text + "' and Status = '" + Status + "' and Data = '" + consulta.dataNormal + "' and CT = '" + lblCT.Text + "'";
                consulta.consultarHistorico();
                lblContador.Text = consulta.cont.ToString();
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

        private void txtOS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnConcluir.PerformClick();
            }
             
        }

        public void AtualizarStatus()
        {
            consulta.DataAtual();
            string status = "HIGIENIZACAO";
            consulta.comando = "";
            consulta.comando = "update Chamados set  Responsavel = '" + cboUsuario.Text + "', Status = '" + status + "' ";
            //consulta.comando += " DtCompra = '" + DtCompra + "', DtTroca = '" + DtTroca + "', DefeitoRelatado = '" + txtDefeitoRelatado.Text + "', Filial = '" + txtFilial.Text + "', NumLacre = '" + txtNumLacre.Text + "', ObsDocumento = '" + txtObsDocumento.Text + "' ";
            consulta.comando += " where OS = '" + txtOS.Text + "' AND STATUS = 'REPARO' and CT = '" + lblCT.Text + "'";
            consulta.Atualizar();

            if (consulta.Retorno == "ok")
            {
                //======Insere na tabela Historico==========================
                string StatusHistorico = "REPARO";                
                consulta.InsereHistorico(txtOS.Text, cboUsuario.Text, StatusHistorico, consulta.dataNormal, consulta.hora, lblCT.Text);
                //=====fim da inserção======================================
            }         
        }

        private void cboUsuario_SelectedValueChanged(object sender, EventArgs e)
        {
            ContadorDeProducao();
            lblUsuario.Text = cboUsuario.Text;
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            consulta.Coluna = "OS";
            consulta.ValorDesejado = txtOS.Text;
            consulta.ComData = "SIM";
            // consulta.DataDesejada = txtDataDesejadaNaoLimpar.Text;
            consulta.ConsultaTudo(lblCT.Text);
            if (cboUsuario.Text == "")
            {
                consulta.PlayFail();
                MessageBox.Show("INFORME O USUÁRIO.");
            }
            else if (consulta.Descricao == "")
            {
                consulta.PlayFail();
                MessageBox.Show("OS NÃO ENCONTRADO.");
                txtOS.Select();
                txtOS.SelectAll();
            }
            else if (consulta.Classificacao == "")
            {
                consulta.PlayFail();
                MessageBox.Show("EQUIPAMENTO SEM CLASSIFICAÇÃO.\r\nNECESSÁRIO PASSAR PELA VISTORIA");
                txtOS.Select();
                txtOS.SelectAll();
            }
            else if (consulta.NS == "")
            {
                consulta.PlayFail();
                MessageBox.Show("EQUIPAMENTO SEM NS.\r\nNECESSÁRIO PASSAR PELA VISTORIA");
                txtOS.Select();
                txtOS.SelectAll();
            }
            else if (consulta.Status != "REPARO")
            {
                consulta.PlayFail();
                MessageBox.Show("OS NÃO ESTA EM REPARO.\r\nSTATUS = " + consulta.Status);
                txtOS.Select();
                txtOS.SelectAll();
            }
            else
            {
                AtualizarStatus();
                if (consulta.Retorno == "ok")
                {
                    consulta.PlayOK();
                    MessageBox.Show("REPARO CADASTRADO.");
                    txtOS.Text = "";
                    consulta.Descricao = "";
                    ContadorDeProducao();
                    txtOS.Select();
                }
                else
                {
                    consulta.PlayFail();
                    MessageBox.Show("ERRO AO INSERIR INFORMAÇÃOES.");
                }
            }
        }



    }
}
