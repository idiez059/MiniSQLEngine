using System;
using System.Text.RegularExpressions;

public class Insert
{
	public Insert(String query)
    {
        string insert = @"INSERT INTO\s+(\*|\w+)(?:\s+[WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+)]+)?(\;)";
        String[] partes = Regex.Split(query, insert); 
	
	}
}
