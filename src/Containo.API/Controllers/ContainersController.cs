using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        [ProducesResponseType(typeof(List<Container>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult> Get()
        {
            try
            {
                var client = GetDockerClient();
                var containersListParameters = new ContainersListParameters
                {
                    All = true
                };

                var containers = await client.Containers.ListContainersAsync(containersListParameters);

                var runningContainers = containers.Select(container => new Contracts.Container
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
            catch (Exception ex)
            {
                return StatusCode(500, new {ErrorMessage = ex.Message});
            }
        }

        private static DockerClient GetDockerClient()
        {
            var dockerUri = Environment.GetEnvironmentVariable("DOCKER_URI");
            var dockerClusterEndpoint = new Uri(dockerUri);
            var client = new DockerClientConfiguration(dockerClusterEndpoint).CreateClient();
            return client;
        }
    }
}