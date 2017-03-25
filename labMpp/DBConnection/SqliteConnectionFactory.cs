using System;
using System.Data;
using Mono.Data.Sqlite;
namespace ConnectionUtils
{
	public class SqliteConnectionFactory : ConnectionFactory
	{
		public override IDbConnection createConnection()
		{
            //Mono Sqlite Connection

            //String connectionString = "URI=file:\\Users\\Micu\\Downloads\\sqlitestudio - 3.1.1\\SQLiteStudio\\Festival,Version=3";
            //return new SqliteConnection(connectionString);

            //Windows Sqlite Connection, fisierul.db ar trebuie sa fie in directorul debug/ bin

            String connectionString = "Data Source=Festival;Version=3";
            return new SqliteConnection(connectionString);
        }
    }
}
