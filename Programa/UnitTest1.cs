using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using MiniSQLEngine;


namespace Programa
{
    [TestClass]
    public class EverythingWorks
    {
        [TestMethod]
        public void Select()
        {


        }

        [TestMethod]
        public void Update()
        {
             Database db = new Database("test-db");
            db.RunQuery(@"UPDATE People SET Name=Bernardino,Email=bernardino@gmail.com WHERE Age<27;");
            Table table = table.ColumnByName(j);

            Assert.AreEqual("People", table.Name);
            Assert.AreEqual("nombre=Name=Bernardino", table.ColumnByName(j)[0]);
            Assert.AreEqual("Email=bernardino@gmail.com", table.ColumnByName(j)[1]);
            Assert.AreEqual("Age<27", table.);


            /*
            Database db = new Database("test-db");
            db.RunQuery("CREATE TABLE People (Name TEXT, Email TEXT, Age INT);");
            db.RunQuery("INSERT INTO People VALUES ('Rafa', 'rafa@gmail.com', 23);");
            db.RunQuery("UPDATE People SET Name=Bernardino,Age=21 WHERE Age<27;");
            //db.RunQuery(@"UPDATE People SET Name=Bernardino,Email=delvalle@gmail.com WHERE Age<27;");
            //db.RunQuery("UPDATE People SET Name=Bernado WHERE Name=Rafa;");
            //db.RunQuery("UPDATE People SET Name=Bernardino,Age=21;");
            //db.RunQuery("UPDATE People SET Name=Bernado WHERE Name=Rafa;");

               
                */
        }
    }
}
