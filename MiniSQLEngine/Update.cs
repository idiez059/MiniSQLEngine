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

    public Update(String tableName, String updates, String left, String op, String rigth)
    {
        pTableName = tableName;
        pLeft = left;
        pOp = op;
        pRight = rigth;

        String[] updatesSeparated = updates.Split(',');
        foreach (string update in updatesSeparated)
        {
            //Name='Bernardo'
            string[] parts = update.Split('=');
            ColumnNames.Add(parts[0]);
            Values.Add(parts[1]);
        }
        
    }
    public override String Run(Database db)
    {
        /*
         * MIRAR SI EXISTE LA TABLA COMPRANDO LA TABLA DADA EN LA LISTA DE TABLAS
         * MIRAR SI EXISTE LA COLUMNA COMPARANDO LAS COLUMNAS DADAS CON LAS QUE HAY SEPARADAS POR COMAS EN LA LISTA DE COLUMNAS
         * SI ALGUNA NO EXISTE RESPONDER MENSAJE 
         * SI TODO EXISTE Y ESTA BIEN MODIFICARLO 
         */

        //get table

        Table table = db.GetTableByName(pTableName);
        if (table == null) return Messages.TableDoesNotExist;

        if (ColumnNames.Count != Values.Count)
            return Messages.WrongSyntax;

        //we need the column list to know the correct column
        foreach (Column column in table.Columns)
        {
            if (ColumnNames.Contains(column.Name))
            {
                int columnIndex = ColumnNames.IndexOf(column.Name);
                for (int i= 0; i<column.GetNumValues(); i++)
                {
                    column.SetValueAsString(i, Values[columnIndex]);
                }
            }

        }
        return Messages.TupleUpdateSuccess;
    
    }

}