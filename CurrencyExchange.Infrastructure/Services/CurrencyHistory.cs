using AutoMapper;
using CurrencyExchange.Domain.DTO;
using CurrencyExchange.Domain.Entity;
using CurrencyExchange.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Services
{
    public interface ICurrencyHistory
    {
        bool IsTodaysCurrencyFetched { get; }

        Task AddTodaysCurrencyRate(ExchangeRateDTO rate);
        ExchangeRateDTO GetNearestCurrencyRate();
    }

    public class CurrencyHistory : ICurrencyHistory
    {
        readonly ICurrencyHistoryRepository _historyRepository;
        readonly IMapper _mapper;


        public CurrencyHistory(ICurrencyHistoryRepository historyRepository,
            IMapper mapper)
        {
            _historyRepository = historyRepository;
            _mapper = mapper;
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

        public async Task AddTodaysCurrencyRate(ExchangeRateDTO rate)
        {
            var entity = _mapper.Map<ExchangeRateEntity>(rate);

            await _historyRepository.AddCurrencyHistory(entity);

        }
    }
}
