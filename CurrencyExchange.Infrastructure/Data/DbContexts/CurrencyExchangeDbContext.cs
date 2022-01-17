using CurrencyExchange.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Data.DbContexts
{
    public class CurrencyExchangeDbContext : DbContext
    {
        public DbSet<ExchangeRateEntity> ExchangeHistory { get; set; }


        public CurrencyExchangeDbContext(DbContextOptions options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ExchangeRateEntity>().ToTable("exchange_rate");

            //seed data
           
            builder.Entity<ExchangeRateEntity>()
                .HasData(new[]
                {
                    new ExchangeRateEntity
                    {
                        Date = DateOnly.FromDateTime( DateTime.Now.AddDays(-1)),
                        EUR = 3.5m,
                        GBP = 3.9m,
                        RUB = 0.12m,
                        USD = 3.0m
                    },
                    new ExchangeRateEntity
                    {
                        Date = DateOnly.FromDateTime( DateTime.Now.AddDays(-2)),
                        EUR = 3.1m,
                        GBP = 3.39m,
                        RUB = 0.512m,
                        USD = 3.70m
                    },
                    new ExchangeRateEntity
                    {
                        Date = DateOnly.FromDateTime( DateTime.Now.AddDays(-3)),
                        EUR = 3.35m,
                        GBP = 3.19m,
                        RUB = 0.312m,
                        USD = 3.40m
                    }
                });
        }
    }
}
