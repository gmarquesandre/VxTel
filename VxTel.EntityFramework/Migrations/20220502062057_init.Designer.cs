﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VxTel.EntityFramework;

#nullable disable

namespace VxTel.EntityFramework.Migrations
{
    [DbContext(typeof(VxTelDbContext))]
    [Migration("20220502062057_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VxTel.Shared.Models.CallPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("ExcedeedTimeFeePercentage")
                        .HasColumnType("float");

                    b.Property<int>("FreeTime")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CallPlans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExcedeedTimeFeePercentage = 0.10000000000000001,
                            FreeTime = 30,
                            Name = "FaleMais 30",
                            Price = 30.0
                        },
                        new
                        {
                            Id = 2,
                            ExcedeedTimeFeePercentage = 0.10000000000000001,
                            FreeTime = 60,
                            Name = "FaleMais 60",
                            Price = 50.0
                        },
                        new
                        {
                            Id = 3,
                            ExcedeedTimeFeePercentage = 0.10000000000000001,
                            FreeTime = 120,
                            Name = "FaleMais 120",
                            Price = 70.0
                        });
                });

            modelBuilder.Entity("VxTel.Shared.Models.CallPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FromDDD")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("PricePerMinute")
                        .HasColumnType("float");

                    b.Property<string>("ToDDD")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FromDDD", "ToDDD")
                        .IsUnique();

                    b.ToTable("CallPrices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FromDDD = "011",
                            PricePerMinute = 1.8999999999999999,
                            ToDDD = "016"
                        },
                        new
                        {
                            Id = 2,
                            FromDDD = "016",
                            PricePerMinute = 2.8999999999999999,
                            ToDDD = "011"
                        },
                        new
                        {
                            Id = 3,
                            FromDDD = "011",
                            PricePerMinute = 1.7,
                            ToDDD = "017"
                        },
                        new
                        {
                            Id = 4,
                            FromDDD = "017",
                            PricePerMinute = 2.7000000000000002,
                            ToDDD = "011"
                        },
                        new
                        {
                            Id = 5,
                            FromDDD = "011",
                            PricePerMinute = 0.90000000000000002,
                            ToDDD = "018"
                        },
                        new
                        {
                            Id = 6,
                            FromDDD = "018",
                            PricePerMinute = 1.8999999999999999,
                            ToDDD = "011"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
