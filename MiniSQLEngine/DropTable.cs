using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class DropTable : Query
{
    
    String pColumns;
    String pTabla;
    String pContenido;
    public DropTable(String tabla)
    {
        pTabla = tabla;
    }
    public override String Run(BDData bd)
    {
        Table nombre = new Table();
        String nombreTabla = nombre.getTitle();
        throw new NotImplementedException();
    }

    public string getTabla()
    {
        return pTabla;
    }
}
