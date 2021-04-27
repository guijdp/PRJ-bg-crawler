using MFU_BGCrawler.DbModels;

namespace MFU_BGCrawler.Services.Interfaces
{
    public interface IExchangeRateService
    {
        DbcExchangeRate[] Get();
        DbcExchangeRate Insert(DbcExchangeRate store);
    }
}
