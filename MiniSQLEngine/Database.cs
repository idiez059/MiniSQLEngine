using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;
using MiniSQLEngine;


namespace MiniSQLEngine
{
    public class Database
    {
        public String Name { get; }
        private List<Table> Tables = new List<Table>();

        public Database(string dbName)
        {
            Name = dbName;
        }

        /// <summary>
        /// Get a table by its name
        /// </summary>
        /// <param name="name">The name of the table</param>
        /// <returns>Returns the table or null if not found</returns>
        public Table GetTableByName(String name)
        {
            foreach (Table table in Tables)
            {
                if (table.Name==name)
                {
                    return table;
                }
            }
            return null ;
        }

        /// <summary>
        /// Creates a table
        /// </summary>
        /// <param name="name">Name of the new table</param>
        /// <param name="columns">Columns to be added to the table</param>
        /// <returns>returns an error/success message</returns>
        public string CreateTable(string name, List<Column> columns)
        {
            if (GetTableByName(name) != null)
                return Messages.TableErrorAlreadyExists;
            else
            {
                try
                {
                    Table table = new Table(name, columns);
                    Tables.Add(table);
                    return Messages.CreateTableSuccess;
                }
                catch
                {
                    return Messages.WrongSyntax;
                }
            }
        }

        public void Update(String columns, String tableName, String left, String op, String rigth)
        {
            Table table = GetTableByName(tableName);
            table.ColumnByName(columns);

            //paso los mismos parametros que me han enviado 

            table.Update(columns,tableName, left, op, rigth);
        }
        public Table SelectAll(string tableName)
        {
            return GetTableByName(tableName);
        }
        public Table SelectColumns(string tableName, List<string> columnNames)
        {
            Table sourceTable = GetTableByName(tableName);
            List<Column> selectedColumns = new List<Column>();
            //Else only selected ones
            foreach (string columnName in columnNames)
            {
                if (columnName == "*")
                    return null; // we don't allow "SELECT *,Name ...", only "SELECT * ..."

                Column column = sourceTable.ColumnByName(columnName);
                if (column != null)
                    selectedColumns.Add(column);
                else return null;
            }
            Table result = new Table("Result",selectedColumns);
            return result;
        }



        public String RunQuery(string line)
        {
            Query theQuery = Parser.Parse(line);
            return theQuery.Run(this);
        }
    }

}