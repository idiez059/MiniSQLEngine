using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;
using MiniSQLEngine;


namespace MiniSQLEngine

{
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
        public String getTitle()
        {
            return title;
        }
        public void setTitle(String newTitle)
        {
            title = newTitle;
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
        public ColumnInt(String title) : base(title)
        {
            col = null;
        }
        public ColumnInt(String title, List<int> pCol) : base(title)
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
        public int getElementByIndex(int foo)
        {
            return col[foo];
        }
        public void setElementByIndex(int foo, int element)
        {
            col[foo] = element;
        }
        public bool hasElement(int element)
        {
            return col.Contains(element);
        }
        public List<int> elementsByContent(int content)
        {
            List<int> elements = null;
            foreach (int element in col)
            {
                if (element == content)
                {
                    elements.Add(element);
                }
            }
            return elements;
        }
    }

    public class ColumnString : Column
    {
        private List<String> col;
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
        public String getElementByIndex(int foo)
        {
            return col[foo];
        }
        public void setElementByIndex(int foo, String element)
        {
            col[foo] = element;
        }
        public bool hasElement(String element)
        {
            return col.Contains(element);
        }
        public List<String> elementsByContent(String content)
        {
            List<String> elements = null;
            foreach (String element in col)
            {
                if (element.Equals(content))
                {
                    elements.Add(element);
                }
            }
            return elements;
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
        public float getElementByIndex(int foo)
        {
            return col[foo];
        }
        public void setElementByIndex(int foo, float element)
        {
            col[foo] = element;
        }
        public bool hasElement(float element)
        {
            return col.Contains(element);
        }
        public List<float> elementsByContent(float content)
        {
            List<float> elements = null;
            foreach (float element in col)
            {
                if (element == content)
                {
                    elements.Add(element);
                }
            }
            return elements;
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
            bd.Add(new ColumnInt(title, lista));
        }
        public void addColumnString(String title)
        {
            bd.Add(new ColumnString(title));
        }
        public void addColumnString(String title, List<String> lista)
        {
            bd.Add(new ColumnString(title, lista));
        }
        public void addColumnFloat(String title)
        {
            bd.Add(new ColumnFloat(title));
        }
        public void addColumnFloat(String title, List<float> lista)
        {
            bd.Add(new ColumnFloat(title, lista));
        }
        public Column findColumnByName(String element)
        {
            Column col = null;
            foreach (Column column in bd)
            {
                if (column.getTitle().Equals(element))
                {
                    col = column;
                }
            }
            return col;
        }
        public bool hasColumn(String element)
        {
            if (findColumnByName(element) != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /*
        public string RunQuery(string queryString)
        {
            string result;
            Parser theParser = new Parser();
            Query theQuery = theParser.parse(queryString);

            Select queryAsSelect = theQuery as Select;
            Update queryAsUpdate = theQuery as Update;
            string table = queryAsSelect.getTabla();
            string column = queryAsSelect.getColumns();
            string content = queryAsSelect.getContenido();



            if (queryAsSelect == null)
            {
                string columna2 = queryAsUpdate.getColumns();
                string tabla2 .....
                string
                if ()
                {

                }


            }

            return ans;


    

        }
*/    }

}