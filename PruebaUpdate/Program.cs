using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSQLEngine;

namespace PruebaUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            /*update*/
            Database db = new Database("test-db");
            db.RunQuery("CREATE TABLE People (Name TEXT, Email TEXT, Age INT);");
            db.RunQuery("INSERT INTO People VALUES ('Rafa', 'rafa@gmail.com', 23);");
            //db.RunQuery(@"UPDATE People SET Name=Bernardino,Email=delvalle@gmail.com WHERE Age<27;");
            db.RunQuery ( "UPDATE People SET Name=Bernardino,Age=21 WHERE Age<27;"); 
            //db.RunQuery("UPDATE People SET Name=Bernado WHERE Name=Rafa;");
          

            /*
            Database db = new Database("test-db");
            db.RunQuery("UPDATE People SET Name = Bernado WHERE Name = Maria;");*/
        }
    }
}
