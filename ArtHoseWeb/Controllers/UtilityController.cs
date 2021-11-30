using Common;
using Shared.Enums;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ArtHoseWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilityController : ControllerBase
    {
        [HttpGet("GetEnumsDetailed")]
        public Task<IEnumerable<EnumDetail>> GetEnumsDetailedAsync()
        {
            return Help.GetEnumDetelsAsync(new[] { "Shared.Enums" });
        }
    }
}
