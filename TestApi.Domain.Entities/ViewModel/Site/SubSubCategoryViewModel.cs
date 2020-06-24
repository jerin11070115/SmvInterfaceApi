using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.ViewModel.Site
{
    public class SubSubCategoryViewModel
    {
        public int SubSubCategoryId { get; set; }
        public string SubSubCategory { get; set; }
        public IEnumerable<ItemViewModel> Items { get; set; }
    }
}
