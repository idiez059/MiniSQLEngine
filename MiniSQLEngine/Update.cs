using System;
using System.Text.RegularExpressions;

public class Update : Query
{
    /*
    public Update(String query)
    {
        string update = @"UPDATE\s+(\w+)\s+SET\s+(\w+)\s+=\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+))?(\;)";
        String[] partes = Regex.Split(query, update);
    }
    */

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