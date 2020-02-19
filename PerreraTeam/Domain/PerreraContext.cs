using PerreraTeam.Domain.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PerreraTeam.Domain
{
    public class PerreraContext : DbContext
    {
        public PerreraContext() : base("PerreraContext")
        {
        }

        public DbSet<Perros> Perros { get; set; }
        public DbSet<Razas> Razas { get; set; }
        public DbSet<Jaulas> Jaulas { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Personas> Personas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<PerreraTeam.Domain.Models.Adopciones> Adopciones { get; set; }
    }
}