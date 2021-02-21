using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MFU_BGCrawler.Models
{
    public class BGSniperContext : DbContext
    {
        public BGSniperContext() : base("name=BGSniper-Databse")
        {
            Database.SetInitializer(new BGSniperInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Boardgame> Boardgame { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<ExchangeRate> ExchangeRate { get; set; }
        public DbSet<Store> Store { get; set; }
    }

    public class BGSniperInitializer : DropCreateDatabaseAlways<BGSniperContext>
    {
        protected override void Seed(BGSniperContext context)
        {
            IList<Boardgame> defaultBoardgames = new List<Boardgame>
            {
                new Boardgame() { GameName = "Gloomhaven" },
                new Boardgame() { GameName = "7Th Continent" },
                new Boardgame() { GameName = "Mariposas" }
            };
            context.Boardgame.AddRange(defaultBoardgames);

            IList<Store> defaultStores = new List<Store>
            {
                new Store() { Name = "Fantazy Welt" },
                new Store() { Name = "UG Cardstore" },
                new Store() { Name = "ZATU Games" }
            };
            context.Store.AddRange(defaultStores);

            IList<Currency> defaultCurrencies = new List<Currency>
            {
                new Currency() { IsoCode = "EUR" },
                new Currency() { IsoCode = "BRL" },
                new Currency() { IsoCode = "USD" },
            };
            context.Currency.AddRange(defaultCurrencies);

            IList<Country> defaultCountries = new List<Country>
            {
                new Country() { CountryName = "Germany", Stores = defaultStores, Currency = defaultCurrencies[0]},
                new Country() { CountryName = "Brazil", Stores = null, Currency = defaultCurrencies[1]},
                new Country() { CountryName = "United States", Stores = null, Currency = defaultCurrencies[2]}
            };
            context.Country.AddRange(defaultCountries);

            IList<ExchangeRate> exchangeRates = new List<ExchangeRate>
            {
                new ExchangeRate() { FromCurrencyId = 1, ToCurrencyId = 2, Rate = 6.52m},
                new ExchangeRate() { FromCurrencyId = 1, ToCurrencyId = 3, Rate = 1.21m},
                new ExchangeRate() { FromCurrencyId = 2, ToCurrencyId = 1, Rate = 0.15m},
                new ExchangeRate() { FromCurrencyId = 2, ToCurrencyId = 3, Rate = 0.19m},
                new ExchangeRate() { FromCurrencyId = 3, ToCurrencyId = 1, Rate = 0.83m},
                new ExchangeRate() { FromCurrencyId = 3, ToCurrencyId = 2, Rate = 5.38m}
            };
            context.ExchangeRate.AddRange(exchangeRates);

            base.Seed(context);
        }
    }
}