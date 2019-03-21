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
    public override String Run(Database bd)
    {

        throw new NotImplementedException();
    }

    public string getTabla()
    {
        return pTabla;
    }
}
