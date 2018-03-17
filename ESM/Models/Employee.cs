using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ESM.Models
{
    public class Employee
    {
  
        public Guid Id { get; protected set; } //Guid to zmienna typu General Identity Number
        public string Name { get;  set; }
        public string Surname { get; set; }
        public string BirthDate { get;  set; }
        public string Title { get;  set; }
        public string Picture { get; set; }


        public Employee()
        {
            Id = Guid.NewGuid(); //Inicjacja unikalnego id Pracownika
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