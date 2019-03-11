using System;
using System.Text.RegularExpressions;

public class Delete : Query
{
    String pTabla;
    String pContenido;

    public Delete( String tabla, String contenido)
    {
        pTabla = tabla;
        pContenido = contenido;
    }
    public override String Run(MiniSQLEngine.BDData db)
    {
        throw new NotImplementedException();
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
