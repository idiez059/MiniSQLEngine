using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class CreateTable : Query
{
    
    String pTabla;
    List<String> columnNames = new List<String>();
    List<String> pTipoDato = new List<String>();
  
    public CreateTable(String tabla, String tipoDato)
    {

        pTabla = tabla;
        String[] splitParameters = tipoDato.Split(',');
        foreach(String toSplit in splitParameters)
        {
            string trimmedToSplit = toSplit.Trim(' ');
            try
            {
                pTipoDato.Add(trimmedToSplit.Split(' ')[1]);
                columnNames.Add(trimmedToSplit.Split(' ')[0]);
            }catch(IndexOutOfRangeException)
            {
                pTabla = null;
            }
        }

    }
    public override String Run(Database bd)
    {
        if(pTabla == null)
        {
            return Messages.WrongSyntax;
        }
        //TODO: Create columns one by one in a list and call bd.CreateDatabase
        if(bd.GetTableByName(pTabla) != null)
        {
            return Messages.TableErrorAlreadyExists;
        }
        if(pTipoDato.Count != columnNames.Count)
        {
            return Messages.WrongSyntax + ", Ammount of column names provided and column types does not match.";
        }
        int cont = 0;
        List<Column> listOfCreation = new List<Column>();
        foreach(String tipo in pTipoDato)
        {
            Column column;
            if(String.IsNullOrWhiteSpace(columnNames[cont]) && String.IsNullOrEmpty(columnNames[cont]))
            {
                return Messages.WrongSyntax + "; Empty, null or whitespace Strings are not accepted as column names.";
            }
            if(String.Equals(tipo,"TEXT",StringComparison.OrdinalIgnoreCase))
            {
                column = new ColumnString(columnNames[cont]);
            }else if(String.Equals(tipo, "INT", StringComparison.OrdinalIgnoreCase))
            {
                column = new ColumnInt(columnNames[cont]);
            }else if(String.Equals(tipo, "DOUBLE", StringComparison.OrdinalIgnoreCase))
            {
                column = new ColumnFloat(columnNames[cont]);
            }
            else
            {
                return Messages.WrongSyntax + ", given type is not recognized by our system, please introduce the type in the form of 'Text', 'Int' or 'Double' (System will ignore letter case)";
            }
            Console.WriteLine("Column created, type: " + tipo + ", column name: " + columnNames[cont]);
            listOfCreation.Add(column);
            cont++;
        }
        Console.WriteLine("CREATE TABLE Query was successful, on standby for Database CreateTable method to validate");
        return bd.CreateTable(pTabla, listOfCreation);
    }
    public string getTabla()
    {
        return pTabla;
    }

}