using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SonicParks.Core.Domain.Interfaces.Services {

    public interface IBaseService<TEntity> : IDisposable where TEntity : class {

        IEnumerable<TEntity> Get();

        Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression);

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);

        TEntity Find(params object[] key);

        TEntity First(Expression<Func<TEntity, bool>> expression);

        TEntity Insert(TEntity entity);

        Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken);

        TEntity Update(TEntity entity);

        bool Exists(Expression<Func<TEntity, bool>> expression);

        int Count(Expression<Func<TEntity, bool>> expression);

        IEnumerable<TEntity> Delete(Expression<Func<TEntity, bool>> expression);

        long LongCount();

        long LongCount(Expression<Func<TEntity, bool>> expression);

        bool Commit();

        Task<bool> CommitAsync(CancellationToken cancellationToken);

    }

}
