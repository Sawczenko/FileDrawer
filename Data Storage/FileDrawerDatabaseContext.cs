using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage
{
    public class FileDrawerDatabaseContext : DbContext
    {
        public DbSet<Drawer> Drawers { get; set; }
        public DbSet<DrawerFile> Files { get; set; }

        public FileDrawerDatabaseContext()
        {

        }
        public FileDrawerDatabaseContext(DbContextOptions<FileDrawerDatabaseContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=FileDrawerDatabase.db");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drawer>().ToTable("Drawers", "Drawers");
            modelBuilder.Entity<Drawer>(entity =>
            {
                entity.HasKey(drawer => drawer.Id);
                entity.HasIndex(drawer => drawer.Name);
            });
            modelBuilder.Entity<DrawerFile>().ToTable("Files", "Files");
            modelBuilder.Entity<DrawerFile>(entity =>
            {
                entity.HasKey(file => file.Id);
                entity.HasIndex(file => file.Name);
            });
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
