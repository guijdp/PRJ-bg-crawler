﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace BGScreener.DbModels
{
    public class ExchangeRateDTO : BaseEntity
    {
        public decimal Rate { get; set; }

        [Key]
        [JsonProperty(Order = int.MaxValue)]
        [Column("from_currency", Order = 1)] public int FromCurrencyId { get; set; }

        [Key]
        [JsonProperty(Order = int.MaxValue)]
        [Column("to_currency", Order = 2)] public int ToCurrencyId { get; set; }
    }
}
