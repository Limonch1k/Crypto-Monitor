using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace DataAccessLayer.Model
{
    public class CryptaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Crypta> Cryptas { get; set; }
        public DbSet<ExpectedCost> ExpectedCosts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public CryptaContext(DbContextOptions<CryptaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Server=(localdb)\\mssqllocaldb;Database=Cryptadb;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Crypta>().HasMany(p => p.ExpectedCosts).WithOne(p => p.Crypta);
            modelBuilder.Entity<Crypta>().HasMany(p => p.Orders).WithOne(p => p.Crypta);
            modelBuilder.Entity<User>().HasMany(p => p.Orders).WithOne(p => p.User);
            modelBuilder.Entity<User>().HasMany(p => p.ExpectedCosts).WithOne(p => p.User);
            modelBuilder.Entity<Crypta>().HasData
            (
                new Crypta { Id = 1, Cost = 100, ExpectedCosts = null, Name = "Bitcoin" },
                new Crypta { Id = 2, Cost = 200, ExpectedCosts = null, Name = "Effir" },
                new Crypta { Id = 3, Cost = 300, ExpectedCosts = null, Name = "Doggicoin" }
            );

            modelBuilder.Entity<User>().HasData
            (
                new User {Id = 1, Age = 20, ExpectedCosts = null, Name = "Dima"},
                new User {Id = 2, Age = 20, ExpectedCosts = null, Name = "Danick"}
            );
        }
    }
}
