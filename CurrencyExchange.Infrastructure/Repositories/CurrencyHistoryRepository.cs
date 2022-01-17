using CurrencyExchange.Domain.Entity;
using CurrencyExchange.Infrastructure.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Repositories
{
    public interface ICurrencyHistoryRepository
    {
        Task AddCurrencyHistory(ExchangeRateEntity entity);
        IEnumerable<ExchangeRateEntity> GetByPredicate(Func<ExchangeRateEntity, bool> predicate);
    }

    public class CurrencyHistoryRepository : ICurrencyHistoryRepository
    {
        readonly CurrencyExchangeDbContext _context;

        public CurrencyHistoryRepository(CurrencyExchangeDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ExchangeRateEntity> GetByPredicate(Func<ExchangeRateEntity, bool> predicate)
            => _context.ExchangeHistory.Where(predicate);

        public async Task AddCurrencyHistory(ExchangeRateEntity entity)
        {
            await _context.ExchangeHistory.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
