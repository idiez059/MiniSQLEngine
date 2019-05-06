using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;
using System.Collections.Generic;
using System.IO;

public class Update : Query
{
    String pTableName { get; }
    String pLeft;
    String pOp;
    String pRight;
    List<string> ColumnNames = new List<string>();
    List<string> Values = new List<string>();
    List<string> ValuesWhere = new List<string>();

    public Update(String tableName, String updates, String left, String op, String right)
    {
        pTableName = tableName;
        pLeft = left;
        pOp = op;
        pRight = right;

        String[] updatesSeparated = updates.Split(',');
        foreach (string update in updatesSeparated)
        {
            //Name='Bernardo'
            string[] parts = update.Split('=');
            ColumnNames.Add(parts[0]);
            Values.Add(parts[1]);
        }
    }
    private bool CompareOp(string columns, string elem1, string elem2, string operat)
    {
        switch (operat)
        {
            case "=":
                return elem1 == elem2;
            case "<":
                int j = string.Compare(elem1, elem2);
                if (j == -1) { return true; }
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

    public override String Run(Database db)
    {
        //get table
        List<int> position = new List<int>();
        Table table = db.GetTableByName(pTableName);

        if (table == null) return Messages.TableDoesNotExist;

        if (ColumnNames.Count != Values.Count)
            return Messages.WrongSyntax;

        //we need the column list to know the correct column
        int numValues = table.ColumnByName(pLeft).GetNumValues();
        numValues--;
        for (int i = 0; i < numValues; i++) 
        {
            
            string value = table.ColumnByName(pLeft).GetValueAsString(i).Trim('\'');
            bool comparation = CompareOp(ColumnNames[i], value, pRight, pOp);
            if (comparation == true)
            {
                for (int j=0; j< Values.Count; j++)
                {
                    //por qué lo cambia al final
                    Column column = table.ColumnByName(ColumnNames[j]);

                    column.SetValueAsString(i,Values[j]);

                    
                }
            }
        }

        
        return Messages.TupleUpdateSuccess;
    
    }

}