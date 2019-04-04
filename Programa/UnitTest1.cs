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
            db.RunQuery("CREATE TABLE People (Name TEXT, Email TEXT, Age INT);");
            db.RunQuery("INSERT INTO People VALUES ('Rafa', 'rafa@gmail.com', 23);");
            db.RunQuery("UPDATE People SET Name=Bernardino,Age=21 WHERE Age<27;");
            //db.RunQuery(@"UPDATE People SET Name=Bernardino,Email=delvalle@gmail.com WHERE Age<27;");
            //db.RunQuery("UPDATE People SET Name=Bernado WHERE Name=Rafa;");
            //db.RunQuery("UPDATE People SET Name=Bernardino,Age=21;");
            //db.RunQuery("UPDATE People SET Name=Bernado WHERE Name=Rafa;");

            /*
            string[] wrongAnswer = {  };
            string[] correctAnswer = { Messages.TupleUpdateSuccess;     };

            foreach (string query in wrongAnswer)
                Assert.IsNull(MiniSQLEngine.);

            foreach (string query in correctAnswer)
                Assert.IsNotNull(MiniSQLEngine);
                */
        }
    }
}
