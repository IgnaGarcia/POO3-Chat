namespace ChatEntities.entities
{
    [Serializable]
    public class Chat
    {
        private int? id;
        private string name;

        public Chat(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Chat(string name)
        {
            this.id = null;
            this.name = name;
        }

        override public string ToString()
        {
            return "Chat(id=" + id + "; name=" + name + ");";
        }

        public string GetName() { return name; }

        public int GetId() => id != null? (int)id : 0;
    }
}
