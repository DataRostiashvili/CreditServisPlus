using AutoMapper;
using CurrencyExchange.Domain.interfaces;
using CurrencyExchange.Infrastructure.Services;
using CurrencyExchange.Models;
using CurrencyExchange.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Net;

namespace CurrencyExchange.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICurrencyExchanger _currencyExchanger;
        private readonly ICurrencyHistory _currencyHistory;


        public HomeController(
            ILogger<HomeController> logger,
             ICurrencyExchanger currencyExchanger,
             ICurrencyHistory currencyHistory
            )
        {
            _logger = logger;
            _currencyExchanger = currencyExchanger;
            _currencyHistory = currencyHistory;
        }


        public async Task<IActionResult> Index(ExchangeRequestViewModel request)
        {
            ViewBag.Currencies = new SelectList(Enum.GetNames(typeof(Currency))
                .Select(c => new SelectListItem { Text = c, Value = c }), "Value", "Text");

            if (!((request.OriginCurrency == Currency.GEL || request.DestinationCurrency == Currency.GEL)
                && (request.OriginCurrency != request.DestinationCurrency)))
                ModelState.AddModelError("OriginCurrency", "one of the currency should be GEL, but not both");

            if (ModelState.IsValid)
            {
                if(!_currencyHistory.IsTodaysCurrencyFetched)
                    await _currencyHistory.AddTodaysCurrencyRate(await _currencyExchanger.GetExchangeRateAsync());

                var exchanged = 0m;
                try
                {
                    exchanged = await _currencyExchanger.ExchangeAsync(request.OriginCurrency, request.DestinationCurrency, request.Amount);
                }
                catch (WebException ex) // i.e Network failure
                {
                    exchanged = await _currencyExchanger.ExchangeAsync(request.OriginCurrency, request.DestinationCurrency, request.Amount,
                        _currencyHistory.GetNearestCurrencyRate());
                }
                ViewBag.exchanged = exchanged;

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