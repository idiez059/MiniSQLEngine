using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSQLEngine;

namespace TestInsert
{
    class Program
    {
        static void Main(string[] args)
        {
            MiniSQLEngine.Database db = new Database("harl");
            db.RunQuery("CREATE TABLE myTable (Name TEXT, Email TEXT, Age INT);");
            db.RunQuery("INSERT INTO myTable VALUES ('Rafa', 'rafa@gmail.com', 23);");
        }
    }
}
