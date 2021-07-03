using Microsoft.EntityFrameworkCore;

namespace MFU_BGCrawler.DbModels
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
            builder.Entity<CurrencyDTO>().ToTable("Currency")
                .HasMany(c => c.Countries)
                .WithOne();

            builder.Entity<CountryDTO>().ToTable("Country")
                .HasOne(c => c.Currency)
                .WithMany(c => c.Countries)
                .IsRequired();

            builder.Entity<StoreDTO>().ToTable("Store")
                .HasOne(s => s.Country)
                .WithMany(c => c.Stores)
                .IsRequired();

            builder.Entity<BoardgameDTO>().ToTable("Boardgame")
                .HasMany(bg => bg.Stores)
                .WithMany(c => c.Boardgames);

            builder.Entity<ExchangeRateDTO>().ToTable("ExchangeRate")
                .HasKey(ex => new { ex.FromCurrencyId, ex.ToCurrencyId });

            builder.Entity<HistoricalPriceDTO>().ToTable("HistoricalPrice")
                .HasKey(h => new { h.StoreRefId, h.BoardGameRefId });
        }
    }
}