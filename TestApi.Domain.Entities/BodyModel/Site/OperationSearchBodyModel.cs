using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.BodyModel.Site
{
    public class OperationSearchBodyModel
    {
        public int BuyerId { get; set; }
        //public int BuyerCategoryId { get; set; }
        public string Keyword { get; set; }
    }
}
