using System.Linq;
using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Model.Dbc;
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
        DbcHistoricalPrice[] IHistoricalPriceService.Get()
        {
            return _repository.HistoricalPrice.ToArray();
        }

        public DbcHistoricalPrice Insert(DbcHistoricalPrice historicalPrice)
        {
            return new DbcHistoricalPrice();//Todo
        }

    }
}
