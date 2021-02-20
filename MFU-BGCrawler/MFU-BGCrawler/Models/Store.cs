using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFU_BGCrawler.Models
{
    public class Store
    {
        public Store()
        {
            Boardgames = new HashSet<Boardgame>();
        }
        [Column("store_id")]
        public int Id { get; set; }
        [Column("store_name")]
        public string Name { get; set; }
        public virtual ICollection<Boardgame> Boardgames { get; set; }
    }
}
