using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.DataModel.Site.Operation
{
    public class OperationBulletinSummaryDataModel
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
        //public int BuyerCatId { get; set; }
        //public string BuyerCategory { get; set; }
        public int ComponentId { get; set; }
        public string Component { get; set; }
        public string StyleNumber { get; set; }
        public string DesignNumber { get; set; }
        public string SampleDate { get; set; }
        public string SampleStage { get; set; }
        public string GroupId { get; set; }
        public DateTime PostedOn { get; set; }

        public string Season { get; set; }
        public int OperationId { get; set; }
        public string OperationName { get; set; }
        public string SmvValue { get; set; }
        public string Machine { get; set; }
        public string Comments { get; set; }
        public float BufferPercentage { get; set; }
    }
}
