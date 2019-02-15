using SonicParks.Core.Domain.Interfaces.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SonicParks.Core.Domain.Entities.Pagination {

    public class PaginationEntity<TEntity> : PaginationBaseEntity, IPaginationEntity<TEntity> where TEntity : class {

        public PaginationEntity(IPaginationBaseEntity pagination, bool pageActive, ulong recordsCount, IQueryable<TEntity> pageRecords) {

            PageFirst = 1;
            Page = pagination.Page;
            PageSize = pagination.PageSize;
            Order = pagination.Order;
            OrderColumn = pagination.OrderColumn;
            RecordsCount = recordsCount;
            Shortcuts = pagination.Shortcuts;
            PageActive = pageActive;
            Records = pageRecords;
            ShortcutPages = new List<PaginationEntity<TEntity>>();

            CalculatePages();

        }

        public uint PageNext { get; private set; }
        public uint PagePrev { get; private set; }
        public ulong RecordsCount { get; private set; }
        public uint PageFirst { get; private set; }
        public uint PageLast { get; private set; }
        public bool PageActive { get; private set; }
        public IEnumerable<PaginationEntity<TEntity>> ShortcutPages { get; private set; }
        public IQueryable<TEntity> Records { get; private set; }

        private void CalculatePages() {

            decimal totalPages = 0;

            if (RecordsCount > 0) {

                totalPages = (RecordsCount / PageSize);

                if (totalPages % 2 == 0) {

                    PageLast = (uint)totalPages;

                }
                else {

                    PageLast = (uint)totalPages + 1;

                }

            }

            if (Page >= PageLast) {

                PageNext = Page;

            }
            else {

                PageNext = Page + 1;

            }

            if (Page > 1) {

                PagePrev = Page - 1;

            }
            else {

                PagePrev = Page;

            }

        }

    }

}
