using System;
using Benton.EF.Core;
using Microsoft.EntityFrameworkCore;

namespace Benton.EF.Repository
{
    public class Repository : ReadOnlyRepository, IRepository
        // where TContext : DbContext
    {
        public Repository(DbContext context)
            : base(context)
        {
        }

        public virtual TEntity Create<TEntity>(TEntity entity, string createdBy = null)
            where TEntity : class, IEntity
        {
            entity.CreatedDate = new DateTimeOffset(DateTime.UtcNow);
            entity.CreatedBy = createdBy;

            context.Set<TEntity>().Add(entity);

            return entity;
        }

        public virtual TEntity Update<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : class, IEntity
        {
            entity.ModifiedDate = new DateTimeOffset(DateTime.UtcNow);
            entity.ModifiedBy = modifiedBy;

            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public virtual void Delete<TEntity>(object id)
            where TEntity : class, IEntity
        {
            TEntity entity = context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public virtual void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            var dbSet = context.Set<TEntity>();
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

    }
    
}