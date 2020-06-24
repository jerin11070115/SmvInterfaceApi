using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Domain.Entities.BodyModel.Site;
using TestApi.Domain.Entities.DataModel.Site.Buyer;
using TestApi.Domain.Entities.DataModel.Site.Operation;

namespace TestApi.Services.Interfaces.Site
{
    public interface ISiteOperationService
    {
        Task<IEnumerable<OperationDataModel>> GetOperationData(OperationRequestBodyModel operationRequestBodyModel);
        Task<IEnumerable<OperationDataModel>> GetBasicOperationDataForView(int buyerId);
        Task<IEnumerable<OperationDataModel>> GetOperationSearchData(OperationSearchBodyModel operationSearchBodyModel);
        Task<IEnumerable<OperationBuyerInfoDataModel>> GetOperationBuyerInfo(OperationBuyerInfoBodyModel operationBuyerInfoBodyModel);
        Task<int> AddOperationBulletin(IEnumerable<OperationBulletinBodyModel> operationBulletinBodyModels);
        Task<IEnumerable<BuyerStyleNumberBodyModel>> GetBuyerStyleNumber(StyleSearchBodyModel styleSearchBodyModel);
        Task<IEnumerable<OperationBulletinSummaryDataModel>> GetOperationBulletinSummary(StyleSearchBodyModel styleSearchBodyModel);
        Task<IEnumerable<OperationBulletinSummaryDataModel>> GetOperationbBulletinDetails(OperationDetailsSearchBodyModel operationDetailsSearchBodyModel);
    }
}
