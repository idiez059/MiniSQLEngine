using System;
using System.Text.RegularExpressions;

public class DropDataBase : Query
{
    /*
	public DropDataBase(String query)
	{
        string dropDataBase = @"DROP DATABASE\s+(\w+)(\;)";
        String[] partes = Regex.Split(query, dropDataBase);
    }
    */

    String pBase;
    
    public DropDataBase(String base)
    {
       pBase = base; 
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
