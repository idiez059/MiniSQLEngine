using System;

public abstract class Class1
{
	abstract public Class1()
	{
        //hacer un metodo parsear
        //poner los parametros 

        String pattern = @"SELECT\s+(\*|\w+)\s+FROM\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+))?(\;)";
	}
}
