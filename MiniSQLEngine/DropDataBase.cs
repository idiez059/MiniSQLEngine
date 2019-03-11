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
    public override void Run(BDData bd)
    {
        throw new NotImplementedException();
    }

    public string getBase()
    {
        return pBase;
    }
}
