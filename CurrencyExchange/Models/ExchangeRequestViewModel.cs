using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Web.Models

{
    public class ExchangeRequestViewModel
    {

        [Required]
        [RegularExpression(@"^\w+[ ]\w+$")] //match only two words seperated by a space
        public string ClientName { get; set; }
        [Required, MaxLength(11), MinLength(11)]
        public string PersonalNumber { get; set; }


        public Currency OriginCurrency {get;set;}
        public Currency DestinationCurrency { get;set;}

        public DateOnly Date { get; set; }
        public decimal Amount { get; set; }
    }

    public enum Currency
    {
        GEL = 1,
        USD,
        EUR,
        RUB,
        GBP
    }
}
