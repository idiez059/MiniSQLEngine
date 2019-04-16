using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSQLEngine.Security
{
    class User
    {
        private string userName{get; set;}
        private string userPass{get; set;}
        private Profile profile { get; set; } //not shure: type, string or Profile
        public User(string pUserName, string pUserPass, string pProfile)
        {
            userName = pUserName;
            userPass = pUserPass;
            //profile = pProfile;
        }
        public Profile getUserProfile() {return profile;}
        public string getUserProfileString() { return profile.ToString(); }
        public string getUserPass() { return userPass; }
        public string getUserName() { return userName; }




    }
}
