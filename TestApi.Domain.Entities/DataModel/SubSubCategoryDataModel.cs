using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.DataModel
{
    public class SubSubCategoryDataModel
    {
        public int SubSubCategoryId { get; set; }
        public string SubSubCategory { get; set; }
        public IEnumerable<ItemDataModel> Items { get; set; }
    }
}
