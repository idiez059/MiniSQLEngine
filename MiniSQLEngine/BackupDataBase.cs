using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class BackupDataBase : Query
{
    String pBase;

    public BackupDataBase(String database)
    {
        pBase = database;
    }
    public override String Run(Database bd)
    {
        throw new NotImplementedException();
    }

    public string getBase()
    {
        return pBase;
    }

}
