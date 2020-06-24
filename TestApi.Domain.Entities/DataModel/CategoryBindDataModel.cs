using System;

namespace TestApi.Domain.Entities.DataModel
{
    public class CategoryBindDataModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int IsActive { get; set; }
        public DateTime PostedOn { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategory { get; set; }

        public int subSubcategoryId { get; set; }
        public string SubSubCategory { get; set; }
    }
}
