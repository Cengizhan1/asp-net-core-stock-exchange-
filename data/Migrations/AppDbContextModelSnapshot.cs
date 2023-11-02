﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity.Entities.Price", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("close")
                        .HasColumnType("real");

                    b.Property<float>("high")
                        .HasColumnType("real");

                    b.Property<float>("low")
                        .HasColumnType("real");

                    b.Property<float>("open")
                        .HasColumnType("real");

                    b.Property<float>("volume")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("Entity.Entities.Share", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lastUpdate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Shares");
                });
#pragma warning restore 612, 618
        }
    }
}
