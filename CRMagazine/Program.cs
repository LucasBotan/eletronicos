using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMagazine
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmInicial());


            //Application.Run(new frmADMAjustarNFSaida());

           // Application.Run(new frmExpedicaoPlanilhaNotaFiscal());
           // Application.Run(new frmEstoqueNovaEntrada());
            // Application.Run(new frmReparoLacarProdutoMontado());
          //  Application.Run(new frmEstoqueRetiradaAvulsa());

         //   Application.Run(new frmEstoqueRecebeProducao());

          //  Application.Run(new frmEstoqueRetiradaAvulsa());

           // Application.Run(new frmEstoqueConsultas());

            
          //  Application.Run(new frmReparo("lucas", ""));
            
             //  Application.Run(new frmEntradaDeNotas());
        }
    }
}
