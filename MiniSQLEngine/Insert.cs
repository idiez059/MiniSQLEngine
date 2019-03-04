using System;
using System.Text.RegularExpressions;

public class Insert : Query
{
    /*
	public Insert(String query)
    {
        string insert = @"INSERT INTO\s+(\*|\w+)(?:\s+[WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+)]+)?(\;)";
        String[] partes = Regex.Split(query, insert); 
	
	}
    */
  
    String pTabla;
    String pContenido;
    public Insert (String tabla, String contenido)
    {
       
        pTabla = tabla;
        pContenido = contenido;
    }
    public override void Run()
    {
        throw new NotImplementedException();
    }

    public string getTabla()
    {
        return pTabla;
    }

    public string getContenido()
    {
        return pContenido;
    }
}
