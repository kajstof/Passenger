using System;
using System.Collections.Generic;
using System.Linq;
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

        public User Get(Guid id)
        {
            return _users.SingleOrDefault(x => x.Id == id);
        }

        public User Get(string email)
        {
            return _users.SingleOrDefault(x => x.Email.Equals(email.ToLowerInvariant()));
        }

        public IEnumerable<User> GetAll() => _users;
        
        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Remove(Guid id)
        {
            _users.Remove(Get(id));
        }

        public void Update(User user)
        {
        }
    }
}