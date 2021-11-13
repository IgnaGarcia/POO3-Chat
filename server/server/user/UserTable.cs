using Npgsql;
using server.connection;
using System.Data;

namespace server.user
{
    internal class UserTable : ConnectionProvider
    {
        public UserTable() : base() { }

        public List<User> GetAll()
        {
            List<User> list = new List<User>();
            string query = "SELECT * FROM \"user\";";
            command = new NpgsqlCommand(query, GetSqlConnection());

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(ToUser(reader));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        public User? GetById(int id)
        {
            string query = "SELECT * FROM \"user\" WHERE \"id\" = " + id + ";";
            command = new NpgsqlCommand(query, GetSqlConnection());

            try
            {
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return ToUser(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public User? GetByName(string name)
        {
            string query = "SELECT * FROM \"user\" WHERE \"name\" ILIKE '" + name + "';";
            command = new NpgsqlCommand(query, GetSqlConnection());

            try
            {
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return ToUser(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public int Create(User user)
        {
            string query = "INSERT INTO \"user\"(name) VALUES ('" + user.GetName() + "');";
            command = new NpgsqlCommand(query, GetSqlConnection());
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

        private User ToUser(IDataRecord result)
        {
            return new User(
                Int32.Parse(result["id"].ToString()),
                result["name"].ToString());
        }
    }
}
