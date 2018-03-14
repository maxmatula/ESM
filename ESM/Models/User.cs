﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESM.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarPath { get; set; }
        public bool IsActive { get; set; }
        private int RoleId { get; set; }
    }
}