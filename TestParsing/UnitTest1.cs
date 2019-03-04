using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

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
        Parser parser = new Parser();
        /*
        [TestMethod]
        public void TestCreateDataBase()
        {
            string input1 = "CREATE DATABASE alumnos";
            string input2 = "CREATE DATA alumnos";
            string input3 = "CREATE BASE alumnos";
            string input4 = "create base alumnos";

            string pattern = @"CREATE DATABASE\s+(\w+)(\;)";
            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input1, pattern));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input2, pattern));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input3, pattern));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input4, pattern));
        }

        [TestMethod]
        public void TestDropDataBase()
        {
            string input1 = "DROP DATABASE alumnos;";
            string input2 = "DROP DATABASES alumnos;";

            string pattern = @"DROP DATABASE\s+(\w+)(\;)";
            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input1, pattern));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input2, pattern));
        }
       
        [TestMethod]
        public void TestDropTable()
        {
            string input1 = "DROP TABLE werq;";
            string input2 = "DROP table werq;";
            string input3 = "DROP DATABASE 'sdfghj';";

            string pattern = @"DROP TABLE\s+(\w+)(\;)";
            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input1, pattern));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input2, pattern));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input3, pattern));
        }

        /* public void TestManageDropTable()
        {
            string query = @"DROP TABLE table1;";  
            ClassDropTable dt = myClass.ManageDropTable(query);
            String name = "table1";
            ClassDropTable dtExpected = new ClassDropTable(name);
            Assert.AreEqual(dtExpected.GetName(), dt.GetName());
        }
        */
        
        /*

        [TestMethod]
        public void TestBackupDataBase()
        {
            string input1 = "BACKUP DATABASE qwert TO DISK = 'tyu';";
            string input2 = "BACKUP DATABASE qwert;";
            string input3 = "BACKUP DATABASE qwert TO DISK = 'tyu'";

            string pattern = @"BACKUP DATABASE\s+(\w+)\s+TO DISK\s+(\=)\s+(\'\w+\')(\;)";
            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input1, pattern));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input2, pattern));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input3, pattern));
        }

        [TestMethod]
        public void TestCreateTable()
        {
            string input1 = "CREATE TABLE qwer (INT PRIMARY KEY(7856));";
            string input2 = "CREATE TABLE qwer;";
            string input3 = "CREATE TABLE qwer (INT PRIMARY KEY(QWERTY));";
            string input4 = "CREATE TABLE qwer (INT PRIMARY KEY(wqerfg) FOREIGN KEY (sdfghj));";
            string input5 = "CREATE TABLE qwer (INT PRIMARY KEY(wqerfg) FOREIGN KEY (sdfghj) REFERENCES werty(fghj));";
            string input6 = "CREATE TABLE qwer (INT PRIMARY KEY(wqerfg) FOREIGN KEY (sdfghj) REFERENCES werty);";

            string pattern = @"CREATE TABLE\s+(\w+)\s+(\()(INT|DOUBLE|TEXT)\s+PRIMARY KEY(\()(\w+)(\))(?:\s+FOREIGN KEY\s+(\()(\w+)(\))\s+REFERENCES\s+(\w+)(\()(\w+)(\)))?(\))(\;)";
            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input1, pattern));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input2, pattern));
            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input3, pattern));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input4, pattern));
            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input5, pattern));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input6, pattern));
        }
        */
        
        [TestMethod]
        public void TestSelect()
        {
           Query instancia=  parser.parse("SELECT * FROM alumno");
           Assert.IsTrue(instancia.)
            /*   
               String input1 = "SELECT * FROM alumno";
               String input2 = "Select * FROM alumno WHERE age < 10";
               String input3 = "SELECT FROM alumno";
               String pattern = @"SELECT\s+(\*|\w+)\s+FROM\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+))?(\;)";


               Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input1, pattern));
               Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input2, pattern));
               Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input3, pattern));

              /* string[] wrongQueries = { "Select * FROM Table1;", "SELECT * FROM Table 1;", "SELECT * FROM Table1", "SELECT column1 FROM Table1;" };
               string[] correctQueries = { "SELECT * FROM Table1;", "SELECT  * FROM Table1 ;" };

               foreach (string query in wrongQueries)
                   Assert.IsNull(MiniSQLEngine.Parser.Parse(query));


               foreach (string query in correctQueries)
                   Assert.IsNotNull(MiniSQLEngine.Parser.Parse(query));
               */
            */
        }
        /*
        [TestMethod]
        public void TestDelete()
        {
            String input1 = "DELETE FROM alumno";
            String input2 = "DELETE FROM alumno WHERE nombre = Xabi";
            String input3 = "DELETE FROM ";
            String pattern = @"DELETE\s+FROM\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|<|>)\s+(\w+))?(\;)";

            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input1, pattern));
            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input2, pattern));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input3, pattern));

        }
        [TestMethod]
        public void TestInsert()
        {
            String input1 = "INSERT INTO alumno";
            String input2 = "INSERT INTO alumno WHERE nombre = Xabi";
            String input3 = "INSERT FROM alumno WHERE nombre = Xabi ";
            String pattern = @"INSERT INTO\s+(\*|\w+)(?:\s+[WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+)]+)?(\;)";

            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input1, pattern));
            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input2, pattern));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input3, pattern));

        }
        [TestMethod]
        public void TestUpdate()
        {

            String input1 = "UPDATE alumno SET nombre = Nadia WHERE nombre = Xabi";
            String input3 = "UPDATE alumno SET nombre = Nadia nombre = Xabi";
            String pattern = @"UPDATE\s+(\w+)\s+SET\s+(\w+)\s+=\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+))?(\;)";

            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input1, pattern));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input3, pattern));


        }
        */
    }
}
 