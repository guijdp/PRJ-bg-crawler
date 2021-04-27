using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Model;

namespace MFU_BGCrawler.Services.Interfaces
{
    public interface ICountryService
    {
        DbcCountry[] Get();
        DbcCountry Find(long id);
        DbcCountry Insert(Country country);
        DbcCountry Update(DbcCountry country);
        DbcCountry Delete(DbcCountry country);
    }
}
