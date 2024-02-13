using Microsoft.Data.Sqlite;

namespace ConsoleApp1.Interfaces
{
    public class Querys : IQuerys
    {
        
        public void SendSqlCommandNonQuery(SqliteConnection sqliteConnection, string sqlCommand)
        {
            using var command = sqliteConnection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sqlCommand;
            command.ExecuteNonQuery();
        }

        public void CreateTables(SqliteConnection databaseConnection)
        {
            SendSqlCommandNonQuery(databaseConnection, @"CREATE TABLE Brent (
                                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Name TEXT(50),
                                            Price REAL,
                                            Date TEXT)");

            SendSqlCommandNonQuery(databaseConnection, @"CREATE TABLE Gold (
                                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Name TEXT(50),
                                            Price REAL,
                                            Date TEXT)");

            SendSqlCommandNonQuery(databaseConnection, @"CREATE TABLE RTS (
                                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Name TEXT(50),
                                            Price REAL,
                                            Date TEXT)");
        }

        public void SqlReader(SqliteConnection databaseConnection, string NameTable)
        {
            string SqlQuery = $"SELECT * FROM {NameTable}";
            SqliteCommand sqliteCommand = new SqliteCommand(SqlQuery, databaseConnection);
            using (SqliteDataReader reader = sqliteCommand.ExecuteReader())
            {

                if (reader.HasRows)
                {
                    Console.WriteLine($"Данные из таблицы {NameTable}");
                    while (reader.Read())
                    {
                        var ID = reader.GetValue(0);
                        var Name = reader.GetValue(1);
                        var Price = reader.GetValue(2);
                        var Date = reader.GetValue(3);

                        Console.WriteLine($"| ID = {ID} |\t| Название = {Name} |\t| Цена = {Price} |\t| Дата добавления = {Date} |");
                    }
                }
                else
                    Console.WriteLine("Данная таблица пустая");

                Console.WriteLine("Нажмите любую клавишу что бы вернуться в меню.");
                Console.ReadKey();
            }
        }
    }
}
