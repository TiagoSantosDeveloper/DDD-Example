using SonicParks.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicParks.Core.Application.Interfaces.ViewsModels {

    public interface IUserRegisterViewModel {

        string NewPassword { get; set; }
        string NewPasswordConfirm { get; set; }
        string Email { get; set; }

    }

}
