using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Domain.DTO
{
    public class ExchangeRateDTO
    {
        public DateTime Date { get; set; }

        public decimal USD { get; set; }
        public decimal EUR { get; set; }
        public decimal GBP { get; set; }
        public decimal RUB { get; set; }
    }
}
