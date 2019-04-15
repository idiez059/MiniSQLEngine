using MiniSQLEngine;
using System;
using System.Text.RegularExpressions;

using System.Collections.Generic;

public class Insert : Query
{
    List<string> ColumnNames = new List<string>();
    string[] valuesSeparated;
    string TableName { get; }

    public Insert(string table, string values)
    {
        TableName = table;
        valuesSeparated = values.Split(',');
        for (int i = 0; i < valuesSeparated.Length; i++)
            valuesSeparated[i] = valuesSeparated[i].Trim(' ');
    }

    public Insert(string table,string columns, string values)
    {
        String[] columnList = columns.Split(',');
        foreach(String col in columnList)
        {
            ColumnNames.Add(col.Trim());
        }
        
        TableName = table;
        valuesSeparated = values.Split(',');
        
        for (int i = 0; i<valuesSeparated.Length; i++)
            valuesSeparated[i] = valuesSeparated[i].Trim(' ');
    }
    
    

    public override String Run(Database db)
    {

        if(ColumnNames.Count == 0)
        {
            db.Insert(TableName, valuesSeparated);
        }
        else
        {
            db.Insert(TableName, ColumnNames, valuesSeparated);
        }
        
        

        return null;
    }
   
}
