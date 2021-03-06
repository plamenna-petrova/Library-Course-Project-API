﻿using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
