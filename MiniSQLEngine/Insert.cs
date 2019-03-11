using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class Insert : Query
{
    
    String pTabla;
    String pContenido;
    public Insert (String tabla, String contenido)
    {
       
        pTabla = tabla;
        pContenido = contenido;
    }
    public override String Run(BDData db)
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
