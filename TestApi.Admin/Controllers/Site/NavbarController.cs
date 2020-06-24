using System.Threading.Tasks;
using System.Web.Http;
using TestApi.Domain.Entities.BodyModel.Site;
using TestApi.Services.Interfaces.Site;

namespace TestApi.Admin.Controllers.Site
{
    [RoutePrefix("api/site/navbar")]
    public class NavbarController : ApiController
    {
        private readonly INavbarService _navbarService;
        public NavbarController(INavbarService navbarService)
        {
            _navbarService = navbarService;
        }

        [HttpGet]
        [Route("GetCategory")]
        public async Task<IHttpActionResult> GetCategoryForNavbar()
        {
            return Ok(await _navbarService.GetCategoryForNavbar());
        }

        [HttpGet]
        [Route("Menubar")]
        public async Task<IHttpActionResult> GetAllMenubarData()
        {
            return Ok(await _navbarService.GetAllMenubarData());
        }

        [HttpGet]
        [Route("BuyerMenu/{subItemId}")]
        public async Task<IHttpActionResult> GetBuyerMenuList(int subItemId)
        {
            return Ok(await _navbarService.GetBuyerMenuList(subItemId));
        }

        [HttpPost]
        [Route("CheckUserForLogin")]
        public async Task<IHttpActionResult> CheckUserForLogin([FromBody]UserBodyModel userBodyModel)
        {
            return Ok(await _navbarService.CheckUserForLogin(userBodyModel));
        }

        [HttpGet]
        [Route("LoadBuyerWiseSampleStage/{buyerId}")]
        public async Task<IHttpActionResult> LoadBuyerWiseSampleStage(int buyerId)
        {
            return Ok(await _navbarService.LoadBuyerWiseSampleStage(buyerId));
        }

        [HttpGet]
        [Route("LoadSamplestageBySampleStageId/{SampleStageId}")]
        public async Task<IHttpActionResult> LoadSamplestageBySampleStageId(int SampleStageId)
        {
            return Ok(await _navbarService.LoadSamplestageBySampleStageId(SampleStageId));
        }
    }
}
