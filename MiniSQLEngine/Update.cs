using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;
using System.Collections.Generic;

public class Update : Query
{
    String pColumns;
    String pTableName { get; }
    String pContenido;
    List<string> ColumnNames = new List<string>();
    List<string> Values = new List<string>();
    String pRigth;
    String pOp;
    String pLeft;

    public Update(String columns, String tableName, String left, String op, String rigth)
    {
        pColumns = columns;
        pTableName = tableName;
        pLeft = left;
        pOp = op;
        pRigth = rigth;
    }
    public override String Run(Database db)
    {
        //get table

        Table table = db.GetTableByName(pTableName);
        if (table == null) return Messages.TableDoesNotExist;

        //we need the column list to know the correct column
        if (ColumnNames.Count == 0)
        {
            if (table.Columns.Count != Values.Count)
                return Messages.WrongSyntax;
        }
        

        //List<Column> updateColumns = new List<Column>();

        //if (ColumnNames.Count == 0)
        //    return Messages.WrongSyntax;

        //else if (ColumnNames.Count == 1)
        //{
              
            
        //}



        throw new NotImplementedException();
    }

}