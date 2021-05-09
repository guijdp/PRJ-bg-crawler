using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MFU_BGCrawler.DbModels
{
    public class DbcCountry : BaseEntity
    {
        public DbcCountry()
        {
            Stores = new HashSet<DbcStore>();
        }

        [Column("country_name")] public string CountryName { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        [Column("currency_id")] public DbcCurrency Currency { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        public virtual ICollection<DbcStore> Stores { get; set; }
    }
}
