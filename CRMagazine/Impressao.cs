using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

namespace CRMagazine
{
    class Impressao
    {
        public string s = "";
        public string TextoLivre = "";
        public string Varejista = "";
        public string Classificacao = "";
        public string NFOrigem = "";
        public string Destino = "";
        public string Funcional = "";
        public string Estetico = "";
        public string Faltante = "";

        //=========== variaveis para etiquetas de todos modelos...

        public string produto = "";
        public string codPositivo = "";
        public string IMEI1 = "";
        public string IMEI2 = "";
        public string NS = "";
     //   public string EAN = "";
        public string Anatel = "";
        public string configuracao1 = "";
        public string configuracao2 = "";
        public string configuracao3 = "";
        public string configuracao4 = "";
        public string configuracao5 = "";
        public string configuracao6 = "";
        public string configuracao7 = "";
        public string configuracao8 = "";
        public string configuracao9 = "";
        public string configuracao10 = "";
        public string configuracao11 = "";
        public string tipoEtiqueta = "";

        public string Fabricante = "";

        public string Modelo = "";   //somente para tablet
        public string Familia = "";  //somente para tablet
        public string Potencia = ""; //somente para tablet
        public string Tensao = "";   //somente para tablet


        public string OS = "";   //somente para entrada
        public string Data = "";   //somente para entrada

        public string NF = ""; //Etiqueta de Devolução
        public string Descricao = "";
        public string LocalDevolucao = "";
        public string CodVarejista = "";
        public string ChamadoPai = "";


        public void EtiquetaEntrada(string OS, string Entrada, string Mais30)
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW1400";
            s += "^LL680";
            s += "^LS0";
            s += "^SD20";
            s += "";
            s += "^BY3,2,80^FT 90,120^BCN,,N,N^FD" + OS + "^FS";
            s += "^FT90,180^A0N,70,80^FH\\^FD" + OS + "^FS";
            s += "";
            s += "^FO80,240^GB310,150,5^FS";
            s += "^FT120,280^A0N,45,55^FH\\^FDENTRADA^FS";
            s += "^FT90,360^A0N,80,60^FH\\^FD"+ Entrada + "^FS";
            s += "";
            // PARA USAR SE QISER A DESCR DO PRODUTO CENTRALIZADA E COM QUEBRA AUTOMATICA
         //   ^FO30,185^FB760,3,0,C,0^AON,25,15^FDCODIGO ISDFGFGDFSGDFGGSGFDFGFDGF5DGNTERNO^FS
            s += "^FO450,240^GB310,150,85^FS";
            s += "^FO500,250^FR^AC,40,20^FDDT LIMITE^FS";
            s += "^FO480,300^FR^AC,80,22^FD" + Mais30 + "^FS";
            s += "";
            s += "^PQ1,0,1,Y^XZ";
        }

        public void EtiquetaEANPuri(string Voltagem, string CodVarejo, string SKU, string EAN, string Descricao)
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD07^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW1400";
            s += "^LL680";
            s += "^LS0";
            s += "^SD20";
            s += "^FO365,40^GB100,110,4^FS";
            s += "^FO0,70^FB850,3,0,C,0^AON,50,15^FD" + Voltagem + "V^FS";
            //s += "^FO0,90^FB800,3,0,C,0^AON,30,15^FDBR/VM^FS";

            s += "^FO10,45^FB340,3,0,C,0^AON,25,15^FDREFERENCIA^FS";
            s += "^FO70,70^BY2^BCN,90,N,N^FD" + CodVarejo + "^FS";
            s += "^FO10,170^FB340,3,0,C,0^AON,25,15^FD" + CodVarejo + "^FS";

            s += "^FO500,45^FB270,3,0,C,0^AON,25,15^FDCODIGO INTERNO^FS";
            s += "^FO510,70^BY2^BCN,90,N,N^FD" + SKU + "^FS";
            s += "^FO500,170^FB270,3,0,C,0^AON,25,15^FD" + SKU + "^FS";

            s += "^FO30,205^GB770,1,4^FS";

            s += "^FT265,240^A0N,30,35^FH\\^FDCODIGO EAN:^FS";
            s += "^BY3,2,60^FT270,305^BEN,,Y,N^FD" + EAN + "^FS";

