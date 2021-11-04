/*
using server.chat;
using server.message;
using server.user;

// getAll users and getById from DB
UserTable userT = new UserTable();
List<User> listUser = userT.getAll();
listUser.ForEach(x => Console.WriteLine(x.ToString()));
Console.WriteLine(userT.getById(1).ToString());

// getAll chats and getById from DB
ChatTable chatT = new ChatTable();
List<Chat> listChat = chatT.getAll();
listChat.ForEach(x => Console.WriteLine(x.ToString()));
Console.WriteLine(chatT.getById(1).ToString());

// getMessages by Chat ID and create from DB
MessageTable messageT = new MessageTable();

//messageT.create(new Message(2, listUser[0].getId(), "hola don pepito"));
//messageT.create(new Message(2, listUser[1].getId(), "hola don jose"));
//messageT.create(new Message(2, listUser[0].getId(), "paso uds ya por casa?"));
//messageT.create(new Message(2, listUser[1].getId(), "por su casa yo pase"));

List<Message> listMessage = messageT.getByChat(2);
listMessage.ForEach(x => Console.WriteLine(x.ToString()));
*/

using server.server;

ChatProtocol server = new ChatProtocol();
server.escucha();