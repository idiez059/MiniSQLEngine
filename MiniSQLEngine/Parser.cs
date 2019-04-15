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
            string update = @"UPDATE\s+(\w+)\s+SET\s+([\w\,\=\@\.]+)\s+WHERE\s+(\w+)\s*(=|<|>)\s*(\w+);";
            string delete = @"DELETE\s+FROM\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|<|>)\s+(\w+))?(\;)";
            string insert = @"INSERT\s+INTO\s+(\w+)\s+\(([^\)]+)\)\s+VALUES\s+\(([^\)]+)\);";
            string insert2 = @"INSERT\s+INTO\s+(\w+)\s+VALUES\s+\(([^\)]+)\);";

            string createDataBase = @"CREATE DATABASE\s+(|\w+)(\;)";
            string dropDataBase = @"DROP DATABASE\s+(\w+)(\;)";
            string dropTable = @"DROP TABLE\s+(\*|\w+)(\;)";
            string backupDataBase = @"BACKUP DATABASE\s+(\w+)\s+TO DISK\s+(\=)\s+(\'\w+\')(\;)";
            string createTable = @"CREATE TABLE\s+(\w+)\s+\(([^\)]+)\)\s*\;";

            string createSecProfile = @"CREATE SECURITY PROFILE\s+(\w+)\;";
            string dropSecProfile = @"DROP SECURITY PROFILE\s+(\w+)\;";

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

                return new Update(table, updates, left, op, right);
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
              


                return new Insert(table, values);
            }

            //Insert with columns
            match = Regex.Match(query, insert);
            if (match.Success)
            {

                String table = match.Groups[1].Value;
                String columns = match.Groups[2].Value;
                String values = match.Groups[3].Value;
                


                return new Insert(table, columns, values);
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
                
                String tableName = match.Groups[1].Value;
                return new DropTable(tableName);
            }

            //BackupDataBase
            match = Regex.Match(query, backupDataBase);
            if (match.Success)
            {                
                String nombreBD = match.Groups[0].Value;
               return new BackupDataBase(nombreBD);

            }

            //CreateTable
            match = Regex.Match(query, createTable);
            if (match.Success)
            {
                String nombreTabla = match.Groups[1].Value;
                String tipoDato = match.Groups[2].Value;
                return new CreateTable(nombreTabla, tipoDato);
            }

            //CreateSecProfile
            match = Regex.Match(query, createSecProfile);
            if (match.Success)
            {
                String profileName = match.Groups[1].Value;               
                return new CreateSecProfile(profileName);
            }

            //DropSecProfile
            match= Regex.Match(query, dropSecProfile);
            if (match.Success)
            {
                String profileName = match.Groups[1].Value;
                return new DropSecProfile(profileName);
            }


            return null;
        }
    }
}