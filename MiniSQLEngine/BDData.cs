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
        public String title;
        private bool fKey;
        private bool pKey;
        private int? forKey;

        public Column(String pTitle)
        {
            title = pTitle;
            pKey = false;
            fKey = false;
            forKey = null;
            
        }

        public void setPKey(bool foo)
        {
            pKey = foo;
        }
        public bool getPKey()
        {
            return pKey;
        }
        public void setFKey(bool foo)
        {
            fKey = foo;
        }
        public bool getFKey()
        {
            return pKey;
        }
        public void setForKey(int pForKey)
        {
            forKey = pForKey;
        }
        public int? getForKey()
        {
            return forKey;
        }
        
      
    }

    public class ColumnInt : Column
    {
        List<int> col;
        public ColumnInt(String title):base(title)
        {
            col = null;
        }
        public ColumnInt(String title,List<int> pCol):base(title)
        {
            col = pCol;
        }
        public List<int> getList()
        {
            return col;
        }
        public void setList(List<int> pLista)
        {
            col = pLista;
        }


    }

    public class ColumnString : Column
    {
        List<String> col;
        public ColumnString(String title) : base(title)
        {
            col = null;
        }
        public ColumnString(String title, List<String> pCol) : base(title)
        {
            col = pCol;
        }
        public List<String> getList()
        {
           return col;
        }
        public void setList(List<String> pLista)
        {
            col = pLista;
        }
    }

    public class ColumnFloat : Column
    {
        List<float> col;
        public ColumnFloat(String title) : base(title)
        {
            col = null;
        }
        public ColumnFloat(String title, List<float> pCol) : base(title)
        {
            col = pCol;
        }
        public List<float> getList()
        {
            return col;
        }
        public void setList(List<float> pLista)
        {
            col = pLista;
        }
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

        public void addColumnInt(String title)
        {
            bd.Add(new ColumnInt(title));
        }
        public void addColumnInt(String title, List<int> lista)
        {
            bd.Add(new ColumnInt(title,lista));
        }
        public void addColumnString(String title)
        {
            bd.Add(new ColumnString(title));
        }
        public void addColumnString(String title, List<String> lista)
        {
            bd.Add(new ColumnString(title,lista));
        }
        public void addColumnFloat(String title)
        {
            bd.Add(new ColumnFloat(title));
        }
        public void addColumnFloat(String title, List<float> lista)
        {
            bd.Add(new ColumnFloat(title,lista));
        }
    }
    
}
 