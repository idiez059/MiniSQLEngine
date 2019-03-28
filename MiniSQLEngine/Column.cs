using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    public abstract class Column
    {
        public String Name { get; }

        public Column(String name)
        {
            Name = name;
        }

        public abstract int GetNumValues();
        public abstract string GetValueAsString(int index);
        public abstract bool AddValue(string value);
        public abstract void InsertEmpty();
        public abstract void RemoveValueAtIndex(int index);
    }

    public class ColumnInt : Column
    {
        List<int> values = new List<int>();
        public ColumnInt(String name) : base(name)
        {
        }

        public override int GetNumValues() { return values.Count; }
        public override string GetValueAsString(int index)
        {
            if (index >= 0 && index < values.Count)
                return values[index].ToString();
            return null;
        }
        public override bool AddValue(string value)
        {
            int parsedValue;
            if (int.TryParse(value, out parsedValue))
            {
                values.Add(parsedValue);
                return true;
            }
            return false;
        }
        public override void InsertEmpty()
        {
            AddValue(String.Empty);
        }
    }
        public override void RemoveValueAtIndex(int index)
        {
            values.RemoveAt(index);
        }
    }

    public class ColumnFloat : Column
    {
        List<int> values = new List<int>();
        public ColumnFloat(String name) : base(name)
        {
        }

        public override int GetNumValues() { return values.Count; }
        public override string GetValueAsString(int index)
        {
            if (index >= 0 && index < values.Count)
                return values[index].ToString();
            return null;
        }
        public override bool AddValue(string value)
        {
            int parsedValue;
            if (int.TryParse(value, out parsedValue))
            {
                values.Add(parsedValue);
                return true;
            }
            return false;
        }
        public override void RemoveValueAtIndex(int index)
        {
            values.RemoveAt(index);
        }
    }
        public override void InsertEmpty()
        {
            AddValue(String.Empty);
        }
    }

    public class ColumnString : Column
    {
        List<string> values = new List<string>();
        public ColumnString(String name) : base(name)
        {

        }

        public override int GetNumValues() { return values.Count; }
        public override string GetValueAsString(int index)
        {
            if (index >= 0 && index < values.Count)
                return values[index];
            return null;
        }
        public override bool AddValue(string value)
        {
            //no parsing needed
            values.Add(value);
            return true;
        }
        public override void RemoveValueAtIndex(int index)
        {
            values.RemoveAt(index);
        }
        public override void InsertEmpty()
        {
            AddValue(String.Empty);
        }
    }


}
