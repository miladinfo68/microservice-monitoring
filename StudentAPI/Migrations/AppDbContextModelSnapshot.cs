﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace StudentAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("StdCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Student");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mahdi",
                            LastName = "Jalali",
                            StdCode = "st-1000"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Milad",
                            LastName = "Jalali",
                            StdCode = "st-1001"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Kamran",
                            LastName = "Jalalian",
                            StdCode = "st-1002"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "John",
                            LastName = "Doe",
                            StdCode = "st-1003"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ahmad",
                            LastName = "Rafei",
                            StdCode = "st-1004"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Zahra",
                            LastName = "Kazemi",
                            StdCode = "st-1005"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Tara",
                            LastName = "Abadi",
                            StdCode = "st-1006"
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Sajedeh",
                            LastName = "Alaverdi",
                            StdCode = "st-1007"
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Fatemeh",
                            LastName = "Shamaghdari",
                            StdCode = "st-1008"
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Tamim",
                            LastName = "Golnoush",
                            StdCode = "st-1009"
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Behnoosh",
                            LastName = "Bahiraei",
                            StdCode = "st-1010"
                        },
                        new
                        {
                            Id = 12,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Farnoosh",
                            LastName = "Kameli",
                            StdCode = "st-1011"
                        },
                        new
                        {
                            Id = 13,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Payam",
                            LastName = "Norouzi",
                            StdCode = "st-1012"
                        },
                        new
                        {
                            Id = 14,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Iman",
                            LastName = "Ghiasi",
                            StdCode = "st-1013"
                        },
                        new
                        {
                            Id = 15,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Hadi",
                            LastName = "ebrahimi",
                            StdCode = "st-1014"
                        },
                        new
                        {
                            Id = 16,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Reza",
                            LastName = "azimi",
                            StdCode = "st-1015"
                        },
                        new
                        {
                            Id = 17,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Akbar",
                            LastName = "Ghaneh",
                            StdCode = "st-1016"
                        },
                        new
                        {
                            Id = 18,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Saeid",
                            LastName = "Piriaei",
                            StdCode = "st-1017"
                        },
                        new
                        {
                            Id = 19,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Delaram",
                            LastName = "Hemati",
                            StdCode = "st-1018"
                        },
                        new
                        {
                            Id = 20,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Farzaneh",
                            LastName = "Teimouri",
                            StdCode = "st-1019"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
