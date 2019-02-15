using SonicParks.Core.Application.Interfaces.ViewsModels;
using SonicParks.Core.Application.ViewsModels;
using SonicParks.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SonicParks.Core.Application.Interfaces.AppServices {

    public interface IUserAppService {

        Task<UserRegisterViewModel> New(IUserRegisterViewModel userViewModel, CancellationToken cancellationToken);
        Task<IList<UserRegisterViewModel>> List(CancellationToken cancellationToken);

    }

}
