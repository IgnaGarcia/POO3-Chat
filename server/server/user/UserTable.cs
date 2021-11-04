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
            string query = "SELECT * FROM \"user\";";
            command = new NpgsqlCommand(query, getSqlConnection());

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(toUser(reader));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        public User? getById(int id)
        {
            string query = "SELECT * FROM \"user\" WHERE \"id\" = " + id + ";";
            command = new NpgsqlCommand(query, getSqlConnection());

            try
            {
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return toUser(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public User? getByName(string name)
        {
            string query = "SELECT * FROM \"user\" WHERE \"name\" ILIKE '" + name + "';";
            command = new NpgsqlCommand(query, getSqlConnection());

            try
            {
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return toUser(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public int create(User user)
        {
            string query = "INSERT INTO \"user\"(name) VALUES ('" + user.getName() + "');";
            command = new NpgsqlCommand(query, getSqlConnection());
            try
            {
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        private User toUser(IDataRecord result)
        {
            return new User(
                Int32.Parse(result["id"].ToString()),
                result["name"].ToString());
        }
    }
}
