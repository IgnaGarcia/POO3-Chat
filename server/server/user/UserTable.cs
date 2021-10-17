using Npgsql;
using server.connection;
using System.Data;

namespace server.user
{
    internal class UserTable : ConnectionProvider
    {
        public UserTable() : base() { }

        public List<User> getAll()
        {
            List<User> list = new List<User>();
            string query = "SELECT * FROM \"user\"";
            command = new NpgsqlCommand(query, getSqlConnection());

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(toUser((IDataRecord)reader));
            }
            return list;
        }

        public User getById(int id)
        {
            //TODO
            return null;
        }
        public User getByName(string name)
        {
            //TODO
            return null;
        }

        public int create(User user)
        {
            /*string query = "INSERT INTO \"user\"(name) VALUES (" + user.getName() + ")";
            command = new NpgsqlCommand(query, getSqlConnection());

            reader = command.ExecuteReader();
            if (reader.Read())
            {
                result = (IDataRecord)reader;
                return result.GetValue(0);
            }*/
            //TODO
            return 0;
        }

        private User toUser(IDataRecord result)
        {
            return new User(
                Int32.Parse(result["id"].ToString()),
                result["name"].ToString());
        }
    }
}
