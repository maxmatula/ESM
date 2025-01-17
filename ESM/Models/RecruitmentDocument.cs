﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESM.Models
{
    [Table("RecruitmentDocuments")]
    public class RecruitmentDocument
    {
        [Key]
        public Guid DocumentId { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        public string FilePath { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data dodania")]
        public DateTime AddDate { get; set; }
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public RecruitmentDocument()
        {
            this.DocumentId = Guid.NewGuid();
            this.AddDate = DateTime.Now;
        }
    }
}