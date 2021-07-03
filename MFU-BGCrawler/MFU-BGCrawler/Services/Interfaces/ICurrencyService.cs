using System;
using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Model;

namespace MFU_BGCrawler.Services.Interfaces
{
    public interface ICurrencyService
    {
        CurrencyDTO[] Get();
        CurrencyDTO Find(Guid id);
        CurrencyDTO Insert(Currency currency);
        CurrencyDTO Update(CurrencyDTO currency);
        CurrencyDTO Delete(CurrencyDTO currency);
    }
}
