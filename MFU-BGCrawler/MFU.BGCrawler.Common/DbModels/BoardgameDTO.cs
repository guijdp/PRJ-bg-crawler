using System.Collections.Generic;
using Newtonsoft.Json;

namespace MFU_BGCrawler.DbModels
{
    public class BoardgameDTO : BaseEntity
    {
        public BoardgameDTO()
        {
            Stores = new List<StoreDTO>();
        }

        public string GameName { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        public List<StoreDTO> Stores { get; set; }
    }
}
