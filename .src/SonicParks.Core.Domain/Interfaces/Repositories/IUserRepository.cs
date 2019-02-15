using SonicParks.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SonicParks.Core.Domain.Interfaces.Repositories {

    public interface IUserRepository : IRepository<UserEntity> {

        Task<IEnumerable<EmailEntity>> GetEmails(int idUser, CancellationToken cancellationToken);
        Task<bool> EmailExists(ICollection<UserEmailEntity> userEmails, CancellationToken cancellationToken);

    }

}
