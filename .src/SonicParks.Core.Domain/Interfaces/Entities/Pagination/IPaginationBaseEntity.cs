using SonicParks.Core.CrossCutting.Enumerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicParks.Core.Domain.Interfaces.Entities.Pagination {

    public interface IPaginationBaseEntity {

        uint Page { get; set; }
        uint PageSize { get; set; }
        Order Order { get; set; }
        string OrderColumn { get; set; }
        ushort Shortcuts { get; set; }

    }

}
