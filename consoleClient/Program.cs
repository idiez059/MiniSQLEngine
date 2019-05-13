using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace consoleClient
{
    class Program
    {
        private string datab;
        private string user;
        private string pass;
        private string ip;
        private string port;
       
        public Program(string datab, string user, string pass,string ip, string port)
        {
            this.datab = datab;
            this.user = user;
            this.pass = pass;
            this.ip= ip;
            this.port = port;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter the IP: ");
            string ip = Console.ReadLine();
            Console.Write("Enter the port: ");
            string port = Console.ReadLine();
            Console.Write("Enter your user: ");
            string user = Console.ReadLine();
            Console.Write("Enter your password: ");
            string pass = Console.ReadLine();
            Console.Write("Enter the name of the database: ");
            string datab = Console.ReadLine();


            String XMLOpenConnection = "<Open Database = " + datab + "User = " + user + "Password = " + pass + "/>";
            //PasarXML(XMLOpenConnection); Cuando este hecho

                Console.WriteLine("Write exit when you want to finish");
            string query;
            Console.Write("Enter the query: ");
            query = Console.ReadLine();

            while (!query.ToLower().Equals("exit"))
            {
                Console.Write("Enter the query: ");
                query = Console.ReadLine();
                
            }
            Environment.Exit(0);
        }
    }
}

