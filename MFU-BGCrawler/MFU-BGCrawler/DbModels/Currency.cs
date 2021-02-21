using System.ComponentModel.DataAnnotations.Schema;

namespace MFU_BGCrawler.DbModels
{
    public class Currency : BaseEntity
    {
        [Column("iso_code")]
        public string IsoCode { get; set; }
    }
}
