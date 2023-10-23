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
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CRMagazine
{
    public partial class old_frmAssistEncerrar : Form
    {
        public old_frmAssistEncerrar(string texto)
        {
            InitializeComponent();
            lblUsuario.Text = texto;
            User = texto;
        }

        string User = "";
        Conexao cx = new Conexao();
        Conexao cx2 = new Conexao();
        Consulta consultar = new Consulta();

        private void frmAssistEncerrar_Load(object sender, EventArgs e)
        {
            ListarTudo();
            FormatarGride();
            chbStatusAssist.Checked = true;
        }

        public void FormatarGride()
        {
            dgvConsulta.RowHeadersVisible = false;
            dgvConsulta.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvConsulta.Columns[1].Visible = false;
            //dgvConsulta.Columns[3].Visible = false;
            dgvConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        }

        public void FormatarGrideParaAnalise()
        {
            dgvConsulta.RowHeadersVisible = false;
            dgvConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvConsulta.Columns[1].Visible = false;
            dgvConsulta.Columns["Status"].Visible = false;
            //dgvConsulta.Columns[3].Visible = false;
            dgvConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        }

        public void ListarTudo()
        {
            string sql = "";
            sql += "select Chamado, DtEntrada, Status from Chamados where Assist = 'ENCERRAR' and Chamado != 'PENDENTE'";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chamados");
            dgvConsulta.DataSource = ds.Tables["Chamados"];
            cx.Desconectar();
            lblTotal.Text = dgvConsulta.Rows.Count.ToString();
        }

        public void ListarReparo()
        {
            string sql = "";
            sql += "select CodPeca1 AS CODIGO, DescPeca1 AS DESCRICAO, SerialAntigo1 AS ANTIGO, SerialNovo1 AS NS from Tecnica where Chamado = '" + txtChamado.Text + "' ";
            sql += "union ";
            sql += "select CodPeca2 AS CODIGO, DescPeca2 AS DESCRICAO, SerialAntigo2 AS ANTIGO, SerialNovo2 AS NS from Tecnica where Chamado = '" + txtChamado.Text + "' ";
            sql += "union ";
            sql += "select CodPeca3 AS CODIGO, DescPeca3 AS DESCRICAO, SerialAntigo3 AS ANTIGO, SerialNovo3 AS NS from Tecnica where Chamado = '" + txtChamado.Text + "' ";
            sql += "union ";
            sql += "select CodPeca4 AS CODIGO, DescPeca4 AS DESCRICAO, SerialAntigo4 AS ANTIGO, SerialNovo4 AS NS from Tecnica where Chamado = '" + txtChamado.Text + "' ";
            sql += "union ";
            sql += "select CodPeca5 AS CODIGO, DescPeca5 AS DESCRICAO, SerialAntigo5 AS ANTIGO, SerialNovo5 AS NS from Tecnica where Chamado = '" + txtChamado.Text + "' ";
            sql += "ORDER BY NS DESC";
            cx2.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx2.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Tecnica");
            dgvConsultaRep.DataSource = ds.Tables["Tecnica"];
            cx2.Desconectar();
            dgvConsultaRep.RowHeadersVisible = false;
            dgvConsultaRep.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        public void ListarAnalise()
        {
            string sql = "";
            sql += "select ";            
            sql += "Chamado, DtEntrada, Status from Chamados ";
            sql += "where ";
            sql += "Assist = 'ANALISE' ";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chamados");
            dgvConsulta.DataSource = ds.Tables["Chamados"];
            cx.Desconectar();
            lblTotal.Text = dgvConsulta.Rows.Count.ToString();
        }


       

        private void dgvConsulta_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string chamado = dgvConsulta.Rows[e.RowIndex].Cells["Chamado"].Value.ToString();
            txtChamado.Text = chamado.Trim();
            dgvConsulta.Select();
        }

        public void ConsultaOS()
        {
            
            consultar.Coluna = "Chamado";
            consultar.ValorDesejado = txtChamado.Text;
           // consultar.ConsultaTudo(lblCT.Text);
            if (consultar.Retorno == "ok")
            {
                txtDescricao.Text = consultar.Descricao;
                txtNS.Text = consultar.NS;
                txtResponsavel.Text = consultar.Responsavel;
                txtAnalise.Text = consultar.ErroAssist;

                try
                {
                    consultar.ConsultarDatas("DtEntrada", txtChamado.Text);
                    txtDias.Text = consultar.DNP;
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
                /*
                try
                {
                    TimeSpan dif = Convert.ToDateTime(consultar.dataInvertidaComtraço).Subtract(Convert.ToDateTime(consultar.DtEntrada));
                    txtDias.Text = dif.ToString();
                }               
                catch(Exception x)
                {
                    MessageBox.Show(x.Message);
                }
                 */
                txtStatusBSoft.Text = consultar.Status;
               // txtAcessoriosAssist.Text = consultar.OrcAcessorios;
            }   
             
        }

        private void txtChamado_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            chbStatusAssist.Checked = false;
            LimparControles(this);
            txtChamado.Text = "";
            if (rbtAnalise.Checked)
            {
                ListarAnalise();
                FormatarGrideParaAnalise();
            }
            else
            {
                ListarTudo();
                FormatarGride();
            }
            
           
            chbStatusAssist.Checked = true;
 
        }

        public void LimparControles(Control parent)
        {
            foreach (Control cont in parent.Controls)
            {
                if (cont is TextBox)
                {
                    if ((cont as TextBox).Name.Contains("SerialNovo") || (cont as TextBox).Name.Contains("DescPeca"))
                    {
                        (cont as TextBox).Visible = false;
                    }
                    if ((cont as TextBox).Name == "txtModelo")
                    {

                    }
                    else
                    {
                        (cont as TextBox).Text = "";
                    }

                }

                //if (cont is ComboBox) { (cont as ComboBox).Text = ""; }

                if (cont is MaskedTextBox) { (cont as MaskedTextBox).Text = ""; }

                //  if (cont is RadioButton) { (cont as RadioButton).Checked = false; }

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

        public void Atualizar()
        {
            chbStatusAssist.Checked = false;
            LimparControles(this);
            txtChamado.Text = "";
            if (rbtAnalise.Checked)
            {
                ListarAnalise();
                FormatarGrideParaAnalise();
            }
            else
            {
                ListarTudo();
                FormatarGride();
            }


            chbStatusAssist.Checked = true;
        }


        public void Concluir(string local, string erro)
        {
            consultar.DataAtual();
            string dataAnalise = consultar.data;
            consultar.Coluna = "CHAMADO";
            consultar.ValorDesejado = txtChamado.Text;
           // consultar.ConsultaTudo(lblCT.Text);
            if (consultar.Retorno == "ok")
            {
                consultar.comando = "";
                consultar.comando = "update Chamados set Assist = '" + local + "', ErroAssit = '" + erro + "' where Chamado = '" + txtChamado.Text + "'";
                consultar.Atualizar();
                if (consultar.Retorno == "ok")
                {
                    MessageBox.Show("CONCLUIDO!");
                }
                else
                {
                    MessageBox.Show("ERRO AO ATUALIZAR NO POSTO");
                }
            }           
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("CONFIRMA CONCLUSÃO?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                string local = "FINALIZADO";
                string erro = "";
                if (chbEnviarParaAnalise.Checked == true)
                {
                    erro = txtAnalise.Text;
                    local = "ANALISE";
                }
                Concluir(local, erro);               
            }
        }

        private void btnEnviarParaAnalise_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("CONFIRMA ENVIAR PARA ANALISE?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtEnviarParaAnalise.Text.Length != 0)
                {
                    string local = "ANALISE";
                    string erro = txtEnviarParaAnalise.Text;
                    Concluir(local, erro);
                    chbEnviarParaAnalise.Checked = false;
                }
                else
                {
                    MessageBox.Show("Preencha um motivo");
                }
            }
        }

        private void chbEnviarParaAnalise_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEnviarParaAnalise.Checked)
            {
                txtEnviarParaAnalise.Visible = true;
                btnEnviarParaAnalise.Visible = true;
                btnConcluir.Visible = false;
                
            }
            else
            {
                txtEnviarParaAnalise.Text = "";
                txtEnviarParaAnalise.Visible = false;
                btnEnviarParaAnalise.Visible = false;
                btnConcluir.Visible = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        public void ReconheceStatus()
        {
            if (txtChamado.Text.Length > 0)
            {
                string Status = "";
                try
                {
                    txtStatusAssist.Text = "";
                    string sql = "";
                    sql += "select QPCT.KURZTEXT AS STATUS, QMMA.* ";
                    sql += "from QMMA, QPCT  ";
                    sql += "where ";
                    sql += "qmma.manum = (select Max(qmma.manum) from Qmma where qmnum = '0" + txtChamado.Text + "') and ";
                    sql += "QPCT.CODE = QMMA.MNCOD and QPCT.CODEGRUPPE = QMMA.MNGRP ";
                    sql += "AND QMMA.QMNUM = '0" + txtChamado.Text + "' ";
                    sql += "order by QMMA.QMNUM, QMMA.MANUM asc ";
                    // txtChamado.Text = "";
                    // txtChamado.Text = sql;

                    cx2.ConectarSAP();
                    SqlCommand cd = new SqlCommand();
                    cd.Connection = cx2.c;
                    cd.CommandText = sql;
                    SqlDataReader dr = cd.ExecuteReader();
                    if (dr.Read())
                    {
                        Status = dr["STATUS"].ToString();
                    }
                    else
                    {
                        Status = "";
                    }
                    dr.Close();
                    cx2.Desconectar();
                }
                catch (SqlException x)
                {
                    MessageBox.Show("consulta NS no SAP " + x.Message);
                }
                cx2.Desconectar();


                try
                {
                    string valor = Status;
                    //int num = dgvConsulta.RowCount;
                    // string valor = dgvConsulta.Rows[num - 1].Cells["STATUS"].Value.ToString();
                    //
                    if (valor == "SISTEMA ATP" || valor == "ABERTURA")
                    {
                        txtStatusAssist.Text = "CHAMADOS RECEBIDOS";
                    }
                    else if (valor == "EM ATENDIMENTO")
                    {
                        txtStatusAssist.Text = "AVALIAÇÃO TECNICA";
                    }
                    else if (valor == "UTILIZANDO BACKUP" || valor == "PEÇA EM TRANSPORTE" || valor == "PEÇA ENTREGUE" || valor == "SEM NECESSIDADE DE PEÇA" || valor == "NENHUMA SOLICITAÇÃO DE PEÇA")
                    {
                        txtStatusAssist.Text = "PENDÊNCIA DE CONCLUSÃO DO CONSERTO"; //\nou\nPENDÊNCIA DE RETIRADA NA ASSISTÊNCIA TÉCNICA";
                    }
                    else if (valor == "POSIC C/ PEDIDO DE PEÇAS FORA COMPOSIÇÃO" || valor == "PEÇA SOLICITADA")
                    {
                        txtStatusAssist.Text = "PENDÊNCIA DE FALTA DE PEÇAS";
                    }
                    else if (valor == "FINALIZADO TECNICAMENTE")
                    {
                        txtStatusAssist.Text = "PENDÊNCIA DE RETIRADA NA ASSISTÊNCIA TÉCNICA";
                    }
                    else if (valor == "ENCERRAMENTO")
                    {
                        txtStatusAssist.Text = "ENCERRADO";
                    }
                    else
                    {
                        txtStatusAssist.Text = valor;
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
        }

        private void chbStatusAssist_CheckedChanged(object sender, EventArgs e)
        {
            if (chbStatusAssist.Checked == false)
            {
                txtStatusAssist.Text = "";
            }
            else
            {
                ReconheceStatus();
            }
        }

        private void txtBusca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBusca.PerformClick();
            }
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            string texto = "";
            string retorno = "";
            for (int i = 0; i < dgvConsulta.RowCount; i++)
            {
                try
                {
                    texto = dgvConsulta.Rows[i].Cells["Chamado"].Value.ToString();
                    if (texto == txtBusca.Text)
                    {
                        consultar.PlayOK();
                        MessageBox.Show("OS " + texto + " ENCONTRADA!");
                        txtChamado.Text = texto;
                        retorno = "ok";
                        break;
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
            if (retorno != "ok")
            {
                for (int i = 0; i < dgvConsulta.RowCount; i++)
                {
                    try
                    {
                        texto = dgvConsulta.Rows[i].Cells["Chamado"].Value.ToString();
                        if (texto == txtBusca.Text)
                        {
                            consultar.PlayOK();
                            MessageBox.Show("CHAMADO " + texto + " ENCONTRADO!");
                            txtChamado.Text = dgvConsulta.Rows[i].Cells["Chamado"].Value.ToString();
                            retorno = "ok";
                            break;
                        }
                    }

                    catch (Exception x)
                    {
                        MessageBox.Show(x.Message);
                    }
                }
            }

            if (retorno != "ok")
            {
                consultar.PlayFail();
                MessageBox.Show("OS / CHAMADO NÃO ENCONTRADO!");
                txtBusca.Text = "";
                txtChamado.Text = "";
                txtBusca.Select();
            }
        }

        private void txtChamado_TextChanged_1(object sender, EventArgs e)
        {

            ConsultaOS();

            if (chbStatusAssist.Checked)
            {
                ReconheceStatus();
            }
            if (txtChamado.Text.Length > 0)
            {
                Clipboard.SetText(txtChamado.Text);
            }
            // ConsultarTecnica();
            ListarReparo();
        }

        private void btnVerificarEncerrados_Click(object sender, EventArgs e)
        {
            if (dgvConsulta.RowCount > 0)
            {
                for (int i = 0; i < dgvConsulta.RowCount; i++)
                {
                    string Cham = dgvConsulta.Rows[i].Cells["Chamado"].Value.ToString();


                    if (txtChamado.Text.Length > 0)
                    {
                        string Resultado = "";
                        string Status = "";
                        try
                        {
                            txtStatusAssist.Text = "";
                            string sql = "";
                            sql += "select QPCT.KURZTEXT AS STATUS, QMMA.* ";
                            sql += "from QMMA, QPCT  ";
                            sql += "where ";
                            sql += "qmma.manum = (select Max(qmma.manum) from Qmma where qmnum = '0" + Cham + "') and ";
                            sql += "QPCT.CODE = QMMA.MNCOD and QPCT.CODEGRUPPE = QMMA.MNGRP ";
                            sql += "AND QMMA.QMNUM = '0" + Cham + "' ";
                            sql += "order by QMMA.QMNUM, QMMA.MANUM asc ";
                            // txtChamado.Text = "";
                            // txtChamado.Text = sql;

                            cx2.ConectarSAP();
                            SqlCommand cd = new SqlCommand();
                            cd.Connection = cx2.c;
                            cd.CommandText = sql;
                            SqlDataReader dr = cd.ExecuteReader();
                            if (dr.Read())
                            {
                                Status = dr["STATUS"].ToString();
                            }
                            else
                            {
                                Status = "";
                            }
                            dr.Close();
                            cx2.Desconectar();
                        }
                        catch (SqlException x)
                        {
                            MessageBox.Show("consulta NS no SAP " + x.Message);
                        }
                        cx2.Desconectar();


                        try
                        {
                            string valor = Status;
                            //int num = dgvConsulta.RowCount;
                            // string valor = dgvConsulta.Rows[num - 1].Cells["STATUS"].Value.ToString();
                            //
                            if (valor == "SISTEMA ATP" || valor == "ABERTURA")
                            {
                                Resultado = "CHAMADOS RECEBIDOS";
                            }
                            else if (valor == "EM ATENDIMENTO")
                            {
                                Resultado = "AVALIAÇÃO TECNICA";
                            }
                            else if (valor == "UTILIZANDO BACKUP" || valor == "PEÇA EM TRANSPORTE" || valor == "PEÇA ENTREGUE" || valor == "SEM NECESSIDADE DE PEÇA" || valor == "NENHUMA SOLICITAÇÃO DE PEÇA")
                            {
                                Resultado = "PENDÊNCIA DE CONCLUSÃO DO CONSERTO"; //\nou\nPENDÊNCIA DE RETIRADA NA ASSISTÊNCIA TÉCNICA";
                            }
                            else if (valor == "POSIC C/ PEDIDO DE PEÇAS FORA COMPOSIÇÃO" || valor == "PEÇA SOLICITADA")
                            {
                                Resultado = "PENDÊNCIA DE FALTA DE PEÇAS";
                            }
                            else if (valor == "FINALIZADO TECNICAMENTE")
                            {
                                Resultado = "PENDÊNCIA DE RETIRADA NA ASSISTÊNCIA TÉCNICA";
                            }
                            else if (valor == "ENCERRAMENTO")
                            {
                                Resultado = "ENCERRADO";
                            }
                            else
                            {
                                Resultado = valor;
                            }
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                        }
                        if (
                            Resultado == "PENDÊNCIA DE RETIRADA NA ASSISTÊNCIA TÉCNICA" ||
                            Resultado == "ENCERRADO" ||
                            Resultado == "ENCERRAMENTO COM NEGOCIAÇÃO" ||
                            Resultado == "ENCERRAMENTO CELULAR"
                            )
                        {
                            dgvConsulta.Rows[i].Cells["Chamado"].Style.BackColor = Color.Red;
                        }


                    }




                }


            }
        }

        private void btnAssist_Click(object sender, EventArgs e)
        {
            string Valida = "OK";
            ProcessStartInfo psi = new ProcessStartInfo();

            if (txtStatusAssist.Text == "CHAMADOS RECEBIDOS")
            {
                psi.FileName = (("http://10.20.120.71/bin/localizaOS.php?opcao=10i&ordem=" + txtChamado.Text));
            }
            else if (txtStatusAssist.Text == "AVALIAÇÃO TECNICA")
            {
                psi.FileName = (("http://10.20.120.71/bin/localizaOS.php?opcao=10&ordem=" + txtChamado.Text));
            }
            else if (txtStatusAssist.Text == "PENDÊNCIA DE CONCLUSÃO DO CONSERTO")
            {
                psi.FileName = (("http://10.20.120.71/bin/localizaOS.php?opcao=30c&ordem=" + txtChamado.Text));
            }
            else if (txtStatusAssist.Text == "PEÇA ACEITA")
            {
                psi.FileName = (("http://10.20.120.71/bin/localizaOS.php?opcao=30c&ordem=" + txtChamado.Text));
            }
            else if (txtStatusAssist.Text == "PENDÊNCIA DE FALTA DE PEÇAS")
            {
                psi.FileName = (("http://10.20.120.71/bin/localizaOS.php?opcao=30e&ordem=" + txtChamado.Text));
            }
            else if (txtStatusAssist.Text == "PENDÊNCIA DE RETIRADA NA ASSISTÊNCIA TÉCNICA")
            {
                psi.FileName = (("http://10.20.120.71/bin/localizaOS.php?opcao=40r&ordem=" + txtChamado.Text));
            }
            else if (txtStatusAssist.Text == "ENCERRADO")
            {
                MessageBox.Show("CHAMADO JÁ ENCERRADO.");
                Valida = "falha";
            }
            else
            {
                 MessageBox.Show("STATUS ASSIST NÃO LOCALIZADO.");
                 Valida = "falha";
            }

            if (Valida == "OK")
            {    
                psi.CreateNoWindow = true;              
                Process.Start(psi);            
            }
            this.TopMost = true;
            this.BringToFront();
            this.Select();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        





    }
}
