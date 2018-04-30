using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESM.Models
{
    [Table("Agreements")]
    public class Agreement
    {
        [Key]
        public Guid AgreementId { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime AddDate { get; set; }
        public string FilePath { get; set; }
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public Agreement()
        {
            this.AgreementId = Guid.NewGuid();
            this.AddDate = DateTime.Now;
        }

    }
}