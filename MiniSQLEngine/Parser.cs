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
            string update = @"UPDATE\s+(\w+)\s+SET\s+(\w+)\s+=\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+))?(\;)";
            string delete = @"DELETE\s+FROM\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|<|>)\s+(\w+))?(\;)";
            //HAY QUE REPETIRLO
            string insert = @"INSERT INTO\s+(\*|\w+)\s+VALUES\s+\(([^\)]+)\)(?:\s+[WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+)]+)?(\;)";

            string createDataBase = @"CREATE DATABASE\s+(|\w+)(\;)";
            string dropDataBase = @"DROP DATABASE\s+(\w+)(\;)";
            string dropTable = @"DROP TABLE\s+(\*|\w+)(\;)";
            string backupDataBase = @"BACKUP DATABASE\s+(\w+)\s+TO DISK\s+(\=)\s+(\'\w+\')(\;)";
            string createTable = @"CREATE TABLE\s+(\w+)\s+(\()(INT|DOUBLE|TEXT)\s+PRIMARY KEY(\()(\w+)(\),)(?:\s+FOREIGN KEY\s+(\()(\w+)(\),)\s+REFERENCES\s+(\w+)(\()(\w+)(\)))?(\))(\;)";

            //Select
            Match matchSelect = Regex.Match(query, select);
            if (matchSelect.Success)
            {
                String columns = matchSelect.Groups[0].Value;
                String table = matchSelect.Groups[1].Value;
                String condition = matchSelect.Groups[2].Value;
                String left = matchSelect.Groups[2].Value;
                String op = matchSelect.Groups[3].Value;
                String right = matchSelect.Groups[4].Value;


                return new Select(columns,table,condition);
            }
                

            //Update
            Match matchUpdate = Regex.Match(query, update);
            if (matchUpdate.Success)
            {
                String columns = matchUpdate.Groups[0].Value;
                String table = matchUpdate.Groups[1].Value;
                String left = matchUpdate.Groups[2].Value;
                String op = matchUpdate.Groups[3].Value;
                String right = matchUpdate.Groups[4].Value;

                return new Update(columns,table,left,op,right);
            }

            //Delete
            Match matchDelete = Regex.Match(query, delete);
            if (matchDelete.Success)
            {

                String table = matchDelete.Groups[0].Value;
                String left = matchDelete.Groups[1].Value;
                String op = matchDelete.Groups[2].Value;
                String right = matchDelete.Groups[3].Value;

                return new Delete(table,left,op,right);
            }

            //Insert
            Match matchInsert = Regex.Match(query, insert);
            if (matchInsert.Success)
            {

                String table = matchInsert.Groups[0].Value;
                String values = matchInsert.Groups[1].Value;
                String left = matchInsert.Groups[2].Value;
                String op = matchInsert.Groups[3].Value;
                String right = matchInsert.Groups[4].Value;


                return new Insert(table,values,left,op,right);
            }

            //CreateDataBase
            Match matchCreateDataBase = Regex.Match(query, createDataBase);
            if (matchCreateDataBase.Success)
            {
                String nombreBD = matchCreateDataBase.Groups[0].Value;

                return new CreateDataBase(nombreBD);
            }

            //DropDataBase
            Match matchDropDataBase = Regex.Match(query, dropDataBase);
            if (matchDropDataBase.Success)
            {
                String nombreDB = matchDropDataBase.Groups[0].Value;
                return new DropDataBase(nombreDB);
            }

            //DropTable
            Match matchDropTable = Regex.Match(query, dropTable);
            if (matchDropTable.Success)
            {
                
                String nombreTabla = matchDropTable.Groups[0].Value;
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
                
                String nombreTabla = matchCreateTable.Groups[0].Value;
                String tipoDato = matchCreateTable.Groups[1].Value;
                String pk = matchCreateTable.Groups[2].Value;
                String fk = matchCreateTable.Groups[3].Value;
                return new CreateTable(nombreTabla, tipoDato, pk, fk);
            }
            return null;
        }
    }
}