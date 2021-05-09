using System.ComponentModel.DataAnnotations.Schema;

namespace MFU_BGCrawler.Model
{
    public class Country
    {
        public string Name { get; set; }
        [Column("currency_id")]
        public int Currency { get; set; }
    }
}
