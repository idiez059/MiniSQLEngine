using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class Delete : Query
{
    String pTable;
    String pContent;

    List<string> ColumnNames = new List<string>();
    String TableName { get; }
    String Condition;

    public Delete( String table, String content)
    {
        TableName = table;
        
    }
    public override String Run(Database bd)
    {
        //Get the table
        //Table table = db.GetTableByName(TableName);
        //if (table == null) return Messages.TableDoesNotExist;
        return null;
    }
}
