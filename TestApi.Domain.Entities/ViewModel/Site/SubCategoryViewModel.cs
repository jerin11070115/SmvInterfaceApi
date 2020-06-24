using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.ViewModel.Site
{
    public class SubCategoryViewModel
    {
        public int SubCategoryId { get; set; }
        public string SubCategory { get; set; }
        public IEnumerable<SubSubCategoryViewModel> SubSubCategories { get; set; }
    }
}
