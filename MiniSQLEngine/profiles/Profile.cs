using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    class Profile
    {
        private string profileName { get; set;}
        private bool eraseable { get; set; }
        List<string> deleteIn = new List<string>();
        List<string> updateIn = new List<string>();
        List<string> insertIn = new List<string>();
        List<string> selectIn = new List<string>();

        public Profile(string pName, bool pErase)
        {
            profileName = pName;
            eraseable = pErase;
        }
        public void addTableToList(string tableName, string wichQuery)
        {
            switch (wichQuery)
            {
                case "DELETE":
                    deleteIn.Add(tableName);
                case "INSERT":
                    insertIn.Add(tableName);

                
            }


        }


    }
}
