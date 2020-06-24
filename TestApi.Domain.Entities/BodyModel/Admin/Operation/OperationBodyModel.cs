using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.BodyModel.Admin.Operation
{
    public class OperationBodyModel
    {
        public int OperationType { get; set; }
        public string OperationName { get; set; }
        public decimal SmvValue { get; set; }
        public string Machine { get; set; }
        public int BuyerId { get; set; }
        //public int BuyerCatId { get; set; }
        public int ComponentId { get; set; }
        public int ComponentCatId { get; set; }
        public int ComponentSubCatId { get; set; }
        public int IsActive { get; set; }       
    }
}
