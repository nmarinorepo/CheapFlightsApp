using CheapFlights.Domain.Common;
using System.Linq.Expressions;

namespace CheapFlights.Application.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync();
        Task<IReadOnlyList<T>> GetAllAsync();

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
    }
}
