using MovieApp.Core.Contracts.Repository;
using MovieApp.Core.Contracts.Service;
using MovieApp.Core.Entities;
using MovieApp.Core.Models;
using MovieApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Infrastructure.Service
{
    public class CastService : ICastService
    {
        ICastRepository CastRepository;
        public CastService(ICastRepository _CastRepository)
        {
            CastRepository = _CastRepository;
        }
        public Task<int> InsertCast(CastModel CastModel)
        {
            Cast CastEntity = new Cast();
            CastEntity.Name = CastModel.Name;
            return CastRepository.InsertAsync(CastEntity);

        }

        public async Task<IEnumerable<CastModel>> GetAllCasts()
        {
            var result = await CastRepository.GetAllAsync();

            List<CastModel> Casts = new List<CastModel>();
            if (result != null)
            {
                foreach (var item in result)
                {
                    CastModel r = new CastModel();
                    r.Id = item.Id;
                    r.Name = item.Name;
                    Casts.Add(r);
                }
            }
            return Casts;
        }

        public Task<int> DeleteCastAsync(int id)
        {
            return CastRepository.DeleteAsync(id);
        }

        public Task<int> UpdateCastAsync(CastModel model)
        {
            Cast CastEntity = new Cast();
            CastEntity.Name = model.Name;
            CastEntity.Id = model.Id;
            return CastRepository.UpdateAsync(CastEntity);
        }

        public async Task<CastModel> GetCastByIdAsync(int id)
        {
            Cast entity = await CastRepository.GetByIdAsync(id);
            if (entity != null)
            {
                CastModel CastModel = new CastModel()
                {
                    Id = entity.Id,
                    Name = entity.Name
                };
                return CastModel;
            }
            return null;
        }
    }
}
