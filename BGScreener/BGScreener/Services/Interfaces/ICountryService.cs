using System;
using BGScreener.DbModels;
using BGScreener.Model;

namespace BGScreener.Services.Interfaces
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
