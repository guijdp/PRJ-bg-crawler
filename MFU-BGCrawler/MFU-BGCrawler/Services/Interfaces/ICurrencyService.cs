using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Model;

namespace MFU_BGCrawler.Services.Interfaces
{
    public interface ICurrencyService
    {
        DbcCurrency[] Get();
        DbcCurrency Find(long id);
        DbcCurrency Insert(Currency currency);
        DbcCurrency Update(DbcCurrency currency);
        DbcCurrency Delete(DbcCurrency currency);
    }
}
