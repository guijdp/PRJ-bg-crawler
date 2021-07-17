using System.Collections.Generic;
using Newtonsoft.Json;

namespace BGScreener.DbModels
{
    public class BoardgameDTO : BaseEntity
    {
        public BoardgameDTO()
        {
            Stores = new List<StoreDTO>();
        }

        public string Name { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        public List<StoreDTO> Stores { get; set; }
    }
}
