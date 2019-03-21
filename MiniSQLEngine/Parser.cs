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
            string insert = @"INSERT INTO\s+(\*|\w+)(?:\s+[WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+)]+)?(\;)";

            string createDataBase = @"CREATE DATABASE\s+(|\w+)(\;)";
            string dropDataBase = @"DROP DATABASE\s+(\w+)(\;)";
            string dropTable = @"DROP TABLE\s+(\*|\w+)(\;)";
            string backupDataBase = @"BACKUP DATABASE\s+(\w+)\s+TO DISK\s+(\=)\s+(\'\w+\')(\;)";
            string createTable = @"CREATE TABLE\s+(\w+)\s+(\()(INT|DOUBLE|TEXT)\s+PRIMARY KEY(\()(\w+)(\),)(?:\s+FOREIGN KEY\s+(\()(\w+)(\),)\s+REFERENCES\s+(\w+)(\()(\w+)(\)))?(\))(\;)";

            //Select
            Match matchSelect = Regex.Match(query, select);
            if (matchSelect.Success)
                return new Select(matchSelect.Groups[1].Value, matchSelect.Groups[2].Value, matchSelect.Groups[3].Value);

            //Update
            Match matchUpdate = Regex.Match(query, update);
            if (matchUpdate.Success)
            {
                String columns = matchUpdate.Groups[0].Value;
                String tabla = matchUpdate.Groups[1].Value;
                String contenido = matchUpdate.Groups[2].Value;

                return new Update(columns, tabla, contenido);
            }

            //Delete
            Match matchDelete = Regex.Match(query, delete);
            if (matchDelete.Success)
            {

                String tabla = matchDelete.Groups[0].Value;
                String contenido = matchDelete.Groups[1].Value;

                return new Delete(tabla, contenido);
            }

            //Insert
            Match matchInsert = Regex.Match(query, insert);
            if (matchInsert.Success)
            {

                String tabla = matchInsert.Groups[0].Value;
                String columnas = matchInsert.Groups[1].Value;
                String valores = matchInsert.Groups[1].Value;


                return new Insert(tabla, columnas, valores);
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