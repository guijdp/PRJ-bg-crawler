using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace MFU_BGCrawler.DbModels
{
    public class BGSniperContext : DbContext, IDbContext
    {
        public BGSniperContext() : base("name=BGSniper-Databse")
        {
            Database.SetInitializer(new BGSniperInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        //public DbSet<Boardgame> Boardgame { get; set; }
        //public DbSet<Country> Country { get; set; }
        //public DbSet<Currency> Currency { get; set; }
        //public DbSet<ExchangeRate> ExchangeRate { get; set; }
        public DbSet<Store> Store { get; set; }
    }

    public class BGSniperInitializer : DropCreateDatabaseAlways<BGSniperContext>
    {
        protected override void Seed(BGSniperContext context)
        {
            IList<Store> germanStores = new List<Store>
            {
                new Store() { Name = "Fantazy Welt" },
                new Store() { Name = "UG Cardstore" }
            };
            context.Store.AddRange(germanStores);
            base.Seed(context);
        }
        //    IList<Boardgame> defaultBoardgames = new List<Boardgame>
        //        {
        //            new Boardgame() { GameName = "Gloomhaven" },
        //            new Boardgame() { GameName = "7Th Continent" },
        //            new Boardgame() { GameName = "Mariposas" }
        //        };
        //    context.Boardgame.AddRange(defaultBoardgames);



        //    IList<Store> brazilianStores = new List<Store>
        //    {
        //        new Store() { Name = "ZATU Games" }
        //    };
        //    context.Store.AddRange(brazilianStores);


        //    IList<Currency> defaultCurrencies = new List<Currency>
        //    {
        //        new Currency() { IsoCode = "EUR" },
        //        new Currency() { IsoCode = "BRL" },
        //        new Currency() { IsoCode = "USD" },
        //    };
        //    context.Currency.AddRange(defaultCurrencies);

        //    IList<Country> defaultCountries = new List<Country>
        //    {
        //        new Country() { CountryName = "Germany", Stores = germanStores, Currency = defaultCurrencies[0]},
        //        new Country() { CountryName = "Brazil", Stores = brazilianStores, Currency = defaultCurrencies[1]},
        //        new Country() { CountryName = "United States", Stores = null, Currency = defaultCurrencies[2]}
        //    };
        //    context.Country.AddRange(defaultCountries);

        //    IList<ExchangeRate> exchangeRates = new List<ExchangeRate>
        //    {
        //        new ExchangeRate() { FromCurrencyId = 1, ToCurrencyId = 2, Rate = 6.52m},
        //        new ExchangeRate() { FromCurrencyId = 1, ToCurrencyId = 3, Rate = 1.21m},
        //        new ExchangeRate() { FromCurrencyId = 2, ToCurrencyId = 1, Rate = 0.15m},
        //        new ExchangeRate() { FromCurrencyId = 2, ToCurrencyId = 3, Rate = 0.19m},
        //        new ExchangeRate() { FromCurrencyId = 3, ToCurrencyId = 1, Rate = 0.83m},
        //        new ExchangeRate() { FromCurrencyId = 3, ToCurrencyId = 2, Rate = 5.38m}
        //    };
        //    context.ExchangeRate.AddRange(exchangeRates);
    }
}