using MiniSQLEngine;
using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;
using System.Collections.Generic;

public class Insert : Query
{
    List<string> ColumnNames = new List<string>();
    string Values;
    string TableName { get; }

    public Insert (string table, string values, string left, string op, string right)
    {
       
        Values = values;
        TableName = table;
        this.Values = values;
        string[] valuesSeparated;
        valuesSeparated = values.Split(',');

        foreach (string valueSeparated in valuesSeparated)
            ColumnNames.Add(valueSeparated.Trim());
    }


    public override String Run(Database db)
    {   
         //Get the table
        Table table = db.GetTableByName(TableName);
        if (table == null) return Messages.TableDoesNotExist;



        List<Column> insertColumns = new List<Column>();

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
                
            }
            catch
            {
                return Messages.ColumnDoesNotExist;
            }
        }


    
        //String[] toReturn = new String[3];
        //Table leTable = new Table();

        ////String tit
        ////leTable.setTabla
        ////toReturn = {getTabla, contenido }

        //throw new NotImplementedException();
        return null;
    }
   
}
