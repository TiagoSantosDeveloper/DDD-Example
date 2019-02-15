using SonicParks.Core.Domain.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SonicParks.Core.Domain.Interfaces.Repositories {

    public interface IRepository<TEntity> : IDisposable where TEntity : class {

        IQueryable<TEntity> Get();

        Task<IQueryable<TEntity>> GetAsync(CancellationToken cancellationToken);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);

        Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);

        TEntity Find(params object[] key);

        TEntity First(Expression<Func<TEntity, bool>> expression);

        TEntity Insert(TEntity entity);

        Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken);

        TEntity Update(TEntity entity);

        bool Exists(Expression<Func<TEntity, bool>> expression);

        int Count(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> Delete(Expression<Func<TEntity, bool>> expression);

        long LongCount();

        long LongCount(Expression<Func<TEntity, bool>> expression);

    }

}
