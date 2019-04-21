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


        if(String.IsNullOrEmpty(ConditionOp))
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

                //create a list of columns, one for each of the requested columns
                List<Column> resultColumns = new List<Column>();
                foreach (string columnName in ColumnNames)
                    resultColumns.Add(new ColumnString(columnName)); //<- This is not 100% correct, but should work

                int numValues = table.ColumnByName(ConditionCol).GetNumValues();
               
                for (int i = 0; i <= numValues; i++) //esto hay que probarlo
                {
                    string gottenValue =
                        table.ColumnByName(ConditionCol).GetValueAsString(i);
                    bool comparation = CompareOp(gottenValue, ConditionValue, ConditionOp);
                    if (comparation == true)
                    {
                        int numRequestedColumns = ColumnNames.Count;
                        for (int colIndex = 0; colIndex < numRequestedColumns; colIndex++)
                        {
                            Column sourceColumn = table.ColumnByName(ColumnNames[colIndex]);
                            resultColumns[colIndex].AddValue(sourceColumn.GetValueAsString(i));
                        }
                    }
                }

                return new Table(table.Name, resultColumns).ToString();
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
                Console.WriteLine("Error comparing tuples, in Compare() method");
                return false;
        }
    }
}
