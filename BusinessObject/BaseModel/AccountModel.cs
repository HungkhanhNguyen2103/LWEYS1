﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class AccountModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        //public int Gender { get; set; }
        public string? Address { get; set; }
    }
}
