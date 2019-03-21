using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class CreateTable : Query
{
    
    String pTabla;
    String pTipoDato;
    String pPK;
    String pFK;
  
    public CreateTable(String tabla,String tipoDato, String pk,String fk)
    {
        pTabla = tabla;
        pTipoDato = tipoDato;
        pPK = pk;
        pFK = fk;

    }
    public override String Run(Database bd)
    {

        //TODO: Create columns one by one in a list and call bd.CreateDatabase
        


        return null;
    }
    public string getFK()
    {
        return pFK;
    }
    public string getPK()
    {
        return pPK;
    }
    public string getTabla()
    {
        return pTabla;
    }

}