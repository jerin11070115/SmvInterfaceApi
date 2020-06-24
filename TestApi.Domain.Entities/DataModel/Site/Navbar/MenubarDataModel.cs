using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.DataModel.Site.Navbar
{
    public class MenubarDataModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategory { get; set; }
        public int SubSubCategoryId { get; set; }
        public string SubSubCategory { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int SubItemId { get; set; }
        public string SubItemName { get; set; }
        //public int SubSubItemId { get; set; }
        //public string SubSubItem { get; set; }
    }
}
