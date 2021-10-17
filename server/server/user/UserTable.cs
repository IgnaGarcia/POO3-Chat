using Npgsql;
using server.connection;

namespace server.user
{
    internal class UserTable : ConnectionProvider
    {
        NpgsqlCommand command;
        public UserTable() : base() { }

        public List<User> getAll()
        {
            //TODO
            return null;
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
            //TODO
            return 0;
        }
    }
}
