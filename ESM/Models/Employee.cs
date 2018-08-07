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
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        [DataType(DataType.Text)]
        [StringLength(60)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Date), Display(Name = "Data urodzenia")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Stanowisko")]
        [DataType(DataType.Text)]
        [StringLength(40)]
        public string Title { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "PESEL")]
        [StringLength(20)]
        public string IdentityNumber { get; set; } //pesel

        [Display(Name = "Adres")]
        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        public string Address { get; set; }

        [Display(Name = "Telefon")]
        [StringLength(12, ErrorMessage = "12 znaków jest maksymalną liczbą dla tego pola")]
        public string Phone { get; set; }

        [Display(Name = "Status związku")]
        [DataType(DataType.Text)]
        [StringLength(20)]
        [DisplayFormat(DataFormatString = "{0:###-###-###}", ApplyFormatInEditMode = true)]
        public string MaritalStatus { get; set; }

        [Display(Name = "Notatki")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "Maksymalnie 500 znaków!")]
        public string AdditionalInfo { get; set; } //notatki

        [Display(Name = "Nazwa Banku")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string BankName { get; set; }

        [Display(Name = "Numer konta bankowego")]
        [DataType(DataType.CreditCard)]
        [StringLength(40)]
        public string BankAccountNumber { get; set; }

        public byte[] PictureData { get; set; }

        [StringLength(50)]
        public string PictureMimeType { get; set; }

        public bool IsInArchive { get; set; } //czy pracownik w archiwum

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
            IsInArchive = false;
        }

        //private DateTime _exitDate { get; set; } // data zakończenia umowy

    }
}
