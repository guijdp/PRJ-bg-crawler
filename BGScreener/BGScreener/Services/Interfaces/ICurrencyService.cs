using System;
using BGScreener.DbModels;
using BGScreener.Model;

namespace BGScreener.Services.Interfaces
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
