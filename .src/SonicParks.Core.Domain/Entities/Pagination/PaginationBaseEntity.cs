using SonicParks.Core.CrossCutting.Enumerator;
using SonicParks.Core.Domain.Interfaces.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicParks.Core.Domain.Entities.Pagination {

    public class PaginationBaseEntity : IPaginationBaseEntity {

        public uint Page { get; set; }
        public uint PageSize { get; set; }
        public Order Order { get; set; }
        public string OrderColumn { get; set; }
        public ushort Shortcuts { get; set; }

    }

}
