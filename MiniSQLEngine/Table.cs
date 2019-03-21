using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    //Clase tabla 
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
    }
}
