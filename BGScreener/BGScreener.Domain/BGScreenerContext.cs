using Microsoft.EntityFrameworkCore;

namespace BGScreener.DbModels
{
    public class BGScreenerContext : DbContext
    {
        public BGScreenerContext(DbContextOptions<BGScreenerContext> options) : base(options) { }

        public DbSet<StoreDTO> Store { get; set; }
        public DbSet<CurrencyDTO> Currency { get; set; }
        public DbSet<CountryDTO> Country { get; set; }
        public DbSet<BoardgameDTO> Boardgame { get; set; }
        public DbSet<ExchangeRateDTO> ExchangeRate { get; set; }
        public DbSet<HistoricalPriceDTO> HistoricalPrice { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var currency = builder.Entity<CurrencyDTO>();
            currency.HasIndex(c => c.IsoCode).IsUnique();
            currency.HasMany(c => c.Countries).WithOne().OnDelete(DeleteBehavior.NoAction);
            currency.Property(c => c.IsoCode).HasMaxLength(3);

            var country = builder.Entity<CountryDTO>();
            country.HasIndex(c => c.CountryName).IsUnique();
            country.HasOne(c => c.Currency).WithMany(c => c.Countries);
            country.Navigation(c => c.Currency).IsRequired();
            country.Property(c => c.CountryName).HasMaxLength(30);

            var store = builder.Entity<StoreDTO>();
            store.HasIndex(s => s.Name).IsUnique();
            store.HasOne(s => s.Country).WithMany(c => c.Stores).IsRequired();
            country.Property(c => c.CountryName).HasMaxLength(30);

            var boardgame = builder.Entity<BoardgameDTO>();
            boardgame.HasMany(bg => bg.Stores).WithMany(c => c.Boardgames);

            var exchangeRate = builder.Entity<ExchangeRateDTO>();
            exchangeRate.HasKey(ex => new { ex.FromCurrencyId, ex.ToCurrencyId });

            var historicalPrice = builder.Entity<HistoricalPriceDTO>();
            historicalPrice.HasKey(h => new { h.StoreRefId, h.BoardGameRefId });
        }
    }
}