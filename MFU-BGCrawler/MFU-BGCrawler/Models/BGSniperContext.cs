using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.Entity;

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
                new Store() { Name = "Fantazy Welt" }
            };
            context.Store.AddRange(defaultStores);

            IList<Currency> defaultCurrencies = new List<Currency>
            {
                new Currency() { IsoCode = "EUR" },
                new Currency() { IsoCode = "BRL" },
            };
            context.Currency.AddRange(defaultCurrencies);

            IList<Country> defaultCountries = new List<Country>
            {
                new Country() { CountryName = "Germany", Stores = defaultStores, Currency = defaultCurrencies[0]}
            };
            context.Country.AddRange(defaultCountries);

            base.Seed(context);
        }
    }
}