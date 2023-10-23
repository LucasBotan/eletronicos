using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.SqlClient;

namespace CRMagazine
{
    public partial class frmImprimirEAN : Form
    {
        public frmImprimirEAN(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();
        Impressao imprimir = new Impressao();

        private void frmImprimirEAN_Load(object sender, EventArgs e)
        {
            txtBusca.Select();            
            rbt220.Checked = true;
            cboVarejista.Text = "VIAVAREJO";
            cboBusca.Text = "CÓDIGO VAREJO";
        }

        private void chbUsarEAN_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if (chbSemConexao.Checked) //coloquei o msm nome do sem conexao
            {
                lblTipoBusca.Text = "EAN";
                txtBusca.Select();
            }
            else
            {
                lblTipoBusca.Text = "SKU";
                txtBusca.Select();
            }
             */ 
        }


        private void cboBusca_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboBusca.Text == "CÓDIGO VAREJO")
            {
                lblTipoBusca.Text = "CÓDIGO VAREJO";
                txtBusca.Select();
            }
            else if (cboBusca.Text == "EAN")
            {
                lblTipoBusca.Text = "EAN";
                txtBusca.Select();
            }
            else
            {
                lblTipoBusca.Text = "SKU";
                txtBusca.Select();
            }
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            string BuscaColuna = "CODVAREJO";
            if (cboBusca.Text == "CÓDIGO VAREJO")
            {
                BuscaColuna = "CODVAREJO";
            }
            else if (cboBusca.Text == "EAN")
            {
                BuscaColuna = "EAN";                
            }
            else
            {
                BuscaColuna = "SKU";
            }
            

            if(txtBusca.Text.Length == 0)
            {
                MessageBox.Show("INFORME O SKU OU EAN.");
            }
            else
            {
                consulta.ConsultarEAN(BuscaColuna, txtBusca.Text, cboVarejista.Text);

                if (consulta.Retorno == "ok")
                {
                    txtDescricao.Text = consulta.Descricao;
                    txtCodVarejo.Text = consulta.CodVarejo;
                    txtSKU.Text = consulta.SKU;
                    txtEAN.Text = consulta.EANpuri;
                    btnReimprimir.Select();
                }
                else
                {
                    consulta.PlayFail();
                    MessageBox.Show("MODELO NÃO ENCONTRADO.");
                    txtBusca.Select();
                    txtBusca.SelectAll();
                }
            }


           
        }

        private void txtBusca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBusca.PerformClick();
            }
        }


        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Length > 0)
            {
                Imprimir();
                txtBusca.Select();
            }
            
        }

        public void Imprimir()
        {
            string Voltagem = "";
            if (rbt110.Checked)
            {
                Voltagem = "110";
            }
            else if (rbtBIv.Checked)
            {
                Voltagem = "BI";
            }
            else
            {
                Voltagem = "220";
            }


            if (chbConfigImpressora.Checked)
            {
                imprimir.EtiquetaEANPuriConfig(Voltagem, txtCodVarejo.Text, txtSKU.Text, txtEAN.Text, txtDescricao.Text);
            }
            else
            {
                imprimir.EtiquetaEANPuri(Voltagem, txtCodVarejo.Text, txtSKU.Text, txtEAN.Text, txtDescricao.Text);
            }


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
            txtBusca.Select();
        }

       

        

       


        
    }
}
