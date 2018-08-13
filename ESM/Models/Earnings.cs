using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESM.Models
{
    [Table("Earnings")]
    public class Earning
    {
        [Key]
        public Guid EarningId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AddDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ChangeDate { get; set; }

        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public Guid? AgreementId { get; set; }

        public ICollection<PartialEarning> PartialEarnings { get; set; }

        public Earning()
        {
            EarningId = Guid.NewGuid();
            AddDate = DateTime.Now;
            AgreementId = null;
        }
    }
}