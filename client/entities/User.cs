using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.entities
{
    [Serializable]
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

        public string GetName() { return name; }

        public int GetId() { return (int)id; }
    }
}
