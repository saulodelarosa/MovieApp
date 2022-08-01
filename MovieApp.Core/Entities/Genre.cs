using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MovieApp.Core.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Varchar(64)")]
        public string Name { get; set; }
    }
}
