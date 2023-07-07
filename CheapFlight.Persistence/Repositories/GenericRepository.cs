using CheapFlight.Persistence.Data;
using CheapFlights.Application.Interfaces;
using CheapFlights.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CheapFlight.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected FlightContext _flightContext;

        public GenericRepository(FlightContext flightContext)
        {
            _flightContext = flightContext;
        }

        public void Add(T entity)
        {
            _flightContext.Set<T>().Add(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        //public Task<IEnumerable<T>> GetAllAsync()
        //{
        //   return _flightContext.Set<T>().ToListAsync();
        //}

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _flightContext.Set<T>().ToListAsync();
        }

        public Task<T> GetByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
