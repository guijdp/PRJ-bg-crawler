using System;
using System.Linq;
using AutoMapper;
using BGScreener.DbModels;
using BGScreener.Model;
using BGScreener.Services.Interfaces;

namespace BGScreener.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly BGScreenerContext _repository;
        private readonly IMapper _mapper;

        public CurrencyService(BGScreenerContext currencyRepository, IMapper mapper)
        {
            _repository = currencyRepository;
            _mapper = mapper;
        }

        public CurrencyDTO[] Get() => _repository.Currency.OrderBy(c => c.IsoCode).ToArray();

        public CurrencyDTO Find(Guid id) => _repository.Currency.FirstOrDefault(c => c.Id == id);

        public CurrencyDTO Insert(Currency currency)
        {
            try
            {
                var entry = _repository.Currency.Add(_mapper.Map<CurrencyDTO>(currency)).Entity;

                _repository.SaveChanges();
                return entry;
            }
            catch (Exception ex)
            {
                //Todo: Log error
                throw ex.InnerException;
            }
        }

        public CurrencyDTO Update(CurrencyDTO currency)
        {
            try
            {
                _repository.Currency.Attach(currency).Property(x => x.IsoCode).IsModified = true;
                _repository.SaveChanges();
                return currency;
            }
            catch (Exception ex)
            {
                //Todo: Log error
                throw ex.InnerException;
            }
        }

        public CurrencyDTO Delete(CurrencyDTO currency)
        {
            try
            {
                _repository.Currency.Remove(currency);
                _repository.SaveChanges();
                return currency;
            }
            catch (Exception ex)
            {
                //Todo: Log error
                throw ex;
            }
        }
    }
}