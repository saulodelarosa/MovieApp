﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Entities
{
    public class MovieGenre
    {
        public Movie MovieId { get; set; }
        public Genre GenreId { get; set; }
    }
}
