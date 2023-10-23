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
using System.Configuration;

namespace CRMagazine
{
    public partial class old_frmEstoqueAjustar : Form
    {
        public old_frmEstoqueAjustar()
        {
            InitializeComponent();
            
        }

        Conexao cx = new Conexao();

        private SqlDataAdapter sqlDataAdapter = null;
        private SqlCommandBuilder sqlCommandBuilder = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        private String sql = null;

        private void frmEstoqueAjustar_Load(object sender, EventArgs e)
        {            
            TornarTudoReadOnly();
        }

        public void TornarTudoReadOnly()
        {
            for (int i = 0; i < dgvCheckList.RowCount; i++)
            {
                for (int j = 0; j < dgvCheckList.ColumnCount; j++)
                {
                    dgvCheckList.Rows[i].Cells[j].ReadOnly = true;
                    dgvCheckList.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
            foreach (DataGridViewColumn coluna in dgvCheckList.Columns)
            {
                coluna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void ListarCheckList()
        {
            string sql = "";
            // sqlntb += "select count(Descricao) AS QNT_NOTE from MaquinasNoPosto where Descricao like '%NTB%'";
            sql += " SELECT * FROM Estoque where Codigo = '" + txtCodigo.Text + "'";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Estoque");
            dgvCheckList.DataSource = ds.Tables["Estoque"];
            cx.Desconectar();
        }

        public void testegringo()
        {
            //connectionString = ConfigurationManager.AppSettings["connectionString"];
            //sqlConnection = new SqlConnection(connectionString);
            sql = "SELECT * FROM Estoque where Codigo = '" + txtCodigo.Text + "'";

            //sqlConnection.Open();
            cx.Conectar();

            sqlDataAdapter = new SqlDataAdapter(sql, cx.c);
            sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            dgvCheckList.DataSource = bindingSource;

            // if you want to hide Identity column
            dgvCheckList.Columns[0].Visible = false;
            dgvCheckList.RowHeadersVisible = false;
            dgvCheckList.AutoResizeColumns();
            cx.Desconectar();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            testegringo();
            TornarTudoReadOnly();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            ImpedirNull();
            if (MessageBox.Show("Deseja realmente ajustar o Código " + txtCodigo.Text + "?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {                
                try
                {
                    sqlDataAdapter.Update(dataTable);
                    MessageBox.Show("Atualizado!");
                }
                catch (Exception exceptionObj)
                {
                    MessageBox.Show(exceptionObj.Message.ToString());
                }
                cx.Desconectar();
                TornarTudoReadOnly(); 
            }           
        }

        public int contar = 0;   
        public List<string> coluna = new List<string>();
        public List<string> linha = new List<string>();
       

        private void dgvCheckList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string texto = "";
            if(MessageBox.Show("DESEJA REALMENTE EDITAR ESSA CELULA ? ", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int column = e.ColumnIndex;
                int row = e.RowIndex;
                texto = dgvCheckList.Rows[row].Cells[column].Value.ToString();
                dgvCheckList.Rows[row].Cells[column].Style.BackColor = Color.Green;
                dgvCheckList.Rows[row].Cells[column].ReadOnly = false;

                
                coluna.Add(column.ToString());
                linha.Add(row.ToString());
                contar = contar + 1;

            }
            else
            {
               
            }
            

        }


        public void ImpedirNull()
        {
            for (int x = contar-1; x >= 0; x--)
            {
                string i = linha[x];
                string j = coluna[x];
                //MessageBox.Show(dgvCheckList.Rows[Convert.ToInt32(i)].Cells[Convert.ToInt32(j)].Value.ToString());

                if (dgvCheckList.Rows[Convert.ToInt32(i)].Cells[Convert.ToInt32(j)].Value.ToString() == "")
                {
                    dgvCheckList.Rows[Convert.ToInt32(i)].Cells[Convert.ToInt32(j)].Value = "0";
                }
            }
            /*
            for (int i = 0; i < dgvCheckList.RowCount; i++)
            {
                for (int j = 0; j < dgvCheckList.ColumnCount; j++)
                {
                    if (dgvCheckList.Rows[i].Cells[j].Style.BackColor == Color.Green) 
                    {
                        if(dgvCheckList.Rows[i].Cells[j].Value.ToString() == "")
                        {
                            dgvCheckList.Rows[i].Cells[j].Value = 0;
                        }
                    }              
                }
            }
             */ 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImpedirNull();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnListar.PerformClick();
            }
        }



    }
}
