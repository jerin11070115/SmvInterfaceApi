using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Domain.Entities.BodyModel.Admin;
using TestApi.Domain.Entities.DataModel.Admin;

namespace TestApi.Domain.Interface.Admin
{
    public interface IBuyerRepository
    {
        Task<int> InsertBuyerInfo(string buyerName, int isActive);
        Task<int> AddBuyerCategory(BuyerCategoryBodyModel buyerCategoryBodyModel);
        Task<IEnumerable<BuyerCategoryDataModel>> GetBuyerCategory(int buyerId);
        Task<int> AddComponent(BuyerComponentBodyModel buyerComponentBodyModel);
        Task<int> AddComponentStage(ComponentStageBodyModel componentStageBodyModel);
        Task<IEnumerable<BuyerComponentDataModel>> GetBuyerComponent();
        Task<IEnumerable<ComponentStageDataModel>> GetBuyerComponentStages(int componentId);
        Task<int> AddSampleStage(SampleStageBodyModel sampleStageBodyModel);
        Task<IEnumerable<SampleStageDataModel>> GetBuyerSampleStages(int buyerId);
        Task<int> AddBuyerMapping(BuyerMappingBodyModel buyerMappingBodyModel);
        Task<IEnumerable<ComponentStageDataModel>> GetBuyerComponentSubStages(int componentStageId);
        Task<int> AddUserAccount(UserInsertBodyModel userInsertBodyModel);
        
    }
}
