using server.chat;
using server.message;
using server.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.server
{
    public class RequestResolver
    {
        /*
                                code(3)
        ping:                   000
        get user by nombre:     001 - namelength(2) - name(30)
        create user:            002 - name(30)
        get chat list:          003
        get messages by chat:   004 - cid(5)
        send messsge in chat:   005 - uid(4) - cid(5) - message 

        str.PadLeft(n, '')
         */
        public static byte[] resolve(byte[] buffer)
        {
            string request = Encoding.ASCII.GetString(buffer);
            string response = processRequest(request);
            return Encoding.ASCII.GetBytes(response);
        }

        private static string processRequest(string request)
        {
            Console.WriteLine(request);
            string code = request.Substring(0, 3);

            if (String.Equals(code, "000"))
            {
                Console.WriteLine("\t- Ping");
                
                return "pinged";
            } 
            else if (code.Equals("001"))
            {
                Console.WriteLine("\t- getUserByName");
                string uname = "nacho";
                User user = new UserTable().getByName(uname);
                
                if (user != null) return user.ToString();
                else return "usuario no encontrado, prueba creandote uno";
            } 
            else if (code.Equals("002"))
            {
                Console.WriteLine("\t- createUser");
                string uname = "pepito";
                int status = new UserTable().create(new User(uname));
                
                if (status == 1) return "usuario creado";
                else return "error al crear el usuario";
            } 
            else if (code.Equals("003"))
            {
                Console.WriteLine("\t- getChatList");
                return new ChatTable().getAll().ToString();
            } 
            else if (code.Equals("004"))
            {
                Console.WriteLine("\t- getMessagesByChat");
                int chatCode = 0;
                return new MessageTable().getByChat(chatCode).ToString();
            } 
            else if (code.Equals("005"))
            {
                Console.WriteLine("\t- sendMessage");
                int chat = 1;
                int from = 1;
                string msg = "la dedon pepito otra vez";

                int status = new MessageTable().create(new Message(chat, from, msg));
                if (status == 1) return "mensaje creado";
                else return "error al crear un mensaje";
            }
            else if (code.Equals("006"))
            {
                Console.WriteLine("\t- exit");
                return null;
            }
            else
            {
                Console.WriteLine("codigo invalido");
                return "codigo invalido";
            }
            
            return "respuesta";
        }
    }
}
