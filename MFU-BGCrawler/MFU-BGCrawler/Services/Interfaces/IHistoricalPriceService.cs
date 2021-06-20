using MFU_BGCrawler.DbModels;

namespace MFU_BGCrawler.Services.Interfaces
{
    public interface IHistoricalPriceService
    {
        DbcHistoricalPrice[] Get();
        DbcHistoricalPrice Insert(DbcHistoricalPrice historicalPrice);
    }
}
