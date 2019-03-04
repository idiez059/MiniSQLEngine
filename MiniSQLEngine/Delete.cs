using System;
using System.Text.RegularExpressions;

public class Delete : Query
{
    /*
	public Delete (String query)
	{
        string delete = @"DELETE\s+FROM\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|<|>)\s+(\w+))?(\;)";
        String[] partes = Regex.Split(query, delete);
    }
    */
    public Delete( String tabla, String contenido)
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
