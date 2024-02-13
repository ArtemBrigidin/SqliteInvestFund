using Microsoft.Data.Sqlite;

namespace ConsoleApp1.Interfaces
{
    public interface IMenu
    {
        public void GetMenu(SqliteConnection databaseConnection);
    }
}