            s += "^FO0,350^FB800,3,2,C,0^AON,30,10^FD" + Descricao +"^FS";
            s += "^PQ1,0,1,Y^XZ";
        }

        public void EtiquetaEANPuriConfig(string Voltagem, string CodVarejo, string SKU, string EAN, string Descricao)
        {
            s = "";
            //s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW1400";
            s += "^LL680";
            s += "^LS0";
            s += "^SD20";
            s += "^FO365,40^GB100,110,4^FS";
            s += "^FO0,70^FB850,3,0,C,0^AON,50,15^FD" + Voltagem + "V^FS";
            //s += "^FO0,90^FB800,3,0,C,0^AON,30,15^FDBR/VM^FS";

            s += "^FO10,45^FB340,3,0,C,0^AON,25,15^FDREFERENCIA^FS";
            s += "^FO70,70^BY2^BCN,90,N,N^FD" + CodVarejo + "^FS";
            s += "^FO10,170^FB340,3,0,C,0^AON,25,15^FD" + CodVarejo + "^FS";

            s += "^FO500,45^FB270,3,0,C,0^AON,25,15^FDCODIGO INTERNO^FS";
            s += "^FO510,70^BY2^BCN,90,N,N^FD" + SKU + "^FS";
            s += "^FO500,170^FB270,3,0,C,0^AON,25,15^FD" + SKU + "^FS";

            s += "^FO30,205^GB770,1,4^FS";

            s += "^FT265,240^A0N,30,35^FH\\^FDCODIGO EAN:^FS";
            s += "^BY3,2,60^FT270,305^BEN,,Y,N^FD" + EAN + "^FS";

            s += "^FO0,350^FB800,3,2,C,0^AON,30,10^FD" + Descricao + "^FS";
            s += "^PQ1,0,1,Y^XZ";
        }

        public void EtiquetaLivre300dpiOLD()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW1400";
            s += "^LL680";
            s += "^LS0";
            s += "^SD20";
            //s += "^FT250,330^A0N,200,120^FH\\^FD" + TextoLivre + "^FS";
            s += "^BY4,4,50^FT 260,250^BCN,,Y,N^FD" + NS + "^FS";
            s += "^PQ1,0,1,Y^XZ";
        }

        public void EtiquetaLivre600dpiOLD()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW2800";
            s += "^LL1360";
            s += "^LS0";
            s += "^SD20";
            //s += "^FT250,330^A0N,200,120^FH\\^FD" + TextoLivre + "^FS";
            s += "^BY9,3,100^FT 550,600^BCN,,Y,N^FD" + NS + "^FS";
            s += "^PQ1,0,1,Y^XZ";
        }

        public void EtiquetaLivre200dpi()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD07^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW933";
            s += "^LL453";
            s += "^LS0";
            s += "^SD20";
            s += "^FT15,50^A0N,50,50^FH\\^FD" + Varejista + "^FS";
            s += "^FT15,120^A0N,60,50^FH\\^FD" + Classificacao + "^FS";

            s += "^FT500,166^A0N,20,24^FH\\^FDCODIGO EAN:^FS";
            s += "^BY2,3,29^FT500,200^BEN,,Y,N^FD" + CodEAN + "^FS";

            s += "^FT15,166^A0N,20,24^FH\\^FDSERIAL:^FS";
            s += "^BY2,3,29^FT 15,200^BCN,,N,N^FD" + NS + "^FS";
            s += "^FT15,220^A0N,20,26^FH\\^FD" + NS + "^FS";

            s += "^FT15,285^A0N,30,30^FH\\^FDCHAMADO: " + ChamadoPai + "^FS";


            if (Varejista == "MagazineLuiza" || Varejista.Contains("MAGAZINE LUIZA"))
            {
                //===========adicionar
                s += "^FT500,266^A0N,20,24^FH\\^FDCODIGO GEMCO:^FS";
                s += "^BY2,2,28^FT500,300^BCN,,Y,N^FD" + Genco + "^FS";
                //==========
                s += "^FT15,330^A0N,20,24^FH\\^FDFILIAL: " + Filial + "^FS";

            }
            else
            {
                //===========adicionar
                s += "^FT500,266^A0N,20,24^FH\\^FDIMEI:^FS";
                s += "^BY2,1,28^FT400,300^BCN,,Y,N^FD" + IMEI1 + "^FS";
                //==========
            }            

            s += "^PQ1,0,1,Y^XZ";

            /*
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW933";
            s += "^LL453";
            s += "^LS0";
            s += "^SD20";
            s += "^FT53,53^A0N,40,40^FH\\^FD " + Varejista + "^FS";
            s += "^FT53,93^A0N,26,26^FH\\^FDCLASSIFICACAO: " + Classificacao + "^FS";
            s += "^FT53,126^A0N,26,26^FH\\^FDNF ORIGEM: " + NFOrigem + "^FS";
            s += "^FT53,160^A0N,26,26^FH\\^FDDESTINO: " + Destino + "^FS";
            s += "^FT53,266^A0N,23,23^FH\\^FDFUNCIONAL:^FS";
            s += "^FT53,286^A0N,20,20^FH\\^FD" + Funcional + "^FS";
            s += "^FT53,313^A0N,23,23^FH\\^FDAVARIAS:^FS";
            s += "^FT53,333^A0N,20,20^FH\\^FD" + Estetico + "^FS";
            s += "^FT53,360^A0N,23,23^FH\\^FDACESSORIOS:^FS";
            s += "^FT53,380^A0N,20,20^FH\\^FD" + Faltante + "^FS";
            s += "^PQ1,0,1,Y^XZ";
             */ 
        }

        public void EtiquetaLivre300dpi()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW1400";
            s += "^LL680";
            s += "^LS0";
            s += "^SD20";
            s += "^FT80,80^A0N,45,45^FH\\^FD" + Varejista + "^FS";
            s += "^FT80,190^A0N,110,95^FH\\^FD" + Classificacao + "^FS";
            s += "^FT750,250^A0N,30,36^FH\\^FDCODIGO EAN:^FS";
            s += "^BY2,3,44^FT750,300^BEN,,Y,N^FD" + CodEAN + "^FS";
            s += "^FT80,250^A0N,30,36^FH\\^FDSERIAL:^FS";
            s += "^BY2,3,42^FT 80,300^BCN,,N,N^FD" + NS + "^FS";
            s += "^FT80,330^A0N,30,36^FH\\^FD" + NS + "^FS";
            s += "^FT80,440^A0N,45,45^FH\\^FDCHAMADO: " + ChamadoPai + "^FS";

          //  MessageBox.Show(Varejista);
            if (Varejista == "MagazineLuiza" || Varejista.Contains("MAGAZINE LUIZA"))
            {
                //===========adicionar
                s += "^FT750,400^A0N,30,36^FH\\^FDCODIGO GEMCO:^FS";
                s += "^BY2,3,42^FT750,450^BCN,,Y,N^FD" + Genco + "^FS";
                //==========
            }            

            s += "^PQ1,0,1,Y^XZ";

            /*
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW1400";
            s += "^LL680";
            s += "^LS0";
            s += "^SD20";
            s += "^FT80,80^A0N,60,60^FH\\^FD " + Varejista + "^FS";
            s += "^FT80,140^A0N,40,40^FH\\^FDCLASSIFICACAO: " + Classificacao + "^FS";
            s += "^FT80,190^A0N,40,40^FH\\^FDNF ORIGEM: " + NFOrigem + "^FS";
            s += "^FT80,240^A0N,40,40^FH\\^FDDESTINO: " + Destino + "^FS";
            s += "^FT80,400^A0N,40,40^FH\\^FDFUNCIONAL:^FS";
            s += "^FT80,430^A0N,30,30^FH\\^FD" + Funcional + "^FS";
            s += "^FT80,470^A0N,40,40^FH\\^FDAVARIAS:^FS";
            s += "^FT80,500^A0N,30,30^FH\\^FD" + Estetico + "^FS";
            s += "^FT80,540^A0N,40,40^FH\\^FDACESSORIOS:^FS";
            s += "^FT80,570^A0N,30,30^FH\\^FD" + Faltante + "^FS";

            //===========adicionar
            s += "^FT750,400^A0N,30,36^FH\\^FDCODIGO GEMCO:^FS";
            s += "^BY2,3,42^FT750,450^BCN,,Y,N^FD" + Genco + "^FS";
            //==========


            s += "^PQ1,0,1,Y^XZ";
             */ 
        }

        public void EtiquetaLivre600dpi()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW2800";
            s += "^LL1360";
            s += "^LS0";
            s += "^SD20";
            s += "^FT160,160^A0N,90,90^FH\\^FD" + Varejista + "^FS";
            s += "^FT160,380^A0N,220,200^FH\\^FD" + Classificacao + "^FS";
            s += "^FT1500,500^A0N,60,72^FH\\^FDCODIGO EAN:^FS";
            s += "^BY5,6,84^FT1500,600^BEN,,Y,N^FD" + CodEAN + "^FS";
            s += "^FT160,500^A0N,60,72^FH\\^FDSERIAL:^FS";
            s += "^BY5,6,84^FT 160,600^BCN,,N,N^FD" + NS + "^FS";
            s += "^FT160,660^A0N,60,72^FH\\^FD" + NS + "^FS";
            s += "^FT160,880^A0N,90,90^FH\\^FDCHAMADO: " + ChamadoPai + "^FS";

            if (Varejista == "MagazineLuiza" || Varejista.Contains("MAGAZINE LUIZA"))
            {
                //===========adicionar
                s += "^FT1500,800^A0N,60,72^FH\\^FDCODIGO GEMCO:^FS";
                s += "^BY5,6,84^FT1500,900^BCN,,Y,N^FD" + Genco + "^FS";
                //==========
            }
           

            s += "^PQ1,0,1,Y^XZ";

            
            /*
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW2800";
            s += "^LL1360";
            s += "^LS0";
            s += "^SD20";
            s += "^FT160,160^A0N,120,120^FH\\^FD " + Varejista + "^FS";
            s += "^FT160,280^A0N,80,80^FH\\^FDCLASSIFICACAO: " + Classificacao + "^FS";
            s += "^FT160,380^A0N,80,80^FH\\^FDNF ORIGEM: " + NFOrigem + "^FS";
            s += "^FT160,480^A0N,80,80^FH\\^FDDESTINO: " + Destino + "^FS";
            s += "^FT160,800^A0N,80,80^FH\\^FDFUNCIONAL:^FS";
            s += "^FT160,860^A0N,60,60^FH\\^FD" + Funcional + "^FS";
            s += "^FT160,940^A0N,80,80^FH\\^FDAVARIAS:^FS";
            s += "^FT160,1000^A0N,60,60^FH\\^FD" + Estetico + "^FS";
            s += "^FT160,1080^A0N,80,80^FH\\^FDACESSORIOS:^FS";
            s += "^FT160,1140^A0N,60,60^FH\\^FD" + Faltante + "^FS";
            s += "^PQ1,0,1,Y^XZ";
             */ 

        }

        public string Genco = "";
        public string CodEAN = "";
        public string Serial = "";
        public string ModeloMag = "";
        public string EtiqChameOGenio = "";
        public string CodAtendimentoChameGenio = "";
        public string Filial = "";
        public string Lacre = "";
        public string Cidade = "";


        public void Magazine()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW1400";
            s += "^LL680";
            s += "^LS0";
            s += "^SD20";
            s += "^FT80,80^A0N,45,45^FH\\^FD" + Varejista + "^FS";
            s += "^FT80,190^A0N,110,110^FH\\^FD" + Classificacao + "^FS";
            s += "^FT750,250^A0N,30,36^FH\\^FDCODIGO EAN:^FS";
            s += "^BY2,3,44^FT750,300^BEN,,Y,N^FD" + CodEAN + "^FS";
            s += "^FT80,250^A0N,30,36^FH\\^FDSERIAL:^FS";
            s += "^BY2,3,42^FT 80,300^BCN,,N,N^FD" + NS + "^FS";
            s += "^FT80,330^A0N,30,36^FH\\^FD" + NS + "^FS";
            s += "^FT80,440^A0N,45,45^FH\\^FDCHAMADO: " + ChamadoPai + "^FS";

            //===========adicionar
            s += "^FT750,400^A0N,30,36^FH\\^FDCODIGO GEMCO:^FS";
            s += "^BY2,3,42^FT750,450^BCN,,Y,N^FD" + Genco + "^FS";
            //==========

            s += "^PQ1,0,1,Y^XZ";
        }

        public void Magazine200dpi()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW1400";
            s += "^LL1000";
            s += "^LS0";
            s += "^FT300,53^A0N,30,30^FH\\^FDMAGAZINE LUIZA^FS";
            // s += "^FO30,80^GB1217,130,4^FS";
            s += "^FT53,80^A0N,19,24^FH\\^FDCODIGO GEMCO:^FS";
            s += "^BY2,2,28^FT53,113^BCN,,Y,N^FD" + Genco + "^FS";
            s += "^FT320,80^A0N,19,24^FH\\^FDCODIGO EAN:^FS";
            s += "^BY2,2,28^FT320,113^BEN,,Y,N^FD" + CodEAN + "^FS";
            s += "^FT546,80^A0N,19,24^FH\\^FDSERIAL:^FS";
            s += "^BY2,2,28^FT 546,113^BCN,,N,N^FD" + Serial + "^FS";
            s += "^FT546,131^A0N,20,24^FH\\^FD" + Serial + "^FS";
           // s += "^FT53,180^A0N,19,24^FH\\^FDFABRICANTE: POSITIVO TECNOLOGIA^FS";
          //  s += "^FT53,206^A0N,19,24^FH\\^FDMODELO: " + ModeloMag + "^FS";
            s += "^FT53,163^A0N,19,24^FH\\^FDFABRICANTE: POSITIVO TECNOLOGIA^FS";
            s += "^FT53,185^A0N,19,24^FH\\^FDMODELO: " + ModeloMag + "^FS";

            s += "^FT53,210^A0N,19,24^FH\\^FDFILIAL: " + Filial + " - " + Cidade + "^FS";
            s += "^FT53,232^A0N,19,24^FH\\^FDCDK:^FS";
            s += "^BY2,2,28^FT 110,245^BCN,,S,N^FD" + Lacre + "^FS";

           // s += "^FT53,233^A0N,19,24^FH\\^FDETIQUETA(LACRE)CHAME O GENIO: " + EtiqChameOGenio + "^FS";
           // s += "^FT53,260^A0N,19,24^FH\\^FDTENSAO OU VOLTAGEM: 110/220V^FS";
        //    s += "^FT53,286^A0N,19,24^FH\\^FDCOD. ATENDIMENTO CHAME O GENIO: " + CodAtendimentoChameGenio + "^FS";
            s += "^FT53,286^A0N,19,24^FH\\^FDETIQUETA(LACRE)CHAME O GENIO: " + EtiqChameOGenio + "^FS";
            s += "^FT53,313^A0N,19,24^FH\\^FDPOSTO AUTORIZADO: POSITIVO^FS";
            s += "^FT53,340^A0N,19,24^FH\\^FDGARANTIA: 3 MESES PARA DEFEITO FUNCIONAL^FS";
            s += "^FT53,373^A0N,26,23^FH\\^FDCLASSIFICACAO: " + Classificacao + " ^FS";
            s += "^PQ1,0,1,Y^XZ";
        }


        public void Magazine600dpi()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW2800";
            s += "^LL2000";
            s += "^LS0";
            s += "^FT900,120^A0N,100,100^FH\\^FDMAGAZINE LUIZA^FS";
            // s += "^FO60,160^GB2434,260,8^FS";
            s += "^FT160,240^A0N,60,72^FH\\^FDCODIGO GEMCO:^FS";
            s += "^BY5,6,84^FT160,340^BCN,,Y,N^FD" + Genco + "^FS";
            s += "^FT960,240^A0N,60,72^FH\\^FDCODIGO EAN:^FS";
            s += "^BY5,6,84^FT960,340^BEN,,Y,N^FD" + CodEAN + "^FS";
            s += "^FT1640,240^A0N,60,72^FH\\^FDSERIAL:^FS";
            s += "^BY5,6,84^FT 1640,340^BCN,,N,N^FD" + Serial + "^FS";
            s += "^FT1640,394^A0N,60,72^FH\\^FD" + Serial + "^FS";
            s += "^FT160,540^A0N,60,72^FH\\^FDFABRICANTE: POSITIVO TECNOLOGIA^FS";
            s += "^FT160,620^A0N,60,72^FH\\^FDMODELO: " + ModeloMag + "^FS";
            s += "^FT160,700^A0N,60,72^FH\\^FDETIQUETA(LACRE)CHAME O GENIO: " + EtiqChameOGenio + "^FS";
            s += "^FT160,780^A0N,60,72^FH\\^FDTENSAO OU VOLTAGEM: 110/220V^FS";
            s += "^FT160,860^A0N,60,72^FH\\^FDCOD. ATENDIMENTO CHAME O GENIO: " + CodAtendimentoChameGenio + "^FS";
            s += "^FT160,940^A0N,60,72^FH\\^FDPOSTO AUTORIZADO: POSITIVO^FS";
            s += "^FT160,1020^A0N,60,72^FH\\^FDGARANTIA: 3 MESES PARA DEFEITO FUNCIONAL^FS";
            s += "^FT160,1120^A0N,80,70^FH\\^FDCLASSIFICACAO: " + Classificacao + " ^FS";
            s += "^PQ1,0,1,Y^XZ";

        }

        // ======================== EAN ==================================

        public void EtiqEAN()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR2,2^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^LL0531";
            s += "^PW1280";
            s += "^LS0";
            s += "^FT81,528^A0B,29,28^FH\\^FD" + produto + "^FS";
            s += "^FT43,346^A0B,37,36^FH\\^FD" + codPositivo + "^FS";
            s += "^FO1159,29^GB0,500,4^FS";
            s += "^FO304,31^GB0,500,4^FS";
            s += "^FO99,31^GB0,500,3^FS";
            s += "^FO745,29^GB0,500,3^FS";
            s += "^FT336,495^A0B,29,33^FH\\^FDEAN DO PRODUTO^FS";
            s += "^BY3,2,42^FT384,492^BEB,,Y,N";
            s += "^FD" + CodEAN + "^FS";
            s += "^FT231,495^A0B,31,33^FH\\^FDORDEM DE PRODU\\80\\C7O^FS";
            s += "^FT131,495^A0B,29,33^FH\\^FDN\\E9MERO DE S\\90RIE^FS";
            s += "^FT1245,519^A0B,17,21^FH\\^FDProduto Beneficiado pela Legisla\\87\\C6o de Inform\\A0tica^FS";
            s += "^FT1225,519^A0B,17,21^FH\\^FDI.E: 06.200.590-1 Ind. Brasileira^FS";
            s += "^FT1205,519^A0B,17,21^FH\\^FDCNPJ: 08.239.748/0001-53^FS";
            s += "^FT1183,519^A0B,17,21^FH\\^FDFabricado por: POSITIVO INFORM\\A0TICA^FS";
            s += "^FT783,245^A0B,37,36^FH\\^FD---^FS";
            s += "^FT776,519^A0B,27,28^FH\\^FDConfigura\\87\\C6o:^FS";
            s += "^FT807,519^A0B,21,21^FH\\^FD" + configuracao1 + "^FS";
            s += "^FT838,519^A0B,21,21^FH\\^FD" + configuracao2 + "^FS";
            s += "^FT869,519^A0B,21,21^FH\\^FD" + configuracao3 + "^FS";
            s += "^FT900,519^A0B,21,21^FH\\^FD" + configuracao4 + "^FS";
            s += "^FT931,519^A0B,21,21^FH\\^FD" + configuracao5 + "^FS";
            s += "^FT962,519^A0B,21,21^FH\\^FD" + configuracao6 + "^FS";
            s += "^FT993,519^A0B,21,21^FH\\^FD" + configuracao7 + "^FS";
            s += "^FT1024,519^A0B,21,21^FH\\^FD" + configuracao8 + "^FS";
            s += "^FT1055,519^A0B,21,21^FH\\^FD" + configuracao9 + "^FS";
            s += "^FT1086,519^A0B,21,21^FH\\^FD" + configuracao10 + "^FS";
            s += "^BY3,3,36^FT275,495^BCB,,Y,N";
            s += "^FD>:XXXXXXXX^FS";
            s += "^BY3,3,35^FT170,495^BCB,,Y,N";
            s += "^FD>:" + NS + "^FS";
            s += "^PQ1,0,1,Y^XZ";
        }

        public void EtiqEAN200()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR2,2^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^LL0354";
            s += "^PW854";
            s += "^LS0";
            s += "^FT54,352^A0B,20,20^FH\\^FD" + produto + "^FS";
            s += "^FT29,230^A0B,25,24^FH\\^FD" + codPositivo + "^FS";
            s += "^FO773,20^GB0,333,3^FS";
            s += "^FO203,20^GB0,333,3^FS";
            s += "^FO66,21^GB0,333,3^FS";
            s += "^FO497,20^GB0,333,3^FS";
            s += "^FT224,330^A0B,20,22^FH\\^FDEAN DO PRODUTO^FS";
            s += "^BY3,2,28^FT256,328^BEB,,Y,N";
            s += "^FD" + CodEAN + "^FS";
            s += "^FT154,330^A0B,21,22^FH\\^FDORDEM DE PRODU\\80\\C7O^FS";
            s += "^FT86,330^A0B,20,22^FH\\^FDN\\E9MERO DE S\\90RIE^FS";
            s += "^FT830,346^A0B,11,14^FH\\^FDProduto Beneficiado pela Legisla\\87\\C6o de Inform\\A0tica^FS";
            s += "^FT817,346^A0B,11,14^FH\\^FDI.E: 06.200.590-1 Ind. Brasileira^FS";
            s += "^FT803,346^A0B,11,14^FH\\^FDCNPJ: 08.239.748/0001-53^FS";
            s += "^FT709,346^A0B,11,14^FH\\^FDFabricado por: POSITIVO INFORM\\A0TICA^FS";
            s += "^FT522,163^A0B,25,24^FH\\^FD---^FS";
            s += "^FT517,346^A0B,18,19^FH\\^FDConfigura\\87\\C6o:^FS";
            s += "^FT538,346^A0B,14,14^FH\\^FD" + configuracao1 + "^FS";
            s += "^FT559,346^A0B,14,14^FH\\^FD" + configuracao2 + "^FS";
            s += "^FT579,346^A0B,14,14^FH\\^FD" + configuracao3 + "^FS";
            s += "^FT600,346^A0B,14,14^FH\\^FD" + configuracao4 + "^FS";
            s += "^FT621,346^A0B,14,14^FH\\^FD" + configuracao5 + "^FS";
            s += "^FT641,346^A0B,14,14^FH\\^FD" + configuracao6 + "^FS";
            s += "^FT662,346^A0B,14,14^FH\\^FD" + configuracao7 + "^FS";
            s += "^FT683,346^A0B,14,14^FH\\^FD" + configuracao8 + "^FS";
            s += "^FT703,346^A0B,14,14^FH\\^FD" + configuracao9 + "^FS";
            s += "^FT724,346^A0B,14,14^FH\\^FD" + configuracao10 + "^FS";
            s += "^BY3,3,24^FT183,330^BCB,,Y,N";
            s += "^FD>:XXXXXXXX^FS";
            s += "^BY3,3,23^FT113,330^BCB,,Y,N";
            s += "^FD>:" + NS + "^FS";
            s += "^PQ1,0,1,Y^XZ";
        }

        public void EtiqEAN600()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR2,2^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^LL01062";
            s += "^PW2560";
            s += "^LS0";
            s += "^FT162,1056^A0B,58,58^FH\\^FD" + produto + "^FS";
            s += "^FT86,692^A0B,72,72^FH\\^FD" + codPositivo + "^FS";
            s += "^FO2318,58^GB0,1000,8^FS";
            s += "^FO608,62^GB0,1000,8^FS";
            s += "^FO198,62^GB0,1000,6^FS";
            s += "^FO1490,60^GB0,1000,6^FS";
            s += "^FT672,990^A0B,60,66^FH\\^FDEAN DO PRODUTO^FS";
            s += "^BY6,4,84^FT768,984^BEB,,Y,N";
            s += "^FD" + CodEAN + "^FS";
            s += "^FT462,990^A0B,62,66^FH\\^FDORDEM DE PRODU\\80\\C7O^FS";
            s += "^FT262,990^A0B,60,66^FH\\^FDN\\E9MERO DE S\\90RIE^FS";
            s += "^FT2490,1038^A0B,34,42^FH\\^FDProduto Beneficiado pela Legisla\\87\\C6o de Inform\\A0tica^FS";
            s += "^FT2450,1038^A0B,34,42^FH\\^FDI.E: 06.200.590-1 Ind. Brasileira^FS";
            s += "^FT2410,1038^A0B,34,42^FH\\^FDCNPJ: 08.239.748/0001-53^FS";
            s += "^FT2366,1038^A0B,34,42^FH\\^FDFabricado por: POSITIVO INFORM\\A0TICA^FS";
            s += "^FT3132,980^A0B,74,72^FH\\^FD---^FS";
            s += "^FT1552,1038^A0B,54,56^FH\\^FDConfigura\\87\\C6o:^FS";
            s += "^FT1614,1038^A0B,42,42^FH\\^FD" + configuracao1 + "^FS";
            s += "^FT1676,1038^A0B,42,42^FH\\^FD" + configuracao2 + "^FS";
            s += "^FT1738,1038^A0B,42,42^FH\\^FD" + configuracao3 + "^FS";
            s += "^FT1800,1038^A0B,42,42^FH\\^FD" + configuracao4 + "^FS";
            s += "^FT1862,1038^A0B,42,42^FH\\^FD" + configuracao5 + "^FS";
            s += "^FT1924,1038^A0B,42,42^FH\\^FD" + configuracao6 + "^FS";
            s += "^FT1986,1038^A0B,42,42^FH\\^FD" + configuracao7 + "^FS";
            s += "^FT2048,1038^A0B,42,42^FH\\^FD" + configuracao8 + "^FS";
            s += "^FT2110,1038^A0B,42,42^FH\\^FD" + configuracao9 + "^FS";
            s += "^FT2172,1038^A0B,42,42^FH\\^FD" + configuracao10 + "^FS";
            s += "^BY6,6,72^FT550,990^BCB,,Y,N";
            s += "^FD>:XXXXXXXX^FS";
            s += "^BY6,6,70^FT340,990^BCB,,Y,N";
            s += "^FD>:" + NS + "^FS";
            s += "^PQ1,0,1,Y^XZ";
        }



        public void EtiqEANHorizontal()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW1320";
            s += "^LL600";
            s += "^LS0";
            s += "^FT190,70^A0N,43,39^FH\\^FD" + codPositivo + "^FS";
            s += "^FT70,110^A0N,35,30^FH\\^FD" + produto + "^FS";
            s += "^FO60,130^GB500,0,3^FS";
            s += "^FT70,180^A0N,31,33^FH\\^FDN\\E9MERO DE S\\90RIE^FS";
            s += "^BY3,5,45^FT60,235^BCN,,Y,N";
            s += "^FD>:" + NS + "^FS";
            s += "^FT70,315^A0N,31,33^FH\\^FDORDEM DE PRODU\\80\\C7O^FS";
            s += "^BY3,5,45^FT60,365^BCN,,Y,N";
            s += "^FD>:XXXXXXXX^FS";
            s += "^FO60,430^GB500,0,3^FS";
            s += "^FT70,460^A0N,31,33^FH\\^FDEAN DO PRODUTO^FS";
            s += "^BY3,5,45^FT60,510^BEN,,Y,N";
            s += "^FD" + CodEAN + "^FS";
            s += "^FO700,90^GB450,0,3^FS";
            s += "^FT710,130^A0N,35,29^FH\\^FDConfigura\\87\\C6o:^FS";
            s += "^FT710,160^A0N,25,23^FH\\^FD" + configuracao1 + "^FS";
            s += "^FT710,185^A0N,25,23^FH\\^FD" + configuracao2  + "^FS";
            s += "^FT710,210^A0N,25,23^FH\\^FD" + configuracao3 + "^FS";
            s += "^FT710,235^A0N,25,23^FH\\^FD" + configuracao4 + "^FS";
            s += "^FT710,260^A0N,25,23^FH\\^FD" + configuracao5 + "^FS";
            s += "^FT710,285^A0N,25,23^FH\\^FD" + configuracao6 + "^FS";
            s += "^FT710,310^A0N,25,23^FH\\^FD" + configuracao7 + "^FS";
            s += "^FT710,335^A0N,25,23^FH\\^FD" + configuracao8 + "^FS";
            s += "^FT710,360^A0N,25,23^FH\\^FD" + configuracao9 + "^FS";
            s += "^FT710,385^A0N,25,23^FH\\^FD" + configuracao10 + "^FS";
            s += "^FT710,410^A0N,25,23^FH\\^FD" + configuracao11 + "^FS";
            s += "^FO700,450^GB450,0,3^FS";
            s += "^FT700,470^A0N,20,23^FH\\^FDFabricado por: POSITIVO INFORM\\b5TICA^FS";
            s += "^FT700,490^A0N,20,23^FH\\^FDCNPJ: 81.243.735/0001-48^FS";
            s += "^FT700,510^A0N,20,23^FH\\^FDI.E: 10.173.024-73 Ind. Brasileira^FS";
            s += "^FT700,530^A0N,20,23^FH\\^FDProduto Beneficiado pela Legisla\\87\\C6o de Inform\\A0tica^FS";
            s += "^PQ1,0,1,Y^XZ";

        }

        public void EtiqEANHorizontal200()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW880";
            s += "^LL400";
            s += "^LS0";
            s += "^FT127,47^A0N,29,26^FH\\^FD" + codPositivo + "^FS";
            s += "^FT47,73^A0N,23,20^FH\\^FD" + produto + "^FS";
            s += "^FO40,87^GB300,0,3^FS";
            s += "^FT47,120^A0N,21,22^FH\\^FDN\\E9MERO DE S\\90RIE^FS";
            s += "^BY3,3,30^FT40,157^BCN,,Y,N";
            s += "^FD>:" + NS + "^FS";
            s += "^FT47,210^A0N,21,22^FH\\^FDORDEM DE PRODU\\80\\C7O^FS";
            s += "^BY3,3,30^FT40,243^BCN,,Y,N";
            s += "^FD>:XXXXXXXX^FS";
            s += "^FO40,287^GB300,0,3^FS";
            s += "^FT47,307^A0N,21,22^FH\\^FDEAN DO PRODUTO^FS";
            s += "^BY3,3,30^FT40,340^BEN,,Y,N";
            s += "^FD" + CodEAN + "^FS";
            s += "^FO467,60^GB300,0,2^FS";
            s += "^FT473,87^A0N,23,20^FH\\^FDConfigura\\87\\C6o:^FS";
            s += "^FT473,107^A0N,17,15^FH\\^FD" + configuracao1 + "^FS";
            s += "^FT473,123^A0N,17,15^FH\\^FD" + configuracao2 + "^FS";
            s += "^FT473,140^A0N,17,15^FH\\^FD" + configuracao3 + "^FS";
            s += "^FT473,157^A0N,17,15^FH\\^FD" + configuracao4 + "^FS";
            s += "^FT473,173^A0N,17,15^FH\\^FD" + configuracao5 + "^FS";
            s += "^FT473,190^A0N,17,15^FH\\^FD" + configuracao6 + "^FS";
            s += "^FT473,207^A0N,17,15^FH\\^FD" + configuracao7 + "^FS";
            s += "^FT473,223^A0N,17,15^FH\\^FD" + configuracao8 + "^FS";
            s += "^FT473,240^A0N,17,15^FH\\^FD" + configuracao9 + "^FS";
            s += "^FT473,257^A0N,17,15^FH\\^FD" + configuracao10 + "^FS";
            s += "^FT473,273^A0N,17,15^FH\\^FD" + configuracao11 + "^FS";
            s += "^FO467,300^GB300,0,2^FS";
            s += "^FT467,313^A0N,13,15^FH\\^FDFabricado por: POSITIVO INFORM\\b5TICA^FS";
            s += "^FT467,327^A0N,13,15^FH\\^FDCNPJ: 81.243.735/0001-48^FS";
            s += "^FT467,340^A0N,13,15^FH\\^FDI.E: 10.173.024-73 Ind. Brasileira^FS";
            s += "^FT467,353^A0N,13,15^FH\\^FDProduto Beneficiado pela Legisla\\87\\C6o de Inform\\A0tica^FS";
            s += "^PQ1,0,1,Y^XZ";
        }

        public void EtiqEANHorizontal600()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW2640";
            s += "^LL1200";
            s += "^LS0";
            s += "^FT380,140^A0N,86,78^FH\\^FD" + codPositivo + "^FS";
            s += "^FT140,220^A0N,70,60^FH\\^FD" + produto + "^FS";
            s += "^FO140,260^GB1000,0,6^FS";
            s += "^FT140,360^A0N,62,66^FH\\^FDN\\E9MERO DE S\\90RIE^FS";
            s += "^BY6,10,90^FT120,470^BCN,,Y,N";
            s += "^FD>:" + NS + "^FS";
            s += "^FT140,630^A0N,62,66^FH\\^FDORDEM DE PRODU\\80\\C7O^FS";
            s += "^BY6,10,90^FT120,730^BCN,,Y,N";
            s += "^FD>:XXXXXXXX^FS";
            s += "^FO140,840^GB1000,0,6^FS";
            s += "^FT140,920^A0N,62,66^FH\\^FDEAN DO PRODUTO^FS";
            s += "^BY6,10,90^FT120,1020^BEN,,Y,N";
            s += "^FD" + CodEAN + "^FS";
            s += "^FO1400,160^GB900,0,6^FS";
            s += "^FT1420,260^A0N,70,58^FH\\^FDConfigura\\87\\C6o:^FS";
            s += "^FT1420,320^A0N,50,46^FH\\^FD" + configuracao1 + "^FS";
            s += "^FT1420,370^A0N,50,46^FH\\^FD" + configuracao2 + "^FS";
            s += "^FT1420,420^A0N,50,46^FH\\^FD" + configuracao3 + "^FS";
            s += "^FT1420,470^A0N,50,46^FH\\^FD" + configuracao4 + "^FS";
            s += "^FT1420,520^A0N,50,46^FH\\^FD" + configuracao5 + "^FS";
            s += "^FT1420,570^A0N,50,46^FH\\^FD" + configuracao6 + "^FS";
            s += "^FT1420,620^A0N,50,46^FH\\^FD" + configuracao7 + "^FS";
            s += "^FT1420,675^A0N,50,46^FH\\^FD" + configuracao8 + "^FS";
            s += "^FT1420,720^A0N,50,46^FH\\^FD" + configuracao9 + "^FS";
            s += "^FT1420,770^A0N,50,46^FH\\^FD" + configuracao10 + "^FS";
            s += "^FT1420,820^A0N,50,46^FH\\^FD" + configuracao11 + "^FS";
            s += "^FO1400,870^GB900,0,6^FS";
            s += "^FT1400,940^A0N,40,46^FH\\^FDFabricado por: POSITIVO INFORM\\b5TICA^FS";
            s += "^FT1400,980^A0N,40,46^FH\\^FDCNPJ: 81.243.735/0001-48^FS";
            s += "^FT1400,1020^A0N,40,46^FH\\^FDI.E: 10.173.024-73 Ind. Brasileira^FS";
            s += "^FT1400,1060^A0N,40,46^FH\\^FDProduto Beneficiado pela Legisla\\87\\C6o de Inform\\A0tica^FS";
            s += "^PQ1,0,1,Y^XZ";
        }



        public void EtiqCelularNova()
        {
            s = ""; 
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ ";
            s += "^XA";
            s += "^MMT";
            s += "^PW1320";
            s += "^LL600";
            s += "^LS0";
            s += "^FT350,100^A0N,80,80^FH\\^FDPOSITIVO " + configuracao1 + "^FS";

            s += "^BY2,2,40^FT70,200^BCN,,N,N";
            s += "^FD" + IMEI1 + "^FS";
            s += "^FT70,230^A0N,33,33^FH\\^FDIMEI 1:^FS";
            s += "^FT170,230^A0N,33,43^FH\\^FD" + IMEI1 + "^FS";

            s += "^BY2,2,40^FT70,300^BCN,,N,N";
            s += "^FD" + IMEI2 + "^FS";
            s += "^FT70,330^A0N,33,33^FH\\^FDIMEI 2:^FS";
            s += "^FT170,330^A0N,33,43^FH\\^FD" + IMEI2 + "^FS";

            s += "^BY2,2,40^FT70,400^BCN,,N,N";
            s += "^FD" + NS + "^FS";
            s += "^FT70,430^A0N,33,33^FH\\^FDSN:^FS";
            s += "^FT170,430^A0N,33,43^FH\\^FD" + NS + "^FS";

            s += "^FT70,490^A0N,31,33^FH\\^FDEAN:^FS";
            s += "^BY3,5,45^FT150,510^BEN,,Y,N";
            s += "^FD" + CodEAN + "^FS";

            s += "^FT710,190^A0N,50,50^FH\\^FDCOR: " + configuracao2 + "^FS";
            s += "^FT710,300^A0N,40,40^FH\\^FDANATEL^FS";
            s += "^FT710,340^A0N,40,40^FH\\^FD" + Anatel + "^FS";
            s += "^FT700,460^A0N,30,50^FH\\^FDPOSITIVO TECNOLOGIA^FS";
            s += "Inform\\A0tica^FS";
            s += "^PQ1,0,1,Y^XZ";

            /*
            s = "";
            s += "^XA~TA000~JSR^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR2,2^JUS^LRN^CI0^XZ";
            s += "~DG000.GRF,03840,012,";
            s += ",::::::::::::::::::::N03FFBIBFBF,N0H5F57F5FD7,N0JFEFEFHF80,N0H5F57F5FD7,N03BFBIBFBB80,N05D5F55D575,N0PF80,N0H75DD5755D,N0BFBFBFJF80,N05D57D5D57D,N0PF80,N0H5F57F5FD7,N0FBHBHFHBFB80,N0J57F55D7,Q07FE00FF80,Q07550175,Q03BF00FF80,Q05D5005D,Q07FF00FF80,Q07550175,Q03BB00BB,Q057F01D7,Q07FE80FE80,Q057F01D7,Q03BB81BB,Q0755D575,Q03FKF80,Q01D5755D,Q03BFJF,Q01D5D57D,R0FEFEFE,Q017F5FD4,R07FBBF8,R07F5FD4,S0IFC0,S01D5,,::P0157F54,P03BIBF,O05F57F5FC0,O0IFEFEFF0,N015F57F5FD0,N03FBFBFFBFC,N05D5F55D574,N03FMFE,N0H75DD5755D,N03FBFBBFHFE,N0H5F57F5FD7,N0HFEFLF,M01D5F57F5FD7,N0HFBA003BFB,M01D5C0I07D7,N0FE80J0FE80,M017D0J0175,M01BE0K0HF,M01770K05D,M01FE0K0HF80,M01D50K0D7,M01BF0K0BF,M01D50J01D7,N0HF80I01FE,M01D5D0I07D7,N0BFBFBFFBFF,N05F5F55D575,N0PF,N0H75DD5755D,N03FHFHBIFE,N0H5F57F5FD6,N03EEFFEFEFC,N015F57F5FD4,N03BBFIFHB8,N015F57F5FD4,O01EFEFHFC0,O015755D5,Q03BFF0,R01440,,T010,T0BF,N0D580055FC0,N0HF8007EFF0,N0D5001F5FD0,N0BF803FFBFC,M015D0055D574,N0FE803FIFC,M01770055755C,N0FB007FBFBA,M01D5007F5FD7,M01FF007FJF,M01D5007F5FD7,M01FB00FFB3BB,M017700D5415D,N0FE00FFC0FF80,M017D01558175,M01BF01BF80FF80,M017701D5005D,M01FF81FF80FF80,M01D5817F00D7,N0BF83BB00BF80,M01D5C57F00D7,N0KFE00FE80,N0H75DD5015D,N0BFHFBE00FF,N05F5F540075,N07FIFE00FF80,N0H75DD4015D,N03BFBFC00BB,N015F57C01D7,O0EFHF800FF,N015F570H0H1,O03BBE0,P054,,:::N0LFEFHF80,N0H5F57F5FD7,N03FHFIBFBF,N0H5F57F5FD7,N0JFEFEFHF80,N0H75DD5755D,N0BFHFBFJF80,N05D5F55D575,N0PF80,N0H75DD5755D,N07FFBFFBFBB80,N0H5F57F5FD7,N0HFEFLF80,,:::U0155,U01FF80,U01D7,U01FF80,U01D7,U01BF80,U01D7,V0HF80,U015D,U01FF80,U0175,N0AEEFABEFHF80,N0H5F57F5FD7,N07FFBFJFB80,N0H5F57F5FD7,N0FEEFFEFEFF80,N0H5F57F5FD7,N0BFBFBBFIF80,N0H75DD5755D,N0PF80,N07D5755D575,N0BFBFBFFBFF80,N0H5F57F5FD7,N0HEFEHEJF80,U01D7,U01BF80,U01D7,U01FF80,U015D,U01FF80,U0175,V0FE80,U01D7,U01BB80,U0155,,::P040,N0JFEFIFE80,N07D5755D575,N0BFBFBFFBFF80,N0H5F57F5FD7,N0LFEFHF80,N0H5F57F5FD7,N03FHFHBHFBF,N0H5F57F5FD7,N0FEEFIFEFF80,N0H75DD5755D,N0BFBFBFJF80,N05F5F55D575,O0A8A828H8A,,:::V015,V0HF80,U0H5D,T07FHF80,S01D575,R03BBFBB80,Q057F5FD7,P01FHFEFHF80,O01F57F5FD7,O0BFBIBFBB,N05D57D5D57D,N0PF80,N0H75DD5755D,N0BFHFBFHFE0,N05D5F55D5,N0FEFHFE80,N0H5F574,N07FFB80,N0H5F4,N0FE,N05F55,N0BFHFA0,N0H75DD5,N0LFC0,N07D5755D5,N03BFBIBFB8,N0H5F57F5FD7,N0LFEFHF80,N0H5F57F5FD7,N03BFBIBFBB,O0157D5D57D,Q0MF80,Q05D5755D,R03BFIF80,R015D575,U0IF80,U01D7,V03B80,V017,X080,Q0H15,Q0FBBF8,O015DD575,O03FKFC0,N0155755D570,N03BFBIBFB8,N015F57F5FD4,N03FMFC,N0H5F57F5FD6,N03FBFBFFBFE,N05D57D5D57D,N0PF,M01775DD5755D,N0BFHFHBJF,M01D5C0I07D7,N0FE80J0HF,M01D50J01D7,M01FF0K0FB,M01D50K0D7,M01FE0K0HF80,M015F0K075,M01BE0K0HF,M01770K05D,N0FE80J0HF80,M01D5D0H017D7,N0BFFA003FBF,N0D5F57F5FD7,N0LFEFHF,N0H5F57F5FD7,N03FBFBFFBFE,N07D57D5D57C,N03FMFE,N0375DD5755C,N03FBFBBFHFC,N015F57F5FD4,O07EFJFE0,O01F57F5FC0,P03BFFBF,Q057F50,,::::::::::::::::::::::::::::~DG001.GRF,03072,012,";
            s += ",::::::::::::::::::::::::::M0EC0,L0IF8,K03FBEA,K07FIF,K0AEEAE80,J01FJFC0,J03BBFBBA0,J03FJFE0,J02EKE0,J07FKFH04,J07BEBIB802,J0MF801,J0ME80080,J0MF80080,J0BEBHBEB80080,J0MF80060,J0EAEEAEE80060,J0F7FJF80070,J07BFBFBF80038,J07FKFI038,J02EKEI02C,J03FJFE0H01C,J03BAFBBA0H01E,J01FJFC0H01E,K0KE80I0E,K07FIFJ01F,J083FBFA0I01B80,J0C0FHF80I01F80,J0E00EA0J02E80,J0F0N03FC0,J0BC0M03B80,J0FE0M07FC0,J0HE80L06EC0,J0HFC0L0HFE0,J0FBE0K01BBE0,J0IFC0J03FFE0,J0JE80I0JE0,J0JFE0H01FHFE0,J0IBFBA00BHBFA0,J0RFE0,J0EAEEAEME0,J0RFE0,J0FBFBFBFBFBFBE0,J0RFC0,J0REC0,J0RFC0,J0HBABBFBAAFBA80,J0RF80,J0RE80,J0RF,J0FBFBFBFBFBFB,J0QFE,J0EAEEAEKEC,J0QF8,J0IBFBHBFBHB8,J0PFE0,J0PEC0,J03FNF80,K03EBJBEA,L0MF0,M0KE80,O0FE0,,:J0E0,J0F0,J0F8,J0HF,J0HEC0,J0HFE0,J03BA8,J01FFC,K06EE,K01FFC0,K01FBE0,K01DFF0,L0CEEC,K01C3FE,K0180BF80,K01C07FC0,L0C00EE0,K01C1FFE0,J0FBFBFBE0,J0LFE0,J0ME0,J0LFE0,J0IBFBA,J0JFC0,J0AE80,,::J080,J0F8,J0BF,J0IF0,J0JE,J0KF0,J07BFBFB,K07FIFE0,L0KE0,M0IFE0,N0HBA0,M01FFE0,M0IE80,L03FHF,L0FBF8,K03FHF0,K0IE80,J03FHF,J0IB8,J0IF0,J0JE,J0JFC0,J0FBFBF8,J01FJFC0,K02EIEA0,L01FHFE0,J08003BBA0,J0E0H03FE0,J0E80H02E0,J0FC0I060,J0FB,J0HFC0,J0IE0,J07FF8,J01FBA,K07FF,L0HE80,K01FFE0,K01DBF8,K01CFFC,L0C2EE,K01C0FF80,K01803B80,K01C01FE0,L0C2EHE0,J0LFE0,J0FBFBFBE0,J0LFE0,J0LEA0,J0KFE,J0BFBB80,J010,,:::P0C0,J0E0J0E0,J0BA0I0A0,J0HFE0H0E0,J0JEH0A0,J0JFC0E0,J0FBFBE8E0,J07FJFE0,K06EJE0,L0HF7FE0,M0HBFA0,N0HFE0,O0HE0,P0E0,::P0A0,P0E0,J0A0J0A0,J0HFJ0E0,J0IEI0E0,J0F7FE,J0FBEBA0,J0KFE,J0LEC0,J0E7FIFE0,J0A03BBFA0,J0E007FFE0,J0E00E6EA0,J0E00707E0,J0E00B00E0,J0E00700E0,J0E00E00E0,J0E00700E0,J0200F00A0,M0700E0,P0E0,:J0C0J0E0,J0FC0I0E0,J0HE80H020,J0IFC,J0BEBB80,J0KF8,J0LE80,J0F7FIFE0,J0E1FBFBE0,J0E01FHFE0,J0E0H0IE0,J0E0H01FE0,J0A0I01A0,J0E0J020,J0E0,:J020,,:::::::::::::::::::::::::^XA";
            s += "^MMT";
            s += "^PW780";
            s += "^LL0691";
            s += "^LS0";
            s += "^FT440,350^XG000.GRF,1,1^FS";
            s += "^FT160,780^XG001.GRF,1,1^FS";
            s += "^FT480,420^A0R,60,80^FH\\^FD" + configuracao1 + "^FS";
            s += "^FT440,590^A0R,35,35^FH\\^FD O celular ^FS";
            s += "^FT400,580^A0R,35,35^FH\\^FDinteligente^FS";
            s += "^FT360,580^A0R,35,35^FH\\^FDda Positivo ^FS";
            s += "^FT310,580^A0R,35,35^FH\\^FDCor:^FS";
            s += "^FT310,640^A0R,35,35^FH\\^FD" + configuracao2 + "^FS";
            s += "^FT280,580^A0R,25,25^FH\\^FDOP:^FS";
            s += "^FT280,640^A0R,25,25^FH\\^FDXXXXXXXX^FS";
            s += "^BY2,2,40^FT410,50^BCR,,N,N";
            s += "^FD" + IMEI1 + "^FS";
            s += "^FT380,50^A0R,33,33^FH\\^FDIMEI 1:^FS";
            s += "^FT380,160^A0R,33,43^FH\\^FD" + IMEI1 + "^FS";
            s += "^BY2,2,40^FT330,50^BCR,,N,N";
            s += "^FD" + IMEI2 + "^FS";
            s += "^FT300,50^A0R,33,33^FH\\^FDIMEI 2:^FS";
            s += "^FT300,160^A0R,33,43^FH\\^FD" + IMEI2 + "^FS";
            s += "^BY3,3,34^FT250,50^BCR,,N,N";
            s += "^FD" + NS + "^FS";
            s += "^FT220,50^A0R,33,33^FH\\^FDSN:^FS";
            s += "^FT220,140^A0R,33,43^FH\\^FD" + NS + "^FS";
            s += "^FT170,50^A0R,25,24^FH\\^FDEAN:^FS";
            s += "^BY4,2,80^FT120,110^BER,,Y,N";
            s += "^FD" + CodEAN + "^FS";
            s += "^FT40,40^A0R,25,25^FH\\^FDFabricado no Brasil^FS";
            s += "^FT40,250^A0R,25,25^FH\\^FDProduto Beneficiado pela Legisla\\87\\C6o da Inform\\A0tica^FS";
            s += "^FT140,570^A0R,25,25^FH\\^FD" + Anatel + "^FS";
            s += "^PQ1,0,1,Y^XZ";
            s += "^XA^ID000.GRF^FS^XZ";
            s += "^XA^ID001.GRF^FS^XZ";
             */ 
        }

        public void EtiqCelularNova200()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ ";
            s += "^XA";
            s += "^MMT";
            s += "^PW880";
            s += "^LL400";
            s += "^LS0";
            s += "^FT233,67^A0N,53,53^FH\\^FDPOSITIVO " + configuracao1 + "^FS";

            s += "^BY2,2,20^FT47,133^BCN,,N,N";
            s += "^FD" + IMEI1 + "^FS";
            s += "^FT47,153^A0N,22,22^FH\\^FDIMEI 1:^FS";
            s += "^FT113,153^A0N,22,29^FH\\^FD" + IMEI1 + "^FS";

            s += "^BY2,2,27^FT47,200^BCN,,N,N";
            s += "^FD" + IMEI2 + "^FS";
            s += "^FT47,220^A0N,22,22^FH\\^FDIMEI 2:^FS";
            s += "^FT113,220^A0N,22,29^FH\\^FD" + IMEI2 + "^FS";

            s += "^BY2,2,27^FT47,267^BCN,,N,N";
            s += "^FD" + NS + "^FS";
            s += "^FT47,287^A0N,22,22^FH\\^FDSN:^FS";
            s += "^FT113,287^A0N,22,29^FH\\^FD" + NS + "^FS";

            s += "^FT47,327^A0N,21,22^FH\\^FDEAN:^FS";
            s += "^BY3,3,30^FT100,340^BEN,,Y,N";
            s += "^FD" + CodEAN + "^FS";

            s += "^FT473,127^A0N,33,33^FH\\^FDCOR: " + configuracao2 + "^FS";
            s += "^FT473,200^A0N,27,27^FH\\^FDANATEL^FS";
            s += "^FT473,227^A0N,27,27^FH\\^FD" + Anatel + "^FS";
            s += "^FT467,307^A0N,20,33^FH\\^FDPOSITIVO TECNOLOGIA^FS";
            s += "Inform\\A0tica^FS";
            s += "^PQ1,0,1,Y^XZ";
        }


        public void EtiqCelularNova600()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ ";
            s += "^XA";
            s += "^MMT";
            s += "^PW2640";
            s += "^LL1200";
            s += "^LS0";
            s += "^FT700,200^A0N,160,160^FH\\^FDPOSITIVO " + configuracao1 + "^FS";

            s += "^BY4,4,80^FT140,400^BCN,,N,N";
            s += "^FD" + IMEI1 + "^FS";
            s += "^FT140,460^A0N,66,66^FH\\^FDIMEI 1:^FS";
            s += "^FT340,460^A0N,66,86^FH\\^FD" + IMEI1 + "^FS";

            s += "^BY4,4,80^FT140,600^BCN,,N,N";
            s += "^FD" + IMEI2 + "^FS";
            s += "^FT140,660^A0N,66,66^FH\\^FDIMEI 2:^FS";
            s += "^FT340,660^A0N,66,86^FH\\^FD" + IMEI2 + "^FS";

            s += "^BY4,4,80^FT140,800^BCN,,N,N";
            s += "^FD" + NS + "^FS";
            s += "^FT140,860^A0N,66,66^FH\\^FDSN:^FS";
            s += "^FT340,860^A0N,66,86^FH\\^FD" + NS + "^FS";

            s += "^FT140,980^A0N,62,66^FH\\^FDEAN:^FS";
            s += "^BY6,10,90^FT300,1020^BEN,,Y,N";
            s += "^FD" + CodEAN + "^FS";

            s += "^FT1420,380^A0N,100,100^FH\\^FDCOR: " + configuracao2 + "^FS";
            s += "^FT1420,600^A0N,80,80^FH\\^FDANATEL^FS";
            s += "^FT1420,680^A0N,80,80^FH\\^FD" + Anatel + "^FS";
            s += "^FT1400,920^A0N,60,100^FH\\^FDPOSITIVO TECNOLOGIA^FS";
            s += "Inform\\A0tica^FS";
            s += "^PQ1,0,1,Y^XZ";
        }



        public void Quantum()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ ";
            s += "^XA";
            s += "^MMT";
            s += "^PW1320";
            s += "^LL600";
            s += "^LS0";
            s += "^FT350,100^A0N,80,80^FH\\^FDQUANTUM " + configuracao1 + "^FS";

            s += "^BY2,2,40^FT70,200^BCN,,N,N";
            s += "^FD" + IMEI1 + "^FS";
            s += "^FT70,230^A0N,33,33^FH\\^FDIMEI 1:^FS";
            s += "^FT170,230^A0N,33,43^FH\\^FD" + IMEI1 + "^FS";

            s += "^BY2,2,40^FT70,300^BCN,,N,N";
            s += "^FD" + IMEI2 + "^FS";
            s += "^FT70,330^A0N,33,33^FH\\^FDIMEI 2:^FS";
            s += "^FT170,330^A0N,33,43^FH\\^FD" + IMEI2 + "^FS";

            s += "^BY2,2,40^FT70,400^BCN,,N,N";
            s += "^FD" + NS + "^FS";
            s += "^FT70,430^A0N,33,33^FH\\^FDSN:^FS";
            s += "^FT170,430^A0N,33,43^FH\\^FD" + NS + "^FS";

            s += "^FT70,490^A0N,31,33^FH\\^FDEAN:^FS";
            s += "^BY3,5,45^FT150,510^BEN,,Y,N";
            s += "^FD" + CodEAN + "^FS";

            s += "^FT710,190^A0N,50,50^FH\\^FDCOR: " + configuracao2 + "^FS";
            s += "^FT710,300^A0N,40,40^FH\\^FDANATEL^FS";
            s += "^FT710,340^A0N,40,40^FH\\^FD" + Anatel + "^FS";
           // s += "^FT700,460^A0N,30,50^FH\\^FDPOSITIVO TECNOLOGIA^FS";
            s += "Inform\\A0tica^FS";
            s += "^PQ1,0,1,Y^XZ";

            /*
            s = "";
            s += "^XA~TA000~JSR^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR2,2^JUS^LRN^CI0^XZ";
            //s += "~DG000.GRF,03840,012,";
            s += ",::::::::::::::::::::N03FFBIBFBF,N0H5F57F5FD7,N0JFEFEFHF80,N0H5F57F5FD7,N03BFBIBFBB80,N05D5F55D575,N0PF80,N0H75DD5755D,N0BFBFBFJF80,N05D57D5D57D,N0PF80,N0H5F57F5FD7,N0FBHBHFHBFB80,N0J57F55D7,Q07FE00FF80,Q07550175,Q03BF00FF80,Q05D5005D,Q07FF00FF80,Q07550175,Q03BB00BB,Q057F01D7,Q07FE80FE80,Q057F01D7,Q03BB81BB,Q0755D575,Q03FKF80,Q01D5755D,Q03BFJF,Q01D5D57D,R0FEFEFE,Q017F5FD4,R07FBBF8,R07F5FD4,S0IFC0,S01D5,,::P0157F54,P03BIBF,O05F57F5FC0,O0IFEFEFF0,N015F57F5FD0,N03FBFBFFBFC,N05D5F55D574,N03FMFE,N0H75DD5755D,N03FBFBBFHFE,N0H5F57F5FD7,N0HFEFLF,M01D5F57F5FD7,N0HFBA003BFB,M01D5C0I07D7,N0FE80J0FE80,M017D0J0175,M01BE0K0HF,M01770K05D,M01FE0K0HF80,M01D50K0D7,M01BF0K0BF,M01D50J01D7,N0HF80I01FE,M01D5D0I07D7,N0BFBFBFFBFF,N05F5F55D575,N0PF,N0H75DD5755D,N03FHFHBIFE,N0H5F57F5FD6,N03EEFFEFEFC,N015F57F5FD4,N03BBFIFHB8,N015F57F5FD4,O01EFEFHFC0,O015755D5,Q03BFF0,R01440,,T010,T0BF,N0D580055FC0,N0HF8007EFF0,N0D5001F5FD0,N0BF803FFBFC,M015D0055D574,N0FE803FIFC,M01770055755C,N0FB007FBFBA,M01D5007F5FD7,M01FF007FJF,M01D5007F5FD7,M01FB00FFB3BB,M017700D5415D,N0FE00FFC0FF80,M017D01558175,M01BF01BF80FF80,M017701D5005D,M01FF81FF80FF80,M01D5817F00D7,N0BF83BB00BF80,M01D5C57F00D7,N0KFE00FE80,N0H75DD5015D,N0BFHFBE00FF,N05F5F540075,N07FIFE00FF80,N0H75DD4015D,N03BFBFC00BB,N015F57C01D7,O0EFHF800FF,N015F570H0H1,O03BBE0,P054,,:::N0LFEFHF80,N0H5F57F5FD7,N03FHFIBFBF,N0H5F57F5FD7,N0JFEFEFHF80,N0H75DD5755D,N0BFHFBFJF80,N05D5F55D575,N0PF80,N0H75DD5755D,N07FFBFFBFBB80,N0H5F57F5FD7,N0HFEFLF80,,:::U0155,U01FF80,U01D7,U01FF80,U01D7,U01BF80,U01D7,V0HF80,U015D,U01FF80,U0175,N0AEEFABEFHF80,N0H5F57F5FD7,N07FFBFJFB80,N0H5F57F5FD7,N0FEEFFEFEFF80,N0H5F57F5FD7,N0BFBFBBFIF80,N0H75DD5755D,N0PF80,N07D5755D575,N0BFBFBFFBFF80,N0H5F57F5FD7,N0HEFEHEJF80,U01D7,U01BF80,U01D7,U01FF80,U015D,U01FF80,U0175,V0FE80,U01D7,U01BB80,U0155,,::P040,N0JFEFIFE80,N07D5755D575,N0BFBFBFFBFF80,N0H5F57F5FD7,N0LFEFHF80,N0H5F57F5FD7,N03FHFHBHFBF,N0H5F57F5FD7,N0FEEFIFEFF80,N0H75DD5755D,N0BFBFBFJF80,N05F5F55D575,O0A8A828H8A,,:::V015,V0HF80,U0H5D,T07FHF80,S01D575,R03BBFBB80,Q057F5FD7,P01FHFEFHF80,O01F57F5FD7,O0BFBIBFBB,N05D57D5D57D,N0PF80,N0H75DD5755D,N0BFHFBFHFE0,N05D5F55D5,N0FEFHFE80,N0H5F574,N07FFB80,N0H5F4,N0FE,N05F55,N0BFHFA0,N0H75DD5,N0LFC0,N07D5755D5,N03BFBIBFB8,N0H5F57F5FD7,N0LFEFHF80,N0H5F57F5FD7,N03BFBIBFBB,O0157D5D57D,Q0MF80,Q05D5755D,R03BFIF80,R015D575,U0IF80,U01D7,V03B80,V017,X080,Q0H15,Q0FBBF8,O015DD575,O03FKFC0,N0155755D570,N03BFBIBFB8,N015F57F5FD4,N03FMFC,N0H5F57F5FD6,N03FBFBFFBFE,N05D57D5D57D,N0PF,M01775DD5755D,N0BFHFHBJF,M01D5C0I07D7,N0FE80J0HF,M01D50J01D7,M01FF0K0FB,M01D50K0D7,M01FE0K0HF80,M015F0K075,M01BE0K0HF,M01770K05D,N0FE80J0HF80,M01D5D0H017D7,N0BFFA003FBF,N0D5F57F5FD7,N0LFEFHF,N0H5F57F5FD7,N03FBFBFFBFE,N07D57D5D57C,N03FMFE,N0375DD5755C,N03FBFBBFHFC,N015F57F5FD4,O07EFJFE0,O01F57F5FC0,P03BFFBF,Q057F50,,::::::::::::::::::::::::::::~DG001.GRF,03072,012,";
            s += ",::::::::::::::::::::::::::M0EC0,L0IF8,K03FBEA,K07FIF,K0AEEAE80,J01FJFC0,J03BBFBBA0,J03FJFE0,J02EKE0,J07FKFH04,J07BEBIB802,J0MF801,J0ME80080,J0MF80080,J0BEBHBEB80080,J0MF80060,J0EAEEAEE80060,J0F7FJF80070,J07BFBFBF80038,J07FKFI038,J02EKEI02C,J03FJFE0H01C,J03BAFBBA0H01E,J01FJFC0H01E,K0KE80I0E,K07FIFJ01F,J083FBFA0I01B80,J0C0FHF80I01F80,J0E00EA0J02E80,J0F0N03FC0,J0BC0M03B80,J0FE0M07FC0,J0HE80L06EC0,J0HFC0L0HFE0,J0FBE0K01BBE0,J0IFC0J03FFE0,J0JE80I0JE0,J0JFE0H01FHFE0,J0IBFBA00BHBFA0,J0RFE0,J0EAEEAEME0,J0RFE0,J0FBFBFBFBFBFBE0,J0RFC0,J0REC0,J0RFC0,J0HBABBFBAAFBA80,J0RF80,J0RE80,J0RF,J0FBFBFBFBFBFB,J0QFE,J0EAEEAEKEC,J0QF8,J0IBFBHBFBHB8,J0PFE0,J0PEC0,J03FNF80,K03EBJBEA,L0MF0,M0KE80,O0FE0,,:J0E0,J0F0,J0F8,J0HF,J0HEC0,J0HFE0,J03BA8,J01FFC,K06EE,K01FFC0,K01FBE0,K01DFF0,L0CEEC,K01C3FE,K0180BF80,K01C07FC0,L0C00EE0,K01C1FFE0,J0FBFBFBE0,J0LFE0,J0ME0,J0LFE0,J0IBFBA,J0JFC0,J0AE80,,::J080,J0F8,J0BF,J0IF0,J0JE,J0KF0,J07BFBFB,K07FIFE0,L0KE0,M0IFE0,N0HBA0,M01FFE0,M0IE80,L03FHF,L0FBF8,K03FHF0,K0IE80,J03FHF,J0IB8,J0IF0,J0JE,J0JFC0,J0FBFBF8,J01FJFC0,K02EIEA0,L01FHFE0,J08003BBA0,J0E0H03FE0,J0E80H02E0,J0FC0I060,J0FB,J0HFC0,J0IE0,J07FF8,J01FBA,K07FF,L0HE80,K01FFE0,K01DBF8,K01CFFC,L0C2EE,K01C0FF80,K01803B80,K01C01FE0,L0C2EHE0,J0LFE0,J0FBFBFBE0,J0LFE0,J0LEA0,J0KFE,J0BFBB80,J010,,:::P0C0,J0E0J0E0,J0BA0I0A0,J0HFE0H0E0,J0JEH0A0,J0JFC0E0,J0FBFBE8E0,J07FJFE0,K06EJE0,L0HF7FE0,M0HBFA0,N0HFE0,O0HE0,P0E0,::P0A0,P0E0,J0A0J0A0,J0HFJ0E0,J0IEI0E0,J0F7FE,J0FBEBA0,J0KFE,J0LEC0,J0E7FIFE0,J0A03BBFA0,J0E007FFE0,J0E00E6EA0,J0E00707E0,J0E00B00E0,J0E00700E0,J0E00E00E0,J0E00700E0,J0200F00A0,M0700E0,P0E0,:J0C0J0E0,J0FC0I0E0,J0HE80H020,J0IFC,J0BEBB80,J0KF8,J0LE80,J0F7FIFE0,J0E1FBFBE0,J0E01FHFE0,J0E0H0IE0,J0E0H01FE0,J0A0I01A0,J0E0J020,J0E0,:J020,,:::::::::::::::::::::::::^XA";
            s += "^MMT";
            s += "^PW780";
            s += "^LL0691";
            s += "^LS0";
            s += "^FT440,350^XG000.GRF,1,1^FS";
            s += "^FT160,780^XG001.GRF,1,1^FS";

            s += "^FT480,50^A0R,60,80^FH\\^FDQUANTUM ^FS";
            s += "^FT480,420^A0R,60,80^FH\\^FD" + configuracao1 + "^FS";
            s += "^FT310,580^A0R,35,35^FH\\^FDCor:^FS";
            s += "^FT310,640^A0R,35,35^FH\\^FD" + configuracao2 + "^FS";
            s += "^FT280,580^A0R,25,25^FH\\^FDOP:^FS";
            s += "^FT280,640^A0R,25,25^FH\\^FDXXXXXXXX^FS";
            s += "^BY2,2,40^FT410,50^BCR,,N,N";
            s += "^FD" + IMEI1 + "^FS";
            s += "^FT380,50^A0R,33,33^FH\\^FDIMEI 1:^FS";
            s += "^FT380,160^A0R,33,43^FH\\^FD" + IMEI1 + "^FS";
            s += "^BY2,2,40^FT330,50^BCR,,N,N";
            s += "^FD" + IMEI2 + "^FS";
            s += "^FT300,50^A0R,33,33^FH\\^FDIMEI 2:^FS";
            s += "^FT300,160^A0R,33,43^FH\\^FD" + IMEI2 + "^FS";
            s += "^BY3,3,34^FT250,50^BCR,,N,N";
            s += "^FD" + NS + "^FS";
            s += "^FT220,50^A0R,33,33^FH\\^FDSN:^FS";
            s += "^FT220,140^A0R,33,43^FH\\^FD" + NS + "^FS";
            s += "^FT170,50^A0R,25,24^FH\\^FDEAN:^FS";
            s += "^BY4,2,80^FT120,110^BER,,Y,N";
            s += "^FD" + CodEAN + "^FS";
            s += "^FT40,40^A0R,25,25^FH\\^FDFabricado no Brasil^FS";
            s += "^FT40,250^A0R,25,25^FH\\^FDProduto Beneficiado pela Legisla\\87\\C6o da Inform\\A0tica^FS";
            s += "^FT140,570^A0R,25,25^FH\\^FD" + Anatel + "^FS";
            s += "^PQ1,0,1,Y^XZ";
            s += "^XA^ID000.GRF^FS^XZ";
            s += "^XA^ID001.GRF^FS^XZ";
             */ 
        }

        public void Quantum200()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ ";
            s += "^XA";
            s += "^MMT";
            s += "^PW880";
            s += "^LL400";
            s += "^LS0";
            s += "^FT233,67^A0N,53,53^FH\\^FDQUANTUM " + configuracao1 + "^FS";

            s += "^BY2,2,20^FT47,133^BCN,,N,N";
            s += "^FD" + IMEI1 + "^FS";
            s += "^FT47,153^A0N,22,22^FH\\^FDIMEI 1:^FS";
            s += "^FT113,153^A0N,22,29^FH\\^FD" + IMEI1 + "^FS";

            s += "^BY2,2,27^FT47,200^BCN,,N,N";
            s += "^FD" + IMEI2 + "^FS";
            s += "^FT47,220^A0N,22,22^FH\\^FDIMEI 2:^FS";
            s += "^FT113,220^A0N,22,29^FH\\^FD" + IMEI2 + "^FS";

            s += "^BY2,2,27^FT47,267^BCN,,N,N";
            s += "^FD" + NS + "^FS";
            s += "^FT47,287^A0N,22,22^FH\\^FDSN:^FS";
            s += "^FT113,287^A0N,22,29^FH\\^FD" + NS + "^FS";

            s += "^FT47,327^A0N,21,22^FH\\^FDEAN:^FS";
            s += "^BY3,3,30^FT100,340^BEN,,Y,N";
            s += "^FD" + CodEAN + "^FS";

            s += "^FT473,127^A0N,33,33^FH\\^FDCOR: " + configuracao2 + "^FS";
            s += "^FT473,200^A0N,27,27^FH\\^FDANATEL^FS";
            s += "^FT473,227^A0N,27,27^FH\\^FD" + Anatel + "^FS";

            s += "Inform\\A0tica^FS";
            s += "^PQ1,0,1,Y^XZ";
        }


        public void Quantum600()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ ";
            s += "^XA";
            s += "^MMT";
            s += "^PW2640";
            s += "^LL1200";
            s += "^LS0";
            s += "^FT700,200^A0N,160,160^FH\\^FDQUANTUM " + configuracao1 + "^FS";

            s += "^BY4,4,80^FT140,400^BCN,,N,N";
            s += "^FD" + IMEI1 + "^FS";
            s += "^FT140,460^A0N,66,66^FH\\^FDIMEI 1:^FS";
            s += "^FT340,460^A0N,66,86^FH\\^FD" + IMEI1 + "^FS";

            s += "^BY4,4,80^FT140,600^BCN,,N,N";
            s += "^FD" + IMEI2 + "^FS";
            s += "^FT140,660^A0N,66,66^FH\\^FDIMEI 2:^FS";
            s += "^FT340,660^A0N,66,86^FH\\^FD" + IMEI2 + "^FS";

            s += "^BY4,4,80^FT140,800^BCN,,N,N";
            s += "^FD" + NS + "^FS";
            s += "^FT140,860^A0N,66,66^FH\\^FDSN:^FS";
            s += "^FT340,860^A0N,66,86^FH\\^FD" + NS + "^FS";

            s += "^FT140,980^A0N,62,66^FH\\^FDEAN:^FS";
            s += "^BY6,10,90^FT300,1020^BEN,,Y,N";
            s += "^FD" + CodEAN + "^FS";

            s += "^FT1420,380^A0N,100,100^FH\\^FDCOR: " + configuracao2 + "^FS";
            s += "^FT1420,600^A0N,80,80^FH\\^FDANATEL^FS";
            s += "^FT1420,680^A0N,80,80^FH\\^FD" + Anatel + "^FS";
          //  s += "^FT1400,920^A0N,60,100^FH\\^FDPOSITIVO TECNOLOGIA^FS";
            s += "Inform\\A0tica^FS";
            s += "^PQ1,0,1,Y^XZ";
        }


        public void Tablet()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ ";
            s += "^XA";
            s += "^MMT";
            s += "^PW1320";
            s += "^LL600";
            s += "^LS0";
            s += "^FT70,120^A0N,80,80^FH\\^FD" + produto + "^FS";
            s += "^FT650,250^A0N,60,60^FH\\^FD" + configuracao1 + "^FS";
            s += "^BY2,2,60^FT70,270^BCN,,N,N";
            s += "^FD" + NS + "^FS";
            s += "^FT70,300^A0N,33,33^FH\\^FDSN:^FS";
            s += "^FT170,300^A0N,33,43^FH\\^FD" + NS + "^FS";
            s += "^FT70,370^A0N,31,33^FH\\^FDEAN:^FS";
            s += "^BY3,5,45^FT150,390^BEN,,Y,N";
            s += "^FD" + CodEAN + "^FS";
           // s += "^BY2,2,60^FT70,510^BCN,,N,N";
           // s += "^FD" + IMEI1 + "^FS";
           // s += "^FT70,540^A0N,33,33^FH\\^FDIMEI 1:^FS";
           // s += "^FT170,540^A0N,33,43^FH\\^FD" + IMEI1 + "^FS  ";
            s += "^FT650,400^A0N,40,40^FH\\^FDANATEL: " + Anatel + "^FS";
            s += "^FT650,480^A0N,40,60^FH\\^FDPOSITIVO TECNOLOGIA^FS";
            s += "^FT650,510^A0N,25,25^FH\\^FDProduto Beneficiado pela Legisla\\87\\C6o da Inform\\A0tica^FS";
            s += "^PQ1,0,1,Y^XZ";

            /*
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD21^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW591";
            s += "^LL0909";
            s += "^LS0";

            s += "^BY3,2,42^FT144,71^BEN,,Y,N";
            s += "^FD" + CodEAN + "^FS";

            s += "^BY2,3,41^FT149,149^BCN,,N,N";
            s += "^FD>:" + NS + "^FS";
            s += "^FT168,176^AAN,27,15^FH\\^FDNS:" + NS + "^FS";

            s += "^FT310,202^A0N,17,16^FH\\^FDqqcoisa^FS";
            s += "^FT153,202^A0N,17,16^FH\\^FD110-220^FS";

            s += "^FT310,268^A0N,17,16^FH\\^FDAnatel: " + Anatel + "^FS";
            s += "^FT89,268^A0N,17,16^FH\\^FD ^FS";
            s += "^FT189,268^A0N,17,16^FH\\^FDNS:" + NS + "^FS";

            s += "^FT89,354^A0N,46,50^FH\\^FD" + produto + "^FS";
            s += "^FT89,391^A0N,37,36^FH\\^FD" + Familia + "^FS";

            s += "^FT257,426^A0N,29,36^FH\\^FDOP^FS";
            s += "^BY2,3,40^FT153,476^BCN,,N,N";
            s += "^FD>:XXXXXXXX^FS";
            s += "^FT222,501^AAN,27,15^FH\\^FDXXXXXXXX^FS";

            s += "^FT257,535^A0N,29,36^FH\\^FDNS^FS";
            s += "^BY2,3,40^FT151,585^BCN,,N,N";
            s += "^FD>:" + NS + "^FS";
            s += "^FT175,618^AAN,36,20^FH\\^FD" + NS + "^FS";

            s += "^FT248,656^A0N,29,36^FH\\^FDEAN^FS";
            s += "^BY3,2,42^FT141,708^BEN,,Y,N";
            s += "^FD" + CodEAN + "^FS";

            s += "^FT89,828^A0N,17,16^FH\\^FDProduto Beneficiado pela Legisla\\87\\C6o de Inform\\A0tica^FS";
            s += "^PQ1,0,1,Y^XZ";
             */ 
        }

        public void Tablet200()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ ";
            s += "^XA";
            s += "^MMT";
            s += "^PW880";
            s += "^LL400";
            s += "^LS0";
            s += "^FT47,80^A0N,53,53^FH\\^FD" + produto + "^FS";
            s += "^FT433,167^A0N,40,40^FH\\^FD" + configuracao1 + "^FS";
            s += "^BY2,2,40^FT47,180^BCN,,N,N";
            s += "^FD" + NS + "^FS";
            s += "^FT47,200^A0N,22,22^FH\\^FDSN:^FS";
            s += "^FT113,200^A0N,22,29^FH\\^FD" + NS + "^FS";

            s += "^FT47,247^A0N,21,22^FH\\^FDEAN:^FS";
            s += "^BY3,3,30^FT100,260^BEN,,Y,N";
            s += "^FD" + CodEAN + "^FS";

           // s += "^BY2,2,40^FT47,340^BCN,,N,N";
           // s += "^FD" + IMEI1 + "^FS";
           // s += "^FT47,360^A0N,22,22^FH\\^FDIMEI 1:^FS";
          //  s += "^FT113,360^A0N,22,29^FH\\^FD" + IMEI1 + "^FS  ";

            s += "^FT433,267^A0N,27,27^FH\\^FDANATEL: " + Anatel + "^FS";
            s += "^FT433,320^A0N,27,40^FH\\^FDPOSITIVO TECNOLOGIA^FS";
            s += "^FT433,340^A0N,17,17^FH\\^FDProduto Beneficiado pela Legisla\\87\\C6o da Inform\\A0tica^FS";
            s += "^PQ1,0,1,Y^XZ";
        }

        public void Tablet600()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ ";
            s += "^XA";
            s += "^MMT";
            s += "^PW2640";
            s += "^LL1200";
            s += "^LS0";

            s += "^FT140,240^A0N,160,160^FH\\^FD" + produto + "^FS";
            s += "^FT1300,500^A0N,120,120^FH\\^FD" + configuracao1 + "^FS";
            s += "^BY4,4,120^FT140,540^BCN,,N,N";
            s += "^FD" + NS + "^FS";
            s += "^FT140,600^A0N,66,66^FH\\^FDSN:^FS";
            s += "^FT340,600^A0N,66,86^FH\\^FD" + NS + "^FS";
                       
            s += "^FT140,740^A0N,62,66^FH\\^FDEAN:^FS";
            s += "^BY6,10,90^FT300,780^BEN,,Y,N";
            s += "^FD" + CodEAN + "^FS";

            /*
            s += "^BY4,4,120^FT140,1020^BCN,,N,N";
            s += "^FD" + IMEI1 + "^FS";
            s += "^FT140,1080^A0N,66,66^FH\\^FDIMEI 1:^FS";
            s += "^FT340,1080^A0N,66,86^FH\\^FD" + IMEI1 + "^FS";
             */ 

            s += "^FT1300,800^A0N,80,80^FH\\^FDANATEL: " + Anatel + "^FS";
            s += "^FT1300,960^A0N,80,120^FH\\^FDPOSITIVO TECNOLOGIA^FS";
            s += "^FT1300,1020^A0N,50,50^FH\\^FDProduto Beneficiado pela Legisla\\87\\C6o da Inform\\A0tica^FS";
            s += "^PQ1,0,1,Y^XZ";

        }

        public void Tablet3G()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ ";
            s += "^XA";
            s += "^MMT";
            s += "^PW1320";
            s += "^LL600";
            s += "^LS0";
            s += "^FT70,120^A0N,80,80^FH\\^FD" + produto + "^FS";
            s += "^FT650,250^A0N,60,60^FH\\^FD" + configuracao1 + "^FS";
            s += "^BY2,2,60^FT70,270^BCN,,N,N";
            s += "^FD" + NS + "^FS";
            s += "^FT70,300^A0N,33,33^FH\\^FDSN:^FS";
            s += "^FT170,300^A0N,33,43^FH\\^FD" + NS + "^FS";

            s += "^FT70,370^A0N,31,33^FH\\^FDEAN:^FS";
            s += "^BY3,5,45^FT150,390^BEN,,Y,N";            
            s += "^FD" + CodEAN + "^FS";

            s += "^BY2,2,60^FT70,510^BCN,,N,N";
            s += "^FD" + IMEI1 + "^FS";
            s += "^FT70,540^A0N,33,33^FH\\^FDIMEI 1:^FS";
            s += "^FT170,540^A0N,33,43^FH\\^FD" + IMEI1 + "^FS  ";
            s += "^FT650,400^A0N,40,40^FH\\^FDANATEL: " + Anatel + "^FS";
            s += "^FT650,480^A0N,40,60^FH\\^FDPOSITIVO TECNOLOGIA^FS";
            s += "^FT650,510^A0N,25,25^FH\\^FDProduto Beneficiado pela Legisla\\87\\C6o da Inform\\A0tica^FS";
            s += "^PQ1,0,1,Y^XZ";

            /*
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD21^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW591";
            s += "^LL0909";
            s += "^LS0";
            s += "^BY3,2,42^FT144,71^BEN,,Y,N^FD" + CodEAN + "^FS";
            s += "^BY2,3,41^FT149,149^BCN,,N,N^FD>:" + NS + "^FS";
            s += "^FT168,176^AAN,27,15^FH\\^FDNS:" + NS + "^FS";
            s += "^FT310,202^A0N,17,16^FH\\^FDQQCOISA^FS";
            s += "^FT153,202^A0N,17,16^FH\\^FD 110-220^FS";
            s += "^FT310,268^A0N,17,16^FH\\^FDAnatel:" + Anatel + "^FS";
            s += "^FT89,268^A0N,17,16^FH\\^FD ^FS";
            s += "^FT189,268^A0N,17,16^FH\\^FDNS:" + NS + "^FS";
            s += "^FT89,318^A0N,46,50^FH\\^FD" + produto + "^FS";
            s += "^FT89,355^A0N,37,36^FH\\^FD" + configuracao1 + "^FS";
            s += "^FT257,390^A0N,29,36^FH\\^FDOP^FS";
            s += "^BY2,3,40^FT117,440^BCN,,N,N^FD>:XXXXXXXX^FS";
            s += "^FT186,465^AAN,27,15^FH\\^FDXXXXXXXX^FS";
            s += "^FT257,495^A0N,29,36^FH\\^FDNS^FS";
            s += "^BY2,3,40^FT151,540^BCN,,N,N^FD>:" + NS + "^FS";
            s += "^FT175,565^AAN,30,17^FH\\^FD" + NS + "^FS";
            s += "^FT248,605^A0N,29,36^FH\\^FDEAN^FS";
            s += "^BY3,2,42^FT141,655^BEN,,Y,N^FD" + CodEAN + "^FS";
            s += "^FT245,720^A0N,29,36^FH\\^FDIMEI^FS";
            s += "^BY2,3,40^FT93,770^BCN,,N,N^FD>:" + IMEI1 + "^FS";
            s += "^FT150,800^AAN,27,15^FH\\^FD" + IMEI1 + "^FS";
            s += "^FX^FT89,828^A0N,17,16^FH\\^FDProduto Beneficiado pela Legisla\\87\\C6o de Inform\\A0tica^FS";
            s += "^PQ1,0,1,Y^XZ";
             */ 
        }

        public void Tablet3G200()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ ";
            s += "^XA";
            s += "^MMT";
            s += "^PW880";
            s += "^LL400";
            s += "^LS0";
            s += "^FT47,80^A0N,53,53^FH\\^FD" + produto + "^FS";
            s += "^FT433,167^A0N,40,40^FH\\^FD" + configuracao1 + "^FS";
            s += "^BY2,2,40^FT47,180^BCN,,N,N";
            s += "^FD" + NS + "^FS";
            s += "^FT47,200^A0N,22,22^FH\\^FDSN:^FS";
            s += "^FT113,200^A0N,22,29^FH\\^FD" + NS + "^FS";

            s += "^FT47,247^A0N,21,22^FH\\^FDEAN:^FS";
            s += "^BY3,3,30^FT100,260^BEN,,Y,N";
            s += "^FD" + CodEAN + "^FS";

            s += "^BY2,2,40^FT47,340^BCN,,N,N";
            s += "^FD" + IMEI1 + "^FS";
            s += "^FT47,360^A0N,22,22^FH\\^FDIMEI 1:^FS";
            s += "^FT113,360^A0N,22,29^FH\\^FD" + IMEI1 + "^FS  ";
            s += "^FT433,267^A0N,27,27^FH\\^FDANATEL: " + Anatel + "^FS";
            s += "^FT433,320^A0N,27,40^FH\\^FDPOSITIVO TECNOLOGIA^FS";
            s += "^FT433,340^A0N,17,17^FH\\^FDProduto Beneficiado pela Legisla\\87\\C6o da Inform\\A0tica^FS";
            s += "^PQ1,0,1,Y^XZ";
        }

        public void Tablet3G600()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ ";
            s += "^XA";
            s += "^MMT";
            s += "^PW2640";
            s += "^LL1200";
            s += "^LS0";
            s += "^FT140,240^A0N,160,160^FH\\^FD" + produto + "^FS";
            s += "^FT1300,500^A0N,120,120^FH\\^FD" + configuracao1 + "^FS";
            s += "^BY4,4,120^FT140,540^BCN,,N,N";
            s += "^FD" + NS + "^FS";
            s += "^FT140,600^A0N,66,66^FH\\^FDSN:^FS";
            s += "^FT340,600^A0N,66,86^FH\\^FD" + NS + "^FS";
            s += "^FT140,740^A0N,62,66^FH\\^FDEAN:^FS";
            s += "^BY6,10,90^FT300,780^BEN,,Y,N";
            s += "^FD" + CodEAN + "^FS";
            s += "^BY4,4,120^FT140,1020^BCN,,N,N";
            s += "^FD" + IMEI1 + "^FS";
            s += "^FT140,1080^A0N,66,66^FH\\^FDIMEI 1:^FS";
            s += "^FT340,1080^A0N,66,86^FH\\^FD" + IMEI1 + "^FS  ";
            s += "^FT1300,800^A0N,80,80^FH\\^FDANATEL: " + Anatel + "^FS";
            s += "^FT1300,960^A0N,80,120^FH\\^FDPOSITIVO TECNOLOGIA^FS";
            s += "^FT1300,1020^A0N,50,50^FH\\^FDProduto Beneficiado pela Legisla\\87\\C6o da Inform\\A0tica^FS";
            s += "^PQ1,0,1,Y^XZ";

        }

        public void Entrada(string NumS, string Modelo, string Cidade, string Data)
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW880";
            s += "^LL400";
            s += "^LS0";
            s += "^FT180,67^A0N,53,53^FH\\^FDPOSITIVO TECNOLOGIA^FS";
            s += "^FT47,127^A0N,40,40^FH\\^FDLOTE: " + Cidade + "^FS";
            s += "^FT47,220^A0N,30,43^FH\\^FD" + Modelo + "^FS";
            s += "^BY2,2,40^FT47,267^BCN,,N,N";
            s += "^FD" + NumS + "^FS";
            s += "^FT47,292^A0N,30,30^FH\\^FDSN:^FS";
            s += "^FT113,292^A0N,30,35^FH\\^FD" + NumS + "^FS";
            s += "^FT520,170^A0N,40,40^FH\\^FDDATA: " + Data + "^FS";
            s += "^PQ1,0,1,Y^XZ";
        }


        public string Chamado = "";
        public string Codigo = "";
        public string DescPeca = "";
        public string DataRMA = "";
        public string Usuario = "";
        public string Situacao = "";
        public void RMA()
        {
            s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD12^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW880";
            s += "^LL453";
            s += "^LS0";
            if (Situacao.Contains("ORCAMENTO"))
            {
                s += "^FO500,40^GB333,60,2^FS";
                s += "^FT556,83^A0N,53,36^FH\\^FDORCAMENTO^FS";
            }
            s += "^FO500,133^GB86,86,2^FS";
            s += "^FT586,193^A0N,60,53^FH\\^FD RMDF^FS";
            s += "^FO500,280^GB86,86,2^FS";
            s += "^FT586,340^A0N,60,53^FH\\^FD RETORNO^FS";
            s += "^FT40,73^A0N,73,60^FH\\^FD" + Chamado + "^FS";
            s += "^BY2,3,43^FT53,126^BCN,,N,N ^FD" + Chamado + "^FS";
            s += "^FT53,186^A0N,53,24^FH\\^FDCODIGO: " + Codigo + "^FS";
            s += "^BY2,2,30^FT35,230^BCN,,N,N^FD" + Codigo + "^FS";
            s += "^FT53,273^A0N,46,30^FH\\^FD" + DescPeca + "^FS";
            s += "^FT53,326^A0N,33,20^FH\\^FDDATA: " + DataRMA + "^FS";
            s += "^FT53,360^A0N,33,20^FH\\^FDUSUARIO: " + Usuario + "^FS";
            s += "^PQ1,0,1,Y^XZ";


            /*
             *  s = "";
            s += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3^MD21^JUS^LRN^CI0^XZ";
            s += "^XA";
            s += "^MMT";
            s += "^PW1320";
            s += "^LL680";
            s += "^LS0";
            s += "^FO750,60^GB500,90,3^FS";
            if (Situacao == "")
            {
                s += "^FT850,125^A0N,80,55^FH\\^FDORCAMENTO^FS";
            }           
            s += "^FO750,200^GB130,130,3^FS";
            s += "^FT880,290^A0N,90,80^FH\\^FD RMDF^FS";
            s += "^FO750,420^GB130,130,3^FS";
            s += "^FT880,510^A0N,90,80^FH\\^FD RETORNO^FS";
            s += "^FT60,110^A0N,110,90^FH\\^FD"+ Chamado +"^FS";
            s += "^BY4,5,65^FT80,190^BCN,,N,N ^FD>"+ Chamado + "^FS";
            s += "^FT80,280^A0N,80,55^FH\\^FDCODIGO: "+ Codigo +"^FS";
            s += "^BY3,5,45^FT80,340^BCN,,N,N^FD>" + Codigo + "^FS";
            s += "^FT80,410^A0N,70,45^FH\\^FD"+ DescPeca +"^FS";
            s += "^FT80,490^A0N,50,30^FH\\^FDDATA: " + DataRMA + "^FS";
            s += "^FT80,540^A0N,50,30^FH\\^FDUSUARIO: " + Usuario + "^FS";
            s += "^PQ1,0,1,Y^XZ";
             */
        }





    }



    class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }

    }



}
