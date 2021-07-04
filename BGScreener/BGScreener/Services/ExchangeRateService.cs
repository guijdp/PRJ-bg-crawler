using System.Linq;
using BGScreener.DbModels;
using BGScreener.Services.Interfaces;

namespace BGScreener.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly BGSniperContext _repository;

        public ExchangeRateService(BGSniperContext repository)
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
