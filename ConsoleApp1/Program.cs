using ConsoleApp1;
using ConsoleApp1.Interfaces;
using Microsoft.Data.Sqlite;
// Название есть (MyInvestFund.sqlite) простое название, 3 таблицы есть, данными заполнил
File.Create(Costants.DatabaseFile).Close();
SqliteConnectionStringBuilder stringBuilder = new SqliteConnectionStringBuilder();
Menu menu = new();
Querys querys = new Querys();
stringBuilder.ConnectionString = Costants.DatabaseConnectionString;
SqliteConnection databaseConnection = new SqliteConnection(stringBuilder.ConnectionString);
databaseConnection.Open();
querys.CreateTables(databaseConnection);
querys.SendSqlCommandNonQuery(databaseConnection, $"INSERT INTO Brent(Name, Price, Date) VALUES ('One', 1 ,'{DateTime.Now}')");
querys.SendSqlCommandNonQuery(databaseConnection, $"INSERT INTO Brent(Name, Price, Date) VALUES ('Two', 2 ,'{DateTime.Now}')");
querys.SendSqlCommandNonQuery(databaseConnection, $"INSERT INTO Brent(Name, Price, Date) VALUES ('Three', 3 ,'{DateTime.Now}')");

querys.SendSqlCommandNonQuery(databaseConnection, $"INSERT INTO Gold(Name, Price, Date) VALUES ('One', 1 ,'{DateTime.Now}')");
querys.SendSqlCommandNonQuery(databaseConnection, $"INSERT INTO Gold(Name, Price, Date) VALUES ('Two', 2 ,'{DateTime.Now}')");
querys.SendSqlCommandNonQuery(databaseConnection, $"INSERT INTO Gold(Name, Price, Date) VALUES ('Three', 3 ,'{DateTime.Now}')");

querys.SendSqlCommandNonQuery(databaseConnection, $"INSERT INTO RTS(Name, Price, Date) VALUES ('One', 1 ,'{DateTime.Now}')");
querys.SendSqlCommandNonQuery(databaseConnection, $"INSERT INTO RTS(Name, Price, Date) VALUES ('Two', 2 ,'{DateTime.Now}')");
querys.SendSqlCommandNonQuery(databaseConnection, $"INSERT INTO RTS(Name, Price, Date) VALUES ('Three', 3 ,'{DateTime.Now}')");

menu.GetMenu(databaseConnection);




