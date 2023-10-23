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
    public partial class frmReparoPPRecebido : Form
    {
        public frmReparoPPRecebido(string texto, string CT)
        {
            InitializeComponent();
            lblUsuario.Text = texto;
            lblCT.Text = CT;
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();

        private void frmReparoPPRecebido_Load(object sender, EventArgs e)
        {            
            ListarPP();
            FormatarGrid();
            FormatarGridPP();
        }

        public void FormatarGrid()
        {
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            Image imagem = pictureBox2.Image;
            img.Image = imagem;
            dgvAguardo.Columns.Add(img);
            img.HeaderText = "PESQUISAR";
            img.Name = "PESQUISAR";
            dgvAguardo.RowHeadersVisible = false;
            dgvAguardo.Columns["MODELO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // dgvConsulta.Columns[1].Width = 80;
        }

        public void FormatarGridPP()
        {
            dgvPP.RowHeadersVisible = false;
            dgvPP.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        public string Seguradora = "";
        public string LocalDeGuarda = "";
        /*
        public string Cod = "";
      //  public string OS = "";
        public string Des = "";
        public string idCod = "";
        public string Chamado = "";
         */ 

        public void ListarPP()
        {
            string sql = "";
            sql += "Select E.idCod, C.OS, C.NS, C.Descricao as MODELO, E.Chamado AS CHAMADO, DATEDIFF(DAY, DataEntrada, GETDATE()) as DNP, E.Codigo, E.Descricao, E.Posicao from Estoque E, Chamados C where (E.Posicao = 'PP' or E.Posicao = 'BACKUP') ";
            sql += "AND E.Chamado = C.OS and C.CT = '" + lblCT.Text + "' ";
            sql += "order By DNP desc ";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Estoque");
            dgvAguardo.DataSource = ds.Tables["Estoque"];
            cx.Desconectar();
            lblTotalPP.Text = dgvAguardo.Rows.Count.ToString();
        }

        public void BuscarPecasApontadas(string Chamado)
        {
            string sql = "";
            sql += " Select * from estoque where chamado = '" + Chamado + "' and CT = '" + lblCT.Text + "'";
            cx.ConectarSAP();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chamados");
            dgvPP.DataSource = ds.Tables["Chamados"];
            cx.Desconectar();

            /*
            string sql = "";
            sql += "select QPCT.KURZTEXT AS STAUTS, '' AS DISPONÍVEL, ";
            sql += "convert(numeric, QMMA.QMNUM) AS CHAMADO, ";
            sql += "convert(numeric, QMMA.MATNR) AS [PEÇA SOLICITADA], ";
            sql += "convert(numeric, QMMA.MATNR_NOVO) AS [PEÇA ENTREGE], ";
            sql += "MARA.MAKTX as DESCRICAO, '' as CodAntigo, '' as DescPecaAntiga ";
            sql += "from QMMA, QPCT, MARA ";
            sql += "where ";
            sql += "MARA.MATNR = QMMA.MATNR AND ";
            sql += "QPCT.CODE = QMMA.MNCOD and QPCT.CODEGRUPPE = QMMA.MNGRP ";
            sql += "and QPCT.KURZTEXT in ('PEÇA SOLICITADA', 'POSIC C/ PEDIDO DE PEÇAS FORA COMPOSIÇÃO', 'ORÇAMENTO', 'ORÇAMENTO APROVADO', 'ORÇAMENTO PAGO') ";
            sql += "AND QMMA.QMNUM = '0" + Chamado + "'";
            cx.ConectarSAP();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chamados");
            dgvPP.DataSource = ds.Tables["Chamados"];
            cx.Desconectar();
             */ 
        }

        public void BuscaBackUp(string Chamado)
        {
            string sql = "";
            sql += "SELECT Status, '' AS DISPONÍVEL, CHAMADO, '' AS [PEÇA SOLICITADA], Codigo AS [PEÇA ENTREGE], DESCRICAO FROM AGUARDOBACKUP WHERE Chamado = '" + Chamado + "' and CT = '" + lblCT.Text + "'";  
          //  sql += "Select 'SIM' AS DISPONÍVEL, * from estoque where chamado = '" + Chamado + "' ";
            cx.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, cx.c);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chamados");
            dgvPP.DataSource = ds.Tables["Chamados"];
            cx.Desconectar();
        }


        public void ChecarSePPRecebido2()
        {
            for (int i = 0; i < dgvPP.RowCount; i++)
            {
                string feedBack = "NÃO";
                try
                {
                    string Cham = dgvPP.Rows[i].Cells["CHAMADO"].Value.ToString();
                    string pecaEntregue = dgvPP.Rows[i].Cells["PEÇA ENTREGE"].Value.ToString();

                    string comando = "";
                    comando = "select * from Estoque where Chamado = '" + Cham + "' AND Codigo = '" + pecaEntregue + "' and Posicao = 'BACKUP' and CT = '" + lblCT.Text + "' ";
                    cx.Conectar();
                    SqlCommand cd = new SqlCommand();
                    cd.Connection = cx.c;
                    cd.CommandText = comando;
                    SqlDataReader dr = cd.ExecuteReader();
                    if (dr.Read())
                    {
                        feedBack = "SIM";
                    }
                    else
                    {
                        feedBack = "NÃO";
                    }
                    dgvPP.Rows[i].Cells["DISPONÍVEL"].Value = feedBack;                   
                    dr.Close();
                    cx.Desconectar();
                    
                }
                catch (Exception x)
                {
                    MessageBox.Show("oi, falhouu" + x.Message);
                    cx.Desconectar();
                }
            }
            
        }

        public void ChecarSePPRecebido()
        {
            for (int i = 0; i < dgvPP.RowCount; i++)
            {
                string feedBack = "NÃO";
                string CodAntigoteta = "";
                string DescPecaAntiga = "";
                try
                {
                    string Cham = dgvPP.Rows[i].Cells["CHAMADO"].Value.ToString();
                    string pecaSolicitada = dgvPP.Rows[i].Cells["PEÇA SOLICITADA"].Value.ToString();
                    string pecaEntregue = dgvPP.Rows[i].Cells["PEÇA ENTREGE"].Value.ToString();

                    string comando = "";
                    comando = "select * from PP where Chamado = '" + Cham + "' and CT = '" + lblCT.Text + "'";
                    cx.Conectar();
                    SqlCommand cd = new SqlCommand();
                    cd.Connection = cx.c;
                    cd.CommandText = comando;
                    SqlDataReader dr = cd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            CodAntigoteta = dr["CodAntigo"].ToString();
                            DescPecaAntiga = dr["DescPecaAntiga"].ToString();
                         
                            if (feedBack != "SIM")
                            {                                
                                string Codigo = dr["Codigo"].ToString();
                                // MessageBox.Show("Codigo pp = " + Codigo);
                                if (Codigo == pecaSolicitada || Codigo == pecaEntregue)
                                {
                                    feedBack = "SIM";
                                }
                                else
                                {
                                    if (feedBack != "SIM")
                                    {
                                        feedBack = "NÃO";
                                    }
                                }
                                //  MessageBox.Show("feedback = " + feedBack);
                            }
                        }
                        dgvPP.Rows[i].Cells["DISPONÍVEL"].Value = feedBack;
                        dgvPP.Rows[i].Cells["CodAntigo"].Value = CodAntigoteta;
                        dgvPP.Rows[i].Cells["DescPecaAntiga"].Value = DescPecaAntiga;
                       
                    }
                    dr.Close();
                    cx.Desconectar();
                }
                catch (Exception x)
                {
                    MessageBox.Show("oi, falhouu" + x.Message);                    
                    cx.Desconectar();
                }
            }
        }

        public void ChecarSeBACKUPRecebido()
        {
            string feedBack = "SIM";
            for (int i = 0; i < dgvPP.RowCount; i++)
            {
                try
                {
                    string Cham = dgvPP.Rows[i].Cells["CHAMADO"].Value.ToString();
                    string Status = dgvPP.Rows[i].Cells["Status"].Value.ToString();

                    if (Status == "PENDENTE")
                    {
                        feedBack = "NÃO";
                    }
                    dgvPP.Rows[i].Cells["DISPONÍVEL"].Value = feedBack;                   
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
        }

        public string Posicao = "";
        public string NS = "";
        private void dgvPP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seguradora = "";
            LocalDeGuarda = "";
            try
            {
                if (dgvAguardo.Columns[e.ColumnIndex].Name == "PESQUISAR")
                {
                    string Chamado = dgvAguardo.Rows[e.RowIndex].Cells["CHAMADO"].Value.ToString();
                //    string NS = dgvAguardo.Rows[e.RowIndex].Cells["NS"].Value.ToString();
                    Posicao = dgvAguardo.Rows[e.RowIndex].Cells["Posicao"].Value.ToString();
                    NS = dgvAguardo.Rows[e.RowIndex].Cells["NS"].Value.ToString();
                    if (MessageBox.Show("DESEJA VISUALIZAR PEÇAS? ", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                      //  Seguradora = dgvAguardo.Rows[e.RowIndex].Cells["Seguradora"].Value.ToString();
                      //  LocalDeGuarda = dgvAguardo.Rows[e.RowIndex].Cells["LocalDeGuarda"].Value.ToString();
                        //MessageBox.Show(Posicao);
                        lblChamado.Text = Chamado;
                        if (Posicao == "PP")
                        {
                            BuscarPecasApontadas(Chamado);
                            ChecarSePPRecebido2();
                        }
                        else
                        {
                            BuscaBackUp(Chamado);
                            //ChecarSeBACKUPRecebido2();
                            ChecarSePPRecebido2();
                        }
                        
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }


        /*
        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            if (dgvPP.RowCount > 0)
            {
                string Chamado = "";
                string feedBack = "SIM";
                for (int i = 0; i < dgvPP.RowCount; i++)
                {
                    Chamado = dgvPP.Rows[i].Cells["CHAMADO"].Value.ToString();
                    try
                    {
                        string Disponivel = dgvPP.Rows[i].Cells["DISPONÍVEL"].Value.ToString();
                        if (Disponivel != "SIM")
                        {
                            feedBack = "NÃO";
                            break;
                        }
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(x.Message);
                    }
                }
                if (feedBack == "SIM")
                {
                    // ============================= INICIA PEDIDOS DE PEÇAS =============================                   
                    for (int i = 0; i < dgvPP.RowCount; i++)
                    {
                        try
                        {
                            // ==========PREENCHE VARIAVEIS PARA CHAMAR O METODO =========================                            
                            string pecaPedida = dgvPP.Rows[i].Cells["PEÇA SOLICITADA"].Value.ToString();
                            string pecaEntregue = dgvPP.Rows[i].Cells["PEÇA ENTREGE"].Value.ToString();
                            string Descricao = dgvPP.Rows[i].Cells["DESCRICAO"].Value.ToString();
                            string Codigo = "";
                            if (pecaEntregue.Length > 0)
                            {
                                Codigo = pecaEntregue;
                            }
                            else
                            {
                                Codigo = pecaPedida;
                            }
                            // ========== FIM PREENCHE VARIAVEIS PARA CHAMAR O METODO ======================
                            //========================== CHAMA OS METODOS ==================================
                            //SolicitarPeca(Codigo, Descricao, Chamado);
                            SolicitarPeca(Codigo, Descricao, Chamado);
                            consulta.Retorno = "ok";
                            if (consulta.Retorno == "ok")
                            {
                                RetirarPPDoEstoque(Codigo, Chamado);
                            }
                            else
                            {
                                MessageBox.Show("FALHA AO INSERIR PEDIDO DA PEÇA: " + Codigo + "\r\n\r\nINFORMAR O SUPORTE");
                            }
                            //========================  FIM CHAMA OS METODOS =================================                            
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                        }
                    }
                    //====verifica se foi tudo ok e retira de pp e insere historico
                    consulta.Retorno = "ok";
                    if (consulta.Retorno == "ok")
                    {
                        //======Insere na tabela Historico==========================
                        string StatusHistorico = "SAIDAPP";
                        consulta.DataAtual();
                        consulta.InsereHistorico(Chamado, lblUsuario.Text, StatusHistorico, consulta.data, consulta.hora);
                        //=====fim da inserção======================================
                        consulta.comando = "";
                        consulta.comando = "update Chamados set Status = 'REPARO' where Chamado = '" + Chamado + "'";
                        consulta.Atualizar();
                        // MessageBox.Show(consulta.comando);

                        MessageBox.Show("SOLICITAÇÃO DE PEÇA CONCLUIDO.");
                        ListarPP();
                        dgvPP.DataSource = null;

                    }
                    // ==================================== FIM ===========================================
                }
                else
                {
                    MessageBox.Show("TODAS AS PEÇAS AINDA NÃO FORAM ENTREGUES");
                }
            }
            else
            {
                MessageBox.Show("SELECIONAR UM CHAMADO PRIMEIRO");
            }
        }
        */

        public void SolicitarPeca(string Cod, string Des, string Chamado)
        {
            consulta.DataAtual();
            string data = consulta.dataCompleta;
            consulta.comando = "";
            consulta.comando = "Insert into Pedidos (CT, Usuario, Codigo, Descricao, Quantidade, Status, HoraPedido, Situacao, NS, OS) Values ";
            consulta.comando += " ('" + lblCT.Text + "', '" + lblUsuario.Text + "', ";
            consulta.comando += " '" + Cod + "', ";
            consulta.comando += " '" + Des + "', ";
            consulta.comando += " '1', ";
            consulta.comando += "'PP-AGUARDANDO', ";
            consulta.comando += " '" + data + "', ";            
            consulta.comando += " '" + Posicao + "', ";
            consulta.comando += " '" + NS + "', ";
            consulta.comando += " '" + Chamado + "' )";
            consulta.Atualizar();
            //MessageBox.Show(consulta.comando);         
        }

        public void RetirarPPDoEstoque(string Codigo, string Chamado)
        {
            consulta.comando = "";
            consulta.comando = "Delete from Estoque where Codigo = '" + Codigo + "' and Chamado = '" + Chamado + "' and CT = '" + lblCT.Text + "'";
            consulta.Atualizar();
            //MessageBox.Show(consulta.comando);
        }

        private void btnSolicitar_Click_1(object sender, EventArgs e)
        {
            if (dgvPP.RowCount > 0)
            {
                string Chamado = "";
                string feedBack = "SIM";
                for (int i = 0; i < dgvPP.RowCount; i++)
                {
                    Chamado = dgvPP.Rows[i].Cells["CHAMADO"].Value.ToString();
                    try
                    {
                        string Disponivel = dgvPP.Rows[i].Cells["DISPONÍVEL"].Value.ToString();
                        if (Disponivel != "SIM")
                        {
                            feedBack = "NÃO";
                            break;
                        }
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(x.Message);
                    }
                }
                if (feedBack == "SIM")
                {
                    // ============================= INICIA PEDIDOS DE PEÇAS =============================                   
                    for (int i = 0; i < dgvPP.RowCount; i++)
                    {
                        try
                        {
                            // ==========PREENCHE VARIAVEIS PARA CHAMAR O METODO =========================                            
                            string pecaPedida = dgvPP.Rows[i].Cells["PEÇA SOLICITADA"].Value.ToString();
                            string pecaEntregue = dgvPP.Rows[i].Cells["PEÇA ENTREGE"].Value.ToString();
                            string Descricao = dgvPP.Rows[i].Cells["DESCRICAO"].Value.ToString();
                           // string CodAntigo = dgvPP.Rows[i].Cells["CodAntigo"].Value.ToString();
                           // string DescPecaAntiga = dgvPP.Rows[i].Cells["DescPecaAntiga"].Value.ToString();           
                            string Codigo = "";
                            if (pecaEntregue.Length > 0)
                            {
                                Codigo = pecaEntregue;
                            }
                            else
                            {
                                Codigo = pecaPedida;
                            }
                            // ========== FIM PREENCHE VARIAVEIS PARA CHAMAR O METODO ======================
                            //========================== CHAMA OS METODOS ==================================
                            SolicitarPeca(Codigo, Descricao, Chamado);
                            consulta.Retorno = "ok";
                            if (consulta.Retorno == "ok")
                            {
                                RetirarPPDoEstoque(Codigo, Chamado);
                            }
                            else
                            {
                                MessageBox.Show("FALHA AO INSERIR PEDIDO DA PEÇA: " + Codigo + "\r\n\r\nINFORMAR O SUPORTE");
                            }
                            //========================  FIM CHAMA OS METODOS =================================                            
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                        }
                    }
                    //====verifica se foi tudo ok e retira de pp e insere historico
                    consulta.Retorno = "ok";
                    if (consulta.Retorno == "ok")
                    {
                        //======Insere na tabela Historico==========================
                        string StatusHistorico = "";
                        if (Posicao == "AGUARDOBACKUP")
                        {
                            StatusHistorico = "SAIDAAGUARDO";
                        }                       
                        else
                        {
                            StatusHistorico = "SAIDAPP";
                        }
                         
                        consulta.DataAtual();
                        consulta.InsereHistorico(Chamado, lblUsuario.Text, StatusHistorico, consulta.dataNormal, consulta.hora, lblCT.Text);
                        //=====fim da inserção======================================
                        consulta.comando = "";
                        consulta.comando = "update Chamados set Status = 'REPARO' where OS = '" + Chamado + "' and CT = '" + lblCT.Text + "'";
                        consulta.Atualizar();
                        // MessageBox.Show(consulta.comando);

                        MessageBox.Show("SOLICITAÇÃO DE PEÇA CONCLUIDO.");
                       // if (Seguradora == "CIELO")
                       // {
                       //     MessageBox.Show("O EQUIPAMENTO ESTA NA CAIXA: " + LocalDeGuarda);
                       // }
                        Seguradora = "";
                        LocalDeGuarda = "";
                        ListarPP();
                        dgvPP.DataSource = null;
                    }
                    // ==================================== FIM ===========================================
                }
                else
                {
                    MessageBox.Show("TODAS AS PEÇAS AINDA NÃO FORAM ENTREGUES");
                }
            }
            else
            {
                MessageBox.Show("SELECIONAR UM CHAMADO PRIMEIRO");
            }
        }

        private void dgvAguardo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        



        /*

        public void Limpar()
        {
            Cod = "";
            //OS = "";
            Des = "";
            idCod = "";
            Chamado = "";
        }

        public void RetirarDoPP()
        {
            consulta.comando = "";
            consulta.comando = "Delete from Estoque where idCod in ( " + idCod + " )";
            //MessageBox.Show(consultar.comando);
            consulta.Atualizar();
        }

        

        public void RetirarAguardo()
        {
            //======Insere na tabela Historico==========================
            string StatusHistorico = "SAIDAPP";
            consulta.DataAtual();
            consulta.InsereHistorico(Chamado, lblUsuario.Text, StatusHistorico, consulta.data, consulta.hora);
            //=====fim da inserção======================================
           // consulta.DataAtual();
           // consulta.Coluna = "Chamado";
          //  consulta.ValorDesejado = Chamado;
          //  consulta.ConsultarChamado();
            consulta.comando = "";
            consulta.comando = "update Chamados set Status = 'AGUARDO' where Chamado = '" + Chamado + "'";
            consulta.Atualizar();
            //MessageBox.Show(consultar.comando);
            if (consulta.Retorno == "ok")
            {
                //MessageBox.Show("CONCLUIDO COM SUCESSO!");
                // ListarPP();
                // consultarOSPeloChamado();
                MessageBox.Show("CHAMADO " + Chamado + " ENVIADO PARA AGUARDO");
            }
            else
            {
                MessageBox.Show("FALHA AO RETIRAR DO AGUARDO");
            }
        }
         * 
         * 
         * 
        public void FormatarGridPP()
        {
            dgvAguardo.RowHeadersVisible = false;
            ListarPP();
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            Image imagem = pictureBox2.Image;
            img.Image = imagem;
            dgvAguardo.Columns.Add(img);
            img.HeaderText = "Solicita";
            img.Name = "Solicita";
            /*
            DataGridViewImageColumn img2 = new DataGridViewImageColumn();
            Image imagem2 = pictureBox3.Image;
            img2.Image = imagem2;
            dgvPP.Columns.Add(img2);
            img2.HeaderText = "Cancela";
            img2.Name = "Cancela";
             
        }

        */


    
    }
}
