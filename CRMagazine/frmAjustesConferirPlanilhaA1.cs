using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace CRMagazine
{
    public partial class frmAjustesConferirPlanilhaA1 : Form
    {
        public frmAjustesConferirPlanilhaA1(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Consulta consulta = new Consulta();
        Conexao cx = new Conexao();
        Criterios criterios = new Criterios();

        private void frmAjustesConferirPlanilhaA1_Load(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            txtErro.Text = "";
            lblStatus.Text = "";
            btnGravar.Enabled = false;
            OpenFileDialog vAbreArq = new OpenFileDialog();
            vAbreArq.Filter = "Microsoft Excel |*.xls; *.xlsx";
            vAbreArq.Title = "Selecione o Arquivo";
            if (vAbreArq.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show("igual =" + vAbreArq.FileName);
                string pasta = vAbreArq.FileName;
                txtEndereco.Text = pasta;
            }
        }

        private void btnLerPlanilha_Click(object sender, EventArgs e)
        {
            txtErro.Text = "";
            lblStatus.Text = "";
            btnGravar.Enabled = false;
            importdatafromexcel(txtEndereco.Text);
        }

        public int LinhaAtual = 0;
        public string Etiqueta = "";

        public void importdatafromexcel(string pasta)
        {
            string varejista = cboAcao.Text;

            string myexceldataquery = "select ETIQUETA, [DT ENTRADA], [TIPO ASSIST] from [" + varejista + "$]";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //create our connection strings
                string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + pasta + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
                // string ssqlconnectionstring = "Server=011EIND2899\\SQLEXPRESS;Database=Vistoria;UID=sa;PWD=123";
              //  string ssqlconnectionstring = "Data Source=10.83.200.23,49172;Initial Catalog=Positivo;User ID=sa;Password=Maiden!@#";

                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);

                oledbconn.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
            //    SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);


                int Cont = 1;
                while (dr.Read())
                {
                    Cont = Cont + 1;
                    lblStatus.Text = "Executando Linha: " + Cont;
                    Etiqueta = dr["ETIQUETA"].ToString();
                    string DTENTRADA = dr["DT ENTRADA"].ToString();
                    string STATUSA1 = dr["TIPO ASSIST"].ToString();                    
                    if (Etiqueta.Length == 0) // SE NÃO TEM DADOS, ENTÃO ENCERRA A LEITURA DA PLANILHA
                    {
                        MessageBox.Show("FINALIZADO");
                        break;
                    }
                    else
                    {
                        DTENTRADA = DTENTRADA.Substring(0, 10);
                        consulta.Coluna = "OS";
                        consulta.ValorDesejado = Etiqueta;
                        consulta.ComData = "SIM";                      
                        consulta.ConsultaTudo(lblCT.Text);

                        if (consulta.Retorno == "ok")
                        {
                          //  MessageBox.Show("ESTA NO POSTO.");
                            consulta.comando = "";
                            consulta.comando = "update Chamados set DataA1 = '" + DTENTRADA + "', StatusA1 = '" + STATUSA1 + "' where OS = '" + Etiqueta + "' and CT = '" + lblCT.Text + "'";
                            consulta.Atualizar();
                            //MessageBox.Show(consulta.comando);

                        }
                        

                        //  MessageBox.Show(Cod + "   " + Des + "   " + Pre);

                        LinhaAtual = Cont;
                        // ConsultaNS();
                        // ConsultaDuplicidadeNS();
                        // ConsultarEtiqueta();

                        //   ZeraVariaveis();    
                    }                                   
                }
                dr.Close();
                oledbconn.Close();
                this.Cursor = Cursors.Default;
                MessageBox.Show("PLANILHA INSERIDA COM SUCESSO.");
            }
            catch (Exception ex)
            {
                //handle exception
                MessageBox.Show("ERRO = " + ex);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

        }

       

    }
}
