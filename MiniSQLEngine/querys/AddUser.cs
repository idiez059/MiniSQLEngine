using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSQLEngine;

class AddUser : Query
{
    
    string pUserName;
    string pUserPassword;
    string pUserProfileName;
    
    public AddUser(string userName, string userPassword, string userProfileName)
    {
        pUserName = userName;
        pUserPassword = userPassword;
        pUserProfileName = userProfileName;
    }
    public override string Run(Database bd)
    {
        bd.AddUser(pUserName, pUserPassword, pUserProfileName);
        return "ADD USER Query was successful, on standby for Database AddUser method to validate";
    }
}
