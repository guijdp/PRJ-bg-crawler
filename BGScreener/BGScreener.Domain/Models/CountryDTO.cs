using System.Collections.Generic;
using Newtonsoft.Json;

namespace BGScreener.DbModels
{
    public class CountryDTO : BaseEntity
    {
        public CountryDTO()
        {
            Stores = new List<StoreDTO>();
        }

        public string Name { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        public CurrencyDTO Currency { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        public List<StoreDTO> Stores { get; set; }
    }
}
