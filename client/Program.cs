using client;

Client client = new Client();
client.connect();

client.send("000");
Console.WriteLine(client.receive());

client.send("001");
Console.WriteLine(client.receive());

client.send("002");
Console.WriteLine(client.receive());

client.send("003");
Console.WriteLine(client.receive());

client.send("004");
Console.WriteLine(client.receive());

client.send("005");
Console.WriteLine(client.receive());

client.send("006");