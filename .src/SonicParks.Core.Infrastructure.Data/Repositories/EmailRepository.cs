﻿using SonicParks.Core.Domain.Entities;
using SonicParks.Core.Domain.Interfaces.Repositories;
using SonicParks.Core.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicParks.Core.Infrastructure.Data.Repositories.Users {

    public class EmailRepository : Repository<EmailEntity>, IEmailRepository {

        public EmailRepository(BaseContext baseContext) : base(baseContext) {



        }

    }

}
