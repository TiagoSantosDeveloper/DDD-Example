using SonicParks.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicParks.Core.Application.Interfaces.ViewsModels {

    public interface IUserLoginViewModel {

        string Password { get; set; }
        string Email { get; set; }

    }

}
