using System.Collections.Generic;
using System.Net;
using Containo.API.Contracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Containo.API.Controllers
{
    [Produces("application/json")]
    [Route("api/records")]
    public class RecordsController : Controller
    {
        private readonly List<Record> availableRecords = new List<Record>
        {
            new Record
            {
                Title = "The Same Sun",
                Artist = "Have Heart"
            }
        };

        [HttpGet]
        [SwaggerResponse((int) HttpStatusCode.OK, typeof(List<Record>), "List of all available records")]
        public OkObjectResult Get()
        {
            return Ok(availableRecords);
        }
    }
}