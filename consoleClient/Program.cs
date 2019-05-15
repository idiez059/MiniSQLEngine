using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
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

                byte[] openDatabase = Encoding.ASCII.GetBytes("<Open Database="
                    + datab + " User=" + user + " Password=" + pass + "/>");
                byte[] inputBuffer = new byte[1024];

                networkStream.Write(openDatabase, 0, openDatabase.Length);
                int readBytes = networkStream.Read(inputBuffer, 0, 1024);
                Console.WriteLine("Server response to database: " + Encoding.ASCII.GetString(inputBuffer));

                if (inputBuffer.Equals(Encoding.ASCII.GetBytes("<Success/>")))
                {                    
                    Console.WriteLine("Write exit when you want to finish");
                    string query;
                    byte[] queryBuffer;
                    String answer;
                    do
                    {
                        Console.Write("Enter the query: ");
                        query = Console.ReadLine();
                        if (query.ToLower() != "exit")
                        {
                            queryBuffer = Encoding.ASCII.GetBytes("<Query>" + query + "</Query>");
                            networkStream.Write(queryBuffer, 0, queryBuffer.Length);
                            readBytes = networkStream.Read(inputBuffer, 0, 1024);
                            answer = Encoding.ASCII.GetString(inputBuffer);
                            Console.WriteLine("Server response to query: " + query + " - " + answer);
                        }
                    } while (query.ToLower() != "exit");
                }
                else
                {
                    Console.WriteLine("Could not log in, check data was correct.");
                }
            }
        }
    }
}

