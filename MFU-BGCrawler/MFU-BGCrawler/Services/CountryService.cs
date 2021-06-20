using System;
using System.Linq;
using AutoMapper;
using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Model;
using MFU_BGCrawler.Services.Interfaces;

namespace MFU_BGCrawler.Services
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

        public Country[] Get() => _mapper.Map<Country[]>(_repository.Country.ToArray());

        public DbcCountry Find(Guid id) => _repository.Country.FirstOrDefault(c => c.Id == id);

        public DbcCountry Insert(Country country)
        {
            try
            {
                var currency = _repository.Currency.FirstOrDefault(c => c.IsoCode == country.Currency);
                if (currency == null)
                    throw new Exception($"Currency named {country.Currency} does not exist");

                var entry = new DbcCountry()
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

        public DbcCountry Update(DbcCountry country)
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

        public DbcCountry Delete(DbcCountry country)
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
