using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ESM.Models
{
    public class UserCompanyReference
    {
        [Key]
        public Guid Id { get; set; }

        //klucz obcy do tabeli User
        public string UserId { get; set; }
        public User User { get; set; }

        //klucz obcy do tabeli Company
        public string CompanyId { get; set; }
        public Company Company { get; set; }

        public UserCompanyReference()
        {
            Id = Guid.NewGuid();
        }
    }
}