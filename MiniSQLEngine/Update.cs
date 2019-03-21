using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;
using System.Collections.Generic;

public class Update : Query
{
    String pColumns;
    String TableName { get; }
    String pContenido;
    List<string> ColumnNames = new List<string>();

    public Update(String columns, String table, String content)
    {
        pColumns = columns;
        TableName = table;
        pContenido = content;
    }
    public override String Run(Database db)
    {
        //get table

        Table table = db.GetTableByName(TableName);
        if (table == null) return Messages.TableDoesNotExist;

        //we need the column list to know the correct column

        List<Column> updateColumns = new List<Column>();

        if (ColumnNames.Count == 0)
            return Messages.WrongSyntax;

        else if (ColumnNames.Count == 1 && ColumnNames[0] == "*")
        {
            
            
        }



        throw new NotImplementedException();
    }

}