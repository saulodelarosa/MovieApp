using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }


        public async Task<IEnumerable<CastResponseModel>> GetAllCastAsyncAll()
        {
            var data = await _castRepository.GetAllAsync();
            if (data != null)
            {
                List<CastResponseModel> model = new List<CastResponseModel>();
                foreach (var item in data)
                {
                    CastResponseModel m = new CastResponseModel();
                    m.Id = item.Id;
                    m.Name = item.Name;
                    m.Gender = item.Gender;
                    m.TmdbUrl = item.TmdbUrl;
                    m.ProfilePath = item.ProfilePath;
                    model.Add(m);
                }
                return model;
            }
            return null;
        }



        public async Task<CastResponseModel> GetAllCastAsync(int id)
        {

            var castDeatil = await _castRepository.GetByIdAsync(id);

            var castModels = new CastResponseModel
            {
                Id = castDeatil.Id,
                Name = castDeatil.Name,
                Gender = castDeatil.Gender,
                TmdbUrl = castDeatil.TmdbUrl,
                ProfilePath = castDeatil.ProfilePath
            };

            
            return castModels;
        }

        public async Task<int> InsertCastAsync(CastResponseModel model)
        {

            Cast g = new Cast();
            g.Name = model.Name;
            g.Gender = model.Gender;
            g.TmdbUrl = model.TmdbUrl;
            g.ProfilePath = model.ProfilePath;

            return await _castRepository.InsertAsync(g);

        }
        public async Task<int> DeleteCastAsync(int id)
        {
            return await _castRepository.DeleteAsync(id);
        }

        public async Task<int> UpdateCastAsync(CastResponseModel model)
        {
            Cast g = new Cast() { 
                Id = model.Id,
                Name = model.Name,
                Gender = model.Gender,
                TmdbUrl = model.TmdbUrl,
                ProfilePath = model.ProfilePath,
        };
            return await _castRepository.UpdateAsync(g);
        }

    }
}
