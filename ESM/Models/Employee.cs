using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ESM.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        [Required]
        [Display(Name = "Imię")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        [DataType(DataType.Text)]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.Date), Display(Name = "Data urodzenia")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name = "Stanowisko")]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        [Display(Name = "PESEL")]
        public int? IdentityNumber { get; set; } //pesel
        [Display(Name = "Adres")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Display(Name = "Status związku")]
        [DataType(DataType.Text)]
        public string MaritalStatus { get; set; }
        [Display(Name = "Notatki")]
        [DataType(DataType.MultilineText)]
        public string AdditionalInfo { get; set; } //notatki
        [Display(Name = "Nazwa Banku")]
        [DataType(DataType.Text)]
        public string BankName { get; set; }
        [Display(Name = "Numer konta bankowego")]
        public int? BankAccountNumber { get; set; }
        public byte[] PictureData { get; set; }
        [StringLength(50)]
        public string PictureMimeType { get; set; }
        [ForeignKey("Companies")]
        public Guid CompanyId { get; set; }
        public virtual Company Companies { get; set; }
        public virtual ICollection<Earning> Earnings { get; set; }
        public virtual ICollection<RecruitmentDocument> RecruitmentDocuments { get; set; }
        public virtual ICollection<Certyfication> Certyfications { get; set; }
        public virtual ICollection<Agreement> Agreements { get; set; }

        public Employee()
        {
            EmployeeId = Guid.NewGuid();
        }

        

        //private DateTime _exitDate { get; set; } // data zakończenia umowy

    }
}
