using Npgsql;
using server.connection;

namespace server.chat
{
    internal class ChatTable : ConnectionProvider
    {
        NpgsqlCommand command;
        public ChatTable() : base() { }

        public List<Chat> getAll()
        {
            //TODO
            return null;
        }

        public Chat getById(int id)
        {
            //TODO
            return null;
        }

        public int create(Chat chat)
        {
            //TODO
            return 0;
        }

    }
}
