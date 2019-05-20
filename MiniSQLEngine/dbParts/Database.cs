using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;
using MiniSQLEngine;
using System.ComponentModel;
using MiniSQLEngine.Security;

namespace MiniSQLEngine
{
    public class Database : IDisposable
    {
        private Boolean disposed = false;
        public String Name { get; }
        public List<Table> Tables = new List<Table>();
        private List<User> users = new List<User>();
        private List<Profile> profiles = new List<Profile>();
        private string loggedUser;
        private string result;

        // Track whether Dispose has been called.

        public Database(string dbName, string user, string password)
        {

            Profile adminProf = new Profile("adminProf");
            User admin = new User("admin", "admin", adminProf);
            users.Add(admin);
            
            profiles.Add(adminProf);
            result = "DBErrorExist/User/Passwd";
            Name = dbName;
            string admPass;
            if (user == null)
            {
                result = "Must introduce a user";
                throw new System.ArgumentException("Must introduce a user");
            }
            else
            {
                if (user == "admin")
                {
                    foreach (User us in users)
                    {
                        if (us.getUserName() == "admin")
                        {
                            admPass = us.getUserPass();
                            if (admPass == password)
                            {
                                loggedUser = "admin";
                                result = "DB created OK.";

                            } else
                            {
                                result = "Admin password incorrect";
                                throw new System.ArgumentException("Admin password incorrect");
                            }
                        }
                    }
                }
                else
                {
                    foreach (User us in users)
                    {

                        {
                            if (us.ToString() == user)
                            {
                                if (us.getUserPass() == password)
                                {
                                    loggedUser = user;
                                    result = "DB created OK.";
                                }
                                else
                                {
                                    result = "User and password do not mach";
                                    throw new System.ArgumentException("User and password do not mach");
                                }
                            }
                            else
                            {
                                result = "User does not exist";
                                throw new System.ArgumentException("User does not exist");
                            }
                        }
                    }
                }

            }
        }

