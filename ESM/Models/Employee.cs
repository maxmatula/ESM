using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace ESM.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        [ForeignKey("Companies")]
        public Guid CompanyId { get; set; }
        public virtual Company Companies { get; set; }
        
        public Employee()
        {
            Id = Guid.NewGuid();
        }

        //private string _identityNumber { get; set; } //pesel
        //private string _address { get; set; }
        //private string _phone { get; set; }

        //private string _maritalStatus { get; set; }
        //private DateTime _employmentDate { get; set; } // data zatrudnienia
        //private DateTime _dismissalDate { get; set; } // data wygasnięcia umowy

        //private DateTime _exitDate { get; set; } // data zakończenia umowy
        //private string _additionalInfo { get; set; } // informacje dodatkowe (osoba do kontaktu w razie wypadku... itp.)

        //private decimal _earnings { get; set; }
        //private string _bank_name { get; set; }
        //private string _accountNumber { get; set; }
        //private string _taxOffice { get; set; }
        //private string _healthcareFund { get; set; } // kasa chorych

        //private Employee(string name, string surname, string title, string picture)
        //{
        //    this.Name = name;
        //    this.Surname = surname;
        //    this.Title = title;
        //    this.Picture = picture;
        //}
    }
}