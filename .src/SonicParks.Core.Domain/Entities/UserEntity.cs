using SonicParks.Core.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicParks.Core.Domain.Entities {

    public class UserEntity : IUserEntity {

        public int UserID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirm { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<UserEmailEntity> UsersEmails { get; set; }

    }

}
