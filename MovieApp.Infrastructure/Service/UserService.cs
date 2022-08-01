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
    public class UserService : IUserService
    {
        IUserRepository UserRepository;
        public UserService(IUserRepository _UserRepository)
        {
            UserRepository = _UserRepository;
        }
        public Task<int> InsertUser(UserModel UserModel)
        {
            User UserEntity = new User();
            UserEntity.FirstName = UserModel.FirstName;
            return UserRepository.InsertAsync(UserEntity);

        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            var result = await UserRepository.GetAllAsync();

            List<UserModel> Users = new List<UserModel>();
            if (result != null)
            {
                foreach (var item in result)
                {
                    UserModel r = new UserModel();
                    r.Id = item.Id;
                    r.FirstName = item.FirstName;
                    Users.Add(r);
                }
            }
            return Users;
        }

        public Task<int> DeleteUserAsync(int id)
        {
            return UserRepository.DeleteAsync(id);
        }

        public Task<int> UpdateUserAsync(UserModel model)
        {
            User UserEntity = new User();
            UserEntity.FirstName = model.FirstName;
            UserEntity.Id = model.Id;
            return UserRepository.UpdateAsync(UserEntity);
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            User entity = await UserRepository.GetByIdAsync(id);
            if (entity != null)
            {
                UserModel UserModel = new UserModel()
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName
                };
                return UserModel;
            }
            return null;
        }
    }
}
