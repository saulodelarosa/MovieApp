using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MovieApp.Core.Entities
{
    public class Favorite
    {
        public int Id { get; set; }
        public Movie MovieId { get; set; }
        public int UserId { get; set; }
    }
}
