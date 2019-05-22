using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSQLEngine;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database("Database1","admin","admin");
            string pathfile = @"..\..\..\Storage\";
            foreach (string file in Directory.EnumerateFiles(pathfile, "*.txt"))
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                if (fileName.Equals("TesterInput"))
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string query = db.RunQuery(line);
                            if(query == null)
                            {
                                string[] parts;
                                parts = line.Split(',');
                                if(parts.Length > 3)
                                {
                                    FileSystemAbstract.LoadOrCreateDB(parts[0],parts[1],parts[2]);
                                    //Ignore given that parts is less on size than 3, as that means it's an empty line / line break
                                }
                                Console.WriteLine(line + ": " + query);
                            }                            
                        }
                    }
                }
            }


                //string query = "SELECT * FROM People WHERE Age < 30;";
                //Console.WriteLine(query + ": " + db.RunQuery(query));

                string queryDelete = "DROP TABLE People;";
            Console.WriteLine(queryDelete + ": " + db.RunQuery(queryDelete));

            //string query = "SELECT Name FROM People;";
            //Console.WriteLine(query + ": " + db.RunQuery(query));

            //Console.WriteLine("MiniSQLJinix V0.0.0.0.0.1");

            //BDData db = BDData.getInstance();

            //int counter = 0;
            //string line;

            //// Read the file and display it line by line.  
            //System.IO.StreamReader file =
            //    new System.IO.StreamReader(@"..\..\..\Prueba.txt");
            //while ((line = file.ReadLine()) != null)
            //{
            //    System.Console.WriteLine(line);
            //    counter++;
            //    string result = db.RunQuery(line);
            //    Console.WriteLine(result);
            //}

            //file.Close();
            //System.Console.WriteLine("There were {0} lines.", counter);
            //// Suspend the screen.  
            //System.Console.ReadLine();           
        }
    }
}
