using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSQLEngine;

class DeleteUser : Query
{
    string pUserName;
    public DeleteUser(string username)
    {
        pUserName = username;
    }
    public override string Run(Database bd)
    {
        bd.DeleteUser(pUserName);
        return "DELETE USER " + pUserName + " deleted succesfully";
    }
}
