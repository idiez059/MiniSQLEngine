using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;
using System.Collections.Generic;

public class Select : Query
{
    String pColumns;
    String pTabla;
    List<String> pContenido;
    public Select(String columns, String tabla, List<String> contenido)
	{
        pColumns = columns;
        pTabla = tabla;
        pContenido = contenido;
	}
    public override String Run(BDData db)
    {
        Table bTable = null;
        Column bColumn = null;
        //String bContent = pContenido;
        bTable = db.getTableByName(pTabla);
        if(bTable != null)
        {
            bColumn = bTable.findColumnByName(pColumns);
            if(bColumn != null)
            {
                    
            }
            else
            {
                return "Could not find the specified column";
            }
        }else
            {
                return "Could not find specified table";
            }
        return null;
    }

    public string getColumns()
    {
        return pColumns;
    }

    public string getTabla()
    {
        return pTabla;
    }

    public List<String> getContenido()
    {
        return pContenido;
    }
}
