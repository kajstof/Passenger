using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>()
        {
            new User("user1@user.com", "User1", "secret", "salt"),
            new User("user2@user.com", "User2", "secret", "salt"),
            new User("user3@user.com", "User3", "secret", "salt")
        };

        public async Task<User> GetAsync(Guid id)
        {
            return await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));
        }

        public async Task<User> GetAsync(string email)
        {
            return await Task.FromResult(_users.SingleOrDefault(x => x.Email.Equals(email.ToLowerInvariant())));
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.FromResult(_users);
        }

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}