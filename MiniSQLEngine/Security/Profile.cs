using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    class Profile
    {
        public string profileName { get; set; }
        List<string> deleteIn = new List<string>();
        List<string> updateIn = new List<string>();
        List<string> insertIn = new List<string>();
        List<string> selectIn = new List<string>();

        public Profile(string pName)
        {
            profileName = pName;
            
        }
        public void addTableToList(string tableName, string wichQuery)
        {
            switch (wichQuery)
            {
                case "DELETE":
                    deleteIn.Add(tableName);
                    break;
                case "INSERT":
                    insertIn.Add(tableName);
                    break;
                case "UPDATE":
                    updateIn.Add(tableName);
                    break;
                case "SELECT":
                    selectIn.Add(tableName);
                    break;
            }
        }
        public void removeTableFromList(string tableName, string wichQuery)
        {
            switch (wichQuery)
            {
                case "DELETE":
                    deleteIn.Remove(tableName);
                    break;
                case "INSERT":
                    insertIn.Remove(tableName);
                    break;
                case "UPDATE":
                    updateIn.Remove(tableName);
                    break;
                case "SELECT":
                    selectIn.Remove(tableName);
                    break;
            }
        }

        public List<string> getDeleteList(){return deleteIn;}
        public List<string> getInsertList(){return insertIn;}
        public List<string> getUpdateList(){return updateIn;}
        public List<string> getSelectList(){return selectIn;}
    }
}
