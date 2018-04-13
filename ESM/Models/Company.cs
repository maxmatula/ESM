﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ESM.Models
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public string Logo { get; set; }

        public string Description { get; set; }
        public decimal TotalEarnings { get; set; }

        public UserCompanyRef UserCompanyRef { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public Company()
        {
            Id = Guid.NewGuid();
        }

    }


}