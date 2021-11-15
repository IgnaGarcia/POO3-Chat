using ChatEntities.entities;
using ChatEntities.serializer;
using ChatServer.orm;
using System.Net.Sockets;

namespace ChatServer.server
{
    public class RequestResolver
    {
        private Response response;
        private Request request;
        public void Resolve(Socket client, Request received)
        {
            request = received;
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

            response = new Response(0, "server is listening");
            client.Send(Serializate(response));
        }

        private void ResolveGetUserByName(Socket client, string username)
        {
            Console.WriteLine("\t- getUserByName = "+username);
            User? user = new UserTable().GetByName(username);

            string status = user != null? "succes: user founded" : "error: user not found";
            response = new Response(1, status, user);
            client.Send(Serializate(response));
        }

        private void ResolveCreateUser(Socket client, string username)
        {
            Console.WriteLine("\t- createUser = "+username);
            int created = new UserTable().Create(new User(username));

            string status = created == 1 ? "succes: user created" : "error: user not created";
            response = new Response(2, status);
            client.Send(Serializate(response));
        }

        private void ResolveGetAllChats(Socket client)
        {
            Console.WriteLine("\t- getChatList");

            response = new Response(3, "succes: chat list retrieved", new ChatTable().GetAll());
            client.Send(Serializate(response));
        }

        private void ResolveGetMessagesByChat(Socket client, int chatId)
        {
            Console.WriteLine("\t- getMessagesByChat = "+chatId);

            response = new Response(4, "succes: message list retrieved", new MessageTable().GetByChat(chatId));
            client.Send(Serializate(response));
        }

        private void ResolveSendMessage(Socket client, Request request)
        {
            Console.WriteLine("\t- sendMessage");
            int chatId = request.chatId;
            int userId = request.userId;
            string username = request.username;
            string message = request.message;
            Message msg = new Message(chatId, userId, username, message);

            int created = new MessageTable().Create(msg);

            string status = created == 1 ? "succes: message created" : "error: message not sent";
            response = new Response(5, status);
            client.Send(Serializate(response));
            /*
            if (created == 1)
            {
                foreach (var item in ChatProtocol.GetInstance().usersInChats[chatId])
                {
                    response = new Response(5, status, msg);
                    item.Value.Send(Serializate(response));
                }
            }
            */
        }

        private void ResolveExit(Socket client)
        {
            Console.WriteLine("\t- exit");
            client.Close();
        }

        private void ResolveExitFromChat(Socket client, int chatId, int userId)
        {
            Console.WriteLine("\t-"+userId+" exitFromChat "+chatId);
            User? user = null;

            /*
            foreach (var item in ChatProtocol.GetInstance().usersInChats[chatId])
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
            } 
            */

            string status = user == null ? "succes: disconnected from chat" : "error: user not found";
            response = new Response(7, status);
            client.Send(Serializate(response));
        }

        private void ResolveConnectToChat(Socket client, int chatId, int userId)
        {
            Console.WriteLine("\t-"+userId+" connectToChat = "+chatId);
            User? user = new UserTable().GetById(userId);

            /*
            if(user != null)
            {
                ChatProtocol.GetInstance().usersInChats[chatId].Add(user, client);
            } 
            */

            string status = user == null ? "succes: connected to chat" : "error: user not found";
            response = new Response(8, status);
            client.Send(Serializate(response));
        }

        private void ResolveDefault(Socket client)
        {
            Console.WriteLine("\t- error: invalid request");

            response = new Response(0, "error: invalid request");
            client.Send(Serializate(response));
        }

        private byte[] Serializate(object obj)
        {
            return BinarySerialization.Serializate(obj);
        }
    }
}
