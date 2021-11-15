using ChatEntities.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.client
{
    internal class RequestMaker
    {
        Client client;
        Response received;
        User user;
        Chat chat;
        List<Chat> chatList;
        List<Message> messages;

        /*public RequestMaker()
        {
            client = new Client();
            client.Connect();
            client.Connect();
            client.Send(new Request(0));
            client.Send(new Request(1, "nacho"));
            client.Send(new Request(2, "jose"));
            client.Send(new Request(3));
            client.Send(new Request(4, 1));
            client.Send(new Request(5, 1, 1, "nacho", "hola don pepito x2"));
            client.Send(new Request(8, 1, 1));
            client.Send(new Request(7, 1, 1));
            client.Send(new Request(6));

           
            Ping();
            user = GetUser("nacho");
            user = CreateUser("jose");
            chatList = GetAllChats();
            chat = ConnectToChat(1);
            messages = GetAllMessages();
            SendMessage("probando probando");
            DisconnectToChat();
            Disconnect();
           
        }
        
        public void Ping()
        {
            received = client.Send(new Request(0));
            if (received is string)
                Console.WriteLine((string)received);
        }

        public void CreateUser(string username)
        {
            do
            {
                received = client.Send(new Request(1, username));
            } while (!(received is User));

            user = (User)received;
            Console.WriteLine(user.ToString());
            return user;
        }

        public void GetUser(string username)
        {
            do
            {
                received = client.Send(new Request(2, username));
            } while (!(received is User));

            user = (User)received;
            Console.WriteLine(user.ToString());
            return user;
        }

        public void GetAllChats()
        {
            received = client.Send(new Request(3));
            if (received is List<Chat>)
                chatList = (List<Chat>)received;

            Console.WriteLine(chatList.ToString());
            return chatList;
        }

        public void GetAllMessages()
        {
            received = client.Send(new Request(4, chat.GetId()));
            if (received is List<Message>)
                messages = (List<Message>)received;

            Console.WriteLine(messages.ToString());
            return messages;
        }

        public void SendMessage(string msg)
        {
            received = client.Send(new Request(5, user.GetId(), chat.GetId(), user.GetName(), msg));
            if (received is int)
                Console.WriteLine((int)received);
        }

        public void ConnectToChat(int chatId)
        {
            received = client.Send(new Request(8, chatId, user.GetId()));
            if (received is Chat) chat = (Chat)received;

            Console.WriteLine(chat.ToString());
            return chat;
        }

        public void DisconnectToChat()
        {
            string res;
            received = client.Send(new Request(7, chat.GetId(), user.GetId()));
            chat = null;
            if (received is string)
                Console.WriteLine((string)received);
        }

        public void Disconnect()
        {
            received = client.Send(new Request(6));
            user = null;
            client.Disconnect();
        }*/
    }
}
