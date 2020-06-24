using System.Threading.Tasks;
using System.Web.Http;
using TestApi.Domain.Entities.BodyModel.Admin;
using TestApi.Services.Interfaces.Admin.MenuItem;

namespace TestApi.Admin.Controllers.Admin.MenuItem
{
    [RoutePrefix("api/Admin/MenuItem")]
    public class MenuItemController : ApiController
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }


        [HttpPost]
        [Route("Category/Insert")]
        public async Task<IHttpActionResult> AddCategory([FromBody] CategoryInsertModel categoryInsertModel)
        {
            return Ok(await _menuItemService.AddCategory(categoryInsertModel));
        }

        [HttpGet]
        [Route("Category/GetCategory")]
        public async Task<IHttpActionResult> GetCategory()
        {
            return Ok(await _menuItemService.GetCategory());
        }

        [HttpPost]
        [Route("SubSubCategory/Insert")]
        public async Task<IHttpActionResult> AddSubSubCategory([FromBody]SubSubCategoryBodyModel SubSubCategoryBodyModel)
        {
            return Ok(await _menuItemService.AddSubSubCategory(SubSubCategoryBodyModel));
        }

        [HttpPost]
        [Route("Item/Insert")]

        public async Task<IHttpActionResult> AddItem([FromBody]ItemBodyModel itemBodyModel)
        {
            return Ok(await _menuItemService.AddItem(itemBodyModel));
        }

        [HttpPost]
        [Route("SubCategory/Insert")]
        public async Task<IHttpActionResult> AddSubCategory([FromBody] SubCategoryBodyModel subCategoryBodyModel)
        {
            return Ok(await _menuItemService.AddSubcategory(subCategoryBodyModel));
        }

        [HttpGet]
        [Route("LoadSubcategory/{categoryId}")]
        public async Task<IHttpActionResult> GetSubCategory(int categoryId)
        {
            return Ok(await _menuItemService.GetSubCategory(categoryId));
        }


        [HttpGet]
        [Route("LoadSubSubcategory/{subCategoryId}")]
        public async Task<IHttpActionResult> GetSubSubCategory(int subCategoryId)
        {
            return Ok(await _menuItemService.GetSubSubCategory(subCategoryId));
        }

        [HttpPost]
        [Route("SubItem/Insert")]
        public async Task<IHttpActionResult> AddSubItem([FromBody]SubItemBodyModel subItemBodyModel)
        {
            return Ok(await _menuItemService.AddSubItem(subItemBodyModel));
        }

        [HttpGet]
        [Route("GetItems/{subSubCategoryId}")]
        public async Task<IHttpActionResult> GetItems(int subSubCategoryId)
        {
            return Ok(await _menuItemService.GetItems(subSubCategoryId));
        }

        //[HttpPost]
        //[Route("SubSubItem/Insert")]

        //public async Task<IHttpActionResult> AddSubSubItem([FromBody]SubSubItemBodyModel subSubItemBodyModel)
        //{
        //    return Ok(await _menuItemService.AddSubSubItem(subSubItemBodyModel));
        //}

        [HttpGet]
        [Route("GetSubItems/{ItemId}")]
        public async Task<IHttpActionResult> GetSubItems(int ItemId)
        {
            return Ok(await _menuItemService.GetSubItems(ItemId));
        }
        [HttpGet]
        [Route("GetBuyers")]
        public async Task<IHttpActionResult> GetBuyers()
        {
            return Ok(await _menuItemService.GetBuyers());
        }

        [HttpGet]
        [Route("GetAllCategory")]
        public async Task<IHttpActionResult>GetAllCategory()
        {
            return Ok(await _menuItemService.GetAllCategory());
        }

        [HttpGet]
        [Route("GetAllSubCategory")]
        public async Task<IHttpActionResult> GetAllSubCategory()
        {
            return Ok(await _menuItemService.GetAllSubCategory());
        }

        [HttpGet]
        [Route("GetAllSubSubCategory")]
        public async Task<IHttpActionResult> GetAllSubSubCategory()
        {
            return Ok(await _menuItemService.GetAllSubSubCategory());
        }
        [HttpGet]
        [Route("GetAllItems")]
        public async Task<IHttpActionResult> GetAllItems()
        {
            return Ok(await _menuItemService.GetAllItems());
        }

        [HttpGet]
        [Route("GetAllSubItems")]
        public async Task<IHttpActionResult> GetAllSubItems()
        {
            return Ok(await _menuItemService.GetAllSubItems());
        }
    }
} 
