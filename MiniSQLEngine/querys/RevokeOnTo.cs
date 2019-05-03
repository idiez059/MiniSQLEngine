using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSQLEngine;

class RevokeOnTo : Query
{

    string pPrivilege;
    string pTable;
    string pProfileName;

    public RevokeOnTo(string privilege, string table, string userProfileName)
    {
        pPrivilege = privilege;
        pTable = table;
        pProfileName = userProfileName;
    }
    public override string Run(Database bd)
    {
        Profile prof = bd.GetProfileByName(pProfileName);
        bd.RevokeOnTo(pPrivilege, pTable, prof);
        return "Revoke ok";
    }
    
}

