using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestApi.Services.Interfaces.Site;

namespace TestApi.Admin.Controllers.Site
{
    [RoutePrefix("api/site/buyer")]
    public class SiteBuyerController : ApiController
    {
        private readonly ISiteBuyerService _siteBuyerService;
        public SiteBuyerController (ISiteBuyerService siteBuyerService)
        {
            _siteBuyerService = siteBuyerService;
        }

        //[HttpGet]
        //[Route("GetComponentData/{buyerCategoryId}")]
        //public async Task<IHttpActionResult> GetComponentData(int buyerCategoryId)
        //{
        //    return Ok(await _siteBuyerService.GetComponentData(buyerCategoryId));
        //}

        [HttpGet]
        [Route("GetComponentDataNew")]
        public async Task<IHttpActionResult> GetComponentDataNew()
        {
            return Ok(await _siteBuyerService.GetComponentDataNew());
        }
    }
}
