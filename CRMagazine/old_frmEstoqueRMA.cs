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
using System.Management;
using System.Management.Instrumentation;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace CRMagazine
{
    public partial class old_frmEstoqueRMA : Form
    {
        public old_frmEstoqueRMA(string texto)
        {
            InitializeComponent();
            lblUsuario.Text = texto;
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();

       



        private void frmEstoqueRMA_Load(object sender, EventArgs e)
        {
            cbxAssist.Text = "SIM";
            ListarTudo();
            FormatarGrid();
        }

       // CheckBox chkbox = new CheckBox();

        public void FormatarGrid()
        {
             dgvConsulta.RowHeadersVisible = false;
             dgvConsulta.Columns[1].Visible = false;
             dgvConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
             dgvConsulta.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
         //   DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        //    dgvConsulta.Columns.Add(chk);
         //   dgvConsulta.Controls.Add(chkbox);
        //    chk.HeaderText = "Check";
        //    chk.Name = "chk";
        }

        public void ListarTudo()
        {
           

            string sql = "";

            sql += " Select idRMA, Chamado, Codigo, Descricao, Qntd, Status, Data, Assist, DataAssist from RMA where Status like '%CONFIRMADO%' " ;

            if (cbxAssist.Text.Length > 0)
            {
                if(cbxAssist.Text == "SIM")
                {
                    sql += "and Assist = 'CONCLUIDO' ";
                }
                else if (cbxAssist.Text == "SEM ASSIST")
                {
                    sql += "and Assist = 'SEM ASSIST' ";
                }
                else if (cbxAssist.Text == "TUDO")
                {
                    sql += "";
                }
                else if (cbxAssist.Text == "ESTORNO")
                {
                    sql += "and Assist = 'ESTORNO' ";
                }
                else
                {
                    sql += "and (Assist != 'CONCLUIDO' or Assist is NULL) ";
                }                
            }

            if (txtCodigo.Text.Length > 0)
            {
                string status = txtCodigo.Text;

                if (txtCodigo.Text.Contains('+'))
                {
                    status = txtCodigo.Text.Replace("+", "' or Codigo = '");
                    //MessageBox.Show(status);
                    sql += "and (Codigo = '" + status + "' )";
                }
                //sql += "M.Descricao like '%" + txtStatus.Text +  "%'";
                else
                {
                    sql += " and Codigo = '" + status + "' ";
                }

                
               // sql += "and Codigo like '" + txtCodigo.Text +"' ";
            }

            if (txtDescricao.Text.Length > 0)
            {
                sql += "and Descricao like '%" + txtDescricao.Text + "%' ";
            }

            if (txtData.Text.Length > 0)
            {
                sql += "and Data like '%" + txtData.Text + "%' ";
            }

            if (txtDataAssist.Text.Length > 0)
            {
                sql += "and DataAssist like '%" + txtDataAssist.Text + "%' ";
            }

           // MessageBox.Show(sql);

            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "RMA");
            dgvConsulta.DataSource = ds.Tables["RMA"];
            cx.Desconectar();
            lblTotal.Text = dgvConsulta.Rows.Count.ToString();
           // LimparVariaveis();            
        }
               
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            VerificarCheck();
            /*
            ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
            foreach (ManagementObject getserial in MOS.Get())
            {
                label1.Text = getserial["SerialNumber"].ToString();
            }        
             */

        }


        public void VerificarCheck()
        {


            /*
            foreach (DataGridViewRow gvr in this.dgvConsulta.Rows)
            {
                string idAluno = gvr.Cells[0].Text;
                bool check = (gvr.FindControl("IdCheckBox") as CheckBox).Checked;
                if (check)
                {
                    //Insere na base de dados;
                }
            }
            */


            foreach (DataGridViewRow dr in dgvConsulta.Rows)
            {
                //valos exibir a linha da [0](Cells[0]) pois ela representa a coluna checkbox 
                //que foi selecionada
                if (dr.Cells[0].Value != null)
                {
                    MessageBox.Show("Linha " + dr.Index + " foi selecionada");
                }
            }
            
            /*
            for (int i = 0; i < dgvConsulta.RowCount; i++)
            {
               // if (dgvConsulta.Rows[i].Cells["chk"].Value = dgvConsulta)

                MessageBox.Show("oi = " + Convert.ToBoolean(dgvConsulta.Rows[i].Cells["chk"].Value));

                /*
                MessageBox.Show("CHECANDO = " + dgvConsulta.Rows[i].Cells["Codigo"].Value.ToString());
                if (Convert.ToBoolean(dgvConsulta.Rows[i].Cells["chk"].Value) == true)
                {
                    MessageBox.Show(dgvConsulta.Rows[i].Cells["Codigo"].Value.ToString() + " SIM CHECADO");
                }
                else
                {
                    MessageBox.Show(dgvConsulta.Rows[i].Cells["Codigo"].Value.ToString() + " NAO CHECADO");
                }
                 */ 
            //}
              
             
        }

        

        private void label1_Click(object sender, EventArgs e)
        {
            
           
        }

        // ============= variaveis ===========
        public string ID = "";
        public string Usuario = "";
        public string OS = "";
        public string Codigo = "";
        public string Descricao = "";
        public string Qntd = "";
        //====================================

        public void LimparVariaveis()
        {
            ID = "";
            Usuario = "";
            OS = "";
            Codigo = "";
            Descricao = "";
            Qntd = "";
        }

        public void InsereLote()
        {
            consulta.DataAtual();
            consulta.comando = "";
            consulta.comando += "insert into Lotes (Lote, Volume, Codigo, Descricao, Quantidade, NF, DataLote, DataNf, DataSaida) Values ";
            consulta.comando += "('" + txtLote.Text + "', '" + txtVolume.Text + "', '" + Codigo + "',  '" + Descricao + "', '" + Qntd + "', '', '" + consulta.data + "', '', '') ";
            consulta.Atualizar();
        }

        public void InsereDescarte()
        {
            consulta.DataAtual();
            consulta.comando = "";
            consulta.comando += "insert into Descartes (Quantidade, DataDescarte, DataSaida, Codigo, Descricao) Values ";
            consulta.comando += "('" + Qntd + "', '" + consulta.data + "', '', '" + Codigo + "', '" + Descricao + "') ";
            consulta.Atualizar();
        }

        public void UpdateRMA()
        {
            consulta.comando = "";
            consulta.comando = "update RMA set Status = '" + txtLote.Text + "' where idRMA = '" + ID + "'";
            consulta.Atualizar();
        }

        private void btnDevolucao_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgvConsulta.Rows)
            {
                if (Convert.ToBoolean(row.Cells["chkColuna"].Value) == true)
                {
                    LimparVariaveis();
                    ID = row.Cells["idRMA"].Value.ToString();
                    //Usuario = row.Cells["Usuario"].Value.ToString();
                    //OS = row.Cells["OS"].Value.ToString();
                    Codigo = row.Cells["Codigo"].Value.ToString();
                    Descricao = row.Cells["Descricao"].Value.ToString();
                    Qntd = row.Cells["Qntd"].Value.ToString();
                    InsereLote();
                    UpdateRMA();
                }
                else
                {
                   
                }
            }
            consulta.LimparControles(this);
            ListarTudo();
        }

        private void btnDescate_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgvConsulta.Rows)
            {
                if (Convert.ToBoolean(row.Cells["chkColuna"].Value) == true)
                {
                    LimparVariaveis();
                    ID = row.Cells["idRMA"].Value.ToString();
                    //Usuario = row.Cells["Usuario"].Value.ToString();
                    //OS = row.Cells["OS"].Value.ToString();
                    Codigo = row.Cells["Codigo"].Value.ToString();
                    Descricao = row.Cells["Descricao"].Value.ToString();
                    Qntd = row.Cells["Qntd"].Value.ToString();
                    InsereDescarte();
                    UpdateRMA();
                }
                else
                {

                }
            }
            consulta.LimparControles(this);
            ListarTudo();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            ListarTudo();
        }

        private void txtLote_Leave(object sender, EventArgs e)
        {
            if (txtLote.Text.Length != 0)
            {
                consulta.comando = "";
                consulta.comando = "select COUNT(Lote) as Quantidade from Lotes where Lote = '" + txtLote.Text + "'";
                consulta.consultarSimNao();
                if (Convert.ToInt32(consulta.qntNaPosicao) > 0)
                {
                    MessageBox.Show("LOTE JÁ EXISTENTE");                    
                }
            }
        }

        private void txtVolume_Leave(object sender, EventArgs e)
        {
            if (txtVolume.Text.Length != 0)
            {
                consulta.comando = "";
                consulta.comando = "select COUNT(Volume) as Quantidade from Lotes where Lote = '" + txtLote.Text + "' and Volume = '" + txtVolume.Text + "'";
                consulta.consultarSimNao();
                if (Convert.ToInt32(consulta.qntNaPosicao) > 0)
                {
                    MessageBox.Show("VOLUME JÁ CADASTRADA NO LOTE");
                    txtVolume.Text = "";
                    txtVolume.Select();
                }
            }
        }

        private void txtVolume_Enter(object sender, EventArgs e)
        {
            if (txtLote.Text.Length == 0)
            {
                MessageBox.Show("PREENCHA O LOTE.");
                txtLote.Select();
            }
        }           

        private void btnDesmarcar_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgvConsulta.Rows)
            {
                if (Convert.ToBoolean(row.Cells["chkColuna"].Value) == true)
                {
                    row.Cells["chkColuna"].Value = false;
                }
                else
                {

                }
            }
        }

        private void btnMarcarTudo_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgvConsulta.Rows)
            {
                if (row.Cells["ASSIST"].Value.ToString() == "CONCLUIDO" || row.Cells["ASSIST"].Value.ToString() == "SEM ASSIST")
                {
                    if (Convert.ToBoolean(row.Cells["chkColuna"].Value) == false)
                    {
                        row.Cells["chkColuna"].Value = true;
                    }                   
                }
                else
                {                    
                    MessageBox.Show("AÇÃO NÃO PERMITIDA. EXISTEM ITENS NÃO CONCLUIDOS NO ASSIST");
                    btnDesmarcar.PerformClick();
                    break;
                }
              
            }
        }


        //CONFIRMA SE O ASSIST FOI CONCLUIDO, PARA LIBERAR UTILIZAR SOMENTE AS PEÇAS QUE JÁ DERAM BAIXO NO ASSIT
         private void dgvConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string Assist = dgvConsulta.Rows[e.RowIndex].Cells["Assist"].Value.ToString();
                if (dgvConsulta.Columns[e.ColumnIndex].Name == "chkColuna")
                {
                    if (Assist != "CONCLUIDO" && Assist != "SEM ASSIST" && Assist != "ESTORNO")
                    {
                        MessageBox.Show("ASSIST AINDA NÃO CONCLUIDO");
                        dgvConsulta.EndEdit();
                        dgvConsulta.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        

         private void btnInserir_Click(object sender, EventArgs e)
         {
             if (MessageBox.Show("DESEJA CONCLUIR RMA SEM ASSIST? ", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                 //========INSERE NA TABELA RMA (SETA COMO PENDENTE PARA APARECER PARA a tela no ESTOQUE)
                 consulta.DataAtual();
                 consulta.comando = "";
                 consulta.comando += "insert into RMA (Usuario, OS, Chamado, Codigo, Descricao, Qntd, Status, Data, Assist, DataAssist) Values ";
                 consulta.comando += "('" + lblUsuario.Text + "', 'SN', 'SN', '" + txtInsereCodigo.Text + "', '" + txtInsereDescricao.Text + "', '" + txtInsereQuantidade.Text + "', 'CONFIRMADO', '" + consulta.data + "', 'SEM ASSIST', '" + consulta.data + "')";
                 consulta.Atualizar();
                 //  MessageBox.Show(consulta.comando);                                             
                 if (consulta.Retorno == "ok")
                 {
                     MessageBox.Show("CONCLUIDO.");
                     txtInsereCodigo.Text = "";
                     txtInsereDescricao.Text = "";
                     txtInsereQuantidade.Text = "";
                     txtInsereCodigo.Select();
                 }
                 else
                 {
                     MessageBox.Show("ERRO AO ADICIONAR EM RMA.");
                 }
             }
         }

         public void VerificarPecaGeral()
         {
             string Codigo = txtInsereCodigo.Text;

             consulta.Codigo = Codigo;
           //  consulta.ConsultarCodigoSAP();
             if (consulta.Retorno == "ok")
             {
                 txtInsereDescricao.Text = consulta.Descricao;
                 txtInsereQuantidade.Select();
             }
             else
             {
                 consulta.Codigo = Codigo;
                // consulta.consultarEstoque(lblCT.Text);
                 if (consulta.Retorno == "ok")
                 {
                     txtInsereDescricao.Text = consulta.Descricao;
                     txtInsereQuantidade.Select();
                 }
                 else
                 {
                     MessageBox.Show("Código não encontrado!");
                     txtInsereCodigo.Text = "";
                     txtInsereDescricao.Text = "";
                     txtInsereCodigo.Select();
                 }
             }
         }

         private void txtInsereCodigo_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (e.KeyChar == 13)
             {
                 VerificarPecaGeral();                 
             }
         }

         private void chbInsereNaMao_CheckedChanged(object sender, EventArgs e)
         {
             if (chbInsereNaMao.Checked)
             {
                 pnlInserirNaMao.Visible = true;
             }
             else
             {
                 pnlInserirNaMao.Visible = false;
             }
         }




    }
}
