using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    //Clase tabla.
    public class Table
    {
        public String Name { get; }
        public List<Column> Columns { get; } = new List<Column>();

        public Table(string name, List<Column> columns)
        {
            Columns = columns;
            Name = name;
        }

        /// <summary>
        /// Returns a column given its name
        /// </summary>
        /// <param name="columnName">The name of the column</param>
        /// <returns>The Table object. Null if not found</returns>
        public Column ColumnByName(String columnName)
        {
            foreach (Column column in Columns)
            {
                if (column.Name == columnName)
                    return column;
            }
            return null;
        }

        public override string ToString()
        {
            //We have all the selected columns now in selectedColumns, just return them as a string with the format:
            //{columnName1,columnName2...}{tuple1.column1,tuple1.column2...}{ tuple2.column1,tuple2.column2...}
            string result = "";
            //First, we add the column names
            result = "{" + Columns[0].Name;
            for (int i = 1; i < Columns.Count; i++) result += "," + Columns[i].Name;
            result += "}";
            //Then the column values for each tuple
            int numTuples = Columns[0].GetNumValues();
            if (numTuples > 0)
            {
                for (int tuple = 0; tuple < numTuples; tuple++)
                {
                    result += "{" + Columns[0].GetValueAsString(tuple);
                    for (int i = 1; i < Columns.Count; i++) result += "," + Columns[i].GetValueAsString(tuple);
                    result += "}";
                }
            }
            return result;
        }
        public void Update(String columns, String tableName, String left, String op, String right)
        {
            Column lacolumna = ColumnByName(columns);
            int numvalues = lacolumna.GetNumValues();

            for (int j = 0; j < numvalues; j++)
            {
                lacolumna.GetValueAsString(j);

            }

            return;
        }

        private bool CompareOp(string columns, string elem1, string elem2, string operat)
        {
            switch (operat)
            {
                case "=":
                    return elem1 == elem2;
                case "<":
                    int j = string.Compare(elem1, elem2);
                    if (j == -1) { return true; }
                    else { return false; }
                case ">":
                    int k = string.Compare(elem1, elem2);
                    if (k == 1) { return true; }
                    else { return false; }
                default:
                    Console.WriteLine("Error comparing tuples, in Compare() method");
                    return false;
            }
        }

        public void DeleteRows(string left, string op, string right)
        {
            for (int i = 0; i < Columns.Count; i++)
            {
                int numTuples = Columns[0].GetNumValues();                
                if (numTuples > 0)
                {
                    if (Columns[i].Name == left) {
                        for (int tuple = 0; tuple < numTuples; tuple++)
                        {
                          bool delete = CompareOp(Columns[i].Name, Columns[i].GetValueAsString(tuple), right,  op);

                            if(delete == true)
                            {
                                for (int j = 0; j < Columns.Count; j++)
                                {
                                    Columns[j].RemoveValueAtIndex(tuple);                                    
                                }
                                tuple--;
                                i--;
                            }
                        }
                    }
                }
            }
        }
    }
}
