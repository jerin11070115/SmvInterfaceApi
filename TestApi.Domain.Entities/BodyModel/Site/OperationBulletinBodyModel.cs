using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.BodyModel.Site
{
    public class OperationBulletinBodyModel
    {
       //public int BuyerCatId { get; set; }
        public int BuyerId { get; set; }
        public int CategoryId { get; set; }
        public string Comments { get; set; }
        public string Component { get; set; }
        public int ComponentId { get; set; }
        public string DesignNumber { get; set; }
        public string GroupId { get; set; }
        public int ItemId { get; set; }
        public string Machine { get; set; }
        public int OperationId { get; set; }
        public string OperationName { get; set; }
        public string SampleDate { get; set; }
        public string SampleStage { get; set; }
        public string Season { get; set; }
        public double SmvValue { get; set; }
        public string StyleNumber { get; set; }
        public int SubCategoryId { get; set; }
        public int SubItemId { get; set; }
        public int SubSubCategoryId { get; set; }
        public int BufferPercentage { get; set; }
    }
}
