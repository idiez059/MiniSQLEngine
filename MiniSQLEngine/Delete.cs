using System;
using System.Text.RegularExpressions;

public class Delete
{
	public Delete (String query)
	{
        string delete = @"DELETE\s+FROM\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|<|>)\s+(\w+))?(\;)";
        String[] partes = Regex.Split(query, delete);
    }
}
