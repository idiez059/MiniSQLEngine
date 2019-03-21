using MiniSQLEngine;
using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class Insert : Query
{
    
    String pTabla;
    String pColumnas;
    String pValores;

    public Insert (String tabla, String columnas, String valores)
    {
       
        pTabla = tabla;
        pColumnas = columnas;
        pValores = valores;
    }
    public override String Run(Database db)
    {
        String[] toReturn = new String[3];
        Table leTable = new Table();

        String tit
        leTable.setTabla
        toReturn = {getTabla, contenido }
        
        throw new NotImplementedException();
    }
    public string getTabla()
    {
        return pTabla;
    }
}
