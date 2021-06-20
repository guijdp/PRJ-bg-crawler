using System.Collections.Generic;
using Newtonsoft.Json;

namespace MFU_BGCrawler.DbModels
{
    public class DbcStore : BaseEntity
    {
        public DbcStore()
        {
            Boardgames = new HashSet<DbcBoardgame>();
        }

        public string Name { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        public DbcCountry Country { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        public virtual ICollection<DbcBoardgame> Boardgames { get; set; }
    }
}
