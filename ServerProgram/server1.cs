using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using MiniSQLEngine;
using System.Text.RegularExpressions;

namespace ServerProgram
{
    public class server1
    {
        public static Database db;
        static bool con = false;
        static bool dbOpened = false;
        static byte[] outputBuffer = Encoding.ASCII.GetBytes("Nothing at all");
        static void Main(string[] args)

        {

            Console.WriteLine("JINIX DB Server v0.000000001");
            const string argPrefixPort = "port=";

            int port = 2400;
            foreach (string arg in args)
            {
                if (arg.StartsWith(argPrefixPort)) port = int.Parse(arg.Substring(argPrefixPort.Length));
            }
            if (port == 0)
            {
                Console.WriteLine("ERROR. Usage: TCPClient ip=<ip> port=<port>");
                return;
            }

            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            Console.WriteLine("Server listening for clients");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
               if (client != null){
                    Console.WriteLine("Client connection accepted");
                    con = true;
                }


                var childSocketThread = new Thread(() =>
                {
                byte[] inputBuffer = new byte[1024];

                NetworkStream networkStream = client.GetStream();

                //Read message from the client
                int size = networkStream.Read(inputBuffer, 0, 1024);
                string request = Encoding.ASCII.GetString(inputBuffer, 0, size);

                while (request != "<Query>EXIT</Query>") //doing thingies here
                {
                    //Database db = null;                        
                    string theAnswer = "";
                    string prueba = @"<Open Database=(\w+)\s+User=(\w+)\s+Password=(\w+)\/>";
                    Match openADb = Regex.Match(request, prueba);
                    //Match openADb = Regex.Match(request, "<Open Database=\"(\\w+)\" User=\"(\\w+)\" Password=\"(\\w+)\"/>");
                    Match runAQuery = Regex.Match(request, "<Query>(.+)</Query>");

                    if (dbOpened == false)
                    {
                        if (openADb.Success)
                        {
                            db = new Database(openADb.Groups[1].Value,
                                openADb.Groups[2].Value, openADb.Groups[3].Value);
                            string creationResult = "Nothing at all";
                            creationResult = db.getResult();
                            if (creationResult == "DB created OK.")
                            {
                                theAnswer = "<Success/>";
                                outputBuffer = Encoding.ASCII.GetBytes(theAnswer);
                                dbOpened = true;
                            }
                            else
                            {
                                theAnswer = "<Error>The database doesn’t exist</Error>";
                                outputBuffer = Encoding.ASCII.GetBytes(theAnswer);
                            }

                        }

                    }
                    else
                    {
                        string requestQuery = ParserXML.QueryXMLtoQuery(request);
                            theAnswer = db.RunQuery(ParserXML.QueryXMLtoQuery(request));
                            outputBuffer = Encoding.ASCII.GetBytes(ParserXML.AddAnswer(request));
                        }

                        Console.WriteLine("Request received: " + request);                        
                        networkStream.Write(outputBuffer, 0, outputBuffer.Length);
                        size = networkStream.Read(inputBuffer, 0, 1024);
                        request = Encoding.ASCII.GetString(inputBuffer, 0, size);
                    }
                    FileSystemAbstract.saveData(db.Name,db.Tables);
                    db.Dispose();
                    client.Close();                    
                });
                childSocketThread.Start();
            }
        }
    }
}
