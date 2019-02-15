using SonicParks.Core.Domain.Entities;
using SonicParks.Core.Domain.Interfaces.Repositories;
using SonicParks.Core.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace SonicParks.Core.Infrastructure.Data.Repositories.Users {

    public class UserRepository : Repository<UserEntity>, IUserRepository {

        private BaseContext baseContext;

        public UserRepository(BaseContext baseContext) : base(baseContext) {

            this.baseContext = baseContext;

        }

        public async Task<IEnumerable<EmailEntity>> GetEmails(int idUser, CancellationToken cancellationToken) {

            return await baseContext.Set<UserEmailEntity>()
                .Where(w => w.UserID == idUser)
                .Select(s => s.Email)
                .ToListAsync(cancellationToken);

        }

        public async Task<bool> EmailExists(ICollection<UserEmailEntity> userEmails, CancellationToken cancellationToken) {

            return await baseContext.Set<EmailEntity>()
                .Join(userEmails.Select(s => s.Email.Email), a => a.Email, b => b, (a, b) => a)
                .CountAsync(cancellationToken) > 0;

        }

    }

}
