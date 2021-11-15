using ChatEntities.entities;
using Npgsql;
using ChatServer.connection;
using System.Data;

namespace ChatServer.orm
{
    internal class MessageTable : ConnectionProvider
    {
        public MessageTable() : base() { }

        public List<Message> GetByChat(int chatId)
        {
            List<Message> list = new List<Message>();
            string query = "SELECT * FROM \"message\" WHERE chat_id = "+ chatId +";";
            command = new NpgsqlCommand(query, GetSqlConnection());

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(ToMessage(reader));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        public int Create(Message message)
        {
            string query = "INSERT INTO \"message\"(chat_id, from_id, from_name, message) VALUES (" + 
                message.GetChatId() + ","+ message.GetFromId() + ",'" + message.GetFromName() + ",'" + message.GetMessage() +"');";
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

        private Message ToMessage(IDataRecord result)
        {
            return new Message(
                Int32.Parse(result["id"].ToString()),
                Int32.Parse(result["chat_id"].ToString()),
                Int32.Parse(result["from_id"].ToString()),
                result["from_name"].ToString(),
                result["message"].ToString(),
                Convert.ToDateTime(result["create_date"].ToString())
            );
        }
    }
}
