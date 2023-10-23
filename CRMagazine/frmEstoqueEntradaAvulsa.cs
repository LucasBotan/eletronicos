using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMagazine
{
    public partial class frmEstoqueEntradaAvulsa : Form
    {
        public frmEstoqueEntradaAvulsa(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consultar = new Consulta();

        private void frmEstoqueEntradaSeparada_Load(object sender, EventArgs e)
        {

        }

        public void Concluir(string Cod, string Quantidade, string Descricao)
        {
            string posicao = "REC";
            string qntNaPosicao = "";
            consultar.comando = "";
            consultar.comando += "Select * from Estoque where Codigo = '" + Cod + "' and Posicao = '" + posicao + "' and CT = '" + lblCT.Text + "'";
            consultar.consultarSimNao();
            if (consultar.Retorno == "ok")
            {
                qntNaPosicao = consultar.qntNaPosicao;
                int total = 0;
                total = Convert.ToInt32(qntNaPosicao) + Convert.ToInt32(Quantidade);
                consultar.comando = "";
                consultar.comando = "update Estoque set Quantidade = '" + total + "' where Posicao = '" + posicao + "' and Codigo = '" + Cod + "' and CT = '" + lblCT.Text + "'";
                // MessageBox.Show(consultar.comando);

                consultar.Atualizar();

                if(consultar.Retorno == "ok")
                {
                    MessageBox.Show("CONCLUIDO.");
                    btnLimparTela.PerformClick();
                }
            }
            else
            {
                string sql = "";
                // consultar.comando = "";
                //consultar.comando += "Select * from Estoque where Codigo = '" + Cod + "'";
                consultar.Codigo = Cod;
                consultar.consultarEstoque(lblCT.Text);
                string Barebone = consultar.Barebone;
                //  string Descricao = consultar.Descricao;
                string Tipo = consultar.Tipo;
                string BareboneEquivalente = consultar.BareboneEquivalente;
                try
                {
                    sql = "";
                    sql += " Insert into Estoque (CT, Codigo, Barebone, Descricao, Quantidade, Posicao, Tipo, BareboneEquivalente)";
                    sql += " Values ( ";
                    sql += " '" + lblCT.Text + "', ";
                    sql += " '" + Cod + "', ";
                    sql += " '" + Barebone + "', ";
                    sql += " '" + Descricao + "', ";
                    sql += " '" + Quantidade + "', ";
                    sql += " '" + posicao + "', ";
                    sql += " '" + Tipo + "', ";
                    sql += " '" + BareboneEquivalente + "')";
                    //MessageBox.Show(sql);        

                    cx.Conectar();
                    SqlCommand cd = new SqlCommand();
                    cd.Connection = cx.c;
                    cd.CommandText = sql;
                    cd.ExecuteNonQuery();
                    cx.Desconectar();

                    MessageBox.Show("CONCLUIDO.");
                    btnLimparTela.PerformClick();                 
                    

                }
                catch (SqlException x)
                {
                    MessageBox.Show("ERRO AO CONCLUIR ENTRADA DE ESTOQUE: \r\n" + x.Message);
                }
                cx.Desconectar();
            }
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            if (txtCodPeca.Text.Length == 0)
            {
                MessageBox.Show("PREENCHA O CODIGO.");
            }
            else if(txtDescPeca.Text.Length == 0)
            {
                MessageBox.Show("INFORME A DESCRIÇÃO DO PRODUTO.");
            }
           // else if (txtTipo.Text.Length == 0)
           // {
           //     MessageBox.Show("INFORME O TIPO DO PRODUTO.");
           // }
            else if (txtQuantidade.Text.Length == 0 || txtQuantidade.Text == "0")
            {
                MessageBox.Show("INFORME A QUANTIDADE.");
            }
            else
            {
                Concluir(txtCodPeca.Text, txtQuantidade.Text, txtDescPeca.Text);
            }

           
        }

        private void txtCodPeca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCodPeca.Text = txtCodPeca.Text.TrimStart('0');
                ConsultaCodigo();
            }
        }

        public void ConsultaCodigo()
        {
            consultar.Codigo = txtCodPeca.Text.ToString();
            consultar.consultarEstoque(lblCT.Text);
            if (consultar.Retorno == "ok")
            {
                txtDescPeca.Text = consultar.Descricao;
                txtTipo.Text = consultar.Tipo;
                txtQuantidade.Select();
               
            }
            else
            {                
                consultar.consultarBaseCodigos(txtCodPeca.Text);
                if (consultar.Retorno == "ok")
                {
                    txtDescPeca.Text = consultar.Descricao;
                    txtTipo.Text = consultar.Tipo;
                    txtQuantidade.Select();
                }
                else
                {
                    if (MessageBox.Show("CÓDIGO NÃO ENCONTRADO NO ESTOQUE!\r\n DESEJA INSERIR ASSIM MESMO?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txtDescPeca.ReadOnly = false;
                        txtTipo.ReadOnly = false;
                    }
                    else
                    {
                        txtCodPeca.Text = "";
                        txtCodPeca.Select();
                    }
                    
                    
                }
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                btnEntrada.Select();
            }
        }

        private void btnLimparTela_Click(object sender, EventArgs e)
        {
            consultar.LimparControles(this);
            txtDescPeca.ReadOnly = true;
            txtTipo.ReadOnly = true;
            txtCodPeca.Select();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

       

    }
}
