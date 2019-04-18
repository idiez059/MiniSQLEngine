using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSQLEngine;


class CreateSecProfile : Query
{
    string pNameProfile;
    


    public CreateSecProfile(string nameProfile)
        {
            pNameProfile = nameProfile;
        }

    public override string Run(Database bd)
    {
        bd.CreateSecProfile(pNameProfile);
        return "CREATE SECURITY PROFILE Query was successful, on standby for Database CreateSecProfile method to validate";
    }

}

