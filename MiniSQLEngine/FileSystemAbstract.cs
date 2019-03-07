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
        public static String openDataFile(String dbName, String tableName)
        {

            String resultingPath = null;
            if (File.Exists("/../../../" + dbName + tableName + ".txt"))
            {
                resultingPath = "/../../../" + dbName + tableName + ".txt";
                return resultingPath;
            }
            else
            {
                Console.WriteLine("Error: could not find specified file");
                resultingPath = "";
                return resultingPath;
            }
        }
        public static String openStructureFile(String dbName, String tableName)
        {
            String resultingPath = null;
            if (File.Exists("/../../../" + dbName + tableName + ".txt"))
            {
                resultingPath = "/../../../" + dbName + tableName + ".txt";
                return resultingPath;
            }
            else
            {
                Console.WriteLine("Error: could not find specified file");
                return resultingPath;
            }
        }
        public void writeToDataFile()
        {

        }
        public void writeToStructureFile(string dbName, string tableName,List<string> colType)
        {
            List<string> col = colType;
            List<string> towrite = new List<string>();
            int i = 0;
            String lePath;
            foreach (var column in col)
            {
                i++;
                towrite.Add(i.ToString() + column.ToString());
            }
            lePath = openStructureFile(dbName, tableName);
            System.IO.File.WriteAllLines(lePath, towrite);
        }

        public ArrayList readDataFile(String dbName, String tableName)
        {
            StreamReader objReader = new StreamReader(openDataFile(dbName, tableName));
            string sLine = "";
            ArrayList arrText = new ArrayList();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    arrText.Add(sLine);
            }
            objReader.Close();

            foreach (string sOutput in arrText) Console.WriteLine(sOutput);
            Console.ReadLine();

            return arrText;
        }
        public ArrayList readDatastructure(String dbName, String tableName)
        {
            StreamReader objReader = new StreamReader(openStructureFile(dbName, tableName));
            string sLine = "";
            ArrayList arrText = new ArrayList();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    arrText.Add(sLine);
            }
            objReader.Close();

            foreach (string sOutput in arrText) Console.WriteLine(sOutput);
            Console.ReadLine();

            return arrText;
        }
    }
}
