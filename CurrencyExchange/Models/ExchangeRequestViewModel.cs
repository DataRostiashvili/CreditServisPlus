using CurrencyExchange.Domain.interfaces;
using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Web.Models

{
    public class ExchangeRequestViewModel
    {

        [Required]
        [RegularExpression(@"^\w+[ ]\w+$", ErrorMessage = "field should contain two words")] //match only two words seperated by a space
        public string ClientName { get; set; }
        [Required, RegularExpression(@"\d{11}", ErrorMessage = "field should consist of 11 digits")]
        public string PersonalNumber { get; set; }


        public Currency OriginCurrency {get;set;}
        public Currency DestinationCurrency { get;set;}

        public DateOnly Date { get; set; }
        public decimal Amount { get; set; }
    }

   
}
