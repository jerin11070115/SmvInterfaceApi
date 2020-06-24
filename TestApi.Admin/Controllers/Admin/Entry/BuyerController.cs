using System.Threading.Tasks;
using System.Web.Http;
using TestApi.Domain.Entities.BodyModel.Admin;
using TestApi.Services.Interfaces.Admin.Entry;

namespace TestApi.Admin.Controllers.Admin.Entry
{
    [RoutePrefix("api/Admin/Buyer")]
    public class BuyerController : ApiController
    {
        private readonly IBuyerService _buyerService;
        public BuyerController(IBuyerService buyerService)
        {
            _buyerService = buyerService;
        }

        [HttpPost]
        [Route("LogoUpload")]

        public async Task<IHttpActionResult> LogoUpload()
        {
            return Ok(await _buyerService.LogoUploadAsync());
        }

        [HttpPost]
        [Route("AddBuyerCategory")]
        public async Task<IHttpActionResult> AddBuyerCategory([FromBody]BuyerCategoryBodyModel buyerCategoryBodyModel)
        {
            return Ok(await _buyerService.AddBuyerCategory(buyerCategoryBodyModel));
        }


        [HttpGet]
        [Route("GetBuyerCategory/{buyerId}")]
        public async Task<IHttpActionResult> GetBuyerCategory(int buyerId)
        {
            return Ok(await _buyerService.GetBuyerCategory(buyerId));
        }

        [HttpPost]
        [Route("AddComponent")]
        public async Task<IHttpActionResult>AddComponent(/*[FromBody] BuyerComponentBodyModel buyerComponentBodyModel*/)
        {
            return Ok(await _buyerService.AddComponent(/*buyerComponentBodyModel*/));
        }


        [HttpPost]
        [Route("AddComponentStages")]
        public async Task<IHttpActionResult>AddComponentStage([FromBody] ComponentStageBodyModel componentStageBodyModel)
        {
            return Ok(await _buyerService.AddComponentStage(componentStageBodyModel));
        }
        [HttpGet]
        [Route("GetBuyerComponent")]
        public async Task<IHttpActionResult> GetBuyerComponent()
        {
            return Ok(await _buyerService.GetBuyerComponent());
        }
        [HttpGet]
        [Route("GetBuyerComponentStages/{componentId}")]
        public async Task<IHttpActionResult> GetBuyerComponentStages(int componentId)
        {
            return Ok(await _buyerService.GetBuyerComponentStages(componentId));
        }
        [HttpPost]
        [Route("AddSampleStage")]
        public async Task<IHttpActionResult> AddSampleStage(SampleStageBodyModel sampleStageBodyModel)
        {
            return Ok(await _buyerService.AddSampleStage(sampleStageBodyModel));
        }

        [HttpGet]
        [Route("GetBuyerSampleStages/{buyerId}")]
        public async Task<IHttpActionResult> GetBuyerSampleStages(int buyerId)
        {
            return Ok(await _buyerService.GetBuyerSampleStages(buyerId));
        }

        [HttpPost]
        [Route("AddBuyerMapping")]
        public async Task<IHttpActionResult> AddBuyerMapping(BuyerMappingBodyModel buyerMappingBodyModel)
        {
            return Ok(await _buyerService.AddBuyerMapping(buyerMappingBodyModel));
        }

        [HttpGet]
        [Route("GetBuyerComponentSubStages/{componentStageId}")]
        public async Task<IHttpActionResult> GetBuyerComponentSubStages(int componentStageId)
        {
            return Ok(await _buyerService.GetBuyerComponentSubStages(componentStageId));
        }


        [HttpPost]
        [Route("AddUserAccount")]
        public async Task<IHttpActionResult> AddUserAccount(UserInsertBodyModel userInsertBodyModel)
        {
            return Ok(await _buyerService.AddUserAccount(userInsertBodyModel));
        }
    }
}
