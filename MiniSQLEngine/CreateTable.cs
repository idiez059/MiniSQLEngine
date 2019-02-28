using System;
using System.Text.RegularExpressions;

public class CreateTable
{
	public CreateTable(String query)
    {
        string createTable = @"CREATE TABLE\s+(\w+)\s+(\()(INT|DOUBLE|TEXT)\s+PRIMARY KEY(\()(\w+)(\))(?:\s+FOREIGN KEY\s+(\()(\w+)(\))\s+REFERENCES\s+(\w+)(\()(\w+)(\)))?(\))(\;)";
        String[] partes = Regex.Split(query, createTable);
    }
}