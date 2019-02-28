using System;
using System.Text.RegularExpressions;

namespace MiniSQLEngine.Parser
{

    public class Parser
    {
        public Parser()
        {
            //devuelve subclase de query que se ejecutara en el metodo run que llamara al select de la base de datos

            string input = Console.ReadLine();

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


            if (matchSelect.Success)
            {
                Match matchSelect = Regex.Match(input, select);
                matchSelect.Groups;
                String seleccion = Match.Groups[0].Value;
                String tabla = Match.Groups[1].Value;
                //create enumerator for enumerating
                IEnumerator<int> cont = condiciones.GetEnumerator();
                bool hasNext = cont.MoveNext();
                cont.MoveNext();
                cont.MoveNext();
                while (hasNext)
                {
                    int i = cont.Current;
                    hasNext = cont.MoveNext();
                    String[] condiciones = NextMatch();
                }
                new Select(seleccion, tabla, condiciones);
            }
            else if (matchUpdate.Success)
            {
                Match matchUpdate = Regex.Match(input, update);
                matchUpdate.Groups;
                new Update(input);
            }
            else if (matchDelete.Success)
            {
                Match matchDelete = Regex.Match(input, delete);
                matchDelete.Groups;
                new Delete(input);
            }
            else if (matchInsert.Success)
            {
                Match matchInsert = Regex.Match(input, insert);
                matchInsert.Groups;
                new Insert(input);
            }
            else if (matchCreateDataBase.Success)
            {
                Match matchCreateDataBase = Regex.Match(input, createDataBase);
                matchCreateDataBase.Groups;
                new CreateDataBase(input);
            }
            else if (matchDropDataBase.Success)
            {
                Match matchDropDataBase = Regex.Match(input, dropDataBase);
                matchDropDataBase.Groups;
                new DropDataBase(input);
            }
            else if (matchDropTable.Success)
            {
                Match matchDropTable = Regex.Match(input, dropTable);
                matchDropTable.Groups;
                new DropTable(input);
            }
            else if (matchBackupDataBase.Success)
            {
                Match matchBackupDataBase = Regex.Match(input, backupDataBase);
                matchBackupDataBase.Groups;
                new BackupDataBase(input);
            }
            else if (matchCreateTable.Success)
            {
                Match matchCreateTable = Regex.Match(input, createTable);
                matchCreateTable.Groups;
                new CreateTable(input);
            }
        }
    }
}
