using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;
using System.Collections.Generic;

public class Update : Query
{
    
    String pTableName { get; }
    String pColumns;
    
    String pValues;
    String pLeft;
    String pOp;
    String pRigth;
    
    List<string> ColumnNames = new List<string>();
    List<string> Values = new List<string>();
    public Update(String tableName, String columns, String values, String left, String op, String rigth)
    {
        pTableName = tableName;
        pColumns = columns; 
        pValues = values;
        pLeft = left;
        pOp = op;
        pRigth = rigth;
      
        ColumnNames.Add(pColumns);
        ColumnNames.Add(pValues);

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