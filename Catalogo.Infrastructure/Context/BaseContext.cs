using Microsoft.EntityFrameworkCore;
using Catalogo.Domain.Entities;
using System.Reflection;

namespace Catalogo.Infrastructure
{
    public class BaseContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Cidade> Cidades { get; set; }

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(fk => fk.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
