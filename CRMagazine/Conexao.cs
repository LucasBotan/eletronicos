using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace CRMagazine
{
    class Conexao
    {
        public SqlConnection c = new SqlConnection();
        public string status = "";

        public void Conectar()
        {
            string s = "";

            //====OFICIAL
            //old s = "Data Source=192.168.0.115,49172;Initial Catalog=Purificar;User ID=sa;Password=portus7472";
            s = "Data Source=192.168.0.250\\SQLEXPRESS;Initial Catalog=Purificar;User ID=sa;Password=portus7472";
            //====

            //==== PARA USO EXTERNO DURANTE OS TESTES, QNDO FOR POBLICAR REMARCAR ESSE, E DEIXAR O ORIGINAL
            //old s = "Data Source=26.2.109.73,49172;Initial Catalog=Purificar;User ID=sa;Password=portus7472";
           // s = "Data Source=192.168.0.250\\SQLEXPRESS;Initial Catalog=TestesQA;User ID=sa;Password=portus7472";
            //====

            /*
            try
            {
                //==== PARA USO EXTERNO DURANTE OS TESTES, QNDO FOR POBLICAR REMARCAR ESSE, E DEIXAR O ORIGINAL
                s = "Data Source=26.2.109.73,49172;Initial Catalog=Purificar;User ID=sa;Password=portus7472";
                //====
            }
            catch(Exception)
            {
                //====OFICIAL
                s = "Data Source=192.168.0.115,49172;Initial Catalog=Purificar;User ID=sa;Password=portus7472";
                //====
            } 
             */
            c.ConnectionString = s;
            c.Open(); 

            /*
            string s = "";           
          //  s = "Data Source=10.83.200.23,49172;Initial Catalog=PSRExterno;User ID=sa;Password=Maiden!@#";
            s = "Data Source=10.20.120.78;Initial Catalog=PROD;User ID=BACKLOG;Password=back100";
            c.ConnectionString = s;
            c.Open();
             */ 
        }


        public void ConectarHost()
        {
            string s = "";
            //s = "Data Source=162.241.203.50;Initial Catalog=jpeltr56_Purificar;User ID=jpeltr56;Password=portus7472";
            s = "Data Source=162.241.203.50;Initial Catalog=jpeltr56_Purificar;User ID=jpeltr56_sa;Password=portus7472";
            c.ConnectionString = s;
            c.Open();
        }

        public void ConectarSP()
        {
            string s = "";
            s = "Data Source=10.81.200.22,49172\\SQLEXPRESS;Initial Catalog=Positivo;User ID=sa;Password=!@#AtpSP!@#";
            c.ConnectionString = s;
            c.Open();
        }

        public void ConectarEtq()
        {
            string s = "";
            s = "Data Source=10.20.120.78;Initial Catalog=PROD;User ID=BACKLOG;Password=back100";
            c.ConnectionString = s;
            c.Open(); 
        }

        public void ConectarAssist()
        {
            string s = "";
            s = "Data Source=011sql551.positivo.corp;Initial Catalog=Assist_REL;User ID=usr_estoque;Password=W67X5JFH";
            c.ConnectionString = s;
            c.Open();
        }

        public void ConectarSAP()
        {
            string s = "";
            s = "Data Source=172.21.16.12;Initial Catalog=RELSAP;User ID=ewertonv;Password=ewerton1984";
            c.ConnectionString = s;
            c.Open();
        }

        public void Desconectar()
        {
            c.Close();
        }       

    }
}
