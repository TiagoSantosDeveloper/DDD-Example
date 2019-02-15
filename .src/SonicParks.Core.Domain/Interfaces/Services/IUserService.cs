using SonicParks.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SonicParks.Core.Domain.Interfaces.Services {

    public interface IUserService : IBaseService<UserEntity> {

        Task<UserEntity> New(UserEntity userEntity, CancellationToken cancellationToken);

    }

}
