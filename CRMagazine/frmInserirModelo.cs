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
    public partial class frmInserirModelo : Form
    {
        public frmInserirModelo(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        private void frmInserirModelo_Load(object sender, EventArgs e)
        {
            consultar.ListarVarejistas(cboVarejista);
            txtCodVarejo.Select();
        }

        Conexao cx = new Conexao();
        Consulta consultar = new Consulta();

        private void txtCodVarejista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cboVarejista.Text.Length == 0)
                {
                    MessageBox.Show("INFORME O VAREJISTA PARA FAZER A CONSULTA DO CÓDIGO.");
                }
                else
                {
                    consultar.ConsultarCodVarejo(txtCodVarejo.Text, cboVarejista.Text);
                    //VerificaSeJaEstaCadastrado();
                    if (consultar.Retorno == "ok")
                    {
                        if (MessageBox.Show("CÓDIGO JÁ CADASTRADO PARA O VAREJISTA.\r\nDEJESA ALTERAR?", "PERGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            txtDescricao.Text = consultar.Descricao;
                            txtEAN.Text = consultar.EANpuri;
                            txtSKU.Text = consultar.SKU;
                            txtTipoEquip.Text = consultar.TipoEquip;
                            cboVarejista.Text = consultar.Varejista;
                            btnConcluir.Text = "ALTERAR";
                        }
                    }
                    else
                    {
                        txtDescricao.Select();
                    }
                }
            }            
          
        }

        private void txtCodVarejo_Leave(object sender, EventArgs e)
        {
            if (txtCodVarejo.Text.Length > 0)
            {
                if (cboVarejista.Text.Length == 0)
                {
                    MessageBox.Show("INFORME O VAREJISTA PARA FAZER A CONSULTA DO CÓDIGO.");
                }
                else
                {
                    //VerificaSeJaEstaCadastrado();
                    consultar.ConsultarCodVarejo(txtCodVarejo.Text, cboVarejista.Text);
                    if (consultar.Retorno == "ok")
                    {
                        if (MessageBox.Show("CÓDIGO JÁ CADASTRADO.\r\nDEJESA ALTERAR?", "PERGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            txtDescricao.Text = consultar.Descricao;
                            txtEAN.Text = consultar.EANpuri;
                            txtSKU.Text = consultar.SKU;
                            txtTipoEquip.Text = consultar.TipoEquip;
                            cboVarejista.Text = consultar.Varejista;
                            btnConcluir.Text = "ALTERAR";
                        }
                    }
                    else
                    {
                        txtDescricao.Select();
                    }
                }
               
          
            }
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSKU.Select();
            }
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if (txtSKU.Text.Length == 0 || txtSKU.Text.Length == 0 || txtSKU.Text.Length == 0 || txtSKU.Text.Length == 0 || cboVarejista.Text.Length == 0)
            {
                consultar.PlayFail();
                MessageBox.Show("PREENCHA TODAS AS INFORMAÇÕES.");
            }
            else
            {
                if (MessageBox.Show("DESEJA CONCLUIR? \n" + txtDescricao.Text, "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (btnConcluir.Text == "CONCLUIR")
                    {
                        InserirEquipamento();
                        consultar.LimparControles(this);
                        btnConcluir.Text = "CONCLUIR";
                    }
                    else
                    {
                        Atualizar();
                        consultar.LimparControles(this);
                        btnConcluir.Text = "CONCLUIR";
                    }

                   
                }
            }         
        }

      
        public void InserirEquipamento()
        {
            string sql = ""; 
            try
            {
                sql += " Insert into CodVarejo (CodVarejo, Descricao, SKU, Varejista, TipoEquip, EAN)";
                sql += " Values ( ";
                sql += " '" + txtCodVarejo.Text + "', ";
                sql += " '" + txtDescricao.Text + "', ";               
                sql += " '" + txtSKU.Text + "', ";
                sql += " '" + cboVarejista.Text + "', ";      
                sql += " '" + txtTipoEquip.Text + "', ";
                sql += " '" + txtEAN.Text + "')";
                cx.Conectar();
                SqlCommand cd = new SqlCommand();
                cd.Connection = cx.c;
                cd.CommandText = sql;
                cd.ExecuteNonQuery();                                
                cx.Desconectar();
            }
            catch (SqlException x)
            {
                MessageBox.Show("ERRO AO INSERIR EQUIPAMENTO. \n " + x.Message);
            }
            cx.Desconectar();
        }

        public void Atualizar()
        {
            string sql = "";
            sql = "update CodVarejo set ";           
            sql += "Descricao =  '" + txtDescricao.Text + "', ";
            sql += "SKU =  '" + txtSKU.Text + "', ";
            sql += "Varejista =  '" + cboVarejista.Text + "', ";
            sql += "TipoEquip =  '" + txtTipoEquip.Text + "', ";
            sql += "EAN =  '" + txtEAN.Text + "' ";
            sql += " where CodVarejo = '" + txtCodVarejo.Text + "' and Varejista = '" + cboVarejista.Text + "' ";
            consultar.comando = "";
            consultar.comando = sql;
            consultar.Atualizar();
        }


        public string Retorno = "";
        public void VerificaSeJaEstaCadastrado()
        {
            try
            {
                string sql = "";
                sql += " Select CodVarejo from CodVarejo";
                sql += " where CodVarejo = '" + txtCodVarejo.Text + "' and Varejista = '" + cboVarejista.Text + "' ";
                cx.Conectar();
                SqlCommand cd2 = new SqlCommand();
                cd2.Connection = cx.c;
                cd2.CommandText = sql;
                SqlDataReader dr2 = cd2.ExecuteReader();
                if (dr2.Read())
                {
                    MessageBox.Show("CODIGO JÁ CADASTRADO PARA O VAREJISTA.");
                    txtCodVarejo.Text = "";   
                    txtCodVarejo.Select();
                    Retorno = "falha";
                }
                else
                {
                    Retorno = "ok";
                }
                dr2.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show("ERRO AO CONSULTAR CODIGO VAREJO " + x.Message);                
            }
            cx.Desconectar();
        }

        private void txtSKU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTipoEquip.Select();
            }            
        }

        private void txtTipoEquip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnConcluir.Select();
            }  
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            consultar.LimparControles(this);
            txtCodVarejo.Select();
        }

    

                
      
        
    }
}
