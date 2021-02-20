using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFU_BGCrawler.Models
{
    public class Boardgame
    {
        public Boardgame()
        {
            Stores = new HashSet<Store>();
        }

        [Column("boardgame_id")]
        public int Id { get; set; }
        [Column("game_name")]
        public string GameName { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
