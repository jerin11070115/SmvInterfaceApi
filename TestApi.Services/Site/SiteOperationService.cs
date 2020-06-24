using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestApi.Domain.Entities.BodyModel.Site;
using TestApi.Domain.Entities.DataModel.Site.Buyer;
using TestApi.Domain.Entities.DataModel.Site.Operation;
using TestApi.Domain.Interface.Site;
using TestApi.Services.Dependency;
using TestApi.Services.Interfaces.Site;

namespace TestApi.Services.Site
{
    [TransientLifetime]
    public class SiteOperationService: ISiteOperationService
    {
        private readonly ISiteOperationRepository _siteOperationRepository;
        public SiteOperationService(ISiteOperationRepository siteOperationRepository)
        {
            _siteOperationRepository = siteOperationRepository;
        }
        public async Task<IEnumerable<OperationDataModel>> GetOperationData(OperationRequestBodyModel operationRequestBodyModel)
        {
            return await _siteOperationRepository.GetOperationData(operationRequestBodyModel);
        }

        public async Task<IEnumerable<OperationDataModel>> GetBasicOperationDataForView(int buyerId)
        {
            return await _siteOperationRepository.GetBasicOperationDataForView(buyerId);
        }

        public async Task<IEnumerable<OperationDataModel>> GetOperationSearchData(OperationSearchBodyModel operationSearchBodyModel)
        {
            return await _siteOperationRepository.GetOperationSearchData(operationSearchBodyModel);
        }
        public async Task<IEnumerable<OperationBuyerInfoDataModel>> GetOperationBuyerInfo(OperationBuyerInfoBodyModel operationBuyerInfoBodyModel)
        {
            return await _siteOperationRepository.GetOperationBuyerInfo(operationBuyerInfoBodyModel);
        }

        public async Task<int> AddOperationBulletin(IEnumerable<OperationBulletinBodyModel> operationBulletinBodyModels)
        {
            var data = ConvertDataTable(operationBulletinBodyModels);
            
            return await _siteOperationRepository.AddOperationBulletin(data);
        }
        protected DataTable ConvertDataTable<T>(IEnumerable<T> listToConvert)
        {
            var propertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var dataTable = new DataTable();
            foreach (var eachPropertyInfo in propertyInfo)
            {
                dataTable.Columns.Add(eachPropertyInfo.Name);
            }
            foreach (var eachObject in listToConvert)
            {
                var dataRow = dataTable.NewRow();
                try
                {
                    foreach (var eachPropertyInfo in propertyInfo)
                    {
                        dataRow[eachPropertyInfo.Name] = eachPropertyInfo.GetValue(eachObject, null);
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        public async Task<IEnumerable<BuyerStyleNumberBodyModel>> GetBuyerStyleNumber(StyleSearchBodyModel styleSearchBodyModel)
        {
            return await _siteOperationRepository.GetBuyerStyleNumber(styleSearchBodyModel);
        }

        public async Task<IEnumerable<OperationBulletinSummaryDataModel>> GetOperationBulletinSummary(StyleSearchBodyModel styleSearchBodyModel)
        {
            return await _siteOperationRepository.GetOperationBulletinSummary(styleSearchBodyModel);
        }

        public async Task<IEnumerable<OperationBulletinSummaryDataModel>> GetOperationbBulletinDetails(OperationDetailsSearchBodyModel operationDetailsSearchBodyModel)
        {
            return await _siteOperationRepository.GetOperationbBulletinDetails(operationDetailsSearchBodyModel);
        }
    }
}
