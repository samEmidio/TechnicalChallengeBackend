using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Domain.Core.Entity;
using TechnicalChallenge.Domain.Interfaces.Repositories;
using TechnicalChallenge.Infra.Data.Context;

namespace TechnicalChallenge.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly TechnicalChallengeContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(TechnicalChallengeContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }


        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            Db.AddRange(entities);
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual IQueryable<TEntity> GetAllDesc()
        {
            return DbSet.OrderByDescending(x => x.CreatedBy);
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
