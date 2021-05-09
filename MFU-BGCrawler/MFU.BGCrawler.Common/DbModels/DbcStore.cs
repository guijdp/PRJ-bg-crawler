using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MFU_BGCrawler.DbModels
{
    public class DbcStore : BaseEntity
    {
        public DbcStore()
        {
            Boardgames = new HashSet<DbcBoardgame>();
        }

        [Column("store_name")] public string Name { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        public DbcCountry Country { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        public virtual ICollection<DbcBoardgame> Boardgames { get; set; }
    }
}
