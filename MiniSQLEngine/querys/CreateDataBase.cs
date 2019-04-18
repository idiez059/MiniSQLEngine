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
        //This is not correct, further storage of the created database is required, but access it from outside as the method returns a string
        Database database = new Database(pBase,"uhgdfyg","jhfh");
        return "Database: " + pBase + " created successfully.";
    }

    public string getBase()
    {
        return pBase;
    }
}
