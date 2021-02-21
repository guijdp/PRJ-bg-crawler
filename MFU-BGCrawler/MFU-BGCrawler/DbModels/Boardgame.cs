using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFU_BGCrawler.DbModels
{
    public class Boardgame : BaseEntity
    {
        public Boardgame()
        {
            Stores = new HashSet<Store>();
        }

        [Column("game_name")]
        public string GameName { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
