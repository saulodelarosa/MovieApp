
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Core.Entities
{
    public class Review
    {

        public Movie MovieId { get; set; }

        public User UserId { get; set; }

        [Required]
        [Column(TypeName = "decimal(3,2)")]
        public decimal Rating { get; set; }

        public string ReviewText { get; set; }
    }

}
}
