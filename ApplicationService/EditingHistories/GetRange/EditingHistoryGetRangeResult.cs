using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.EditingHistories.GetRange
{
    public class EditingHistoryGetRangeResult
    {
        public List<EditingHistoryDataForQuery> EditingHistories { get; init; }
        public int PageNumber { get; init; }
        public int ResultNumber { get; init; }
    }
}
