using System.ComponentModel.DataAnnotations.Schema;

namespace MFU_BGCrawler.DbModels
{
    public class DbcCurrency : BaseEntity
    {
        [Column("iso_code")] public string IsoCode { get; set; }
    }
}
