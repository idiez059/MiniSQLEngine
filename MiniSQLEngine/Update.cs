using System;
using System.Text.RegularExpressions;

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
    public override void Run()
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