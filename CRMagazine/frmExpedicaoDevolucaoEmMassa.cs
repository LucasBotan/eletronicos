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
    public partial class frmExpedicaoDevolucaoEmMassa : Form
    {
        public frmExpedicaoDevolucaoEmMassa(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Conexao consulte = new Conexao();
        Consulta consulta = new Consulta();

        private void frmExpedicaoDevolucaoEmMassa_Load(object sender, EventArgs e)
        {
            FormatarGridTeste();
            consulta.ListarVarejistas(cboVarejista);
            txtCodVarejo.Select();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            Contar();
            if (dgvExpedicao.RowCount > 0)
            {
                btnConcluir.Visible = true;
                lblQnt.Text = dgvExpedicao.RowCount.ToString();
            }

        }

        public void FormatarGridTeste()
        {
            //NF,CLASS,COD,OK,DESC,QNT,VALOR_UNI,VALORTOTAL,NCM
            dgvExpedicao.Rows.Clear();
            dgvExpedicao.ColumnCount = 11;
            dgvExpedicao.Columns[0].Name = "NotaFiscal";
            dgvExpedicao.Columns[1].Name = "Classificacao";
            dgvExpedicao.Columns[2].Name = "CodVarejo";
            //dgvExpedicao.Columns[3].Name = "OK";
            dgvExpedicao.Columns[3].Name = "Descricao";
            dgvExpedicao.Columns[4].Name = "QNT";
            dgvExpedicao.Columns[5].Name = "Valor_uni";
            //dgvExpedicao.Columns[7].Name = "VALOR_TOTAL";
            dgvExpedicao.Columns[6].Name = "NCM";
            dgvExpedicao.Columns[7].Name = "Varejista";
            dgvExpedicao.Columns[8].Name = "id_NotaEntrada";
            dgvExpedicao.Columns[9].Name = "QNT_Restante";
            dgvExpedicao.Columns[10].Name = "RETORNO";

            dgvExpedicao.RowHeadersVisible = false;
            //dgvExpedicao.Columns[0].Visible = false;
            //dgvExpedicao.Columns[1].Width = 80;
            //dgvExpedicaoa.Columns[2].Width = 80;
            //  dgvExpedicao.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvExpedicao.AutoResizeColumns();
            //dgvExpedicao.ScrollBars = ScrollBars.Vertical;
            //dgvConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both;  
        }

        public void Contar()
        {
            if (txtCodVarejo.Text.Length == 0 || txtQntTotal.Text.Length == 0 || cboClassificacao.Text.Length == 0 || cboVarejista.Text.Length == 0)
            {
                MessageBox.Show("PREENCHA TODOS OS CAMPOS PARA PROCEGUIR.");
            }
            else
            {
                dgvExpedicao.Rows.Clear();
                txtRetorno.Text = "";
                txtRetornoRetirada.Text = "";
                //MessageBox.Show("LIMPOU");

                int QntTotal = Convert.ToInt32(txtQntTotal.Text);
                // select sum(convert(numeric,QntRestante)) as qnt from NotaFiscal where CodVarejo = '5396191' and QntRestante > 0 and Varejista = 'MAGAZINE RIBEIRAO'
                consulta.comando = "";
                // consulta.comando = "select top(1) notafiscal as Quantidade from NotaFiscal where CodVarejo = '" + CodVarejista + "' and QntRestante > 0 and Varejista = '" + Varejista + "' ";
                consulta.comando = "select sum(convert(numeric,QntRestante)) as Quantidade from NotaFiscal where CodVarejo = '" + txtCodVarejo.Text + "' and QntRestante > 0 and Varejista = '" + cboVarejista.Text + "' and CT = '" + lblCT.Text + "' ";
                consulta.consultarSimNao();
                string Qnt = consulta.qntNaPosicao;
                if (Qnt == "")
                {
                    Qnt = "0";
                }

                if (Convert.ToInt32(Qnt) < QntTotal)
                {
                    MessageBox.Show("QUANTIDADE NECESSARIA MENOR DO QUE A QUANTIDADE DISPONIVEL\r\nQUANTIDADE DISPONIVEL = " + Qnt);
                }
                else
                {
                    try
                    {
                        string sql = "";
                        sql += " Select * from notafiscal ";
                        sql += " where CodVarejo = '" + txtCodVarejo.Text + "' and QntRestante > 0 and Varejista = '" + cboVarejista.Text + "' and CT = '" + lblCT.Text + "' order by CONVERT(date, Data, 103) ASC";
                        cx.Conectar();
                        SqlCommand cd = new SqlCommand();
                        cd.Connection = cx.c;
                        cd.CommandText = sql;
                        SqlDataReader dr = cd.ExecuteReader();
                        while (dr.Read())
                        {
                            //NF,CLASS,COD,OK,DESC,QNT,VALOR_UNI,VALORTOTAL,NCM
                            string QntRestante = dr["QntRestante"].ToString();
                            string ID = dr["idNotaFiscal"].ToString();
                            string NCM = dr["NCM"].ToString();
                            string NF = dr["NotaFiscal"].ToString();
                            string Valor_uni = dr["Valor_uni"].ToString();
                            string Descricao = dr["Descricao"].ToString();

                            int QntDaNF = Convert.ToInt32(QntRestante);
                            if (QntTotal >= QntDaNF) // se o desejado for maior que o da NF
                            {
                                txtRetorno.Text += NF + "\t" + QntDaNF + "\t" + NCM + "\r\n";
                                txtRetornoRetirada.Text += QntDaNF + "\t" + QntDaNF + "\t" + ID + "\r\n";
                                int qnt_final = QntDaNF - QntDaNF;
                                dgvExpedicao.Rows.Add(NF, cboClassificacao.Text, txtCodVarejo.Text, Descricao, QntDaNF, Valor_uni, NCM, cboVarejista.Text, ID, qnt_final);
                                
                                QntTotal = QntTotal - QntDaNF;
                            }
                            else
                            {
                                txtRetorno.Text += NF + "\t" + QntTotal + "\t" + NCM + "\r\n";
                                txtRetornoRetirada.Text += QntDaNF + "\t" + QntTotal + "\t" + ID + "\r\n";
                                int qnt_final = QntDaNF - QntTotal;
                                dgvExpedicao.Rows.Add(NF, cboClassificacao.Text, txtCodVarejo.Text, Descricao, QntTotal, Valor_uni, NCM, cboVarejista.Text, ID, qnt_final);
                                
                                QntTotal = 0;
                            }

                            if (QntTotal == 0)
                            {
                                //MessageBox.Show("Acabou");
                                break;
                            }
                        }
                        dr.Close();
                    }
                    catch (SqlException x)
                    {
                        MessageBox.Show("Falha em Contar ESTOQUE: \n" + x.Message);
                    }
                    cx.Desconectar();
                }
            }
            
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if (dgvExpedicao.RowCount > 0)
            {
                InsereNoBancoNotaPorFora();
            }
        }

        public void InsereNoBancoNotaPorFora()
        {
            for(int i = 0; i < dgvExpedicao.RowCount; i++)
            {
                string NotaFiscal = dgvExpedicao.Rows[i].Cells["NotaFiscal"].Value.ToString();
                string Classificacao = dgvExpedicao.Rows[i].Cells["Classificacao"].Value.ToString();
                string CodVarejo = dgvExpedicao.Rows[i].Cells["CodVarejo"].Value.ToString();
                string Descricao = dgvExpedicao.Rows[i].Cells["Descricao"].Value.ToString();
                string QNT = dgvExpedicao.Rows[i].Cells["QNT"].Value.ToString();
                string Valor_uni = dgvExpedicao.Rows[i].Cells["Valor_uni"].Value.ToString();
                string NCM = dgvExpedicao.Rows[i].Cells["NCM"].Value.ToString();
                string Varejista = dgvExpedicao.Rows[i].Cells["Varejista"].Value.ToString();
                string id_NotaEntrada = dgvExpedicao.Rows[i].Cells["id_NotaEntrada"].Value.ToString();
                string QNT_Restante = dgvExpedicao.Rows[i].Cells["QNT_Restante"].Value.ToString();
            
                //insere no banco notaporfora
                consulta.comando = "";
                consulta.comando += "INSERT INTO NOTAPORFORA (CT, Notafiscal, Classificacao, CodVarejo, Descricao, Qnt, Valor_uni, NCM, Varejista, Status, id_NotaEntrada, Qnt_Restante) VALUES ";
                consulta.comando += " ('" + lblCT.Text + "', '" + NotaFiscal + "','" + Classificacao + "','" + CodVarejo + "','" + Descricao + "','" + QNT + "','" + Valor_uni + "','" + NCM + "' ,'" + Varejista + "','PENDENTE','" + id_NotaEntrada + "', '" + QNT_Restante + "') ";
                consulta.Atualizar();

                if (consulta.Retorno == "ok")
                {
                    //debta do banco entradanotas
                    consulta.comando = "";
                    consulta.comando = "UPDATE NOTAFISCAL SET QNTRESTANTE = '"+ QNT_Restante + "' WHERE IDNOTAFISCAL = '" + id_NotaEntrada + "' and CT = '" + lblCT.Text + "' ";
                    consulta.Atualizar();
                    //MessageBox.Show(consulta.comando);
                    if (consulta.Retorno == "ok")
                    {
                        dgvExpedicao.Rows[i].Cells["RETORNO"].Value = "OK";
                    }
                }
            }
            string Feed = "ok";
            for (int i = 0; i < dgvExpedicao.RowCount; i++)
            {
                string Retorno = dgvExpedicao.Rows[i].Cells["RETORNO"].Value.ToString();
                if (Retorno != "OK")
                {
                    Feed = "falha";
                }
            }
            if (Feed == "ok")
            {
                MessageBox.Show("REGISTROS INSERIDOS COM SUCESSO.");
                txtCodVarejo.Text = "";
                txtQntTotal.Text = "";
                txtCodVarejo.Select();
            }
            else
            {
                MessageBox.Show("NEM TODOS OS REGISTROS FORAM INSERIDOS COM SUCESSO.");
                MessageBox.Show("VERIFICAR OS QUE NÃO ESTÃO OK E RELANÇAS AS QUANTIDADES.");
            }
            btnConcluir.Visible = false;

        
        }

        private void txtCodVarejo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if(txtCodVarejo.Text.Length > 0)
                {
                    txtQntTotal.Select();
                }
            }
        }

        private void txtQntTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtQntTotal.Text.Length > 0)
                {
                    cboVarejista.Select();
                }
            }
        }

        private void cboVarejista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cboVarejista.Text.Length > 0)
                {
                    cboClassificacao.Select();
                }
            }
        }

        private void cboClassificacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cboClassificacao.Text.Length > 0)
                {
                    btnBusca.Select();
                }
            }
        }

        

        /*
        // ============================ ANTIGO
        public void ListarTudo_old() // 
        {
            string sql = "";
            sql += " Select idChamados, OS, NS, Descricao, Status, CodVarejista, DataEntrada, Varejista, DATEDIFF(DAY, DataEntrada, GETDATE()) as DNP, '' AS QUERY_NOTA, '' AS QUERY_CHAMADOS From Chamados where STATUS != 'FINALIZADO' AND DATEDIFF(DAY, DataEntrada, GETDATE()) >= '" + txtDiasNoPosto.Text + "' and varejista = '" + cboVarejista.Text + "' Order by DATEDIFF(DAY, DataEntrada, GETDATE()) ";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chamados");
            dgvExpedicao.DataSource = ds.Tables["Chamados"];
            cx.Desconectar();
            lblQnt.Text = dgvExpedicao.Rows.Count.ToString();
        }

        public void Buscar_old()
        {
            for (int i = 0; i < dgvExpedicao.RowCount; i++)
            {
                consulta.DataAtual();
                string OS = dgvExpedicao.Rows[i].Cells["OS"].Value.ToString();
                string CodVarejista = dgvExpedicao.Rows[i].Cells["CodVarejista"].Value.ToString();
                string Varejista = dgvExpedicao.Rows[i].Cells["Varejista"].Value.ToString();
                string NF = "";
                string pendente = "PENDENTE";
                consulta.comando = "";
                consulta.comando = "select top(1) notafiscal as Quantidade from NotaFiscal where CodVarejo = '" + CodVarejista + "' and QntRestante > 0 and Varejista = '" + Varejista + "' ";
                consulta.consultarSimNao();
                NF = consulta.qntNaPosicao;
                //consulta.comando = "";
                //consulta.comando = "update notafiscal set QntRestante = QntRestante - 1 where notafiscal = '" + NF + "' and CodVarejo = '" + CodVarejista + "'";
                //consulta.Atualizar();
                dgvExpedicao.Rows[i].Cells["QUERY_NOTA"].Value = "update notafiscal set QntRestante = QntRestante - 1 where notafiscal = '" + NF + "' and CodVarejo = '" + CodVarejista + "'";

                if (NF == "0")
                {
                    NF = "SEM NOTA";
                    pendente = "SEM NOTA";
                }
                //consulta.comando = "";
                //consulta.comando = "update Chamados Set Status = 'FINALIZADO', DataSaida = '" + consulta.data + "', NotaFiscal = '" + NF + "', NotaFiscalSaida = '" + pendente + "' where Status = 'EXPEDICAO' and OS = '" + OS + "'";
                //consulta.Atualizar();
                dgvExpedicao.Rows[i].Cells["QUERY_CHAMADOS"].Value = "update Chamados Set Status = 'FINALIZADO', DataSaida = '" + consulta.data + "', NotaFiscal = '" + NF + "', NotaFiscalSaida = '" + pendente + "' where Status = 'EXPEDICAO' and OS = '" + OS + "'";
                // ==============================================================================
                if (consulta.Retorno == "ok")
                {
                    //======Insere na tabela Historico==========================
                    string StatusHistorico = "EXPEDIDO";
                    consulta.DataAtual();
                    consulta.InsereHistorico(OS, "BSOFT", StatusHistorico, consulta.dataNormal, consulta.hora);
                    //=====fim da inserção======================================
                }
            }
        }
        */

        

    }
}
