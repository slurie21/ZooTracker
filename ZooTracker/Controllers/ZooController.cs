using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZooTracker.Filters.ActionFilters;

namespace ZooTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ServiceFilter(typeof(Auth_ConfirmJtiNotBlacklistedFilterAttribute))]
    public class ZooController : ControllerBase
    {
        [HttpPost("add")]
        [GetGuidForLogging]
        public async Task<IActionResult> AddZoo([FromBody] string tmp)
        {
            return Ok();
        }
    }
}
