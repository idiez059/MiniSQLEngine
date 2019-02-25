using System;
using System.Text.RegularExpressions;

public class Select : Query
{
    String pSeleccion;
    String pTabla;
    String[] pCondiciones;
    public Select(String seleccion, String tabla, String[] condiciones)
	{
        pSeleccion = seleccion;
        pTabla = tabla;
        pCondiciones = condiciones;
	}
    public override void Run()
    {
        throw new NotImplementedException();
    }

    public string getSeleccion()
    {
        return pSeleccion;
    }

    public string getTabla()
    {
        return pTabla;
    }
}
