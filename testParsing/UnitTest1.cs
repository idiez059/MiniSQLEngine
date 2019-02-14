using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace testParsing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSelect()
        {
            String input1 = "SELECT * FROM alumno";
            String input2 = "Select * FROM alumno WHERE age < 10";
            String input3 = "SELECT FROM alumno";
            String pattern = @"SELECT\s+(\*|\w+)\s+FROM\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+))?(\;)
";

            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input1, pattern));
            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input2, pattern));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input3, pattern));

        }
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
        public void TestUpdate()
        {
            String input1 = "UPDATE alumno SET nombre = Nadia WHERE nombre = Xabi";
            String input3 = "UPDATE alumno SET nombre = Nadia nombre = Xabi";
            String pattern = @"UPDATE\s+(\w+)\s+SET\s+(\w+)\s+=\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+))?(\;)";

            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input1, pattern));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input3, pattern));

        }

    }
}
