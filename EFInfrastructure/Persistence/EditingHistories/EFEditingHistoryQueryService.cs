using ApplicationService.EditingHistories;
using ApplicationService.EditingHistories.GetRange;
using EFInfrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInfrastructure.Persistence.EditingHistories
{
    public class EFEditingHistoryQueryService : IEditingHistoryQueryService
    {
        private readonly SBIDbContext _context;
        private readonly int _limit = 20;

        public EFEditingHistoryQueryService(
            SBIDbContext context)
        {
            _context = context;
        }

        public EditingHistoryGetRangeResult GetRange(EditingHistoryGetRangeCommand command)
        {
            var items = from EditingHistory in _context.EditingHistories
                        join User in _context.Users on EditingHistory.UserId equals User.Id
                        select new
                        {
                            EditingHistory,
                            User
                        };

            // 最新のものから順に並び替え
            items = items.OrderByDescending(x => x.EditingHistory.CreateTime);

            // 件数
            int resultNumber = items.Count();
            int pageNumber = (int)Math.Ceiling((double)resultNumber / _limit);

            // ページで抜き出し
            var page = (command.Page > 0) ? command.Page : 1;
            items = items.Skip((page - 1) * _limit).Take(_limit);

            var editingHistories = items.Select(x => new EditingHistoryDataForQuery
            {
                UserId = x.User.Id,
                UserName = x.User.Name,
                UserImage = x.User.Image,
                OperationType = x.EditingHistory.OperationType,
                ContentType = x.EditingHistory.ContentType,
                Content = x.EditingHistory.Content,
                CreateTime = x.EditingHistory.CreateTime
            }).ToList();

            var result = new EditingHistoryGetRangeResult
            {
                EditingHistories = editingHistories,
                PageNumber = pageNumber,
                ResultNumber = resultNumber
            };
            return result;
        }
    }
}
