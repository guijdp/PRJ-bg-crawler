using System.Collections.Generic;
using Newtonsoft.Json;

namespace MFU_BGCrawler.DbModels
{
    public class StoreDTO : BaseEntity
    {
        public StoreDTO()
        {
            Boardgames = new HashSet<BoardgameDTO>();
        }

        public string Name { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        public CountryDTO Country { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        public virtual ICollection<BoardgameDTO> Boardgames { get; set; }
    }
}
