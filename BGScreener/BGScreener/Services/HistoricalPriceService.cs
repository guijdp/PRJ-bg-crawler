using System.Linq;
using BGScreener.DbModels;
using BGScreener.Services.Interfaces;

namespace BGScreener.Services
{
    public class HistoricalPriceService : IHistoricalPriceService
    {
        private readonly BGScreenerContext _repository;

        public HistoricalPriceService(BGScreenerContext repository)
        {
            _repository = repository;
        }
        HistoricalPriceDTO[] IHistoricalPriceService.Get()
        {
            return _repository.HistoricalPrice.ToArray();
        }

        public HistoricalPriceDTO Insert(HistoricalPriceDTO historicalPrice)
        {
            return new HistoricalPriceDTO();//Todo
        }

    }
}
