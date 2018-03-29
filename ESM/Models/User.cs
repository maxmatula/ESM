using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ESM.Models
{
    public class User
    {
        public Guid UserId { get; protected set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string Salt { get; set; }
        public string AvatarPath { get; set; }
        public bool IsActive { get; set; }
        private int RoleId { get; set; }


        public User()
        {
            UserId = Guid.NewGuid();
        }
    }
}