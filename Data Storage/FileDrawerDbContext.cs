using System;
using System.IO;
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using File = Core.Entities.File;

namespace DataStorage
{
    public class FileDrawerDbContext : DbContext
    {
        public DbSet<Drawer> Drawers { get; set; }
        public DbSet<File> Files { get; set; }
        public string DbPath { get; set; }

        public FileDrawerDbContext()
        {
            var folder = Directory.GetCurrentDirectory();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName = FileDrawerDatabase", option =>
            {
                option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drawer>().ToTable("Drawers", "test");
            modelBuilder.Entity<Drawer>(entity =>
            {
                entity.HasKey(drawer => drawer.Id);
                entity.HasIndex(drawer => drawer.Name);
            });
            modelBuilder.Entity<File>().ToTable("Files", "test");
            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(file => file.Id);
                entity.HasIndex(file => file.Name);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}