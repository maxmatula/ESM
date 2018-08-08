using ESM.Models;
using ESM.ViewModels.Earnings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ESM.ViewModels.Employees
{
    public class EmployeeViewModel
    {
        public Guid EmployeeId { get; set; }
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data urodzenia")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Stanowisko")]
        public string Title { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "PESEL")]
        public string IdentityNumber { get; set; } //pesel
        [Display(Name = "Adress")]
        public string Address { get; set; }
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        [Display(Name = "Status cywilny")]
        public string MaritalStatus { get; set; }
        [Display(Name = "Notatki")]
        public string AdditionalInfo { get; set; } //notatki
        [Display(Name = "Nazwa banku")]
        public string BankName { get; set; }
        [Display(Name = "Numer konta")]
        public string BankAccountNumber { get; set; }
        [Display(Name = "Obecne zarobki")]
        public string CurrentEarnings { get; set; }
        public byte[] PictureData { get; set; }
        public string PictureMimeType { get; set; }
        public Guid CompanyId { get; set; }
        public Company Companies { get; set; }
        public List<EarningForDisplayDto> Earnings { get; set; }
        public List<RecruitmentDocument> RecruitmentDocuments { get; set; }
        public List<Certyfication> Certyfications { get; set; }
        public List<Agreement> Agreements { get; set; }
    }
}
