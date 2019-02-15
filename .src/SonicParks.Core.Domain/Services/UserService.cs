using SonicParks.Core.CrossCutting.Locality;
using SonicParks.Core.Domain.Entities;
using SonicParks.Core.Domain.Interfaces.Entities;
using SonicParks.Core.Domain.Interfaces.Persistence;
using SonicParks.Core.Domain.Interfaces.Repositories;
using SonicParks.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using SonicParks.Core.CrossCutting.Util.Security;

namespace SonicParks.Core.Domain.Services {

    public class UserService : BaseService<UserEntity>, IUserService {

        IUserRepository userRepository;
        IUnitOfWork<UserEntity> unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork<UserEntity> unitOfWork) : base(userRepository, unitOfWork) {

            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;

        }

        public async Task<UserEntity> New(UserEntity userEntity, CancellationToken cancellationToken) {

            if (!string.IsNullOrEmpty(userEntity.NewPassword) && !string.IsNullOrEmpty(userEntity.NewPasswordConfirm)) {

                if (userEntity.UsersEmails == null || !await userRepository.EmailExists(userEntity.UsersEmails, cancellationToken)) {

                    userEntity.Login = "user" + DateTime.Now.ToBinary();
                    userEntity.Password = userEntity.NewPassword.EncryptMD5();
                    return Insert(userEntity);

                }

            }

            return null;

        }

    }

}
