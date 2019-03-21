using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class DropDataBase : Query
{
    
    String pBase;

    public DropDataBase(String database)
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
