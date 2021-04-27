using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Model;
using MFU_BGCrawler.Services.Interfaces;
using System.Linq;

namespace MFU_BGCrawler.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly BGSniperContext _repository;

        public CurrencyService(BGSniperContext currencyRepository)
        {
            _repository = currencyRepository;
        }

        public DbcCurrency[] Get()
        {
            return _repository.Currency.ToArray();
        }

        public DbcCurrency Find(long id)
        {
            return _repository.Currency.FirstOrDefault(c => c.ID == id);
        }


        public DbcCurrency Insert(Currency currency)
        {
            throw new System.NotImplementedException();//todo
        }

        public DbcCurrency Update(DbcCurrency currency)
        {
            throw new System.NotImplementedException();//todo
        }

        public DbcCurrency Delete(DbcCurrency currency)
        {
            throw new System.NotImplementedException();//todo
        }
    }
}