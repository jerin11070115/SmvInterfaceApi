using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.BodyModel.Admin
{
    public class BuyerCategoryBodyModel
    {
        public string BuyerCategory { get; set; }
        public int BuyerId { get; set; }
        public int IsActive { get; set; }
        //public int SampleStageId { get; set; }
    }
}
