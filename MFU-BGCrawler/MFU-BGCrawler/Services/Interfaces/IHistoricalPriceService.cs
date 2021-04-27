using MFU_BGCrawler.Model.Dbc;

namespace MFU_BGCrawler.Services.Interfaces
{
    public interface IHistoricalPriceService
    {
        DbcHistoricalPrice[] Get();
        DbcHistoricalPrice Insert(DbcHistoricalPrice historicalPrice);
    }
}
