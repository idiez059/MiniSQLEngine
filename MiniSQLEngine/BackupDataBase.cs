using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class BackupDataBase : Query
{
    String pBase;

    public BackupDataBase(String database)
    {
        pBase = database;
    }
    public override void Run(BDData bd)
    {
        Table nombre = new Table();
        String nombreTabla = nombre.getTitle();
        throw new NotImplementedException();
    }

    public string getBase()
    {
        return pBase;
    }

}
