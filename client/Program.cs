using client;

Client client = new Client();
client.Connect();

Console.WriteLine(client.Send(new Request(0)));

Console.WriteLine(client.Send(new Request(1, "nacho")));

Console.WriteLine(client.Send(new Request(2, "datazo")));

Console.WriteLine(client.Send(new Request(3)));

Console.WriteLine(client.Send(new Request(4, 1)));

Console.WriteLine(client.Send(new Request(5, 1, 1, "nacho", "probando probando")));

Console.WriteLine(client.Send(new Request(6)));

Console.WriteLine(client.Send(new Request(8, 1, 1)));

Console.WriteLine(client.Send(new Request(7, 1, 1)));