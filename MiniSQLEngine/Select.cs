using System;
using System.Text.RegularExpressions;
using MiniSQLEngine;
using System.Collections.Generic;

public class Select : Query
{
    String pColumns;
    String pTabla;
    List<String> pContenido;
    public Select(String columns, String tabla, List<String> contenido)
	{
        pColumns = columns;
        pTabla = tabla;
        pContenido = contenido;
	}
    public override String Run(BDData db)
    {
        Table bTable = null;
        Column bColumn = null;
        //String bContent = pContenido;
        bTable = db.getTableByName(pTabla);
        String result = String.Empty;
        String splitChar = "/r/n";
        if(bTable != null)
        {
            bColumn = bTable.findColumnByName(pColumns);
            if(bColumn != null)
            {
                if(pContenido[0].Equals(String.Empty) || pContenido[0] == null)
                {
                    String type = bColumn.GetType();
                    switch (type)
                    {
                        case "int":
                            //Add splitting character here!
                            foreach(int buffer in (bColumn as ColumnInt).getList())
                            {
                                result = result + buffer.ToString() + splitChar;
                            }
                            break;
                        case "String":
                            //Add splitting character here!
                            foreach (String buffer in (bColumn as ColumnString).getList())
                            {
                                result = result + buffer + splitChar;
                            }
                            break;
                        case "Float":
                            //Add splitting character here!
                            foreach (float buffer in (bColumn as ColumnFloat).getList())
                            {
                                result = result + buffer.ToString() + splitChar;
                            }
                            break;
                    }
                }
                else
                {
                    String typeSel = bColumn.GetType();
                    Column condColumn = bTable.findColumnByName(pContenido[0]);
                    if (condColumn == null || condColumn.Equals(String.Empty))
                    {
                        return "Could not find the column specified in the where part of the query";
                    }
                    else
                    {
                        String fromType = condColumn.GetType();
                        String comparator = pContenido[1];
                        String condition = pContenido[2];
                        List<int> indexList = new List<int>();
                        List<String> finalList = new List<String>();
                        if (fromType.Equals("int"))
                        {
                            int cond = Int32.Parse(condition);
                            if (comparator.Equals("<"))
                            {
                                int cont = 0;
                                foreach(int buffer in (condColumn as ColumnInt).getList())
                                {
                                    if (buffer < cond)
                                    {
                                        indexList.Add(cont);
                                    }
                                    cont++;
                                }
                            }
                            else if (comparator.Equals(">"))
                            {
                                int cont = 0;
                                foreach (int buffer in (condColumn as ColumnInt).getList())
                                {
                                    if (buffer > cond)
                                    {
                                        indexList.Add(cont);
                                    }
                                    cont++;
                                }
                            }
                            else if (comparator.Equals("="))
                            {
                                int cont = 0;
                                foreach (int buffer in (condColumn as ColumnInt).getList())
                                {
                                    if (buffer == cond)
                                    {
                                        indexList.Add(cont);
                                    }
                                    cont++;
                                }
                            }
                            else
                            {
                                return "A comparing condition was not provided on WHERE part of the query";
                            }
                            foreach(int foo in indexList)
                            {
                                finalList.Add((bColumn as ColumnInt).getElementByIndex(foo).ToString());
                            }
                            foreach(String atLast in finalList)
                            {
                                result = result + atLast + splitChar;
                            }
                        }
                        else if(fromType.Equals("float"))
                        {
                            float cond = float.Parse(condition);
                            if (comparator.Equals("<"))
                            {
                                int cont = 0;
                                foreach (float buffer in (condColumn as ColumnFloat).getList())
                                {
                                    if (buffer < cond)
                                    {
                                        indexList.Add(cont);
                                    }
                                    cont++;
                                }
                            }
                            else if (comparator.Equals(">"))
                            {
                                int cont = 0;
                                foreach (float buffer in (condColumn as ColumnFloat).getList())
                                {
                                    if (buffer > cond)
                                    {
                                        indexList.Add(cont);
                                    }
                                    cont++;
                                }
                            }
                            else if (comparator.Equals("="))
                            {
                                int cont = 0;
                                foreach (float buffer in (condColumn as ColumnFloat).getList())
                                {
                                    if (buffer == cond)
                                    {
                                        indexList.Add(cont);
                                    }
                                    cont++;
                                }
                            }
                            else
                            {
                                return "A comparing condition was not provided on WHERE part of the query";
                            }
                            foreach (int foo in indexList)
                            {
                                finalList.Add((bColumn as ColumnInt).getElementByIndex(foo).ToString());
                            }
                            foreach (String atLast in finalList)
                            {
                                result = result + atLast + splitChar;
                            }
                        }
                        else
                        {
                            String cond = condition;
                            if (comparator.Equals("<"))
                            {
                                int cont = 0;
                                foreach (String buffer in (condColumn as ColumnString).getList())
                                {
                                    if (buffer.CompareTo(cond) == -1)
                                    {
                                        indexList.Add(cont);
                                    }
                                    cont++;
                                }
                            }
                            else if (comparator.Equals(">"))
                            {
                                int cont = 0;
                                foreach (String buffer in (condColumn as ColumnString).getList())
                                {
                                    if (buffer.CompareTo(cond) == 1)
                                    {
                                        indexList.Add(cont);
                                    }
                                    cont++;
                                }
                            }
                            else if (comparator.Equals("="))
                            {
                                int cont = 0;
                                foreach (String buffer in (condColumn as ColumnString).getList())
                                {
                                    if (buffer.Equals(cond))
                                    {
                                        indexList.Add(cont);
                                    }
                                    cont++;
                                }
                            }
                            else
                            {
                                return "A comparing condition was not provided on WHERE part of the query";
                            }
                            foreach (int foo in indexList)
                            {
                                finalList.Add((bColumn as ColumnInt).getElementByIndex(foo).ToString());
                            }
                            foreach (String atLast in finalList)
                            {
                                result = result + atLast + splitChar;
                            }
                        }
                    }
                }
                return result;
            }
            else
            {
                return "Could not find the specified column";
            }
        }
        else
        {
            return "Could not find specified table";
        }
    }

    public string getColumns()
    {
        return pColumns;
    }

    public string getTabla()
    {
        return pTabla;
    }

    public List<String> getContenido()
    {
        return pContenido;
    }
}
