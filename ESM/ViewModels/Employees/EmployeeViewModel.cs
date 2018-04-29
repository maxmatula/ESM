using ESM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ESM.ViewModels.Employees
{
    public class EmployeeViewModel
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public string Title { get; set; }
        public decimal CurrentEarnings { get; set; }
        public byte[] PictureData { get; set; }
        public string PictureMimeType { get; set; }
        public Guid CompanyId { get; set; }
        public Company Companies { get; set; }
        public List<Earning> Earnings { get; set; }
        public List<RecruitmentDocument> RecruitmentDocuments { get; set; }
        public List<Certyfication> Certyfications { get; set; }
        public List<Agreement> Agreements { get; set; }
    }
}
