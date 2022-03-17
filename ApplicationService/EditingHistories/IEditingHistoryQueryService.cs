using ApplicationService.EditingHistories.GetRange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.EditingHistories
{
    public interface IEditingHistoryQueryService
    {
        EditingHistoryGetRangeResult GetRange(EditingHistoryGetRangeCommand command);
    }
}
