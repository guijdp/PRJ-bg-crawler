using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFU_BGCrawler.Model.Dbc
{
    public class DbcHistoricalPrice
    {
        [Key]
        [Column("store_Id", Order = 1)] public int StoreId { get; set; }
        [Key]
        [Column("boardgame_Id", Order = 2)] public int BoardGameId { get; set; }

        [Column("historical_low")] public bool HistoricalLow { get; set; }
        [Column("day")] public DateTime DateTime { get; set; }
    }
}
