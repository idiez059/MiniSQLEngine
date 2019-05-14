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
        static void Main(string[] args)
        {
            Console.WriteLine("JINIX DB Server v0.000000001");
            const string argPrefixPort = "port=";

            int port = 0;
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
                Console.WriteLine("Client connection accepted");

                var childSocketThread = new Thread(() =>
                {
                    byte[] inputBuffer = new byte[1024];

                    NetworkStream networkStream = client.GetStream();

                    //Read message from the client
                    int size = networkStream.Read(inputBuffer, 0, 1024);
                    string request = Encoding.ASCII.GetString(inputBuffer, 0, size);

                    while (request != "END") //doing thingies here
                    {
                        Database db = null;
                        string theAnswer = "";
                        Match openADb = Regex.Match(request, "<Open Database=\"(\\w+)\" User=\"(\\w+)\" Password=\"(\\w+)\"/>");
                        Match runAQuery = Regex.Match(request, "<Query>(.+)</Query>");

                        if (openADb.Success)
                        {
                            db = new Database(openADb.Groups[1].Value,openADb.Groups[2].Value,openADb.Groups[3].Value);
                            string creationResult = "Nothing at all";
                            creationResult = db.getResult();
                            if (creationResult == "DB created OK.")
                            {
                                theAnswer = "<Success/>";
                            }
                            else
                            {
                                theAnswer = "<Error>The database doesn’t exist</Error>";
                            }

                        }else if (runAQuery.Success)
                        {
                            db.RunQuery(runAQuery.Groups[1].Value);
                        }
                        else
                        {
                            Console.WriteLine("Could not understand what to do!");
                            theAnswer = "<Error> Database, user or password are incorrect </Error>";
                        }


                        Console.WriteLine("Request received: " + request);

                        byte[] outputBuffer = Encoding.ASCII.GetBytes(theAnswer);
                        networkStream.Write(outputBuffer, 0, outputBuffer.Length);

                        size = networkStream.Read(inputBuffer, 0, 1024);
                        request = Encoding.ASCII.GetString(inputBuffer, 0, size);
                    }
                    client.Close();
                });
                childSocketThread.Start();
            }
        }
    }
}
