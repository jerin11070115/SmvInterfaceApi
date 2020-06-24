using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.DataModel.Site.Navbar
{
    public class BuyerMenuListDataModel
    {
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        //public int SampleStageId { get; set; }
        //public string SampleStage { get; set; }
        public int BuyerCategoryId { get; set; }
        public string BuyerCategory { get; set; }
    }
}
