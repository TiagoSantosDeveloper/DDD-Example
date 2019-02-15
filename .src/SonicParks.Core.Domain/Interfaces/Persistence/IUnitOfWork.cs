using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SonicParks.Core.Domain.Interfaces.Persistence {

    public interface IUnitOfWork<TEntity> : IDisposable where TEntity : class {

        bool Commit();
        Task<bool> CommitAsync(CancellationToken cancellationToken);

    }

}
