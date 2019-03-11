using System;
using System.Text.RegularExpressions;

public class BackupDataBase : Query
{
    String pBase;

    public BackupDataBase(String database)
    {
        pBase = database;
    }
    public override String Run()
    {
        throw new NotImplementedException();
    }

    public string getBase()
    {
        return pBase;
    }

}
