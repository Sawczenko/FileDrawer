// <auto-generated />
using System;
using DataStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataStorage.Migrations
{
    [DbContext(typeof(FileDrawerDatabaseContext))]
    [Migration("20220505201830_EntitiesUpdate")]
    partial class EntitiesUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("Core.Entities.Drawer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("FileCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Drawers", "Drawers");
                });

            modelBuilder.Entity("Core.Entities.DrawerFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DrawerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.Property<string>("Size")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DrawerId");

                    b.HasIndex("Name");

                    b.ToTable("Files", "Files");
                });

            modelBuilder.Entity("Core.Entities.DrawerFile", b =>
                {
                    b.HasOne("Core.Entities.Drawer", null)
                        .WithMany("FileList")
                        .HasForeignKey("DrawerId");
                });

            modelBuilder.Entity("Core.Entities.Drawer", b =>
                {
                    b.Navigation("FileList");
                });
#pragma warning restore 612, 618
        }
    }
}
