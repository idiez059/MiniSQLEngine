using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSQLEngine;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MiniSQLJinix V0.0.0.0.0.1");

            BDData db = BDData.getInstance();

            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\ismad\source\repos\ABDJINIX\Prueba.txt");
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                counter++;
                string var = db.RunQuery(line);
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();
         
                //string var = db.Query("SELECT * FROM .......");
               // Console.WriteLine(var);
            
        }
    }
}
