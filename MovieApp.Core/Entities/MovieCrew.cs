using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MovieApp.Core.Entities
{
    public class MovieCrew
    {
        public Movie MovieId { get; set; }

        public Crew CrewId { get; set; }

        [Required]
        [Column(TypeName = "Varchar(128)")]
        public string Department { get; set; }

        [Required]
        [Column(TypeName = "Varchar(128)")]
        public string Job { get; set; }
    }
}
