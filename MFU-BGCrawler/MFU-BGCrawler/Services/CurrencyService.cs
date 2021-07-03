using System;
using System.Linq;
using AutoMapper;
using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Model;
using MFU_BGCrawler.Services.Interfaces;

namespace MFU_BGCrawler.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly BGSniperContext _repository;
        private readonly IMapper _mapper;

        public CurrencyService(BGSniperContext currencyRepository, IMapper mapper)
        {
            _repository = currencyRepository;
            _mapper = mapper;
        }

        public CurrencyDTO[] Get() => _repository.Currency.ToArray();

        public CurrencyDTO Find(Guid id) => _repository.Currency.FirstOrDefault(c => c.Id == id);

        public CurrencyDTO Insert(Currency currency)
        {
            try
            {
                var entry = new CurrencyDTO()
                {
                    IsoCode = currency.IsoCode
                };

                _repository.Currency.Add(entry);
                _repository.SaveChanges();

                return entry;
            }
            catch (Exception e)
            {
                //Todo: Log error here
                throw e;
            }
        }

        public CurrencyDTO Update(CurrencyDTO currency)
        {
            try
            {
                var entry = Find(currency.Id);
                if (entry == null)
                    throw new Exception($"Currency with Id {currency.Id} does not exist");

                _repository.Currency.Attach(entry);

                entry.ModifiedDate = DateTime.UtcNow;
                entry.IsoCode = currency.IsoCode;
                _repository.SaveChanges();
                return entry;
            }
            catch (Exception ex)
            {
                //Todo: Log error
                throw ex;
            }
        }

        public CurrencyDTO Delete(CurrencyDTO currency)
        {
            var entry = Find(currency.Id);
            if (entry == null)
                return null;

            try
            {
                _repository.Currency.Remove(entry);
                _repository.SaveChanges();
                return currency;
            }
            catch (Exception ex)
            {
                //Todo: Log error
                _repository.Entry(entry).Reload();
                throw ex.InnerException;
            }
        }
    }
}