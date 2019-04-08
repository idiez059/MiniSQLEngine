using System.Collections.Generic;
using System.IO;

namespace MiniSQLEngine
{


    class FileSystemAbstract
    {
        public static Database LoadOrCreateDB(string name)
        {
            string pathfile = @"..\..\..\Storage\" + name;
            //If given database does NOT exist (notice exclamation mark at the beginning)
            if (!Directory.Exists(pathfile)) //If it doesnt work this way put double transversal bar
            {
                //Create a new database
                Console.WriteLine("Database was not found, creating new database named: " + name);
                Directory.CreateDirectory(name);
                return new Database(name);
            }
            //If it DOES exist
            else
            {
                //Load existing data
                Database loadedDB = new Database(name);
                foreach (string file in Directory.EnumerateFiles(pathfile, "*.txt"))
                {
                    string line;
                    using (StreamReader sr = new StreamReader(file))
                    {
                        List<String> columnNames = new List<String>();
                        int cont = -1;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            if (cont == -1)
                            {
                                List<Column> columns = new List<Column>();
                                foreach(string columnName in parts)
                                {
                                    //ATM, we'll just create columnStrings for correcting affairs, however, this is subject to change as we'll need to define the type of column to be created later on
                                    columns.Add(new ColumnString(columnName));
                                    columnNames.Add(columnName);
                                }
                                loadedDB.CreateTable(file, columns);
                            }
                            else
                            {
                                loadedDB.Insert(file,columnNames,parts);
                            }
                        cont++;
                        }
                    }
                }
                return loadedDB;
            }
        }   
        
        public static void saveData(string dbName,List<Table> tables)
        {
            foreach (Table table in tables)
            {
                List<Column> columns = table.Columns;
                string tableName = table.Name;
                string path = @"..\..\..\Storage\" + dbName + tableName + ".txt";
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
 
