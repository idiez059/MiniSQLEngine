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
            Database db = new Database("test-db");

            List<Column> columns = new List<Column>();
            Column ages = new ColumnInt("Age");
            ages.AddValue("23");
            ages.AddValue("42");
            columns.Add(ages);
            Column names = new ColumnString("Name");
            names.AddValue("Maria");
            names.AddValue("Ignacio");
            columns.Add(names);
            db.CreateTable("People", columns);
            string query = "SELECT * FROM People WHERE Age = 23;";
            Console.WriteLine(query + ": " + db.RunQuery(query));

            //string queryDelete = "DELETE FROM People WHERE Age > 25;";
            //Console.WriteLine(queryDelete + ": " + db.RunQuery(queryDelete));

            //string query = "SELECT Name FROM People;";
            //Console.WriteLine(query + ": " + db.RunQuery(query));

            //Console.WriteLine("MiniSQLJinix V0.0.0.0.0.1");

            //BDData db = BDData.getInstance();

            //int counter = 0;
            //string line;

            //// Read the file and display it line by line.  
            //System.IO.StreamReader file =
            //    new System.IO.StreamReader(@"..\..\..\Prueba.txt");
            //while ((line = file.ReadLine()) != null)
            //{
            //    System.Console.WriteLine(line);
            //    counter++;
            //    string result = db.RunQuery(line);
            //    Console.WriteLine(result);
            //}

            //file.Close();
            //System.Console.WriteLine("There were {0} lines.", counter);
            //// Suspend the screen.  
            //System.Console.ReadLine();           
        }
    }
}
