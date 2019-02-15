using AutoMapper;
using SonicParks.Core.Application.Interfaces.AppServices;
using SonicParks.Core.Application.Interfaces.ViewsModels;
using SonicParks.Core.Application.ViewsModels;
using SonicParks.Core.CrossCutting.AutoMap.EntityMapping;
using SonicParks.Core.Domain.Entities;
using SonicParks.Core.Domain.Interfaces.Entities;
using SonicParks.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SonicParks.Core.Application.AppServices {

    public class UserAppService : IUserAppService {

        private IUserService userService;

        public UserAppService(IUserService userService) {

            this.userService = userService;

        }

        public async Task<UserRegisterViewModel> New(IUserRegisterViewModel userViewModel, CancellationToken cancellationToken) {

            await userService.New(AutoMapping.Convert<IUserRegisterViewModel, UserEntity>(userViewModel), cancellationToken);

            if (await userService.CommitAsync(cancellationToken)) {

                return userViewModel as UserRegisterViewModel;

            }
            else {

                throw new Exception("Usuário não foi salvo.");

            }

        }

        public async Task<IList<UserRegisterViewModel>> List(CancellationToken cancellationToken) {

            IList<UserRegisterViewModel> result = new List<UserRegisterViewModel>();
            IEnumerable<UserEntity> users = await userService.GetAsync(cancellationToken);

            if (users != null) {

                foreach (UserEntity item in users) {

                    //result.Add(new UserRegisterViewModel {
                    //    Active = item.Active,
                    //    Login = item.Login,
                    //    Password = item.Password,
                    //    UserID = item.UserID
                    //});

                }

            }

            return result;

        }

    }

}
