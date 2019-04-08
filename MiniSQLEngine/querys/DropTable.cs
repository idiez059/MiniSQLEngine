using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;

public class DropTable : Query
{
    
    
    String pTable;
    
    public DropTable(String table)
    {
        pTable = table;
    }
    public override String Run(Database bd)
    {

        bd.GetTableByName(pTable);
        if (pTable == null) return Messages.TableDoesNotExist;
        bd.DeleteTable(pTable);
        return null;


    }

    public string getTable()
    {
        return pTable;
    }
}
