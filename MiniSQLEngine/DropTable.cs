using System;
using System.Text.RegularExpressions;

public class DropTable : Query
{
    
    String pColumns;
    String pTabla;
    String pContenido;
    public DropTable(String tabla)
    {
        pTabla = tabla;
    }
    public override String Run()
    {
        throw new NotImplementedException();
    }

    public string getTabla()
    {
        return pTabla;
    }
}
