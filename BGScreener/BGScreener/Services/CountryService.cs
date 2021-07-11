using System;
using System.Linq;
using AutoMapper;
using BGScreener.DbModels;
using BGScreener.Model;
using BGScreener.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BGScreener.Services
{
    public class CountryService : ICountryService
    {
        private readonly BGScreenerContext _repository;
        private readonly IMapper _mapper;

        public CountryService(BGScreenerContext countryRepository, IMapper mapper)
        {
            _repository = countryRepository;
            _mapper = mapper;
        }

        public CountryDTO[] Get() =>
            _repository.Country.OrderBy(c => c.CountryName).Include(c => c.Currency).ToArray();

        public CountryDTO Find(Guid id) => _repository.Country.FirstOrDefault(c => c.Id == id);

        public CountryDTO Insert(Country country)
        {
            try
            {
                var model = _mapper.Map<CountryDTO>(country);
                var currency = _repository.Currency.FirstOrDefault(c => c.IsoCode == country.Currency);
                model.Currency = currency ?? model.Currency;

                var result = _repository.Country.Add(model).Entity;
                _repository.SaveChanges();

                return result;
            }
            catch (Exception e)
            {
                //Todo: Log error here
                throw e;
            }
        }

        public CountryDTO Update(CountryDTO country)
        {
            try
            {
                _repository.Country.Attach(country).Property(x => x.CountryName).IsModified = true;
                _repository.SaveChanges();
                return country;
            }
            catch (Exception ex)
            {
                //Todo: Log error
                throw ex.InnerException;
            }
        }

        public CountryDTO Delete(CountryDTO country)
        {
            try
            {
                _repository.Country.Remove(country);
                _repository.SaveChanges();
                return country;
            }
            catch (Exception ex)
            {
                //Todo: Log error
                throw ex;
            }
        }
    }
}
