using System;
using System.Text.RegularExpressions;

public class CreateDataBase : Query
{
    /*
    public CreateDataBase(String query)
	{
        string  createDataBase =  @"CREATE DATABASE\s+(|\w+)(\;)";
        String[] partes = Regex.Split(query, createDataBase);
    }
    */
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
