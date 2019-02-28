using System;
using System.Collections.Generic;
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
                Console.WriteLine("MiniSQLJinix V0.0.0.0.0.1");

                BDData db = BDData.getInstance();
                //string var = db.Query("SELECT * FROM .......");
               // Console.WriteLine(var);
            
        }
    }
}
