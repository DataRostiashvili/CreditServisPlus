using AutoMapper;
using CurrencyExchange.Domain.DTO;
using CurrencyExchange.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Services
{
    public class CurrencyHistory
    {
        readonly CurrencyHistoryRepository _historyRepository;
        readonly IMapper _mapper;


        public CurrencyHistory(CurrencyHistoryRepository historyRepository,
            IMapper mapper)
        {
            _historyRepository = historyRepository;
        }
        public bool IsTodaysCurrencyFetched => 
            GetNearestCurrencyRate().Date.Equals(DateOnly.FromDateTime(DateTime.Now));


        public ExchangeRateDTO GetNearestCurrencyRate()
        {
           var rateEntity = _historyRepository
                .GetByPredicate(rate => true)
                .OrderByDescending(rate => rate.Date)
                .First();

            return _mapper.Map<ExchangeRateDTO>(rateEntity);
        }
    }
}
