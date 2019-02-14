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

        public struct Column
        {
            public string title;
            public List<object> col;

            public List<object> getList()
            {
                return col;
            }
        }

        public static void pruebaLectura()
        {
           
            String[] lines = File.ReadAllLines("ejemploColumnas.txt");
            var outerList = new List<Column>();
            outerList.Add(new Column { title = "namesList", col = new List<object> {new List<String>()}});
            outerList.Add(new Column { title = "agesList", col = new List<object> { new List<int>() } });
            foreach (String data in lines)
            {
                String[] split = data.Split(',');
                outerList[0].getList().Add(split[0]);
                outerList[1].getList().Add(Convert.ToInt32(split[1]));
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
