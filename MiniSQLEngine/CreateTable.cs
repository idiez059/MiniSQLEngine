﻿using System;
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
    public override String Run(BDData bd)
    {






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