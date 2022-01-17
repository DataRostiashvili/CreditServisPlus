﻿// <auto-generated />
using System;
using CurrencyExchange.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CurrencyExchange.Infrastructure.Migrations
{
    [DbContext(typeof(CurrencyExchangeDbContext))]
    partial class CurrencyExchangeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CurrencyExchange.Domain.Entity.ExchangeRateEntity", b =>
                {
                    b.Property<int>("ExchangeRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExchangeRateId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("EUR")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GBP")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RUB")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("USD")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ExchangeRateId");

                    b.ToTable("exchange_rate", (string)null);

                    b.HasData(
                        new
                        {
                            ExchangeRateId = -1,
                            Date = new DateTime(2022, 1, 16, 22, 43, 48, 16, DateTimeKind.Local).AddTicks(3600),
                            EUR = 3.5m,
                            GBP = 3.9m,
                            RUB = 0.12m,
                            USD = 3.0m
                        },
                        new
                        {
                            ExchangeRateId = -2,
                            Date = new DateTime(2022, 1, 15, 22, 43, 48, 16, DateTimeKind.Local).AddTicks(3633),
                            EUR = 3.1m,
                            GBP = 3.39m,
                            RUB = 0.512m,
                            USD = 3.70m
                        },
                        new
                        {
                            ExchangeRateId = -3,
                            Date = new DateTime(2022, 1, 14, 22, 43, 48, 16, DateTimeKind.Local).AddTicks(3638),
                            EUR = 3.35m,
                            GBP = 3.19m,
                            RUB = 0.312m,
                            USD = 3.40m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
