using client;
using client.entities;
using server.message;

internal class Program
{
    static Client client;
    static object received;
    static User user;
    static Chat chat;
    static List<Chat> chatList;
    static List<Message> messages;

    public Program() { }

    static void Main(string[] args)
    {
        client = new Client();
        client.Connect();

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

    private static void Ping()
    {
        received = client.Send(new Request(0));
        if (received is string) 
            Console.WriteLine((string)received);
    }

    private static User CreateUser(string username)
    {
        do
        {
            received = client.Send(new Request(1, username));
        } while (!(received is User));

        user = (User)received;
        Console.WriteLine(user.ToString());
        return user;
    }

    private static User GetUser(string username)
    {
        do
        {
            received = client.Send(new Request(2, username));
        } while (!(received is User));

        user = (User)received;
        Console.WriteLine(user.ToString());
        return user;
    }

    private static List<Chat> GetAllChats()
    {
        received = client.Send(new Request(3));
        if(received is List<Chat>) 
            chatList = (List<Chat>)received;

        Console.WriteLine(chatList.ToString());
        return chatList;
    }

    private static List<Message> GetAllMessages()
    {
        received = client.Send(new Request(4, chat.GetId()));
        if (received is List<Message>)
            messages = (List<Message>)received;

        Console.WriteLine(messages.ToString());
        return messages;
    }

    private static void SendMessage(string msg)
    {
        received = client.Send(new Request(5, user.GetId(), chat.GetId(), user.GetName(), msg));
        if(received is int)
            Console.WriteLine((int) received);
    }

    private static Chat ConnectToChat(int chatId)
    {
        received = client.Send(new Request(8, chatId, user.GetId()));
        if(received is Chat) chat = (Chat) received;

        Console.WriteLine(chat.ToString());
        return chat;
    }

    private static void DisconnectToChat()
    {
        string res;
        received = client.Send(new Request(7, chat.GetId(), user.GetId()));
        chat = null;
        if (received is string) 
            Console.WriteLine((string)received);
    }

    private static void Disconnect()
    {
        received = client.Send(new Request(6));
        user = null;
        if(received is string)
            Console.WriteLine((string)received);
        client.Disconnect();
    }
}