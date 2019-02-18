using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;

namespace MiniSQLEngine
{
    public class Generic<T>
    {
        public Generic()
        {
            Console.WriteLine("T={0}", typeof(T));
        }
    }
    public class Column
    {
        public string title;
        public List<object> col;

        public List<object> getList()
        {
            return col;
        }
    }

    public class ColumnInt : Column
    {

    }

    public class ColumnString : Column
    {

    }

    public class ColumnFloat : Column
    {

    }

    public class BDData
    {

        private List<Column> bd = new List<Column>();

        private BDData()
        {

        }
        private static BDData instance = new BDData();

        public static BDData getInstance()
        {
            return instance;
        }
        public void resetBD(List<Column> pBD)
        {
            bd = pBD;
        }

        //XabiLovesOverlord
        public void addColumnInt(String pTitle)
        {
            bd.Add(new ColumnInt { title = pTitle, col = new List<object> { new List<String>() } });
        }
        public void addColumnString(String pTitle)
        {
            bd.Add(new ColumnString { title = pTitle, col = new List<object> { new List<String>() } });
        }
        public void addColumnFloat(String pTitle)
        {
            bd.Add(new ColumnFloat { title = pTitle, col = new List<object> { new List<String>() } });
        }
    }
    
}
 