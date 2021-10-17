using server.user;

UserTable userT = new UserTable();

List<User> list = userT.getAll();
list.ForEach(x => Console.WriteLine(x.ToString()));

Console.WriteLine(userT.create(new User("dai")));

Console.WriteLine(userT.getById(2).ToString());
Console.WriteLine(userT.getByName("pablin").ToString());
