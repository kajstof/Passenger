using System;
using System.ComponentModel.Design;
using Passenger.Core.Domain;
using Passenger.Core.Repository;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto Get(string email)
        {
            var user = _userRepository.Get(email);
            return new UserDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName
            };
        }

        public void Register(string email, string userName, string password)
        {
            var user = _userRepository.Get(email);
            if (user != null)
            {
                throw new Exception($"User with email: '{email}' already exists.");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, userName, password, salt);
            _userRepository.Add(user);
        }
    }
}