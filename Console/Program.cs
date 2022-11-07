using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFramework.Triggers;

namespace Example {
	public class Program {
		public abstract class Trackable {
			public virtual DateTime Inserted { get; private set; }
			public virtual DateTime Updated { get; private set; }

			static Trackable() {
				Triggers<Trackable>.Inserting += entry => entry.Entity.Inserted = entry.Entity.Updated = DateTime.UtcNow;
				Triggers<Trackable>.Updating += entry => entry.Entity.Updated = DateTime.UtcNow;
			}
		}

		public abstract class SoftDeletable : Trackable {
			public virtual DateTime? Deleted { get; private set; }

			public Boolean IsSoftDeleted => Deleted != null;
			public void SoftDelete() => Deleted = DateTime.UtcNow;
			public void SoftRestore() => Deleted = null;

			static SoftDeletable() {
				Triggers<SoftDeletable>.Deleting += entry => {
					entry.Entity.SoftDelete();
					entry.Cancel = true; // Cancels the deletion, but will persist changes with the same effects as EntityState.Modified
				};
			}
		}

		public class Person : SoftDeletable {
			public virtual Int64 Id { get; private set; }
			public virtual String FirstName { get; set; }
			public virtual String LastName { get; set; }
		}

		public class LogEntry {
			public virtual Int64 Id { get; private set; }
			public virtual String Message { get; set; }
		}

		public class Context : DbContextWithTriggers {
			public virtual DbSet<Person> People { get; set; }
			public virtual DbSet<LogEntry> Log { get; set; }
		}
		internal sealed class Configuration : DbMigrationsConfiguration<Context> {
			public Configuration() {
				AutomaticMigrationsEnabled = true;
			}
		}

		static Program() {
			Triggers<Person, Context>.Inserting += e => {
				e.Context.Log.Add(new LogEntry { Message = "Insert trigger fired for " + e.Entity.FirstName });
				Console.WriteLine("Inserting " + e.Entity.FirstName);
			};
			Triggers<Person>.Updating += e => Console.WriteLine($"Updating {e.Original.FirstName} to {e.Entity.FirstName}");
			Triggers<Person>.Deleting += e => Console.WriteLine("Deleting " + e.Entity.FirstName);
			Triggers<Person>.Inserted += e => Console.WriteLine("Inserted " + e.Entity.FirstName);
			Triggers<Person>.Updated += e => Console.WriteLine("Updated " + e.Entity.FirstName);
			Triggers<Person>.Deleted += e => Console.WriteLine("Deleted " + e.Entity.FirstName);
		}
		
		private static void Main(String[] args) => Task.WaitAll(MainAsync(args));

		private static async Task MainAsync(String[] args) {
			using (var context = new Context()) {
				context.Database.Delete();
				context.Database.Create();

				var log = context.Log.ToList();
				var nickStrupat = new Person {
					FirstName = "Nick",
					LastName = "Strupat"
				};

				context.People.Add(nickStrupat);
				await context.SaveChangesAsync();

				nickStrupat.FirstName = "Nicholas";
				context.SaveChanges();
				context.People.Remove(nickStrupat);
				await context.SaveChangesAsync();
			}
		}
	}
}