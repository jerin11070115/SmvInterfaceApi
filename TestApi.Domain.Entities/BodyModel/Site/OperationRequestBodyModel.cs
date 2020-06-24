using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.BodyModel.Site
{
    public class OperationRequestBodyModel
    {
        public int BuyerId { get; set; }
        //public int BuyerCatId { get; set; }
        public int ComponentId { get; set; }
        public int ComponentCatId { get; set; }
        public int ComponentSubCatId { get; set; }
    }
}
