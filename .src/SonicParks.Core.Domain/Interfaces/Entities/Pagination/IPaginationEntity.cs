using SonicParks.Core.Domain.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SonicParks.Core.Domain.Interfaces.Entities.Pagination {

    public interface IPaginationEntity<TEntity> : IPaginationBaseEntity where TEntity : class {

        uint PageNext { get; }
        uint PagePrev { get; }
        uint PageFirst { get; }
        uint PageLast { get; }
        ulong RecordsCount { get; }
        bool PageActive { get; }
        IEnumerable<PaginationEntity<TEntity>> ShortcutPages { get; }
        IQueryable<TEntity> Records { get; }

    }

}
