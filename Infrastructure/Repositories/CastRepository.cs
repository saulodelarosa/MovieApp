using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CastRepository:BaseRepository<Cast>,ICastRepository
    {
        MovieWebAppDbContext _db;
        public CastRepository(MovieWebAppDbContext dbContext):base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<Cast> GetCastAsync(int id)
        {
            return await _db.Casts.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
