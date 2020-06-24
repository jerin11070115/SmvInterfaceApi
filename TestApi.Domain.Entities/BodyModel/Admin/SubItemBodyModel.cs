using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.BodyModel.Admin
{
    public class SubItemBodyModel
    {
        public string SubItemName { get; set; }
        public int IsActive { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int SubSubCategoryId { get; set; }
        public int ItemId { get; set; }
    }
}
