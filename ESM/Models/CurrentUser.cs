using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESM.Models
{
    public class CurrentUser
    {
        public int UserId { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}