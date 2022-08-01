using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Entities
{
    public class Crew
    {
        public int id { get; set; }

        [Column(TypeName = "Varchar(128)")]
        public string name { get; set; }

        public string Gender { get; set; }

        public string TmdbUrl { get; set; }

        [Column(TypeName = "Varchar(2084)")]
        public string ProfilePath { get; set; }
    }
}
