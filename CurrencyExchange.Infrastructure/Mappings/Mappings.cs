using AutoMapper;
using CurrencyExchange.Domain.DTO;
using CurrencyExchange.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Mappings
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<ExchangeRateEntity, ExchangeRateDTO>().ReverseMap();
        }
    }
}
