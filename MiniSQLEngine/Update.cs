using System;
using System.Text.RegularExpressions;

public class Update
{
    public Update(String query)
    {
        string update = @"UPDATE\s+(\w+)\s+SET\s+(\w+)\s+=\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+))?(\;)";
        String[] partes = Regex.Split(query, update);
    }
}