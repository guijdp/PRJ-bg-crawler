using System.Collections.Generic;
using System.Linq;
using BGScreener.DbModels;
using BGScreener.Domain;

namespace BGScreener
{
    public static class BGSniperSeeder
    {
        public static void EnsureSeedData(this BGScreenerContext context)
        {
            if (context.AllMigrationsApplied())
            {
                if (!context.Currency.Any())
                {
                    var euro = context.Currency.Add(new CurrencyDTO() { IsoCode = "EUR" }).Entity;
                    var real = context.Currency.Add(new CurrencyDTO() { IsoCode = "BRL" }).Entity;
                    var dolar = context.Currency.Add(new CurrencyDTO() { IsoCode = "USD" }).Entity;

                    var germany = context.Country.Add(new CountryDTO() { Name = "Germany", Currency = euro }).Entity;
                    var brasil = context.Country.Add(new CountryDTO() { Name = "Brasil", Currency = real }).Entity;
                    var usa = context.Country.Add(new CountryDTO() { Name = "USA", Currency = dolar }).Entity;

                    euro.Countries.Add(germany);
                    real.Countries.Add(brasil);
                    dolar.Countries.Add(usa);

                    var glomhaven = context.Boardgame.Add(new BoardgameDTO() { Name = "Gloomhaven" }).Entity;
                    var seventhContinent = context.Boardgame.Add(new BoardgameDTO() { Name = "7Th Continent" }).Entity;
                    var mariposas = context.Boardgame.Add(new BoardgameDTO() { Name = "Mariposas" }).Entity;

                    var fanazyWelt = context.Store.Add(new StoreDTO() { Name = "FantazyWelt", Country = germany, Boardgames = new List<BoardgameDTO>() { glomhaven, seventhContinent } }).Entity;
                    var zatu = context.Store.Add(new StoreDTO() { Name = "ZATU", Country = germany, Boardgames = new List<BoardgameDTO>() { mariposas } }).Entity;

                    //var ex1 = context.ExchangeRate.Add(new DbcExchangeRate() { FromCurrencyId = 1, ToCurrencyId = 2, Rate = 6.52m }).Entity;
                    //var ex2 = context.ExchangeRate.Add(new DbcExchangeRate() { FromCurrencyId = 1, ToCurrencyId = 3, Rate = 1.21m }).Entity;
                    //var ex3 = context.ExchangeRate.Add(new DbcExchangeRate() { FromCurrencyId = 2, ToCurrencyId = 1, Rate = 0.15m }).Entity;
                    //var ex4 = context.ExchangeRate.Add(new DbcExchangeRate() { FromCurrencyId = 2, ToCurrencyId = 3, Rate = 0.19m }).Entity;
                    //var ex5 = context.ExchangeRate.Add(new DbcExchangeRate() { FromCurrencyId = 3, ToCurrencyId = 1, Rate = 0.83m }).Entity;
                    //var ex6 = context.ExchangeRate.Add(new DbcExchangeRate() { FromCurrencyId = 3, ToCurrencyId = 2, Rate = 5.38m }).Entity;

                    //var historicalPrice = context.HistoricalPrice.Add(new DbcHistoricalPrice() { BoardGame = glomhaven, Store = fanazyWelt, DateTime = DateTime.UtcNow }).Entity;

                    context.SaveChanges();
                }
            }
        }
    }
}
