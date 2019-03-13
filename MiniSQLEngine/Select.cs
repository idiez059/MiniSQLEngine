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
        if(bTable != null)
        {
            bColumn = bTable.findColumnByName(pColumns);
            if(bColumn != null)
            {
                String type = bColumn.getType();
                String result = String.Empty;
                switch (type)
                {
                    case "int":
                        if (pContenido[0] == null || pContenido[0].Equals(String.Empty))
                        {
                            
                            foreach (int buffer in (bColumn as ColumnInt).getList())
                            {
                                //Add splitting character after buffer!
                                result += buffer.ToString();
                            }
                        }
                        else
                        {
                            Column cColumn = bTable.findColumnByName(pContenido[0]);
                            if (cColumn == null)
                            {
                                return "Could not find the column specified in where condition";
                            }
                            else
                            {
                                if(pContenido[1].Equals(">"))
                                {
                                    foreach (int buffer in (bColumn as ColumnInt).getList())
                                    {
                                        if(buffer > Int32.Parse(pContenido[2]))
                                        {
                                            //Add splitting character after buffer!
                                            result += buffer.ToString();
                                        }
                                    }
                                }
                                else if(pContenido[1].Equals("<"))
                                {
                                    foreach (int buffer in (bColumn as ColumnInt).getList())
                                    {
                                        if (buffer < Int32.Parse(pContenido[2]))
                                        {
                                            //Add splitting character after buffer!
                                            result += buffer.ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (int buffer in (bColumn as ColumnInt).getList())
                                    {
                                        if (buffer == Int32.Parse(pContenido[2]))
                                        {
                                            //Add splitting character after buffer!
                                            result += buffer.ToString();
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "String":
                        if (pContenido[0] == null || pContenido[0].Equals(String.Empty))
                        {

                            foreach (String buffer in (bColumn as ColumnString).getList())
                            {
                                //Add splitting character after buffer!
                                result += buffer;
                            }
                        }
                        else
                        {
                            Column cColumn = bTable.findColumnByName(pContenido[0]);
                            if (cColumn == null)
                            {
                                return "Could not find the column specified in where condition";
                            }
                            else
                            {
                                if (pContenido[1].Equals(">"))
                                {
                                    foreach (String buffer in (bColumn as ColumnString).getList())
                                    {
                                        if (buffer.CompareTo(pContenido[2]) == 1)
                                        {
                                            //Add splitting character after buffer!
                                            result += buffer;
                                        }
                                    }
                                }
                                else if (pContenido[1].Equals("<"))
                                {
                                    foreach (String buffer in (bColumn as ColumnString).getList())
                                    {
                                        if (buffer.CompareTo(pContenido[2]) == -1)
                                        {
                                            //Add splitting character after buffer!
                                            result += buffer;
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (String buffer in (bColumn as ColumnString).getList())
                                    {
                                        if (buffer.CompareTo(pContenido[2]) == 0)
                                        {
                                            //Add splitting character after buffer!
                                            result += buffer;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "float":
                        if (pContenido[0] == null || pContenido[0].Equals(String.Empty))
                        {

                            foreach (float buffer in (bColumn as ColumnFloat).getList())
                            {
                                //Add splitting character after buffer!
                                result += buffer.ToString();
                            }
                        }
                        else
                        {
                            Column cColumn = bTable.findColumnByName(pContenido[0]);
                            if (cColumn == null)
                            {
                                return "Could not find the column specified in where condition";
                            }
                            else
                            {
                                if (pContenido[1].Equals(">"))
                                {
                                    foreach (float buffer in (bColumn as ColumnFloat).getList())
                                    {
                                        if (buffer > float.Parse(pContenido[2]))
                                        {
                                            //Add splitting character after buffer!
                                            result += buffer.ToString();
                                        }
                                    }
                                }
                                else if (pContenido[1].Equals("<"))
                                {
                                    foreach (float buffer in (bColumn as ColumnInt).getList())
                                    {
                                        if (buffer < float.Parse(pContenido[2]))
                                        {
                                            //Add splitting character after buffer!
                                            result += buffer.ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (float buffer in (bColumn as ColumnInt).getList())
                                    {
                                        if (buffer == float.Parse(pContenido[2]))
                                        {
                                            //Add splitting character after buffer!
                                            result += buffer.ToString();
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
                
            }
            else
            {
                return "Could not find the specified column";
            }
        }else
            {
                return "Could not find specified table";
            }
        return null;
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
