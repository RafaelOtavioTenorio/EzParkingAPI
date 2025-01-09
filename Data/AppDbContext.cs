using Microsoft.EntityFrameworkCore;
using ez_parking_api.Models;

namespace ez_parking_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Registro> Registros { get; set; }
        public DbSet<Estacionamento> Estacionamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Veiculo>().ToTable("Veiculos");
            modelBuilder.Entity<Registro>().ToTable("Registros");
            modelBuilder.Entity<Estacionamento>().ToTable("Estacionamentos");
        }

    }
}
