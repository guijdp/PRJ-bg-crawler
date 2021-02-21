//using MFU_BGCrawler.DbModels;
//using MFU_BGCrawler.Model;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace MFU_BGCrawler.Services
//{
//    public class CountryService : ICountryService
//    {
//        private readonly BGSniperContext _dbContext;
//        private readonly ILogger _logger;
//        public CountryService(BGSniperContext dbContext, ILogger logger)
//        {
//            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
//            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
//        }

//        public void Delete<T>(int id)
//        {
//            var country = _dbContext.Country.Find(id);
//            if (country == null)
//            {
//                _logger.LogError($"Cannot delete country Id:{id}");
//                return;
//            }

//            _dbContext.Country.Remove(country);
//            Save();
//        }

//        public T Find<T>(string name)
//        {
//            var country = _dbContext.Country.FirstOrDefault(c => c.CountryName == name);
//            return (T)Convert.ChangeType(country, typeof(T));
//        }

//        public void Insert<T>(T entity)
//        {
//            var country = entity as CountryModel;
//            var newCountry = new Country() { CountryName = country.CountryName, Currency = new Currency { } };
//            try
//            {
//                var a = _dbContext.Country.Add(newCountry);
//                Save();
//            }
//            catch (Exception e)
//            {
//                _logger.LogError(e.Message);
//                throw;
//            }
//        }

//        public IEnumerable<T> ListAll<T>()
//        {
//            var countries = _dbContext.Country.Select(c => new CountryModel
//            {
//                CountryName = c.CountryName,
//                Currency = c.Currency.IsoCode
//            });
//            return (IEnumerable<T>)countries;
//        }

//        public IEnumerable<T> ListFiltered<T>(string name)
//        {
//            var countries = _dbContext.Country.Where(s => s.CountryName.Contains(name)).ToList();
//            return (IEnumerable<T>)countries;
//        }

//        public void Save()
//        {
//            _dbContext.SaveChanges();
//        }
//    }
//}
