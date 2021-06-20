using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MFU_BGCrawler.DbModels
{
    public class DbcCurrency : BaseEntity
    {
        [Required] 
        public string IsoCode { get; set; }

        [JsonProperty(Order = int.MaxValue)] 
        public virtual ICollection<DbcCountry> Countries { get; set; }
    }
}
