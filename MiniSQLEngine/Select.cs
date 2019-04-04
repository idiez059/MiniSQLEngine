using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;
using System.Collections.Generic;

public class Select : Query
{
    List<string> ColumnNames = new List<string>();
    String TableName { get; }
    String ConditionCol;
    String ConditionOp;
    String ConditionValue;
    public Select(string columns, string table, string condCol, string condOp, string condValue)
	{
        //parse the list of columns
        string [] columnNames = columns.Split(',');
        foreach (string columnName in columnNames)
            ColumnNames.Add(columnName.Trim()); //Trim() removes spaces from the start and end

        TableName = table;
        this.ConditionCol = condCol;
        this.ConditionOp = condOp;
        this.ConditionValue = condValue;
	}
    public override String Run(Database db)
    {
        //Get the table
        Table table = db.GetTableByName(TableName);
        if (table == null) return Messages.TableDoesNotExist;
        //List<Column> selectedColumns = new List<Column>();


        if(ConditionOp == null)
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
            {
                return Messages.WrongSyntax;
            }
            else
            {
                //SELECT Name,Age,... & condition
                //Handle condition
                int numValues = table.ColumnByName(ConditionCol).GetNumValues();
                numValues--;
                for (int i = 0; i <= numValues; i++) //esto hay que probarlo
                {
                    string gottenValue =
                        table.ColumnByName(ConditionCol).GetValueAsString(i);
                    bool comparation = CompareOp(gottenValue, ConditionValue, ConditionOp);
                    if (comparation == false)
                    {
                        //preguntar en clase RemoveAt(i)
                        //no estoy seguro
                        foreach (Column delColTuple in table.Columns)
                        {
                            delColTuple.RemoveValueAtIndex(i);
                        }
                        i--;
                        numValues--;
                    }
                }
                return table.ToString();
                //try
                //{
                //    return db.SelectColumns(TableName, ColumnNames).ToString();
                //}
                //catch
                //{
                //    return Messages.ColumnDoesNotExist;
                //}
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
