# DataTent
A lightweight/temporary datastore of JSON files in folders. 

It is a tent, not a house, not an office building, and not an industrial warehouse. It's intended for quick prototypes, small projects, projects with a need to quickly store data, but without the overhead of bigger data store approaches.

Many of the features you're already wanting to add to this are an indication you don't want to live in a tent. You want an RV, a house, or something larger with more features. Those are signs it's time to move on to something else. Fortunately, since DataTent is just folders full of JSON files, you can easily take your data with you and migrate to whatever more robust data storage tool you choose. Godspeed.

## To use
dotnet add package DataTent --version 0.1.1

Either inject a IDataStore with DI like:
```
services.AddSingleton<IDataStore>(ds=> new DataStore("data"));
```

or instantiate directly:
```
var dataStore = new DataStore("data");
```

The "data" argument specifies the subfolder under your project that will house the data. A folder for each DocumentCollection will go there.

Then, create a collection based on some basic, serializable data class and use based on example below. Most operations require a unique string id as an argument. That gets used as the filename. I HIGHLY recommend using something that's a property of the object you're storing or you can end up sort of disconnecting your data and being unable to easily update or delete.

```
var userCollection = dataStore.GetCollection<SiteUser>();
var allUsersQueryable = userCollection.AsQueryable();
var activeUsers = allUsersQueryable.Where(u=>u.Active == true);
var inactiveUsers = userCollection.Find(u=>u.Active == false);
var newUserId = Guid.NewGuid();
var newUser = userCollection.Insert(new SiteUser(){ Active = true; Username = "Rusty Shackleford", Id = newUserId }, newUserId.ToString());
userCollection.Delete(newUserId.ToString());
```
