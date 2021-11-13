namespace server.message
{
    [Serializable]
    internal class Message
    {
        private int? id;
        private int chat_id;
        private int from_id;
        private string from_name;
        private string message;
        private DateTime? created_date;

        public Message(int id, int chat_id, int from_id, string from_name, string message, DateTime created_date)
        {
            this.id = id;
            this.chat_id = chat_id;
            this.from_id = from_id;
            this.from_name = from_name;
            this.message = message;
            this.created_date = created_date;
        }

        public Message(int chat_id, int from_id, string from_name, string message)
        {
            this.id = null;
            this.chat_id = chat_id;
            this.from_id = from_id;
            this.from_name = from_name;
            this.message = message;
            this.created_date = null;
        }

        public string ToString()
        {
            return "Message(id=" + id + "; chat=" + chat_id + "; from=(" + from_name + "-" + from_id + "); date=" + created_date + "; message=" + message + ");";
        }

        public int GetChatId() { return chat_id; }
        public int GetFromId() { return from_id; }
        public int GetFromName() { return from_name; }
        public string GetMessage() { return message; }
    }
}
