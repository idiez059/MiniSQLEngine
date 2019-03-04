using System;
using System.Text.RegularExpressions;

public class BackupDataBase : Query
{
    /*
    public BackupDataBase (String query)
	{
        string  backupDataBase =  @"BACKUP DATABASE\s+(\w+)\s+TO DISK\s+(\=)\s+(\'\w+\')(\;)";
        String[] partes = Regex.Split(query, backupDataBase);
    }
    */

    String pBase;

    public BackupDataBase(String database)
    {
        pBase = database;
    }
    public override void Run()
    {
        throw new NotImplementedException();
    }

    public string getBase()
    {
        return pBase;
    }

}
