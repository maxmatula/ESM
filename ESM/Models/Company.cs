using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ESM.Models
{
    public class Company
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public string Logo { get; set; }

        public string Description { get; set; }
        public decimal TotalEarnings { get; set; }


        public Company()
        {
            Id = Guid.NewGuid();
        }

    }


}