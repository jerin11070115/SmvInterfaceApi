using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.DataModel.Site.Buyer
{
    public class SiteBuyerComponentDataModel
    {
        public int ComponentId { get; set; }
        public string Component { get; set; }
        public int ComponentStageId { get; set; }
        public string ComponentStage { get; set; }
        public int ComponentStageCatId { get; set; }
        public string ComponentStageCat { get; set; }
        public int ParentId { get; set; }

    }
}
