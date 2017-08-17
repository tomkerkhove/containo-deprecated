using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Containo.API.Contracts;
using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace Containo.API.Controllers
{
    [Route("api/containers")]
    public class ContainersController : Controller
    {
        /// <summary>
        ///     Gets a all the running containers
        /// </summary>
        /// <response code="200">Returns list of all running containers</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Container>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get()
        {
            var dockerClusterEndpoint = new Uri("npipe://./pipe/docker_engine");
            var client = new DockerClientConfiguration(dockerClusterEndpoint).CreateClient();
            var containersListParameters = new ContainersListParameters
            {
                All = true
            };

            var containers = await client.Containers.ListContainersAsync(containersListParameters);

            var runningContainers = containers.Select(container => new Container
            {
                Id = container.ID,
                Image = container.Image,
                Status = container.Status,
                Labels = container.Labels,
                Names = container.Names,
                State = container.State
            }).ToList();

            return Ok(runningContainers);
        }
    }
}