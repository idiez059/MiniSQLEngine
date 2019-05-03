using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSQLEngine;

class DropSecProfile : Query
{
    string pNameProfile;

    public DropSecProfile(string nameProfile)
    {
        pNameProfile = nameProfile;
    }
    public override string Run(Database bd)
    {
        bd.DropSecProfile(pNameProfile);
        return "DROP SECURITY PROFILE Query was successful, on standby for Database DropSecProfile method to validate";
    }
    

    
}

