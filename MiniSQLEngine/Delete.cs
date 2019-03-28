using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class Delete : Query
{
    String pTableName;
    String pLeft;
    String pOp;
    int pRight;   
    
    public Delete(String table, String left, String op, String right)
    {
        pTableName = table;
        pLeft = left;
        pOp = op;
        pRight = int.Parse(right);     
    }

    public override String Run(Database bd)
    {
        //Get the table
        Table table = bd.GetTableByName(pTableName);
        if (table == null) return Messages.TableDoesNotExist;
        return bd.DeleteRows(pTableName, pLeft, pOp, pRight).ToString();
    }
}
