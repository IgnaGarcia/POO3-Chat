using server.chat;
using server.message;
using server.user;
using System.Net.Sockets;
namespace server.server
{
    public class RequestResolver
    {
        public void Resolve(Socket client, byte[] buffer)
        {
            Request request = (Request) BinarySerialization.Deserializate(buffer);
            Console.WriteLine(request.ToString());
            int code = request.code;

            if (code == 0) { ResolvePing(client); }
            else if (code == 1) { ResolveGetUserByName(client, request.username); }
            else if (code == 2) { ResolveCreateUser(client, request.username); }
            else if (code == 3) { ResolveGetAllChats(client); }
            else if (code == 4) { ResolveGetMessagesByChat(client, request.chatId); }
            else if (code == 5) { ResolveSendMessage(client, request); }
            else if (code == 6) { ResolveExit(client); }
            else if (code == 7) { ResolveExitFromChat(client, request.chatId, request.userId); }
            else if (code == 8) { ResolveConnectToChat(client, request.chatId, request.userId); }
            else { ResolveDefault(client); }
        }

        private void ResolvePing(Socket client)
        {
            Console.WriteLine("\t- Ping");
            client.Send(Serializate("server is listening"));
        }

        private void ResolveGetUserByName(Socket client, string username)
        {
            Console.WriteLine("\t- getUserByName = "+username);
            User user = new UserTable().GetByName(username);
            if (user != null) client.Send(Serializate(user));
            else client.Send(Serializate("error: user not found"));
        }

        private void ResolveCreateUser(Socket client, string username)
        {
            Console.WriteLine("\t- createUser = "+username);
            int status = new UserTable().Create(new User(username));
            if (status == 1) client.Send(Serializate(username));
            else client.Send(Serializate("error: user not created"));
        }

        private void ResolveGetAllChats(Socket client)
        {
            Console.WriteLine("\t- getChatList");
            client.Send(Serializate(new ChatTable().GetAll()));
        }

        private void ResolveGetMessagesByChat(Socket client, int chatId)
        {
            Console.WriteLine("\t- getMessagesByChat = "+chatId);
            client.Send(Serializate(new MessageTable().GetByChat(chatId)));
        }

        private void ResolveSendMessage(Socket client, Request request)
        {
            int chatId = request.chatId;
            int userId = request.userId;
            string username = request.username;
            string message = request.message;
            Message msg = new Message(chatId, userId, username, message);
            Console.WriteLine("\t- sendMessage = "+msg.ToString());

            int status = new MessageTable().Create(msg);

            /*if (status == 1)
            {
                foreach (var item in ChatProtocol.GetInstance().usersInChats[chatId])
                {
                    item.Value.Send(Serializate(msg));
                }
            }
            else client.Send(Serializate("error: message not sent"));*/
        }

        private void ResolveExitFromChat(Socket client, int chatId, int userId)
        {
            Console.WriteLine("\t-"+userId+" exitFromChat "+chatId);
            User? user = null;

            /*foreach (var item in ChatProtocol.GetInstance().usersInChats[chatId])
            {
                if (item.Key.GetId() == userId)
                {
                    user = item.Key;
                    break;
                }
            }
            if (user != null)
            {
                ChatProtocol.GetInstance().usersInChats[chatId].Remove(user);
                client.Send(Serializate("user removed from " + chatId));
            } else
            {
                client.Send(Serializate("error: user not found"));
            }*/
        }

        private void ResolveConnectToChat(Socket client, int chatId, int userId)
        {
            Console.WriteLine("\t-"+userId+" connectToChat = "+chatId);
            User user = new UserTable().GetById(userId);
            /*if(user != null)
            {
                ChatProtocol.GetInstance().usersInChats[chatId].Add(user, client);
                client.Send(Serializate("user added to " + chatId));
            } else
            {
                client.Send(Serializate("error: user not found"));
            }*/
        }

        private void ResolveExit(Socket client)
        {
            Console.WriteLine("\t- exit");
            client.Send(Serializate("bye bye"));
            client.Close();
        }

        private void ResolveDefault(Socket client)
        {
            Console.WriteLine("\t- error: invalid request");
            client.Send(Serializate("error: invalid request"));
        }

        private byte[] Serializate(object obj)
        {
            return BinarySerialization.Serializate(obj);
        }
    }
}
