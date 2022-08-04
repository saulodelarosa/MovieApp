using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        IUserRepository userRepository;
        public AccountService(IUserRepository _user)
        {
            userRepository = _user;
        }
        public async Task<int> Register(UserRegisterRequestModel user)
        {
            var existingUser =  await userRepository.GetUserByEmail(user.Email);
            if (existingUser != null)
            {
                throw new Exception("Email is already existing");
            }
            //register the user with salt and hashing
            //create a random salt
            var salt = GenerateSalt();
            var password = GetHashedPassword(user.Password, salt);
            User u = new User()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Salt = salt,
                HashedPassword = password,
                DateOfBirth = DateTime.UtcNow

            };
            return await userRepository.InsertAsync(u);
        }
        private string GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var randomSalt = RandomNumberGenerator.Create())
            {
                randomSalt.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        private string GetHashedPassword(string password, string salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(password, Convert.FromBase64String(salt), KeyDerivationPrf.HMACSHA512, 100000, 128 / 8)
                );
            return hashed;
        }

        public async Task<UserLoginResponseModel> Validate(string email, string password)
        {
            var user = await userRepository.GetUserByEmail(email);
            if (user == null)
                throw new Exception("Email does not exist");
            var hashPassword = GetHashedPassword(password, user.Salt);
            if (hashPassword == user.HashedPassword)
            {
                return new UserLoginResponseModel() { Id = user.Id, FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = email,
                    DateOfBirth = user.DateOfBirth.GetValueOrDefault()
                };
            }
            return null;
        }
    }
}
