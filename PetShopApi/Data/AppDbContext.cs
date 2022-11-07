using PetshopAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using EntityFrameworkCore.Triggers;
using System.Threading;
using System.Threading.Tasks;

namespace PetshopAPI.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<TipoAtendimento> TipoAtendimentos { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Dono> Donos { get; set; }
        public DbSet<DonosPets> DonosPets1 { get; set; }

        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<ProfissionalTipoAtendimento> ProfissionaisTipoAtendimentos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        }

        public override Int32 SaveChanges() {
		return this.SaveChangesWithTriggers(base.SaveChanges, acceptAllChangesOnSuccess: true);
	}
	public override Int32 SaveChanges(Boolean acceptAllChangesOnSuccess) {
		return this.SaveChangesWithTriggers(base.SaveChanges, acceptAllChangesOnSuccess);
	}
	public override Task<Int32> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken)) {
		return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, acceptAllChangesOnSuccess: true, cancellationToken: cancellationToken);
	}
	public override Task<Int32> SaveChangesAsync(Boolean acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken)) {
		return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, acceptAllChangesOnSuccess, cancellationToken);
	
   
    }
    }
    }
    

