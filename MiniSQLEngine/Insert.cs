using MiniSQLEngine;
using System;
using System.Text.RegularExpressions;

using System.Collections.Generic;

public class Insert : Query
{
    List<string> ColumnNames = new List<string>();
    string Values;
    string TableName { get; }

    public Insert (string table, string values, string left, string op, string right)
    {
       
        Values = values;
        TableName = table;
        this.Values = values;
        string[] valuesSeparated;
        valuesSeparated = Values.Split(',');

        foreach (string valueSeparated in valuesSeparated)
            ColumnNames.Add(valueSeparated.Trim());
    }


    public override String Run(Database db)
    {

        return null;
    }
   
}
