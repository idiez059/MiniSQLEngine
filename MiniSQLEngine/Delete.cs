using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class Delete : Query
{
    String pTable;
    String pLeft;
    String pOp;
    String pRight;

    List<string> ColumnNames = new List<string>();
    String TableName { get; }
    String Condition;

    public Delete(String table, String left, String op, string right)
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
