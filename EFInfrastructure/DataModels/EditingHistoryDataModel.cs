using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInfrastructure.DataModels
{
    public class EditingHistoryDataModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string OperationType { get; set; }
        public string ContentType { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
