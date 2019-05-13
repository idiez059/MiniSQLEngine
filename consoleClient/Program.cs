using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace consoleClient
{
    class Program
    {
        private string datab;
        private string user;
        private string pass;
        private string ip;
        private int port;
       
        public Program(string datab, string user, string pass,string ip, int port)
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
            int port = int.Parse(Console.ReadLine());
            Console.Write("Enter your user: ");
            string user = Console.ReadLine();
            Console.Write("Enter your password: ");
            string pass = Console.ReadLine();
            Console.Write("Enter the name of the database: ");
            string datab = Console.ReadLine();

            
            if (ip == null || port == 0 )
            {
                Console.WriteLine("ERROR. Usage: TCPClient ip=<ip> port=<port>");
                return;
            }
                      
            using (TcpClient client = new TcpClient(ip, port))
            {
                NetworkStream networkStream = client.GetStream();

                byte[] database = Encoding.ASCII.GetBytes(datab);
                byte[] userBuffer = Encoding.ASCII.GetBytes(user);
                byte[] passBuffer = Encoding.ASCII.GetBytes(pass);
                byte[] inputBuffer = new byte[1024];

                networkStream.Write(database,0,database.Length);
                int readBytes = networkStream.Read(inputBuffer, 0, 1024);
                Console.WriteLine("Server response to database: " + readBytes);
                networkStream.Write(userBuffer, 0, userBuffer.Length);
                readBytes = networkStream.Read(inputBuffer, 0, 1024);
                Console.WriteLine("Server response to user: " + readBytes);
                networkStream.Write(passBuffer, 0, passBuffer.Length);
                readBytes = networkStream.Read(inputBuffer, 0, 1024);
                Console.WriteLine("Server response to password: " + readBytes);

                Console.WriteLine("Write exit when you want to finish");
                string query;
                byte[] queryBuffer;
                do
                {
                    Console.Write("Enter the query: ");
                    query = Console.ReadLine();
                    queryBuffer = Encoding.ASCII.GetBytes(query);
                    networkStream.Write(queryBuffer, 0, queryBuffer.Length);
                    readBytes = networkStream.Read(inputBuffer, 0, 1024);
                    Console.WriteLine("Server response to query: " + query + "; " + readBytes);
                } while (query.ToLower() != "exit");
            }
        }
    }
}

