using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSQLEngine;

public class GrantOnTo : Query
{
    string pPrivilege;
    string pTable;
    string pProfileName;

    public GrantOnTo(string privilege, string table, string userProfileName)
    {
        pPrivilege = privilege;
        pTable = table;
        pProfileName= userProfileName;
    }
    public override string Run(Database bd)
    {
        Profile prof = bd.GetProfileByName(pProfileName);
        bd.GrantOnTo(pPrivilege, pTable, prof);
        return "Grant ok";
    }
}

