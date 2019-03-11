using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class Update : Query
{
   
    String pColumns;
    String pTabla;
    String pContenido;
    public Update(String columns, String tabla, String contenido)
    {
        pColumns = columns;
        pTabla = tabla;
        pContenido = contenido;
    }
    public override String Run(BDData db)
    {
        throw new NotImplementedException();
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