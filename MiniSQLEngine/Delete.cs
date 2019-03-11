using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class Delete : Query
{
    String pTabla;
    String pContenido;

    public Delete( String tabla, String contenido)
    {
        pTabla = tabla;
        pContenido = contenido;
    }
    public override String Run(BDData bd)
    {
        
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
