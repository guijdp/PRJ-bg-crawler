using Microsoft.EntityFrameworkCore;

namespace MFU_BGCrawler.DbModels
{
    public class BGSniperContext : DbContext
    {
        public BGSniperContext(DbContextOptions<BGSniperContext> options) : base(options) { }

        public DbSet<DbcStore> Store { get; set; }
        public DbSet<DbcCurrency> Currency { get; set; }
        public DbSet<DbcCountry> Country { get; set; }
        public DbSet<DbcBoardgame> Boardgame { get; set; }
        public DbSet<DbcExchangeRate> ExchangeRate { get; set; }
        public DbSet<DbcHistoricalPrice> HistoricalPrice { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DbcStore>().ToTable("Store");
            builder.Entity<DbcCurrency>().ToTable("Currency");
            builder.Entity<DbcCountry>().ToTable("Country");
            builder.Entity<DbcBoardgame>().ToTable("Boardgame");
            builder.Entity<DbcExchangeRate>().ToTable("ExchangeRate")
                .HasKey(ex => new { ex.FromCurrencyId, ex.ToCurrencyId });

            builder.Entity<DbcHistoricalPrice>().ToTable("HistoricalPrice")
                .HasKey(h => new { h.StoreRefId, h.BoardGameRefId });
        }
    }
}