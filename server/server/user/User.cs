namespace server.user
{
    internal class User
    {
        private int? id;
        private string name;

        public User(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public User(string name)
        {
            this.id = null;
            this.name = name;
        }

        public string ToString()
        {
            return "User(id=" + id + "; name=" + name + ");";
        }

        public string getName() { return name; }

        public int getId() { return (int)id; }
    }
}
