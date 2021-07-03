using System.Linq;
using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Services.Interfaces;

namespace MFU_BGCrawler.Services
{
    public class HistoricalPriceService : IHistoricalPriceService
    {
        private readonly BGSniperContext _repository;

        public HistoricalPriceService(BGSniperContext repository)
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
