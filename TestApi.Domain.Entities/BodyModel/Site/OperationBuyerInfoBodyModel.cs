using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.BodyModel.Site
{
    public class OperationBuyerInfoBodyModel
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int SubSubCategoryId { get; set; }
        public int ItemId { get; set; }
        public int SubItemId { get; set; }
        public int BuyerId { get; set; }
        //public int SampleStageId { get; set; }
        //public int BuyerCategoryId { get; set; }
    }
}
