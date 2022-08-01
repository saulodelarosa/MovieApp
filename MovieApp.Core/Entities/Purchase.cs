using System.ComponentModel.DataAnnotations;


namespace MovieApp.Core.Entities
{
    public class Purchase
    {
        public int Id { get; set; }

        [Required]
        public User UserId { get; set; }

        [Required]
        public int PurchaseNumber { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public decimal PurchaseDateTime { get; set; }

        public Movie MovieId { get; set; }
    }
}
