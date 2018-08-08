using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESM.Models
{
    [Table("PartialEarnings")]
    public class PartialEarning
    {
        [Key]
        public Guid PartialEarningId { get; set; }
        public string Name { get; set; }
        public decimal Ammount { get; set; }

        public Guid EarningId { get; set; }
        public virtual Earning Earning { get; set; }

        public PartialEarning()
        {
            PartialEarningId = Guid.NewGuid();
        }
    }
}