using Npgsql;
using server.connection;
using System.Data;

namespace server.chat
{
    internal class ChatTable : ConnectionProvider
    {
        NpgsqlCommand command;
        public ChatTable() : base() { }

        public List<Chat> getAll()
        {
            List<Chat> list = new List<Chat>();
            string query = "SELECT * FROM \"chat\";";

            command = new NpgsqlCommand(query, getSqlConnection());

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(toChat(reader));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public Chat? getById(int id)
        {
            string query = "SELECT * FROM \"chat\" WHERE \"id\" = " + id + ";";
            command = new NpgsqlCommand(query, getSqlConnection());

            try
            {
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return toChat(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public int create(Chat chat)
        {
            string query = "INSERT INTO \"chat\"(name) VALUES ('" + chat.getName() + "');";
            command = new NpgsqlCommand(query, getSqlConnection());
            try
            {
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        private Chat toChat(IDataRecord result)
        {
            return new Chat(
                Int32.Parse(result["id"].ToString()),
                result["name"].ToString());
        }

    }
}
