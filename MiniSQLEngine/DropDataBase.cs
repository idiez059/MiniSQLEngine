using System;
using System.Text.RegularExpressions;

public class DropDataBase
{
	public DropDataBase(String query)
	{
        string dropDataBase = @"DROP DATABASE\s+(\w+)(\;)";
        String[] partes = Regex.Split(query, dropDataBase);
    }
}
