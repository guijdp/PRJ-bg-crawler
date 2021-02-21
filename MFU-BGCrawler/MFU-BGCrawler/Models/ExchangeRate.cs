using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFU_BGCrawler.Models
{
    public class ExchangeRate
    {
        [Key]
        [Column("from_currency", Order = 1)]
        public int FromCurrencyId { get; set; }
        [Key]
        [Column("to_currency", Order = 2)]
        public int ToCurrencyId { get; set; }
        [Column("exchange_rate")]
        public decimal Rate { get; set; }
    }
}
