using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFU_BGCrawler.DbModels
{
    public class DbcCountry : BaseEntity
    {
        public DbcCountry()
        {
            Stores = new HashSet<DbcStore>();
        }

        [Column("country_name")] public string CountryName { get; set; }
        [Column("currency_id")] public DbcCurrency Currency { get; set; }

        public virtual ICollection<DbcStore> Stores { get; set; }
    }
}
