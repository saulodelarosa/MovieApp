using MovieApp.Core.Contracts.Repository;
using MovieApp.Core.Entities;
using MovieApp.Infrastructure.Data;
using MovieApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Infrastructure.Repository
{
    public class MovieRepository : BaseRepositoryAsync<Cast>, IMovieRepository
    {
        public MovieRepository(CustomerCrmDbContext _context) : base(_context)
        {
        }
    }
}
