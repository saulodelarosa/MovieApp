using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository;
        public GenreService(IGenreRepository _gen)
        {
            genreRepository = _gen;
        }
        public async Task<IEnumerable<GenreModel>> GetAllGenresAsync()
        {
            var data = await genreRepository.GetAllAsync();
            if (data != null)
            {
                List<GenreModel> model = new List<GenreModel>();
                foreach (var item in data)
                {
                    GenreModel m = new GenreModel();
                    m.Id = item.Id;
                    m.Name = item.Name;
                    model.Add(m);
                }
                return model;
            }
            return null;
        }

        public async Task<int> InsertGenreAsync(GenreModel model)
        {

            Genre g = new Genre();

            g.Name = model.Name;
            return await genreRepository.InsertAsync(g);

        }
        public async Task<int> DeleteGenreAsync(int id)
        {
            return await genreRepository.DeleteAsync(id);
        }

        public async Task<int> UpdateGenreAsync(GenreModel model)
        {
            Genre g = new Genre() { Id = model.Id, Name = model.Name };
            return await genreRepository.UpdateAsync(g);
        }
    }
}
