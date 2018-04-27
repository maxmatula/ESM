using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ESM.Models
{
    [Table("Certyfications")]
    public class Certyfication
    {
        [Key]
        public Guid CertyficationId { get; set; }
        public string FileName { get; set; }
        public string FileMimeType { get; set; }
        public string FilePath { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AddDate { get; set; }
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public Certyfication()
        {
            this.CertyficationId = Guid.NewGuid();
            this.AddDate = DateTime.Now;
        }
    }
}