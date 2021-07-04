using Microsoft.EntityFrameworkCore;

namespace BGScreener.DbModels
{
    public class BGSniperContext : DbContext
    {
        public BGSniperContext(DbContextOptions<BGSniperContext> options) : base(options) { }

        public DbSet<StoreDTO> Store { get; set; }
        public DbSet<CurrencyDTO> Currency { get; set; }
        public DbSet<CountryDTO> Country { get; set; }
        public DbSet<BoardgameDTO> Boardgame { get; set; }
        public DbSet<ExchangeRateDTO> ExchangeRate { get; set; }
        public DbSet<HistoricalPriceDTO> HistoricalPrice { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var currency = builder.Entity<CurrencyDTO>();
            currency.HasMany(c => c.Countries).WithOne();
            currency.Property(c => c.IsoCode).HasMaxLength(3);
            currency.HasIndex(c => c.IsoCode).IsUnique();

            var country = builder.Entity<CountryDTO>();
            country.HasOne(c => c.Currency).WithMany(c => c.Countries).IsRequired();

            var store = builder.Entity<StoreDTO>();
            store.HasOne(s => s.Country).WithMany(c => c.Stores).IsRequired();

            var boardgame = builder.Entity<BoardgameDTO>();
            boardgame.HasMany(bg => bg.Stores).WithMany(c => c.Boardgames);

            var exchangeRate = builder.Entity<ExchangeRateDTO>();
            exchangeRate.HasKey(ex => new { ex.FromCurrencyId, ex.ToCurrencyId });

            var historicalPrice = builder.Entity<HistoricalPriceDTO>();
            historicalPrice.HasKey(h => new { h.StoreRefId, h.BoardGameRefId });
        }
    }
}