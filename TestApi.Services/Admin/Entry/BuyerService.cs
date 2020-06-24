using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TestApi.Domain.Entities.BodyModel.Admin;
using TestApi.Domain.Entities.DataModel.Admin;
using TestApi.Domain.Interface.Admin;
using TestApi.Services.Dependency;
using TestApi.Services.Interfaces.Admin.Entry;

namespace TestApi.Services.Admin.Entry
{
    [TransientLifetime]
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepository _buyerRepository;
        public BuyerService(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task<int> LogoUploadAsync()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;


                string buyerName = httpRequest.Form["BuyerName"];
                int isActive = Convert.ToInt32(httpRequest.Form["IsActive"]);

                var result = await _buyerRepository.InsertBuyerInfo(buyerName, isActive);

                if (result > 0)
                {
                    if (httpRequest.Files.Count > 0)
                    {
                        foreach (string file in httpRequest.Files)
                        {
                            var postedFile = httpRequest.Files[file];

                            if (postedFile != null && postedFile.ContentLength > 0)
                            {
                                IList<string> AllowedFileExtensions = new List<string> { ".png" };
                                var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                                var extension = ext.ToLower();
                                if(AllowedFileExtensions.Contains(extension))
                                {
                                    var filePath = HttpContext.Current.Server.MapPath("~/Images/Buyers/" + buyerName.ToLower() + "_logo" + extension);
                                    postedFile.SaveAs(filePath);
                                }
                            }
                        }

                    }

                }
                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }


        }
        public async Task<int> AddBuyerCategory(BuyerCategoryBodyModel buyerCategoryBodyModel)
        {

            return await _buyerRepository.AddBuyerCategory(buyerCategoryBodyModel);

        }

        public async Task<IEnumerable<BuyerCategoryDataModel>> GetBuyerCategory(int buyerId)
        {
            return await _buyerRepository.GetBuyerCategory(buyerId);
        }
        public async Task<int> AddComponent(/*BuyerComponentBodyModel buyerComponentBodyModel*/)
        {
            try {
                BuyerComponentBodyModel buyerComponentBodyModel = new BuyerComponentBodyModel();
                var httpRequest = HttpContext.Current.Request;
                
                //int buyerId = Convert.ToInt32(httpRequest.Form["BuyerId"]);
                //int buyerCategoryId = Convert.ToInt32(httpRequest.Form["BuyerCategoryId"]);
                string component = httpRequest.Form["Component"];
                int isActive = Convert.ToInt32(httpRequest.Form["IsActive"]);

                //buyerComponentBodyModel.BuyerId = buyerId;
                //buyerComponentBodyModel.BuyerCategoryId = buyerCategoryId;
                buyerComponentBodyModel.Component = component;
                buyerComponentBodyModel.IsActive = isActive;

                var result = await _buyerRepository.AddComponent(buyerComponentBodyModel);

                if (result > 0)
                {
                    if (httpRequest.Files.Count > 0)
                    {
                        foreach (string file in httpRequest.Files)
                        {
                            var postedFile = httpRequest.Files[file];

                            if (postedFile != null && postedFile.ContentLength > 0)
                            {
                                IList<string> AllowedFileExtensions = new List<string> { ".png" };
                                var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                                var extension = ext.ToLower();
                                if (AllowedFileExtensions.Contains(extension))
                                {
                                    var filePath = HttpContext.Current.Server.MapPath("~/Images/Components/" +  component.ToLower() + extension);
                                    postedFile.SaveAs(filePath);
                                }
                            }
                        }

                    }

                }
                return result;


            }
            catch (Exception exception) {
                throw exception;
            }

        }
        public async Task<int> AddComponentStage(ComponentStageBodyModel componentStageBodyModel)
        {
            return await _buyerRepository.AddComponentStage(componentStageBodyModel);
        }
        public async Task<IEnumerable<BuyerComponentDataModel>> GetBuyerComponent()
        {
            return await _buyerRepository.GetBuyerComponent();
        }
        public async Task<IEnumerable<ComponentStageDataModel>> GetBuyerComponentStages(int componentId)
        {
            return await _buyerRepository.GetBuyerComponentStages(componentId);
        }

        public async Task<IEnumerable<ComponentStageDataModel>> GetBuyerComponentSubStages(int componentStageId)
        {
            return await _buyerRepository.GetBuyerComponentSubStages(componentStageId);
        }
        public async Task<int> AddSampleStage(SampleStageBodyModel sampleStageBodyModel)
        {
            return await _buyerRepository.AddSampleStage(sampleStageBodyModel);
        }

        public async Task<IEnumerable<SampleStageDataModel>> GetBuyerSampleStages(int buyerId)
        {
            return await _buyerRepository.GetBuyerSampleStages(buyerId);
        }
        public async Task<int> AddBuyerMapping(BuyerMappingBodyModel buyerMappingBodyModel)
        {
            return await _buyerRepository.AddBuyerMapping(buyerMappingBodyModel);
        }
        public async Task<int> AddUserAccount(UserInsertBodyModel userInsertBodyModel)
        {
            return await _buyerRepository.AddUserAccount(userInsertBodyModel);
        }
    }
}
