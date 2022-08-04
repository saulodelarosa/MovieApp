using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? HashedPassword { get; set; }
        public string? Salt { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime? LockoutEndDate { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime? LastLoginDateTime { get; set; }
        public bool? IsLocked { get; set; }
        public int? AccessFailedCount { get; set; }
        public List<Review> UserReview { get; set; }
        public List<Favorite> UserFavorite { get; set; }
        public List<Purchase> UserPurchase { get; set; }
        public List<UserRole> UserName { get; set; }
    }
}
