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
    public partial class frmInserirChekListVistoria : Form
    {
        public frmInserirChekListVistoria(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();

        private void frmInserirChekListVistoria_Load(object sender, EventArgs e)
        {
            FormatarGridAoIniciar();
        }

        public void FormatarGridAoIniciar()
        {
            dgvConsulta.RowHeadersVisible = false;
            dgvConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            dgvConsulta.AutoResizeColumns();

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            Image imagem = pictureBox1.Image;
            img.Image = imagem;
            dgvConsulta.Columns.Add(img);
            img.HeaderText = "BUSCAR";
            img.Name = "BUSCAR";
            dgvConsulta.Columns["BUSCAR"].Width = 60;
        }

        public void FormatarGrid()
        {            
            dgvConsulta.Columns["Item"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvConsulta.Columns["idCheckList"].Visible = false;           
        }

        public void ListarTudo()
        {
            string sql = "";
            sql += " Select * From CheckListGeral where TipoEquip = '" + cboTipoEquip.Text + "' and Especie = '" + cboEspecie.Text + "' ";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "CheckListGeral");
            dgvConsulta.DataSource = ds.Tables["CheckListGeral"];
            cx.Desconectar();
            FormatarGrid();
            if (cboAcao.Text == "CONSULTAR" || cboAcao.Text == "INSERIR")
            {
                dgvConsulta.Columns["BUSCAR"].Visible = false;
            }
            else
            {
                dgvConsulta.Columns["BUSCAR"].Visible = true;
            }
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            ListarTudo();
        }

        private void cboAcao_SelectedValueChanged(object sender, EventArgs e)
        {
            lblAcao.Text = cboAcao.Text;
            btnConcluir.Text = cboAcao.Text;
            if (cboAcao.Text == "CONSULTAR" || cboAcao.Text == "")
            {
                pnlItem.Visible = false;
            }
            else
            {
                pnlItem.Visible = true;
            }

            if (cboAcao.Text == "INSERIR")
            {
                btnCriarItem.Visible = true;
            }
            else
            {
                btnCriarItem.Visible = false;
            }

            dgvConsulta.DataSource = null;
            consulta.LimparControles(this);
            PreencherComboboxTipoEquip();
        }

        public void PreencherComboboxTipoEquip()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql += " Select DISTINCT TipoEquip from CheckListGeral WHERE TipoEquip != 'VAREJISTA'";
            cx.Conectar();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "CheckListGeral");
            cboTipoEquip.ValueMember = "idCheckList";
            cboTipoEquip.DisplayMember = "TipoEquip";
            cboTipoEquip.DataSource = ds.Tables["CheckListGeral"];
            cx.Desconectar();
            cboTipoEquip.Text = null;
            cboTipoEquip.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTipoEquip.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void dgvConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvConsulta.Columns[e.ColumnIndex].Name == "BUSCAR")
                {
                    txtID.Text = dgvConsulta.Rows[e.RowIndex].Cells["idCheckList"].Value.ToString();
                    txtEquipamento.Text = dgvConsulta.Rows[e.RowIndex].Cells["TipoEquip"].Value.ToString();
                    txtEspecie.Text = dgvConsulta.Rows[e.RowIndex].Cells["Especie"].Value.ToString();
                    txtItem.Text = dgvConsulta.Rows[e.RowIndex].Cells["Item"].Value.ToString();
                    if (cboAcao.Text == "INSERIR")
                    {
                        txtID.Text = "";
                        txtItem.Text = "";
                    }
                }
            }
            catch (Exception)
            {
                // MessageBox.Show(x.Message);
            }
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if (txtEquipamento.Text.Length > 0 && txtEspecie.Text.Length > 0 && txtItem.Text.Length > 0)
            {
                string retorno = "";
                if (btnConcluir.Text == "INSERIR")
                {
                    string sql = "";
                    try
                    {
                        sql += "insert into CheckListGeral (TipoEquip, Especie, Item) values ";
                        sql += "('" + txtEquipamento.Text + "', '" + txtEspecie.Text + "', '" + txtItem.Text + "')";
                        cx.Conectar();
                        SqlCommand cd = new SqlCommand();
                        cd.Connection = cx.c;
                        cd.CommandText = sql;
                        cd.ExecuteNonQuery();
                    }
                    catch (Exception x)
                    {
                        retorno = "ERRO";
                        MessageBox.Show("ERRO AO INSERIR EM : \n" + x.Message);
                    }
                    cx.Desconectar();
                    if(retorno == "")
                    {
                        MessageBox.Show(txtItem.Text + " ISERIDO COM SUCESSO.");
                        txtItem.Text = "";
                    }
                }
                else if (btnConcluir.Text == "ALTERAR")
                {
                    consulta.comando = "";
                    consulta.comando = "update CheckListGeral set Item = '" + txtItem.Text + "' where idCheckList = '" + txtID.Text + "'";
                    consulta.Atualizar();
                    if (consulta.Retorno == "ok")
                    {
                        MessageBox.Show(txtItem.Text + " ALTERADO COM SUCESSO.");
                        txtItem.Text = "";
                        txtID.Text = "";
                        txtEspecie.Text = "";
                        txtEquipamento.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("ERRO AO ALTERAR");
                    }
                }
                else if (btnConcluir.Text == "DELETAR")
                {
                    consulta.comando = "";
                    consulta.comando = "delete from CheckListGeral where idCheckList = '" + txtID.Text + "'";
                    consulta.Atualizar();
                    if (consulta.Retorno == "ok")
                    {
                        MessageBox.Show(txtItem.Text + " DELETADO COM SUCESSO.");
                        txtItem.Text = "";
                        txtID.Text = "";
                        txtEspecie.Text = "";
                        txtEquipamento.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("ERRO AO DELETAR");
                    }
                }
                else
                {
                    MessageBox.Show("TEM QUE ESTAR SELECIONADO");
                }
            }
            else
            {
                MessageBox.Show("OS CAMPOS DEVEM ESTAR PREENCHIDOS.");
            }
            
        }

        private void cboTipoEquip_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboAcao.Text == "INSERIR")
            {
                txtEquipamento.Text = cboTipoEquip.Text;
            }
        }

        private void cboTipoEquip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                            
            }
        }

        private void cboEspecie_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboAcao.Text == "INSERIR")
            {
                txtEspecie.Text = cboEspecie.Text;
            }
        }

        private void btnCriarItem_Click(object sender, EventArgs e)
        {
            if (cboAcao.Text == "INSERIR")
            {
                if (MessageBox.Show("DESEJA INSERIR O ITEM " + cboTipoEquip.Text + " ?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    txtEquipamento.Text = cboTipoEquip.Text;
                }
            }  
        }

        
    }
}
