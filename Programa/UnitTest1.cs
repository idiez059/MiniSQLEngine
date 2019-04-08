using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using MiniSQLEngine;


namespace Programa
{
    [TestClass]
    public class EverythingWorks
    {
        private object query1;

        [TestMethod]
        public void Select()
        {
            Database db = new Database("name");
            MiniSQLEngine.Parser.Parse("CREATE TABLE table (column TEXT);");
            query1 = MiniSQLEngine.Parser.Parse("SELECT column FROM table;");
            Assert.IsInstanceOfType(query1, typeof(Select));
        }

        [TestMethod]
        public void Update()
        {          
            Database db = new Database("name");
            MiniSQLEngine.Parser.Parse("CREATE TABLE table (column TEXT);");
            query1 = MiniSQLEngine.Parser.Parse("UPDATE table SET value=value1 WHERE value=value1;");
            Assert.IsInstanceOfType(query1, typeof(Update));          
        }
        [TestMethod]
        public void Insert()
        {
            Database db = new Database("name");
            MiniSQLEngine.Parser.Parse("CREATE TABLE table (column TEXT);");
            query1 = MiniSQLEngine.Parser.Parse("INSERT INTO table (column) VALUES (column1);");
            Assert.IsInstanceOfType(query1, typeof(Insert));
        }
        [TestMethod]
        public void Delete()
        {
            Database db = new Database("name");
            MiniSQLEngine.Parser.Parse("CREATE TABLE table (column TEXT);");
            query1 = MiniSQLEngine.Parser.Parse("DELETE FROM table WHERE age = 42;");
            Assert.IsInstanceOfType(query1, typeof(Delete));
        }
        [TestMethod]
        public void CreateDatabase()
        {
            Database db = new Database("name");
            query1 = MiniSQLEngine.Parser.Parse("CREATE DATABASE database;");
            Assert.IsInstanceOfType(query1, typeof(CreateDataBase));
        }
        [TestMethod]
        public void CreateTable()
        {
            Database db = new Database("name");
            query1 = MiniSQLEngine.Parser.Parse("CREATE TABLE table (Int column1,Int column2);");
            Assert.IsInstanceOfType(query1, typeof(CreateTable));
        }
        [TestMethod]
        public void DropTable()
        {
            Database db = new Database("name");
            query1 = MiniSQLEngine.Parser.Parse("DROP TABLE table;");
            Assert.IsInstanceOfType(query1, typeof(DropTable));
        }
    }
}
