using CurrencyExchange.Domain.DTO;
using CurrencyExchange.Domain.interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Services
{
    public interface ICurrencyExchanger
    {
        ValueTask<decimal> ExchangeAsync(Currency origin, Currency destination, decimal amount, ExchangeRateDTO prefetchedRate = null);
        Task<ExchangeRateDTO> GetExchangeRateAsync();
    }

    public class CurrencyExchanger : ICurrencyExchanger
    {
        readonly Uri _currencyApi = new("https://nbg.gov.ge/gw/api/ct/monetarypolicy/currencies/ka/json");
        readonly HttpClient _httpClient = new();



        public async ValueTask<decimal> ExchangeAsync(Currency origin, Currency destination, decimal amount, ExchangeRateDTO prefetchedRate = null)
        {
            var exchangeToGEL = async (Currency origin, decimal amount) =>
            {
                var rates = prefetchedRate ?? await GetExchangeRateAsync();
                return origin switch
                {
                    Currency.USD => rates.USD * amount,
                    Currency.EUR => rates.EUR * amount,
                    Currency.RUB => (rates.RUB * amount) / 100,
                    Currency.GBP => rates.GBP * amount,
                };
            };

            var exchangeFromGEL = async (Currency destination, decimal amount) =>
            {
                var rates = prefetchedRate ??  await GetExchangeRateAsync();
                return destination switch
                {
                    Currency.USD => amount / rates.USD,
                    Currency.EUR => amount / rates.EUR,
                    Currency.RUB => (amount / rates.RUB) * 100,
                    Currency.GBP => amount / rates.GBP,
                };
            };
            if(origin == Currency.GEL)
            {
              return  await  exchangeFromGEL(destination, amount);
            } 
            else if(destination == Currency.GEL)
            {
                return await exchangeToGEL(origin, amount);
            }

            throw new ArgumentException();
        }
        public async Task<ExchangeRateDTO> GetExchangeRateAsync()
        {
            var queryExchangeRate = (JArray json, string currencyCode) =>
            {
                return json[0]["currencies"]
                     .Where(currency => currency["code"].Value<string>() == currencyCode)
                     .Select(currency => currency.Value<decimal>("rate"))
                     .Single();
            };

            var rawResult = await _httpClient.GetStringAsync(_currencyApi);
            var jArray = JArray.Parse(rawResult);

            return new ExchangeRateDTO
            {
                EUR = queryExchangeRate(jArray, "EUR"),
                RUB = queryExchangeRate(jArray, "RUB"),
                USD = queryExchangeRate(jArray, "USD"),
                GBP = queryExchangeRate(jArray, "GBP"),

                Date = DateTime.Now

            };
        }
    }
}
