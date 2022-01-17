using CurrencyExchange.Domain.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Services
{
    public class CurrencyExchanger
    {
        readonly Uri _currencyApi = new("https://nbg.gov.ge/gw/api/ct/monetarypolicy/currencies/ka/json");
        readonly HttpClient _httpClient = new();


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

                Date = DateOnly.FromDateTime(DateTime.Now)

            };
        }
    }
}
