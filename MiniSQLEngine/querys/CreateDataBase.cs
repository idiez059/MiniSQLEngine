using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class CreateDataBase : Query
{
    String pBase;
    String pUserName;
    String pPassword;
    String result;

    public CreateDataBase(String database, String userName, String password)
    {
        pBase = database;
        pUserName = userName;
        pPassword = password;
    }
    public override String Run(Database bd)
    {
        //This is not correct, further storage of the created database is required, but access it from outside as the method returns a string
        Database database = new Database(pBase,pUserName,pPassword);
        result = "Database: " + pBase + " created successfully.";
        return "Database: " + pBase + " created successfully.";
    }

    public string getBase()
    {
        return pBase;
    }
    public string getResult()
    {
        return result;
    }
}
