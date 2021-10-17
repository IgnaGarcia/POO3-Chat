using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.user
{
    internal class User
    {
        private int id;
        private string name;

        public User(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string toString()
        {
            return "User(id=" + id + "; name=" + name + ");";
        }
    }
}
