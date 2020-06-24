using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Domain.Entities.BodyModel.Site;
using TestApi.Domain.Entities.DataModel.Site.Buyer;
using TestApi.Domain.Entities.DataModel.Site.Navbar;
using TestApi.Domain.Entities.ViewModel.Site;

namespace TestApi.Services.Interfaces.Site
{
    public interface INavbarService
    {
        Task<IEnumerable<CategoryDataModel>> GetCategoryForNavbar();
        Task<IEnumerable<MenubarViewModel>> GetAllMenubarData();
        Task<IEnumerable<BuyerMenuViewModel>> GetBuyerMenuList(int SubItemId);
        Task<IEnumerable<UserDataModel>> CheckUserForLogin(UserBodyModel userBodyModel);
        Task<IEnumerable<BuyerWiseSampleStageDataModel>> LoadBuyerWiseSampleStage(int buyerId);
        Task<IEnumerable<BuyerWiseSampleStageDataModel>> LoadSamplestageBySampleStageId(int SampleStageId);
    }
}
