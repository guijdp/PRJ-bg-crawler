using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MFU_BGCrawler.Model.Dbc;

namespace MFU_BGCrawler.DbModels
{
    public class BGSniperContext : DbContext
    {
        public BGSniperContext() : base("name=BGSniper-Databse")
        {
            Database.SetInitializer(new BGSniperInitializer());
        }

        public DbSet<DbcStore> Store { get; set; }
        public DbSet<DbcCurrency> Currency { get; set; }
        public DbSet<DbcCountry> Country { get; set; }
        public DbSet<DbcBoardgame> Boardgame { get; set; }
        public DbSet<DbcExchangeRate> ExchangeRate { get; set; }
        public DbSet<DbcHistoricalPrice> HistoricalPrice { get; set; }
    }

    public class BGSniperInitializer : DropCreateDatabaseAlways<BGSniperContext>
    {
        protected override void Seed(BGSniperContext context)
        {
            IList<DbcCurrency> defaultCurrencies = new List<DbcCurrency>
                {
                    new DbcCurrency() { IsoCode = "EUR" },
                    new DbcCurrency() { IsoCode = "BRL" },
                    new DbcCurrency() { IsoCode = "USD" },
                };
            context.Currency.AddRange(defaultCurrencies);

            IList<DbcCountry> defaultCountries = new List<DbcCountry>
            {
                new DbcCountry() { CountryName = "Germany", Currency = defaultCurrencies.FirstOrDefault(c => c.IsoCode == "EUR")},
            };

            IList<DbcStore> germanStores = new List<DbcStore>
            {
                new DbcStore() { Name = "Fantazy Welt" },
                new DbcStore() { Name = "UG Cardstore" }
            };
            germanStores[0].Country = defaultCountries.First();
            defaultCountries[0].Stores = germanStores;

            context.Store.AddRange(germanStores);
            context.Country.AddRange(defaultCountries);

            IList<DbcBoardgame> defaultBoardgames = new List<DbcBoardgame>
            {
                new DbcBoardgame() { GameName = "Gloomhaven" },
                new DbcBoardgame() { GameName = "7Th Continent" },
                new DbcBoardgame() { GameName = "Mariposas" }
            };
            context.Boardgame.AddRange(defaultBoardgames);
            germanStores[1].Boardgames = defaultBoardgames;

            IList<DbcExchangeRate> exchangeRates = new List<DbcExchangeRate>
            {
                new DbcExchangeRate() { FromCurrencyId = 1, ToCurrencyId = 2, Rate = 6.52m},
                new DbcExchangeRate() { FromCurrencyId = 1, ToCurrencyId = 3, Rate = 1.21m},
                new DbcExchangeRate() { FromCurrencyId = 2, ToCurrencyId = 1, Rate = 0.15m},
                new DbcExchangeRate() { FromCurrencyId = 2, ToCurrencyId = 3, Rate = 0.19m},
                new DbcExchangeRate() { FromCurrencyId = 3, ToCurrencyId = 1, Rate = 0.83m},
                new DbcExchangeRate() { FromCurrencyId = 3, ToCurrencyId = 2, Rate = 5.38m}
            };
            context.ExchangeRate.AddRange(exchangeRates);

            IList<DbcHistoricalPrice> historicalPrices = new List<DbcHistoricalPrice>
            {
                new DbcHistoricalPrice() { BoardGame = germanStores[1].Boardgames.First(), Store = germanStores[1] ,DateTime = DateTime.UtcNow}
            };
            context.HistoricalPrice.AddRange(historicalPrices);
        }
    }
}