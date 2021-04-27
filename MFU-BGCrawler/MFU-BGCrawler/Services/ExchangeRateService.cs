using System.Linq;
using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Services.Interfaces;

namespace MFU_BGCrawler.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly BGSniperContext _repository;

        public ExchangeRateService(BGSniperContext repository)
        {
            _repository = repository;
        }

        public DbcExchangeRate[] Get()
        {
            return _repository.ExchangeRate.ToArray();
        }

        public DbcExchangeRate Insert(DbcExchangeRate exchangeRate)
        {
            return new DbcExchangeRate();//todo
        }
    }
}
