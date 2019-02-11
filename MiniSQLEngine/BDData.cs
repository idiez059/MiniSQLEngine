using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    class BDData
    {
       static void Main (String[] args)
        {
            String[] lines = File.ReadAllLines("ejemploDatos.txt");
            Dictionary<String, Int32> nameAges = new Dictionary<String, Int32>();
            foreach (String nameAge in lines)
            {
                String[] split = nameAge.Split(',');
                nameAges.Add(split[0], Convert.ToInt32(split[1]));
            }
        }

       

    }
}
