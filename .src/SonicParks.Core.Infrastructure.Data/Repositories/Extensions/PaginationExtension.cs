using Microsoft.EntityFrameworkCore;
using SonicParks.Core.Domain.Entities.Pagination;
using SonicParks.Core.Domain.Interfaces.Entities.Pagination;
using SonicParks.Core.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SonicParks.Core.Infrastructure.Data.Repositories.Extensions {

    public static class PaginationExtension {

        public static PaginationEntity<TEntity> ListPage<TEntity>(this IRepository<TEntity> repository, IPaginationBaseEntity paginationBase) where TEntity : class {

            return ListPage(repository, null, paginationBase);

        }

        public static PaginationEntity<TEntity> ListPage<TEntity>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> expression, IPaginationBaseEntity paginationBase) where TEntity : class {

            IQueryable<TEntity> records;
            PaginationEntity<TEntity> result;
            PaginationEntity<TEntity> shortcurts;
            short shortcutPrev = 0;
            short shortcutNext = 0;
            IList<PaginationEntity<TEntity>> shortcutPages = new List<PaginationEntity<TEntity>>();

            if (expression != null) {

                records = repository
                    .Get(expression)
                    .AsNoTracking()
                    .OrderBy(o => $"{paginationBase.OrderColumn} {paginationBase.Order}")
                    .Skip((int)((paginationBase.Page - 1) * paginationBase.PageSize))
                    .Take((int)paginationBase.PageSize);

                result = new PaginationEntity<TEntity>(paginationBase, true, (ulong)repository.LongCount(expression), records);

            }
            else {

                records = repository
                    .Get()
                    .AsNoTracking()
                    .OrderBy(o => $"{paginationBase.OrderColumn} {paginationBase.Order}")
                    .Skip((int)((paginationBase.Page - 1) * paginationBase.PageSize))
                    .Take((int)paginationBase.PageSize);

                result = new PaginationEntity<TEntity>(paginationBase, true, (ulong)repository.LongCount(), records);

            }

            #region Shortcuts

            if (result.Shortcuts % 2 == 0) {
                result.Shortcuts++;
            }

            shortcutPrev = Convert.ToInt16(result.Shortcuts / 2);
            shortcutNext = Convert.ToInt16(shortcutPrev + 1);

            if (shortcutPrev - (result.PageLast - result.Page) > 0) {
                shortcutPrev += Convert.ToInt16(shortcutPrev - (result.PageLast - result.Page));
            }

            //ShortCurtsPrev
            for (uint i = result.Page; i > 1; i--) {

                if (shortcutPages.Count < shortcutPrev) {

                    shortcurts = new PaginationEntity<TEntity>(paginationBase, false, result.RecordsCount, records);
                    shortcurts.Page = i - 1;
                    shortcutPages.Add(shortcurts);

                }
                else if (shortcutNext <= result.Shortcuts) {

                    shortcutNext++;

                }
                else {

                    break;

                }

            }

            //ShortCurtsActual
            shortcutPages.Add(result);

            //ShortCurtsNext
            for (uint i = result.Page; i < result.PageLast; i++) {

                if (shortcutPages.Count < result.Shortcuts) {

                    shortcurts = new PaginationEntity<TEntity>(paginationBase, false, result.RecordsCount, records);
                    shortcurts.Page = i + 1;
                    shortcutPages.Add(shortcurts);

                }
                else {

                    break;

                }

            }

            (result.ShortcutPages as List<PaginationEntity<TEntity>>).AddRange(shortcutPages.OrderBy(o => o.Page));

            #endregion

            return result;

        }

    }

}
