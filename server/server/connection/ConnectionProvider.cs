using Npgsql;
using System.Data;

namespace server.connection
{
    internal class ConnectionProvider
    {
        protected NpgsqlDataReader reader;
        protected NpgsqlCommand command;
        protected IDataRecord result;

        public ConnectionProvider() { }

        public NpgsqlConnection GetSqlConnection()
        {
            try
            {
                NpgsqlConnection sqlConnection = new NpgsqlConnection(ConnectionConfig.GetConnectionString());
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
                return sqlConnection;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
