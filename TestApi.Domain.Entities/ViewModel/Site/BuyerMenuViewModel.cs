using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.ViewModel.Site
{
    public class BuyerMenuViewModel
    {
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public IEnumerable<BuyerCategoryViewModel> BuyerCategorys { get; set; }
    }
}
