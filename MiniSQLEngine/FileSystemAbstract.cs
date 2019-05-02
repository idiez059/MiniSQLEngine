using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;

namespace MiniSQLEngine
{
    
    
    class FileSystemAbstract
    {
        public static void Init(string name)
        {
            
            if (!Directory.Exists("/../../../" + name + ".txt")) //If it doesnt work this way put double transversal bar
            {
                //Create a new database
                new Database(name,"trt","gy");
           
            }
            else
            {
                //Load existing data 
                string pathfile = @"/../../../" + name + ".txt";

                foreach (string file in Directory.EnumerateFiles(pathfile, "*.txt"))
                {
                    string line;
                    using (StreamReader sr = new StreamReader(file))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');                            
                        }
                    }
                }                               
            }
        }

        public static void saveUserInfo(string name, string password, Profile profileType)
        {
            string path = @"..\..\..\Storage\Users\" + name + ".txt";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                file.Write(name + " " + password + " " + profileType.profileName);
            }
        }

        public static void saveProfileInfo(string name)
        {
            string path = @"..\..\..\Storage\Profiles\" + name + ".txt";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                file.Write(name);
            }
        }

        public static void saveData(string dbName, List<Table> tables)
        {
            foreach (Table table in tables)
            {
                List<Column> columns = table.Columns;
                string tableName = table.Name;
                string path = @"..\....\Storage\" + dbName + "-" + tableName + ".txt";
                string[] lines = { };


                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
                {
                    for (int i = 0; i < columns.Count; i++)
                    {
                        file.Write(columns[i].Name + " ");
                    }

                    int numTuples = columns[0].GetNumValues();
                    if (numTuples > 0)
                    {
                        for (int tuple = 0; tuple < numTuples; tuple++)
                        {
                            file.WriteLine("");
                            for (int j = 0; j < columns.Count; j++)
                            {
                                file.Write(columns[j].GetValueAsString(tuple) + " ");
                            }
                        }
                    }
                }
            }
        }
    }
}