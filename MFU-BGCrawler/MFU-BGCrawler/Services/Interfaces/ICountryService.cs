using System;
using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Model;

namespace MFU_BGCrawler.Services.Interfaces
{
    public interface ICountryService
    {
        CountryDTO[] Get();
        CountryDTO Find(Guid id);
        CountryDTO Insert(Country country);
        CountryDTO Update(CountryDTO country);
        CountryDTO Delete(CountryDTO country);
    }
}
