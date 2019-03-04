﻿using System;
using System.Text.RegularExpressions;

namespace MiniSQLEngine.Parser
{

    public class Parser
    {
        public Query Parserito()
        {
            
        }

        public void parse(string input) {
        //devuelve subclase de query que se ejecutara en el metodo run que llamara al select de la base de datos

        string select = @"SELECT\s+(\*|\w+)\s+FROM\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+))?(\;)";
        string update = @"UPDATE\s+(\w+)\s+SET\s+(\w+)\s+=\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+))?(\;)";
        string delete = @"DELETE\s+FROM\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|<|>)\s+(\w+))?(\;)";
        string insert = @"INSERT INTO\s+(\*|\w+)(?:\s+[WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+)]+)?(\;)";

        string createDataBase = @"CREATE DATABASE\s+(|\w+)(\;)";
        string dropDataBase = @"DROP DATABASE\s+(\w+)(\;)";
        string dropTable = @"DROP TABLE\s+(\*|\w+)(\;)";
        string backupDataBase = @"BACKUP DATABASE\s+(\w+)\s+TO DISK\s+(\=)\s+(\'\w+\')(\;)";
        string createTable = @"CREATE TABLE\s+(\w+)\s+(\()(INT|DOUBLE|TEXT)\s+PRIMARY KEY(\()(\w+)(\))(?:\s+FOREIGN KEY\s+(\()(\w+)(\))\s+REFERENCES\s+(\w+)(\()(\w+)(\)))?(\))(\;)";

        // we search only one coincidence 
        Console.WriteLine("Regex.Match()");

            //Select
            Match matchSelect = Regex.Match(input, select);
            if (matchSelect.Success)
            {
                String columns = matchSelect.Groups[0].Value;
        String tabla = matchSelect.Groups[1].Value;
        String contenido = matchSelect.Groups[2].Value;

                return new Select(columns, tabla, contenido);
    }

    //Update
    Match matchUpdate = Regex.Match(input, update);
            if (matchUpdate.Success)
            {
                String columns = match.Groups[0].Value;
                String tabla = match.Groups[1].Value;
                String contenido = match.Groups[2].Value;

                return new Update(columns, tabla, contenido);
            }
            Match match2 = Regex.Match(input, delete);
            if (match.Success)
            {
              
                String tabla = match.Groups[0].Value;
                String contenido = match.Groups[1].Value;

                return new Delete(tabla, contenido);
            }

            Match match3 = Regex.Match(input, insert);
            if (match.Success)
            {
              
                String tabla = match.Groups[0].Value;
                String contenido = match.Groups[1].Value;

                return new Insert( tabla, contenido);
            }
                  
            //    else if (matchInsert.Success)
            //    {
            //        Match matchInsert = Regex.Match(input, insert);
            //        matchInsert.Groups;
            //        new Insert(input);
            //    }
            //    else if (matchCreateDataBase.Success)
            //    {
            //        Match matchCreateDataBase = Regex.Match(input, createDataBase);
            //        matchCreateDataBase.Groups;
            //        new CreateDataBase(input);
            //    }
            //    else if (matchDropDataBase.Success)
            //    {
            //        Match matchDropDataBase = Regex.Match(input, dropDataBase);
            //        matchDropDataBase.Groups;
            //        new DropDataBase(input);
            //    }
            //    else if (matchDropTable.Success)
            //    {
            //        Match matchDropTable = Regex.Match(input, dropTable);
            //        matchDropTable.Groups;
            //        new DropTable(input);
            //    }
            //    else if (matchBackupDataBase.Success)
            //    {
            //        Match matchBackupDataBase = Regex.Match(input, backupDataBase);
            //        matchBackupDataBase.Groups;
            //        new BackupDataBase(input);
            //    }
            //    else if (matchCreateTable.Success)
            //    {
            //        Match matchCreateTable = Regex.Match(input, createTable);
            //        matchCreateTable.Groups;
            //        new CreateTable(input);
            //    }
            return null;
        }
}
