using SonicParks.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicParks.Core.Domain.Interfaces.Entities {

    public interface IUserEmailEntity {

        int UserID { get; set; }
        int EmailID { get; set; }
        UserEntity User { get; set; }
        EmailEntity Email { get; set; }

    }

}
