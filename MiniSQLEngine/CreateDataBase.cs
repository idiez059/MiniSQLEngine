using System;
using System.Text.RegularExpressions;

public class CreateDataBase : Query
{
    String pBase;

    public CreateDataBase(String database)
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
