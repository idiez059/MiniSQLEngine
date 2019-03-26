using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;
using System.Collections.Generic;

public class Select : Query
{
    List<string> ColumnNames = new List<string>();
    String TableName { get; }
    String Condition;
    public Select(string columns, string table, string condition)
	{
        //parse the list of columns
        string [] columnNames = columns.Split(',');
        foreach (string columnName in columnNames)
            ColumnNames.Add(columnName.Trim()); //Trim() removes spaces from the start and end

        TableName = table;
        this.Condition = condition;
	}
    public override String Run(Database db)
    {
        //Get the table
        Table table = db.GetTableByName(TableName);
        if (table == null) return Messages.TableDoesNotExist;
        //List<Column> selectedColumns = new List<Column>();


        if(Condition == null)
        {        
            if (ColumnNames.Count == 0)
                return Messages.WrongSyntax;
            else if (ColumnNames.Count == 1 && ColumnNames[0] == "*")
            {
                //SELECT *
                return db.SelectAll(TableName).ToString();
            }
            else
            {
                //SELECT Name,Age,...
                try
                {
                    return db.SelectColumns(TableName, ColumnNames).ToString();
                }
                catch
                {
                    return Messages.ColumnDoesNotExist;
                }
            }
        }
        else
        {
            if (ColumnNames.Count == 0)
                return Messages.WrongSyntax;
            else if (ColumnNames.Count == 1 && ColumnNames[0] == "*")
            {
                //SELECT *
                return db.SelectAll(TableName).ToString();
            }
            else
            {
                //SELECT Name,Age,... & condition
                string[] splitCond = Condition.Split(' ');
                Column condColumn = table.ColumnByName(splitCond[0]);
                string condColumnName = splitCond[0].Trim();
                string condSymbol = splitCond[1].Trim();
                string condValue = splitCond[2].Trim();
                
                //Handle condition


                //if (condSymbol == "=")
                //{
                //    //condTable = db.SelectColumns(TableName, ColumnNames);
                //    List<Column> selectedCondColumns = new List<Column>();
                //    int colValueNum = table.ColumnByName(condColumnName).
                //        GetNumValues();
                //    for (int i=0; colValueNum > i; i++)
                //    {
                //        string gottenValue =
                //        table.ColumnByName(condColumnName).GetValueAsString(i);

                //        if(gottenValue == condValue)
                //        {
                            
                //            selectedCondColumns.Add(toAdd);
                //            Table condTable = new Table(TableName, selectedColumns);
                //            return condTable.ToString();
                //        }
                //    }

                //}
                //else if (condSymbol == "<")
                //{

                //}
                //else if (condSymbol == ">")
                //{

                //}
                //else
                //{
                //    return Messages.ConditionDoesNotExist;
                //}
                try
                {
                    return db.SelectColumns(TableName, ColumnNames).ToString();
                }
                catch
                {
                    return Messages.ColumnDoesNotExist;
                }
            }
        }
    }
    private bool CompareOp(string elem1, string elem2, string operat)
    {
        switch (operat)
        {
            case "=":
                return elem1 == elem2;
            case "<":
                int j = string.Compare(elem1, elem2);
                if(j == -1) {return true;}
                else { return false; }
            case ">":
                int k = string.Compare(elem1, elem2);
                if (k == 1) { return true; }
                else { return false; }
            default:
                System.Console.WriteLine("Error comparing tuples, in Compare() method");
                return false;
        }
    }
}
