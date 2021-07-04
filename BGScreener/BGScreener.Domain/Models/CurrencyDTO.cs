using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BGScreener.DbModels
{
    public class CurrencyDTO : BaseEntity
    {
        public CurrencyDTO()
        {
            Countries = new List<CountryDTO>();
        }

        [Required]
        public string IsoCode { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        public List<CountryDTO> Countries { get; set; }
    }
}
