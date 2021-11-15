namespace ChatEntities.entities
{
    [Serializable]
    public class User
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

        override public string ToString()
        {
            return "User(id=" + id + "; name=" + name + ");";
        }

        public string GetName() { return name; }

        public int GetId() => id != null? (int)id : 0;
    }
}
