using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly MovieWebAppDbContext _db;
        public UserRepository(MovieWebAppDbContext context) : base(context)
        {
            _db = context;
        }
        public async Task<User> GetUserByEmail(string email)
        {
            return await _db.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}
