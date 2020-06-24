using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.DataModel.Admin
{
    public class CategoryDataModel
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int IsActive { get; set; }
        public DateTime PostedOn { get; set; }
        
    }
}
