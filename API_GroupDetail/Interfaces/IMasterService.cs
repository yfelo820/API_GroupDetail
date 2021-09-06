using API_GroupDetail.DB.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GroupDetail.Interfaces
{
    public interface IMasterService
    {
        Task<MasterResponse> GetMasterResponse(Guid groupId, string username, int session);
    }
}
