﻿using System;
using System.Threading;
using System.Threading.Tasks;

#if EF_CORE
using Microsoft.EntityFrameworkCore;
namespace EntityFrameworkCore.Triggers
#else
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
namespace EntityFramework.Triggers
#endif
{
	/// <summary>
	/// A <see cref="DbContext"/>-derived class with trigger functionality called automatically
	/// </summary>
	public class DbContextWithTriggers : DbContext
	{
		public Boolean TriggersEnabled { get; set; } = true;

		private readonly IServiceProvider serviceProvider;

		public DbContextWithTriggers() : base() { }
		public DbContextWithTriggers(IServiceProvider serviceProvider) : base() => this.serviceProvider = serviceProvider;

#if EF_CORE
		public DbContextWithTriggers(DbContextOptions options) : base(options) {}

		public DbContextWithTriggers(IServiceProvider serviceProvider, DbContextOptions options) : base(options) => this.serviceProvider = serviceProvider;

		public override Int32 SaveChanges() {
			return TriggersEnabled ? this.SaveChangesWithTriggers(base.SaveChanges, serviceProvider) : base.SaveChanges();
		}
		
		public override Int32 SaveChanges(Boolean acceptAllChangesOnSuccess) {
			return TriggersEnabled ? this.SaveChangesWithTriggers(base.SaveChanges, serviceProvider, acceptAllChangesOnSuccess) : base.SaveChanges(acceptAllChangesOnSuccess);
		}
		
		public override Task<Int32> SaveChangesAsync(CancellationToken cancellationToken = default) {
			return TriggersEnabled ? this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, serviceProvider, cancellationToken) : base.SaveChangesAsync(cancellationToken);
		}
		
		public override Task<Int32> SaveChangesAsync(Boolean acceptAllChangesOnSuccess, CancellationToken cancellationToken = default) {
			return TriggersEnabled ? this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, serviceProvider, acceptAllChangesOnSuccess, cancellationToken) : base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}
#else
        public DbContextWithTriggers(DbCompiledModel model) : base(model) {}
		public DbContextWithTriggers(String nameOrConnectionString) : base(nameOrConnectionString) {}
		public DbContextWithTriggers(DbConnection existingConnection, Boolean contextOwnsConnection) : base(existingConnection, contextOwnsConnection) {}
		public DbContextWithTriggers(ObjectContext objectContext, Boolean dbContextOwnsObjectContext) : base(objectContext, dbContextOwnsObjectContext) {}
		public DbContextWithTriggers(String nameOrConnectionString, DbCompiledModel model) : base(nameOrConnectionString, model) {}
		public DbContextWithTriggers(DbConnection existingConnection, DbCompiledModel model, Boolean contextOwnsConnection) : base(existingConnection, model, contextOwnsConnection) {}

		public DbContextWithTriggers(IServiceProvider serviceProvider, DbCompiledModel model) : base(model) => this.serviceProvider = serviceProvider;
		public DbContextWithTriggers(IServiceProvider serviceProvider, String nameOrConnectionString) : base(nameOrConnectionString) => this.serviceProvider = serviceProvider;
		public DbContextWithTriggers(IServiceProvider serviceProvider, DbConnection existingConnection, Boolean contextOwnsConnection) : base(existingConnection, contextOwnsConnection) => this.serviceProvider = serviceProvider;
		public DbContextWithTriggers(IServiceProvider serviceProvider, ObjectContext objectContext, Boolean dbContextOwnsObjectContext) : base(objectContext, dbContextOwnsObjectContext) => this.serviceProvider = serviceProvider;
		public DbContextWithTriggers(IServiceProvider serviceProvider, String nameOrConnectionString, DbCompiledModel model) : base(nameOrConnectionString, model) => this.serviceProvider = serviceProvider;
		public DbContextWithTriggers(IServiceProvider serviceProvider, DbConnection existingConnection, DbCompiledModel model, Boolean contextOwnsConnection) : base(existingConnection, model, contextOwnsConnection) => this.serviceProvider = serviceProvider;
		
		public override Int32 SaveChanges() {
			return TriggersEnabled ? this.SaveChangesWithTriggers(base.SaveChanges, serviceProvider) : base.SaveChanges();
		}
		public override Task<Int32> SaveChangesAsync(CancellationToken cancellationToken) {
			return TriggersEnabled ? this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, serviceProvider, cancellationToken) : base.SaveChangesAsync(cancellationToken);
		}
#endif
	}
}
