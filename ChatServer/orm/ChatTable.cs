using ChatEntities.entities;
using Npgsql;
using ChatServer.connection;
using System.Data;

namespace ChatServer.orm
{
    internal class ChatTable : ConnectionProvider
    {
        public ChatTable() : base() { }

        public List<Chat> GetAll()
        {
            List<Chat> list = new List<Chat>();
            string query = "SELECT * FROM \"chat\";";

            command = new NpgsqlCommand(query, GetSqlConnection());

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(ToChat(reader));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public Chat? GetById(int id)
        {
            string query = "SELECT * FROM \"chat\" WHERE \"id\" = " + id + ";";
            command = new NpgsqlCommand(query, GetSqlConnection());

            try
            {
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return ToChat(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public int Create(Chat chat)
        {
            string query = "INSERT INTO \"chat\"(name) VALUES ('" + chat.GetName() + "');";
            command = new NpgsqlCommand(query, GetSqlConnection());
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

        private Chat ToChat(IDataRecord result)
        {
            return new Chat(
                Int32.Parse(result["id"].ToString()),
                result["name"].ToString());
        }

    }
}
