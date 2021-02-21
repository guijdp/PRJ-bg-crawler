using System.ComponentModel.DataAnnotations.Schema;

namespace MFU_BGCrawler.Models
{
    public class Currency
    {
        [Column("currency_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("iso_code")]
        public string IsoCode { get; set; }
    }
}
