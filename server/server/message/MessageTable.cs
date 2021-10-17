using Npgsql;
using server.connection;
using System.Data;

namespace server.message
{
    internal class MessageTable : ConnectionProvider
    {
        NpgsqlCommand command;
        public MessageTable() : base() { }

        public List<Message> getByChat()
        {
            //TODO
            return null;
        }

        public int create(Message message)
        {
            //TODO
            return 0;
        }

        private Message toMessage(IDataRecord result)
        {
            //TODO
            return null;
        }
    }
}
