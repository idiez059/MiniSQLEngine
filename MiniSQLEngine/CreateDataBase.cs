using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class CreateDataBase : Query
{
    String pBase;

    public CreateDataBase(String database)
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
