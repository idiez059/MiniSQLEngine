using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSQLEngine;

namespace TrialCreateTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database("Test-db");
            Console.WriteLine("Create Table test results: " + db.RunQuery("CREATE TABLE someTable (ages INT, names TEXT, average DOUBLE);"));
            Console.WriteLine("Create Table test results: " + db.RunQuery("CREATE TABLE someTable (ages INT, names TEXT, average DOUBLE);"));
            //This 3rd one nis going to work even if it should not, as our Parser is kinda simple, we're gonna just leave it like that, Borja said
            Console.WriteLine("Create Table test results: " + db.RunQuery("CREATE TABLE myTable (ages INT names TEXT, average DOUBLE);"));
            Console.WriteLine("Create Table test results: " + db.RunQuery("CREATE TABLE whyTable (INT ages, names TEXT, average DOUBLE);"));
            Console.WriteLine("Create Table test results: " + db.RunQuery("CREATE TABLE howToTable (ages, names TEXT, average DOUBLE);"));
        }
    }
}
