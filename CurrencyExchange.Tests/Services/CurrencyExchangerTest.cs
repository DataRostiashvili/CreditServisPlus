using CurrencyExchange.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CurrencyExchange.Tests.Services
{
    public class CurrencyExchangerTest
    {

        [Fact]
        public async Task should_return_valid_result()
        {
            var exchanger = new CurrencyExchanger();
            var rates = await exchanger.GetExchangeRateAsync();
           
            Assert.IsType<decimal>(rates.EUR);
        }
    }
}
