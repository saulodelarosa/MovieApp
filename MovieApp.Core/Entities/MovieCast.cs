using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MovieApp.Core.Entities
{
    public class MovieCast
    {
        public Movie MovieId { get; set; }

        public Cast CastId { get; set; }

        [Required]
        [Column(TypeName = "Varchar(450)")]
        public string Character { get; set; }
    }
}
