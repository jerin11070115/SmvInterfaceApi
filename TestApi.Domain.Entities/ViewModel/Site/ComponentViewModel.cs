using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.ViewModel.Site
{
    public class ComponentViewModel
    {
        public int ComponentId { get; set; }
        public string Component { get; set; }
        public IEnumerable<ComponentStageViewModel> ComponentStageViewModel { get; set; }
    }
}
