using SonicParks.Core.Domain.Interfaces.Persistence;
using SonicParks.Core.Domain.Interfaces.Repositories;
using SonicParks.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SonicParks.Core.Domain.Services {

    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class {

        private IRepository<TEntity> repository;
        private IUnitOfWork<TEntity> unitOfWork;

        public BaseService(IRepository<TEntity> repository, IUnitOfWork<TEntity> unitOfWork) {

            this.repository = repository;
            this.unitOfWork = unitOfWork;

        }

        public virtual IEnumerable<TEntity> Get() {

            return repository.Get();

        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken) {

            return await repository.GetAsync(cancellationToken);

        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression) {

            return repository.Get(expression);

        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken) {

            return await repository.GetAsync(expression, cancellationToken);

        }

        public virtual TEntity Find(params object[] key) {

            return repository.Find(key);

        }

        public virtual TEntity First(Expression<Func<TEntity, bool>> expression) {

            return repository.First(expression);

        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> expression) {

            return repository.Exists(expression);

        }

        public virtual TEntity Insert(TEntity entity) {

            return repository.Insert(entity);

        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken) {

            return await repository.InsertAsync(entity, cancellationToken);

        }

        public virtual TEntity Update(TEntity entity) {

            return repository.Update(entity);

        }

        public virtual IEnumerable<TEntity> Delete(Expression<Func<TEntity, bool>> expression) {

            return repository.Delete(expression);

        }

        public virtual int Count(Expression<Func<TEntity, bool>> expression) {

            return repository.Count(expression);

        }

        public virtual bool Commit() {

            return unitOfWork.Commit();

        }

        public virtual async Task<bool> CommitAsync(CancellationToken cancellationToken) {

            return await unitOfWork.CommitAsync(cancellationToken);

        }

        public void Dispose() {

            if (repository != null) {

                repository.Dispose();

            }

            GC.SuppressFinalize(this);

        }

        public long LongCount() {

            return repository.LongCount();

        }

        public long LongCount(Expression<Func<TEntity, bool>> expression) {

            return repository.LongCount(expression);

        }

    }

}
