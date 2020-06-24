using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TestApi.Domain.Entities.BodyModel.Admin.Operation;
using TestApi.Domain.Entities.DataModel.Admin.Operation;
using TestApi.Domain.Interface.Admin;
using TestApi.Services.Dependency;
using TestApi.Services.Interfaces.Admin.Entry;

namespace TestApi.Services.Admin.Entry
{
    [TransientLifetime]
    public class OperationService: IOperationService
    {
        private readonly IOperationRepository _operationRepository;
        public OperationService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }
        public async Task<IEnumerable<OperationReturnDataModel>> AddOperation()
        {
            try
            {
                OperationBodyModel operationBodyModel = new OperationBodyModel();
                var httpRequest = HttpContext.Current.Request;

                var operationType = Convert.ToInt32(httpRequest.Form["OperationType"]);
                var operationName = httpRequest.Form["OperationName"].ToString();
                var smvValue =Convert.ToDecimal(httpRequest.Form["SmvValue"]);
                var machine= httpRequest.Form["Machine"].ToString();

                var buyerId =Convert.ToInt32(httpRequest.Form["BuyerId"]);
                //var buyerCategoryId = Convert.ToInt32(httpRequest.Form["BuyerCatId"]);
                var buyerComponentId = Convert.ToInt32(httpRequest.Form["ComponentId"]);
                var componentCatId = Convert.ToInt32(httpRequest.Form["ComponentCatId"]);
                var componentSubCatId = Convert.ToInt32(httpRequest.Form["ComponentSubCatId"]);
                var isActive = Convert.ToInt32(httpRequest.Form["IsActive"]);

                operationBodyModel.OperationType = operationType;
                operationBodyModel.OperationName = operationName;
                operationBodyModel.SmvValue = smvValue;
                operationBodyModel.Machine = machine;
                operationBodyModel.BuyerId = buyerId;
                //operationBodyModel.BuyerCatId = buyerCategoryId;
                operationBodyModel.ComponentId = buyerComponentId;
                operationBodyModel.ComponentCatId = componentCatId;
                operationBodyModel.ComponentSubCatId = componentSubCatId;
                operationBodyModel.IsActive = isActive;

               
               var ReturnDataModel = await _operationRepository.AddOperation(operationBodyModel);
                
                var data = (from c in ReturnDataModel
                            select c.NewOperationId).FirstOrDefault();
   

                if (ReturnDataModel.ToList().Count() > 0)
                {
                    if (httpRequest.Files.Count > 0)
                    {
                        foreach (string file in httpRequest.Files)
                        {
                            var postedFile = httpRequest.Files[file];
                            if (postedFile != null && postedFile.ContentLength > 0)
                            {
                                IList<string> AllowedFileExtensions = new List<string> { ".pdf"/*,".flv",".avi", ".mp4", ".mpg", ".wmv"*/ };
                                var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                                var extension = ext.ToLower();
                                if (AllowedFileExtensions.Contains(extension))
                                {
                                    //if(extension==".pdf")
                                    //{
                                        var filePath = HttpContext.Current.Server.MapPath("~/Files/GSD/" + data + extension);
                                        postedFile.SaveAs(filePath);
                                    //}
                                    //else
                                    //{
                                    //    var filePath = HttpContext.Current.Server.MapPath("~/Files/OperationVideos/" + OperationReturnDataModel + extension);
                                    //    postedFile.SaveAs(filePath);
                                    //}
                                }
                            }
                        }
                    }

                }
                    return ReturnDataModel;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            
        }
    }
}
