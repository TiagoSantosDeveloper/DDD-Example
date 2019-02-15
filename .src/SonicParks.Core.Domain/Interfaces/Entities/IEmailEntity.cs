using SonicParks.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicParks.Core.Domain.Interfaces.Entities {

    public interface IEmailEntity {

        int EmailID { get; set; }
        string Email { get; set; }
        bool Active { get; set; }
        ICollection<UserEmailEntity> UsersEmails { get; set; }

    }

}
