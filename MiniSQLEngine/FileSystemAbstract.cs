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

        //    //Carga un fichero de datos
        //    public static String openDataFile(String dbName, String tableName)
        //    {

        //        String resultingPath = null;
        //        if (File.Exists("/../../../" + dbName + tableName + ".txt"))
        //        {
        //            resultingPath = "/../../../" + dbName + tableName + ".txt";
        //            return resultingPath;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Error: could not find specified file");
        //            resultingPath = "";
        //            return resultingPath;
        //        }
        //    }
        //    //Carga un fichero de estructura
        //    public static String openStructureFile(String dbName, String tableName)
        //    {
        //        String resultingPath = null;
        //        if (File.Exists("/../../../" + dbName + tableName + ".txt"))
        //        {
        //            resultingPath = "/../../../" + dbName + tableName + ".txt";
        //            return resultingPath;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Error: could not find specified file");
        //            return resultingPath;
        //        }
        //    }

        //    public void writeToDataFile( String dbName, String tableName, String param)
        //    {
        //        String lePath;

        //        lePath = openStructureFile(dbName, tableName);
        //        System.IO.File.WriteAllText(lePath, param);

        //    }

        //    //Lee un fichero de estructura al completo
        //    public ArrayList readStructureFile(String dbName, String tableName)
        //    {
        //        StreamReader objReader = new StreamReader(openStructureFile(dbName, tableName));
        //        string sLine = "";
        //        ArrayList arrText = new ArrayList();

        //        while (sLine != null)
        //        {
        //            sLine = objReader.ReadLine();
        //            if (sLine != null)
        //                arrText.Add(sLine);
        //        }
        //        objReader.Close();

        //        foreach (string sOutput in arrText) Console.WriteLine(sOutput);
        //        Console.ReadLine();

        //        return arrText;
        //    }

        //    //Escribe en un fichero de estructura
        //    public void writeToStructureFile(string dbName, string tableName,List<string> colType)
        //    {
        //        List<string> col = colType;
        //        List<string> towrite = new List<string>();
        //        int i = 0;
        //        String lePath = openStructureFile(dbName, tableName);
        //        foreach (var column in col)
        //        {
        //            i++;
        //            towrite.Add(i.ToString() + column.ToString());
        //        }
        //        lePath = openStructureFile(dbName, tableName);
        //        System.IO.File.WriteAllLines(lePath, towrite);
        //    }
        //    //Lee un fichero de datos al completo
        //     public ArrayList readDataFile(String dbName, String tableName)
        //     {
        //         StreamReader objReader = new StreamReader(openDataFile(dbName, tableName));
        //         string sLine = "";
        //         ArrayList arrText = new ArrayList();

        //         while (sLine != null)
        //         {
        //             sLine = objReader.ReadLine();
        //             if (sLine != null)
        //                 arrText.Add(sLine);
        //         }
        //         objReader.Close();

        //         foreach (string sOutput in arrText) Console.WriteLine(sOutput);
        //         Console.ReadLine();

        //         return arrText;
        //     }
        }
    }
 
