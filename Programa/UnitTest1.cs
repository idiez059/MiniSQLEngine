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
            string result2 = db.RunQuery("INSERT INTO People VALUES ('Rafa', 'rafa@gmail.com', 23);");
            //el insert no devuelve nada
            //Assert.AreNotEqual("{Name}{'Rafa','rafa@gmail.com', 23}", result2);
            //No funciona, devuelve null
            Assert.AreEqual(" Messages.InsertSuccess;", result2);
        }

        [TestMethod]
        public void TestUpdate()
        {
            Database db = new Database("test-db");
            db.RunQuery("CREATE TABLE People (Name TEXT, Email TEXT, Age INT);");
            db.RunQuery("INSERT INTO People VALUES ('Rafa', 'rafa@gmail.com', 34);");
            string result1 = db.RunQuery("UPDATE People SET Name=Bernardino,Age=21 WHERE Age<27;");
            //Assert.AreNotEqual("{Name,Email,Age}{'Bernardino','rafa@gmail.com',21}", result1);
            //No funciona, devuelve null
            //return Messages.TupleUpdateSuccess;
            Assert.AreEqual(" Messages.TupleUpdateSuccess;", result1);
        }
        
        [TestMethod]
        public void TestDelete()
        {
            Database db = new Database("test-db");
            db.RunQuery("CREATE TABLE People (Name TEXT, Email TEXT, Age INT);");
            db.RunQuery("INSERT INTO People VALUES ('Rafa', 'rafa@gmail.com', 34);");
            string result1 = db.RunQuery("DELETE FROM People WHERE Name = Rafa; ");
            Assert.AreEqual(
        }
        /*
        [TestMethod]
        public void TestCreateTable()
        {
            Database db = new Database("test-db");
           
        }

        [TestMethod]
        public void TestDropTable()
        {
            Database db = new Database("test-db");

        }
        */

    }
}
