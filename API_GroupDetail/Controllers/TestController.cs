using API_GroupDetail.DB.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GroupDetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly SchoolsDbContext _dbContext;

        public TestController(SchoolsDbContext dbContext) => _dbContext = dbContext;

        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            return Ok((await _dbContext.Group.Where(b => b.SchoolId == 170.ToString()).ToListAsync()));
        }
    }
}
