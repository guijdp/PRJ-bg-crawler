using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MFU_BGCrawler.DbModels
{
    public class HistoricalPriceDTO : BaseEntity
    {
        [Key, Column(Order = 0)] public Guid StoreRefId { get; set; }
        [JsonProperty(Order = int.MaxValue)]
        [ForeignKey("StoreRefId")] public virtual StoreDTO Store { get; set; }

        [Key, Column(Order = 1)] public Guid BoardGameRefId { get; set; }
        [JsonProperty(Order = int.MaxValue)]
        [ForeignKey("BoardGameRefId")] public virtual BoardgameDTO BoardGame { get; set; }

        [Column("historical_low")] public bool HistoricalLow { get; set; }
        [Column("day")] public DateTime DateTime { get; set; }
    }
}
