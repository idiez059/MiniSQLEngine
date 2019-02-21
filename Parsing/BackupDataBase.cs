using System;

public class BackupDataBase
{
    public BackupDataBase (String query)
	{
        string  backupDataBase =  @"BACKUP DATABASE\s+(\w+)\s+TO DISK\s+(\=)\s+(\'\w+\')(\;)";
        String[] partes = Regex.Split(query, backupDataBase);
    }
}
