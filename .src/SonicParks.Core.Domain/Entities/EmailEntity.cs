using SonicParks.Core.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicParks.Core.Domain.Entities {

    public class EmailEntity : IEmailEntity {

        public int EmailID { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<UserEmailEntity> UsersEmails { get; set; }

    }

}
