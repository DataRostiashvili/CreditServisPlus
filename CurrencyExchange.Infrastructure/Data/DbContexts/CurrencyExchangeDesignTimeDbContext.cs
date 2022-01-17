using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Data.DbContexts
{
   
    public class CurrencyExchangeDesignTimeDbContext : IDesignTimeDbContextFactory<DbContexts.CurrencyExchangeDbContext>
    {
        public CurrencyExchangeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CurrencyExchangeDbContext>();
            

            optionsBuilder.UseSqlServer("Server=localhost;Database=ExchangeDatabase;User Id=SA;Password=yourStrong(!)Password;");

            return new CurrencyExchangeDbContext(optionsBuilder.Options);
        }
    }
}
