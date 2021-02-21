using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFU_BGCrawler.DbModels
{
    public class Country : BaseEntity
    {
        public Country()
        {
            Stores = new HashSet<Store>();
        }

        [Column("country_name")]
        public string CountryName { get; set; }
        [Column("currency_id")]
        public Currency Currency { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
