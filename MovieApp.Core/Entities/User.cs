﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Column(TypeName = "Varchar(128)")]
        public string FirstName { get; set; }

        [Column(TypeName = "Varchar(128)")]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "Varchar(256)")]
        public string Email { get; set; }

        [Column(TypeName = "Varchar(1024)")]
        public string HashedPassword { get; set; }

        [Column(TypeName = "Varchar(1024)")]
        public string Salt { get; set; }

        [Column(TypeName = "Varchar(16)")]
        public string PhoneNumber { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime LockoutEndDate { get; set; }

        public DateTime LastLoginDateTime { get; set; }

        public bool IsLocked { get; set; }

        public int AccessFailedCount { get; set; }

    }
}
