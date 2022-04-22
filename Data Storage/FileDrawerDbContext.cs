using System;
using System.IO;
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using File = Core.Entities.File;

namespace DataStorage
{
    public class FileDrawerDbContext : DbContext
    {
        public DbSet<Drawer> Drawers { get; set; }
        public DbSet<File> Files { get; set; }
        public string DbPath { get; set; }

        public FileDrawerDbContext(DbContextOptions<FileDrawerDbContext> options) : base(options)
        {
            
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