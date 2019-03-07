using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace MiniSQLEngine
{
   

    class FileSystemAbstract
    {
        public static String openDataFile(String dbName, String tableName)
        {

            String resultingPath = null;
            if (File.Exists(dbName+"/" + dbName + "Data" + tableName + ".txt"))
            {
                resultingPath = dbName+"/" + dbName + "/Data" + tableName + ".txt";
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
            if (File.Exists(dbName+"/" +dbName + "Structure" + tableName + ".txt"))
            {
                resultingPath = dbName+"/" + dbName + "Structure" + tableName + ".txt";
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
        public void writeToStructureFile(List<string> colType)
        {
            List<string> col = colType;
            List<string> towrite = new List<string>();
            int i = 0;
            foreach (var column in col)
            {
                i++;
                towrite.Add(i.ToString() + column.ToString());
            }
            System.IO.File.WriteAllLines(@".....", towrite);
        }
    }
}
