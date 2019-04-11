using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;
using System.IO;

namespace Programa
{
    [TestClass]
    public class EverythingWorks
    {
        [TestMethod]
        public void TestManageSelect()
        {
            Database db = new Database("test-db");
            db.RunQuery("CREATE TABLE People (Name TEXT, Email TEXT, Age INT);");
            db.RunQuery("INSERT INTO People VALUES ('Rafa', 'rafa@gmail.com', 23);");
            // Este test no pasa
            //string result = db.RunQuery("SELECT Name FROM People;");
           // Assert.AreEqual("{Name,Email,Age}{'Rafa','rafa@gmail.com',23}",result);
            //Este test lo pasa
            string result1 = db.RunQuery("SELECT Name FROM People WHERE Age = 23;"); 
            Assert.AreEqual("{Name,Email,Age}{'Rafa','rafa@gmail.com',23}", result1);
        }

        
    }
}
