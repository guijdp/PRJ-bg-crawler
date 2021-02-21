using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFU_BGCrawler.DbModels
{
    public class Store : BaseEntity
    {
        public Store()
        {
            //Boardgames = new HashSet<Boardgame>();
        }

        [Column("store_name")]
        public string Name { get; set; }
        public Country Country { get; set; }
        //public virtual ICollection<Boardgame> Boardgames { get; set; }
    }
}
