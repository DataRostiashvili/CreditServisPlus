using CurrencyExchange.Infrastructure.Services;
using CurrencyExchange.Models;
using CurrencyExchange.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace CurrencyExchange.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICurrencyExchanger _currencyExchanger;

        public HomeController(ILogger<HomeController> logger,
             ICurrencyExchanger currencyExchanger)
        {
            _logger = logger;
            _currencyExchanger = currencyExchanger;
        }

        //public IActionResult Index()
        //{
        //    ViewBag.Currencies = new SelectList(Enum.GetNames(typeof(Currency))
        //        .Select(c => new SelectListItem { Text = c, Value = c }), "Value", "Text");
        //    return View();
        //}

        public IActionResult Index(ExchangeRequestViewModel request)
        {
            ViewBag.Currencies = new SelectList(Enum.GetNames(typeof(Currency))
                .Select(c => new SelectListItem { Text = c, Value = c }), "Value", "Text");

            if (!((request.OriginCurrency == Currency.GEL || request.DestinationCurrency == Currency.GEL)
                && (request.OriginCurrency != request.DestinationCurrency)))
                  ModelState.AddModelError("OriginCurrency", "one of the currency should be GEL, but not both");

            if (ModelState.IsValid)
            {
                _currencyExchanger.E
            }
            


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}