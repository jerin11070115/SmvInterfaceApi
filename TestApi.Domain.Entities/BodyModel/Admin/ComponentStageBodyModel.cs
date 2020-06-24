using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.BodyModel.Admin
{
    public class ComponentStageBodyModel
    {
       
        public string ComponentStage { get; set; }
        public int ParentId { get; set; }
        public int ComponentId { get; set; }
        public int IsActive { get; set; }
    }
}
