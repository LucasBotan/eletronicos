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
    public partial class frmExpedicaoExpedicao : Form
    {
        public frmExpedicaoExpedicao(string texto, string CT)
        {
            InitializeComponent();
            lblUsuario.Text = texto;
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Conexao consulte = new Conexao();
        Consulta consulta = new Consulta();

        private void frmExpedicaoExpedicao_Load(object sender, EventArgs e)
        {
            txtOS.Select();
          //  ListarTudo();
          //  FormatarGrid();
            ContadorDeProducao();
        }

        public void ContadorDeProducao()
        {
            consulta.DataAtual();
            string Status = "EXPEDIDO";
            consulta.comando = "select COUNT(*) as QNT from Historico where Usuario = '" + lblUsuario.Text + "' and Status = '" + Status + "' and Data = '" + consulta.dataNormal + "' and CT = '" + lblCT.Text + "'";
            consulta.consultarHistorico();
            lblContador.Text = consulta.cont.ToString();
        }

        public void FormatarGrid()
        {
            dgvParaAbrir.Columns[0].Visible = false;
            dgvParaAbrir.RowHeadersVisible = false;
            // dgvConsulta.Columns[1].Width = 60;
            //dgvParaAbrir.Columns[1].Width = 200;
            dgvParaAbrir.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvConsulta.ScrollBars = ScrollBars.Vertical;
            dgvParaAbrir.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        }

        public void ListarTudo()
        {
            string sql = "";
            sql += " Select idChamados, OS, NS, Descricao, Status, DataEntrada, DATEDIFF(DAY, DataEntrada, GETDATE()) as DNP, StatusA1 From Chamados where Status = 'EXPEDICAO' and CT = '" + lblCT.Text + "'";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chamados");
            dgvParaAbrir.DataSource = ds.Tables["Chamados"];
            cx.Desconectar();
            lblTotal.Text = dgvParaAbrir.Rows.Count.ToString();
            //listar datas     
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            for (int i = 0; i < dgvParaAbrir.RowCount; i++)
            {
                string OS = dgvParaAbrir.Rows[i].Cells["OS"].Value.ToString();


                // ========================= ATUALIZA BANCO CHAMADOS ============================
                consulta.comando = "update Chamados Set Status = 'FINALIZADO', DataSaida = '" + consulta.data + "' where Status = 'EXPEDICAO' and OS = '" + OS + "' and CT = '" + lblCT.Text + "'";
                consulta.Atualizar();
                // ==============================================================================

                //======Insere na tabela Historico==========================
                string StatusHistorico = "EXPEDIDO";
                consulta.DataAtual();
                consulta.InsereHistorico(OS, lblUsuario.Text, StatusHistorico, consulta.dataNormal, consulta.hora, lblCT.Text);
                //=====fim da inserção======================================

            }
            

            MessageBox.Show("EQUIPAMENTOS EPEDIDOS.");
            this.Cursor = Cursors.Default;
            ListarTudo();
            ContadorDeProducao();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            consulta.Coluna = "OS";
            consulta.ValorDesejado = txtOS.Text;
          //  consulta.ComData = "SIM";  // para não puxar os finalizados
            // consulta.DataDesejada = txtDataDesejadaNaoLimpar.Text;
            consulta.ConsultaTudo(lblCT.Text);
            if (consulta.Retorno == "falha")
            {
                consulta.PlayFail();
                MessageBox.Show("OS NÃO ENCONTRADA.");
                txtOS.Select();
                txtOS.SelectAll();
            }
            else if (consulta.Status == "FINALIZADO")
            {
                consulta.PlayFail();
                MessageBox.Show("OS JÁ EXPEDIDA.");
                txtOS.Select();
                txtOS.SelectAll();
            }
            else if (consulta.Status != "EXPEDICAO")
            {
                consulta.PlayFail();
                MessageBox.Show("OS NÃO ESTA EM EXPEDICAO.\r\nSTATUS = " + consulta.Status);
                txtOS.Select();
                txtOS.SelectAll();
            }
            else if ((consulta.Varejista != "MULTIVAREJO" && consulta.Classificacao == "ORCAMENTO" && !consulta.StatusA1.Contains("APROVADO")) && chbSemA1.Checked == false)
            {
                consulta.PlayFail();
                MessageBox.Show("OS NÃO APROVADA.");
                txtOS.Select();
                txtOS.SelectAll();
            }
            else
            {

               
                txtDescricao.Text = consulta.Descricao;
                txtClassificacao.Text = consulta.Classificacao;
                txtStatusA1.Text = consulta.StatusA1;
                txtCodVarejo.Text = consulta.CodVarejo;
                txtVarejista.Text = consulta.Varejista;
                txtID.Text = consulta.idChamados;

                if(lblCT.Text != "10_1") // verificar essa lógiaca ao testar
                {
                    BuscarNFparaConsulta();
                }
                else
                {
                    txtNF.Text = "0";
                }
                
                if (txtNF.Text != "0" && txtNF.Text.Length > 0 || lblCT.Text == "10_1") // verificar essa lógiaca ao testar
                {
                    if (MessageBox.Show("CONCLUIR? ", "Pergunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {                        
                        // ========================= ATUALIZA BANCO CHAMADOS ============================
                        string pendente = "PENDENTE";
                        if (txtNF.Text == "0")
                        {
                            NF = "SEM NOTA";
                            pendente = "SEM NOTA";
                        }
                        else // verificar essa lógiaca ao testar ( antes não tinha o ELSE, O BuscarNFparaExpedir(); FICAVA SOLTO
                        {
                            BuscarNFparaExpedir();
                        }
                        //consulta.comando = "update Chamados Set Status = 'FINALIZADO', Classificacao = 'DEVOLUCAO', MotivoDevolucao = 'DEVOLUÇÃO EXIGIDA', DataSaida = '" + consulta.data + "', NotaFiscal = '" + NF + "', NotaFiscalSaida = '" + pendente + "' where Status = 'EXPEDICAO' and OS = '" + txtOS.Text + "'";
                        consulta.comando = "update Chamados Set Status = 'FINALIZADO', DataSaida = '" + consulta.data + "', NotaFiscal = '" + NF + "', NotaFiscalSaida = '" + pendente + "' where Status = 'EXPEDICAO' and OS = '" + txtOS.Text + "' and CT = '" + lblCT.Text + "'";
                        consulta.Atualizar();
                        // ==============================================================================
                        if (consulta.LinhasAfetadas > 0)
                        {
                            if (lblCT.Text != "10_1") // verificar essa lógiaca ao testar
                            {
                                BaixarQntNF();
                            }
                            //======Insere na tabela Historico==========================
                            string StatusHistorico = "EXPEDIDO";
                            consulta.DataAtual();
                            consulta.InsereHistorico(txtOS.Text, lblUsuario.Text, StatusHistorico, consulta.dataNormal, consulta.hora, lblCT.Text);
                            //=====fim da inserção======================================

                            lstContagem.Items.Add(txtOS.Text);
                            int rows = lstContagem.Items.Count;
                            lblContagem.Text = rows.ToString();

                            ContadorDeProducao();
                            consulta.PlayOK();
                            LimparTela();
                        }
                        else
                        {
                            consulta.PlayFail();                            
                            MessageBox.Show("NÃO FOI POSSÍVEL EXPEDIR, TENTE NOVAMENTE.");
                        }

                    }
                    else
                    {
                        LimparTela();
                    }
                }
                else
                {
                    consulta.PlayFail();
                    MessageBox.Show("NÃO FOI POSSÍVEL ATRIBUIR UMA NOTA FISCAL.");
                    LimparTela();
                }

                
            }

        }

        public void LimparTela()
        {
            NF = "";
            consulta.LimparControles(this);
            txtOS.Select();
        }

        private void txtConcluir_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstContagem.Items.Clear();
            int rows = lstContagem.Items.Count;
            lblContagem.Text = rows.ToString();
            LimparTela();
        }

        private void txtOS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBusca.PerformClick();
            }
        }

        // PUXAR A NOTA FISCAL MAIS ANTIGA QUE CONTENHA O CODVAREJO E PRECISE SER BAIXADA A QUANTIDADE
        public void BuscarNFparaConsulta()
        {
            consulta.comando = "";
            consulta.comando = "select top(1) notafiscal as Quantidade from NotaFiscal where CodVarejo = '" + txtCodVarejo.Text + "' and QntRestante > 0 and Varejista = '" + txtVarejista.Text + "' and CT = '" + lblCT.Text + "' order by CONVERT(date, Data, 103) ASC";
            consulta.consultarSimNao();
            txtNF.Text = consulta.qntNaPosicao;
        }

        public string NF = "";


        public void BuscarNFparaExpedir()
        {
            consulta.DataAtual();
            consulta.comando = "";
            consulta.comando = "select top(1) notafiscal as Quantidade from NotaFiscal where CodVarejo = '" + txtCodVarejo.Text + "' and QntRestante > 0 and Varejista = '" + txtVarejista.Text + "' and CT = '" + lblCT.Text + "' order by CONVERT(date, Data, 103) ASC";
            consulta.consultarSimNao();
            NF = consulta.qntNaPosicao;
        }
        // BAIXAR QNT DA NOTA FISCAL MAIS ANTIGA QUE CONTENHA O CODVAREJO E PRECISE SER BAIXADA A QUANTIDADE
        public void BaixarQntNF()
        {
            
            // alterei a posição. Agora expede primeiro e em seguida baixa uma qnt
            /*
            consulta.comando = "";
            consulta.comando = "select top(1) notafiscal as Quantidade from NotaFiscal where CodVarejo = '" + txtCodVarejo.Text + "' and QntRestante > 0 and Varejista = '" + txtVarejista.Text + "' and CT = '" + lblCT.Text + "' order by CONVERT(date, Data, 103) ASC";
            consulta.consultarSimNao();
            NF = consulta.qntNaPosicao;
            */
            consulta.comando = "";
            consulta.comando = "update notafiscal set QntRestante = QntRestante - 1 where notafiscal = '" + NF + "' and CodVarejo = '" + txtCodVarejo.Text + "' and CT = '" + lblCT.Text + "'";
            consulta.Atualizar();

            consulta.comando = "";
            consulta.comando += "insert into RegistroSaidaNF(OS, idChamados, DataHoraSaida, NF, Codigo, CT) values ";
            consulta.comando += "(";
            consulta.comando += " '" + txtOS.Text + "', ";
            consulta.comando += " '" + txtID.Text + "', ";
            consulta.comando += " '" + consulta.dataHora + "', ";
            consulta.comando += " '" + NF + "', ";
            consulta.comando += " '" + txtCodVarejo.Text + "', ";
            consulta.comando += " '" + lblCT.Text + "' ";
            consulta.comando += ") ";
            consulta.Atualizar();

        }



    }
}
