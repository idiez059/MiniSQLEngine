
namespace MiniSQLEngine
{
    class Messages
    {
        public const string CreateDatabaseSuccess = "Database created";
        public const string DeleteDatabaseSuccess = "Database deleted";
        public const string BackupDatabaseSuccess = "Database backed up";


        public const string CreateTableSuccess = "Table created";
        public const string InsertSuccess = "Tuple added";
        public const string TupleDeleteSuccess = "Tuple(s) deleted";
        public const string TupleUpdateSuccess = "Tuple(s) updated";

        public const string Error = "ERROR: ";

        public const string WrongSyntax = Error + "Syntactical error";
        public const string DatabaseDoesNotExist = Error + "Database does not exist";
        public const string TableDoesNotExist = Error + "Table does not exist";
        public const string ColumnDoesNotExist = Error + "Column does not exist";
        public const string IncorrectDataType = Error + "Incorrect data type";
        public const string DatabaseErrorAlreadyExists = Error + "Database already exists";
        public const string TableErrorAlreadyExists = Error + "Table already exists";
        public const string ConditionDoesNotExist = "Introduced condition is incorrect: must be <, > or =.";
    }
}
