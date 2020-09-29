using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSushi.Data
{
    public class SuperSushiContext : DbContext
    {
        public DbSet<Gerecht> Gerechten { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGerecht> MenuGerechten { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=SuperSushi;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuGerecht>()
                .HasKey(t => new { t.GerechtId, t.MenuId });

            modelBuilder.Entity<MenuGerecht>()
                .HasOne(pt => pt.Menu)
                .WithMany(p => p.Bevat)
                .HasForeignKey(pt => pt.MenuId);

            modelBuilder.Entity<MenuGerecht>()
                .HasOne(pt => pt.Gerecht)
                .WithMany(t => t.Onderdeelvan)
                .HasForeignKey(pt => pt.GerechtId);
        }
    }
}
