﻿using System;

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
        Match matchSelect = Regex.Match(input, select);
        Match matchUpdate = Regex.Match(input, update);
        Match matchDelete = Regex.Match(input, delete);
        Match matchInsert = Regex.Match(input, insert);

        Match matchCreateDataBase = Regex.Match(input, createDataBase);
        Match matchDropDataBase = Regex.Match(input, dropDataBase);
        Match matchDropTable = Regex.Match(input, dropTable);
        Match matchBackupDataBase = Regex.Match(input, backupDataBase);
        Match matchCreateTable = Regex.Match(input, createTable);
      
        if (matchSelect.Success)
        {
            new Select(input);
        }
        else if (matchUpdate.Success)
        {
            new Update(input);
        }
        else if (matchDelete.Success)
        {
            new Delete(input);
        }
        else if (matchInsert.Success)
        {
            new Insert(input);
        }
        else if (matchCreateDataBase.Success)
        {
            new CreateDataBase(input);
        }
        else if (matchDropDataBase.Success)
        {
            new DropDataBase(input);
        }
        else if (matchDropTable.Success)
        {
            new DropTable(input);
        }
        else if (matchBackupDataBase.Success)
        {
            new BackupDataBase(input);
        }
        else if (matchCreateTable.Success)
        {
            new CreateTable(input);
        }
    }
}
