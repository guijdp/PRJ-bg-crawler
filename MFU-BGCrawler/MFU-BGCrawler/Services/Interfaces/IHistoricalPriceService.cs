using MFU_BGCrawler.DbModels;

namespace MFU_BGCrawler.Services.Interfaces
{
    public interface IHistoricalPriceService
    {
        HistoricalPriceDTO[] Get();
        HistoricalPriceDTO Insert(HistoricalPriceDTO historicalPrice);
    }
}
