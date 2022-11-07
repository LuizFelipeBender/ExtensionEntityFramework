using System;
using EntityFrameworkCore.Triggers;

namespace PetshopAPI.Models.Entities
{
    public abstract class Trackable {
	public DateTime Inserted { get; private set; }
	public DateTime Updated { get; private set; }

	static Trackable() {
		Triggers<Trackable>.Inserting += entry => entry.Entity.Inserted = entry.Entity.Updated = DateTime.UtcNow;
		Triggers<Trackable>.Updating += entry => entry.Entity.Updated = DateTime.UtcNow;
	}
}
public class Person : Trackable {
	public int Id { get; private set; }
	public String Name { get; set; } = "Administrator";
}
    public class Base: Person
    {
        
    }

	
}
