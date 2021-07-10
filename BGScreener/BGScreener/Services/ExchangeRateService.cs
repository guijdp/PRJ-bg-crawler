using System.Linq;
using BGScreener.DbModels;
using BGScreener.Services.Interfaces;

namespace BGScreener.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly BGScreenerContext _repository;

        public ExchangeRateService(BGScreenerContext repository)
        {
            _repository = repository;
        }

        public ExchangeRateDTO[] Get()
        {
            return _repository.ExchangeRate.ToArray();
        }

        public ExchangeRateDTO Insert(ExchangeRateDTO exchangeRate)
        {
            return new ExchangeRateDTO();//todo
        }
    }
}
