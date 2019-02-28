using System;
using System.Text.RegularExpressions;

public class DropTable
{
	public DropTable(String query)
    {
        string dropTable = @"DROP TABLE\s+(\*|\w+)(\;)";
        String[] partes = Regex.Split(query, dropTable); 
	
	}
}
