using Microsoft.Data.Sqlite;

namespace ConsoleApp1.Interfaces
{
    internal interface IQuerys
    {
        void SendSqlCommandNonQuery(SqliteConnection sqliteConnection, string sqlCommand);
        void CreateTables(SqliteConnection databaseConnection);

        void SqlReader(SqliteConnection databaseConnection, string NameTable);
    }
}
