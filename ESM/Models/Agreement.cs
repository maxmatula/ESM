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

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime AddDate { get; set; }

        public string FilePath { get; set; }

        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public Guid? EarningId { get; set; }

        public Agreement()
        {
            AgreementId = Guid.NewGuid();
            AddDate = DateTime.Now;
            EarningId = null;
        }

    }
}