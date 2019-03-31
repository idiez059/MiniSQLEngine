using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;
using System.Collections.Generic;
using System.IO;

public class Update : Query
{
    
    String pTableName { get; }
    String pColumns;
    String pValues;
    String pLeft;
    String pOp;
    String pRigth;
    String[] valuesSeparated;
    List<string> ColumnNames = new List<string>();
    List<string> Values = new List<string>();
    String end;
    String error = "ERROR: ";
    Boolean mistake;

    public Update(String tableName, String columns, String values, String left, String op, String rigth)
    {
        pTableName = tableName;
        pColumns = columns; 
        pValues = values;
        pLeft = left;
        pOp = op;
        pRigth = rigth;
      
        ColumnNames.Add(pColumns);
        Values.Add(pValues);

        valuesSeparated = values.Split(',');
    }
    public override String Run(Database db)
    {
        /*
         * MIRAR SI EXISTE LA TABLA COMPRANDO LA TABLA DADA EN LA LISTA DE TABLAS
         * MIRAR SI EXISTE LA COLUMNA COMPARANDO LAS COLUMNAS DADAS CON LAS QUE HAY SEPARADAS POR COMAS EN LA LISTA DE COLUMNAS
         * SI ALGUNA NO EXISTE RESPONDER MENSAJE 
         * SI TODO EXISTE Y ESTA BIEN MODIFICARLO 
         * 
         * /

        //get table

        Table table = db.GetTableByName(pTableName);
        if (table == null) return Messages.TableDoesNotExist;

        //we need the column list to know the correct column
        if (ColumnNames.Count == 0)
        {
            if (table.Columns.Count != Values.Count)
                return Messages.WrongSyntax;
        }
       //Directorio
        if (!File.Exists("..//..//..//data//" + db.Name + "//" + Table.Name + ".data"))
        {
            end = error + "Table does not exist";
            mistake = true;
        }
        if (mistake == false)
        {
            String[] tupla = System.IO.File.ReadAllLines("..//..//..//data//" + db.Name + "//" + Table + ".def");
            foreach (String la in pColumns)
            {
                String[]  splitIt= la.Split('=');
                String find = splitIt[0];
                if (tupla[0].Contains(find) == false)
                {
                    end = error + "Column does not exist";
                    mistake = true;
                }
            }
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