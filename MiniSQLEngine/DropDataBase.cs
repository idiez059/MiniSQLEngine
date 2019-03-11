using System;
using System.Text.RegularExpressions;

public class DropDataBase : Query
{
    
    String pBase;

    public DropDataBase(String database)
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
