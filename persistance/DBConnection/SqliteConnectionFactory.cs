using System;
using System.Data;
using Mono.Data.Sqlite;
namespace ConnectionUtils
{
	public class SqliteConnectionFactory : ConnectionFactory
	{
		public override IDbConnection createConnection()
		{
            String connectionString = "URI=file:Festival,Version=3";
            return new SqliteConnection(connectionString);
        }
    }
}
