using System.ComponentModel.DataAnnotations.Schema;

namespace MFU_BGCrawler.Models
{
    public class Store
    {
        [Column("store_id")]
        public int Id { get; set; }
        [Column("store_name")]
        public string Name { get; set; }
    }
}
