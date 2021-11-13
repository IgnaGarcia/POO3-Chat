using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.entities
{
    [Serializable]
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

        public string GetName() { return name; }

        public int GetId() { return (int)id; }
    }
}
