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
using System.Deployment.Application;
using System.Drawing.Text;
using System.IO;
using System.Globalization;

namespace CRMagazine
{
    public partial class frmInicial : Form
    {
        public frmInicial()
        {
            InitializeComponent();
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                lblVersao.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            else
            {
                //lblVersao.Text = "Teste";
                lblVersao.Text = "1.0.0.44";
            }
        }

        Conexao cx = new Conexao();
        Consulta consulta = new Consulta();

        private void eNTRADAToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            //frmEntrada c = new frmEntrada();
            //c.Show();
        }

        private void rEPAROToolStripMenuItem_Click(object sender, EventArgs e)
        {            
                     
        }

        private void eXPEDIÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmExpedicao c = new frmExpedicao();
           // c.Show();
        }

        private void eQUIPAMENTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaEquipamento c = new frmConsultaEquipamento(lblCT.Text);
           c.Show();
        }

        public void ConferirLogar()
        {
            consulta.Usuario = txtUsuario.Text;
            consulta.consultarUsuario(txtUsuario.Text, "");
        }

        string Versao = "";
        public void ConferirVersao()
        {
            consulta.Usuario = "Master";
            consulta.consultarUsuario("Master", "");
            Versao = consulta.Versao;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ConferirVersao();
            ConferirLogar();
            if (consulta.Retorno == "falha")
            {
                MessageBox.Show("Usuario não Cadastrado");
            }
            else if (consulta.Senha != txtSenha.Text)
            {
                MessageBox.Show("Senha Errada!");
            }
            else if (Versao != lblVersao.Text)
          //else if (Versao != lblVersao.Text && lblVersao.Text != "Teste")
            {
                MessageBox.Show("Versão Desatualizada.\r\nAtualize o programa.");
            }
            else
            {
                txtUsuario.Enabled = false;
                pnlSenha.Visible = false;
                lblCT.Text = consulta.CT;
                if (consulta.Entrada == "yes")
                {
                    eNTRADAToolStripMenuItem.Enabled = true;
                }
                if (consulta.Vistoria == "yes")
                {
                    vISTORIAToolStripMenuItem.Enabled = true;
                }
                if (consulta.Reparo == "yes")
                {
                    rEPAROToolStripMenuItem.Enabled = true;
                }
                if (consulta.Runin == "yes")
                {
                    rUNINToolStripMenuItem.Enabled = true;
                }
                if (consulta.Embalagem == "yes")
                {
                    eMBALAGEMToolStripMenuItem.Enabled = true;
                }
                if (consulta.Expedicao == "yes")
                {
                    eXPEDIÇÃOToolStripMenuItem.Enabled = true;
                }
                if (consulta.Consultas == "yes")
                {
                    cONSULTASToolStripMenuItem.Enabled = true;
                }
                if (consulta.Ajuste == "yes")
                {
                    aJUSTEToolStripMenuItem.Enabled = true;                    
                }
                if (consulta.ADM == "yes")
                {
                    aDMToolStripMenuItem.Enabled = true;
                }
                if (consulta.Estoque == "yes")
                {
                    eSTOQUEToolStripMenuItem.Enabled = true;                    
                }
                if (consulta.Assist == "yes")
                {
                    aSSISTToolStripMenuItem.Enabled = true;
                }
                if (consulta.Morfar == "yes")
                {
                    chbMudarATP.Visible = true;
                }
                lblBemVindo.Text = "BEM VINDO " + txtUsuario.Text;
            }
        }

        private void frmInicial_Load(object sender, EventArgs e)
        {

        }

        private void sAIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlSenha.Visible = true;
            txtUsuario.Enabled = true;
            eNTRADAToolStripMenuItem.Enabled = false;
            vISTORIAToolStripMenuItem.Enabled = false;
            rEPAROToolStripMenuItem.Enabled = false;
            rUNINToolStripMenuItem.Enabled = false;
            eMBALAGEMToolStripMenuItem.Enabled = false;
            eXPEDIÇÃOToolStripMenuItem.Enabled = false;
            cONSULTASToolStripMenuItem.Enabled = false;
            aJUSTEToolStripMenuItem.Enabled = false;
            aDMToolStripMenuItem.Enabled = false;
            eSTOQUEToolStripMenuItem.Enabled = false;
            aSSISTToolStripMenuItem.Enabled = false;
            txtUsuario.Text = "";
            txtSenha.Text = "";
            lblBemVindo.Text = "";
            pnlMorfar.Visible = false;
            chbMudarATP.Visible = false;
            lblCT.Text = "";
            lblFilial.Text = "";
            for (int intIndex = Application.OpenForms.Count - 1; intIndex >= 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
        }

        private void vISTORIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void rUNINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmRunin c = new frmRunin(txtUsuario.Text);
           // c.Show();
        }

        private void eMBALAGEMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void pRÉENTRADAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVistoria c = new frmVistoria(txtUsuario.Text, lblCT.Text);
            c.Show();
        }

        private void rEPAROToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReparo c = new frmReparo(txtUsuario.Text,"", lblCT.Text);
            c.Show();
        }

        private void hIGIENIZAÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHigienizacao c = new frmHigienizacao(txtUsuario.Text, lblCT.Text);
            c.Show();
        }

        private void eNTRADAToolStripMenuItem2_Click(object sender, EventArgs e)
        {
           // frmEstoqueNovaEntrada c = new frmEstoqueNovaEntrada();
            frmEstoqueEntrada c = new frmEstoqueEntrada(lblCT.Text);
            c.Show();
        }

        private void aBERTURADECHAMADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            old_frmAberturaChamados c = new old_frmAberturaChamados();
            c.Show();
        }

        private void uSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInserirUsuario c = new frmInserirUsuario(lblCT.Text);
            c.Show();
        }

        private void lblBemVindo_Click(object sender, EventArgs e)
        {
            frmTrocarSenha c = new frmTrocarSenha(txtSenha.Text, txtUsuario.Text, lblCT.Text);
            c.ShowDialog();
        }

        private void sOLICITARPECAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmReparoSolicitarPecasPP c = new frmReparoSolicitarPecasPP(txtUsuario.Text,"","","","NORMAL");
            frmEstoqueSolicitarPecasInterno c = new frmEstoqueSolicitarPecasInterno(txtUsuario.Text, "", "", "", "NORMAL", lblCT.Text);
            c.Show();
        }

        private void tÉCNICAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaTecnica c = new frmConsultaTecnica(lblCT.Text);
            c.Show();
        }

        private void pEDIRPEÇASSPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //old_frmEstoqueSolicitarPecasSAOPAULO c = new old_frmEstoqueSolicitarPecasSAOPAULO("","2","","","");
            //c.Show();
        }

        private void eXPEDIÇÃOToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmExpedicaoExpedicao c = new frmExpedicaoExpedicao(txtUsuario.Text, lblCT.Text);
            c.Show();
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnOK.PerformClick();
            }
        }

        private void cRIARETIQUETAEANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            old_frmAjustesCriarEAN c = new old_frmAjustesCriarEAN();
            c.Show();
        }

        private void rETIRARDEPPSEMPEÇAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAjusteRetirarDePP c = new frmAjusteRetirarDePP(txtUsuario.Text, lblCT.Text);
            c.Show();
        }

        private void iMPRESSÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // old_frmEtiquetas c = new old_frmEtiquetas();
           // c.Show();
        }

        private void mOVIMENTAÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueMovimentacao c = new frmEstoqueMovimentacao(lblCT.Text);
            c.Show();
        }

        private void pAINELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoquePainelPedidos c = new frmEstoquePainelPedidos(lblCT.Text);
            c.Show();
        }

        private void eNTREGAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueRecebeProducao c = new frmEstoqueRecebeProducao(lblCT.Text);
            c.Show();
        }

        private void cONSULTARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueConsultas c = new frmEstoqueConsultas(lblCT.Text);
            c.Show();
        }

        private void pEÇASRMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueConfereRMA c = new frmEstoqueConfereRMA(lblCT.Text);
            c.Show();
        }

        private void rETORNOPEÇASBOASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueConferePecaBoa c = new frmEstoqueConferePecaBoa(lblCT.Text);
            c.Show();
        }

        private void sOLICITARPEÇASPToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // old_frmEstoqueSolicitarPecasSAOPAULO c = new old_frmEstoqueSolicitarPecasSAOPAULO("","2","","","");
           // c.Show();
        }

        private void rMAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eNTRADAPEÇASSPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            old_frmEstoqueEntregaPecaSP c = new old_frmEstoqueEntregaPecaSP();
            c.Show();
        }

        private void hISTORICOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaHistorico c = new frmConsultaHistorico(lblCT.Text);
            c.Show();
        }

        private void pAINELGERALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPainelGeral c = new frmPainelGeral(lblCT.Text);
            c.Show();
        }

        private void pRODUTIVIDADEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cONSULTARAGUARDOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReparoChamadoemPP c = new frmReparoChamadoemPP(txtUsuario.Text, lblCT.Text);
            c.Show();
        }

        private void cONCLUSÃOASSISTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            old_frmAssistEncerrar c = new old_frmAssistEncerrar(txtUsuario.Text);
            c.Show();
        }

        private void iNSERIRPRODUTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInserirModelo c = new frmInserirModelo(lblCT.Text);
            c.Show();
        }

        private void lOCALIZADORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalizador c = new frmLocalizador(lblCT.Text);
            c.Show();
        }

        private void aLTERAREXCLUIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlterarBanco c = new frmAlterarBanco(lblCT.Text);
            c.Show();
        }

        private void sUBIRPLANILHAA1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAjustesConferirPlanilhaA1 c = new frmAjustesConferirPlanilhaA1(lblCT.Text);
            c.Show();
        }

        private void iNSERIRCHECKLISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInserirChekListVistoria c = new frmInserirChekListVistoria(lblCT.Text);
            c.Show();
        }

        private void iNSERIRCHECKLISTVISTORIAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pEÇASDERETORNOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueConferePecaBoa c = new frmEstoqueConferePecaBoa(lblCT.Text);
            c.Show();
        }

        private void aJUSTEDEESTOQUEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dEVOLUÇÃOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProcessosDevolucao c = new frmProcessosDevolucao(txtUsuario.Text, lblCT.Text);
            c.Show();
        }

        private void sUBIRPLANILHADECÓDIGOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmADMSubirPrecoEmMassa c = new frmADMSubirPrecoEmMassa(lblCT.Text);
            c.Show();
        }

        private void cADASTROREPAROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReparoLancarRapido c = new frmReparoLancarRapido(lblCT.Text);
            c.Show();
        }

        private void eNDEREÇAMENTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProcessosEnderecamento c = new frmProcessosEnderecamento(txtUsuario.Text,"", lblCT.Text);
            c.Show();
        }

        private void eNDEREÇAMENTOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProcessosEnderecamento c = new frmProcessosEnderecamento(txtUsuario.Text,"", lblCT.Text);
            c.Show();
        }

        private void eNTRADANOTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEntradaDeNotas c = new frmEntradaDeNotas(lblCT.Text);
            c.Show();
        }

        private void lANÇARNFSAIDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpedicaoPlanilhaNotaFiscal c = new frmExpedicaoPlanilhaNotaFiscal(lblCT.Text);
            c.Show();
        }

        private void rEIMPRIMIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImprimirEtqEntrada c = new frmImprimirEtqEntrada(lblCT.Text);
            c.Show();
        }

        private void iMPRIMIREANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImprimirEAN c = new frmImprimirEAN(lblCT.Text);
            c.Show();
        }

        private void iNVENTARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("INFORME A SENHA PARA PROCEGUIR.");
            frmSenha novaForm = new frmSenha("SENHA", "INFORME A SENHA", lblCT.Text);
            novaForm.ShowDialog();
            string Senha = novaForm.TextoTeste;
            consulta.ConferirLogar();
            if (Senha == consulta.senha)
            {
                frmEstoqueInventario c = new frmEstoqueInventario(lblCT.Text);
                c.Show();
            }
        }

        private void eNTRADAPORNOTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueNovaEntrada c = new frmEstoqueNovaEntrada(lblCT.Text);
            c.Show();
        }

        private void eNTRADAAVULSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueEntradaAvulsa c = new frmEstoqueEntradaAvulsa(lblCT.Text);
            c.Show();
        }

        private void sAÍDADEPEÇAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueRetiradaAvulsa c = new frmEstoqueRetiradaAvulsa(lblCT.Text);
            c.Show();
        }

        private void lANÇARPRODUÇÃOAVULSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReparoLacarProdutoMontado c = new frmReparoLacarProdutoMontado(lblCT.Text);
            c.Show();
        }

        private void cADASTRODECLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarClientes c = new frmCadastrarClientes("", lblCT.Text);
            c.Show();
        }

        private void cONSULTAPEÇASToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEstoqueSolicitarPecasInterno c = new frmEstoqueSolicitarPecasInterno(txtUsuario.Text, "", "", "", "NORMAL", lblCT.Text);
            c.Show();
        }

        private void sAÍDANFPORCÓDIGOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpedicaoDevolucaoEmMassa c = new frmExpedicaoDevolucaoEmMassa(lblCT.Text);
            c.Show();
        }

        private void aJUSTEDENFSAÍDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmADMAjustarNFSaida c = new frmADMAjustarNFSaida(lblCT.Text);
            c.Show();
        }

        private void lblCT_TextChanged(object sender, EventArgs e)
        {
            consulta.comando = "SELECT NOME as Quantidade FROM CADASTRO_CT WHERE CT = '" + lblCT.Text + "' ";
            consulta.consultarSimNao();
            lblFilial.Text = consulta.qntNaPosicao;
        }

        private void lblFilial_Click(object sender, EventArgs e)
        {

        }

        private void chbMudarATP_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMudarATP.Checked)
            {
                if (MessageBox.Show("DESEJA MUDAR DE ATP?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmSenha novaForm = new frmSenha("SENHA", "INFORME A SENHA", lblCT.Text);
                    novaForm.ShowDialog();
                    string Senha = novaForm.TextoTeste;
                    consulta.ConferirLogar();
                    if (Senha == consulta.senha)
                    {
                        for (int intIndex = Application.OpenForms.Count - 1; intIndex >= 0; intIndex--)
                        {
                            if (Application.OpenForms[intIndex] != this)
                                Application.OpenForms[intIndex].Close();
                        }
                        pnlMorfar.Visible = true;
                        cboCT.Text = "";
                        chbMudarATP.Checked = false;
                        ListarCT();
                    }
                    else
                    {
                        MessageBox.Show("SENHA ERRADA.");
                        pnlMorfar.Visible = false;
                        chbMudarATP.Checked = false;
                    }
                }
            }
        }

        public void ListarCT()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string sql = "";
            sql += " Select CT from Cadastro_CT ";
            // sql += " Order by  Categoria ";
            cx.Conectar();
            da = new SqlDataAdapter(sql, cx.c);
            da.Fill(ds, "Cadastro_CT");
            cboCT.ValueMember = "idCT";
            cboCT.DisplayMember = "CT";
            cboCT.DataSource = ds.Tables["Cadastro_CT"];
            cx.Desconectar();
            cboCT.Text = "";
        }

        private void btnMudar_Click(object sender, EventArgs e)
        {
            if (cboCT.Text != "")
            {
                lblCT.Text = cboCT.Text;
                pnlMorfar.Visible = false;
            }
        }

        private void lANÇARREGISTROSAIDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpedicaoLancarRegistro c = new frmExpedicaoLancarRegistro(lblCT.Text, txtUsuario.Text);
            c.Show();
        }

        /*
        private void tÉCNICAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaTecnica c = new frmConsultaTecnica();
            c.Show();
        }

        private void eXPEDIÇÃOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaExpedicao c = new frmConsultaExpedicao();
            c.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desenvolvido por: \nLucas Marques Botan", "Sobre o SoftWare");         
        }

        private void llbTrocarSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTrocarSenha c = new frmTrocarSenha(txtSenha.Text, txtUsuario.Text);
            c.Show();
        }

        private void lblBemVindo_Click(object sender, EventArgs e)
        {
            frmTrocarSenha c = new frmTrocarSenha(txtSenha.Text, txtUsuario.Text);
            c.Show();
        }

        private void aJUSTEDEOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrocaDeOS c = new frmTrocaDeOS(txtUsuario.Text);
            c.Show();
        }

        private void iNSERIRMODELOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInserirModelo c = new frmInserirModelo();
            c.Show();
        }

        private void aLTERAREXCLUIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlterarBanco c = new frmAlterarBanco();
            c.Show();
        }

        private void cONSULTAVISTORIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaVistoria c = new frmConsultaVistoria(txtUsuario.Text);
            c.Show();
        }

        private void vISTORIAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVistoria c = new frmVistoria(txtUsuario.Text);
            //frmNovaVistoria c = new frmNovaVistoria(txtUsuario.Text);
            c.Show();
        }

        private void aBERTURADECHAMADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAberturaChamados c = new frmAberturaChamados();
            c.Show();
        }

        private void gERENCIALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultasGerenciais c = new frmConsultasGerenciais();
            c.Show();
        }

        private void pRÉENTRADAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPreEntrada c = new frmPreEntrada(txtUsuario.Text);
            c.Show();
        }

        private void eNTRADAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEntrada c = new frmEntrada(txtUsuario.Text);
            c.Show();
        }

        private void lOGRESTAURAÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRestauracao c = new frmRestauracao(txtUsuario.Text);
            c.Show();
        }

        private void dEVOLUÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDevolucao c = new frmDevolucao(txtUsuario.Text);
            c.Show();
        }

        private void eXPEDIÇÃOToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmExpedicao c = new frmExpedicao(txtUsuario.Text);
            c.Show();
        }

        private void pAINELPROCESSOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatorioPosto c = new frmRelatorioPosto();
            c.Show();
        }

        private void lOCALIZADORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalizador c = new frmLocalizador();
            c.Show();
        }

        private void eMBALAGEMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEmbalagem c = new frmEmbalagem(txtUsuario.Text);
            c.Show();
        }

        private void hIGIENIZAÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHigienizacao c = new frmHigienizacao(txtUsuario.Text);
            c.Show();
        }

        private void pRODUTIVIDADEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProdutividade c = new frmProdutividade();
            c.Show();
        }

        private void iNSERIRUSUARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInserirUsuario c = new frmInserirUsuario();
            c.Show();
        }

        private void qUALIDADEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQualidade c = new frmQualidade(txtUsuario.Text);
            c.Show();
        }

        private void iNSERIRKITSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInserirKit c = new frmInserirKit();
            c.Show();
        }

        private void oRÇAMENTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRetirarDeAprovacao c = new frmRetirarDeAprovacao(txtUsuario.Text);
            c.Show();
        }

        private void iMPRESSÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEtiquetas c = new frmEtiquetas();
            c.Show();
        }

        private void fINALIZARASSISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAssistFinalizarAssist c = new frmAssistFinalizarAssist();
            c.Show();
        }

        private void rEPAROToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTecnica c = new frmTecnica(txtUsuario.Text);
            c.Show();  
        }

        private void aGUARDOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAguardoPecas c = new frmAguardoPecas(txtUsuario.Text, "");
            c.Show();
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            txtUsuario.Text = txtUsuario.Text.Trim();            
        }

        private void cONSULTARAGUARDOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarAguardo c = new frmConsultarAguardo(txtUsuario.Text);
            c.Show();
        }

        private void sUBIREMMASSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubirEmMassa c = new frmSubirEmMassa();
            c.Show();
        }

        private void cONFERIRCELULARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConferirCelular c = new frmConferirCelular();
            c.Show();
        }

        private void cONSULTAKITSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMontagemKits c = new frmMontagemKits();
            c.Show();
        }

        private void eNTRADAToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmEstoqueEntrada c = new frmEstoqueEntrada();
            c.Show();
        }

        private void pAINELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoquePainelPedidos c = new frmEstoquePainelPedidos();
            c.Show();
        }

        private void sOLICITARPECAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueSolicitarPecas c = new frmEstoqueSolicitarPecas(txtUsuario.Text, OS, Barebone, Chamado);
            c.Show();
        }

        private void eNTREGAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueEntrega c = new frmEstoqueEntrega();
            c.Show();
        }

        private void mOVIMENTAÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueMovimentacao c = new frmEstoqueMovimentacao();
            c.Show();
        }

        public string OS = "";
        public string Barebone = "";
        public string Chamado = "";
        private void sOLICITARPEÇASToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEstoqueSolicitarPecas c = new frmEstoqueSolicitarPecas(txtUsuario.Text, OS, Barebone, Chamado);
            c.Show();
        }

        private void sOLICITARPEÇASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueSolicitarPecas c = new frmEstoqueSolicitarPecas(txtUsuario.Text, OS, Barebone, Chamado);
            c.Show();
        }

        private void cONSULTARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueConsultas c = new frmEstoqueConsultas();
            c.Show();
        }

        private void cADASTRODEMATERIAISToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueCadastrodeMateriais c = new frmEstoqueCadastrodeMateriais();
            c.Show();
        }

        private void aJUSTEDEESTOQUEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueAjustar c = new frmEstoqueAjustar();
            c.Show();
        }

        private void aSSISTLINHAAZULToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void aGUARDOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAguardoEmbalagem c = new frmAguardoEmbalagem(txtUsuario.Text);
            c.Show();
        }

        private void rETIRARAGUARDOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRetirarAguardoEmbalagem c = new frmRetirarAguardoEmbalagem(txtUsuario.Text);
            c.Show();
        }

        private void cONSULTARPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarPP c = new frmConsultarPP(txtUsuario.Text);
            c.Show();
        }

        private void rUNINToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRunin c = new frmRunin(txtUsuario.Text);
            c.Show();
        }

        private void rETORNOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRuninRetorno c = new frmRuninRetorno(txtUsuario.Text);
            c.Show();
        }        

        private void bLOQUEAROSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBloquearOS c = new frmBloquearOS(txtUsuario.Text);
            c.Show();
        }

        private void pAINELHIGIENIZAÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPainelHigienizacao c = new frmPainelHigienizacao();
            c.Show();
        }

        private void pAINELCELULARHIGIENIZAÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPainelSLACelularHigienizacao c = new frmPainelSLACelularHigienizacao();
            c.Show();
        }

        private void pAINELDEPROCESSOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatorioPosto c = new frmRelatorioPosto();
            c.Show();
        }

        private void pAINELTECNICAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPainelSLATecnica c = new frmPainelSLATecnica();
            c.Show();
        }

        private void pAINELHIGIENIZAÇÃOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPainelHigienizacao c = new frmPainelHigienizacao();
            c.Show();
        }

        private void pAINELCELULARHIGIENIZAÇÃOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPainelSLACelularHigienizacao c = new frmPainelSLACelularHigienizacao();
            c.Show();
        }
         

        private void pAINELRUNINToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPainelSLARunin c = new frmPainelSLARunin();
            c.Show();
        }

        private void pAINELVISTORIAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPainelSLAVistoria c = new frmPainelSLAVistoria();
            c.Show();
        }

        private void iNSERIRBAREBONEToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void aJUSTEDEESTOQUEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEstoqueAjustar c = new frmEstoqueAjustar();
            c.Show();
        }

        private void iNSERIRBAREBONEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEstoqueInserirBarebone c = new frmEstoqueInserirBarebone();
            c.Show();
        }

        private void iNSERIRNFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEntradaDeNotas c = new frmEntradaDeNotas();
            c.Show();
        }

        private void cONSULTAHISTORICOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaSAP c = new frmConsultaSAP();
            c.Show();
        }

        private void pAINELEMBALAGEMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPainelSLAEmbalagem c = new frmPainelSLAEmbalagem();
            c.Show();
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnOK.PerformClick();
            }
        }

        private void hISTORICOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaHistorico c = new frmConsultaHistorico();
            c.Show();
        }

        private void cONCLUSÃOASSISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void eNTRADAPORNOTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueNovaEntrada c = new frmEstoqueNovaEntrada();
            c.Show();
        }

        private void pAINELAGPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoquePainelAGP c = new frmEstoquePainelAGP();
            c.Show();
        }

        private void pAINELDEPROCESSO2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatorioPosto2 c = new frmRelatorioPosto2();
            c.Show();
        }

        private void sEPARARPRODUÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSepararPorTecnico c = new frmSepararPorTecnico();
            c.Show();
        }

        private void oRÇAMENTOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaVistoria c = new frmConsultaVistoria(txtUsuario.Text);
            c.Show();
        }

        private void aPROVAÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRetirarDeAprovacao c = new frmRetirarDeAprovacao(txtUsuario.Text);
            c.Show();           
        }

        private void aBERTURACHAMADOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void aBERTURADECHAMADOSToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAberturaChamados c = new frmAberturaChamados();
            c.Show();
        }

        private void aSSISTLINHAAZULToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAssistLinhaAzul c = new frmAssistLinhaAzul();
            c.Show();
        }

        private void cONCLUSÃOASSISTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAssistFinalizarAssistPorTecnico c = new frmAssistFinalizarAssistPorTecnico(txtUsuario.Text);
            c.Show();
        }

        private void rMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueRMA c = new frmEstoqueRMA(txtUsuario.Text);
            c.Show();
        }

        private void lOTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueLotes c = new frmEstoqueLotes();
            c.Show();
        }

        private void cONSULTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueConsultaNota c = new frmEstoqueConsultaNota();
            c.Show();
        }

        private void rUNINoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRunin c = new frmRunin(txtUsuario.Text);
            c.Show();
        }

        private void rETORNORUNINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRuninRetorno c = new frmRuninRetorno(txtUsuario.Text);
            c.Show();
        }

        private void dEVOLUÇÃOToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDevolucao c = new frmDevolucao(txtUsuario.Text);
            c.Show();
        }

        private void eMBALAGEMToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmEmbalagem c = new frmEmbalagem(txtUsuario.Text);
            c.Show();
        }

        private void aGUARDOToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmAguardoEmbalagem c = new frmAguardoEmbalagem(txtUsuario.Text);
            c.Show();
        }

        private void rETIRARAGUARDOToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmRetirarAguardoEmbalagem c = new frmRetirarAguardoEmbalagem(txtUsuario.Text);
            c.Show();
        }

        private void sOLICITAPEÇAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRetirarAguardoEmbalagem c = new frmRetirarAguardoEmbalagem(txtUsuario.Text);
            c.Show();
        }

        private void qUALIDADEToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmQualidade c = new frmQualidade(txtUsuario.Text);
            c.Show();
        }

        private void pEÇASRMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueConfereRMA c = new frmEstoqueConfereRMA();
            c.Show();
        }

        private void rETORNOPEÇASBOASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueConferePecaBoa c = new frmEstoqueConferePecaBoa();
            c.Show();
        }

        private void cONSULTACHAMADOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAssistConsulta c = new frmAssistConsulta();
            c.Show();
        }

        private void cONSULTANOTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAssistConsultaNotas c = new frmAssistConsultaNotas();
            c.Show();
        }

        private void aLTERARCLASSIFICAÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAjustesAlterarClassificacao c = new frmAjustesAlterarClassificacao(txtUsuario.Text);
            c.Show();
        }

        private void eNCERRARASSISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAssistEncerrar c = new frmAssistEncerrar();
            c.Show();
        }

        private void mONITORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVistoriaMonitores c = new frmVistoriaMonitores(txtUsuario.Text);
            c.Show();
        }

        private void mONITORESToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaMonitores c = new frmConsultaMonitores();
            c.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void cRIARETIQUETAEANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAjustesCriarEAN c = new frmAjustesCriarEAN();
            c.Show();
        }

        private void pAINELGERALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPainelGeral c = new frmPainelGeral();
            c.Show();
        }

        private void aJUSTEDEOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTrocaDeOS c = new frmTrocaDeOS(txtUsuario.Text);
            c.Show();
        }

        private void iNSERIRMODELOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInserirModelo c = new frmInserirModelo();
            c.Show();
        }

        private void sUBIRPREÇOSEMMASSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubirEmMassa c = new frmSubirEmMassa();
            c.Show();
        }

        private void uSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInserirUsuario c = new frmInserirUsuario();
            c.Show();
        }

        private void aJUSTEDEESTOQUEToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmEstoqueAjustar c = new frmEstoqueAjustar();
            c.Show();
        }

        private void aLTERAREXCLUIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlterarBanco c = new frmAlterarBanco();
            c.Show();
        }

        private void nOVAVISTORIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVistoria c = new frmVistoria(txtUsuario.Text);
            c.Show();
        }

        private void iNSERIRCHECKLISTVISTORIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInserirChekListVistoria c = new frmInserirChekListVistoria();          
            c.Show();
        }

        private void lToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConferirCelular c = new frmConferirCelular();
            c.Show();
        }
        */




    }
}
