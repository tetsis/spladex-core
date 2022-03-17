using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.EditingHistories
{
    public interface IEditingHistoryRepository
    {
        List<EditingHistory> FindRange(int offset, int limit);
        int GetCount();
        void Create(EditingHistory editingHistory);
    }
}
