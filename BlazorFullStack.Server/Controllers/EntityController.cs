using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorFullStack.Shared.Framework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BlazorFullStack.Server.Controllers
{
    [Route("api/[controller]")]
    public class EntityController : Controller
    {
        private readonly MetadataService _service;
        private readonly IServiceProvider _provider;

        public EntityController(MetadataService service, IServiceProvider provider)
        {
            _service = service;
            _provider = provider;
        }

        [HttpPost("{entityId}/{queryId}")]

        public Task<IActionResult> ExecuteQuery(int entityId, int queryId, [FromBody]JObject parameters)
        {
            var metadata = _service.GetMetadata(entityId);
            var queryType = metadata.GetQuery(queryId);

            _provider.GetService(queryType);
        }
    }
}
