using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Domain.Entities.BodyModel.Site;
using TestApi.Domain.Entities.DataModel.Site.Buyer;
using TestApi.Domain.Entities.DataModel.Site.Navbar;
using TestApi.Domain.Entities.ViewModel.Site;
using TestApi.Domain.Interface.Site;
using TestApi.Services.Dependency;
using TestApi.Services.Interfaces.Site;

namespace TestApi.Services.Site
{
    [TransientLifetime]
    public class NavbarService: INavbarService
    {
        private readonly INavbarRepository _navbarRepository;
        public NavbarService(INavbarRepository navbarRepository)
        {
            _navbarRepository = navbarRepository;
        }

        public async Task<IEnumerable<CategoryDataModel>> GetCategoryForNavbar()
        {
            return await _navbarRepository.GetCategoryForNavbar();
        }

        public async Task<IEnumerable<MenubarViewModel>> GetAllMenubarData()
        {
            var data = await _navbarRepository.GetAllMenubarData();

            var query = from c in data
                        group c by c.CategoryId into CategoryData
                        select new MenubarViewModel
                        {
                            CategoryId = CategoryData.Key,
                            CategoryName = (from c in CategoryData
                                            select c.CategoryName
                                          ).FirstOrDefault(),
                            
                            SubCategories = (from d in CategoryData where d.SubCategoryId!=0
                                             group d by d.SubCategoryId into SubCategoryData
                                             select new SubCategoryViewModel
                                             {
                                                 SubCategoryId = SubCategoryData.Key,
                                                 SubCategory = (from d in SubCategoryData select d.SubCategory).FirstOrDefault(),

                                                 SubSubCategories = (from sc in SubCategoryData where sc.SubSubCategoryId!=0
                                                                     group sc by sc.SubSubCategoryId into SubSubCategoryData
                                                                     select new SubSubCategoryViewModel
                                                                     {
                                                                         SubSubCategoryId = SubSubCategoryData.Key,
                                                                         SubSubCategory = (from sc in SubSubCategoryData select sc.SubSubCategory).FirstOrDefault(),
                                                                         Items=(from i in SubSubCategoryData where i.ItemId!=0
                                                                                group i by i.ItemId into ItemData
                                                                                select new ItemViewModel
                                                                                {
                                                                                    ItemId=ItemData.Key,
                                                                                    ItemName=(from i in ItemData select i.ItemName).FirstOrDefault(),
                                                                                    SubItems=(from si in ItemData where si.SubItemId!=0
                                                                                              group si by si.SubItemId into SubItemData
                                                                                              select new SubItemViewModel
                                                                                              {
                                                                                                  SubItemId=SubItemData.Key,
                                                                                                  SubItemName=(from si in SubItemData select si.SubItemName).FirstOrDefault()
                                                                                                  //SubSubItems=(from ssi in SubItemData
                                                                                                  //             group ssi by ssi.SubSubItemId into SubSubItemData
                                                                                                  //             select new SubSubItemViewModel
                                                                                                  //             {
                                                                                                  //                 SubSubItemId= SubSubItemData.Key,
                                                                                                  //                 SubSubItem=(from ssi in SubSubItemData select ssi.SubSubItem).FirstOrDefault()
                                                                                                  //             })
                                                                                              })
                                                                                })
                                                                     })
                                             })


                        };


            return query;
        }

        public async Task<IEnumerable<BuyerMenuViewModel>> GetBuyerMenuList(int SubItemId)
        {
            try
            {
                var data = await _navbarRepository.GetBuyerMenuList(SubItemId);
                var query = from c in data
                            group c by c.BuyerId into BuyerMenu
                            select new BuyerMenuViewModel
                            {
                                BuyerId = BuyerMenu.Key,
                                BuyerName = (from b in BuyerMenu
                                             select b.BuyerName
                                          ).FirstOrDefault(),
                                BuyerCategorys = (from bc in BuyerMenu
                                                  where bc.BuyerCategoryId != 0
                                                  group bc by bc.BuyerCategoryId into BuyerCategoryData
                                                  select new BuyerCategoryViewModel
                                                  {
                                                      BuyerCategoryId = BuyerCategoryData.Key,
                                                      BuyerCategory = (from bc in BuyerCategoryData select bc.BuyerCategory).FirstOrDefault()
                                                  })
                            };
                return query;


            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<UserDataModel>> CheckUserForLogin (UserBodyModel userBodyModel)
        {
            try
            {
                var data = await _navbarRepository.CheckUserForLogin(userBodyModel);
                return data;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        public async Task<IEnumerable<BuyerWiseSampleStageDataModel>> LoadBuyerWiseSampleStage(int buyerId)
        {

            try
            {
                var data = await _navbarRepository.LoadBuyerWiseSampleStage(buyerId);
                return data;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<BuyerWiseSampleStageDataModel>> LoadSamplestageBySampleStageId(int SampleStageId)
        {

            try
            {
                var data = await _navbarRepository.LoadSamplestageBySampleStageId(SampleStageId);
                return data;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


    }
}
