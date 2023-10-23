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
using System.Drawing.Printing;

namespace CRMagazine
{
    public partial class frmImprimirEtqEntrada : Form
    {
        public frmImprimirEtqEntrada(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Consulta consulta = new Consulta();
        Impressao imprimir = new Impressao();
        Conexao cx = new Conexao();

        private void frmImprimirEtqEntrada_Load(object sender, EventArgs e)
        {
            txtOS.Select();
        }

        private void txtOS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBusca.PerformClick();
            }            
        }
                
        private void btnBusca_Click(object sender, EventArgs e)
        {
            if (txtOS.Text.Length > 0)
            {
                consulta.Coluna = "OS";
                consulta.ValorDesejado = txtOS.Text;
                consulta.ComData = "SIM";
                // consulta.DataDesejada = txtDataDesejadaNaoLimpar.Text;
                consulta.ConsultaTudo(lblCT.Text);
                if (consulta.Descricao == "")
                {
                    MessageBox.Show("OS NÃO ENCONTRADO.");
                    txtOS.Select();
                    txtOS.SelectAll();
                }
                else
                {
                    txtDescricao.Text = consulta.Descricao;

                    DateTime dt = Convert.ToDateTime(consulta.DtEntrada);

                    txtDataEntrada.Text = dt.ToString("dd/MM/yyyy");

                    //CALCULA DATA + 30 DIAS                    
                    DateTime Mais30 = dt.AddDays(30);
                    string DataMais30 = Mais30.ToString("dd/MM/yyyy");
                    txtData30.Text = DataMais30;
                }
            }
            else
            {
                MessageBox.Show("INFORME A OS.");
            }


            /*
            DateTime dat = Convert.ToDateTime(txtRecebeData.Text);
            DateTime Mais30 = dat.AddDays(30);
            string DataMais30 = Mais30.ToString("dd/MM/yyyy");            
            txtDataEntrada.Text = dat.ToString("dd/MM/yyyy");
            txtData30.Text = DataMais30;
             */
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            if (txtOS.Text.Length > 0 && txtDescricao.Text.Length > 0 && txtDataEntrada.Text.Length > 0)
            {
                Imprimir();
                btnLimpar.PerformClick();
            }
            else
            {
                MessageBox.Show("PREENCHA TODAS AS INFORMAÇÕES");
            }

        }

        public void Imprimir()
        {      

            imprimir.EtiquetaEntrada(txtOS.Text, txtDataEntrada.Text, txtData30.Text);

            string codZPL = imprimir.s;

            // SELECIONAR IMPRESSORA OU UTILIZAR A PADRÃO
            if (chbSelecionarImpressora.Checked)
            {
                // Allow the user to select a printer.
                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new PrinterSettings();
                if (DialogResult.OK == pd.ShowDialog(this))
                {
                    // Send a printer-specific to the printer.
                    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, codZPL);
                }
            }
            else
            {
                string nomeImpressoraPadrao = (new PrinterSettings()).PrinterName;
                RawPrinterHelper.SendStringToPrinter(nomeImpressoraPadrao, codZPL);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            consulta.LimparControles(this);            
            txtOS.Select();
        }

       

    }
}
