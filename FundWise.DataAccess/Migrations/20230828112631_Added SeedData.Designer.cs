﻿// <auto-generated />
using System;
using FundWise.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FundWise.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230828112631_Added SeedData")]
    partial class AddedSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FundWise.Domain.Entities.Asset", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("MarketValue")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("PortfolioId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("RiskLevel")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("FundWise.Domain.Entities.FinancialData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("ExchangeRate")
                        .HasColumnType("numeric");

                    b.Property<decimal>("InterestRate")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("StockIndex")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("FinancialInformation");
                });

            modelBuilder.Entity("FundWise.Domain.Entities.InvestmentStrategy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("MinExpectedReturn")
                        .HasColumnType("numeric");

                    b.Property<int>("MinRiskLevel")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("InvestmentStrategies");
                });

            modelBuilder.Entity("FundWise.Domain.Entities.Portfolio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("FundWise.Domain.Entities.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Action")
                        .HasColumnType("integer");

                    b.Property<long>("AssetId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("FundWise.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 10L,
                            CreateAt = new DateTime(2023, 8, 28, 11, 26, 31, 719, DateTimeKind.Utc).AddTicks(2034),
                            DateOfBirth = new DateTime(1990, 5, 14, 19, 0, 0, 0, DateTimeKind.Utc),
                            Email = "johndoe@example.com",
                            FirstName = "John",
                            IsDeleted = false,
                            LastName = "Doe",
                            Password = "password",
                            Phone = "123-456-7890",
                            Role = 3
                        },
                        new
                        {
                            Id = 20L,
                            CreateAt = new DateTime(2023, 8, 28, 11, 26, 31, 719, DateTimeKind.Utc).AddTicks(2083),
                            DateOfBirth = new DateTime(1985, 10, 24, 19, 0, 0, 0, DateTimeKind.Utc),
                            Email = "emilysmith@example.com",
                            FirstName = "Emily",
                            IsDeleted = false,
                            LastName = "Smith",
                            Password = "password",
                            Phone = "987-654-3210",
                            Role = 3
                        },
                        new
                        {
                            Id = 30L,
                            CreateAt = new DateTime(2023, 8, 28, 11, 26, 31, 719, DateTimeKind.Utc).AddTicks(2087),
                            DateOfBirth = new DateTime(1978, 3, 7, 19, 0, 0, 0, DateTimeKind.Utc),
                            Email = "michaeljohnson@example.com",
                            FirstName = "Michael",
                            IsDeleted = false,
                            LastName = "Johnson",
                            Password = "password",
                            Phone = "555-123-4567",
                            Role = 1
                        },
                        new
                        {
                            Id = 40L,
                            CreateAt = new DateTime(2023, 8, 28, 11, 26, 31, 719, DateTimeKind.Utc).AddTicks(2090),
                            DateOfBirth = new DateTime(1995, 7, 11, 19, 0, 0, 0, DateTimeKind.Utc),
                            Email = "jessicawilliams@example.com",
                            FirstName = "Jessica",
                            IsDeleted = false,
                            LastName = "Williams",
                            Password = "password",
                            Phone = "111-222-3333",
                            Role = 3
                        },
                        new
                        {
                            Id = 50L,
                            CreateAt = new DateTime(2023, 8, 28, 11, 26, 31, 719, DateTimeKind.Utc).AddTicks(2092),
                            DateOfBirth = new DateTime(1992, 9, 9, 19, 0, 0, 0, DateTimeKind.Utc),
                            Email = "sanjar@example.com",
                            FirstName = "Sanjar",
                            IsDeleted = false,
                            LastName = "Tursunov",
                            Password = "password",
                            Phone = "998-91-234-56-78",
                            Role = 3
                        },
                        new
                        {
                            Id = 60L,
                            CreateAt = new DateTime(2023, 8, 28, 11, 26, 31, 719, DateTimeKind.Utc).AddTicks(2095),
                            DateOfBirth = new DateTime(1992, 9, 9, 19, 0, 0, 0, DateTimeKind.Utc),
                            Email = "sanjar@example.com",
                            FirstName = "Sanjar",
                            IsDeleted = false,
                            LastName = "Tursunov",
                            Password = "password",
                            Phone = "998-91-234-56-78",
                            Role = 3
                        },
                        new
                        {
                            Id = 70L,
                            CreateAt = new DateTime(2023, 8, 28, 11, 26, 31, 719, DateTimeKind.Utc).AddTicks(2097),
                            DateOfBirth = new DateTime(1993, 4, 4, 19, 0, 0, 0, DateTimeKind.Utc),
                            Email = "umid@example.com",
                            FirstName = "Umid",
                            IsDeleted = false,
                            LastName = "Ismoilov",
                            Password = "password",
                            Phone = "998-93-456-78-90",
                            Role = 3
                        },
                        new
                        {
                            Id = 80L,
                            CreateAt = new DateTime(2023, 8, 28, 11, 26, 31, 719, DateTimeKind.Utc).AddTicks(2099),
                            DateOfBirth = new DateTime(1991, 11, 14, 19, 0, 0, 0, DateTimeKind.Utc),
                            Email = "nodir@example.com",
                            FirstName = "Nodir",
                            IsDeleted = false,
                            LastName = "Nazarov",
                            Password = "password",
                            Phone = "998-94-567-89-01",
                            Role = 3
                        });
                });

            modelBuilder.Entity("FundWise.Domain.Entities.Asset", b =>
                {
                    b.HasOne("FundWise.Domain.Entities.Portfolio", "Portfolio")
                        .WithMany("Assets")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("FundWise.Domain.Entities.Portfolio", b =>
                {
                    b.HasOne("FundWise.Domain.Entities.User", "User")
                        .WithMany("Portfolios")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FundWise.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("FundWise.Domain.Entities.Asset", "Asset")
                        .WithMany("Transactions")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");
                });

            modelBuilder.Entity("FundWise.Domain.Entities.Asset", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("FundWise.Domain.Entities.Portfolio", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("FundWise.Domain.Entities.User", b =>
                {
                    b.Navigation("Portfolios");
                });
#pragma warning restore 612, 618
        }
    }
}
