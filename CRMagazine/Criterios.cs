using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Media;
using System.IO;

namespace CRMagazine
{
    class Criterios
    {
        public string tempotroca = "";
        public string tempotriagem = "";
        public string motivo = "";
        public string garantia = "";
        public string estadoequipamento = "";
        public string acessorios = "";
        public string retencao = "";
        public string semdocumento = "";
        public string flag = "";
        public string Classificacao = "";
        public string ForaGarantia = "";
        public int diaParaOrcamento = 0;
        public int prazoTroca = 0;



        // LOGICA MAGAZINE LUIZA =================================
        public void MagazineLojaFisica()
        {
            if ((retencao.Length > 0))
            {
                if (retencao.Contains("SALDO-A"))
                {
                    Classificacao = "SALDO-A";
                }
                else
                {
                    Classificacao = "SALDO";
                }                               
            }
            else if ((Convert.ToInt32(garantia) > 15) ||        //MAIS DE 15 MESES DA DATA DO FATURAMENTO     
               (ForaGarantia == "ForaGarantia"))         //APRESENTA MAU USO OU OBSOLETO                             
            {
                //messageBox.Show("FORA DE GARANTIA");
                Classificacao = "FORA DE GARANTIA";
            }
            //=====
            else if ((semdocumento != "SIM") &&                 //RADIO BUTTON SEM DOCUMENTO NÃO ESTAJA MARCADO
               (Convert.ToInt32(tempotroca) <= 4) &&           //TEMPO TROCA <= Q 4 DIAS
               (Convert.ToInt32(tempotriagem) <= 90) &&         //TEMPO TRIAGEM <= 90 DIAS
               (motivo != "SEM DEFEITO") &&                           //COM FUNCIONAL
               (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
               (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
               (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("DEVOLUÇÃO DE VENDA - DOA");
                //Classificacao = "DEVOLUÇÃO DE VENDA - DOA";
                Classificacao = "REPARO FUNCIONAL - GARANTIA"; // alteado conforme reunião realizada em 08/06/2018 no Magazine. (não tem DOA, a não ser para feature)               

            }
            //======
            else if ((flag == "MaisDe30Dias") &&               //FLEGADO MAIS DE 30            
              (motivo != "SEM DEFEITO") &&                           //COM FUNCIONAL
              (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("DEVOLUÇÃO DE VENDA");
               // Classificacao = "DEVOLUÇÃO DE VENDA";
                Classificacao = "REPARO FUNCIONAL - GARANTIA"; // alteado conforme reunião realizada em 08/06/2018 no Magazine. (não tem DOA, a não ser para feature)
            }
            //===== 
            else if ((Convert.ToInt32(garantia) <= 15) &&      //MENOS DE 15 MESES DA DATA DO FATURAMENTO     
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("REPARO FUNCIONAL - GARANTIA");
                Classificacao = "REPARO FUNCIONAL - GARANTIA";
            }
            //=====
            else if ((Convert.ToInt32(garantia) <= 15))         //MENOS DE 15 MESES DA DATA DO FATURAMENTO          
            {
                //messageBox.Show("REPARO FUNCIONAL - ORÇAMENTO");
                Classificacao = "REPARO FUNCIONAL - ORÇAMENTO";
            }                    
        }
        // FIM - LOGICA MAGAZINE LUIZA =================================


        // LOGICA ALLIED ===============================================
        public void Allied()
        {
            if ((retencao.Length > 0))
            {
                if (retencao.Contains("LIKE NEW"))
                {
                    Classificacao = "LIKE NEW";
                }
                else
                {
                    Classificacao = "RETENCAO";
                }                               
            }
            else if ((Convert.ToInt32(garantia) > 15) ||        //MAIS DE 15 MESES DA DATA DO FATURAMENTO     
               (ForaGarantia == "ForaGarantia"))         //APRESENTA MAL USO                              
            {
                //messageBox.Show("FORA DE GARANTIA");
                Classificacao = "FORA DE GARANTIA";
            }
            //=====
            else if ((semdocumento != "SIM") &&                 //RADIO BUTTON SEM DOCUMENTO NÃO ESTAJA MARCADO
               (Convert.ToInt32(tempotroca) <= 4) &&            //TEMPO TROCA <= Q 4 DIAS
               (Convert.ToInt32(tempotriagem) <= 120) &&         //TEMPO TRIAGEM <= 120 DIAS mudado para 150 até o final do ano (31/12/2017) apartir de 2018 voltar para 120
               (motivo != "SEM DEFEITO") &&                           //COM FUNCIONAL
               (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
               (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
               (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("DEVOLUÇÃO DE VENDA - DOA");
                Classificacao = "DEVOLUÇÃO DE VENDA - DOA";
            }
            //======
            else if ((flag == "MaisDe30Dias") &&               //FLEGADO MAIS DE 30            
              (motivo != "SEM DEFEITO") &&                           //COM FUNCIONAL
              (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("DEVOLUÇÃO DE VENDA");
                Classificacao = "DEVOLUÇÃO DE VENDA";
            }
            //===== 
            else if ((Convert.ToInt32(garantia) <= 15) &&      //MENOS DE 15 MESES DA DATA DO FATURAMENTO     
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("REPARO FUNCIONAL - GARANTIA");
                Classificacao = "REPARO FUNCIONAL - GARANTIA";
            }
            //=====
            else if ((Convert.ToInt32(garantia) <= 15))         //MENOS DE 15 MESES DA DATA DO FATURAMENTO          
            {
                //messageBox.Show("REPARO FUNCIONAL - ORÇAMENTO");
                Classificacao = "REPARO FUNCIONAL - ORÇAMENTO";
                
            }
        }
        // FIM - LOGICA ALLIED =========================================

                
        // LOGICA MIXTEL ===============================================
        public void Mixtel()
        {
            if ((retencao.Length > 0))
            {
                if (retencao.Contains("LIKE NEW"))
                {
                    Classificacao = "LIKE NEW";
                }
                else
                {
                    Classificacao = "RETENCAO";
                }       
            }
            else if ((Convert.ToInt32(garantia) > 15) ||        //MAIS DE 15 MESES DA DATA DO FATURAMENTO     
               (ForaGarantia == "ForaGarantia"))         //APRESENTA MAL USO                              
            {
                //messageBox.Show("FORA DE GARANTIA");
                Classificacao = "FORA DE GARANTIA";
            }
            //=====
            else if ((semdocumento != "SIM") &&                 //RADIO BUTTON SEM DOCUMENTO NÃO ESTAJA MARCADO
               (Convert.ToInt32(tempotroca) <= 4) &&            //TEMPO TROCA <= Q 4 DIAS
               (Convert.ToInt32(tempotriagem) <= 120) &&        //TEMPO TRIAGEM <= 120 DIAS
               (motivo != "SEM DEFEITO") &&                           //COM FUNCIONAL
               (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
               (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
               (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("DEVOLUÇÃO DE VENDA - DOA");
                Classificacao = "DEVOLUÇÃO DE VENDA - DOA";
            }
            //======
            else if ((flag == "MaisDe30Dias") &&               //FLEGADO MAIS DE 30            
              (motivo != "SEM DEFEITO") &&                           //COM FUNCIONAL
              (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("DEVOLUÇÃO DE VENDA");
                Classificacao = "DEVOLUÇÃO DE VENDA";
            }
            //===== 
            else if ((Convert.ToInt32(garantia) <= 15) &&      //MENOS DE 15 MESES DA DATA DO FATURAMENTO     
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("REPARO FUNCIONAL - GARANTIA");
                Classificacao = "REPARO FUNCIONAL - GARANTIA";
            }
            //=====
            else if ((Convert.ToInt32(garantia) <= 15))         //MENOS DE 15 MESES DA DATA DO FATURAMENTO          
            {
                //messageBox.Show("REPARO FUNCIONAL - ORÇAMENTO");
                Classificacao = "REPARO FUNCIONAL - ORÇAMENTO";
                
            }
        }
        // FIM - LOGICA MIXTEL =========================================
        

        // LOGICA SOCIC-ANANINDEUA ===================================
        public void SocicAnanindeua()
        {
            if ((retencao.Length > 0))
            {
                if (retencao.Contains("LIKE NEW"))
                {
                    Classificacao = "LIKE NEW";
                }
                else
                {
                    Classificacao = "RETENCAO";
                }       
            }
            else if ((Convert.ToInt32(garantia) > 15) ||        //MAIS DE 15 MESES DA DATA DO FATURAMENTO     
               (ForaGarantia == "ForaGarantia"))         //APRESENTA MAL USO                              
            {
                //messageBox.Show("FORA DE GARANTIA");
                Classificacao = "FORA DE GARANTIA";
            }
            //=====
            else if ((semdocumento != "SIM") &&                 //RADIO BUTTON SEM DOCUMENTO NÃO ESTAJA MARCADO
               (Convert.ToInt32(tempotroca) <= 4) &&            //TEMPO TROCA <= Q 4 DIAS
               (Convert.ToInt32(tempotriagem) <= 30) &&        //TEMPO TRIAGEM <= 30 DIAS
               (motivo != "SEM DEFEITO") &&                           //COM FUNCIONAL
               (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
               (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
               (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("DEVOLUÇÃO DE VENDA - DOA");
                Classificacao = "DEVOLUÇÃO DE VENDA - DOA";
            }
            else
            {
                //messageBox.Show("NÃO DOA");
                Classificacao = "NAO DOA";
            }
            /*
            }            
            //======
            else if ((flag == "MaisDe30Dias") &&               //FLEGADO MAIS DE 30            
              (motivo != "SEM DEFEITO") &&                           //COM FUNCIONAL
              (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("DEVOLUÇÃO DE VENDA");
                Classificacao = "DEVOLUÇÃO DE VENDA";
            }
            //===== 
            else if ((Convert.ToInt32(garantia) <= 15) &&      //MENOS DE 15 MESES DA DATA DO FATURAMENTO     
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("REPARO FUNCIONAL - GARANTIA");
                Classificacao = "REPARO FUNCIONAL - GARANTIA";
            }
            //=====
            else if ((Convert.ToInt32(garantia) <= 15))         //MENOS DE 15 MESES DA DATA DO FATURAMENTO          
            {
                //messageBox.Show("REPARO FUNCIONAL - ORÇAMENTO");
                Classificacao = "REPARO FUNCIONAL - ORÇAMENTO";
               
            }
             */
        }
        // FIM - SOCIC - ANANINDEUA ====================================


        // LOGICA DELTASUL =============================================
        public void DeltaSul()
        {
            if ((retencao.Length > 0))
            {
                if (retencao.Contains("LIKE NEW"))
                {
                    Classificacao = "LIKE NEW";
                }
                else
                {
                    Classificacao = "RETENCAO";
                }       
            }
            else if ((Convert.ToInt32(garantia) > 15) ||        //MAIS DE 15 MESES DA DATA DO FATURAMENTO     
               (ForaGarantia == "ForaGarantia"))         //APRESENTA MAL USO                              
            {
                //messageBox.Show("FORA DE GARANTIA");
                Classificacao = "FORA DE GARANTIA";
            }
            //=====
            else if ((semdocumento != "SIM") &&                 //RADIO BUTTON SEM DOCUMENTO NÃO ESTAJA MARCADO
               (Convert.ToInt32(tempotroca) <= 4) &&            //TEMPO TROCA <= Q 4 DIAS
               //(Convert.ToInt32(tempotriagem) <= 120) &&        //TEMPO TRIAGEM <= 120 DIAS
               (motivo != "SEM DEFEITO") &&                           //COM FUNCIONAL
               (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
               (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
               (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("DEVOLUÇÃO DE VENDA - DOA");
                Classificacao = "DEVOLUÇÃO DE VENDA - DOA";
            }
            //======
            else if ((flag == "MaisDe30Dias") &&               //FLEGADO MAIS DE 30            
              (motivo != "SEM DEFEITO") &&                           //COM FUNCIONAL
              (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("DEVOLUÇÃO DE VENDA");
                Classificacao = "DEVOLUÇÃO DE VENDA";
            }
            //===== 
            else if ((Convert.ToInt32(garantia) <= 15) &&      //MENOS DE 15 MESES DA DATA DO FATURAMENTO     
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("REPARO FUNCIONAL - GARANTIA");
                Classificacao = "REPARO FUNCIONAL - GARANTIA";
            }
            //=====
            else if ((Convert.ToInt32(garantia) <= 15))         //MENOS DE 15 MESES DA DATA DO FATURAMENTO          
            {
                //messageBox.Show("REPARO FUNCIONAL - ORÇAMENTO");
                Classificacao = "REPARO FUNCIONAL - ORÇAMENTO";
            }
        }
        // FIM - DELTASUL ==============================================

        // LOGICA MASTER ELETRONICA DE BRINQUEDOS ======================
        public void MasterEletronica()
        {            
            if ((retencao.Length > 0))
            {
                if (retencao.Contains("LIKE NEW"))
                {
                    Classificacao = "LIKE NEW";
                }
                else
                {
                    Classificacao = "RETENCAO";
                }       
            }
            else if ((Convert.ToInt32(garantia) > 15) ||        //MAIS DE 15 MESES DA DATA DO FATURAMENTO     
               (ForaGarantia == "ForaGarantia"))                //APRESENTA MAL USO                              
            {
                //messageBox.Show("FORA DE GARANTIA");
                Classificacao = "FORA DE GARANTIA";
            }
            //=====
            else if ((semdocumento != "SIM") &&                 //RADIO BUTTON SEM DOCUMENTO NÃO ESTAJA MARCADO
               (Convert.ToInt32(tempotroca) <= diaParaOrcamento) &&            //TEMPO TROCA <= Q NUM DIAS DE ACORDO COM O TIPO DO EQUTIPAMENTO
               (Convert.ToInt32(tempotriagem) <= 30) &&         //TEMPO TRIAGEM <= 30 DIAS
               (motivo != "SEM DEFEITO") &&                     //COM FUNCIONAL
               (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
               (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
               (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("DEVOLUÇÃO DE VENDA - DOA");
                Classificacao = "DEVOLUÇÃO DE VENDA - DOA";
            }
            //======
            else if ((flag == "MaisDe30Dias") &&               //FLEGADO MAIS DE 30            
              (motivo != "SEM DEFEITO") &&                           //COM FUNCIONAL
              (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("DEVOLUÇÃO DE VENDA");
                Classificacao = "DEVOLUÇÃO DE VENDA";
            }
            //===== 
            else if ((Convert.ToInt32(garantia) <= 15) &&      //MENOS DE 15 MESES DA DATA DO FATURAMENTO     
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("REPARO FUNCIONAL - GARANTIA");
                Classificacao = "REPARO FUNCIONAL - GARANTIA";
            }
            //=====
            else if ((Convert.ToInt32(garantia) <= 15))         //MENOS DE 15 MESES DA DATA DO FATURAMENTO          
            {
                //messageBox.Show("REPARO FUNCIONAL - ORÇAMENTO");
                Classificacao = "REPARO FUNCIONAL - ORÇAMENTO";
            }
        }
        // FIM - LOGICA MASTER ELETRONICA DE BRINQUEDOS ================

        // LOGICA CARREFOUR ============================================
        public void Carrefour()
        {
            if ((retencao.Length > 0))
            {
                if (retencao.Contains("LIKE NEW"))
                {
                    Classificacao = "LIKE NEW";
                }
                else
                {
                    Classificacao = "RETENCAO";
                }       
            }
            else if ((Convert.ToInt32(garantia) > 15) ||        //MAIS DE 15 MESES DA DATA DO FATURAMENTO     
               (ForaGarantia == "ForaGarantia"))                //APRESENTA MAL USO                              
            {
                //messageBox.Show("FORA DE GARANTIA");
                Classificacao = "FORA DE GARANTIA";
            }
            //=====
            else if ((semdocumento != "SIM") &&                 //RADIO BUTTON SEM DOCUMENTO NÃO ESTAJA MARCADO
               (Convert.ToInt32(tempotroca) <= diaParaOrcamento) &&            //TEMPO TROCA <= Q NUM DIAS DE ACORDO COM O TIPO DO EQUTIPAMENTO
               (Convert.ToInt32(tempotriagem) <= 30) &&         //TEMPO TRIAGEM <= 30 DIAS
               (motivo != "SEM DEFEITO") &&                     //COM FUNCIONAL
               (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
               (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
               (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("DEVOLUÇÃO DE VENDA - DOA");
                Classificacao = "DEVOLUÇÃO DE VENDA - DOA";
            }
            //======
            else if ((flag == "MaisDe30Dias") &&               //FLEGADO MAIS DE 30            
              (motivo != "SEM DEFEITO") &&                           //COM FUNCIONAL
              (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("DEVOLUÇÃO DE VENDA");
                Classificacao = "DEVOLUÇÃO DE VENDA";
            }
            //===== 
            else if ((Convert.ToInt32(garantia) <= 15) &&      //MENOS DE 15 MESES DA DATA DO FATURAMENTO     
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("REPARO FUNCIONAL - GARANTIA");
                Classificacao = "REPARO FUNCIONAL - GARANTIA";
            }
            //=====
            else if ((Convert.ToInt32(garantia) <= 15))         //MENOS DE 15 MESES DA DATA DO FATURAMENTO          
            {
                //messageBox.Show("REPARO FUNCIONAL - ORÇAMENTO");
                Classificacao = "REPARO FUNCIONAL - ORÇAMENTO";
            }
        }
        // FIM - LOGICA CARREFOUR=======================================


        // LOGICA DEMAIS VAREJISTAS "GERAL"=============================
        public void DemaisVarejistas()
        {
            if ((retencao.Length > 0))
            {
                if (retencao.Contains("LIKE NEW"))
                {
                    Classificacao = "LIKE NEW";
                }
                else
                {
                    Classificacao = "RETENCAO";
                }       
            }
            else if ((Convert.ToInt32(garantia) > 15) ||        //MAIS DE 15 MESES DA DATA DO FATURAMENTO     
               (ForaGarantia == "ForaGarantia"))         //APRESENTA MAL USO                              
            {
               // //messageBox.Show("FORA DE GARANTIA");
                Classificacao = "FORA DE GARANTIA";
            }
            //=====
            else if ((semdocumento != "SIM") &&                 //RADIO BUTTON SEM DOCUMENTO NÃO ESTAJA MARCADO
               (Convert.ToInt32(tempotroca) <= diaParaOrcamento) &&            //TEMPO TROCA <= Q O ESPECIFICADO PARA O CLIENTE
               (Convert.ToInt32(tempotriagem) <= prazoTroca) &&        //TEMPO TRIAGEM <= O ESPECIFICADO PARA O CLIENTE
               (motivo != "SEM DEFEITO") &&                           //COM FUNCIONAL
               (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
               (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
               (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
              //  //messageBox.Show("DEVOLUÇÃO DE VENDA - DOA");
                Classificacao = "DEVOLUÇÃO DE VENDA - DOA";
            }
            //======
            else if ((flag == "MaisDe30Dias") &&               //FLEGADO MAIS DE 30            
              (motivo != "SEM DEFEITO") &&                           //COM FUNCIONAL
              (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
              //  //messageBox.Show("DEVOLUÇÃO DE VENDA");
                Classificacao = "DEVOLUÇÃO DE VENDA";
            }
            //=====
            else if ((Convert.ToInt32(garantia) <= 15) &&      //MENOS DE 15 MESES DA DATA DO FATURAMENTO
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
             //   //messageBox.Show("REPARO FUNCIONAL - GARANTIA");
                Classificacao = "REPARO FUNCIONAL - GARANTIA";
            }
            //=====
            else if ((Convert.ToInt32(garantia) <= 15))         //MENOS DE 15 MESES DA DATA DO FATURAMENTO
            {
              //  //messageBox.Show("REPARO FUNCIONAL - ORÇAMENTO");
                Classificacao = "REPARO FUNCIONAL - ORÇAMENTO";
            }
        }
        // FIM - DEMAIS VAREJISTAS =====================================

        // LOGICA PARA FEATUREFONES ====================================
        public void FeaturePhone()
        {
            if ((retencao.Length > 0))
            {
                Classificacao = "SALDO"; 
            }
            else if ((Convert.ToInt32(garantia) > 15) ||        //MAIS DE 15 MESES DA DATA DO FATURAMENTO     
               (ForaGarantia == "ForaGarantia"))         //APRESENTA MAL USO                              
            {
                //messageBox.Show("FORA DE GARANTIA");
                Classificacao = "FORA DE GARANTIA";
            }
            //=====
            else if (//(semdocumento != "SIM") &&                 //RADIO BUTTON SEM DOCUMENTO NÃO ESTAJA MARCADO
            //   (Convert.ToInt32(tempotroca) <= diaParaOrcamento) &&            //TEMPO TROCA <= Q O ESPECIFICADO PARA O CLIENTE
             //  (Convert.ToInt32(tempotriagem) <= prazoTroca) &&        //TEMPO TRIAGEM <= O ESPECIFICADO PARA O CLIENTE
               (motivo != "SEM DEFEITO") &&                           //COM FUNCIONAL
               (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
               (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
               (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("DEVOLUÇÃO DE VENDA - DOA");
                Classificacao = "DEVOLUÇÃO DE VENDA - DOA";
            }
            //======
            else if ((flag == "MaisDe30Dias") &&               //FLEGADO MAIS DE 30            
              (motivo != "SEM DEFEITO") &&                           //COM FUNCIONAL
              (Convert.ToInt32(garantia) <= 15) &&             //MENOS DE 15 MESES DA DATA DO FATURAMENTO
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("DEVOLUÇÃO DE VENDA");
                Classificacao = "DEVOLUÇÃO DE VENDA";
            }
            //=====
            else if ((Convert.ToInt32(garantia) <= 15) &&      //MENOS DE 15 MESES DA DATA DO FATURAMENTO
              (estadoequipamento == "SEM AVARIAS") &&               //SEM AVARIAS ESTETICAS
              (acessorios == "COMPLETO"))                        //SEM ACESSÓRIOS FALTANTES
            {
                //messageBox.Show("REPARO FUNCIONAL - GARANTIA");
                Classificacao = "REPARO FUNCIONAL - GARANTIA";
            }
            //=====
            else if ((Convert.ToInt32(garantia) <= 15))         //MENOS DE 15 MESES DA DATA DO FATURAMENTO
            {
                //messageBox.Show("REPARO FUNCIONAL - ORÇAMENTO");
                Classificacao = "REPARO FUNCIONAL - ORÇAMENTO";
            }
        }
        // FIM - LOGICA PARA FEATUREFONES ==============================
        



    }
}
