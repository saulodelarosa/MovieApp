using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Infrastructure.Data
{
    public class CustomerCrmDbContext:DbContext
    {
        public CustomerCrmDbContext(DbContextOptions<CustomerCrmDbContext> options):base(options)
        {

        }

        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Trailer> Trailer { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<MovieCrew> MovieCrew { get; set; }

    }
}
