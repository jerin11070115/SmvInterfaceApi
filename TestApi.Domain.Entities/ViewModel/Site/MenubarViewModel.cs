using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.ViewModel.Site
{
    public class MenubarViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<SubCategoryViewModel> SubCategories { get; set; }
    }
}
