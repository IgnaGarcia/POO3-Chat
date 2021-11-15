namespace ChatServer.connection
{
    internal class ConnectionConfig
    {
        private string dbserv;

        private static ConnectionConfig? instance;

        private ConnectionConfig()
        {
            string server = "localhost";
            string user = "postgres";
            string password = "admin";
            string database = "chat";
            dbserv = "Server = " + server
                + "; User Id = " + user
                + "; Password = " + password
                + "; Database = " + database
                + ";";
        }

        private static void CreateInstance()
        {
            if (instance == null) instance = new ConnectionConfig();
        }

        public static ConnectionConfig getInstance()
        {
            if (instance == null) CreateInstance();
            return instance!;
        }

        public static string GetConnectionString()
        {
            CreateInstance();
            return instance!.dbserv;
        }
    }
}
