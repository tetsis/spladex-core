using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.EditingHistories.GetRange
{
    public class EditingHistoryDataForQuery
    {
        public string UserId { get; init; }
        public string UserName { get; init; }
        public string UserImage { get; init; }
        public string OperationType { get; init; }
        public string ContentType { get; init; }
        public string Content { get; init; }
        public DateTime CreateTime { get; init; }
    }
}
