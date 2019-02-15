using Microsoft.EntityFrameworkCore;
using SonicParks.Core.Domain.Interfaces.Persistence;
using SonicParks.Core.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SonicParks.Core.Infrastructure.Data.Persistence {

    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class {

        private BaseContext context;

        public UnitOfWork(BaseContext context) {

            this.context = context;

        }

        public virtual bool Commit() {

            return context.SaveChanges() > 0;

        }

        public virtual async Task<bool> CommitAsync(CancellationToken cancellationToken) {

            return await context.SaveChangesAsync(cancellationToken) > 0;

        }

        public void Dispose() {

            if (context != null) {

                context.Dispose();

            }

            GC.SuppressFinalize(this);

        }

    }

}
