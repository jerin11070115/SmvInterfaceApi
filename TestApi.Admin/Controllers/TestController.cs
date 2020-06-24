using System.Threading.Tasks;
using System.Web.Http;
using TestApi.Services.Interfaces;

namespace TestApi.Admin.Controllers
{
    [RoutePrefix("api/home")]
    
    public class TestController : ApiController
    {
        private readonly ITestService _testService;
       
        public TestController(ITestService testService)
        {
            _testService = testService;            
        }

        [HttpGet]
        [Route("GetCategoryInfo/{categoryId}")]
        public async Task<IHttpActionResult> GetCategoryInfo(string categoryId)
        {
            return Ok(await _testService.GetCategoryInfo(categoryId));
            //return Ok("2000");
        }

        [HttpGet]
        [Route("ok")]
        public async Task<IHttpActionResult> okcontrol()
        {
            return Ok(await _testService.GetAllCategoryInfo());
            //return Ok("himel");
        }

        [HttpGet]
        [Route("Category")]

        public async Task<IHttpActionResult> GetAllCategoryBindInfo()
        {
            return Ok(await _testService.GetAllCategoryBindInfo());
        }
    }
}
