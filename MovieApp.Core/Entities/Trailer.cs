
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MovieApp.Core.Entities
{
    public class Trailer
    {
        public int Id { get; set; }
        public Movie MovieId { get; set; }

        [Column(TypeName = "Varchar(2084)")]
        public string TrailerUrl { get; set; }

        [Column(TypeName = "Varchar(2084)")]
        public string Name { get; set; }
    }
}
