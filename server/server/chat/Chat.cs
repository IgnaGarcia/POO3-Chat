﻿namespace server.chat
{
    internal class Chat
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

        public string ToString()
        {
            return "Chat(id=" + id + "; name=" + name + ");";
        }

    }
}
