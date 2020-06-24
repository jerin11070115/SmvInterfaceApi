using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Domain.Entities.ViewModel.Site;
using TestApi.Domain.Interface.Site;
using TestApi.Services.Dependency;
using TestApi.Services.Interfaces.Site;

namespace TestApi.Services.Site
{
    [TransientLifetime]
    public class SiteBuyerService: ISiteBuyerService
    {
        private readonly ISiteBuyerRepository _siteBuyerRepository;
        public SiteBuyerService(ISiteBuyerRepository siteBuyerRepository)
        {
            _siteBuyerRepository = siteBuyerRepository;
        }

        //public async Task<IEnumerable<ComponentViewModel>> GetComponentData(int buyerCategoryId)
        //{
        //    try
        //    {
        //        var data = await _siteBuyerRepository.GetComponentData(buyerCategoryId);
        //        var query = from c in data
        //                    group c by c.ComponentId into ComponentMenu
        //                    select new ComponentViewModel
        //                    {
        //                        ComponentId = ComponentMenu.Key,
        //                        Component = (from c in ComponentMenu
        //                                     select c.Component
        //                                  ).FirstOrDefault(),
        //                        ComponentStageViewModel = (from bc in ComponentMenu
        //                                                   group bc by bc.ComponentStageId into ComponentCategoryData
        //                                                   select new ComponentStageViewModel
        //                                                   {
        //                                                       ComponentStageId = ComponentCategoryData.Key,
        //                                                       ComponentStage = (from sc in ComponentCategoryData select sc.ComponentStage).FirstOrDefault(),
        //                                                       ComponentCatViewModel = (from cc in ComponentCategoryData
        //                                                                                group cc by cc.ComponentStageCatId into ComponentCatData
        //                                                                                select new ComponentCatViewModel
        //                                                                                {
        //                                                                                    ComponentStageCatId = ComponentCatData.Key,
        //                                                                                    ComponentStageCat = (from ccd in ComponentCatData select ccd.ComponentStageCat).FirstOrDefault()
        //                                                                                })
        //                                                   })
        //                    };
        //        return query;
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //}

        public async Task<IEnumerable<ComponentViewModel>> GetComponentDataNew()
        {
            try
            {
                var data = await _siteBuyerRepository.GetComponentDataNew();
                var query = from c in data
                            group c by c.ComponentId into ComponentMenu
                            select new ComponentViewModel
                            {
                                ComponentId = ComponentMenu.Key,
                                Component = (from c in ComponentMenu
                                             select c.Component
                                           ).FirstOrDefault(),
                                ComponentStageViewModel = (from bc in ComponentMenu
                                                           where bc.ParentId == 0 && bc.ComponentStageId!=0
                                                           group bc by bc.ComponentStageId into ComponentCategoryData
                                                           select new ComponentStageViewModel
                                                           {
                                                               ComponentStageId = ComponentCategoryData.Key,
                                                               ComponentStage = (from sc in ComponentCategoryData select sc.ComponentStage).FirstOrDefault(),
                                                               ComponentCatViewModel = (from cc in ComponentMenu
                                                                                        where cc.ParentId== ComponentCategoryData.Key//ComponentCategoryData.Select(x => x.ComponentStageId).FirstOrDefault() //ComponentCategoryData.Key
                                                                                        && cc.ParentId!=0 && cc.ComponentStageId!=0
                                                                                        group cc by cc.ComponentStageId into ComponentCatData
                                                                                        select new ComponentCatViewModel
                                                                                        {
                                                                                            ComponentStageCatId = ComponentCatData.Key,
                                                                                            ComponentStageCat = (from ccd in ComponentCatData select ccd.ComponentStage).FirstOrDefault()
                                                                                        })
                                                           })
                            };
                return query;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }



    }
}
