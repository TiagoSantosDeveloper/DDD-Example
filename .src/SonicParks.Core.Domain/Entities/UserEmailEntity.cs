using SonicParks.Core.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicParks.Core.Domain.Entities {

    public class UserEmailEntity : IUserEmailEntity {

        public int UserID { get; set; }
        public int EmailID { get; set; }
        public UserEntity User { get; set; }
        public EmailEntity Email { get; set; }

    }

}
