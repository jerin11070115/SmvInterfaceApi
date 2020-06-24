using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.DataModel
{
    public class SubCategoryDataModel
    {
        public int SubCategoryId { get; set; }
        public string SubCategory { get; set; }
        public IEnumerable<SubSubCategoryDataModel> SubSubCategories { get; set; }
    }
}
