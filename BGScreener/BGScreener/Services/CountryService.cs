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
        private readonly BGSniperContext _repository;
        private readonly IMapper _mapper;

        public CountryService(BGSniperContext countryRepository, IMapper mapper)
        {
            _repository = countryRepository;
            _mapper = mapper;
        }

        public CountryDTO[] Get() => _repository.Country.Include(c => c.Currency).ToArray();

        public CountryDTO Find(Guid id) => _repository.Country.FirstOrDefault(c => c.Id == id);

        public CountryDTO Insert(Country country)
        {
            try
            {
                var currency = _repository.Currency.FirstOrDefault(c => c.IsoCode == country.Currency);
                if (currency == null)
                    throw new Exception($"Currency named {country.Currency} does not exist");

                var entry = new CountryDTO()
                {
                    CountryName = country.Name,
                    Currency = currency
                };

                _repository.Country.Add(entry);
                _repository.SaveChanges();

                return entry;
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
                var entry = Find(country.Id);
                if (entry == null)
                    throw new Exception($"Country with Id {country.Id} does not exist");

                var currency = _repository.Currency.FirstOrDefault(c => c.IsoCode == country.Currency.IsoCode);
                if (currency == null)
                    throw new Exception($"Currency named {country.Currency} does not exist");

                _repository.Country.Attach(entry);

                entry.ModifiedDate = DateTime.UtcNow;
                entry.CountryName = country.CountryName;
                _repository.SaveChanges();
                return entry;
            }
            catch (Exception ex)
            {
                //Todo: Log error
                throw ex;
            }
        }

        public CountryDTO Delete(CountryDTO country)
        {
            var entry = Find(country.Id);
            if (entry == null)
                return null;

            try
            {
                _repository.Country.Remove(entry);
                _repository.SaveChanges();
                return country;
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
