using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Domain.Entities.ViewModel.Site;

namespace TestApi.Services.Interfaces.Site
{
    public interface ISiteBuyerService
    {
        //Task<IEnumerable<ComponentViewModel>> GetComponentData(int buyerCategoryId);
        Task<IEnumerable<ComponentViewModel>> GetComponentDataNew();
    }
}
