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

        public NpgsqlConnection getSqlConnection()
        {
            try
            {
                NpgsqlConnection sqlConnection = new NpgsqlConnection(ConnectionConfig.getConnectionString());
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
