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
        public void Select()
        {
            string[] wrongQueries = { "Select * FROM Table1;", "SELECT * FROM Table 1;", "SELECT * FROM Table1", "SELECT column1 FROM Table1;" };
            string[] correctQueries = { "SELECT * FROM Table1;", "SELECT  * FROM Table1 ;" };

            foreach (string query in wrongQueries)
                Assert.IsNull(MiniSQLEngine.Parser.Parser(query));


            foreach (string query in correctQueries)
                Assert.IsNotNull(MiniSQLEngine.Parser.Parser(query));
        }
        public void Insert()
        {
            string[] wrongQueries = { "INSERT FROM alumno WHERE nombre = Xabi;" };
            string[] correctQueries = { "INSERT INTO alumno;", "INSERT INTO alumno WHERE nombre = Xabi;" };
        
            foreach (string query in wrongQueries)
                Assert.IsNull(MiniSQLEngine.Parser.Parser(query));

            foreach (string query in correctQueries)
                Assert.IsNotNull(MiniSQLEngine.Parser.Parser(query));
        }
        public void Delete()
        {
            string[] wrongQueries = { "DELETE FROM ;" };
            string[] correctQueries = { "DELETE FROM alumno;", "DELETE FROM alumno WHERE nombre = Xabi;" };

            foreach (string query in wrongQueries)
                Assert.IsNull(MiniSQLEngine.Parser.Parser(query));

            foreach (string query in correctQueries)
                Assert.IsNotNull(MiniSQLEngine.Parser.Parser(query));
        }
        public void Update()
        {
            string[] wrongQueries = { "UPDATE alumno SET nombre = Nadia nombre = Xabi;" };
            string[] correctQueries = { " UPDATE alumno SET nombre = Nadia WHERE nombre = Xabi;"};

            foreach (string query in wrongQueries)
                Assert.IsNull(MiniSQLEngine.Parser.Parser(query));

            foreach (string query in correctQueries)
                Assert.IsNotNull(MiniSQLEngine.Parser.Parser(query));
        }
       
    }
}
 