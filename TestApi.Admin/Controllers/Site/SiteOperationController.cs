using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestApi.Domain.Entities.BodyModel.Site;
using TestApi.Domain.Entities.DataModel.Site.Operation;
using TestApi.Services.Interfaces.Site;

namespace TestApi.Admin.Controllers.Site
{
    [RoutePrefix("api/site/operation")]
    public class SiteOperationController : ApiController
    {
        private readonly ISiteOperationService _siteOperationService;
        public SiteOperationController(ISiteOperationService siteOperationService)
        {
            _siteOperationService = siteOperationService;
        }

        [HttpPost]
        [Route("GetOperationData")]
        public async Task<IHttpActionResult> GetOperationData([FromBody]OperationRequestBodyModel operationRequestBodyModel)
        {
            return Ok(await _siteOperationService.GetOperationData(operationRequestBodyModel));
        }

        [HttpGet]
        [Route("GetBasicOperationDataForView/{buyerId}")]
        public async Task<IHttpActionResult> GetBasicOperationDataForView(int buyerId)
        {
            return Ok(await _siteOperationService.GetBasicOperationDataForView(buyerId));
        }

        [HttpPost]
        [Route("GetOperationSearchData")]
        public async Task<IHttpActionResult> GetOperationSearchData([FromBody]OperationSearchBodyModel operationSearchBodyModel)
        {
            return Ok(await _siteOperationService.GetOperationSearchData(operationSearchBodyModel));
        }


        [HttpPost]
        [Route("GetOperationBuyerInfo")]
        public async Task<IHttpActionResult> GetOperationBuyerInfo(OperationBuyerInfoBodyModel operationBuyerInfoBodyModel)
        {
            return Ok(await _siteOperationService.GetOperationBuyerInfo(operationBuyerInfoBodyModel));
        }

        [HttpPost]
        [Route("AddOperationBulletin")]

        public async Task<IHttpActionResult> AddOperationBulletin(List<OperationBulletinBodyModel> operationBulletinBodyModels)
        {
            return Ok(await _siteOperationService.AddOperationBulletin(operationBulletinBodyModels));
        }

        [HttpPost]
        [Route("GetBuyerStyleNumber")]

        public async Task<IHttpActionResult> GetBuyerStyleNumber(StyleSearchBodyModel styleSearchBodyModel)
        {
            return Ok(await _siteOperationService.GetBuyerStyleNumber(styleSearchBodyModel));
        }

        [HttpPost]
        [Route("GetOperationbBulletinSummary")]
        public async Task<IHttpActionResult> GetOperationBulletinSummary(StyleSearchBodyModel styleSearchBodyModel)
        {
            return Ok(await _siteOperationService.GetOperationBulletinSummary(styleSearchBodyModel));
        }

        [HttpPost]
        [Route("GetOperationbBulletinDetails")]
        public async Task<IHttpActionResult> GetOperationbBulletinDetails(OperationDetailsSearchBodyModel operationDetailsSearchBodyModel)
        {
            return Ok(await _siteOperationService.GetOperationbBulletinDetails(operationDetailsSearchBodyModel));
        }
    }
}
