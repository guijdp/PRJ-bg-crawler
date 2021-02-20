using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFU_BGCrawler.Models
{
    public class Country
    {
        public Country()
        {
            Stores = new HashSet<Store>();
        }

        [Column("country_id")]
        public int Id { get; set; }
        [Column("country_name")]
        public string CountryName { get; set; }
        [Column("currency_id")]
        public Currency Currency { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
