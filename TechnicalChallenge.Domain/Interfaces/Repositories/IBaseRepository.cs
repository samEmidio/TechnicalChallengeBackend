using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalChallenge.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        void AddRange(IEnumerable<TEntity> entities);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllDesc();
        void Update(TEntity obj);
        void Remove(Guid id);
    }
}
