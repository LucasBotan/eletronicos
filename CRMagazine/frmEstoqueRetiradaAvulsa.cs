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
    public partial class frmEstoqueRetiradaAvulsa : Form
    {
        public frmEstoqueRetiradaAvulsa(string CT)//string Cod, string Usuario, string Quantidade, string ID, string Chamado)
        {
            InitializeComponent();
            lblCT.Text = CT;
            /*
            txtCodPeca.Text = Cod;
            txtUsuario.Text = Usuario;
            txtQntd.Text = Quantidade;
            txtID.Text = ID;
            txtChamado.Text = Chamado;
             */
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();



        private void frmEstoqueExternoEntrega_Load(object sender, EventArgs e)
        {
            ListarUsuarios();

            /*
            if (txtUsuario.Text.Length == 0)
            {
                ListarUsuarios();
            }
            else
            {
                ConsultaCodigo();
                if (txtCodPeca.Text.Length > 0)
                {
                    if (txtChamado.Text.Length > 0)
                    {
                        ListarPPMagazine();
                    }
                    else
                    {
                        ListarLocais();
                    }                   
                }    
            }
             */ 
            FormatarGridListar();
        }

        public void ListarUsuarios()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql += " Select Usuario from Usuarios where Reparo = 'yes' and CT = '" + lblCT.Text + "'";
            // sql += " Order by  Categoria ";
            cx.Conectar();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "Usuarios");
            cbxTecnico.ValueMember = "idUsuario";
            cbxTecnico.DisplayMember = "Usuario";
            cbxTecnico.DataSource = ds.Tables["Usuarios"];
            cx.Desconectar();
            cbxTecnico.Text = null;
        }

        public void ListarClientes()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql += " Select CPF from Clientes";
            // sql += " Order by  Categoria ";
            cx.Conectar();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "Clientes");
            cbxTecnico.ValueMember = "idClientes";
            cbxTecnico.DisplayMember = "CPF";
            cbxTecnico.DataSource = ds.Tables["Clientes"];
            cx.Desconectar();
            cbxTecnico.Text = null;
        }

        public void ListarClientesPorNome()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql += " Select Nome from Clientes";
            // sql += " Order by  Categoria ";
            cx.Conectar();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "Clientes");
            cboUsers.ValueMember = "idClientes";
            cboUsers.DisplayMember = "Nome";
            cboUsers.DataSource = ds.Tables["Clientes"];
            cx.Desconectar();
            cboUsers.Text = null;
            cboUsers.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboUsers.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboUsers.Text = "";
        }

        public void FormatarGridListar()
        {
            dgvLocal.AutoResizeColumns();
            //dgvLocal.Columns[0].Visible = false;
            dgvLocal.RowHeadersVisible = false;
            //dgvConsulta.Columns[1].Width = 80;
            dgvLocal.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLocal.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLocal.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLocal.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        }

        public void ConsultaCodigo()
        {
            dgvLocal.DataSource = null;
            consulta.Codigo = txtCodPeca.Text.ToString();
            consulta.consultarEstoque(lblCT.Text);

            if (consulta.Retorno == "ok")
            {
                txtDescPeca.Text = consulta.Descricao;
               // txtQntd.Select();
            }
            else
            {
                MessageBox.Show("CÓDIGO NÃO ENCONTRADO NO ESTOQUE!");
                LimparControles(this);
                txtCodPeca.Select();
            }

            //contar a qntd em estoque 
            int Estoque = 0;
            consulta.Codigo = txtCodPeca.Text.ToString();
            consulta.ContarEstoque(lblCT.Text);
            Estoque = consulta.Contagem;
            //contar a qntd já solicitada
            int Pedidos = 0;
            consulta.Codigo = txtCodPeca.Text.ToString();
            consulta.ContarEmPedidos(lblCT.Text);
            Pedidos = consulta.Contagem;

            txtDisponivel.Text = Convert.ToString(Estoque - Pedidos);

            /*
            if (txtUsuario.Text == "MAGAZINE") // SE FOR PARA O MAGAZINE, NÃO DESCONTA OS JÁ SOLICITADOS PELO PROPRIO MAGAZINE
            {
                txtDisponivel.Text = Convert.ToString(Estoque - Pedidos);
            }
            else
            {
                //contar a qntd pedida do magazine tmb
                int PedidosMagazine = 0;
                consulta.Codigo = txtCodPeca.Text.ToString();
                consulta.ContarEmPedidosMagazineSP();
                PedidosMagazine = consulta.Contagem;
                //subtrai as qntds para obter a disponibilidade real em estoque
                txtDisponivel.Text = Convert.ToString(Estoque - Pedidos - PedidosMagazine);
            }            
             */ 
        }

        public void ListarLocais()
        {
            if (Convert.ToInt32(txtDisponivel.Text) > 0)
            {
                string sql = "";
                sql += " Select Codigo, Quantidade, Posicao from Estoque where Codigo = '" + txtCodPeca.Text + "' and Posicao != 'PP' and Posicao not like '%KAM%' and Quantidade > '0' and CT = '" + lblCT.Text + "'";
                cx.Conectar();
                SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
                DataSet ds = new DataSet();
                da.Fill(ds, "Estoque");
                dgvLocal.DataSource = ds.Tables["Estoque"];
                cx.Desconectar();
            }
            else
            {
                MessageBox.Show("SEM SALDO SUFICIENTE");
            }
        }

        /*
        public void ListarPPMagazine()
        {
            if (Convert.ToInt32(txtDisponivel.Text) > 0)
            {
                string sql = "";
                sql += " Select Codigo, Quantidade, Posicao from Estoque where Codigo = '" + txtCodPeca.Text + "' and Chamado = '" + txtChamado.Text + "' and Quantidade > '0'";
                cx.Conectar();
                SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
                DataSet ds = new DataSet();
                da.Fill(ds, "Estoque");
                dgvLocal.DataSource = ds.Tables["Estoque"];
                cx.Desconectar();
            }
            else
            {
                MessageBox.Show("SEM SALDO SUFICIENTE");
            }
        }
         */ 
       

        // ======================= TXTCODPECA ================================
        // ===================================================================
        private void txtCodPeca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ConsultarPeca();   
            }
        }

        private void txtCodPeca_Leave(object sender, EventArgs e)
        {
            ConsultarPeca();            
        }

        public void ConsultarPeca()
        {
            if (cbxTecnico.Text.Length == 0)
            {
                MessageBox.Show("INFORME O " + lblInterExterno.Text + ".");
            }
            else if (txtCodPeca.Text.Length == 0)
            {
               // MessageBox.Show("CÓDIGO NÃO ENCONTRADO NO ESTOQUE!");
                LimparControles(this);               
            }
            else
            {
                if (txtCodPeca.Text.Length > 0)
                {
                    ConsultaCodigo();
                    if (txtCodPeca.Text.Length > 0)
                    {
                        ListarLocais();
                    }
                }
            }
        }

       
        // ===================================================================
        // ===================================================================

        public int qnt = 0;

        private void dgvLocal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvLocal.Columns[e.ColumnIndex].Name == "Posicao")
                {
                    string Pos = dgvLocal.Rows[e.RowIndex].Cells["Posicao"].Value.ToString();
                    qnt = Convert.ToInt32(dgvLocal.Rows[e.RowIndex].Cells["Quantidade"].Value.ToString());
                    txtPosicao.Text = Pos;
                    txtQntd.Select();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

      

        private void txtQntd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnConcluir.Select();
            }            
        }
    

        public void Concluir()
        {
            string Tecnico = cbxTecnico.Text;
           

            /* OBS.: RETIREI A VERIFICAÇÃO DE SEJÁ EXISTE A PEÇA PARA O TECNICO, POIS AGORA É GERADA UMA NF POR PEÇA, POR TANTO SEMPRE VAI INSERIR O COD A QNT E A NF
            // VERIFICA SE JA EXISTE A PEÇA PARA O TECNICO
            consulta.comando = "";
            consulta.comando += "Select * from Externo where Codigo = '" + txtCodPeca.Text + "' and Usuario = '" + Tecnico + "'";
            consulta.consultarSimNao();

            
            // PARTE QUE INSERE OU ATUALIZA A QUANTIDADE PARA O TECNICO
            if (consulta.Retorno == "ok")
            {
                consulta.comando = "";
                consulta.comando = "update Externo set Quantidade = Quantidade + '" + txtQntd.Text + "' where Usuario = '" + Tecnico + "' and Codigo = '" + txtCodPeca.Text + "'";
                consulta.Atualizar();
            }
             */ 
            //else
            //{
                try
                {
                    string sql = "";
                    sql += " Insert into SaidaEstoque (CT, Usuario, Codigo, Descricao, Quantidade, Tipo, Data, Hora, Cliente)";
                    sql += " Values ( ";
                    sql += " '" + lblCT.Text + "', ";
                    sql += " '" + Tecnico + "', ";
                    sql += " '" + txtCodPeca.Text + "', ";
                    sql += " '" + txtDescPeca.Text + "', ";
                    sql += " '" + txtQntd.Text + "', ";
                    sql += " '" + lblInterExterno.Text + "', ";
                    sql += " '" + consulta.dataNormal + "', ";
                    sql += " '" + consulta.hora + "', ";
                    sql += " '" + txtCliente.Text + "')";
                    cx.Conectar();
                    SqlCommand cd = new SqlCommand();
                    cd.Connection = cx.c;
                    cd.CommandText = sql;
                    cd.ExecuteNonQuery();
                    cx.Desconectar();
                }
                catch (SqlException x)
                {
                    MessageBox.Show("ERRO SEPARAR PEÇA PARA EXTERNO: \r\n" + x.Message);
                }
                cx.Desconectar();
            //}
           
        }


        public void LimparControles(Control parent)
        {
            dgvLocal.DataSource = null;
            foreach (Control cont in parent.Controls)
            {
                if (cont is TextBox)
                {
                    (cont as TextBox).Text = "";
                    cont.BackColor = ((TextBox)cont).ReadOnly
                       ? System.Drawing.SystemColors.Control
                       : System.Drawing.SystemColors.Window;
                }

                if (cont is MaskedTextBox)
                {
                    (cont as MaskedTextBox).Text = "";
                    cont.BackColor = ((MaskedTextBox)cont).ReadOnly
                       ? System.Drawing.SystemColors.Control
                       : System.Drawing.SystemColors.Window;
                }

                // if (cont is ComboBox) { (cont as ComboBox).Text = ""; }

                if (cont is DateTimePicker) { (cont as DateTimePicker).Text = ""; }

                if (cont is MaskedTextBox) { (cont as MaskedTextBox).Text = ""; }

                if (cont is RadioButton) { (cont as RadioButton).Checked = false; }

                if (cont is CheckBox) { (cont as CheckBox).Checked = false; }

                if (cont is CheckedListBox)
                {
                    foreach (ListControl item in (cont as CheckedListBox).Items)
                        item.SelectedIndex = -1;
                }

                if (cont is ListBox) { (cont as ListBox).Items.Clear(); }

                if (cont is ListView) { (cont as ListView).Items.Clear(); }

                // varre os filhos...
                this.LimparControles(cont);
            }
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DESEJA CONCLUIR?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                consulta.DataAtual();
                //=========================================================
                if (Convert.ToInt32(txtQntd.Text) <= 0)
                {
                    MessageBox.Show("QUANTIDADE INVALIDA.");
                }
                else if (Convert.ToInt32(txtQntd.Text) > qnt)
                {
                    MessageBox.Show("QUANTIDADE DESEJADA É INDISPONIVEL.");
                }                
                else
                {
                    /*
                    if (txtChamado.Text.Length > 0)
                    {
                        consulta.comando = "";
                        consulta.comando = "Delete from Estoque where Codigo = '" + txtCodPeca.Text + "' and Chamado = '" + txtChamado.Text + "'";
                        //MessageBox.Show(consultar.comando);
                        consulta.Atualizar();
                    }
                     */ 
                    //else
                    //{
                        consulta.comando = "";
                        consulta.comando = "update Estoque set Quantidade = Quantidade - '" + txtQntd.Text + "' where Codigo = '" + txtCodPeca.Text + "' and Posicao = '" + txtPosicao.Text + "' and CT = '" + lblCT.Text + "'";
                        consulta.Atualizar();

                   // }
                    if (consulta.Retorno == "ok")
                    {
                        Concluir();

                        /*
                        if (txtUsuario.Text == "MAGAZINE")
                        {
                            //=========================== SETAR CONCLUIDO NO BANCO MOVIMENTAÇÃO =================================
                            consulta.comando = "";
                            consulta.comando = "update MovimentacaoEstoque set Status = 'ATENDIDO', DataAtendimento = '" + consulta.dataCompleta + "', NF = '" + txtNF.Text + "' where idMovimentacao = '" + txtID.Text + "'";
                            consulta.Atualizar();
                            //===================================================================================================

                        }
                         */ 
                        MessageBox.Show("CONCLUIDO");
                        /*
                        if (txtUsuario.Text == "MAGAZINE")
                        {
                            this.Close();
                        }
                         */ 
                        
                        LimparControles(this);
                        txtCodPeca.Select();
                    }
                    else
                    {
                        MessageBox.Show("ERRO AO ATUALIZAR TABELA ESTOQUE");
                    }
                }
                //=========================================================                    
            }
        }

        private void chbPareCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPareCliente.Checked)
            {
                lblInterExterno.Text = "CLIENTE";
                cbxTecnico.DataSource = null;
                pnlCPF.Visible = true;
                txtCliente.Visible = true;                
                ListarClientes();
                ListarClientesPorNome();
                txtCliente.Text = "";
                txtBusca.Text = "";
                
            }
            else
            {
                lblInterExterno.Text = "TECNICO";
                cbxTecnico.DataSource = null;
                pnlCPF.Visible = false;
                txtCliente.Visible = false;
                txtCliente.Text = "";
                txtBusca.Text = "";
                ListarUsuarios();
            }
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            if (txtBusca.Text.Length == 0)
            {
                MessageBox.Show("INFORME O CPF DO CLIENTE.");
            }
            else
            {
                consulta.consultarClientes("CPF", txtBusca.Text);
                if (consulta.Retorno == "ok")
                {
                    cbxTecnico.Text = consulta.CPF;
                    txtBusca.Text = "";
                    cboUsers.Text = "";
                    
                }
                else
                {
                    if (MessageBox.Show("CLIENTE NÃO CADASTRADO.\r\n\r\nDESEJA CADASTRAR AGORA?", "PERGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmCadastrarClientes c = new frmCadastrarClientes(txtBusca.Text, lblCT.Text);
                        c.ShowDialog();
                        ListarClientes();
                        ListarClientesPorNome();
                    }
                    else
                    {
                        txtBusca.Text = "";
                    }

                }
            }
           
        }

        private void cbxTecnico_SelectedValueChanged(object sender, EventArgs e)
        {
            if (chbPareCliente.Checked)
            {                
                consulta.consultarClientes("CPF", cbxTecnico.Text);
                if (consulta.Retorno == "ok")
                {
                   txtCliente.Text = consulta.Nome;                                       
                }
            }
        }

        private void cboUsers_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboUsers.Text.Length > 0)
            {
                consulta.consultarClientes("Nome", cboUsers.Text);
                //txtCliente.Text = consulta.Nome;
                txtBusca.Text = consulta.CPF;
                //txtUserBloqueio.Text = consulta.Login;
            }    
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            plnEquivalencia.Visible = true;
        }

        private void lblBotao1_Click(object sender, EventArgs e)
        {
            plnEquivalencia.Visible = false;
            consulta.LimparControles(plnEquivalencia);
            dgvConsulta.DataSource = null;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            consultarEstoque();
        }

        public void consultarEstoque()
        {
            string sql = "";

            if ((txtParteDesc.Text.Length == 0) && (txtDescricao.Text.Length == 0))
            {
                sql = "";
                // sql = "select Codigo, Descricao, Barebone, sum(Quantidade)As Quantidade from Estoque E, BaseCodigo B where E.Codigo = B.Codigo and B.SKU = '%"+txtSKU.Text+ "%' and Descricao like '%xxzzyy%' and Barebone like '%xxzzyy%' group by Codigo, Descricao, Barebone ";

                sql = "select Codigo, Descricao, sum(Quantidade) As Quantidade from Estoque where Descricao like '%xxzzyy%' and Descricao like '%xxzzyy%' and CT = '" + lblCT.Text + "' group by Codigo, Descricao order by Quantidade";

                //sql = "select * FROM CheckListGeral WHERE TIPOEQUIP = '" + txtSKU.Text + "' ORDER BY ESPECIE";
                cx.Conectar();
                SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
                DataSet ds = new DataSet();
                da.Fill(ds, "Estoque");
                dgvConsulta.DataSource = ds.Tables["Estoque"];
                cx.Desconectar();
            }
            else
            {
                sql = "";
                // sql = "select Codigo, Descricao, Barebone, sum(Quantidade)As Quantidade from Estoque E, BaseCodigo B where E.Codigo = B.Codigo and B.SKU = '%"+txtSKU.Text+ "%' and Descricao like '%xxzzyy%' and Barebone like '%xxzzyy%' group by Codigo, Descricao, Barebone ";

                sql = "select Codigo, Descricao, sum(Quantidade) As Quantidade from Estoque where Descricao like '%" + txtDescricao.Text + "%' and Descricao like '%" + txtParteDesc.Text + "%' and CT = '" + lblCT.Text + "' group by Codigo, Descricao order by Quantidade";

                // sql = "select * FROM CheckListGeral WHERE TIPOEQUIP = '" + txtSKU.Text + "' AND ITEM like '%" + txtDescricao.Text + "%' and ITEM like '%" + txtParteDesc.Text + "%' ORDER BY ESPECIE";
                cx.Conectar();
                SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
                DataSet ds = new DataSet();
                da.Fill(ds, "Estoque");
                dgvConsulta.DataSource = ds.Tables["Estoque"];
                cx.Desconectar();
            }
        }

        private void dgvConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string Codigo = dgvConsulta.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                if (dgvConsulta.Columns[e.ColumnIndex].Name == "Codigo")
                {
                    txtCodPeca.Text = Codigo;
                    txtCodPeca.Select();
                    SendKeys.Send("{ENTER}");
                    plnEquivalencia.Visible = false;
                    consulta.LimparControles(plnEquivalencia);
                    dgvConsulta.DataSource = null;

                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox3, "ABRIR BUSCA DE PEÇA\r\nAPÓS A BUSCA CLICK 2X NO CODIGO PARA SELECIONAR ");
        }

        private void dgvConsulta_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //toolTip1.SetToolTip(pictureBox3, "DOIS CLICKS NO CÓDIGO PARA BUSCAR.");
        }




    }
}
