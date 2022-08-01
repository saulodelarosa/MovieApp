﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Entities
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Varchar(20)")]
        public string Name { get; set; }
    }
}
