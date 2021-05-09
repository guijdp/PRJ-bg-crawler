using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MFU_BGCrawler.DbModels
{
    public class DbcBoardgame : BaseEntity
    {
        public DbcBoardgame()
        {
            Stores = new HashSet<DbcStore>();
        }

        [Column("game_name")] public string GameName { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        public virtual ICollection<DbcStore> Stores { get; set; }
    }
}
