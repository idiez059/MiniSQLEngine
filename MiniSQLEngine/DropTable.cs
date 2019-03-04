using System;
using System.Text.RegularExpressions;

public class DropTable : Query
{
    /*
	public DropTable(String query)
    {
        string dropTable = @"DROP TABLE\s+(\*|\w+)(\;)";
        String[] partes = Regex.Split(query, dropTable); 
	
	}
    */

    String pColumns;
    String pTabla;
    String pContenido;
    public DropTable(String tabla)
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
