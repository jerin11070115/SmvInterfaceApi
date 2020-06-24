using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.DataModel.Site.Operation
{
    public class OperationBuyerInfoDataModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategory { get; set; }
        public int SubSubCategoryId { get; set; }
        public string SubSubCategory { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int SubItemId { get; set; }
        public string SubItemName { get; set; }
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        //public int SampleStageId { get; set; }
        //public string SampleStage { get; set; }
        public int BuyerCategoryId { get; set; }
        public string BuyerCategory { get; set; }
    }
}
