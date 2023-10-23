using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CRMagazine
{
    public partial class frmLocalizador : Form
    {
        public frmLocalizador(string CT)
        {
            InitializeComponent();
            lblCT.Text = CT;
        }

        Consulta consulta = new Consulta();

        private void frmLocalizador_Load(object sender, EventArgs e)
        {

        }

        private void txtOS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                lblStatus.Text = "";
                if (lstRestante.Items.Contains(txtOS.Text))
                {
                    this.BackColor = System.Drawing.Color.Green;
                    lstConferido.Items.Add(txtOS.Text);
                    lstRestante.Items.Remove(txtOS.Text);
                    consulta.PlayOK();
                    txtOS.Focus();
                    txtOS.SelectAll();
                }
                else
                {
                    this.BackColor = System.Drawing.Color.WhiteSmoke;
                    if (lstConferido.Items.Contains(txtOS.Text))
                    {
                        //MessageBox.Show("ITEM JÁ CONFERIDO");
                        lblStatus.Text = "ITEM JÁ CONFERIDO";
                    }
                    consulta.PlayFail();
                    txtOS.Focus();
                    txtOS.SelectAll();
                    this.BackColor = System.Drawing.Color.WhiteSmoke;
                }
                int rowsrestante = lstRestante.Items.Count;
                lblRestante.Text = rowsrestante.ToString();
                int rowsconferido = lstConferido.Items.Count;
                lblTotalConferido.Text = rowsconferido.ToString();
            }
            
        }


        public void passar()
        {
            TextReader read = new System.IO.StringReader(txtOsParaLocalizar.Text);
            int rows = txtOsParaLocalizar.Lines.Length;
            int cont = 0;
            while (cont < rows)
            {
                string[] text1 = new string[rows];
                text1[cont] = read.ReadLine();
                if (text1[cont] != null)
                {
                    lstRestante.Items.Add(text1[cont]);
                }                
                cont = cont + 1;
            }
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            passar();
            txtOS.Select();
            int rowsrestante = lstRestante.Items.Count;
            lblRestante.Text = rowsrestante.ToString();
        }

        private void txtOsParaLocalizar_TextChanged(object sender, EventArgs e)
        {
            lblTotalListagem.Text = Convert.ToString(txtOsParaLocalizar.Lines.Length);
            TextReader read = new System.IO.StringReader(txtOsParaLocalizar.Text);
            int rows = txtOsParaLocalizar.Lines.Length;
           // string[] text1 = new string[rows];
            if (rows != 0)
            {
                string text = txtOsParaLocalizar.Lines[rows - 1];                
                if (text.Length == 0)
                {
                    lblTotalListagem.Text = Convert.ToString(txtOsParaLocalizar.Lines.Length - 1);
                }
            }
            
        }

        private void btnCopiarRestante_Click(object sender, EventArgs e)
        {
            string copy = "";
            int rows = lstRestante.Items.Count;
            if (rows > 0)
            {
                foreach (string item in lstRestante.Items)
                {
                    if (rows > 1)
                    {
                        copy += item + "\r\n";
                    }
                    else
                    {
                        copy += item;
                    }
                    rows--;
                }
                Clipboard.SetText(copy);
            }            
        }

        private void btnCopiarConferido_Click(object sender, EventArgs e)
        {
            string copy = "";
            int rows = lstConferido.Items.Count;
            if (rows > 0) 
            {
                foreach (string item in lstConferido.Items)
                {
                    if (rows > 1)
                    {
                        copy += item + "\r\n";
                    }
                    else
                    {
                        copy += item;
                    }
                    rows--;
                }
                Clipboard.SetText(copy); 
            }            
        }



       

       
    }
}
