using System;

public class CreateDataBase
{
    public CreateDataBase(String query)
	{
        string  createDataBase =  @"CREATE DATABASE\s+(|\w+)(\;)";
        String[] partes = Regex.Split(query, createDataBase);
    }
}
