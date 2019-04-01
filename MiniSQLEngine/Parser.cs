using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace MiniSQLEngine { 


    public class Parser
    {
        
        public Parser()
        {
            
        }

        public static Query Parse(string query)
          
        {
            //devuelve subclase de query que se ejecutara en el metodo run que llamara al select de la base de datos

            string select = @"SELECT\s+(\*|\w+)\s+FROM\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+))?(\;)";
            string update = @"UPDATE\s+(\w+)\s+SET\s+([\w\,\=]+)\s+WHERE\s+(\w+)\s*(=|<|>)\s*(\w+);";
           // string update = @"UPDATE\s+(\w+)\s+SET\s+(\w+)\s+=\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+))?(\;)";
            string delete = @"DELETE\s+FROM\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|<|>)\s+(\w+))?(\;)";
            //HAY QUE REPETIRLO
            string insert = @"INSERT\s+INTO\s+(\w+)\s+\(([^\)]+)\)\s+VALUES\s+\(([^\)]+)\);";
            string insert2 = @"INSERT\s+INTO\s+(\w+)\s+VALUES\s+\(([^\)]+)\);";

            string createDataBase = @"CREATE DATABASE\s+(|\w+)(\;)";
            string dropDataBase = @"DROP DATABASE\s+(\w+)(\;)";
            string dropTable = @"DROP TABLE\s+(\*|\w+)(\;)";
            string backupDataBase = @"BACKUP DATABASE\s+(\w+)\s+TO DISK\s+(\=)\s+(\'\w+\')(\;)";
            string createTable = @"CREATE TABLE\s+(\w+)\s+\(([^\)]+)\)\s*\;";

            //Select
            Match match = Regex.Match(query, select);
            if (match.Success)
            {
                String columns = match.Groups[1].Value;
                String table = match.Groups[2].Value;
                String left = match.Groups[3].Value;
                String op = match.Groups[4].Value;
                String right = match.Groups[5].Value;


                return new Select(columns,table,left,op,right);
            }


            //Update
            match = Regex.Match(query, update);
            if (match.Success)
            {
                String table = match.Groups[1].Value;
                String updates = match.Groups[2].Value;
                String left = match.Groups[3].Value;
                String op = match.Groups[4].Value;
                String right = match.Groups[5].Value;

                return new Update(table,updates, left,op,right);
            }

            //Delete
            match = Regex.Match(query, delete);
            if (match.Success)
            {

                String table = match.Groups[1].Value;
                String left = match.Groups[2].Value;
                String op = match.Groups[3].Value;
                String right = match.Groups[4].Value;

                return new Delete(table,left,op,right);
            }

            //insert without columns
            match = Regex.Match(query, insert2);
            if (match.Success)
            {

                String table = match.Groups[1].Value;
                String values = match.Groups[2].Value;
                String left = match.Groups[3].Value;
                String op = match.Groups[4].Value;
                String right = match.Groups[5].Value;


                return new Insert(table, values, left, op, right);
            }

            //Insert with columns
            match = Regex.Match(query, insert);
            if (match.Success)
            {

                String table = match.Groups[1].Value;
                String columns = match.Groups[2].Value;
                String values = match.Groups[3].Value;
                String left = match.Groups[4].Value;
                String op = match.Groups[5].Value;
                String right = match.Groups[6].Value;


                return new Insert(table,columns, values,left,op,right);
            }

            //CreateDataBase
            match = Regex.Match(query, createDataBase);
            if (match.Success)
            {
                String nombreBD = match.Groups[0].Value;

                return new CreateDataBase(nombreBD);
            }

            //DropDataBase
            match = Regex.Match(query, dropDataBase);
            if (match.Success)
            {
                String nombreDB = match.Groups[0].Value;
                return new DropDataBase(nombreDB);
            }

            //DropTable
            match = Regex.Match(query, dropTable);
            if (match.Success)
            {
                
                String nombreTabla = match.Groups[0].Value;
                return new DropTable(nombreTabla);
            }

            //BackupDataBase
            Match matchBackupDataBase = Regex.Match(query, backupDataBase);
            if (matchBackupDataBase.Success)
            {                
                String nombreBD = matchBackupDataBase.Groups[0].Value;
               return new BackupDataBase(nombreBD);

            }

            //CreateTable
            Match matchCreateTable = Regex.Match(query, createTable);
            if (matchCreateTable.Success)
            {
                String nombreTabla = matchCreateTable.Groups[1].Value;
                String tipoDato = matchCreateTable.Groups[2].Value;
                return new CreateTable(nombreTabla, tipoDato);
            }
            return null;
        }
    }
}