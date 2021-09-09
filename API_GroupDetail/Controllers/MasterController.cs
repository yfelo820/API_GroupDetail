using API_GroupDetail.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GroupDetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterService _masterService;

        public MasterController(IMasterService masterService) => _masterService = masterService;
        
        [HttpGet]
        public async Task<IActionResult> GetGroupDetail([FromQuery] Guid groupId, [FromQuery] string username, [FromQuery] int session)
        {
            return Ok(await _masterService.GetMasterResponse(groupId, username, session));
        }
        
    }
}
