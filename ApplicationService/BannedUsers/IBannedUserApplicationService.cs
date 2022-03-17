using ApplicationService.BannedUsers.Delete;
using ApplicationService.BannedUsers.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.BannedUsers
{
    public interface IBannedUserApplicationService
    {
        BannedUserGetAllResult GetAll(BannedUserGetAllCommand command);
        void Delete(BannedUserDeleteCommand command);
    }
}
