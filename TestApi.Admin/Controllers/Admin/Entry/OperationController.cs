using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestApi.Domain.Entities.BodyModel.Admin.Operation;
using TestApi.Services.Interfaces.Admin.Entry;

namespace TestApi.Admin.Controllers.Admin.Entry
{
    [RoutePrefix("api/Admin/Operation")]
    public class OperationController : ApiController
    {
        private readonly IOperationService _operationService;
        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpPost]
        [Route("AddOperation")]
        public async Task<IHttpActionResult> AddOperation()
        {
            return Ok(await _operationService.AddOperation());
        }
    }
}
