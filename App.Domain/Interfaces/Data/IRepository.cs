using App.Domain.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetListAllAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
