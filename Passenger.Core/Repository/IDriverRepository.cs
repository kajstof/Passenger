using System;
using System.Collections.Generic;
using Passenger.Core.Domain;

namespace Passenger.Core.Repository
{
    public interface IDriverRepository
    {
        Driver Get(Guid userId); 
        IEnumerable<Driver> GetAll();
        void Add(Driver driver);
        void Update(Driver driver);
    }
}