        public bool checkPrivileges(string user, string query, string pTable)
        {
            Profile profile = null;
            List<string> list = new List<string>();
            if(user == "admin") { return true; }
            foreach (User us in users)
            {
                if (us.getUserName() == user)
                {
                    profile = us.getUserProfile();
                }
            }
            switch (query)
            {
                case "DELETE":
                    list = profile.getDeleteList();
                    break;
                case "INSERT":
                    list = profile.getInsertList();
                    break;
                case "UPDATE":
                    list = profile.getUpdateList();
                    break;
                case "SELECT":
                    list = profile.getSelectList();
                    break;
            }
            foreach (string table in list)
            {
                if (table == pTable)
                {
                    return true;
                }
            }
            throw new System.ArgumentException("The user has no privileges over this table");

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing == true)
                {
                    //someone want the deterministic release of all resources
                    //Let us release all the managed resources
                    ReleaseManagedResources();
                }
                else
                {
                    // Do nothing, no one asked a dispose, the object went out of
                    // scope and finalized is called so lets next round of GC 
                    // release these resources

                }
                // Release the unmanaged resource in any case as they will not be 
                // released by GC
                disposed = true;
                ReleaseUnmanagedResources();

            }
        }

        private void ReleaseUnmanagedResources()
        {
            Console.WriteLine("Releasing Managed Resources");
            if (this != null)
            {
                this.Dispose();
            }
        }
        private void ReleaseManagedResources()
        {
            FileSystemAbstract.saveData(Name,Tables);
            Console.WriteLine("Releasing Unmanaged Resources");
        }


        /// <summary>
        /// Get a table by its name
        /// </summary>
        /// <param name="name">The name of the table</param>
        /// <returns>Returns the table or null if not found</returns>
        public Table GetTableByName(String name)
        {
            foreach (Table table in Tables)
            {
                if (table.Name == name)
                {
                    return table;
                }
            }
            return null;
        }
        public bool ExistProfile(string nameProfile)
        {
            bool exist = false;
            foreach (Profile prof in profiles)
            {
                if (prof.profileName == nameProfile)
                {
                    exist = true;
                }
            }
            return exist;
        }
        public string CreateSecProfile(string name)
        {
            if (ExistProfile(name))
            {
                return Messages.ProfileErrorAlreadyExists;
            }
            else
            {
                Profile profile = new Profile(name);
                profiles.Add(profile);
                FileSystemAbstract.saveProfileInfo(name);
                return Messages.CreateProfileSuccess;
            }
        }
        public string DropSecProfile(string name)
        {

            foreach (Profile prof in profiles)
            {
                if (prof.profileName == name)
                {
                    profiles.Remove(prof);
                    return Messages.DropProfileSuccess;

                }
            }


            return null;
        }
        public string AddUser(string userName, string userPassword, Profile userProfileName)
        {
            foreach (User us in users)
            {
                if (us.getUserName() == userName)
                {
                    return Messages.UserErrorAlreadyExists;
                }
            }
            User user = new User(userName, userPassword, userProfileName);
            users.Add(user);
            FileSystemAbstract.saveUserInfo(userName, userPassword, userProfileName);
            return Messages.UserAddedSuccess;

        }
        public string DeleteUser(string userName)
        {
            foreach (User us in users)
            {
                if (us.getUserName() == userName)
                {
                    users.Remove(us);
                    return Messages.UserDeletedCorrectly;
                }
            }
            return Messages.UserNotDeleted;
        }
        public string GrantOnTo(string privilege, string table, Profile prof)
        {
            foreach (Table theTable in Tables)
            {
                if (theTable.Name == table)
                {
                    foreach (Profile profi in profiles)
                    {
                        if (profi == prof)
                        {
                            if (privilege.Equals("INSERT") || privilege.Equals("DELETE") || privilege.Equals("SELECT") || privilege.Equals("UPDATE"))
                            {
                                switch (privilege)
                                {
                                    case "DELETE":
                                        foreach (string tab in profi.getDeleteList())
                                        {
                                            if (tab == table)
                                            {
                                                return Messages.ErrorPrivilegeGrant;
                                            }
                                        }
                                        break;
                                    case "INSERT":
                                        foreach (string tab in profi.getInsertList())
                                        {
                                            if (tab == table)
                                            {
                                                return Messages.ErrorPrivilegeGrant;
                                            }
                                        }
                                        break;
                                    case "UPDATE":
                                        foreach (string tab in profi.getUpdateList())
                                        {
                                            if (tab == table)
                                            {
                                                return Messages.ErrorPrivilegeGrant;
                                            }
                                        }
                                        break;
                                    case "SELECT":
                                        foreach (string tab in profi.getSelectList())
                                        {
                                            if (tab == table)
                                            {
                                                return Messages.ErrorPrivilegeGrant;
                                            }
                                        }
                                        break;
                                }
                                profi.addTableToList(table, privilege);
                            }
                            else
                            {
                                return Messages.ErrorPrivilegeGrant;
                            }

                        }
                    }
                    return Messages.GrantedCorrectly;
                }
            }
            return Messages.TableDoesNotExist;
        }
        public string RevokeOnTo(string privilege, string table, Profile prof)
        {

            foreach (Profile profi in profiles)
            {
                if (profi == prof)
                {
                    if (privilege.Equals("INSERT") || privilege.Equals("DELETE") || privilege.Equals("SELECT") || privilege.Equals("UPDATE"))
                    {
                        switch (privilege)
                        {
                            case "DELETE":
                                foreach (string tab in profi.getDeleteList())
                                {
                                    if (tab == table)
                                    {
                                        profi.removeTableFromList(table, privilege);
                                        return Messages.RevokeedCorrectly;

                                    }
                                }
                                break;
                            case "INSERT":
                                foreach (string tab in profi.getInsertList())
                                {
                                    if (tab == table)
                                    {
                                        profi.removeTableFromList(table, privilege);
                                        return Messages.RevokeedCorrectly;

                                    }
                                }
                                break;
                            case "UPDATE":
                                foreach (string tab in profi.getUpdateList())
                                {
                                    if (tab == table)
                                    {
                                        profi.removeTableFromList(table, privilege);
                                        return Messages.RevokeedCorrectly;

                                    }
                                }
                                break;
                            case "SELECT":
                                foreach (string tab in profi.getSelectList())
                                {
                                    if (tab == table)
                                    {
                                        profi.removeTableFromList(table, privilege);
                                        return Messages.RevokeedCorrectly;

                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        return Messages.ErrorPrivilegeRevoke;
                    }

                }
            }
            return Messages.RevokeedCorrectly;
        }
    


        public Profile GetProfileByName(String theName)
        {
            foreach(Profile prof in profiles)
            {
                if (prof.profileName == theName)
                {
                    return prof;
                }               
            }
            return null;
        }
        /// <summary>
        /// Creates a table
        /// </summary>
        /// <param name="name">Name of the new table</param>
        /// <param name="columns">Columns to be added to the table</param>
        /// <returns>returns an error/success message</returns>
        public string CreateTable(string name, List<Column> columns)
        {
            if (GetTableByName(name) != null)
                return Messages.TableErrorAlreadyExists;
            else
            {
                try
                {
                    Table table = new Table(name, columns);
                    Tables.Add(table);
                    return Messages.CreateTableSuccess;
                }
                catch
                {
                    return Messages.WrongSyntax;
                }
            }
        }
        public string Update(String columns, String tableName, String left, String op, String right)
        {
            checkPrivileges(loggedUser, "UPDATE", tableName);
            Table table = GetTableByName(tableName);
            table.ColumnByName(columns);

            //paso los mismos parametros que me han enviado 

            table.Update(columns,tableName, left, op, right);
            return "hay que cambiarlo";
        }
        public Table SelectAll(string tableName)
        {
            checkPrivileges(loggedUser, "SELECT", tableName);
            return GetTableByName(tableName);
        }
        public Table SelectColumns(string tableName, List<string> columnNames)
        {
            checkPrivileges(loggedUser, "SELECT", tableName);
            Table sourceTable = GetTableByName(tableName);
            List<Column> selectedColumns = new List<Column>();
            //Else only selected ones
            foreach (string columnName in columnNames)
            {
                if (columnName == "*")
                    return null; // we don't allow "SELECT *,Name ...", only "SELECT * ..."

                Column column = sourceTable.ColumnByName(columnName);
                if (column != null)
                    selectedColumns.Add(column);
                else return null;
            }
            Table result = new Table("Result",selectedColumns);
            return result;
        }
        public string Insert(string tableName, string [] values)
        {
            checkPrivileges(loggedUser, "INSERT", tableName);
            Table table = GetTableByName(tableName);
            if (table == null)
            {
                return Messages.TableDoesNotExist;
            }
            int cont = 0;

            foreach (Column column in table.Columns)
            {
                column.AddValue(values[cont]);
                cont++;
            }
            return Messages.InsertSuccess;
        }
        public string Insert(string tableName, List<string> columnNames, string[] values)
        {
            checkPrivileges(loggedUser, "INSERT", tableName);
            Table table = GetTableByName(tableName);
            if (table == null)
            {
                return Messages.TableDoesNotExist;
            }
            

            foreach (Column column in table.Columns)
            {
                for (int i = 0; i < columnNames.Count; i++)
                {
                    if (column.Name == columnNames[i])
                    {
                        column.AddValue(values[i]);
                    }
                }
               

            }
            return Messages.InsertSuccess;
        }


        public string  DeleteRows(String tableName, String left, String op, string right)
        {
            checkPrivileges(loggedUser, "DELETE", tableName);
            Table sourceTable = GetTableByName(tableName);
            sourceTable.DeleteRows(left, op, right);
            return Messages.TupleDeleteSuccess;

        }
        public Table DeleteTable(string name)
        {
            checkPrivileges(loggedUser, "DELETE", name);
            for (int i = 0; i < Tables.Count; i++)
            {
                if (Tables[i].Name.Equals(name))
                {
                    Tables.RemoveAt(i);
                }
            }
            return null;
        }
        public string getResult()
        {
            return result;
        }
        public String RunQuery(string line)
        {
            Query theQuery = Parser.Parse(line);
            return theQuery.Run(this);
            
        }
    }
}