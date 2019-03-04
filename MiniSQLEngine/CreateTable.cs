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
    String pPK;
    String pFK;
  
    public CreateTable(String tabla, String pk,String fk)
    {
        pTabla = tabla;
        pPK = pk;
        pFK = fk;

    }
    public override void Run()
    {
        throw new NotImplementedException();
    }
    public string getFK()
    {
        return pFK;
    }
    public string getPK()
    {
        return pPK;
    }
    public string getTabla()
    {
        return pTabla;
    }

}