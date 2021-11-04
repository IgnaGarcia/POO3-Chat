using Npgsql;
using server.connection;
using System.Data;

namespace server.message
{
    internal class MessageTable : ConnectionProvider
    {
        NpgsqlCommand command;
        public MessageTable() : base() { }

        public List<Message> getByChat(int chatId)
        {
            List<Message> list = new List<Message>();
            string query = "SELECT * FROM \"message\" WHERE chat_id = "+ chatId +";";
            command = new NpgsqlCommand(query, getSqlConnection());

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(toMessage(reader));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        public int create(Message message)
        {
            string query = "INSERT INTO \"message\"(chat_id, from_id, message) VALUES (" + 
                message.getChatId() + ","+ message.getFromId() + ",'" + message.getMessage() +"');";
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

        private Message toMessage(IDataRecord result)
        {
            return new Message(
                Int32.Parse(result["id"].ToString()),
                Int32.Parse(result["chat_id"].ToString()),
                Int32.Parse(result["from_id"].ToString()),
                result["message"].ToString(),
                Convert.ToDateTime(result["create_date"].ToString())
            );
        }
    }
}
