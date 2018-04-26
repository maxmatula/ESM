using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ESM.Models
{
    [Table("Earnings")]
    public class Earning
    {
        [Key]
        public Guid EarningId { get; set; }
        public decimal Ammount { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AddDate { get; set; }
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public Earning()
        {
            this.EarningId = Guid.NewGuid();
            this.AddDate = DateTime.Now;
        }
    }
}