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

        List<Column> selectedColumns = new List<Column>();

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
}
