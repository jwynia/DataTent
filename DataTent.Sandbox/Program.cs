using Bogus;
using DataTent;
using DataTent.Sandbox;

var dataStore = new DataStore("data");
var userCollection = dataStore.GetCollection<User>();
var faker = new Faker<User>();
faker.RuleFor(u=>u.FirstName,(f,u)=>f.Person.FirstName);
faker.RuleFor(u=>u.LastName,(f,u)=>f.Person.LastName);
faker.RuleFor(u=>u.City,(f,u)=>f.Address.City());
faker.RuleFor(u=>u.Id,(f,u)=>Guid.NewGuid());
var users = faker.Generate(1000);
foreach (var user in users)
{
     userCollection.InsertOne(user,user.Id.ToString());
}

// Console.WriteLine(userCollection.Count);
// var usersWithLongNames = userCollection.AsQueryable().Where(u => u.FirstName.Length > 5);
// foreach (var user in usersWithLongNames)
// {
//     Console.WriteLine($"{user.FirstName}");
// }

Console.WriteLine(userCollection.Count);
var randomToDelete = userCollection.AsQueryable().OrderBy(x => Guid.NewGuid()).Take(10);
foreach (var delete in randomToDelete)
{
     userCollection.DeleteOne(delete.Id.ToString());
}
userCollection.Reload();

Console.WriteLine(userCollection.Count);

Console.WriteLine("Press ENTER to quit");
Console.ReadLine();
