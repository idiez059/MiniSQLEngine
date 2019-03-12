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

    //Clases que hereda de otra columna
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
        public List<String> getAsString()
        {
            List<String> stringList = new List<String>();
            foreach(int alexNoTieneAngulo in col)
            {
                stringList.Add(alexNoTieneAngulo.ToString());
            }
            return stringList;
        }
        public void setList(List<int> pLista)
        {
            col = pLista;
        }
        public String getAll()
        {
            String D4NK = String.Empty;
            foreach(int foo in col)
            {
                D4NK = D4NK + foo.ToString() + "\r\n";
            }
            return D4NK;
        }
        public int getElementByIndex(int foo)
        {
            return col[foo];
        }
        public List<int> getElementsByIndex(List<int> foo)
        {
            List<int> elements = new List<int>();
            foreach (int peekaboo in foo)
            {
                elements.Add(col[peekaboo]);
            }
            return elements;
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
                if (element.Equals(content))
                {
                    elements.Add(col.IndexOf(content));
                }
            }
            return elements;
        }
        public System.Type getType()
        {
            return col.GetType();
        }
    }
    //Clases que hereda de otra columna
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
        public String getAll()
        {
            String D4NK = String.Empty;
            foreach (String foo in col)
            {
                D4NK = D4NK + foo + "\r\n";
            }
            return D4NK;
        }
        public String[] getArrayOfElements()
        {
            String[] elements = col.ToArray();
            return elements;
        }
        public String getElementByIndex(int foo)
        {
            return col[foo];
        }
        public List<String> getElementsByIndex(List<int> foo)
        {
            List<String> elements = new List<String>();
            foreach (int peekaboo in foo)
            {
                elements.Add(col[peekaboo]);
            }
            return elements;
        }
        public void setElementByIndex(int foo, String element)
        {
            col[foo] = element;
        }
        public bool hasElement(String element)
        {
            return col.Contains(element);
        }
        public List<int> elementsByContent(String content)
        {
            List<int> elements = null;
            foreach (String element in col)
            {
                if (element.Equals(content))
                {
                    elements.Add(col.IndexOf(content));
                }
            }
            return elements;
        }
        public System.Type getType()
        {
            return col.GetType();
        }
    }
    //Clases que hereda de otra columna
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
        public List<String> getAsString()
        {
            List<String> stringList = new List<String>();
            foreach (int alexNoTieneAngulo in col)
            {
                stringList.Add(alexNoTieneAngulo.ToString());
            }
            return stringList;
        }
        public String getAll()
        {
            String D4NK = String.Empty;
            foreach (float foo in col)
            {
                D4NK = D4NK + foo.ToString() + "\r\n";
            }
            return D4NK;
        }
        public float getElementByIndex(int foo)
        {
            return col[foo];
        }
        public List<float> getElementsByIndex(List<int> foo)
        {
            List<float> elements = new List<float>();
            foreach(int peekaboo in foo)
            {
                elements.Add(col[peekaboo]);
            }
            return elements;
        }
        public void setElementByIndex(int foo, float element)
        {
            col[foo] = element;
        }
        public bool hasElement(float element)
        {
            return col.Contains(element);
        }
        public List<int> elementsByContent(float content)
        {
            List<int> elements = null;
            foreach (float element in col)
            {
                if (element == content)
                {
                    elements.Add(col.IndexOf(content));
                }
            }
            return elements;
        }
        public System.Type getType()
        {
            return col.GetType();
        }
    }
    //Clase tabla 
    public class Table
    {
        private String title;
        private List<Column> table = new List<Column>();

        //XabiLovesOverlord
        //Devuelve el nombre de la tabla 
        public String getTitle()
        {
            return title;
        }
        public void setTitle(String pTitle)
        {
            title = pTitle;
        }
        public List<Column> getColumns()
        {
            return table;
        }
        public void setTabla(List<Column> pTable)
        {
            table = pTable;
        }
        public void addColumnInt(String title)
        {
            table.Add(new ColumnInt(title));
        }
        public void addColumnInt(String title, List<int> lista)
        {
            table.Add(new ColumnInt(title, lista));
        }
        public void addColumnString(String title)
        {
            table.Add(new ColumnString(title));
        }
        public void addColumnString(String title, List<String> lista)
        {
            table.Add(new ColumnString(title, lista));
        }
        public void addColumnFloat(String title)
        {
            table.Add(new ColumnFloat(title));
        }
        public void addColumnFloat(String title, List<float> lista)
        {
            table.Add(new ColumnFloat(title, lista));
        }
        //Encontrar una columna sabiendo su nombre
        public Column findColumnByName(String element)
        {
            Column col = null;
            foreach (Column column in table)
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

    }
    public class BDData
    {
        private String name;
        private List<Table> bd = new List<Table>();

        private BDData()
        {

        }
        private static BDData instance = new BDData();

        public static BDData getInstance()
        {
            return instance;
        }
        public void resetBD(List<Table> pBD)
        {
            bd = pBD;
        }
        //Lista las referencias a las tablas
        public List<Table> getTables()
        {
            return bd;
        }
        public void setName(String pName)
        {
            name = pName;
        }
        //nombre de la base de datos
        public String getName()
        {
            return name;
        }
        //pasandole el nombre te da la tabla
        public Table getTableByName(String pName)
        {
            Table result = null;
            foreach (Table table in bd)
            {
                if (table.getTitle().Equals(pName))
                {
                    result = table;
                }
            }
            return result;
        }

        public string RunQuery(string line)
        {
            throw new NotImplementedException();
        }
    }

}