﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShopWebApi.Data.EntityFramework;

namespace ShopWebApi.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ShopWebApi.Model.Entity.ProductInWarehouse", b =>
                {
                    b.Property<Guid>("Article")
                        .HasColumnType("uuid")
                        .HasColumnName("article");

                    b.Property<string>("ProductInformation")
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Article");

                    b.ToTable("warehouse");
                });

            modelBuilder.Entity("ShopWebApi.Model.Entity.ReservedProduct", b =>
                {
                    b.Property<Guid>("IdOrder")
                        .HasColumnType("uuid")
                        .HasColumnName("id_order");

                    b.Property<string>("ProductName")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReservationTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("IdOrder");

                    b.ToTable("reserved_products");
                });
#pragma warning restore 612, 618
        }
    }
}
