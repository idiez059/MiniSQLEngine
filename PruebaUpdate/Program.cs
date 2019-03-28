using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSQLEngine;

namespace PruebaUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database("test-db");
            db.RunQuery ( "Update People set Name = Bernado where Name = Maria");
        }
    }
}
