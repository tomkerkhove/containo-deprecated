using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Containo.API.Controllers
{
    [Produces("application/json")]
    [Route("api/records")]
    public class RecordsController : Controller
    {
        [HttpGet]
        public OkObjectResult Get()
        {
            return Ok(new List<string> {"The Same Sun"});
        }
    }
}