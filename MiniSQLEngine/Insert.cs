using MiniSQLEngine;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Insert : Query
{
    List<string> ColumnNames = new List<string>();
    string[] valuesSeparated;
    string TableName { get; }

    public Insert(string table,string columns, string values, string left, string op, string right)
    {
        String[] columnList = columns.Split(',');
        foreach(String col in columnList)
        {
            ColumnNames.Add(col);
        }
        
        TableName = table;
        valuesSeparated = values.Split(',');

    }

    public override String Run(Database db)
    {
        Table table = db.GetTableByName(TableName);
        if (table == null)
        {
            return Messages.TableDoesNotExist;
        }
        int cont = 0;

        //if ()
        //{
            foreach (Column column in table.Columns)
            { 
                if (ColumnNames.Contains(column.Name))
                {
                    column.AddValue(valuesSeparated[cont]);
                    cont++;
                }
                else
                {
                    column.InsertEmpty();

                }
            
            }
        //}
        
    
        return null;
    }
   
}
