using SonicParks.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicParks.Core.Domain.Interfaces.Entities {

    public interface IUserEntity {

        int UserID { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        string NewPassword { get; set; }
        string NewPasswordConfirm { get; set; }
        bool Active { get; set; }
        ICollection<UserEmailEntity> UsersEmails { get; set; }

    }

}
