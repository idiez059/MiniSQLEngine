using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class Select : Query
{
    String pColumns;
    String pTabla;
    String pContenido;
    public Select(String columns, String tabla, String contenido)
	{
        pColumns = columns;
        pTabla = tabla;
        pContenido = contenido;
	}
    public override String Run(BDData db)
    {
        Table bTable = null;
        Column bColumn = null;
        String bContent;
        //try
        //{
            foreach(Table table in db.getTables())
            {
                if (table.getTitle().Equals(pTabla))
                {
                   bTable = table;
                }
            }
            if(bTable != null)
            {
            foreach (Column column in bTable.getColumns())
            {
                if (column.getTitle().Equals(pColumns))
                {
                    bColumn = column;
                }
            }
            if(bColumn != null)
            {
                bColumn.getTitle();
            }
        }
            
        //}catch(NullReferenceException)
        //{

        //}
        return null;
    }

    public string getColumns()
    {
        return pColumns;
    }

    public string getTabla()
    {
        return pTabla;
    }

    public string getContenido()
    {
        return pContenido;
    }
}
