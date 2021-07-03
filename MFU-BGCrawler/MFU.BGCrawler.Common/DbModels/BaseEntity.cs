using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MFU_BGCrawler.DbModels
{
    public abstract class BaseEntity
    {
        [Key, Column(Order=0), JsonProperty(Order = int.MinValue)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public Guid Id { get; set; }

        [JsonProperty(Order = int.MaxValue)]
        public DateTime? AddedDate { get; } = DateTime.UtcNow; //Todo find better way to initialize added date

        [JsonProperty(Order = int.MaxValue)]
        public DateTime? ModifiedDate { get; set; }
    }
}
