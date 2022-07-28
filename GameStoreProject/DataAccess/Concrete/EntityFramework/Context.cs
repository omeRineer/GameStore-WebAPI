using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.ModelConfigurations;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-0DGVKL8C;Database=GameStore;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            modelBuilder.Entity<Gamer>().ToTable("Gamers");
            modelBuilder.Entity<Company>().ToTable("Companies");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Gamer> Gamers { get; set; }
        public DbSet<GameImage> GameImages { get; set; }
        public DbSet<ImageCategory> ImageCategories { get; set; }
    }
}
