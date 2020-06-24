using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.DataModel.Admin.TableModel
{
    public class SubSubCategoryTableDataModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategory { get; set; }
        public int SubSubCategoryId { get; set; }
        public string SubSubCategory { get; set; }
        public int IsActive { get; set; }
    }
}
