﻿using Npgsql;
using System.Data;

namespace server.connection
{
    internal class ConnectionProvider
    {
        static NpgsqlConnection sqlConnection = null;
        protected NpgsqlDataReader reader;

        public ConnectionProvider()
        {
            if (sqlConnection == null)
            {
                try
                {
                    sqlConnection = new NpgsqlConnection(ConnectionConfig.getConnectionString());
                    if (sqlConnection.State != ConnectionState.Open)
                    {
                        sqlConnection.Open();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void ejecute(string query)
        {
            NpgsqlCommand command = new NpgsqlCommand(query, sqlConnection);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void finish()
        {
            sqlConnection.Close();
        }

        public NpgsqlConnection getSqlConnection()
        {
            return sqlConnection;
        }
    }
}