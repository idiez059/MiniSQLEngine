using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MiniSQLEngine
{
    public class BDData
    {
       static void Main (String[] args)
        {
           
        }


        public static void pruebaLectura()
        {
           
            String[] lines = File.ReadAllLines("ejemploColumnas.txt");
            List<List<dynamic>> outerList = new List<List<dynamic>>();
            List<String> innerList1 = new List<string>();
            List<int> innerList2 = new List<int>();
            outerList.Add(innerList1);
            foreach(String data in lines)
            {
                String[] split = data.Split(',');
                .Add(split[0], Convert.ToInt32(split[1]));
            }
        }

        //public static void pruebaLectura()
        //{
        //    String[] lines = File.ReadAllLines("ejemploDatos.txt");
        //    Dictionary<String, Int32> nameAges = new Dictionary<String, Int32>();
        //    foreach (String nameAge in lines)
        //    {
        //        String[] split = nameAge.Split(',');
        //        nameAges.Add(split[0], Convert.ToInt32(split[1]));

        //    }
        //}
       

    }
}
