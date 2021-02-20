using System.ComponentModel.DataAnnotations.Schema;

namespace MFU_BGCrawler.Models
{
    public class ExchangeRate
    {
        [Column("from_currency")]
        public Currency FromCurrency { get; set; }
        [Column("to_currency")]
        public Currency ToCurrency { get; set; }
        [Column("exchange_rate")]
        public decimal Currency { get; set; }
    }
}
