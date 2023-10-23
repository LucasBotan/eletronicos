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
    public partial class frmADMAjustarNFSaida : Form
    {
        public frmADMAjustarNFSaida(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consultar = new Consulta();

        private void frmADMAjustarNFSaida_Load(object sender, EventArgs e)
        {

        }

        public void FormatarGrid()
        {
            dgvNFSaida.RowHeadersVisible = false;
            dgvNFSaida.AutoResizeColumns();
            // dgvConsulta.Columns[1].Width = 60;
            // dgvConsultaNotas.Columns["NotaFiscal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //  dgvConsultaNotas.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarNF.Text.Length > 0)
            {
                BuscarNotaSaida();
            }
            else
            {
                MessageBox.Show("INFORME A NF.");
            }
        }

        private void txtBuscarNF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBuscar.PerformClick();
            }
        }

        public void BuscarNotaSaida()
        {
            try
            {
                string sql = "";
                sql += " select 'SELECT' as SELECIONAR, Tipo, idNotaFiscalSaida, NotaSaida, NotaEntrada, Data, Classificacao, CodVarejo, Descricao, QNT, Valor_uni, VALOR_TOTAL, NCM, Varejista, Alteracao from NotaFiscalSaida where NotaSaida = '" + txtBuscarNF.Text + "' and CT = '" + lblCT.Text + "' ";
                cx.Conectar();
                SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
                DataSet ds = new DataSet();
                da.Fill(ds, "NotaFiscalSaida");
                dgvNFSaida.DataSource = ds.Tables["NotaFiscalSaida"];
                cx.Desconectar();
                lblTotal.Text = dgvNFSaida.Rows.Count.ToString();
                //listar datas
                FormatarGrid();
            }
            catch (Exception x)
            {
                MessageBox.Show("ERRO AO CONSULTAR:\r\n" + x.Message);
            }
        }

        private void dgvNFSaida_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvNFSaida.Columns[e.ColumnIndex].Name == "SELECIONAR")
                {
                    string idNotaFiscal = dgvNFSaida.Rows[e.RowIndex].Cells["idNotaFiscalSaida"].Value.ToString();
                    string NotaSaida = dgvNFSaida.Rows[e.RowIndex].Cells["NotaSaida"].Value.ToString();
                    string NotaEntrada = dgvNFSaida.Rows[e.RowIndex].Cells["NotaEntrada"].Value.ToString();
                    string Data = dgvNFSaida.Rows[e.RowIndex].Cells["Data"].Value.ToString();
                    string Classificacao = dgvNFSaida.Rows[e.RowIndex].Cells["Classificacao"].Value.ToString();
                    string CodVarejo = dgvNFSaida.Rows[e.RowIndex].Cells["CodVarejo"].Value.ToString();
                    string Descricao = dgvNFSaida.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
                    string QNT = dgvNFSaida.Rows[e.RowIndex].Cells["QNT"].Value.ToString();
                    string Valor_uni = dgvNFSaida.Rows[e.RowIndex].Cells["Valor_uni"].Value.ToString();
                    string VALOR_TOTAL = dgvNFSaida.Rows[e.RowIndex].Cells["VALOR_TOTAL"].Value.ToString();
                    string NCM = dgvNFSaida.Rows[e.RowIndex].Cells["NCM"].Value.ToString();
                    string Varejista = dgvNFSaida.Rows[e.RowIndex].Cells["Varejista"].Value.ToString();

                    //TO DO VERIFICAR NECESSIDADE DE ACRESCENTAR NOVA COLUNA para não precisar deletar informações.. apenas setar como deletado... e nos alterados ficar registrado q foi alterado.


                    txtID.Text = idNotaFiscal;
                    txtNF.Text = NotaSaida;
                    txtNFEntrada.Text = NotaEntrada;
                    txtData.Text = Data;
                    txtClassificacao.Text = Classificacao;
                    txtCodVarejo.Text = CodVarejo;
                    txtDescricao.Text = Descricao;
                    txtQnt.Text = QNT;
                    txtValor_uni.Text = Valor_uni;
                    txtValor_Total.Text = VALOR_TOTAL;
                    txtNCM.Text = NCM;
                    txtVarejista.Text = Varejista;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                cx.Desconectar();
            }
        }


        public void Atualizar()
        {
            consultar.comando = "";
            consultar.comando += "update NotaFiscalSaida set ";
            consultar.comando += " NotaSaida = '" + txtNF.Text + "' ";
            consultar.comando += ", NotaEntrada = '" + txtNFEntrada.Text + "' ";
            consultar.comando += ", Data = '" + txtData.Text + "' ";
            consultar.comando += ", Classificacao = '" + txtClassificacao.Text + "' ";
            consultar.comando += ", CodVarejo = '" + txtCodVarejo.Text + "' ";
            consultar.comando += ", Descricao = '" + txtDescricao.Text + "' ";
            consultar.comando += ", QNT = '" + txtQnt.Text + "' ";
            consultar.comando += ", Valor_uni = '" + txtValor_uni.Text + "' ";
            consultar.comando += ", VALOR_TOTAL = '" + txtValor_Total.Text + "' ";
            consultar.comando += ", NCM = '" + txtNCM.Text + "' ";
            consultar.comando += ", Varejista = '" + txtVarejista.Text + "' ";
            consultar.comando += ", Alteracao = 'ALTERADO' ";
            consultar.comando += " where idNotaFiscalSaida = '" + txtID.Text + "' and CT = '" + lblCT.Text + "'";

            //MessageBox.Show(consultar.comando);
            consultar.Atualizar();

            if(consultar.Retorno == "ok")
            {
                MessageBox.Show("ALTERAÇÃO CONCLUIDA.");
                consultar.LimparControles(this.pnlAlteracao);
            }
        }

        public void Deletar()
        {
            consultar.comando = "";
            consultar.comando += " update NotaFiscalSaida set Alteracao = 'CANCELADO' where idNotaFiscalSaida = '" + txtID.Text + "' and CT = '" + lblCT.Text + "'";
            //MessageBox.Show(consultar.comando);
            consultar.Atualizar();

            if (consultar.Retorno == "ok")
            {
                MessageBox.Show("DELETE CONCLUIDO.");
                consultar.LimparControles(this.pnlAlteracao);
            }
        }

        public void DuplicarLinha()
        {
            consultar.comando = "";
            consultar.comando += "insert into NotaFiscalSaida (NotaSaida, NotaEntrada, Data, Classificacao, CodVarejo, Descricao, QNT, Valor_uni, VALOR_TOTAL, NCM, Varejista ,Tipo, CT) Values ";
            consultar.comando += " ( ";
            consultar.comando += " '" + txtNF.Text + "' ";
            consultar.comando += ",'" + txtNFEntrada.Text + "' ";
            consultar.comando += ", '" + txtData.Text + "' ";
            consultar.comando += ", '" + txtClassificacao.Text + "' ";
            consultar.comando += ", '" + txtCodVarejo.Text + "' ";
            consultar.comando += ", '" + txtDescricao.Text + "' ";
            consultar.comando += ", '" + txtQnt.Text + "' ";
            consultar.comando += ", '" + txtValor_uni.Text + "' ";
            consultar.comando += ", '" + txtValor_Total.Text + "' ";
            consultar.comando += ", '" + txtNCM.Text + "' ";
            consultar.comando += ", '" + txtVarejista.Text + "' ";
            consultar.comando += ", 'DUPLICADO' ";
            consultar.comando += ", '" + lblCT.Text + "' ";
            consultar.comando += " ) ";

            //MessageBox.Show(consultar.comando);
            consultar.Atualizar();

            if (consultar.Retorno == "ok")
            {
                MessageBox.Show("DUPLICAÇÃO CONCLUIDA.");
                consultar.LimparControles(this.pnlAlteracao);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //DESEJA LIMPAR
            if (MessageBox.Show("CONFIRMA LIMPAR A TELA?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                consultar.LimparControles(this);
                txtBuscarNF.Select();
            }
            
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("CONFIRMA ATUALIZAR?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Atualizar();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DESEJA CANCELAR A LINHA?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Deletar();
            }
        }

        private void btnDuplicar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DESEJA DUPLICAR O ITEM?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DuplicarLinha();
            }
        }

       

       




    }
}
