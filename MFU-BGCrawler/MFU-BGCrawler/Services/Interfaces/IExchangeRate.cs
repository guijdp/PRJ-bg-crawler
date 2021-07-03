using MFU_BGCrawler.DbModels;

namespace MFU_BGCrawler.Services.Interfaces
{
    public interface IExchangeRateService
    {
        ExchangeRateDTO[] Get();
        ExchangeRateDTO Insert(ExchangeRateDTO store);
    }
}
