using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace ApplicationCore.Entities
{
    public class User:IdentityUser
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? HashedPassword { get; set; }
        public string? Salt { get; set; }
        public List<Review> UserReview { get; set; }
        public List<Favorite> UserFavorite { get; set; }
        public List<Purchase> UserPurchase { get; set; }
        public List<UserRole> UserName { get; set; }
    }
}
