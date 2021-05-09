using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFU_BGCrawler.DbModels
{
    public abstract class BaseEntity
    {
        [Key, Column(Order=0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public Int64 Id { get; set; }//Todo change to guid
        public DateTime? AddedDate { get; } = DateTime.UtcNow; //Todo find better way to initialize added date
        public DateTime? ModifiedDate { get; set; }
    }
}
