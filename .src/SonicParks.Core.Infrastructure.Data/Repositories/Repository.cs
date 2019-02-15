using Microsoft.EntityFrameworkCore;
using SonicParks.Core.Domain.Interfaces.Repositories;
using SonicParks.Core.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SonicParks.Core.Infrastructure.Data.Repositories {

    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class {

        private BaseContext context;

        public Repository(BaseContext context) {

            this.context = context;

        }

        public virtual IQueryable<TEntity> Get() {

            return context.Set<TEntity>();

        }

        public virtual async Task<IQueryable<TEntity>> GetAsync(CancellationToken cancellationToken) {

            var result = await context.Set<TEntity>().ToListAsync(cancellationToken);
            return result.AsQueryable();

        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression) {

            return context.Set<TEntity>().Where(expression);

        }

        public virtual async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken) {

            var result = await context.Set<TEntity>().Where(expression).ToListAsync(cancellationToken);
            return result.AsQueryable();

        }

        public virtual TEntity Find(params object[] key) {

            return context.Set<TEntity>().Find(key);

        }

        public virtual TEntity First(Expression<Func<TEntity, bool>> expression) {

            return context.Set<TEntity>().FirstOrDefault(expression);

        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> expression) {

            return context.Set<TEntity>().Any(expression);

        }

        public virtual TEntity Insert(TEntity entity) {

            return context.Set<TEntity>().Add(entity).Entity;

        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken) {

            return (await context.Set<TEntity>().AddAsync(entity, cancellationToken)).Entity;

        }

        public virtual TEntity Update(TEntity entity) {

            context.Entry(entity).State = EntityState.Modified;
            return entity;

        }

        public virtual IQueryable<TEntity> Delete(Expression<Func<TEntity, bool>> expression) {

            IQueryable<TEntity> remove = context.Set<TEntity>().Where(expression);
            context.Set<TEntity>().RemoveRange(remove);
            return remove;

        }

        public virtual int Count(Expression<Func<TEntity, bool>> expression) {

            return context.Set<TEntity>().Count(expression);

        }

        public void Dispose() {

            if (context != null) {

                context.Dispose();

            }

            GC.SuppressFinalize(this);

        }

        public long LongCount() {

            return context.Set<TEntity>().LongCount();

        }

        public long LongCount(Expression<Func<TEntity, bool>> expression) {

            return context.Set<TEntity>().LongCount(expression);

        }

    }

}
