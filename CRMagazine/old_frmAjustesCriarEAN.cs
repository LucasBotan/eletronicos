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
    public partial class old_frmAjustesCriarEAN : Form
    {
        public old_frmAjustesCriarEAN()
        {
            InitializeComponent();
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();


        private void frmAjustesCriarEAN_Load(object sender, EventArgs e)
        {
            txtNS.Select();
        }

        public void InserirEtiquetas()
        {
            string sql = "insert into PSREXTERNO_ETIQUETAS (TipoEtiqueta, CodViaVarejo, CodPositivo, EAN, Descricao, Anatel, Config1, Config2, Config3, Config4, Config5, Config6, Config7, Config8, Config9, Config10, Config11) values ";

            string query = "";
            GerarQuery(out query);

            sql += "('" + txtTipoEtq.Text + "', '', '" + txtCodPositivo.Text + "', '" + txtEAN.Text + " ', '" + txtDescAbreviada.Text + "', '" + txtAnatel.Text + "', ";
            sql += query;

            //MessageBox.Show(sql);

            consulta.comando = sql;
            consulta.Atualizar();
            if (consulta.Retorno == "ok")
            {
                MessageBox.Show("MODELO CADASTRADO.");
                btnLimparTela.PerformClick();
            }
            else
            {
                MessageBox.Show("ERRO AO CADASTRAR ETIQUETA.");
            }
        }

        private void txtNS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string tipo = "";
                consulta.NumeroSerie = txtNS.Text;
             //   consulta.ConsultarNSEQUISAP();
                txtCodPositivo.Text = consulta.SAPCodPos.TrimStart('0');               
                txtDescSAP.Text = consulta.SAPDescricao;
                tipo = consulta.SAPTipo;
                Tipo(tipo.Trim());
                txtTipo.Text = consulta.SAPTipo;
                if (consulta.Retorno == "ok")
                {
                      //CONSULTAR SE CODIGO JÁ ESTA CADASTRADO
                    consulta.comando = "select count(codPositivo) as Quantidade from PSREXTERNO_ETIQUETAS where codPositivo = '" + txtCodPositivo.Text + "'";
                      consulta.consultarSimNao();
                      if (consulta.qntNaPosicao == "0")
                      {
                          txtDescAbreviada.Select();
                      }
                      else
                      {
                          if (MessageBox.Show("CÓDIGO JÁ CADASTRADO.\r\nDEJESA ALTERAR?", "PERGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                          {
                              consulta.CodPositivo = txtCodPositivo.Text;
                             // consulta.consultarImpressao();

                              txtTipoEtq.Text = consulta.TipoEtiqueta;
                              txtEAN.Text = consulta.EAN;
                              txtDescAbreviada.Text = consulta.DescricaoEan;
                              txtAnatel.Text = consulta.Anatel;
                              txtConfig1.Text = consulta.Config1;
                              txtConfig2.Text = consulta.Config2;
                              txtConfig3.Text = consulta.Config3;
                              txtConfig4.Text = consulta.Config4;
                              txtConfig5.Text = consulta.Config5;
                              txtConfig6.Text = consulta.Config6;
                              txtConfig7.Text = consulta.Config7;
                              txtConfig8.Text = consulta.Config8;
                              txtConfig9.Text = consulta.Config9;
                              txtConfig10.Text = consulta.Config10;
                              txtConfig11.Text = consulta.Config11;
                              btnConcluir.Text = "ALTERAR";

                          }
                          else
                          {
                              btnLimparTela.PerformClick();
                          }
                      }
                }
                else
                {
                    MessageBox.Show("NÚMERO DE SÉRIE NÃO CADASTRADO NO SAP");
                }
                   

                /*
                  
                 */



            }         
        }

        public void Tipo(string tipo)
        {
            if (tipo == "SMART2CHIP" ||
                tipo == "MESG3CHIP" ||
                tipo == "SMART3CHIP" ||
                tipo == "MESG2CHIP" ||
                tipo == "SMART1CHIP"
               )
            {
                if (txtDescSAP.Text.Contains("SMART"))
                {
                    txtTipo.Text = "SMART";
                    //=====TIPO ETQ
                    if (txtDescSAP.Text.Contains("QUANTUM"))
                    {
                        txtTipoEtq.Text = "QUANTUM";
                    }
                    else
                    {
                        txtTipoEtq.Text = "CELULAR";
                    }
                    //=== FIM TIPO ETQ
                }
                else
                {
                    txtTipo.Text = "FEATURE";
                    txtTipoEtq.Text = "CELULAR";
                }
            }
            //  else if( tipo == "MESG3CHIP" ||
            //    tipo == "MESG2CHIP" 
            //      )
            //  {
            //       txtTipo.Text = "FEATURE";
            //   }
            else if (tipo == "DESKTOP")
            {
                if (txtDescSAP.Text.Contains("UNION"))
                {
                    txtTipo.Text = "UNION";
                    txtAnatel.Text = "0";
                }
                else
                {
                    txtTipo.Text = tipo;
                }
                txtTipoEtq.Text = "EANVERTICAL";
                txtAnatel.Text = "0";
            }
            else if (tipo == "TABLET")
            {
                txtTipoEtq.Text = "TABLET";
                txtAnatel.Text = "0";
            }
            else if (tipo == "NOTEBOOK")
            {
                txtTipoEtq.Text = "EANHORIZONTAL";
                txtAnatel.Text = "0";
            }
            else
            {
                 txtTipo.Text = tipo;
                 txtTipoEtq.Text = "EANVERTICAL";
                 txtAnatel.Text = "0";
            }
           
            

        }

        private void txtCodPositivo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTipoEtq_TextChanged(object sender, EventArgs e)
        {
            if (txtTipoEtq.Text == "")
            {
                lblConfig1.Text = "CONFIG1"; txtConfig1.Enabled = true;
                lblConfig2.Text = "CONFIG2"; txtConfig2.Enabled = true;
                lblConfig3.Text = "CONFIG3"; txtConfig3.Enabled = true;
                lblConfig4.Text = "CONFIG4"; txtConfig4.Enabled = true;
                lblConfig5.Text = "CONFIG5"; txtConfig5.Enabled = true;
                lblConfig6.Text = "CONFIG6"; txtConfig6.Enabled = true;
                lblConfig7.Text = "CONFIG7"; txtConfig7.Enabled = true;
                lblConfig8.Text = "CONFIG8"; txtConfig8.Enabled = true;
                lblConfig9.Text = "CONFIG9"; txtConfig9.Enabled = true;
                lblConfig10.Text = "CONFI10"; txtConfig10.Enabled = true;
                lblConfig11.Text = "CONFIG11"; txtConfig11.Enabled = true;
            }
            else if (txtTipoEtq.Text == "TABLET")
            {
                lblConfig1.Text = "CONFIGURAÇÃO (7.0'' - 4GB - WIFI)";
                lblConfig2.Text = "CONFIG2"; txtConfig2.Enabled = false;
                lblConfig3.Text = "CONFIG3"; txtConfig3.Enabled = false;
                lblConfig4.Text = "CONFIG4"; txtConfig4.Enabled = false;
                lblConfig5.Text = "CONFIG5"; txtConfig5.Enabled = false;
                lblConfig6.Text = "CONFIG6"; txtConfig6.Enabled = false;
                lblConfig7.Text = "CONFIG7"; txtConfig7.Enabled = false;
                lblConfig8.Text = "CONFIG8"; txtConfig8.Enabled = false;
                lblConfig9.Text = "CONFIG9"; txtConfig9.Enabled = false;
                lblConfig10.Text = "CONFI10"; txtConfig10.Enabled = false;
                lblConfig11.Text = "CONFIG11"; txtConfig11.Enabled = false;
            }
            else if (txtTipoEtq.Text == "QUANTUM" || txtTipoEtq.Text == "CELULAR")
            {
                lblConfig1.Text = "BAREBONE"; txtConfig1.Enabled = true;
                lblConfig2.Text = "COR";     txtConfig2.Enabled = true;
                lblConfig3.Text = "CONFIG3"; txtConfig3.Enabled = false;
                lblConfig4.Text = "CONFIG4"; txtConfig4.Enabled = false;
                lblConfig5.Text = "CONFIG5"; txtConfig5.Enabled = false;
                lblConfig6.Text = "CONFIG6"; txtConfig6.Enabled = false;
                lblConfig7.Text = "CONFIG7"; txtConfig7.Enabled = false;
                lblConfig8.Text = "CONFIG8"; txtConfig8.Enabled = false;
                lblConfig9.Text = "CONFIG9"; txtConfig9.Enabled = false;
                lblConfig10.Text = "CONFI10"; txtConfig10.Enabled = false;
                lblConfig11.Text = "CONFIG11"; txtConfig11.Enabled = false;
            }
            else if (txtTipoEtq.Text == "EANHORIZONTAL" || txtTipoEtq.Text == "EANVERTICAL")
            {
                lblConfig1.Text = "PROCESSADOR"; txtConfig1.Enabled = true;
                lblConfig2.Text = "SIST OPERACIONAL"; txtConfig2.Enabled = true;
                lblConfig3.Text = "MEMORIA"; txtConfig3.Enabled = true;
                lblConfig4.Text = "HDD"; txtConfig4.Enabled = true;
                lblConfig5.Text = "OUTROS"; txtConfig5.Enabled = true;
                lblConfig6.Text = "OUTROS"; txtConfig6.Enabled = true;
                lblConfig7.Text = "OUTROS"; txtConfig7.Enabled = true;
                lblConfig8.Text = "OUTROS"; txtConfig8.Enabled = true;
                lblConfig9.Text = "OUTROS"; txtConfig9.Enabled = true;
                lblConfig10.Text = "OUTROS"; txtConfig10.Enabled = true;
                lblConfig11.Text = "OUTROS"; txtConfig11.Enabled = true;
            }
           
        }

        private void btnLimparTela_Click(object sender, EventArgs e)
        {
            consulta.LimparControles(this);
            btnConcluir.Text = "CONCLUIR";
            txtNS.Select();
        }

        public void GerarQuery(out string query)
        {
            string confg1 = txtConfig1.Text;
            string confg2 = txtConfig2.Text;
            string confg3 = txtConfig3.Text;
            string confg4 = txtConfig4.Text;
            string confg5 = txtConfig5.Text;
            string confg6 = txtConfig6.Text;
            string confg7 = txtConfig7.Text;
            string confg8 = txtConfig8.Text;
            string confg9 = txtConfig9.Text;
            string confg10 = txtConfig10.Text;
            string confg11 = txtConfig11.Text;

            query = " '" + confg1 + "', '" + confg2 + "','" + confg3 + "','" + confg4 + "','" + confg5 + "','" + confg6 + "','" + confg7 + "','" + confg8 + "','" + confg9 + "','" + confg10 + "','" + confg11 + "') ";
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            string check;
            Verificacao(out check);
            if (check == "falha")
            {
                MessageBox.Show("PREENCHA OS CAMPOS OBRIGATORIOS");
            }
            else
            {
                if (btnConcluir.Text == "CONCLUIR")
                {
                    InserirEtiquetas();
                }
                else
                {
                    AlterarEtiquetas();
                }
            }            
        }

        public void AlterarEtiquetas()
        {
            string sql = "update PSREXTERNO_ETIQUETAS set TipoEtiqueta = '" + txtTipoEtq.Text + "',  CodViaVarejo = '', CodPositivo = '" + txtCodPositivo.Text + "', EAN = '" + txtEAN.Text + " ', Descricao = '" + txtDescAbreviada.Text + "', Anatel = '" + txtAnatel.Text + "', ";
            sql += "Config1 = '" + txtConfig1.Text + "', Config2 = '" + txtConfig2.Text + "', Config3 = '" + txtConfig3.Text + "', Config4 = '" + txtConfig4.Text + "', Config5 = '" + txtConfig5.Text + "', Config6 = '" + txtConfig6.Text + "', Config7 = '" + txtConfig7.Text + "', Config8 = '" + txtConfig8.Text + "', Config9 = '" + txtConfig9.Text + "', Config10 = '" + txtConfig10.Text + "', Config11 = '" + txtConfig11.Text + "'";
            sql += " where CodPositivo = '" + txtCodPositivo.Text + "'";
            consulta.comando = sql;
            consulta.Atualizar();
            if (consulta.Retorno == "ok")
            {
                MessageBox.Show("ETIQUETA ALTERADA COM SUCESSO.");
                btnLimparTela.PerformClick();
            }
            else
            {
                MessageBox.Show("ERRO AO ALTERAR ETIQUETA.");
            }

        }


        public string check = "";
        public void Verificacao(out string check)
        {
            check = "";

            //==============PADRÃO=======================
            //===== NUMERO SERIE
            if (txtNS.Text.Length == 0)
            {
                check = "falha";
                txtNS.BackColor = Color.Tomato;
            }
            else
            {
                txtNS.BackColor = DefaultBackColor;
            }

            if (txtDescAbreviada.Text.Length == 0)
            {
                check = "falha";
                txtDescAbreviada.BackColor = Color.Tomato;
            }
            else
            {
                txtDescAbreviada.BackColor = DefaultBackColor;
            }

            if (txtEAN.Text.Length == 0)
            {
                check = "falha";
                txtEAN.BackColor = Color.Tomato;
            }
            else
            {
                txtEAN.BackColor = DefaultBackColor;
            }

            if (txtTipoEtq.Text.Length == 0)
            {
                check = "falha";
                txtTipoEtq.BackColor = Color.Tomato;
            }
            else
            {
                txtTipoEtq.BackColor = DefaultBackColor;
            }

            if (txtAnatel.Text.Length == 0)
            {
                check = "falha";
                txtAnatel.BackColor = Color.Tomato;
            }
            else
            {
                txtAnatel.BackColor = DefaultBackColor;
            }

            if (txtConfig1.Text.Length == 0)
            {
                check = "falha";
                txtConfig1.BackColor = Color.Tomato;
            }
            else
            {
                txtConfig1.BackColor = DefaultBackColor;
            }
            //============== FIM PADRÃO====================

            if(txtTipoEtq.Text == "CELULAR" || txtTipoEtq.Text == "QUANTUM")
            {
                if (txtConfig2.Text.Length == 0)
                {
                    check = "falha";
                    txtConfig2.BackColor = Color.Tomato;
                }
                else
                {
                    txtConfig2.BackColor = DefaultBackColor;
                }
            }
            if (txtTipoEtq.Text == "EANHORIZONTAL" || txtTipoEtq.Text == "EANVERTICAL")
            {
                if (txtConfig2.Text.Length == 0)
                {
                    check = "falha";
                    txtConfig2.BackColor = Color.Tomato;
                }
                else
                {
                    txtConfig2.BackColor = DefaultBackColor;
                }
                if (txtConfig3.Text.Length == 0)
                {
                    check = "falha";
                    txtConfig3.BackColor = Color.Tomato;
                }
                else
                {
                    txtConfig3.BackColor = DefaultBackColor;
                }
                if (txtConfig4.Text.Length == 0)
                {
                    check = "falha";
                    txtConfig4.BackColor = Color.Tomato;
                }
                else
                {
                    txtConfig4.BackColor = DefaultBackColor;
                }
            }


        }

    }
}
