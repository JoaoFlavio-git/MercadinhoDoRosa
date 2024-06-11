using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiDoMercadinho.Models;

namespace ApiDoMercadinho.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Mercado> Mercadinho { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mercado>()
                .Property(props => props.Nome)
                .HasMaxLength(80);

            modelBuilder.Entity<Mercado>()
                .Property(props => props.Preco)
                .HasPrecision(10, 2);
        }
    }
}
