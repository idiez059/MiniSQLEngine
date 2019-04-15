using System;
using System.Collections.Generic;
using System.IO;

namespace MiniSQLEngine
{


    public class FileSystemAbstract
    {
        public static Database LoadOrCreateDB(string name)
        {
            string pathfile = @"..\..\..\Storage\" + name;
            //If given database does NOT exist (notice exclamation mark at the beginning)
            if (!Directory.Exists(pathfile)) //If it doesnt work this way put double transversal bar
            {
                //Create a new database
                Console.WriteLine("Database was not found, creating new database named: " + name);
                Directory.CreateDirectory(pathfile);
                return new Database(name);
            }
            //If it DOES exist
            else
            {
                //Load existing data
                Database loadedDB = new Database(name);
                Console.WriteLine("Database: " + name + "was found, will proceed to open now...");
                foreach (string file in Directory.EnumerateFiles(pathfile, "*.txt"))
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    Console.WriteLine("Building table: " + fileName);
                    string line;
                    using (StreamReader sr = new StreamReader(file))
                    {
                        List<String> columnNames = new List<String>();
                        int cont = -1;
                        while ((line = sr.ReadLine()) != null)
                        {
                            line = line.Trim();
                            string[] parts = line.Split(' ');
                            if (cont == -1)
                            {
                                Console.WriteLine("First line loaded, columns: " + line);
                                List<Column> columns = new List<Column>();
                                foreach(string columnName in parts)
                                {
                                    //ATM, we'll just create columnStrings for correcting affairs, however, this is subject to change as we'll need to define the type of column to be created later on
                                    columns.Add(new ColumnString(columnName));
                                    columnNames.Add(columnName);
                                }
                                loadedDB.CreateTable(fileName, columns);
                            }
                            else
                            {
                                Console.WriteLine("Line loaded: " + line);
                                loadedDB.Insert(fileName,columnNames,parts);
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
                string path = @"..\..\..\Storage\" + dbName + "\\" + tableName + ".txt";
                string[] lines = { };
                Directory.CreateDirectory(@"..\..\..\Storage\" + dbName);


                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path,false))
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
        /*public void saveUSerInfo(List<User> users)
        {
            string path = @"..\..\..\Storage\" + dbName + "-" + tableName + ".txt";
            string[] lines = { };

        }*/
    }
}
 
