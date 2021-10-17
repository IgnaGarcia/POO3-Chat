using server.user;

UserTable userT = new UserTable();
List<User> list = userT.getAll();
list.ForEach(x => Console.WriteLine(x.toString()));