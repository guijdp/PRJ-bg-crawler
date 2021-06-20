using System.Collections.Generic;
using Newtonsoft.Json;

namespace MFU_BGCrawler.DbModels
{
    public class DbcBoardgame : BaseEntity
    {
        public string GameName { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        public virtual ICollection<DbcStore> Stores { get; set; } = new HashSet<DbcStore>();
    }
}
