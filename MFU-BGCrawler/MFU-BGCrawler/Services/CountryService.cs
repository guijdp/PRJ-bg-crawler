using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Model;
using MFU_BGCrawler.Services.Interfaces;
using System.Linq;

namespace MFU_BGCrawler.Services
{
    public class CountryService : ICountryService
    {
        private readonly BGSniperContext _repository;

        public CountryService(BGSniperContext repository)
        {
            _repository = repository;
        }

        public DbcCountry[] Get()
        {
            return _repository.Country.ToArray();
        }

        public DbcCountry Find(long id)
        {
            return _repository.Country.FirstOrDefault(c => c.Id == id);
        }

        public DbcCountry Insert(Country country)
        {
            return new DbcCountry();//todo
        }

        public DbcCountry Update(DbcCountry country)
        {
            return new DbcCountry();//todo
        }

        public DbcCountry Delete(DbcCountry country)
        {
            return new DbcCountry();//todo
        }
    }
}
