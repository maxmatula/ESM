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
        [DataType(DataType.Text)]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data rozpoczęcia")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data zakończenia")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data dodania")]
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