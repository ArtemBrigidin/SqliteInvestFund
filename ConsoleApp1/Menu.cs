
using Microsoft.Data.Sqlite;

namespace ConsoleApp1.Interfaces
{
    public class Menu : IMenu
    {
            Querys querys = new();
            public void GetMenu(SqliteConnection databaseConnection)
            {
                int choice = -1;
                string? name;
                while (choice != 0)
                {
                    Console.WriteLine("1. Добавить данные в таблицу Brent.");
                    Console.WriteLine("2. Добавить данные в таблицу Gold.");
                    Console.WriteLine("3. Добавить данные в таблицу RTS.");
                    Console.WriteLine("4. Вывести данные таблицы Brent");
                    Console.WriteLine("5. Вывести данные таблицы Gold");
                    Console.WriteLine("6. Вывести данные таблицы RTS");
                    Console.WriteLine("0. Выйти.");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\tДобавление данных в таблицу Brent");
                            Console.WriteLine("Введите название >> ");
                            name = Console.ReadLine();
                            Console.WriteLine("Введите цену >> ");
                            var price = Console.ReadLine();
                            querys.SendSqlCommandNonQuery(databaseConnection, $"INSERT INTO Brent(Name, Price, Date) VALUES ('{name}', {price} ,'{DateTime.Now}')");
                            Console.Clear();
                            break;
                        case 2:
                            Console.WriteLine("\tДобавление данных в таблицу Gold");
                            Console.WriteLine("Введите название >> ");
                            name = Console.ReadLine();
                            Console.WriteLine("Введите цену >> ");
                            price = Console.ReadLine();
                            querys.SendSqlCommandNonQuery(databaseConnection, $"INSERT INTO Gold(Name, Price, Date) VALUES ('{name}', {price} ,'{DateTime.Now}')");
                            Console.Clear();
                            break;
                        case 3:
                            Console.WriteLine("\tДобавление данных в таблицу RTS");
                            Console.WriteLine("Введите название >> ");
                            name = Console.ReadLine();
                            Console.WriteLine("Введите цену >> ");
                            price = Console.ReadLine();
                            querys.SendSqlCommandNonQuery(databaseConnection, $"INSERT INTO RTS(Name, Price, Date) VALUES ('{name}', {price} ,'{DateTime.Now}')");
                            Console.Clear();
                            break;
                        case 4:
                            querys.SqlReader(databaseConnection, "Brent");
                            Console.Clear();
                            break;
                        case 5:
                            querys.SqlReader(databaseConnection, "Gold");
                            Console.Clear();
                            break;
                        case 6:
                            querys.SqlReader(databaseConnection, "RTS");
                            Console.Clear();
                            break;
                        case 0:
                            databaseConnection.Close();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                }
            }
        }
    }