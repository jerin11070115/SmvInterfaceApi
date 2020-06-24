using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Entities.ViewModel.Site
{
    public class ComponentStageViewModel
    {
        public int ComponentStageId { get; set; }
        public string ComponentStage { get; set; }
        public IEnumerable<ComponentCatViewModel> ComponentCatViewModel { get; set; }
    }
}
