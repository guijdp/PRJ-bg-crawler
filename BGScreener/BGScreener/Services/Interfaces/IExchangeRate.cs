using BGScreener.DbModels;

namespace BGScreener.Services.Interfaces
{
    public interface IExchangeRateService
    {
        ExchangeRateDTO[] Get();
        ExchangeRateDTO Insert(ExchangeRateDTO store);
    }
}
