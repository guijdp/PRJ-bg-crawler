using BGScreener.DbModels;

namespace BGScreener.Services.Interfaces
{
    public interface IHistoricalPriceService
    {
        HistoricalPriceDTO[] Get();
        HistoricalPriceDTO Insert(HistoricalPriceDTO historicalPrice);
    }
}
