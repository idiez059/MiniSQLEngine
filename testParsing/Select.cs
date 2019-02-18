using System;

public abstract class Class1
{
	abstract public Class1()
	{
        String pattern = @"SELECT\s+(\*|\w+)\s+FROM\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+))?(\;)";
	}
}
