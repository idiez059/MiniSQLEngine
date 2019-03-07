using System;
using System.Text.RegularExpressions;

public class DropDataBase : Query
{
    
    String pBase;

    public DropDataBase(String database)
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
