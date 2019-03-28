using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class CreateTable : Query
{
    
    String pTabla;
    String[] columnNames;
    String[] pTipoDato;
    String[] pPK;
    String pFK;
  
    public CreateTable(String tabla,String columnList, String tipoDato, String pk,String fk)
    {

        pTabla = tabla;
        columnNames = columnList.Split(',');
        pTipoDato = tipoDato.Split(',');
        pPK = pk.Split(',');
        pFK = fk;

    }
    public override String Run(Database bd)
    {

        //TODO: Create columns one by one in a list and call bd.CreateDatabase
        if(bd.GetTableByName(pTabla) != null)
        {
            return Messages.TableErrorAlreadyExists;
        }
        List<Column> columns = new List<Column>();

        


        return null;
    }
    public string getFK()
    {
        return pFK;
    }
    public string[] getPK()
    {
        return pPK;
    }
    public string getTabla()
    {
        return pTabla;
    }

}