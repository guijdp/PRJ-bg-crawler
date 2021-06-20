using System;
using System.Collections.Generic;
using System.Linq;
using MFU_BGCrawler.DbModels;

namespace MFU_BGCrawler
{
    public static class BGSniperExtensions
    {
        public static void EnsureSeedData(this BGSniperContext context)
        {
            if (context.AllMigrationsApplied())
            {
                if (!context.Currency.Any())
                {
                    var euro = context.Currency.Add(new DbcCurrency() { IsoCode = "EUR" }).Entity;
                    var real = context.Currency.Add(new DbcCurrency() { IsoCode = "BRL" }).Entity;
                    var dolar = context.Currency.Add(new DbcCurrency() { IsoCode = "USD" }).Entity;

                    var germany = context.Country.Add(new DbcCountry() { CountryName = "Germany", Currency = euro }).Entity;
                    var brasil = context.Country.Add(new DbcCountry() { CountryName = "Brasil", Currency = real }).Entity;
                    var usa = context.Country.Add(new DbcCountry() { CountryName = "USA", Currency = dolar }).Entity;

                    euro.Countries.Add(germany);
                    real.Countries.Add(brasil);
                    dolar.Countries.Add(usa);


                    var glomhaven = context.Boardgame.Add(new DbcBoardgame() { GameName = "Gloomhaven" }).Entity;
                    var seventhContinent = context.Boardgame.Add(new DbcBoardgame() { GameName = "7Th Continent" }).Entity;
                    var mariposas = context.Boardgame.Add(new DbcBoardgame() { GameName = "Mariposas" }).Entity;

                    var fanazyWelt = context.Store.Add(new DbcStore() { Name = "FantazyWelt", Country = germany, Boardgames = new List<DbcBoardgame>() { glomhaven, seventhContinent } }).Entity;
                    var zatu = context.Store.Add(new DbcStore() { Name = "ZATU", Country = germany, Boardgames = new List<DbcBoardgame>() { mariposas } }).Entity;

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
