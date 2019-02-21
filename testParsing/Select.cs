using System;
using System.Text.RegularExpressions;

public class Select
{
    public Select(String query)
	{
        string select = @"SELECT\s+(\*|\w+)\s+FROM\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+))?(\;)";
        String[] partes = Regex.Split(query,select);
        
	}
}
