using System;
using System.Text.RegularExpressions;

public class CreateTable : Query
{
    /*
	public CreateTable(String query)
    {
        string createTable = @"CREATE TABLE\s+(\w+)\s+(\()(INT|DOUBLE|TEXT)\s+PRIMARY KEY(\()(\w+)(\))(?:\s+FOREIGN KEY\s+(\()(\w+)(\))\s+REFERENCES\s+(\w+)(\()(\w+)(\)))?(\))(\;)";
        String[] partes = Regex.Split(query, createTable);
    }
    */

    String pTabla;
  
    public CreateTable(String tabla)
    {
        pTabla = tabla;
    }
    public override void Run()
    {
        throw new NotImplementedException();
    }

    public string getTabla()
    {
        return pTabla;
    }

}