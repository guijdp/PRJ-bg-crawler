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

        public string CountryName { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        public virtual DbcCurrency Currency { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        public virtual ICollection<DbcStore> Stores { get; set; }
    }
}
