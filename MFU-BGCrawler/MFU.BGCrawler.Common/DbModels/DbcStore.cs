using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFU_BGCrawler.DbModels
{
    public class DbcStore : BaseEntity
    {
        public DbcStore()
        {
            Boardgames = new HashSet<DbcBoardgame>();
        }

        [Column("store_name")] public string Name { get; set; }
        public DbcCountry Country { get; set; }
        public virtual ICollection<DbcBoardgame> Boardgames { get; set; }
    }
}
