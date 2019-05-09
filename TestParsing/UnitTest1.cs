using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using MiniSQLEngine;

namespace testParsing
{
    [TestClass]
    public class TestParsing1
    {
        /*
         *  TODAS ESTAS PRUEBAS ESTAN MAL
         *  HAY QUE HACER QUE COJA LOS VALORES DEL QUERY
         *  PORQUE QUE PASE ESTOS TEST NO QUIERE DECIR QUE PASE EL ENGIN
         * mIRAR PRIMERO EL SELECT
         * 
         */

        [TestMethod]
        public void Select()
        {
            string[] wrongQueries = { "Select * FROM Table1;", "SELECT * FROM Table 1;", "SELECT * FROM Table1", "SELECT * FROM Table1 ;"};
            string[] correctQueries = { "SELECT * FROM Table1;" };

            foreach (string query in wrongQueries)
                Assert.IsNull(Parser.Parse(query));


            foreach (string query in correctQueries)
                Assert.IsNotNull(Parser.Parse(query));
        }

        [TestMethod]
        public void Insert()
        {
            string[] wrongQueries = { "INSERT FROM alumno WHERE nombre = Xabi;" };
            string[] correctQueries = { "INSERT INTO myTable VALUES ('Rafa', 'rafa@gmail.com', 23);", "INSERT INTO table_name (column1, column2, column3) VALUES (value1, value2, value3); ; " };
        
            foreach (string query in wrongQueries)
                Assert.IsNull(Parser.Parse(query));

            foreach (string query in correctQueries)
                Assert.IsNotNull(Parser.Parse(query));
        }

        [TestMethod]
        public void Delete()
        {
            string[] wrongQueries = { "DELETE FROM ;" };
            string[] correctQueries = { "DELETE FROM alumno;", "DELETE FROM alumno WHERE nombre = Xabi;" };

            foreach (string query in wrongQueries)
                Assert.IsNull(Parser.Parse(query));

            foreach (string query in correctQueries)
                Assert.IsNotNull(Parser.Parse(query));
        }

        [TestMethod]
        public void Update()
        {
            string[] wrongQueries = { "UPDATE alumno SET nombre = Nadia nombre = Xabi;" };
            string[] correctQueries = { "UPDATE People SET Name=Bernado,Edad=23 WHERE Name=Maria;" };
            

            foreach (string query in wrongQueries)
                Assert.IsNull(Parser.Parse(query));

            foreach (string query in correctQueries)
                Assert.IsNotNull(Parser.Parse(query));
        }
        //creo que aqui da el error en el github
         [TestMethod]
         public void TestCreateDataBase()
         {
            string[] wrongQueries = { "CREATE DATABASE alumno where nombre = Juan;" };
            string[] correctQueries = { "CREATE DATABASE alumno,admin,admin;" };
            /*
             string input1 = "CREATE DATABASE alumnos";
             string input2 = "CREATE DATA alumnos";
             string input3 = "CREATE BASE alumnos";
             string input4 = "create base alumnos";
             */
            foreach (string query in wrongQueries)
                Assert.IsNull(Parser.Parse(query));

            foreach (string query in correctQueries)
                Assert.IsNotNull(Parser.Parse(query));
         }

         [TestMethod]
         public void TestDropDataBase()
         {
            string[] wrongQueries = { "DROP DATABASES alumnos;" };
            string[] correctQueries = { "DROP DATABASE alumnos;" };

            foreach (string query in wrongQueries)
                Assert.IsNull(Parser.Parse(query));

            foreach (string query in correctQueries)
                Assert.IsNotNull(Parser.Parse(query));
         }

        [TestMethod]
         public void TestDropTable()
         {
            string[] correctQueries = { "DROP TABLE werq;" };
            string[] wrongQueries = {"DROP table werq;"};

            foreach (string query in wrongQueries)
                Assert.IsNull(Parser.Parse(query));

            foreach (string query in correctQueries)
                Assert.IsNotNull(Parser.Parse(query)); 
         }

        /*
          public void TestManageDropTable()
          {

             string query = @"DROP TABLE table1;";  
             ClassDropTable dt = myClass.ManageDropTable(query);
             String name = "table1";
             ClassDropTable dtExpected = new ClassDropTable(name);
             Assert.AreEqual(dtExpected.GetName(), dt.GetName());
          } 
    */       

        [TestMethod]
        public void TestBackupDataBase()

        {
            string[] correctQueries = { "BACKUP DATABASE qwert TO DISK = 'tyu';" };
            string[] wrongQueries = { "BACKUP DATABASE qwert;" };

            foreach (string query in wrongQueries)
                Assert.IsNull(Parser.Parse(query));

            foreach (string query in correctQueries)
                Assert.IsNotNull(Parser.Parse(query));
        }

        [TestMethod]
        public void TestCreateTable()
        {

            string[] correctQueries = { "CREATE TABLE table_name (column1 datatype, column2 datatype, column3 datatype);"};
            string[] wrongQueries = { "CREATE TABLE table_name(INT PRIMARY KEY(wqerfg) FOREIGN KEY(sdfghj) REFERENCES werty);" };

            foreach (string query in wrongQueries)
                Assert.IsNull(Parser.Parse(query));

            foreach (string query in correctQueries)
                Assert.IsNotNull(Parser.Parse(query));
        }
        
    }
}
 