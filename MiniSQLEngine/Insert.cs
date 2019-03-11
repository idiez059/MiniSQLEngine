using MiniSQLEngine;
using System;
using System.Text.RegularExpressions;

public class Insert : Query
{
    
    String pTabla;
    String pContenido;
    public Insert (String tabla, String contenido)
    {
       
        pTabla = tabla;
        pContenido = contenido;
    }
    public override void Run(BDData db)
    {
        Table leTable = new Table();
        String titleTable = leTable.getTitle();
        
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
