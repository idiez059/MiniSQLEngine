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
            Database db1 = FileSystemAbstract.LoadOrCreateDB("patataBrava");
            //A ver si peta
            FileSystemAbstract.LoadOrCreateDB("AscoDeVida");
            List<Column> columns = new List<Column>();
            Column ages = new ColumnInt("Age");
            ages.AddValue("23");
            ages.AddValue("42");
            ages.AddValue("50");
            columns.Add(ages);
            Column names = new ColumnString("Name");
            names.AddValue("Maria");
            names.AddValue("Ignacio");
            names.AddValue("Ricardo");
            columns.Add(names);
            db.CreateTable("People", columns);
            //string query = "SELECT * FROM People WHERE Age < 30;";
            //Console.WriteLine(query + ": " + db.RunQuery(query));

            string querySelect1 = "SELECT * FROM table1;";
            string querySelect2 = "SELECT * FROM table2;";
            string queryInsert1 = "INSERT INTO table1 (names, ages) VALUES (D4NK_Nadius, 22);";
            string queryInsert2 = "INSERT INTO table2 (Kills, KDA) VALUES (5000, 0.9);";
            Console.WriteLine(querySelect1 + ": " + db1.RunQuery(querySelect1));
            Console.WriteLine(querySelect2 + ": " + db1.RunQuery(querySelect2));
            Console.WriteLine(queryInsert1 + ": " + db1.RunQuery(queryInsert1));
            Console.WriteLine(queryInsert2 + ": " + db1.RunQuery(queryInsert2));
            Console.WriteLine(querySelect1 + ": " + db1.RunQuery(querySelect1));
            Console.WriteLine(querySelect2 + ": " + db1.RunQuery(querySelect2));
            db1.Dispose();
            Console.WriteLine("Test finalizado.");
            string queryDelete = "DROP TABLE People;";
            db.Dispose();
            Console.WriteLine(queryDelete + ": " + db.RunQuery(queryDelete));
            

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
