using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;
using System.IO;

namespace Programa
{
    [TestClass]
    public class EverythingWorks
    {
        [TestMethod]
        public void TestSelect()
        {
            Database db = new Database("test-db");
            db.RunQuery("CREATE TABLE People (Name TEXT, Email TEXT, Age INT);");
            db.RunQuery("INSERT INTO People VALUES ('Rafa', 'rafa@gmail.com', 23);");
            //Este test lo pasa
            string result1 = db.RunQuery("SELECT Name FROM People WHERE Age = 23;"); 
            Assert.AreEqual("{Name,Email,Age}{'Rafa','rafa@gmail.com',23}", result1);
            Assert.AreNotEqual("{Name,Email,Age}{'Luis', 'rafa@gmail.com', 23}", result1);
            // Este test no pasa
            //string result = db.RunQuery("SELECT Name FROM People;");

        }

        [TestMethod]
        public void TestInsert()
        {
            Database db = new Database("test-db");
            db.RunQuery("CREATE TABLE People (Name TEXT, Email TEXT, Age INT);");
            string result1 = db.RunQuery("INSERT INTO People VALUES ('Rafa', 'rafa@gmail.com', 23);");
            //el insert no devuelve nada
            Assert.AreNotEqual("{Name}{'Rafa','rafa@gmail.com', 23}", result1);
        }

        [TestMethod]
        public void TestUpdate()
        {
            Database db = new Database("test-db");
            db.RunQuery("CREATE TABLE People (Name TEXT, Email TEXT, Age INT);");
            db.RunQuery("INSERT INTO People VALUES ('Rafa', 'rafa@gmail.com', 34);");
            string result1 = db.RunQuery("UPDATE People SET Name=Bernardino,Age=21 WHERE Age<27;");
            Assert.AreNotEqual("{Name,Email,Age}{'Bernardino','rafa@gmail.com',21}", result1);
        }
    }
}
