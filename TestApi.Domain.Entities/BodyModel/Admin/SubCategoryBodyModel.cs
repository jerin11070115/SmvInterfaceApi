using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.BodyModel.Admin
{
    public class SubCategoryBodyModel
    {
        public string SubCategory { get; set; }
        public int CategoryId { get; set; }
        public int IsActive { get; set; }
    }
}
