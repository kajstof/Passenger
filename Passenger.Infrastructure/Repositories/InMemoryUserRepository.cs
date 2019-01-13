using System;
using System.Collections.Generic;
using Passenger.Core.Domain;
using Passenger.Core.Repository;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public User Get(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}